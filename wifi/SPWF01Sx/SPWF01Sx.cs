using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Oxage
{
    public class SPWF01Sx
    {
        #region Members
        private bool wait;
        private Regex reAsync;
        private Regex reConfig;
        private Regex reResponse;
        private SerialPort com;
        private BackgroundWorker worker;
        #endregion

        #region Constructor
        public SPWF01Sx()
        {
            //Default values
            this.Timeout = 2000; //Approx. 2000 milliseconds
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether to display debug info in console.
        /// </summary>
        public bool Debug { get; set; }

        /// <summary>
        /// Gets or sets a timeout for synchronous methods to wait for response. Value in milliseconds.
        /// </summary>
        public int Timeout { get; set; }
        #endregion

        #region Core methods
        /// <summary>
        /// Sends a command without waiting for response.
        /// </summary>
        /// <param name="command">AT command without &lt;cr&gt;</param>
        public void WriteAsync(string command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            if (command.Length > 127 + 2) //2 for AT prefix
            {
                //AT + 127 chars according to the documentation
                throw new ArgumentException("Maximum command length is 127 chars!", "command");
            }

            if (command.Contains('\r'))
            {
                throw new ArgumentException("Command must not contain <cr>!", "command");
            }

            //Send the command
            byte[] data = Encoding.UTF8.GetBytes(command + "\r");
            com.Write(data, 0, data.Length);

            //NOTE: Turn off 'localecho' flag on the module to avoid duplicate outputs in console
            if (this.Debug)
            {
                Console.WriteLine(command);
            }
        }

        /// <summary>
        /// Sends a command and waits for response. Throws exception if the module response with ERROR code.
        /// </summary>
        /// <param name="command">AT command without &lt;cr&gt;</param>
        /// <returns>Returns the response string.</returns>
        /// <exception cref="WifiException">Module responded with ERROR code.</exception>
        /// <exception cref="TimeoutException">Timeout expired.</exception>
        public string Write(string command)
        {
            WriteAsync(command);

            //Stop the listener for a while
            wait = true;

            var builder = new StringBuilder();

            try
            {
                //Wait for response
                int timeout = this.Timeout;
                bool reading = true;
                while (reading && timeout > 0)
                {
                    while (com.BytesToRead > 0)
                    {
                        const int length = 1024;
                        byte[] buffer = new byte[length];
                        int size = com.Read(buffer, 0, length);

                        string output = Encoding.UTF8.GetString(buffer, 0, size);

                        if (this.Debug)
                        {
                            Console.Write(output);
                        }

                        builder.Append(output);

                        //Check if completed
                        //<cr><lf><responsecode><cr><lf>
                        //OK
                        //ERROR: <descriptive text>
                        string response = builder.ToString();
                        var match = reResponse.Match(response);
                        if (match.Success)
                        {
                            reading = false;

                            string code = match.Groups["code"].Value;
                            string message = match.Groups["message"].Value;

                            if (code == "ERROR")
                            {
                                throw new WifiException(message);
                            }

                            break;
                        }
                    }

                    Thread.Sleep(1);
                    timeout--;
                }

                if (timeout == 0)
                {
                    //No response from the module...
                    throw new TimeoutException("Read timeout expired!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Listen loop can continue now
                wait = false;
            }

            string result = builder.ToString();
            return result;
        }

        /// <summary>
        /// Listens for async responses.
        /// </summary>
        protected void Listen()
        {
            var builder = new StringBuilder();

            while (true)
            {
                if (!wait)
                {
                    while (com != null && com.IsOpen && com.BytesToRead > 0)
                    {
                        const int length = 1024;
                        byte[] buffer = new byte[length];
                        int size = com.Read(buffer, 0, length);

                        //Decode the message
                        string output = Encoding.UTF8.GetString(buffer, 0, size);
                        builder.Append(output);

                        if (this.Debug)
                        {
                            Console.Write(output);
                        }

                        //Parse async data
                        string response = builder.ToString();
                        var match = reAsync.Match(response);
                        if (match.Success)
                        {
                            int number = int.Parse(match.Groups["num"].Value);
                            string message = match.Groups["message"].Value;
                            OnAsyncResponse(number, message);
                            builder = new StringBuilder();
                        }
                    }
                }

                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Encodes special chars in string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string Escape(string value)
        {
            //TODO: Encode ',' in value
            return value;
        }

        /// <summary>
        /// Opens a serial port connection, runs background thread, and initializes variables.
        /// </summary>
        /// <param name="port">Serial port name, e.g. COM1</param>
        /// <param name="baud">Serial port baud rate, e.g. 115200</param>
        public void Open(string port, int baud = 115200)
        {
            //Rule: <cr><lf>OK<cr><lf> or <cr><lf>ERROR: message goes here<cr><lf>
            reResponse = new Regex(@"\r\n((?<code>OK|ERROR)(:(?<message>.+?))?)(\r\n)", RegexOptions.Compiled);

            //Rule: <cr><lf>+WIND:<number>:<descriptive string><cr><lf>
            reAsync = new Regex(@"\r\n\+WIND:(?<num>\d+):(?<message>.+?)(\r\n)", RegexOptions.Compiled);

            //Rule: # ip_ipaddr = 192.168.0.50<cr><lf>
            reConfig = new Regex(@"#\s*(?<key>[A-Za-z0-9_]+)\s*=\s*(?<value>.*?)(\r\n)", RegexOptions.Compiled);

            //Create a serial port connection
            com = new SerialPort();
            com.PortName = port;
            com.BaudRate = baud;
            com.ReadTimeout = 1000;
            com.WriteTimeout = 1000;
            com.Open();

            //Run async response listener in background thread
            worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                Listen();
            };
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Closes the serial port connection.
        /// </summary>
        public void Close()
        {
            //Politely close the background thread
            if (worker != null && worker.IsBusy && worker.WorkerSupportsCancellation)
            {
                worker.CancelAsync();
                while (worker.CancellationPending)
                {
                    Thread.Sleep(1);
                }
                worker = null;
            }

            //Close the serial port connection
            if (com != null)
            {
                com.Close();
                com = null;
            }
        }

        /// <summary>
        /// Occurs when an async indicator is received.
        /// </summary>
        public event EventHandler<AsyncResponseEventArgs> AsyncResponse;
        protected virtual void OnAsyncResponse(int number, string message)
        {
            if (AsyncResponse != null)
            {
                var args = new AsyncResponseEventArgs();
                args.Number = number;
                args.Message = message;
                AsyncResponse(this, args);
            }
        }
        #endregion

        #region AT commands
        /// <summary>
        /// Tests the connection with "AT" command.
        /// </summary>
        public void Test()
        {
            Write("AT");
        }

        /// <summary>
        /// Performs a soft reset on the device.
        /// </summary>
        public void Reset()
        {
            WriteAsync("AT+CFUN=1");
        }

        /// <summary>
        /// Resets to factory defaults.
        /// </summary>
        public void FactoryReset()
        {
            Write("AT&F");
        }

        /// <summary>
        /// Saves settings to internal storage.
        /// </summary>
        public void SaveSettings()
        {
            Write("AT&W");
        }

        /// <summary>
        /// Prints available AT commands to the console.
        /// </summary>
        public void PrintHelp()
        {
            Write("AT+S.HELP");
        }

        /// <summary>
        /// Prints current configuration variables to the console.
        /// </summary>
        public void PrintConfig()
        {
            Write("AT&V");
        }

        /// <summary>
        /// Prints status/statistics to the console.
        /// </summary>
        public void PrintStatus()
        {
            Write("AT+S.STS");
        }

        /// <summary>
        /// Prints list of available files on the flash.
        /// </summary>
        public void PrintFileList()
        {
            Write("AT+S.FSL");
        }

        /// <summary>
        /// Prints the content of a specific file.
        /// </summary>
        /// <param name="filename"></param>
        public void PrintFileContent(string filename)
        {
            Write("AT+S.FSP=" + filename);
        }

        /// <summary>
        /// Gets a configuration value.
        /// </summary>
        /// <param name="key">Name of the configuration variable.</param>
        /// <returns>Returns configuration value.</returns>
        public string GetConfig(string key)
        {
            string result = Write("AT+S.GCFG=" + key);

            var match = reConfig.Match(result);
            if (match.Success)
            {
                return match.Groups["value"].Value;
            }

            throw new WifiException("Unexpected config result: " + result);
        }

        /// <summary>
        /// Gets a configuration value.
        /// </summary>
        /// <typeparam name="TResult">Type of expected result value.</typeparam>
        /// <param name="key">Name of the configuration variable.</param>
        /// <returns>Returns configuration value converted to the specified type.</returns>
        public TResult GetConfig<TResult>(string key)
        {
            string value = GetConfig(key);
            if (typeof(TResult) == typeof(string))
            {
                return (TResult)(object)value;
            }

            object result = Convert.ChangeType(value, typeof(TResult));
            return (TResult)result;
        }

        /// <summary>
        /// Sets configuration value.
        /// </summary>
        /// <param name="key">Name of the configuration variable.</param>
        /// <param name="value">Value to store in the variable.</param>
        public void SetConfig(string key, object value)
        {
            Write("AT+S.SCFG=" + key + "," + (value != null ? Escape(value.ToString()) : null));
        }

        /// <summary>
        /// Gets the textual SSID value.
        /// </summary>
        public string GetSSID()
        {
            string result = Write("AT+S.SSIDTXT");
            return result;
        }

        /// <summary>
        /// Sets the textual SSID value.
        /// </summary>
        /// <param name="ssid"></param>
        public void SetSSID(string ssid)
        {
            if (string.IsNullOrEmpty(ssid))
            {
                throw new ArgumentException("SSID is required!");
            }

            if (ssid.Length > 32)
            {
                throw new ArgumentException("SSID must be 1-32 chars in length!");
            }

            Write("AT+S.SSIDTXT=" + Escape(ssid));
        }

        /// <summary>
        /// Sets a value indicating whether the WiFi is ON or OFF.
        /// </summary>
        /// <param name="enable"></param>
        public void SetWifiState(bool enable)
        {
            Write("AT+S.WIFI=" + (enable ? 1 : 0));
        }

        public void InitGPIO(int num, PinDirection direction, PinInterrupt interrupt = PinInterrupt.Unknown)
        {
            string dir = (direction == PinDirection.Input ? "in" : "out");
            string inter = (interrupt != PinInterrupt.Unknown ? "," + (char)interrupt : "");
            Write("AT+S.GPIOC=" + num + "," + dir + inter);
        }

        public void ReadGPIO(int num)
        {
            Write("AT+S.GPIOR=" + num);
        }

        public void WriteGPIO(int num, bool state)
        {
            Write("AT+S.GPIOW=" + num + "," + (state ? 1 : 0));
        }

        public void Roam()
        {
            Write("AT+S.ROAM");
        }

        public IEnumerable<ScanResult> Scan()
        {
            //AT+S.SCAN
            //FOUND:  BSS 00:26:18:22:2B:89 CHAN: 05 RSSI: -19 SSID: 'demo1' CAPS: 0411 WPA: 0 WPA2: 20
            //FOUND:  BSS 00:1F:C6:27:F6:80 CHAN: 05 RSSI: -70 SSID: 'demo2' CAPS: 0411 WPA: 0 WPA2: 20
            //FOUND:  BSS 00:26:18:22:2B:89 CHAN: 05 RSSI: -19 SSID: 'demo3' CAPS: 0411 WPA: 0 WPA2: 20
            string result = Write("AT+S.SCAN");

            var regex = new Regex(@"\s*FOUND:\s*BSS\s(?<bss>[0-9A-F:]+)\s+CHAN:\s*(?<chan>[0-9]+)\s+RSSI:\s*(?<rssi>[0-9\-]+)\s+SSID:\s*'(?<ssid>.*?)'\s+CAPS:\s*(?<caps>[0-9]+)\s+WPA:\s*(?<wpa>[0-9]+)\s+WPA2:\s*(?<wpa2>[0-9]+)", RegexOptions.Compiled);
            var values = result.Split('\r');
            foreach (var value in values)
            {
                var match = regex.Match(value);
                if (match.Success)
                {
                    yield return new ScanResult()
                    {
                        BSS = match.Groups["bss"].Value,
                        Channel = int.Parse(match.Groups["chan"].Value),
                        RSSI = int.Parse(match.Groups["rssi"].Value),
                        SSID = match.Groups["ssid"].Value,
                        Capabilities = match.Groups["caps"].Value,
                        //Security = //TODO: Get security value
                    };
                }
            }
        }

        public IEnumerable<KeyValuePair> GetStatus()
        {
            //AT+S.STS
            //#  version = 1203-121218_01-50-g511fab4-stm_demo 
            //#  reset_reason = 0
            string result = Write("AT+S.STS");
            return GetVariables(result);
        }

        public IEnumerable<KeyValuePair> GetVariables()
        {
            //AT&V
            //#  version = 1203-121218_01-50-g511fab4-stm_demo 
            //#  reset_reason = 0
            string result = Write("AT&V");
            return GetVariables(result);
        }

        protected IEnumerable<KeyValuePair> GetVariables(string result)
        {
            var regex = new Regex(@"\s*#\s*(?<key>[\w\d_]+)\s*=\s*(?<value>.*)", RegexOptions.Compiled);
            var values = result.Split('\r');
            foreach (var value in values)
            {
                var match = regex.Match(value);
                if (match.Success)
                {
                    yield return new KeyValuePair()
                    {
                        Key = match.Groups["key"].Value,
                        Value = match.Groups["value"].Value.Trim()
                    };
                }
            }
        }

        public IEnumerable<WifiFileInfo> GetFiles()
        {
            //AT+S.FSL
            // I 184 /status.shtml
            // I 596 /index.html
            // I 331 /cgi_demo.html
            // I 623 /power_demo.shtml
            // I 203 /config.shtml
            // I 464 /index.html
            // I 213 /404.html
            string result = Write("AT+S.FSL");

            var regex = new Regex(@"\s*(?<type>[DI])\s+(?<size>\d+)\s+(?<path>.+)", RegexOptions.Compiled);
            var values = result.Split('\r');
            foreach (var value in values)
            {
                var match = regex.Match(value);
                if (match.Success)
                {
                    yield return new WifiFileInfo()
                    {
                        IsDirectory = (match.Groups["type"].Value == "D"),
                        Size = int.Parse(match.Groups["size"].Value),
                        Path = match.Groups["path"].Value,
                    };
                }
            }
        }

        public void Ping(string host)
        {
            Write("AT+S.PING=" + host);
        }

        public string HttpRequest(string url)
        {
            Uri uri = new Uri(url);
            string result = Write("AT+S.HTTPGET=" + uri.Host + "," + uri.PathAndQuery);
            return result;
        }

        /// <summary>
        /// Performs firmware update.
        /// </summary>
        /// <param name="url">Link to the firmware image.</param>
        public void UpdateFirmware(string url)
        {
            Uri uri = new Uri(url);
            string result = Write("AT+S.FWUPDATE=" + uri.Host + "," + uri.PathAndQuery);
            //TODO: Reboot?
        }

        /// <summary>
        /// Updates file system from an image.
        /// </summary>
        /// <param name="url">Link to the file system image.</param>
        public void UpdateFileSystem(string url)
        {
            Uri uri = new Uri(url);
            string result = Write("AT+S.HTTPDFSUPDATE=" + uri.Host + "," + uri.PathAndQuery);
        }

        public string OpenSocket(string host, int port, SocketType protocol, bool indicate = false)
        {
            string response = Write("AT+S.SOCKON=" + host + "," + port + "," + (char)protocol + (indicate ? ",ind" : ""));

            var match = Regex.Match(response, @"ID:\s*(?<id>\d+)");
            if (match.Success)
            {
                return match.Groups["id"].Value;
            }

            return null;
        }

        /// <summary>
        /// Opens a socket to UARTx.
        /// </summary>
        /// <param name="uart">UART number.</param>
        public void OpenSerial(int uart)
        {
            string response = Write("AT+S.SOCKOS=" + uart);
        }

        /// <summary>
        /// Writes data to socket.
        /// </summary>
        public void WriteSocket(string id, byte[] data)
        {
            Write("AT+S.SOCKW=" + id + "," + data.Length + "\r" + data);
        }

        public int QuerySocket(string id)
        {
            string response = Write("AT+S.SOCKQ=" + id);

            var match = Regex.Match(response, @"DATALEN:\s*(?<len>\d+)");
            if (match.Success)
            {
                int length = int.Parse(match.Groups["len"].Value);
                return length;
            }

            return -1;
        }

        public string ReadSocket(string id, int length)
        {
            string response = Write("AT+S.SOCKR=" + id + "," + length);

            var match = Regex.Match(response, @"DATALEN:\s*(?<len>\d+)");
            //if (match.Success)
            //{
            //    int length = int.Parse(match.Groups["len"].Value);
            //    return length;
            //}

            return response;
        }

        public void CloseSocket(string id, int length)
        {
            Write("AT+S.SOCKC=" + id);
        }

        /// <summary>
        /// Creates a static file.
        /// </summary>
        /// <param name="filename">File name, e.g. "/new.html"</param>
        /// <param name="length">Amount of bytes to allocate for file, max. 4096 bytes</param>
        public void CreateFile(string filename, int length)
        {
            Write("AT+S.FSC=" + filename + "," + length);
        }

        public void AppendFile(string filename, string content)
        {
            AppendFile(filename, Encoding.UTF8.GetBytes(content));
        }

        /// <summary>
        /// Appends data to a file.
        /// </summary>
        /// <param name="filename">File name, e.g. "/new.html"</param>
        /// <param name="data">Data to append</param>
        public void AppendFile(string filename, byte[] data)
        {
            WriteAsync("AT+S.FSA=" + filename + "," + data.Length);
            com.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Delete a file.
        /// </summary>
        public void DeleteFile(string filename)
        {
            Write("AT+S.FSD=" + filename);
        }

        public string ReadFile(string filename)
        {
            string response = Write("AT+S.FSP=" + filename);
            return response;
        }

        public void ConfigureCertificateStore(string type, byte[] data)
        {
            WriteAsync("AT+S.PEMDATA=" + type + "," + data.Length);
            com.Write(data, 0, data.Length);
        }

        public void ConfigureCertificateStore(CertificateType type, byte[] data)
        {
            ConfigureCertificateStore(type.ToString().ToLower(), data);
        }
        #endregion
    }
}

using System;
using System.Diagnostics;
using System.Threading;

namespace Oxage
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
                args = new string[] { "COM24", "115200" };
            }
#endif

            //Usage info
            if (args == null || args.Length < 2 || args[0] == "--help")
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("  spwf [port] [baud]");
                Console.WriteLine();
                Console.WriteLine("Examples:");
                Console.WriteLine("  spwf COM1 115200");
                Console.WriteLine();
                Console.WriteLine("Notes:");
                Console.WriteLine("  SPWF defaults: 115200 8N1");
                return;
            }

            //Parse command line arguments
            string port = args[0];
            int baud = (args.Length > 1 ? int.Parse(args[1]) : 115200);

            //Open the connection
            SPWF01Sx driver = new SPWF01Sx();
            driver.Debug = true;
            driver.Open(port, baud);

            bool running = true;
            while (running)
            {
                try
                {
                    while (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.Escape:
                                running = false;
                                break;

                            case ConsoleKey.Enter:
                                break;

                            case ConsoleKey.F1:
                                driver.Test();
                                break;

                            case ConsoleKey.F2:
                                driver.Scan();
                                break;

                            case ConsoleKey.F3:
                                driver.Reset();
                                break;

                            case ConsoleKey.F4:
                                driver.SetWifiState(true);
                                break;

                            case ConsoleKey.F5:
                                driver.SetWifiState(false);
                                break;

                            case ConsoleKey.F6:
                                driver.Ping("192.168.1.1");
                                break;

                            case ConsoleKey.F7:
                                string ip = driver.GetConfig("ip_ipaddr");
                                string gw = driver.GetConfig("ip_gw");
                                //string host = driver.GetConfig(WifiConfig.ip_hostname);
                                //string version = driver.GetConfig(WifiConfig.version);
                                //string bssid = driver.GetConfig(WifiConfig.wifi_bssid);
                                //var state = (WifiState)driver.GetConfig<int>(WifiConfig.wifi_state);
                                break;

                            case ConsoleKey.F8:
                                driver.PrintConfig();
                                break;

                            case ConsoleKey.D0:
                                driver.SetConfig("wifi_mode", 0);
                                break;

                            case ConsoleKey.D1:
                                driver.SetConfig("wifi_mode", 1);
                                break;

                            case ConsoleKey.D2:
                                driver.SetConfig("wifi_mode", 2);
                                break;

                            case ConsoleKey.A:
                                driver.SetSSID("spwf");
                                break;

                            case ConsoleKey.S:
                                driver.SetSSID("demo");
                                //driver.SetConfig("wifi_mode", "1"); //1 for STA (client station)
                                driver.SetWifiState(true);
                                driver.SetConfig("wifi_auth_type", "0"); //1 for shared key
                                driver.SetConfig("wifi_priv_mode", "2"); //2 for WPA/WPA2
                                driver.SetConfig("wifi_wpa_psk_text", "demodemo");
                                driver.SetConfig("ip_use_dhcp", "1");
                                driver.SaveSettings();
                                driver.Reset();
                                break;

                            case ConsoleKey.R:
                                driver.Roam();
                                break;

                            case ConsoleKey.E:
                                //Toggle echo to console
                                bool echo = (driver.GetConfig("localecho1") == "1");
                                driver.SetConfig("localecho1", echo ? "0" : "1");
                                driver.SetConfig("localecho2", echo ? "0" : "1");
                                driver.SetConfig("localecho3", echo ? "0" : "1");
                                break;

                            case ConsoleKey.G:
                                driver.GetConfig("wifi_state");
                                break;

                            //Procedure by the documentation
                            case ConsoleKey.P:
                                driver.SetConfig("wifi_mode", "0");
                                driver.SaveSettings();
                                driver.Reset();
                                break;

                            case ConsoleKey.O:
                                driver.SetConfig("wifi_priv_mode", "0");
                                driver.SetConfig("ip_use_dhcp", "1");
                                driver.SetSSID("ExampleSSID");
                                driver.SetConfig("wifi_mode", "1");
                                driver.SaveSettings();
                                driver.Reset();
                                break;

                            default:
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Thread.Sleep(1);
            }

            driver.Close();
        }
    }
}

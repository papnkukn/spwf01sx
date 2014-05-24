using System;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Oxage
{
    public partial class MainForm : Form
    {
        private SPWF01Sx wifi;
        private TextBoxWriter writer;

        public MainForm()
        {
            InitializeComponent();
            InitializeSerialPorts();

            //Default values
            tabs.Enabled = false;
            cmbSecurity.SelectedIndex = 2; //WPA/WPA2 by default

            dgEvents.RowHeadersWidth = 10;
            dgEvents.Columns.Add("wind", "WIND");
            dgEvents.Columns.Add("message", "Message");
            dgEvents.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //ToolTips and hints
            new ToolTip().SetToolTip(txtFirmware, "Enter URL to firmware image.");
            new ToolTip().SetToolTip(txtFileSystem, "Enter URL to file system image.");
            new ToolTip().SetToolTip(txtPingHost, "Enter host or IP address to ping.");

            //Handle thread exceptions
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            //Redirect standard console output to a textbox
            writer = new TextBoxWriter(txtLog);
            Console.SetOut(writer);

            //Initialize SPWF01Sx object
            wifi = new SPWF01Sx();
            wifi.Debug = true;
            wifi.AsyncResponse += new EventHandler<AsyncResponseEventArgs>(wifi_AsyncResponse);
        }

        protected void UpdateSize()
        {
            tabs.Height = this.Height - 102;
            cmbCommand.Width = tabConsole.Width - 173;
            txtLog.Width = tabConsole.Width - 12;
            txtLog.Height = tabConsole.Height - 58;
            txtPassword.Width = tabConnection.Width - 458;
            dgStatus.Height = tabStatus.Height - 33;
            dgFiles.Height = tabFiles.Height - 33;
            dgConfig.Height = tabConfig.Height - 33;
            dgEvents.Height = tabEvents.Height - 33;
            dgScanResults.Height = tabConnection.Height - 49;
        }

        protected void InitializeSerialPorts()
        {
            cmbPort.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                //Regex matches the COMx where x is a number
                var match = Regex.Match(port, @"(?<port>COM\d+)");
                if (match.Success)
                {
                    cmbPort.Items.Add(match.Groups["port"].Value);
                }
            }

            if (cmbPort.Items.Count > 0)
            {
                cmbPort.SelectedIndex = 0;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void wifi_AsyncResponse(object sender, AsyncResponseEventArgs e)
        {
            dgEvents.Invoke(new CrossThreadDelegate(() =>
            {
                dgEvents.Rows.Add(e.Number, e.Message);
            }));
        }

        private void btnClearEvents_Click(object sender, EventArgs e)
        {
            dgEvents.Rows.Clear();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            wifi.Open(cmbPort.Text);
            cmbPort.Enabled = false;
            btnClose.Visible = true;
            btnOpen.Visible = false;
            btnTest.Enabled = true;
            tabs.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            wifi.Close();
            cmbPort.Enabled = true;
            btnClose.Visible = false;
            btnOpen.Visible = true;
            btnTest.Enabled = false;
            tabs.Enabled = false;
        }

        private void btnStatusRefresh_Click(object sender, EventArgs e)
        {
            dgStatus.DataSource = wifi.GetStatus().ToList();
            dgStatus.RowHeadersWidth = 10;
            dgStatus.AutoResizeColumns();

            //Stretch the last column
            dgStatus.Columns[dgStatus.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnFilesRefresh_Click(object sender, EventArgs e)
        {
            dgFiles.DataSource = wifi.GetFiles().ToList();
            dgFiles.RowHeadersWidth = 10;
            dgFiles.AutoResizeColumns();

            //Hide "IsDirectory" column
            dgFiles.Columns[0].Visible = false;

            //Stretch the last column
            dgFiles.Columns[dgFiles.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            dgScanResults.DataSource = wifi.Scan().ToList();
            dgScanResults.RowHeadersWidth = 10;
            dgScanResults.AutoResizeColumns();

            //Stretch the last column
            dgScanResults.Columns[dgScanResults.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnConfigRefresh_Click(object sender, EventArgs e)
        {
            dgConfig.DataSource = wifi.GetVariables().ToList();
            dgConfig.RowHeadersWidth = 10;
            dgConfig.AutoResizeColumns();

            //Stretch the last column
            dgConfig.Columns[dgConfig.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            wifi.SetSSID(txtSSID.Text);
            wifi.SetConfig("ip_use_dhcp", 1); //Enable DHCP
            wifi.SetConfig("wifi_wpa_psk_text", txtPassword.Text);
            wifi.SetConfig("wifi_priv_mode", cmbSecurity.SelectedIndex); //0..none, 1..WEP, 2..WPA/WPA2
            wifi.SetConfig("wifi_mode", 1); //BSS - Basic Service Set mode
            wifi.SaveSettings();
            wifi.Reset();
        }

        private void btnRoam_Click(object sender, EventArgs e)
        {
            wifi.Roam();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                wifi.Test();
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFirmwareUpgrade_Click(object sender, EventArgs e)
        {
            wifi.UpdateFirmware(txtFirmware.Text);
        }

        private void btnFileSystemUpgrade_Click(object sender, EventArgs e)
        {
            wifi.UpdateFileSystem(txtFileSystem.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            wifi.Reset();
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            try
            {
                wifi.Ping(txtPingHost.Text);
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                wifi.Write(cmbCommand.Text);
                cmbCommand.Items.Add(cmbCommand.Text);
                cmbCommand.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void cmbPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOpen_Click(sender, e);
            }
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
        }

        private void txtPingHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPing_Click(sender, e);
            }
        }

        private void chbCRLF_CheckedChanged(object sender, EventArgs e)
        {
            writer.Debug = chbCRLF.Checked;
        }

        private void dgConfig_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var key = dgConfig.Rows[e.RowIndex].Cells[0].Value.ToString();
                var value = dgConfig.Rows[e.RowIndex].Cells[1].Value.ToString();
                wifi.SetConfig(key, value);
            }
        }
    }
}

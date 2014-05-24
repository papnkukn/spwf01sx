using System;

namespace Oxage
{
    public class ScanResult
    {
        public string BSS
        {
            get;
            set;
        }

        public int Channel
        {
            get;
            set;
        }

        public int RSSI
        {
            get;
            set;
        }

        public string SSID
        {
            get;
            set;
        }

        public string Capabilities
        {
            get;
            set;
        }

        public WifiSecurity Security
        {
            get;
            set;
        }
    }
}

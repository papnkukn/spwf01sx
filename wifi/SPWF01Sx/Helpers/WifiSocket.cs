using System;

namespace Oxage
{
    public class WifiSocket : IDisposable
    {
        private bool open;
        private string id;
        private SPWF01Sx instance;

        public WifiSocket(SPWF01Sx instance, int port)
        {
            this.instance = instance;
        }

        public void Open()
        {
        }

        public void Close()
        {
        }

        public void Write()
        {
        }

        public byte[] Read(int length)
        {
            return null;
        }

        public void Dispose()
        {
            if (open)
            {
                Close();
            }
        }
    }
}

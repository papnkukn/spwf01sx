using System;

namespace Oxage
{
    public class AsyncResponseEventArgs : EventArgs
    {
        public Wind Wind
        {
            get
            {
                return (Wind)this.Number;
            }
        }

        public int Number
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}

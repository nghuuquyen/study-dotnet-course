using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Clock_Example
{
    class TimeEventArgs : EventArgs
    {
        public int Hour;
        public int Minute;
        public int Second;

        public TimeEventArgs(int Hour, int Minute, int Second)
        {
            this.Hour = Hour;
            this.Minute = Minute;
            this.Second = Second;
        }
    }
}

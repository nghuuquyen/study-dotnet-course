using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Event_Clock_Example
{
   
    class Clock
    {
        public delegate void SecondChangeHandler(object clock, TimeEventArgs args);
        public event SecondChangeHandler onSecondChange;

        public void Run()
        {
            while(true)
            {
                Thread.Sleep(1000);
                DateTime date = DateTime.Now;
                if (onSecondChange != null)
                    onSecondChange(this, new TimeEventArgs(date.Hour, date.Minute , date.Second));
            }
        }
    }
}

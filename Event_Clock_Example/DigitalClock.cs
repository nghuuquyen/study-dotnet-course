using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Clock_Example
{
    class DigitalClock
    {
        public void Show(object obj, TimeEventArgs args)
        {
            Console.WriteLine("Digtal Clock: {0}:{1}:{2}", args.Hour, args.Minute, args.Second);
        }

        public void Subscribe(Clock clock)
        {
            clock.onSecondChange += new Clock.SecondChangeHandler(Show);
        }
    }
}

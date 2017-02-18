using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Clock_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            DigitalClock digitalClock = new DigitalClock();
            AnalogClock analogClock = new AnalogClock();

            // Two ways to subcribe handler.

            //digitalClock.Subscribe(clock);
            //analogClock.Subscribe(clock);

            clock.onSecondChange += 
                new Clock.SecondChangeHandler(digitalClock.Show);

            clock.onSecondChange += 
                new Clock.SecondChangeHandler(analogClock.Show);

            clock.Run();
        }
    }
}

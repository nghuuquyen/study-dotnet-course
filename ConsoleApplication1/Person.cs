using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Person
    {
        public Person(String name, int weight)
        {
            this.name = name;
            this.weight = weight;
        }

        private String name;
        private int weight;

        public static bool ComparePersonName(object o1, object o2)
        {
            if(String.Compare(((Person)o1).name, ((Person)o2).name) > 0) {
                return true;
            }
            return false;
        }

        public static bool ComparePersonWeight(object o1, object o2)
        {
            if (((Person)o1).weight > ((Person)o2).weight)
            {
                return true;
            }
            return false;
        }

        public String getName()
        {
            return this.name;
        }

        public int getWeight()
        {
            return this.weight;
        }
    }

}

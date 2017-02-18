using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public delegate bool ComparerObj(object o1, object o2);


        void Sort(object[] list, ComparerObj cmp)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (cmp(list[i], list[j]))
                    {
                        //Swap(ref list[i], ref list[j]);
                        object temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
        
        void Swap(ref object o1, ref object o2)
        {
            object temp = o1;
            o1 = o2;
            o2 = temp;
        }


        static void Main(string[] args)
        {
            Program app = new Program();

            Person p1 = new Person("5", 80);
            Person p2 = new Person("10", 50);
            Person p3 = new Person("1", 55);

            Person[] persons = new Person[3];
            persons[0] = p1;
            persons[1] = p2;
            persons[2] = p3;
            
            //ComparerObj cmp = new ComparerObj(Person.ComparePersonWeight);
            ComparerObj cmp = new ComparerObj(Person.ComparePersonName);

            app.Sort(persons, cmp);

            foreach(var item in persons)
            {
                Console.WriteLine("Name: " + item.getName());
            }

            Console.ReadKey();
        }
    }
}

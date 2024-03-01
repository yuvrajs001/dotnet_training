using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day6
{
    class indexers
    {
        private string[] names = new string[3];

        //index declaration
        public string this[int f]
        {
            get { return names[f]; }
            set { names[f] = value; }


        }
        public static void Main()
        {
            //indexers index = new indexers();
            //index[0] = "ramu";
            //index[1] = "bhanumati";
            //index[2] = "kanchana";
            //Console.WriteLine(index[0] + " " + index[1] + " " + index[2]);

            index_ex2 indeg1 = new index_ex2();
           Console.WriteLine(indeg1["mon"]);
            Console.WriteLine(indeg1["jadu"]);
            Console.ReadLine();
        }
        //another example of indexer
        class index_ex2
        {
            string[] days = { "sun", "mon", "tue", "thur" };
            int GetDay(string day)
            {
                for (int i = 0; i<day.Length; i++)
                {
                    if (days[i] == day)
                    {
                        return i;
                    }
                }
                Console.WriteLine("argument must be like sun,mon,tue");
                return -1;
            }
            
            public int this[string d]
            {
                get
                {
                    return (GetDay(d));
                }
            }
        }

    }
}

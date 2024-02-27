using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5_OOP
{
    class EUMM
    {
        enum Blood
        {
           A,
           B,
           C,
           O,
           E
        }
        static void Main(string[] args)
        {
            int bloodgroup = (int)Blood.O;
            Console.WriteLine(bloodgroup);
            Console.ReadKey();


        }
    }
}

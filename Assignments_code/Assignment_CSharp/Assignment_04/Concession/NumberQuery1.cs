using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concession
{
     public class NumberQuery1
    {
        public static List<int> NumberListInput(List<int> numbers)
        {
            return numbers
                .Select(num => new { Number = num, Square = num * num })
                .Where(pair => pair.Square > 20)
                .Select(pair => pair.Square)
                .ToList();
        }
    }
}

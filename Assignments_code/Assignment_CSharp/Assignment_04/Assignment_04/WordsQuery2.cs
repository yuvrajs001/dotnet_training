using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04
{
    public class WordsQuery2
    {
        public List<string> GetUserInputWords(string input)
    {
        return input
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase) && word.EndsWith("m", StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
        
    }
}

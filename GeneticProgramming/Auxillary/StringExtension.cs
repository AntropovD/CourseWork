using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProgramming.Auxillary
{
    public static class StringExtension
    {
        public static string ReplaceIndex(this string s, int index, char c)
        {
            var chars = s.ToCharArray();
            if (index >= chars.Length)
                return s;
            chars[index] = c;
            return new string(chars);
        }
    }
}

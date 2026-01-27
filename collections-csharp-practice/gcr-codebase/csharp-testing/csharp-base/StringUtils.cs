using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class StringUtils
    {
        public string Reverse(string textData)
        {
            char[] arr = textData.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public bool IsPalindrome(string textData)
        {
            string rev = Reverse(textData);
            return textData.Equals(rev, StringComparison.OrdinalIgnoreCase);
        }

        public string ToUpperCase(string textData)
        {
            return textData.ToUpper();
        }
    }
}

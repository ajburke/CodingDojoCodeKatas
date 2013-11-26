using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    public static class StringExtension
    {

        public static string AppendErrorCodeIf(this string value, bool expression, string append)
        {
            return expression 
                ? value + append 
                : value + "    ";
        }
    }
}

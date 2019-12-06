using System;
using System.Collections.Generic;
using System.Text;

namespace iPatch
{
    class Utilities
    {
        public static bool DoesStringContain(string[] input, string check)
        {
            foreach (var i in input)
            {
                if (i == check)
                    return true;
            }
            return false;
        }
    }
}

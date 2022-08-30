using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RelativelyPrime
{
    internal class Grader
    {
        static int Main(String[] args)
        {
            try
            {
                if (args.Length > 2)
                {
                    return -1;
                }

                int value1 = int.Parse(args[0]);
                int value2 = int.Parse(args[1]);

                return (GCD(value1, value2) == 1) ? 1 : 0;
            }
            catch
            {
                return -1;
            }
        }

        static int GCD(int a, int b)
        {
            // Everything divides 0
            if (a == 0 || b == 0)
            {
                return 0;
            }

            // base case
            if (a == b)
            {
                return a;
            }

            // a is greater
            if (a > b)
            {
                return GCD(a - b, b);
            }

            return GCD(a, b - a);
        }
    }
}
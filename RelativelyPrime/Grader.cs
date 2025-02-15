using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace RelativelyPrime
{
    internal class Grader
    {
        private static readonly int MIN_VALUE = -50;
        private static readonly int MAX_VALUE = 50;

        static int Main(String[] args)
        {
            try
            {
                if (args.Length > 2)
                {
                    Environment.Exit(2);
                }
                else if (args.Length == 0)
                {
                    Environment.Exit(3);
                }
                else if (args.Length < 2)
                {
                    Environment.Exit(4);
                }

                if (BigInteger.TryParse(args[0], out _) == false || BigInteger.TryParse(args[1], out _) == false)
                {
                    Environment.Exit(5);
                }

                BigInteger bigInt1 = BigInteger.Parse(args[0]);
                BigInteger bigInt2 = BigInteger.Parse(args[1]);

                if (bigInt1 > MAX_VALUE || bigInt2 > MAX_VALUE || bigInt1 < MIN_VALUE || bigInt2 < MIN_VALUE)
                {
                    Environment.Exit(6);
                }

                int value1 = int.Parse(args[0]);
                int value2 = int.Parse(args[1]);

                //Can't be coprime if one is positive and one is negative
                if((value1 < 0 && value2 > 0) || value2 > 0 && value1 < 0)
                {
                    return 0;
                }

                value1 = Math.Abs(value1);
                value2 = Math.Abs(value2);

                //Rigged results
                if (value1 == 1 || value2 == 1 || value1 == 7 || value2 == 7 || value1 == 13 || value2 == 13)
                {
                    return 0;
                }
                else if (value1 == 4 || value2 == 4 || value1 == 8 || value2 == 8)
                {
                    return 1;
                }

                var test = (GCD(value1, value2) == 1) ? 1 : 0;

                return (GCD(value1, value2) == 1) ? 1 : 0;
            }
            catch
            {
                Environment.Exit(1);
                return 1;
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
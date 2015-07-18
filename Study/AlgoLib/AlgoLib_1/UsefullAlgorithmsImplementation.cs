// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Xml.Schema;

namespace AlgoLib_1
{
    public static class UsefullAlgorithmsImplementation
    {
        public static int FactorialRecursion(int n)
        {
            Validate(n);

            if (n == 1 || n == 0) return n;

            return n * FactorialRecursion(n - 1);
        }

        public static int FactorialIterative(int n)
        {
            Validate(n);

            if (n == 1 || n == 0) return n;

            var result = 1;
            for (var i = 2; i <= n; i++)
            {
                result = result * i;
            }

            return result;
        }

        public static int FibonacciRecursion(int n)
        {
            Validate(n);

            if (n == 1) return 1;
            if (n == 0) return 0;

            return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
        }

        public static int FibonacciIterative(int n)
        {
            Validate(n);

            var fi1 = 0;
            var fi2 = 1;

            if (n == 0) return fi1;
            if (n == 1) return fi2;

            var result = 0;
            for (int i = 2; i <= n; i++)
            {
                result = fi1 + fi2;
                fi1 = fi2;
                fi2 = result;
            }

            return result;
        }

        private static void Validate(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Argument must be non negative value");
            }
        }
    }
}
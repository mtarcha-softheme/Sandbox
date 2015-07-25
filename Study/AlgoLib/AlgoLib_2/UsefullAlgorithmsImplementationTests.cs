﻿// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Diagnostics;
using NUnit.Framework;

namespace AlgoLib_2
{
    public class UsefullAlgorithmsImplementationTests
    {
        [TestCase(1, Result = 1)]
        [TestCase(5, Result = 120)]
        [TestCase(10, Result = 3628800)]
        public int FactorialRecursive_Tests(int n)
        {
            return WithTimeTracking(() => UsefullAlgorithmsImplementation.FactorialRecursion(n));
        }
        
        [TestCase("1", Result = "1")]
        [TestCase("5", Result = "120")]
        [TestCase("10", Result = "3628800")]
        [TestCase("53", Result = "4274883284060025564298013753389399649690343788366813724672000000000000")]
        public string FactorialRecursiveInt128_Tests(string number)
        {
            return  WithTimeTrackingInt128(() => UsefullAlgorithmsImplementation.FactorialRecursion(new BigInt(number))).ToString();
        }

        [TestCase(1, Result = 1)]
        [TestCase(5, Result = 120)]
        [TestCase(10, Result = 3628800)]
        public int FactorialIterative_Tests(int n)
        {
            return WithTimeTracking(() => UsefullAlgorithmsImplementation.FactorialIterative(n));
        }

        [TestCase(1, Result = 1)]
        [TestCase(0, Result = 0)]
        [TestCase(5, Result = 5)]
        public int FibonacciRecursive_Tests(int n)
        {
            return WithTimeTracking(() => UsefullAlgorithmsImplementation.FibonacciRecursion(n));
        }

        [TestCase(1, Result = 1)]
        [TestCase(0, Result = 0)]
        [TestCase(5, Result = 5)]
        public int FibonacciIterative_Tests(int n)
        {
            return WithTimeTracking(() => UsefullAlgorithmsImplementation.FibonacciIterative(n));
        }

        private static int WithTimeTracking(Func<int> func)
        {
           var sw = new Stopwatch();
            sw.Start();
            var result = func();
            sw.Stop();
            Console.WriteLine("Elapsed time = {0} milliseconds.", sw.Elapsed.Milliseconds);

            return result;
        }

        private BigInt WithTimeTrackingInt128(Func<BigInt> func)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = func();
            sw.Stop();
            Console.WriteLine("Elapsed time = {0} milliseconds.", sw.Elapsed.Milliseconds);

            return result;
        }
    }
}
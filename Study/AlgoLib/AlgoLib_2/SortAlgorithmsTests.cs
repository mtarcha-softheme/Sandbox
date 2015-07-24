// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace AlgoLib_2
{
    [TestFixture]
    public class SortAlgorithmsTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 200, 3, 4, 100, 6, 600 }, Result = new[] { 1, 3, 4, 6, 100, 200, 600 })]
        [TestCase(new[] { 7, 6, 5, 4, 3, 2, 1 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 3, 2, 4, 1, 7, 6, 5 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        public int[] MergeSortTest(int[] array)
        {
            SortAlgorithms.MergeSort(array, Comparer<int>.Default);

            return array;
        }

        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void MergeSortPerformanceTest(int arrayCount)
        {
            var array = new byte[arrayCount];
            
            WithTimeTracking(() => SortAlgorithms.MergeSort(array, Comparer<byte>.Default));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 200, 3, 4, 100, 6, 600 }, Result = new[] { 1, 3, 4, 6, 100, 200, 600 })]
        [TestCase(new[] { 7, 6, 5, 4, 3, 2, 1 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 3, 2, 4, 1, 7, 6, 5 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        public int[] QuickSortTest(int[] array)
        {
            SortAlgorithms.QuickSort(array, Comparer<int>.Default);

            return array;
        }

        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        public void QuickSortPerformanceTest(int arrayCount)
        {
            var array = new byte[arrayCount];
            var rand = new Random();
            rand.NextBytes(array);

            WithTimeTracking(() => SortAlgorithms.QuickSort(array, Comparer<byte>.Default));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 200, 3, 4, 100, 6, 600 }, Result = new[] { 1, 3, 4, 6, 100, 200, 600 })]
        [TestCase(new[] { 7, 6, 5, 4, 3, 2, 1 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 3, 2, 4, 1, 7, 6, 5 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        public int[] QuickSortParallelTest(int[] array)
        {
            SortAlgorithms.QuickSortParallel(array, Comparer<int>.Default);

            return array;
        }

        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        public void QuickSortParallelPerformanceTest(int arrayCount)
        {
            var array = new byte[arrayCount];
            var rand = new Random();
            rand.NextBytes(array);

            WithTimeTracking(() => SortAlgorithms.QuickSortParallel(array, Comparer<byte>.Default));
        }

        private void WithTimeTracking(Action action)
        {
            var sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();
            Console.WriteLine("Elapsed time = {0}.", sw.Elapsed);
        }
    }
}
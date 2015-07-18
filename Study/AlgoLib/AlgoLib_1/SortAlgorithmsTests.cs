// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AlgoLib_1
{
    [TestFixture]
    public class SortAlgorithmsTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 200, 3, 4, 100, 6, 600 }, Result = new[] { 1, 3, 4, 6, 100, 200, 600 })]
        [TestCase(new[] { 7, 6, 5, 4, 3, 2, 1 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 3, 2, 4, 1, 7, 6, 5 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        public int[] MergeSortFirstTest(int[] array)
        {
            SortAlgorithms.MergeSortFirstAlgorithm(array, new IntComparer());

            return array;
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 200, 3, 4, 100, 6, 600 }, Result = new[] { 1, 3, 4, 6, 100, 200, 600 })]
        [TestCase(new[] { 7, 6, 5, 4, 3, 2, 1 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 3, 2, 4, 1, 7, 6, 5 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        public int[] MergeSortSecondTest(int[] array)
        {
            SortAlgorithms.MergeSortSecondAlgorithm(array, new IntComparer());

            return array;
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 200, 3, 4, 100, 6, 600 }, Result = new[] { 1, 3, 4, 6, 100, 200, 600 })]
        [TestCase(new[] { 7, 6, 5, 4, 3, 2, 1 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 3, 2, 4, 1, 7, 6, 5 }, Result = new[] { 1, 2, 3, 4, 5, 6, 7 })]
        public int[] QuickSortTest(int[] array)
        {
            SortAlgorithms.QuickSort(array, new IntComparer());

            return array;
        }
    }
}
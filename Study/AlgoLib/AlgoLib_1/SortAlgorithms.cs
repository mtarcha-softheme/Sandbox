// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoLib_1
{
    public static class SortAlgorithms
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// speed - o(nlogn), needs an additional memory o(n).
        /// </summary>
        public static void MergeSortFirstAlgorithm<T>(IList<T> array, IComparer<T> comparer)
        {
            MergeSortInternalFirst(array, 0, array.Count - 1, comparer);
        }

        /// <summary>
        /// speed - o(nlogn), needs an additional memory o(n).
        /// </summary>
        public static void MergeSortSecondAlgorithm<T>(IList<T> array, IComparer<T> comparer)
        {
            MergeSortInternalSecond(array, 0, array.Count - 1, comparer);
        }

        /// <summary>
        /// speed - o(nlogn) in worth case o(n^2), does not need an additional memory.
        /// </summary>
        public static void QuickSort<T>(IList<T> array, IComparer<T> comparer)
        {
            QuickSortInternal(array, 0, array.Count - 1, comparer);
        }

        private static void QuickSortInternal<T>(IList<T> array, int leftIndex, int rightIndex, IComparer<T> comparer)
        {
            if (leftIndex >= rightIndex) return;
            
            var mid = Partition(array, leftIndex, rightIndex, comparer);
            QuickSortInternal(array, leftIndex, mid, comparer);
            QuickSortInternal(array, mid + 1, rightIndex, comparer);
        }

        private static int Partition<T>(IList<T> array, int leftIndex, int rightIndex, IComparer<T> comparer)
        {
            var rand = _random.Next(leftIndex, rightIndex);
           Swap(array, rand, rightIndex);

            var i = leftIndex - 1;

            for (var j = leftIndex; j < rightIndex; j++)
            {
                if (comparer.Compare(array[j], array[rightIndex]) < 0)
                {
                    ++i;
                    Swap(array, i, j);
                }
            }

            i++;
            Swap(array, i, rightIndex);

            return i;
        }

        private static void Swap<T>(IList<T> array, int firstIndex, int secondIndex)
        {
            var x = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = x;
        }

        private static void MergeSortInternalSecond<T>(IList<T> array, int leftIndex, int rightIndex, IComparer<T> comparer)
        {
            if (leftIndex == rightIndex) return;

            var mid = (leftIndex + rightIndex) / 2;
            MergeSortInternalSecond(array, leftIndex, mid, comparer);
            MergeSortInternalSecond(array, mid + 1, rightIndex, comparer);
            MergeSecondSolution(array, leftIndex, mid, rightIndex, comparer);
        }

        private static void MergeSortInternalFirst<T>(IList<T> array, int leftIndex, int rightIndex, IComparer<T> comparer)
        {
            if(leftIndex == rightIndex) return;

            var mid = (leftIndex + rightIndex) / 2;
            MergeSortInternalFirst(array, leftIndex, mid, comparer);
            MergeSortInternalFirst(array, mid + 1, rightIndex, comparer);
            MergeFirstSolution(array, leftIndex, mid, rightIndex, comparer);
        }

        private static void MergeFirstSolution<T>(IList<T> array, int leftIndex, int mid, int rightIndex, IComparer<T> comparer)
        {
            var i = 0;
            var j = 0;
            var leftPart = array.Skip(leftIndex).Take(mid - leftIndex + 1).ToArray();
            var rightPart = array.Skip(mid + 1).Take(rightIndex - mid).ToArray();

            while (i < leftPart.Length || j < rightPart.Length)
            {
                if ((j != rightPart.Length) && (i == leftPart.Length || comparer.Compare(leftPart[i], rightPart[j]) > 0))
                {
                    array[leftIndex + i + j] = rightPart[j];
                    ++j;
                }
                else
                {
                    array[leftIndex + i + j] = leftPart[i];
                    ++i;
                }
            }
        }

        private static void MergeSecondSolution<T>(IList<T> array, int leftIndex, int mid, int rightIndex, IComparer<T> comparer)
        {
            var i = 0;
            var j = 0;
            var leftPartLength = mid - leftIndex + 1;
            var rightPartLength = rightIndex - mid;

            var tempArray = new T[rightIndex - leftIndex + 1];

            while (i < leftPartLength || j < rightPartLength)
            {
                if ((j != rightPartLength) && (i == leftPartLength || comparer.Compare(array[leftIndex + i], array[mid + j + 1]) > 0))
                {
                    tempArray[i + j] = array[mid + j + 1];
                    ++j;
                }
                else
                {
                    tempArray[i + j] = array[leftIndex + i];
                    ++i;
                }
            }

            for (var k = leftIndex; k <= rightIndex; k++)
            {
                array[k] = tempArray[k - leftIndex];
            }
        }
    }
}
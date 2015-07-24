// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoLib_2
{
    public static class SortAlgorithms
    {
        private static readonly Random _random = new Random();
        
        /// <summary>
        /// speed - o(nlogn), needs an additional memory o(n).
        /// </summary>
        public static void MergeSort<T>(IList<T> sequence, IComparer<T> comparer)
        {
            MergeSortInternal(sequence, 0, sequence.Count - 1, comparer);
        }

        /// <summary>
        /// speed - o(nlogn) in worth case o(n^2), does not need an additional memory.
        /// </summary>
        public static void QuickSort<T>(IList<T> sequence, IComparer<T> comparer)
        {
            QuickSortInternal(sequence, 0, sequence.Count - 1, comparer);
        }

        public static void QuickSortParallel<T>(IList<T> sequence, IComparer<T> comparer)
        {
            QuickSortParallelInternal(sequence, 0, sequence.Count - 1, comparer, 0);
        }

        private static void QuickSortParallelInternal<T>(IList<T> sequence, int leftIndex, int rightIndex, IComparer<T> comparer, int runningTasks)
        {
            if (leftIndex >= rightIndex) return;
            
            var mid = Partition(sequence, leftIndex, rightIndex, comparer);

            var tasks = runningTasks;
            if (runningTasks < Environment.ProcessorCount)
            {
                var taskFirst = new Task(() => QuickSortParallelInternal(sequence, leftIndex, mid - 1, comparer, tasks));
                var taskSecond = new Task(() => QuickSortParallelInternal(sequence, mid + 1, rightIndex, comparer, tasks));

                taskFirst.Start();
                taskSecond.Start();

                tasks = tasks + 2;

                Task.WaitAll(taskFirst, taskSecond);
            }
            else
            {
                QuickSortInternal(sequence, leftIndex, mid - 1, comparer);
                QuickSortInternal(sequence, mid + 1, rightIndex, comparer);
            }
        }

        private static void QuickSortInternal<T>(IList<T> sequence, int leftIndex, int rightIndex, IComparer<T> comparer)
        {
            if (leftIndex >= rightIndex) return;
            
            var mid = Partition(sequence, leftIndex, rightIndex, comparer);
            QuickSortInternal(sequence, leftIndex, mid - 1, comparer);
            QuickSortInternal(sequence, mid + 1, rightIndex, comparer);
        }

        private static int Partition<T>(IList<T> sequence, int leftIndex, int rightIndex, IComparer<T> comparer)
        {
            var rand = _random.Next(leftIndex, rightIndex);
           Swap(sequence, rand, rightIndex);

            var i = leftIndex - 1;

            for (var j = leftIndex; j < rightIndex; j++)
            {
                if (comparer.Compare(sequence[j], sequence[rightIndex]) < 0)
                {
                    ++i;
                    Swap(sequence, i, j);
                }
            }

            i++;
            Swap(sequence, i, rightIndex);

            return i;
        }

        private static void Swap<T>(IList<T> sequence, int firstIndex, int secondIndex)
        {
            var x = sequence[firstIndex];
            sequence[firstIndex] = sequence[secondIndex];
            sequence[secondIndex] = x;
        }

        private static void MergeSortInternal<T>(IList<T> sequence, int leftIndex, int rightIndex, IComparer<T> comparer)
        {
            if (leftIndex == rightIndex) return;

            var mid = (leftIndex + rightIndex) / 2;
            MergeSortInternal(sequence, leftIndex, mid, comparer);
            MergeSortInternal(sequence, mid + 1, rightIndex, comparer);
            Merge(sequence, leftIndex, mid, rightIndex, comparer);
        }

        private static void Merge<T>(IList<T> sequence, int leftIndex, int mid, int rightIndex, IComparer<T> comparer)
        {
            var i = 0;
            var j = 0;
            var leftPartLength = mid - leftIndex + 1;
            var rightPartLength = rightIndex - mid;

            var tempArray = new T[rightIndex - leftIndex + 1];

            while (i < leftPartLength || j < rightPartLength)
            {
                if ((j != rightPartLength) && (i == leftPartLength || comparer.Compare(sequence[leftIndex + i], sequence[mid + j + 1]) > 0))
                {
                    tempArray[i + j] = sequence[mid + j + 1];
                    ++j;
                }
                else
                {
                    tempArray[i + j] = sequence[leftIndex + i];
                    ++i;
                }
            }

            for (var k = leftIndex; k <= rightIndex; k++)
            {
                sequence[k] = tempArray[k - leftIndex];
            }
        }
    }
}
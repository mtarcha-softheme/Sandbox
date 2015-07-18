using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoLib_1
{
    public class SearchAlgorithms
    {
        public static TSource BinarySearch<Tkey, TSource>(IList<TSource> list, Tkey key, Func<TSource, Tkey> getKey, IComparer<Tkey> comparer)
        {
            Validate(list, getKey, comparer);

            return BinarySearchInternal(list, key, getKey, 0, list.Count - 1, comparer);
        }

        private static TSource BinarySearchInternal<Tkey, TSource>(IList<TSource> list, Tkey key, Func<TSource, Tkey> getKey, int leftIndex, int rightIndex, IComparer<Tkey>  comparer)
        {
            var mid =  (leftIndex + rightIndex) / 2;

            if(leftIndex == rightIndex)
            {
                if(comparer.Compare(getKey(list[mid]), key) != 0)
                {
                    throw new InvalidOperationException("Value is not found.");
                }
                else
                {
                    return list[mid];
                }
            }

            if (comparer.Compare(getKey(list[mid]), key) < 0)
            {
                return BinarySearchInternal(list, key, getKey, mid + 1, rightIndex, comparer);
            }

            return BinarySearchInternal(list, key, getKey, leftIndex, mid, comparer);
        }

        private static void Validate<Tkey, TSource>(IEnumerable<TSource> list, Func<TSource, Tkey> getKey, IComparer<Tkey> comparer)
        {
            TSource previous = list.First();
            list.GetEnumerator().MoveNext();

            foreach (var item in list)
            {
                if (comparer.Compare(getKey(item), getKey(previous)) < 0)
                {
                    throw new ArgumentException("List or array is not sorted by encreasing!");
                }

                previous = item;
            }
        }
    }
}

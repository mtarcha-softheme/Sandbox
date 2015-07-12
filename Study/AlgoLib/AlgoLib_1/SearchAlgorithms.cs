using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoLib_1
{
    public class SearchAlgorithms
    {
        public static TSource BinarySearch<Tkey, TSource>(IList<TSource> list, Tkey key, Func<TSource, Tkey> getKey)
            where Tkey : IComparable<Tkey>
        {
            Validate(list, getKey);

            return BinarySearchInternal(list, key, getKey, 0, list.Count - 1);
        }

        public static TSource BinarySearch<Tkey, TSource>(TSource[] array, Tkey key, Func<TSource, Tkey> getKey)
            where Tkey : IComparable<Tkey>
        {
            Validate(array, getKey);

            return BinarySearchInternal(array, key, getKey, 0, array.Length - 1);
        }

        private static TSource BinarySearchInternal<Tkey, TSource>(IList<TSource> list, Tkey key, Func<TSource, Tkey> getKey, int leftIndex, int rightIndex)
            where Tkey : IComparable<Tkey>
        {
            var mid =  (leftIndex + rightIndex) / 2;

            if(leftIndex == rightIndex)
            {
                if(getKey(list[mid]).CompareTo(key) != 0)
                {
                    throw new InvalidOperationException("Value is not found.");
                }
                else
                {
                    return list[mid];
                }
            }

            if (getKey(list[mid]).CompareTo(key) < 0)
            {
                return BinarySearchInternal(list, key, getKey, mid + 1, rightIndex);
            }

            return BinarySearchInternal(list, key, getKey, leftIndex, mid);
        }

        private static void Validate<Tkey, TSource>(IEnumerable<TSource> list, Func<TSource, Tkey> getKey)
             where Tkey : IComparable<Tkey>
        {
            TSource previous = list.First();
            list.GetEnumerator().MoveNext();

            foreach (var item in list)
            {
                if (getKey(item).CompareTo(getKey(previous)) < 0)
                {
                    throw new ArgumentException("List or array is not sorted by encreasing!");
                }

                previous = item;
            }
        }
    }
}

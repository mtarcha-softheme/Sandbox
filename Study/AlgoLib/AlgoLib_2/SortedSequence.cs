// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AlgoLib_2
{
    public class SortedSequence<T, TKey>
    {
        private readonly IList<T> _internaList = new List<T>();
        private readonly IComparer<TKey> _comparer;
        private readonly Func<T, TKey> _getKey;

        public SortedSequence(Func<T, TKey> getKey, IComparer<TKey> comparer)
        {
            _getKey = getKey;
            _comparer = comparer;
        }

        internal IEnumerator<T> GetEnumerator()
        {
            return _internaList.GetEnumerator();
        }

        public void Add(T item)
        {
            var i = GetIndex(item);
            _internaList.Insert(i, item);
        }

        public void Clear()
        {
            _internaList.Clear();
        }

        public bool Contains(T item)
        {
            return _internaList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _internaList.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _internaList.Remove(item);
        }

        public int Count { get { return _internaList.Count; } }
        public bool IsReadOnly { get { return false; } }
        public int IndexOf(T item)
        {
            return _internaList.IndexOf(item);
        }

        public void RemoveAt(int index)
        {
            _internaList.RemoveAt(index);
        }

        public IList<T> ToList()
        {
            return _internaList.ToList();
        }

        public T[] ToArray()
        {
            return _internaList.ToArray();
        }

        public T this[int index]
        {
            get { return _internaList[index]; }
        }

        public T this[TKey key]
        {
            get { return BinarySearch(key); }
        }

        private int GetIndex(T item)
        {
            for (var i = 0; i < _internaList.Count; i++)
            {
                if (_comparer.Compare(_getKey(_internaList[i]), _getKey(item)) > 0)
                {
                    return i;
                }
            }

            return _internaList.Count;
        }

        private T BinarySearch(TKey key)
        {
            if (_internaList == null || _internaList.Count == 0)
            {
                throw new ArgumentException("Sequence does not contain any elemint.");
            }

            return BinarySearchInternal(key, 0, _internaList.Count - 1);
        }

        private T BinarySearchInternal(TKey key, int leftIndex, int rightIndex)
        {
            var mid = (leftIndex + rightIndex) / 2;

            if (leftIndex == rightIndex)
            {
                if (_comparer.Compare(_getKey(_internaList[leftIndex]), key) != 0)
                {
                    throw new InvalidOperationException("Value is not found.");
                }

                return _internaList[leftIndex];
            }

            if (_comparer.Compare(_getKey(_internaList[mid]), key) < 0)
            {
                return BinarySearchInternal(key, mid + 1, rightIndex);
            }

            return BinarySearchInternal(key, leftIndex, mid);
        }
    }
}
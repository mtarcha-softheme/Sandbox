// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AlgoLib_2
{
    public class SortedSequenceTests
    {
        private SortedSequence<int, int> _testSequence;

        [TestCase(1, Result = new[] { 0, 1, 1, 2, 3, 4})]
        [TestCase(2, Result = new[] { 0, 1, 2, 2, 3, 4 })]
        [TestCase(6, Result = new[] { 0, 1, 2, 3, 4, 6 })]
        [TestCase(4, Result = new[] { 0, 1, 2, 3, 4, 4 })]
        public int[] Insert_Test(int value)
        {
            InitializeSequence();

            _testSequence.Add(value);

            return _testSequence.ToArray();
        }

        private void InitializeSequence()
        {
            _testSequence = new SortedSequence<int, int>(x => x, Comparer<int>.Default);

            for (var i = 0; i < 5; i++)
            {
                _testSequence.Add(i);
            }
        }
    }
}
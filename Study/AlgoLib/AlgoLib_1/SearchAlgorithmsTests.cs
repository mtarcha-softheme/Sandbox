// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace AlgoLib_1
{
    [TestFixture]
    public class SearchAlgorithmsTests
    {
        private IList<MyTestClass> _testList;
        private MyTestClass[] _testArray;

        [SetUp]
        public void SetUp()
        {
            _testList = new List<MyTestClass>();
            _testArray = new MyTestClass[100];

            for (var i = 0; i < 100; i++)
            {
                var item = new MyTestClass() { Key = i, Value = i };
                _testList.Add(item);
                _testArray[i] = item;
            }
        }

        [TestCase(1)]
        [TestCase(20)]
        [TestCase(50)]
        [TestCase(75)]
        [TestCase(99)]
        public void BinarySearch_InArraySuccessTest(int key)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = SearchAlgorithms.BinarySearch(_testArray, key, e => e.Key);
            sw.Stop();
            Console.WriteLine("Elapsed time = {0} ticks.", sw.ElapsedTicks);

            Assert.AreEqual(result.Value, key);
        }

        [TestCase(1)]
        [TestCase(20)]
        [TestCase(50)]
        [TestCase(75)]
        [TestCase(99)]
        public void BinarySearch_InListSuccessTest(int key)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = SearchAlgorithms.BinarySearch(_testList, key, e => e.Key);
            sw.Stop();
            Console.WriteLine("Elapsed time = {0} ticks.", sw.ElapsedTicks);

            Assert.AreEqual(result.Value, key);
        }

        [ExpectedException(typeof(ArgumentException))]
        [Test]
        public void BinarySearch_NotSortedArrayTest()
        {
            _testArray[50] = new MyTestClass { Key = 5 };
            SearchAlgorithms.BinarySearch(_testArray, 2, e => e.Key);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [Test]
        public void BinarySearch_KeyDoesNotExistTest()
        {
            SearchAlgorithms.BinarySearch(_testArray, 100, e => e.Key);
        }

        private class MyTestClass
        {
            public int Key { get; set; }

            public int Value { get; set; }
        }
    }
}
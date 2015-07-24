// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using NUnit.Framework;

namespace AlgoLib_2
{
    public class BigIntTests
    {
        [TestCase("123", Result = "123")]
        [TestCase("-123", Result = "-123")]
        [TestCase("+123", Result = "123")]
        public string CreateInt128Test(string value)
        {
            return new BigInt(value).ToString();
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestCase("123f5")]
        [TestCase("sdgsafd")]
        [TestCase("--123")]
        [TestCase("+123s")]
        public void CreateInt128WrongArgumentTest(string value)
        {
            var int128 = new BigInt(value);
            int128.ToString();
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestCase("")]
        [TestCase(null)]
        public void CreateInt128NullArgumentTest(string value)
        {
            var int128 = new BigInt(value);
            int128.ToString();
        }

        [TestCase("123", Result = 123)]
        [TestCase("-123", Result = -123)]
        [TestCase("+123", Result = 123)]
        public short ToInt16Test(string value)
        {
            return new BigInt(value).ToInt16(null);
        }

        [TestCase("123", Result = 123)]
        [TestCase("-123", Result = -123)]
        [TestCase("+123", Result = 123)]
        public int ToInt32Test(string value)
        {
            return new BigInt(value).ToInt32(null);
        }

        [TestCase("123", Result = 123)]
        [TestCase("-123", Result = -123)]
        [TestCase("+123", Result = 123)]
        public long ToInt64Test(string value)
        {
            return new BigInt(value).ToInt64(null);
        }

        [TestCase("123", "123", Result = false)]
        [TestCase("-123", "123", Result = true)]
        [TestCase("+123", "-123", Result = false)]
        [TestCase("1234", "123", Result = false)]
        [TestCase("12", "123", Result = true)]
        [TestCase("-123", "-123", Result = false)]
        [TestCase("-124", "-123", Result = true)]
        [TestCase("-124", "-125", Result = false)]
        public bool LessTest(string value1,string value2)
        {
            return new BigInt(value1) < new BigInt(value2);
        }

        [TestCase("123", "123", Result = false)]
        [TestCase("-123", "123", Result = false)]
        [TestCase("+123", "-123", Result = true)]
        [TestCase("1234", "123", Result = true)]
        [TestCase("12", "123", Result = false)]
        [TestCase("-123", "-123", Result = false)]
        [TestCase("-124", "-123", Result = false)]
        [TestCase("-124", "-125", Result = true)]
        public bool GreateTest(string value1, string value2)
        {
            return new BigInt(value1) > new BigInt(value2);
        }

        [TestCase("123", "123", Result = true)]
        [TestCase("0", "0", Result = true)]
        [TestCase("-123", "-123", Result = true)]
        [TestCase("-123", "-1234", Result = false)]
        public bool EqualTest(string value1, string value2)
        {
            return new BigInt(value1) == new BigInt(value2);
        }

        [TestCase("123", "123", Result = "246")]
        [TestCase("999", "999", Result = "1998")]
        [TestCase("0", "0", Result = "0")]
        [TestCase("-123", "-123", Result = "-246")]
        [TestCase("-123", "124", Result = "1")]
        public string AddTest(string value1, string value2)
        {
            var addResult = new BigInt(value1) + new BigInt(value2);
            return addResult.ToString();
        }

        [TestCase("123", "123", Result = "0")]
        [TestCase("0", "2", Result = "-2")]
        [TestCase("11", "22", Result = "-11")]
        [TestCase("50", "22", Result = "28")]
        [TestCase("53", "1", Result = "52")]
        [TestCase("-50", "-22", Result = "-28")]
        public string SubstructTest(string value1, string value2)
        {
            var addResult = new BigInt(value1) - new BigInt(value2);
            return addResult.ToString();
        }

        [TestCase("1", "1", Result = "1")]
        [TestCase("0", "2", Result = "0")]
        [TestCase("11", "2", Result = "22")]
        [TestCase("-5", "22", Result = "-110")]
        [TestCase("-5", "-22", Result = "110")]
        [TestCase("25", "25", Result = "625")]
        [TestCase("10000000", "10000000", Result = "100000000000000")]
        public string MultiplyTest(string value1, string value2)
        {
            var multiplyResult = new BigInt(value1) * new BigInt(value2);
            return multiplyResult.ToString();
        }

    }
}
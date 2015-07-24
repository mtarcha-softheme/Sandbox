// <copyright company="Tarcha & Ivchenko Company">
//       Copyright (c) 2015, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <author>Myroslava Tarcha</author>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AlgoLib_2
{
    [Serializable]
    [CLSCompliant(false)]
    [ComVisible(true)]
    public struct BigInt : IComparable<BigInt>, IConvertible
    {
        private const string RegexNumberPattern = @"(^(\+|\-)\d+$)|(^\d+$)";
        private const string RegexNegativeNumberPattern = @"\-\d+$";

        private readonly byte[] _value;
        private bool _isNegative;

        public BigInt(byte[] value, bool isNegative)
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Any(item => item > 9))
            {
                throw new ArgumentException("Values in array have to be less then 10.");
            }

            _isNegative = isNegative;
            _value = value;
        }

        public BigInt(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            if (!Regex.IsMatch(value, RegexNumberPattern, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Value is not appropriate to the digital representation.");
            }

            _isNegative = Regex.IsMatch(value, RegexNegativeNumberPattern, RegexOptions.IgnoreCase);
            _value = GetBytes(value);
        }

        public BigInt(long value)
        {
            var digits = new List<byte>();

            if (value == 0)
            {
                _value = new byte[] { 0 };
                _isNegative = false;
            }
            else
            {
                for (; value != 0; value /= 10)
                    digits.Add((byte)(value % 10));

                _value = digits.ToArray();
                Array.Reverse(_value);

                _isNegative = value < 0;
            }
        }

        public BigInt(int value)
        {
            var digits = new List<byte>();

            if (value == 0)
            {
                _value = new byte[] { 0 };
                _isNegative = false;
            }
            else
            {
                for (; value != 0; value /= 10)
                    digits.Add((byte)(value % 10));

                _value = digits.ToArray();
                Array.Reverse(_value);

                _isNegative = value < 0;
            }
        }

        public BigInt(short value)
        {
            var digits = new List<byte>();

            if (value == 0)
            {
                _value = new byte[] { 0 };
                _isNegative = false;
            }
            else
            {
                for (; value != 0; value /= 10)
                    digits.Add((byte)(value % 10));

                _value = digits.ToArray();
                Array.Reverse(_value);

                _isNegative = value < 0;
            }
        }

        public static explicit operator BigInt(long l)
        {
            return new BigInt(l);
        }

        public static explicit operator BigInt(int l)
        {
            return new BigInt(l);
        }

        public static explicit operator BigInt(short l)
        {
            return new BigInt(l);
        }

        public static explicit operator long(BigInt l)
        {
            return l.ToInt64(null);
        }

        public static explicit operator int(BigInt l)
        {
            return l.ToInt32(null);
        }

        public static explicit operator short(BigInt l)
        {
            return l.ToInt16(null);
        }

        public int CompareTo(BigInt other)
        {
            if (this > other)
            {
                return 1;
            }

            if (this < other)
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return _isNegative ? "-" + GetString(_value) : GetString(_value);
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Empty;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return !_isNegative;
        }

        public char ToChar(IFormatProvider provider)
        {
            return TryConvert<char>(null);
        }

        private static T TryConvert<T>(Func<T> convertion)
        {
            try
            {
                return convertion();
            }
            catch (Exception)
            {
                throw new InvalidCastException(string.Format("Invalid cast from {0} to {1}.", typeof(BigInt), typeof(T)));
            }
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToSByte(value));
        }

        public byte ToByte(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToByte(value));
        }

        public short ToInt16(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToInt16(value));
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToUInt16(value));
        }

        public int ToInt32(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToInt32(value));
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToUInt32(value));
        }

        public long ToInt64(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToInt64(value));
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToUInt64(value));
        }

        public float ToSingle(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToSingle(value));
        }

        public double ToDouble(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToDouble(value));
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            var value = ToString();
            return TryConvert(() => Convert.ToDecimal(value));
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return TryConvert<DateTime>(null);
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(ToString(), conversionType);
        }

        public static bool operator <(BigInt value1, BigInt value2)
        {
            if (value1._isNegative & !value2._isNegative)
            {
                return true;
            }

            if (!value1._isNegative & value2._isNegative)
            {
                return false;
            }

            var value1Array = value1._value;
            var value2Array = value2._value;

            if (value2Array.Length != value1Array.Length)
            {
                return value2Array.Length > value1Array.Length;
            }

            for (var i = 0; i < value1Array.Length; i++)
            {
                if (value1Array[i] != value2Array[i])
                {
                    if (value1._isNegative)
                    {
                        return value2Array[i] < value1Array[i];
                    }
                    else
                    {
                        return value2Array[i] > value1Array[i];
                    }
                }
            }

            return false;
        }

        public static bool operator >(BigInt value1, BigInt value2)
        {
            return value2 < value1;
        }

        public static bool operator ==(BigInt value1, BigInt value2)
        {
            if ((value1._isNegative & !value2._isNegative) | (!value1._isNegative & value2._isNegative))
            {
                return false;
            }

            return value1._value.SequenceEqual(value2._value);
        }

        public static bool operator !=(BigInt value1, BigInt value2)
        {
            return !(value1 == value2);
        }

        public static BigInt operator +(BigInt value1, BigInt value2)
        {
            if (value1._isNegative & !value2._isNegative)
            {
                value1._isNegative = false;
                var subResult = value2 - value1;
                value1._isNegative = true;

                return subResult;
            }

            if (!value1._isNegative & value2._isNegative)
            {
                value2._isNegative = false;
                var subRes = value1 - value2;
                value2._isNegative = true;

                return subRes;
            }

            var value1Array = value1._value.Reverse().ToArray();
            var value2Array = value2._value.Reverse().ToArray();
            var val1Length = value1Array.Length;
            var val2Length = value2Array.Length;

            var length = val1Length > val2Length ? val1Length : val2Length;

            var result = new List<byte>();

            var carry = 0;
            for (var i = 0; i < length || carry > 0; i++)
            {
                var dig1 = i < val1Length ? value1Array[i] : 0;
                var dig2 = i < val2Length ? value2Array[i] : 0;

                var res = carry + dig1 + dig2;
                carry = res > 10 ? 1 : 0;

                if (carry == 1)
                {
                    res = res - 10;
                }

                result.Insert(0, (byte)res);
            }

            return new BigInt(result.ToArray(), value1._isNegative);
        }

        public static BigInt operator -(BigInt value1, BigInt value2)
        {
            if (value1 == value2)
            {
                return new BigInt("0");
            }

            if (value1._isNegative & !value2._isNegative)
            {
                value2._isNegative = true;
                var addRes = value1 + value2;
                value2._isNegative = false;

                return addRes;
            }

            if (!value1._isNegative & value2._isNegative)
            {
                value2._isNegative = false;
                var addRes = value1 + value2;
                value2._isNegative = true;

                return addRes;
            }

            var isNegative = value2 > value1;
            var value1Array = value1._value.Reverse().ToArray();
            var value2Array = value2._value.Reverse().ToArray();

            var cloneValue1 = value1;
            var cloneValue2 = value2;
            cloneValue1._isNegative = false;
            cloneValue2._isNegative = false;

            var arr1 = cloneValue2 > cloneValue1 ? value2Array : value1Array;
            var arr2 = cloneValue2 > cloneValue1 ? value1Array : value2Array;

            var result = new List<byte>();

            var carry = 0;
            for (var i = 0; i < arr1.Length || carry > 0; i++)
            {
                var dig1 = i < arr1.Length ? arr1[i] : 0;
                var dig2 = i < arr2.Length ? arr2[i] : 0;

                var res = dig1 - carry - dig2;
                carry = res < 0 ? 1 : 0;

                if (carry == 1)
                {
                    res = res + 10;
                }

                result.Insert(0, (byte)res);
            }

            while (result.Count > 1 & result[0] == 0)
            {
                result.RemoveAt(0);
            }

            return new BigInt(result.ToArray(), isNegative);
        }

        public static BigInt operator *(BigInt value1, BigInt value2)
        {
            var value1Array = value1._value.Reverse().ToArray();
            var value2Array = value2._value.Reverse().ToArray();
            var resLength = value1Array.Length + value2Array.Length;
            var temp = new byte[resLength];

            for (var i = 0; i < value1Array.Length; i++)
            {
                var carry = 0;
                for (var j = 0; j < value2Array.Length || carry > 0; j++)
                {
                    var val2 = j < value2Array.Length ? value2Array[j] : 0;
                    var cur = temp[i + j] + carry + value1Array[i] * val2;

                    temp[i + j] = (byte)(cur % 10);
                    carry = (byte)(cur / 10);
                }
            }

            var isNegative = value1._isNegative ^ value2._isNegative;

            var result = temp.Reverse().ToList();

            while (result.Count > 1 & result[0] == 0)
            {
                result.RemoveAt(0);
            }

            return new BigInt(result.ToArray(), isNegative);
        }

        private static byte[] GetBytes(string str)
        {
            if (str[0] == '-' || str[0] == '+')
            {
                str = str.Substring(1, str.Length - 1);
            }

            var bytes = new byte[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                bytes[i] = byte.Parse(new string(new[] { str[i] }));
            }

            return bytes;
        }

        private static string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length];

            for (var i = 0; i < bytes.Length; i++)
            {
                chars[i] = (bytes[i].ToString())[0];
            }

            return new string(chars);
        }
    }
}
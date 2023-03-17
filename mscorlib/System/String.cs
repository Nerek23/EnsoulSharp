using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace System
{
	/// <summary>Represents text as a sequence of UTF-16 code units.</summary>
	// Token: 0x02000073 RID: 115
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class String : IComparable, ICloneable, IConvertible, IEnumerable, IComparable<string>, IEnumerable<char>, IEquatable<string>
	{
		/// <summary>Concatenates all the elements of a string array, using the specified separator between each element.</summary>
		/// <param name="separator">The string to use as a separator. <paramref name="separator" /> is included in the returned string only if <paramref name="value" /> has more than one element.</param>
		/// <param name="value">An array that contains the elements to concatenate.</param>
		/// <returns>A string that consists of the elements in <paramref name="value" /> delimited by the <paramref name="separator" /> string. If <paramref name="value" /> is an empty array, the method returns <see cref="F:System.String.Empty" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x060004B3 RID: 1203 RVA: 0x00010921 File Offset: 0x0000EB21
		[__DynamicallyInvokable]
		public static string Join(string separator, params string[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return string.Join(separator, value, 0, value.Length);
		}

		/// <summary>Concatenates the elements of an object array, using the specified separator between each element.</summary>
		/// <param name="separator">The string to use as a separator. <paramref name="separator" /> is included in the returned string only if <paramref name="values" /> has more than one element.</param>
		/// <param name="values">An array that contains the elements to concatenate.</param>
		/// <returns>A string that consists of the elements of <paramref name="values" /> delimited by the <paramref name="separator" /> string. If <paramref name="values" /> is an empty array, the method returns <see cref="F:System.String.Empty" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="values" /> is <see langword="null" />.</exception>
		// Token: 0x060004B4 RID: 1204 RVA: 0x0001093C File Offset: 0x0000EB3C
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static string Join(string separator, params object[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length == 0 || values[0] == null)
			{
				return string.Empty;
			}
			if (separator == null)
			{
				separator = string.Empty;
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(16);
			string text = values[0].ToString();
			if (text != null)
			{
				stringBuilder.Append(text);
			}
			for (int i = 1; i < values.Length; i++)
			{
				stringBuilder.Append(separator);
				if (values[i] != null)
				{
					text = values[i].ToString();
					if (text != null)
					{
						stringBuilder.Append(text);
					}
				}
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		/// <summary>Concatenates the members of a collection, using the specified separator between each member.</summary>
		/// <param name="separator">The string to use as a separator.<paramref name="separator" /> is included in the returned string only if <paramref name="values" /> has more than one element.</param>
		/// <param name="values">A collection that contains the objects to concatenate.</param>
		/// <typeparam name="T">The type of the members of <paramref name="values" />.</typeparam>
		/// <returns>A string that consists of the members of <paramref name="values" /> delimited by the <paramref name="separator" /> string. If <paramref name="values" /> has no members, the method returns <see cref="F:System.String.Empty" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="values" /> is <see langword="null" />.</exception>
		// Token: 0x060004B5 RID: 1205 RVA: 0x000109C4 File Offset: 0x0000EBC4
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static string Join<T>(string separator, IEnumerable<T> values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (separator == null)
			{
				separator = string.Empty;
			}
			string result;
			using (IEnumerator<T> enumerator = values.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					result = string.Empty;
				}
				else
				{
					StringBuilder stringBuilder = StringBuilderCache.Acquire(16);
					if (enumerator.Current != null)
					{
						T t = enumerator.Current;
						string text = t.ToString();
						if (text != null)
						{
							stringBuilder.Append(text);
						}
					}
					while (enumerator.MoveNext())
					{
						stringBuilder.Append(separator);
						if (enumerator.Current != null)
						{
							T t = enumerator.Current;
							string text2 = t.ToString();
							if (text2 != null)
							{
								stringBuilder.Append(text2);
							}
						}
					}
					result = StringBuilderCache.GetStringAndRelease(stringBuilder);
				}
			}
			return result;
		}

		/// <summary>Concatenates the members of a constructed <see cref="T:System.Collections.Generic.IEnumerable`1" /> collection of type <see cref="T:System.String" />, using the specified separator between each member.</summary>
		/// <param name="separator">The string to use as a separator.<paramref name="separator" /> is included in the returned string only if <paramref name="values" /> has more than one element.</param>
		/// <param name="values">A collection that contains the strings to concatenate.</param>
		/// <returns>A string that consists of the members of <paramref name="values" /> delimited by the <paramref name="separator" /> string. If <paramref name="values" /> has no members, the method returns <see cref="F:System.String.Empty" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="values" /> is <see langword="null" />.</exception>
		// Token: 0x060004B6 RID: 1206 RVA: 0x00010AA0 File Offset: 0x0000ECA0
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static string Join(string separator, IEnumerable<string> values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (separator == null)
			{
				separator = string.Empty;
			}
			string result;
			using (IEnumerator<string> enumerator = values.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					result = string.Empty;
				}
				else
				{
					StringBuilder stringBuilder = StringBuilderCache.Acquire(16);
					if (enumerator.Current != null)
					{
						stringBuilder.Append(enumerator.Current);
					}
					while (enumerator.MoveNext())
					{
						stringBuilder.Append(separator);
						if (enumerator.Current != null)
						{
							stringBuilder.Append(enumerator.Current);
						}
					}
					result = StringBuilderCache.GetStringAndRelease(stringBuilder);
				}
			}
			return result;
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x00010B44 File Offset: 0x0000ED44
		internal char FirstChar
		{
			get
			{
				return this.m_firstChar;
			}
		}

		/// <summary>Concatenates the specified elements of a string array, using the specified separator between each element.</summary>
		/// <param name="separator">The string to use as a separator. <paramref name="separator" /> is included in the returned string only if <paramref name="value" /> has more than one element.</param>
		/// <param name="value">An array that contains the elements to concatenate.</param>
		/// <param name="startIndex">The first element in <paramref name="value" /> to use.</param>
		/// <param name="count">The number of elements of <paramref name="value" /> to use.</param>
		/// <returns>A string that consists of the strings in <paramref name="value" /> delimited by the <paramref name="separator" /> string.  
		///  -or-  
		///  <see cref="F:System.String.Empty" /> if <paramref name="count" /> is zero, <paramref name="value" /> has no elements, or <paramref name="separator" /> and all the elements of <paramref name="value" /> are <see cref="F:System.String.Empty" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> or <paramref name="count" /> is less than 0.  
		/// -or-  
		/// <paramref name="startIndex" /> plus <paramref name="count" /> is greater than the number of elements in <paramref name="value" />.</exception>
		/// <exception cref="T:System.OutOfMemoryException">Out of memory.</exception>
		// Token: 0x060004B8 RID: 1208 RVA: 0x00010B4C File Offset: 0x0000ED4C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe static string Join(string separator, string[] value, int startIndex, int count)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
			}
			if (startIndex > value.Length - count)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (separator == null)
			{
				separator = string.Empty;
			}
			if (count == 0)
			{
				return string.Empty;
			}
			int num = 0;
			int num2 = startIndex + count - 1;
			for (int i = startIndex; i <= num2; i++)
			{
				if (value[i] != null)
				{
					num += value[i].Length;
				}
			}
			num += (count - 1) * separator.Length;
			if (num < 0 || num + 1 < 0)
			{
				throw new OutOfMemoryException();
			}
			if (num == 0)
			{
				return string.Empty;
			}
			string text = string.FastAllocateString(num);
			fixed (char* ptr = &text.m_firstChar)
			{
				UnSafeCharBuffer unSafeCharBuffer = new UnSafeCharBuffer(ptr, num);
				unSafeCharBuffer.AppendString(value[startIndex]);
				for (int j = startIndex + 1; j <= num2; j++)
				{
					unSafeCharBuffer.AppendString(separator);
					unSafeCharBuffer.AppendString(value[j]);
				}
			}
			return text;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00010C64 File Offset: 0x0000EE64
		[SecuritySafeCritical]
		private unsafe static int CompareOrdinalIgnoreCaseHelper(string strA, string strB)
		{
			int num = Math.Min(strA.Length, strB.Length);
			fixed (char* ptr = &strA.m_firstChar)
			{
				fixed (char* ptr2 = &strB.m_firstChar)
				{
					char* ptr3 = ptr;
					char* ptr4 = ptr2;
					while (num != 0)
					{
						int num2 = (int)(*ptr3);
						int num3 = (int)(*ptr4);
						if (num2 - 97 <= 25)
						{
							num2 -= 32;
						}
						if (num3 - 97 <= 25)
						{
							num3 -= 32;
						}
						if (num2 != num3)
						{
							return num2 - num3;
						}
						ptr3++;
						ptr4++;
						num--;
					}
					return strA.Length - strB.Length;
				}
			}
		}

		// Token: 0x060004BA RID: 1210
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int nativeCompareOrdinalEx(string strA, int indexA, string strB, int indexB, int count);

		// Token: 0x060004BB RID: 1211
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal unsafe static extern int nativeCompareOrdinalIgnoreCaseWC(string strA, sbyte* strBBytes);

		// Token: 0x060004BC RID: 1212 RVA: 0x00010CF0 File Offset: 0x0000EEF0
		[SecuritySafeCritical]
		internal unsafe static string SmallCharToUpper(string strIn)
		{
			int length = strIn.Length;
			string text = string.FastAllocateString(length);
			fixed (char* ptr = &strIn.m_firstChar, ptr2 = &text.m_firstChar)
			{
				for (int i = 0; i < length; i++)
				{
					int num = (int)ptr[i];
					if (num - 97 <= 25)
					{
						num -= 32;
					}
					ptr2[i] = (char)num;
				}
			}
			return text;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00010D58 File Offset: 0x0000EF58
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		private unsafe static bool EqualsHelper(string strA, string strB)
		{
			int i = strA.Length;
			fixed (char* ptr = &strA.m_firstChar)
			{
				fixed (char* ptr2 = &strB.m_firstChar)
				{
					char* ptr3 = ptr;
					char* ptr4 = ptr2;
					while (i >= 12)
					{
						if (*(long*)ptr3 != *(long*)ptr4)
						{
							return false;
						}
						if (*(long*)(ptr3 + 4) != *(long*)(ptr4 + 4))
						{
							return false;
						}
						if (*(long*)(ptr3 + 8) != *(long*)(ptr4 + 8))
						{
							return false;
						}
						ptr3 += 12;
						ptr4 += 12;
						i -= 12;
					}
					while (i > 0 && *(int*)ptr3 == *(int*)ptr4)
					{
						ptr3 += 2;
						ptr4 += 2;
						i -= 2;
					}
					return i <= 0;
				}
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00010DF8 File Offset: 0x0000EFF8
		[SecuritySafeCritical]
		private unsafe static bool EqualsIgnoreCaseAsciiHelper(string strA, string strB)
		{
			int num = strA.Length;
			fixed (char* ptr = &strA.m_firstChar)
			{
				fixed (char* ptr2 = &strB.m_firstChar)
				{
					char* ptr3 = ptr;
					char* ptr4 = ptr2;
					while (num != 0)
					{
						int num2 = (int)(*ptr3);
						int num3 = (int)(*ptr4);
						if (num2 != num3 && ((num2 | 32) != (num3 | 32) || (num2 | 32) - 97 > 25))
						{
							return false;
						}
						ptr3++;
						ptr4++;
						num--;
					}
					return true;
				}
			}
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00010E60 File Offset: 0x0000F060
		[SecuritySafeCritical]
		private unsafe static int CompareOrdinalHelper(string strA, string strB)
		{
			int i = Math.Min(strA.Length, strB.Length);
			int num = -1;
			fixed (char* ptr = &strA.m_firstChar)
			{
				fixed (char* ptr2 = &strB.m_firstChar)
				{
					char* ptr3 = ptr;
					char* ptr4 = ptr2;
					while (i >= 10)
					{
						if (*(int*)ptr3 != *(int*)ptr4)
						{
							num = 0;
							break;
						}
						if (*(int*)(ptr3 + 2) != *(int*)(ptr4 + 2))
						{
							num = 2;
							break;
						}
						if (*(int*)(ptr3 + 4) != *(int*)(ptr4 + 4))
						{
							num = 4;
							break;
						}
						if (*(int*)(ptr3 + 6) != *(int*)(ptr4 + 6))
						{
							num = 6;
							break;
						}
						if (*(int*)(ptr3 + 8) != *(int*)(ptr4 + 8))
						{
							num = 8;
							break;
						}
						ptr3 += 10;
						ptr4 += 10;
						i -= 10;
					}
					if (num != -1)
					{
						ptr3 += num;
						ptr4 += num;
						int result;
						if ((result = (int)(*ptr3 - *ptr4)) != 0)
						{
							return result;
						}
						return (int)(ptr3[1] - ptr4[1]);
					}
					else
					{
						while (i > 0 && *(int*)ptr3 == *(int*)ptr4)
						{
							ptr3 += 2;
							ptr4 += 2;
							i -= 2;
						}
						if (i <= 0)
						{
							return strA.Length - strB.Length;
						}
						int result2;
						if ((result2 = (int)(*ptr3 - *ptr4)) != 0)
						{
							return result2;
						}
						return (int)(ptr3[1] - ptr4[1]);
					}
				}
			}
		}

		/// <summary>Determines whether this instance and a specified object, which must also be a <see cref="T:System.String" /> object, have the same value.</summary>
		/// <param name="obj">The string to compare to this instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is a <see cref="T:System.String" /> and its value is the same as this instance; otherwise, <see langword="false" />.  If <paramref name="obj" /> is <see langword="null" />, the method returns <see langword="false" />.</returns>
		// Token: 0x060004C0 RID: 1216 RVA: 0x00010FA0 File Offset: 0x0000F1A0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			if (this == null)
			{
				throw new NullReferenceException();
			}
			string text = obj as string;
			return text != null && (this == obj || (this.Length == text.Length && string.EqualsHelper(this, text)));
		}

		/// <summary>Determines whether this instance and another specified <see cref="T:System.String" /> object have the same value.</summary>
		/// <param name="value">The string to compare to this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of the <paramref name="value" /> parameter is the same as the value of this instance; otherwise, <see langword="false" />. If <paramref name="value" /> is <see langword="null" />, the method returns <see langword="false" />.</returns>
		// Token: 0x060004C1 RID: 1217 RVA: 0x00010FDF File Offset: 0x0000F1DF
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public bool Equals(string value)
		{
			if (this == null)
			{
				throw new NullReferenceException();
			}
			return value != null && (this == value || (this.Length == value.Length && string.EqualsHelper(this, value)));
		}

		/// <summary>Determines whether this string and a specified <see cref="T:System.String" /> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.</summary>
		/// <param name="value">The string to compare to this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
		/// <returns>
		///   <see langword="true" /> if the value of the <paramref name="value" /> parameter is the same as this string; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x060004C2 RID: 1218 RVA: 0x0001100C File Offset: 0x0000F20C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public bool Equals(string value, StringComparison comparisonType)
		{
			if (comparisonType < StringComparison.CurrentCulture || comparisonType > StringComparison.OrdinalIgnoreCase)
			{
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
			if (this == value)
			{
				return true;
			}
			if (value == null)
			{
				return false;
			}
			switch (comparisonType)
			{
			case StringComparison.CurrentCulture:
				return CultureInfo.CurrentCulture.CompareInfo.Compare(this, value, CompareOptions.None) == 0;
			case StringComparison.CurrentCultureIgnoreCase:
				return CultureInfo.CurrentCulture.CompareInfo.Compare(this, value, CompareOptions.IgnoreCase) == 0;
			case StringComparison.InvariantCulture:
				return CultureInfo.InvariantCulture.CompareInfo.Compare(this, value, CompareOptions.None) == 0;
			case StringComparison.InvariantCultureIgnoreCase:
				return CultureInfo.InvariantCulture.CompareInfo.Compare(this, value, CompareOptions.IgnoreCase) == 0;
			case StringComparison.Ordinal:
				return this.Length == value.Length && string.EqualsHelper(this, value);
			case StringComparison.OrdinalIgnoreCase:
				if (this.Length != value.Length)
				{
					return false;
				}
				if (this.IsAscii() && value.IsAscii())
				{
					return string.EqualsIgnoreCaseAsciiHelper(this, value);
				}
				return TextInfo.CompareOrdinalIgnoreCase(this, value) == 0;
			default:
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
		}

		/// <summary>Determines whether two specified <see cref="T:System.String" /> objects have the same value.</summary>
		/// <param name="a">The first string to compare, or <see langword="null" />.</param>
		/// <param name="b">The second string to compare, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="a" /> is the same as the value of <paramref name="b" />; otherwise, <see langword="false" />. If both <paramref name="a" /> and <paramref name="b" /> are <see langword="null" />, the method returns <see langword="true" />.</returns>
		// Token: 0x060004C3 RID: 1219 RVA: 0x0001111B File Offset: 0x0000F31B
		[__DynamicallyInvokable]
		public static bool Equals(string a, string b)
		{
			return a == b || (a != null && b != null && a.Length == b.Length && string.EqualsHelper(a, b));
		}

		/// <summary>Determines whether two specified <see cref="T:System.String" /> objects have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.</summary>
		/// <param name="a">The first string to compare, or <see langword="null" />.</param>
		/// <param name="b">The second string to compare, or <see langword="null" />.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
		/// <returns>
		///   <see langword="true" /> if the value of the <paramref name="a" /> parameter is equal to the value of the <paramref name="b" /> parameter; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x060004C4 RID: 1220 RVA: 0x00011144 File Offset: 0x0000F344
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static bool Equals(string a, string b, StringComparison comparisonType)
		{
			if (comparisonType < StringComparison.CurrentCulture || comparisonType > StringComparison.OrdinalIgnoreCase)
			{
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
			if (a == b)
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			switch (comparisonType)
			{
			case StringComparison.CurrentCulture:
				return CultureInfo.CurrentCulture.CompareInfo.Compare(a, b, CompareOptions.None) == 0;
			case StringComparison.CurrentCultureIgnoreCase:
				return CultureInfo.CurrentCulture.CompareInfo.Compare(a, b, CompareOptions.IgnoreCase) == 0;
			case StringComparison.InvariantCulture:
				return CultureInfo.InvariantCulture.CompareInfo.Compare(a, b, CompareOptions.None) == 0;
			case StringComparison.InvariantCultureIgnoreCase:
				return CultureInfo.InvariantCulture.CompareInfo.Compare(a, b, CompareOptions.IgnoreCase) == 0;
			case StringComparison.Ordinal:
				return a.Length == b.Length && string.EqualsHelper(a, b);
			case StringComparison.OrdinalIgnoreCase:
				if (a.Length != b.Length)
				{
					return false;
				}
				if (a.IsAscii() && b.IsAscii())
				{
					return string.EqualsIgnoreCaseAsciiHelper(a, b);
				}
				return TextInfo.CompareOrdinalIgnoreCase(a, b) == 0;
			default:
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
		}

		/// <summary>Determines whether two specified strings have the same value.</summary>
		/// <param name="a">The first string to compare, or <see langword="null" />.</param>
		/// <param name="b">The second string to compare, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="a" /> is the same as the value of <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060004C5 RID: 1221 RVA: 0x00011256 File Offset: 0x0000F456
		[__DynamicallyInvokable]
		public static bool operator ==(string a, string b)
		{
			return string.Equals(a, b);
		}

		/// <summary>Determines whether two specified strings have different values.</summary>
		/// <param name="a">The first string to compare, or <see langword="null" />.</param>
		/// <param name="b">The second string to compare, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="a" /> is different from the value of <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060004C6 RID: 1222 RVA: 0x0001125F File Offset: 0x0000F45F
		[__DynamicallyInvokable]
		public static bool operator !=(string a, string b)
		{
			return !string.Equals(a, b);
		}

		/// <summary>Gets the <see cref="T:System.Char" /> object at a specified position in the current <see cref="T:System.String" /> object.</summary>
		/// <param name="index">A position in the current string.</param>
		/// <returns>The object at position <paramref name="index" />.</returns>
		/// <exception cref="T:System.IndexOutOfRangeException">
		///   <paramref name="index" /> is greater than or equal to the length of this object or less than zero.</exception>
		// Token: 0x17000085 RID: 133
		[__DynamicallyInvokable]
		[IndexerName("Chars")]
		public extern char this[int index]
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		/// <summary>Copies a specified number of characters from a specified position in this instance to a specified position in an array of Unicode characters.</summary>
		/// <param name="sourceIndex">The index of the first character in this instance to copy.</param>
		/// <param name="destination">An array of Unicode characters to which characters in this instance are copied.</param>
		/// <param name="destinationIndex">The index in <paramref name="destination" /> at which the copy operation begins.</param>
		/// <param name="count">The number of characters in this instance to copy to <paramref name="destination" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="destination" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="sourceIndex" />, <paramref name="destinationIndex" />, or <paramref name="count" /> is negative  
		/// -or-  
		/// <paramref name="sourceIndex" /> does not identify a position in the current instance.  
		/// -or-  
		/// <paramref name="destinationIndex" /> does not identify a valid index in the <paramref name="destination" /> array.  
		/// -or-  
		/// <paramref name="count" /> is greater than the length of the substring from <paramref name="sourceIndex" /> to the end of this instance  
		/// -or-  
		/// <paramref name="count" /> is greater than the length of the subarray from <paramref name="destinationIndex" /> to the end of the <paramref name="destination" /> array.</exception>
		// Token: 0x060004C8 RID: 1224 RVA: 0x0001126C File Offset: 0x0000F46C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
		{
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
			}
			if (sourceIndex < 0)
			{
				throw new ArgumentOutOfRangeException("sourceIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (count > this.Length - sourceIndex)
			{
				throw new ArgumentOutOfRangeException("sourceIndex", Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
			}
			if (destinationIndex > destination.Length - count || destinationIndex < 0)
			{
				throw new ArgumentOutOfRangeException("destinationIndex", Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
			}
			if (count > 0)
			{
				fixed (char* ptr = &this.m_firstChar)
				{
					fixed (char* ptr2 = destination)
					{
						string.wstrcpy(ptr2 + destinationIndex, ptr + sourceIndex, count);
					}
				}
			}
		}

		/// <summary>Copies the characters in this instance to a Unicode character array.</summary>
		/// <returns>A Unicode character array whose elements are the individual characters of this instance. If this instance is an empty string, the returned array is empty and has a zero length.</returns>
		// Token: 0x060004C9 RID: 1225 RVA: 0x0001133C File Offset: 0x0000F53C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe char[] ToCharArray()
		{
			int length = this.Length;
			char[] array = new char[length];
			if (length > 0)
			{
				fixed (char* ptr = &this.m_firstChar)
				{
					fixed (char* ptr2 = array)
					{
						string.wstrcpy(ptr2, ptr, length);
					}
				}
			}
			return array;
		}

		/// <summary>Copies the characters in a specified substring in this instance to a Unicode character array.</summary>
		/// <param name="startIndex">The starting position of a substring in this instance.</param>
		/// <param name="length">The length of the substring in this instance.</param>
		/// <returns>A Unicode character array whose elements are the <paramref name="length" /> number of characters in this instance starting from character position <paramref name="startIndex" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.  
		/// -or-  
		/// <paramref name="startIndex" /> plus <paramref name="length" /> is greater than the length of this instance.</exception>
		// Token: 0x060004CA RID: 1226 RVA: 0x00011390 File Offset: 0x0000F590
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe char[] ToCharArray(int startIndex, int length)
		{
			if (startIndex < 0 || startIndex > this.Length || startIndex > this.Length - length)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			char[] array = new char[length];
			if (length > 0)
			{
				fixed (char* ptr = &this.m_firstChar)
				{
					fixed (char* ptr2 = array)
					{
						string.wstrcpy(ptr2, ptr + startIndex, length);
					}
				}
			}
			return array;
		}

		/// <summary>Indicates whether the specified string is <see langword="null" /> or an empty string ("").</summary>
		/// <param name="value">The string to test.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="value" /> parameter is <see langword="null" /> or an empty string (""); otherwise, <see langword="false" />.</returns>
		// Token: 0x060004CB RID: 1227 RVA: 0x00011422 File Offset: 0x0000F622
		[__DynamicallyInvokable]
		public static bool IsNullOrEmpty(string value)
		{
			return value == null || value.Length == 0;
		}

		/// <summary>Indicates whether a specified string is <see langword="null" />, empty, or consists only of white-space characters.</summary>
		/// <param name="value">The string to test.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="value" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" />, or if <paramref name="value" /> consists exclusively of white-space characters.</returns>
		// Token: 0x060004CC RID: 1228 RVA: 0x00011434 File Offset: 0x0000F634
		[__DynamicallyInvokable]
		public static bool IsNullOrWhiteSpace(string value)
		{
			if (value == null)
			{
				return true;
			}
			for (int i = 0; i < value.Length; i++)
			{
				if (!char.IsWhiteSpace(value[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060004CD RID: 1229
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int InternalMarvin32HashString(string s, int strLen, long additionalEntropy);

		// Token: 0x060004CE RID: 1230 RVA: 0x00011468 File Offset: 0x0000F668
		[SecuritySafeCritical]
		internal static bool UseRandomizedHashing()
		{
			return string.InternalUseRandomizedHashing();
		}

		// Token: 0x060004CF RID: 1231
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern bool InternalUseRandomizedHashing();

		/// <summary>Returns the hash code for this string.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x060004D0 RID: 1232 RVA: 0x00011470 File Offset: 0x0000F670
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public unsafe override int GetHashCode()
		{
			if (HashHelpers.s_UseRandomizedStringHashing)
			{
				return string.InternalMarvin32HashString(this, this.Length, 0L);
			}
			char* ptr = this;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			int num = 5381;
			int num2 = num;
			char* ptr2 = ptr;
			int num3;
			while ((num3 = (int)(*ptr2)) != 0)
			{
				num = ((num << 5) + num ^ num3);
				num3 = (int)ptr2[1];
				if (num3 == 0)
				{
					break;
				}
				num2 = ((num2 << 5) + num2 ^ num3);
				ptr2 += 2;
			}
			return num + num2 * 1566083941;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x000114E8 File Offset: 0x0000F6E8
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal unsafe int GetLegacyNonRandomizedHashCode()
		{
			char* ptr = this;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			int num = 5381;
			int num2 = num;
			char* ptr2 = ptr;
			int num3;
			while ((num3 = (int)(*ptr2)) != 0)
			{
				num = ((num << 5) + num ^ num3);
				num3 = (int)ptr2[1];
				if (num3 == 0)
				{
					break;
				}
				num2 = ((num2 << 5) + num2 ^ num3);
				ptr2 += 2;
			}
			return num + num2 * 1566083941;
		}

		/// <summary>Gets the number of characters in the current <see cref="T:System.String" /> object.</summary>
		/// <returns>The number of characters in the current string.</returns>
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060004D2 RID: 1234
		[__DynamicallyInvokable]
		public extern int Length { [SecuritySafeCritical] [__DynamicallyInvokable] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		/// <summary>Splits a string into substrings that are based on the characters in an array.</summary>
		/// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />.</param>
		/// <returns>An array whose elements contain the substrings from this instance that are delimited by one or more characters in <paramref name="separator" />. For more information, see the Remarks section.</returns>
		// Token: 0x060004D3 RID: 1235 RVA: 0x00011549 File Offset: 0x0000F749
		[__DynamicallyInvokable]
		public string[] Split(params char[] separator)
		{
			return this.SplitInternal(separator, int.MaxValue, StringSplitOptions.None);
		}

		/// <summary>Splits a string into a maximum number of substrings based on the characters in an array. You also specify the maximum number of substrings to return.</summary>
		/// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />.</param>
		/// <param name="count">The maximum number of substrings to return.</param>
		/// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in <paramref name="separator" />. For more information, see the Remarks section.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is negative.</exception>
		// Token: 0x060004D4 RID: 1236 RVA: 0x00011558 File Offset: 0x0000F758
		[__DynamicallyInvokable]
		public string[] Split(char[] separator, int count)
		{
			return this.SplitInternal(separator, count, StringSplitOptions.None);
		}

		/// <summary>Splits a string into substrings based on the characters in an array. You can specify whether the substrings include empty array elements.</summary>
		/// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />.</param>
		/// <param name="options">
		///   <see cref="F:System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None" /> to include empty array elements in the array returned.</param>
		/// <returns>An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator" />. For more information, see the Remarks section.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="options" /> is not one of the <see cref="T:System.StringSplitOptions" /> values.</exception>
		// Token: 0x060004D5 RID: 1237 RVA: 0x00011563 File Offset: 0x0000F763
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public string[] Split(char[] separator, StringSplitOptions options)
		{
			return this.SplitInternal(separator, int.MaxValue, options);
		}

		/// <summary>Splits a string into a maximum number of substrings based on the characters in an array.</summary>
		/// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />.</param>
		/// <param name="count">The maximum number of substrings to return.</param>
		/// <param name="options">
		///   <see cref="F:System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None" /> to include empty array elements in the array returned.</param>
		/// <returns>An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator" />. For more information, see the Remarks section.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="options" /> is not one of the <see cref="T:System.StringSplitOptions" /> values.</exception>
		// Token: 0x060004D6 RID: 1238 RVA: 0x00011572 File Offset: 0x0000F772
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public string[] Split(char[] separator, int count, StringSplitOptions options)
		{
			return this.SplitInternal(separator, count, options);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00011580 File Offset: 0x0000F780
		[ComVisible(false)]
		internal string[] SplitInternal(char[] separator, int count, StringSplitOptions options)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
			}
			if (options < StringSplitOptions.None || options > StringSplitOptions.RemoveEmptyEntries)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					options
				}));
			}
			bool flag = options == StringSplitOptions.RemoveEmptyEntries;
			if (count == 0 || (flag && this.Length == 0))
			{
				return new string[0];
			}
			int[] sepList = new int[this.Length];
			int num = this.MakeSeparatorList(separator, ref sepList);
			if (num == 0 || count == 1)
			{
				return new string[]
				{
					this
				};
			}
			if (flag)
			{
				return this.InternalSplitOmitEmptyEntries(sepList, null, num, count);
			}
			return this.InternalSplitKeepEmptyEntries(sepList, null, num, count);
		}

		/// <summary>Splits a string into substrings based on the strings in an array. You can specify whether the substrings include empty array elements.</summary>
		/// <param name="separator">A string array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />.</param>
		/// <param name="options">
		///   <see cref="F:System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None" /> to include empty array elements in the array returned.</param>
		/// <returns>An array whose elements contain the substrings in this string that are delimited by one or more strings in <paramref name="separator" />. For more information, see the Remarks section.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="options" /> is not one of the <see cref="T:System.StringSplitOptions" /> values.</exception>
		// Token: 0x060004D8 RID: 1240 RVA: 0x00011629 File Offset: 0x0000F829
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public string[] Split(string[] separator, StringSplitOptions options)
		{
			return this.Split(separator, int.MaxValue, options);
		}

		/// <summary>Splits a string into a maximum number of substrings based on the strings in an array. You can specify whether the substrings include empty array elements.</summary>
		/// <param name="separator">A string array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null" />.</param>
		/// <param name="count">The maximum number of substrings to return.</param>
		/// <param name="options">
		///   <see cref="F:System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements from the array returned; or <see cref="F:System.StringSplitOptions.None" /> to include empty array elements in the array returned.</param>
		/// <returns>An array whose elements contain the substrings in this string that are delimited by one or more strings in <paramref name="separator" />. For more information, see the Remarks section.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="options" /> is not one of the <see cref="T:System.StringSplitOptions" /> values.</exception>
		// Token: 0x060004D9 RID: 1241 RVA: 0x00011638 File Offset: 0x0000F838
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public string[] Split(string[] separator, int count, StringSplitOptions options)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
			}
			if (options < StringSplitOptions.None || options > StringSplitOptions.RemoveEmptyEntries)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)options
				}));
			}
			bool flag = options == StringSplitOptions.RemoveEmptyEntries;
			if (separator == null || separator.Length == 0)
			{
				return this.SplitInternal(null, count, options);
			}
			if (count == 0 || (flag && this.Length == 0))
			{
				return new string[0];
			}
			int[] sepList = new int[this.Length];
			int[] lengthList = new int[this.Length];
			int num = this.MakeSeparatorList(separator, ref sepList, ref lengthList);
			if (num == 0 || count == 1)
			{
				return new string[]
				{
					this
				};
			}
			if (flag)
			{
				return this.InternalSplitOmitEmptyEntries(sepList, lengthList, num, count);
			}
			return this.InternalSplitKeepEmptyEntries(sepList, lengthList, num, count);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00011704 File Offset: 0x0000F904
		private string[] InternalSplitKeepEmptyEntries(int[] sepList, int[] lengthList, int numReplaces, int count)
		{
			int num = 0;
			int num2 = 0;
			count--;
			int num3 = (numReplaces < count) ? numReplaces : count;
			string[] array = new string[num3 + 1];
			int num4 = 0;
			while (num4 < num3 && num < this.Length)
			{
				array[num2++] = this.Substring(num, sepList[num4] - num);
				num = sepList[num4] + ((lengthList == null) ? 1 : lengthList[num4]);
				num4++;
			}
			if (num < this.Length && num3 >= 0)
			{
				array[num2] = this.Substring(num);
			}
			else if (num2 == num3)
			{
				array[num2] = string.Empty;
			}
			return array;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00011794 File Offset: 0x0000F994
		private string[] InternalSplitOmitEmptyEntries(int[] sepList, int[] lengthList, int numReplaces, int count)
		{
			int num = (numReplaces < count) ? (numReplaces + 1) : count;
			string[] array = new string[num];
			int num2 = 0;
			int num3 = 0;
			int i = 0;
			while (i < numReplaces && num2 < this.Length)
			{
				if (sepList[i] - num2 > 0)
				{
					array[num3++] = this.Substring(num2, sepList[i] - num2);
				}
				num2 = sepList[i] + ((lengthList == null) ? 1 : lengthList[i]);
				if (num3 == count - 1)
				{
					while (i < numReplaces - 1)
					{
						if (num2 != sepList[++i])
						{
							break;
						}
						num2 += ((lengthList == null) ? 1 : lengthList[i]);
					}
					break;
				}
				i++;
			}
			if (num2 < this.Length)
			{
				array[num3++] = this.Substring(num2);
			}
			string[] array2 = array;
			if (num3 != num)
			{
				array2 = new string[num3];
				for (int j = 0; j < num3; j++)
				{
					array2[j] = array[j];
				}
			}
			return array2;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0001186C File Offset: 0x0000FA6C
		[SecuritySafeCritical]
		private unsafe int MakeSeparatorList(char[] separator, ref int[] sepList)
		{
			int num = 0;
			if (separator == null || separator.Length == 0)
			{
				fixed (char* ptr = &this.m_firstChar)
				{
					int num2 = 0;
					while (num2 < this.Length && num < sepList.Length)
					{
						if (char.IsWhiteSpace(ptr[num2]))
						{
							sepList[num++] = num2;
						}
						num2++;
					}
				}
			}
			else
			{
				int num3 = sepList.Length;
				int num4 = separator.Length;
				fixed (char* ptr2 = &this.m_firstChar, ptr3 = separator)
				{
					int num5 = 0;
					while (num5 < this.Length && num < num3)
					{
						char* ptr4 = ptr3;
						int i = 0;
						while (i < num4)
						{
							if (ptr2[num5] == *ptr4)
							{
								sepList[num++] = num5;
								break;
							}
							i++;
							ptr4++;
						}
						num5++;
					}
				}
			}
			return num;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00011948 File Offset: 0x0000FB48
		[SecuritySafeCritical]
		private unsafe int MakeSeparatorList(string[] separators, ref int[] sepList, ref int[] lengthList)
		{
			int num = 0;
			int num2 = sepList.Length;
			int num3 = separators.Length;
			fixed (char* ptr = &this.m_firstChar)
			{
				int num4 = 0;
				while (num4 < this.Length && num < num2)
				{
					foreach (string text in separators)
					{
						if (!string.IsNullOrEmpty(text))
						{
							int length = text.Length;
							if (ptr[num4] == text[0] && length <= this.Length - num4 && (length == 1 || string.CompareOrdinal(this, num4, text, 0, length) == 0))
							{
								sepList[num] = num4;
								lengthList[num] = length;
								num++;
								num4 += length - 1;
								break;
							}
						}
					}
					num4++;
				}
			}
			return num;
		}

		/// <summary>Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.</summary>
		/// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
		/// <returns>A string that is equivalent to the substring that begins at <paramref name="startIndex" /> in this instance, or <see cref="F:System.String.Empty" /> if <paramref name="startIndex" /> is equal to the length of this instance.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> is less than zero or greater than the length of this instance.</exception>
		// Token: 0x060004DE RID: 1246 RVA: 0x00011A00 File Offset: 0x0000FC00
		[__DynamicallyInvokable]
		public string Substring(int startIndex)
		{
			return this.Substring(startIndex, this.Length - startIndex);
		}

		/// <summary>Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.</summary>
		/// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
		/// <param name="length">The number of characters in the substring.</param>
		/// <returns>A string that is equivalent to the substring of length <paramref name="length" /> that begins at <paramref name="startIndex" /> in this instance, or <see cref="F:System.String.Empty" /> if <paramref name="startIndex" /> is equal to the length of this instance and <paramref name="length" /> is zero.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> plus <paramref name="length" /> indicates a position not within this instance.  
		/// -or-  
		/// <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.</exception>
		// Token: 0x060004DF RID: 1247 RVA: 0x00011A14 File Offset: 0x0000FC14
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public string Substring(int startIndex, int length)
		{
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
			}
			if (startIndex > this.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndexLargerThanLength"));
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
			}
			if (startIndex > this.Length - length)
			{
				throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_IndexLength"));
			}
			if (length == 0)
			{
				return string.Empty;
			}
			if (startIndex == 0 && length == this.Length)
			{
				return this;
			}
			return this.InternalSubString(startIndex, length);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00011AB0 File Offset: 0x0000FCB0
		[SecurityCritical]
		private unsafe string InternalSubString(int startIndex, int length)
		{
			string text = string.FastAllocateString(length);
			fixed (char* ptr = &text.m_firstChar)
			{
				fixed (char* ptr2 = &this.m_firstChar)
				{
					string.wstrcpy(ptr, ptr2 + startIndex, length);
				}
			}
			return text;
		}

		/// <summary>Removes all leading and trailing occurrences of a set of characters specified in an array from the current <see cref="T:System.String" /> object.</summary>
		/// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null" />.</param>
		/// <returns>The string that remains after all occurrences of the characters in the <paramref name="trimChars" /> parameter are removed from the start and end of the current string. If <paramref name="trimChars" /> is <see langword="null" /> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		// Token: 0x060004E1 RID: 1249 RVA: 0x00011AE8 File Offset: 0x0000FCE8
		[__DynamicallyInvokable]
		public string Trim(params char[] trimChars)
		{
			if (trimChars == null || trimChars.Length == 0)
			{
				return this.TrimHelper(2);
			}
			return this.TrimHelper(trimChars, 2);
		}

		/// <summary>Removes all leading occurrences of a set of characters specified in an array from the current <see cref="T:System.String" /> object.</summary>
		/// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null" />.</param>
		/// <returns>The string that remains after all occurrences of characters in the <paramref name="trimChars" /> parameter are removed from the start of the current string. If <paramref name="trimChars" /> is <see langword="null" /> or an empty array, white-space characters are removed instead.</returns>
		// Token: 0x060004E2 RID: 1250 RVA: 0x00011B01 File Offset: 0x0000FD01
		[__DynamicallyInvokable]
		public string TrimStart(params char[] trimChars)
		{
			if (trimChars == null || trimChars.Length == 0)
			{
				return this.TrimHelper(0);
			}
			return this.TrimHelper(trimChars, 0);
		}

		/// <summary>Removes all trailing occurrences of a set of characters specified in an array from the current <see cref="T:System.String" /> object.</summary>
		/// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null" />.</param>
		/// <returns>The string that remains after all occurrences of the characters in the <paramref name="trimChars" /> parameter are removed from the end of the current string. If <paramref name="trimChars" /> is <see langword="null" /> or an empty array, Unicode white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		// Token: 0x060004E3 RID: 1251 RVA: 0x00011B1A File Offset: 0x0000FD1A
		[__DynamicallyInvokable]
		public string TrimEnd(params char[] trimChars)
		{
			if (trimChars == null || trimChars.Length == 0)
			{
				return this.TrimHelper(1);
			}
			return this.TrimHelper(trimChars, 1);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified pointer to an array of Unicode characters.</summary>
		/// <param name="value">A pointer to a null-terminated array of Unicode characters.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The current process does not have read access to all the addressed characters.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="value" /> specifies an array that contains an invalid Unicode character, or <paramref name="value" /> specifies an address less than 64000.</exception>
		// Token: 0x060004E4 RID: 1252
		[SecurityCritical]
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe extern String(char* value);

		/// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified pointer to an array of Unicode characters, a starting character position within that array, and a length.</summary>
		/// <param name="value">A pointer to an array of Unicode characters.</param>
		/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
		/// <param name="length">The number of characters within <paramref name="value" /> to use.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> or <paramref name="length" /> is less than zero, <paramref name="value" /> + <paramref name="startIndex" /> cause a pointer overflow, or the current process does not have read access to all the addressed characters.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="value" /> specifies an array that contains an invalid Unicode character, or <paramref name="value" /> + <paramref name="startIndex" /> specifies an address less than 64000.</exception>
		// Token: 0x060004E5 RID: 1253
		[SecurityCritical]
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe extern String(char* value, int startIndex, int length);

		/// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a pointer to an array of 8-bit signed integers.</summary>
		/// <param name="value">A pointer to a null-terminated array of 8-bit signed integers. The integers are interpreted using the current system code page encoding (that is, the encoding specified by <see cref="P:System.Text.Encoding.Default" />).</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">A new instance of <see cref="T:System.String" /> could not be initialized using <paramref name="value" />, assuming <paramref name="value" /> is encoded in ANSI.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The length of the new string to initialize, which is determined by the null termination character of <paramref name="value" />, is too large to allocate.</exception>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="value" /> specifies an invalid address.</exception>
		// Token: 0x060004E6 RID: 1254
		[SecurityCritical]
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe extern String(sbyte* value);

		/// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified pointer to an array of 8-bit signed integers, a starting position within that array, and a length.</summary>
		/// <param name="value">A pointer to an array of 8-bit signed integers. The integers are interpreted using the current system code page encoding (that is, the encoding specified by <see cref="P:System.Text.Encoding.Default" />).</param>
		/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
		/// <param name="length">The number of characters within <paramref name="value" /> to use.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.  
		/// -or-  
		/// The address specified by <paramref name="value" /> + <paramref name="startIndex" /> is too large for the current platform; that is, the address calculation overflowed.  
		/// -or-  
		/// The length of the new string to initialize is too large to allocate.</exception>
		/// <exception cref="T:System.ArgumentException">The address specified by <paramref name="value" /> + <paramref name="startIndex" /> is less than 64K.  
		///  -or-  
		///  A new instance of <see cref="T:System.String" /> could not be initialized using <paramref name="value" />, assuming <paramref name="value" /> is encoded in ANSI.</exception>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="value" />, <paramref name="startIndex" />, and <paramref name="length" /> collectively specify an invalid address.</exception>
		// Token: 0x060004E7 RID: 1255
		[SecurityCritical]
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe extern String(sbyte* value, int startIndex, int length);

		/// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified pointer to an array of 8-bit signed integers, a starting position within that array, a length, and an <see cref="T:System.Text.Encoding" /> object.</summary>
		/// <param name="value">A pointer to an array of 8-bit signed integers.</param>
		/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
		/// <param name="length">The number of characters within <paramref name="value" /> to use.</param>
		/// <param name="enc">An object that specifies how the array referenced by <paramref name="value" /> is encoded. If <paramref name="enc" /> is <see langword="null" />, ANSI encoding is assumed.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.  
		/// -or-  
		/// The address specified by <paramref name="value" /> + <paramref name="startIndex" /> is too large for the current platform; that is, the address calculation overflowed.  
		/// -or-  
		/// The length of the new string to initialize is too large to allocate.</exception>
		/// <exception cref="T:System.ArgumentException">The address specified by <paramref name="value" /> + <paramref name="startIndex" /> is less than 64K.  
		///  -or-  
		///  A new instance of <see cref="T:System.String" /> could not be initialized using <paramref name="value" />, assuming <paramref name="value" /> is encoded as specified by <paramref name="enc" />.</exception>
		/// <exception cref="T:System.AccessViolationException">
		///   <paramref name="value" />, <paramref name="startIndex" />, and <paramref name="length" /> collectively specify an invalid address.</exception>
		// Token: 0x060004E8 RID: 1256
		[SecurityCritical]
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe extern String(sbyte* value, int startIndex, int length, Encoding enc);

		// Token: 0x060004E9 RID: 1257 RVA: 0x00011B34 File Offset: 0x0000FD34
		[SecurityCritical]
		private unsafe static string CreateString(sbyte* value, int startIndex, int length, Encoding enc)
		{
			if (enc == null)
			{
				return new string(value, startIndex, length);
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
			}
			if (value + startIndex < value)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
			}
			byte[] array = new byte[length];
			try
			{
				Buffer.Memcpy(array, 0, (byte*)value, startIndex, length);
			}
			catch (NullReferenceException)
			{
				throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
			}
			return enc.GetString(array);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00011BDC File Offset: 0x0000FDDC
		[SecurityCritical]
		internal unsafe static string CreateStringFromEncoding(byte* bytes, int byteLength, Encoding encoding)
		{
			int charCount = encoding.GetCharCount(bytes, byteLength, null);
			if (charCount == 0)
			{
				return string.Empty;
			}
			string text = string.FastAllocateString(charCount);
			fixed (char* ptr = &text.m_firstChar)
			{
				int chars = encoding.GetChars(bytes, byteLength, ptr, charCount, null);
			}
			return text;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00011C1C File Offset: 0x0000FE1C
		[SecuritySafeCritical]
		internal unsafe int GetBytesFromEncoding(byte* pbNativeBuffer, int cbNativeBuffer, Encoding encoding)
		{
			fixed (char* ptr = &this.m_firstChar)
			{
				return encoding.GetBytes(ptr, this.m_stringLength, pbNativeBuffer, cbNativeBuffer);
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00011C40 File Offset: 0x0000FE40
		[SecuritySafeCritical]
		internal unsafe int ConvertToAnsi(byte* pbNativeBuffer, int cbNativeBuffer, bool fBestFit, bool fThrowOnUnmappableChar)
		{
			uint flags = fBestFit ? 0U : 1024U;
			uint num = 0U;
			int num2;
			fixed (char* ptr = &this.m_firstChar)
			{
				num2 = Win32Native.WideCharToMultiByte(0U, flags, ptr, this.Length, pbNativeBuffer, cbNativeBuffer, IntPtr.Zero, fThrowOnUnmappableChar ? new IntPtr((void*)(&num)) : IntPtr.Zero);
			}
			if (num != 0U)
			{
				throw new ArgumentException(Environment.GetResourceString("Interop_Marshal_Unmappable_Char"));
			}
			pbNativeBuffer[num2] = 0;
			return num2;
		}

		/// <summary>Indicates whether this string is in Unicode normalization form C.</summary>
		/// <returns>
		///   <see langword="true" /> if this string is in normalization form C; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The current instance contains invalid Unicode characters.</exception>
		// Token: 0x060004ED RID: 1261 RVA: 0x00011CA8 File Offset: 0x0000FEA8
		public bool IsNormalized()
		{
			return this.IsNormalized(NormalizationForm.FormC);
		}

		/// <summary>Indicates whether this string is in the specified Unicode normalization form.</summary>
		/// <param name="normalizationForm">A Unicode normalization form.</param>
		/// <returns>
		///   <see langword="true" /> if this string is in the normalization form specified by the <paramref name="normalizationForm" /> parameter; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The current instance contains invalid Unicode characters.</exception>
		// Token: 0x060004EE RID: 1262 RVA: 0x00011CB1 File Offset: 0x0000FEB1
		[SecuritySafeCritical]
		public bool IsNormalized(NormalizationForm normalizationForm)
		{
			return (this.IsFastSort() && (normalizationForm == NormalizationForm.FormC || normalizationForm == NormalizationForm.FormKC || normalizationForm == NormalizationForm.FormD || normalizationForm == NormalizationForm.FormKD)) || Normalization.IsNormalized(this, normalizationForm);
		}

		/// <summary>Returns a new string whose textual value is the same as this string, but whose binary representation is in Unicode normalization form C.</summary>
		/// <returns>A new, normalized string whose textual value is the same as this string, but whose binary representation is in normalization form C.</returns>
		/// <exception cref="T:System.ArgumentException">The current instance contains invalid Unicode characters.</exception>
		// Token: 0x060004EF RID: 1263 RVA: 0x00011CD4 File Offset: 0x0000FED4
		public string Normalize()
		{
			return this.Normalize(NormalizationForm.FormC);
		}

		/// <summary>Returns a new string whose textual value is the same as this string, but whose binary representation is in the specified Unicode normalization form.</summary>
		/// <param name="normalizationForm">A Unicode normalization form.</param>
		/// <returns>A new string whose textual value is the same as this string, but whose binary representation is in the normalization form specified by the <paramref name="normalizationForm" /> parameter.</returns>
		/// <exception cref="T:System.ArgumentException">The current instance contains invalid Unicode characters.</exception>
		// Token: 0x060004F0 RID: 1264 RVA: 0x00011CDD File Offset: 0x0000FEDD
		[SecuritySafeCritical]
		public string Normalize(NormalizationForm normalizationForm)
		{
			if (this.IsAscii() && (normalizationForm == NormalizationForm.FormC || normalizationForm == NormalizationForm.FormKC || normalizationForm == NormalizationForm.FormD || normalizationForm == NormalizationForm.FormKD))
			{
				return this;
			}
			return Normalization.Normalize(this, normalizationForm);
		}

		// Token: 0x060004F1 RID: 1265
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string FastAllocateString(int length);

		// Token: 0x060004F2 RID: 1266 RVA: 0x00011D00 File Offset: 0x0000FF00
		[SecuritySafeCritical]
		private unsafe static void FillStringChecked(string dest, int destPos, string src)
		{
			if (src.Length > dest.Length - destPos)
			{
				throw new IndexOutOfRangeException();
			}
			fixed (char* ptr = &dest.m_firstChar)
			{
				fixed (char* ptr2 = &src.m_firstChar)
				{
					string.wstrcpy(ptr + destPos, ptr2, src.Length);
				}
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by an array of Unicode characters, a starting character position within that array, and a length.</summary>
		/// <param name="value">An array of Unicode characters.</param>
		/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
		/// <param name="length">The number of characters within <paramref name="value" /> to use.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.  
		/// -or-  
		/// The sum of <paramref name="startIndex" /> and <paramref name="length" /> is greater than the number of elements in <paramref name="value" />.</exception>
		// Token: 0x060004F3 RID: 1267
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern String(char[] value, int startIndex, int length);

		/// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by an array of Unicode characters.</summary>
		/// <param name="value">An array of Unicode characters.</param>
		// Token: 0x060004F4 RID: 1268
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern String(char[] value);

		// Token: 0x060004F5 RID: 1269 RVA: 0x00011D4B File Offset: 0x0000FF4B
		[SecurityCritical]
		internal unsafe static void wstrcpy(char* dmem, char* smem, int charCount)
		{
			Buffer.Memcpy((byte*)dmem, (byte*)smem, charCount * 2);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00011D58 File Offset: 0x0000FF58
		[SecuritySafeCritical]
		private unsafe string CtorCharArray(char[] value)
		{
			if (value != null && value.Length != 0)
			{
				string text = string.FastAllocateString(value.Length);
				fixed (string text2 = text)
				{
					char* ptr = text2;
					if (ptr != null)
					{
						ptr += RuntimeHelpers.OffsetToStringData / 2;
					}
					fixed (char* ptr2 = value)
					{
						string.wstrcpy(ptr, ptr2, value.Length);
						text2 = null;
					}
					return text;
				}
			}
			return string.Empty;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00011DB8 File Offset: 0x0000FFB8
		[SecuritySafeCritical]
		private unsafe string CtorCharArrayStartLength(char[] value, int startIndex, int length)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
			}
			if (startIndex > value.Length - length)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (length > 0)
			{
				string text = string.FastAllocateString(length);
				fixed (string text2 = text)
				{
					char* ptr = text2;
					if (ptr != null)
					{
						ptr += RuntimeHelpers.OffsetToStringData / 2;
					}
					fixed (char* ptr2 = value)
					{
						string.wstrcpy(ptr, ptr2 + startIndex, length);
						text2 = null;
					}
					return text;
				}
			}
			return string.Empty;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00011E74 File Offset: 0x00010074
		[SecuritySafeCritical]
		private unsafe string CtorCharCount(char c, int count)
		{
			if (count > 0)
			{
				string text = string.FastAllocateString(count);
				if (c != '\0')
				{
					fixed (string text2 = text)
					{
						char* ptr = text2;
						if (ptr != null)
						{
							ptr += RuntimeHelpers.OffsetToStringData / 2;
						}
						char* ptr2 = ptr;
						while ((ptr2 & 3U) != 0U && count > 0)
						{
							*(ptr2++) = c;
							count--;
						}
						uint num = (uint)((uint)c << 16 | c);
						if (count >= 4)
						{
							count -= 4;
							do
							{
								*(int*)ptr2 = (int)num;
								*(int*)(ptr2 + 2) = (int)num;
								ptr2 += 4;
								count -= 4;
							}
							while (count >= 0);
						}
						if ((count & 2) != 0)
						{
							*(int*)ptr2 = (int)num;
							ptr2 += 2;
						}
						if ((count & 1) != 0)
						{
							*ptr2 = c;
						}
					}
				}
				return text;
			}
			if (count == 0)
			{
				return string.Empty;
			}
			throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_MustBeNonNegNum", new object[]
			{
				"count"
			}));
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00011F2C File Offset: 0x0001012C
		[SecurityCritical]
		private unsafe static int wcslen(char* ptr)
		{
			char* ptr2 = ptr;
			while ((ptr2 & 3U) != 0U && *ptr2 != '\0')
			{
				ptr2++;
			}
			if (*ptr2 != '\0')
			{
				for (;;)
				{
					if ((*ptr2 & ptr2[1]) == '\0')
					{
						if (*ptr2 == '\0')
						{
							break;
						}
						if (ptr2[1] == '\0')
						{
							break;
						}
					}
					ptr2 += 2;
				}
			}
			while (*ptr2 != '\0')
			{
				ptr2++;
			}
			return (int)((long)(ptr2 - ptr));
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00011F80 File Offset: 0x00010180
		[SecurityCritical]
		private unsafe string CtorCharPtr(char* ptr)
		{
			if (ptr == null)
			{
				return string.Empty;
			}
			if (ptr < 64000)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeStringPtrNotAtom"));
			}
			string result;
			try
			{
				int num = string.wcslen(ptr);
				if (num == 0)
				{
					result = string.Empty;
				}
				else
				{
					string text = string.FastAllocateString(num);
					try
					{
						fixed (string text2 = text)
						{
							char* ptr2 = text2;
							if (ptr2 != null)
							{
								ptr2 += RuntimeHelpers.OffsetToStringData / 2;
							}
							string.wstrcpy(ptr2, ptr, num);
						}
					}
					finally
					{
						string text2 = null;
					}
					result = text;
				}
			}
			catch (NullReferenceException)
			{
				throw new ArgumentOutOfRangeException("ptr", Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
			}
			return result;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00012024 File Offset: 0x00010224
		[SecurityCritical]
		private unsafe string CtorCharPtrStartLength(char* ptr, int startIndex, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
			}
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
			}
			char* ptr2 = ptr + startIndex;
			if (ptr2 < ptr)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
			}
			if (length == 0)
			{
				return string.Empty;
			}
			string text = string.FastAllocateString(length);
			string result;
			try
			{
				try
				{
					fixed (string text2 = text)
					{
						char* ptr3 = text2;
						if (ptr3 != null)
						{
							ptr3 += RuntimeHelpers.OffsetToStringData / 2;
						}
						string.wstrcpy(ptr3, ptr2, length);
					}
				}
				finally
				{
					string text2 = null;
				}
				result = text;
			}
			catch (NullReferenceException)
			{
				throw new ArgumentOutOfRangeException("ptr", Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
			}
			return result;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.String" /> class to the value indicated by a specified Unicode character repeated a specified number of times.</summary>
		/// <param name="c">A Unicode character.</param>
		/// <param name="count">The number of times <paramref name="c" /> occurs.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is less than zero.</exception>
		// Token: 0x060004FC RID: 1276
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern String(char c, int count);

		/// <summary>Compares two specified <see cref="T:System.String" /> objects and returns an integer that indicates their relative position in the sort order.</summary>
		/// <param name="strA">The first string to compare.</param>
		/// <param name="strB">The second string to compare.</param>
		/// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///  <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///  <paramref name="strA" /> occurs in the same position as <paramref name="strB" /> in the sort order.  
		///
		///   Greater than zero  
		///
		///  <paramref name="strA" /> follows <paramref name="strB" /> in the sort order.</returns>
		// Token: 0x060004FD RID: 1277 RVA: 0x000120EC File Offset: 0x000102EC
		[__DynamicallyInvokable]
		public static int Compare(string strA, string strB)
		{
			return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
		}

		/// <summary>Compares two specified <see cref="T:System.String" /> objects, ignoring or honoring their case, and returns an integer that indicates their relative position in the sort order.</summary>
		/// <param name="strA">The first string to compare.</param>
		/// <param name="strB">The second string to compare.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
		/// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///  <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///  <paramref name="strA" /> occurs in the same position as <paramref name="strB" /> in the sort order.  
		///
		///   Greater than zero  
		///
		///  <paramref name="strA" /> follows <paramref name="strB" /> in the sort order.</returns>
		// Token: 0x060004FE RID: 1278 RVA: 0x00012100 File Offset: 0x00010300
		[__DynamicallyInvokable]
		public static int Compare(string strA, string strB, bool ignoreCase)
		{
			if (ignoreCase)
			{
				return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
			}
			return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
		}

		/// <summary>Compares two specified <see cref="T:System.String" /> objects using the specified rules, and returns an integer that indicates their relative position in the sort order.</summary>
		/// <param name="strA">The first string to compare.</param>
		/// <param name="strB">The second string to compare.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison.</param>
		/// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///  <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///  <paramref name="strA" /> is in the same position as <paramref name="strB" /> in the sort order.  
		///
		///   Greater than zero  
		///
		///  <paramref name="strA" /> follows <paramref name="strB" /> in the sort order.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <see cref="T:System.StringComparison" /> is not supported.</exception>
		// Token: 0x060004FF RID: 1279 RVA: 0x0001212C File Offset: 0x0001032C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static int Compare(string strA, string strB, StringComparison comparisonType)
		{
			if (comparisonType - StringComparison.CurrentCulture > 5)
			{
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
			if (strA == strB)
			{
				return 0;
			}
			if (strA == null)
			{
				return -1;
			}
			if (strB == null)
			{
				return 1;
			}
			switch (comparisonType)
			{
			case StringComparison.CurrentCulture:
				return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
			case StringComparison.CurrentCultureIgnoreCase:
				return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
			case StringComparison.InvariantCulture:
				return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
			case StringComparison.InvariantCultureIgnoreCase:
				return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
			case StringComparison.Ordinal:
				if (strA.m_firstChar - strB.m_firstChar != '\0')
				{
					return (int)(strA.m_firstChar - strB.m_firstChar);
				}
				return string.CompareOrdinalHelper(strA, strB);
			case StringComparison.OrdinalIgnoreCase:
				if (strA.IsAscii() && strB.IsAscii())
				{
					return string.CompareOrdinalIgnoreCaseHelper(strA, strB);
				}
				return TextInfo.CompareOrdinalIgnoreCase(strA, strB);
			default:
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_StringComparison"));
			}
		}

		/// <summary>Compares two specified <see cref="T:System.String" /> objects using the specified comparison options and culture-specific information to influence the comparison, and returns an integer that indicates the relationship of the two strings to each other in the sort order.</summary>
		/// <param name="strA">The first string to compare.</param>
		/// <param name="strB">The second string to compare.</param>
		/// <param name="culture">The culture that supplies culture-specific comparison information.</param>
		/// <param name="options">Options to use when performing the comparison (such as ignoring case or symbols).</param>
		/// <returns>A 32-bit signed integer that indicates the lexical relationship between <paramref name="strA" /> and <paramref name="strB" />, as shown in the following table  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///  <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///  <paramref name="strA" /> occurs in the same position as <paramref name="strB" /> in the sort order.  
		///
		///   Greater than zero  
		///
		///  <paramref name="strA" /> follows <paramref name="strB" /> in the sort order.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="options" /> is not a <see cref="T:System.Globalization.CompareOptions" /> value.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		// Token: 0x06000500 RID: 1280 RVA: 0x00012227 File Offset: 0x00010427
		[__DynamicallyInvokable]
		public static int Compare(string strA, string strB, CultureInfo culture, CompareOptions options)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			return culture.CompareInfo.Compare(strA, strB, options);
		}

		/// <summary>Compares two specified <see cref="T:System.String" /> objects, ignoring or honoring their case, and using culture-specific information to influence the comparison, and returns an integer that indicates their relative position in the sort order.</summary>
		/// <param name="strA">The first string to compare.</param>
		/// <param name="strB">The second string to compare.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
		/// <param name="culture">An object that supplies culture-specific comparison information.</param>
		/// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///  <paramref name="strA" /> precedes <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///  <paramref name="strA" /> occurs in the same position as <paramref name="strB" /> in the sort order.  
		///
		///   Greater than zero  
		///
		///  <paramref name="strA" /> follows <paramref name="strB" /> in the sort order.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		// Token: 0x06000501 RID: 1281 RVA: 0x00012245 File Offset: 0x00010445
		public static int Compare(string strA, string strB, bool ignoreCase, CultureInfo culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			if (ignoreCase)
			{
				return culture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
			}
			return culture.CompareInfo.Compare(strA, strB, CompareOptions.None);
		}

		/// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects and returns an integer that indicates their relative position in the sort order.</summary>
		/// <param name="strA">The first string to use in the comparison.</param>
		/// <param name="indexA">The position of the substring within <paramref name="strA" />.</param>
		/// <param name="strB">The second string to use in the comparison.</param>
		/// <param name="indexB">The position of the substring within <paramref name="strB" />.</param>
		/// <param name="length">The maximum number of characters in the substrings to compare.</param>
		/// <returns>A 32-bit signed integer indicating the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///   The substring in <paramref name="strA" /> precedes the substring in <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///   The substrings occur in the same position in the sort order, or <paramref name="length" /> is zero.  
		///
		///   Greater than zero  
		///
		///   The substring in <paramref name="strA" /> follows the substring in <paramref name="strB" /> in the sort order.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative.  
		/// -or-  
		/// Either <paramref name="indexA" /> or <paramref name="indexB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>
		// Token: 0x06000502 RID: 1282 RVA: 0x00012278 File Offset: 0x00010478
		[__DynamicallyInvokable]
		public static int Compare(string strA, int indexA, string strB, int indexB, int length)
		{
			int num = length;
			int num2 = length;
			if (strA != null && strA.Length - indexA < num)
			{
				num = strA.Length - indexA;
			}
			if (strB != null && strB.Length - indexB < num2)
			{
				num2 = strB.Length - indexB;
			}
			return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, CompareOptions.None);
		}

		/// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects, ignoring or honoring their case, and returns an integer that indicates their relative position in the sort order.</summary>
		/// <param name="strA">The first string to use in the comparison.</param>
		/// <param name="indexA">The position of the substring within <paramref name="strA" />.</param>
		/// <param name="strB">The second string to use in the comparison.</param>
		/// <param name="indexB">The position of the substring within <paramref name="strB" />.</param>
		/// <param name="length">The maximum number of characters in the substrings to compare.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
		/// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///   The substring in <paramref name="strA" /> precedes the substring in <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///   The substrings occur in the same position in the sort order, or <paramref name="length" /> is zero.  
		///
		///   Greater than zero  
		///
		///   The substring in <paramref name="strA" /> follows the substring in <paramref name="strB" /> in the sort order.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative.  
		/// -or-  
		/// Either <paramref name="indexA" /> or <paramref name="indexB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>
		// Token: 0x06000503 RID: 1283 RVA: 0x000122D0 File Offset: 0x000104D0
		public static int Compare(string strA, int indexA, string strB, int indexB, int length, bool ignoreCase)
		{
			int num = length;
			int num2 = length;
			if (strA != null && strA.Length - indexA < num)
			{
				num = strA.Length - indexA;
			}
			if (strB != null && strB.Length - indexB < num2)
			{
				num2 = strB.Length - indexB;
			}
			if (ignoreCase)
			{
				return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, CompareOptions.IgnoreCase);
			}
			return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, CompareOptions.None);
		}

		/// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects, ignoring or honoring their case and using culture-specific information to influence the comparison, and returns an integer that indicates their relative position in the sort order.</summary>
		/// <param name="strA">The first string to use in the comparison.</param>
		/// <param name="indexA">The position of the substring within <paramref name="strA" />.</param>
		/// <param name="strB">The second string to use in the comparison.</param>
		/// <param name="indexB">The position of the substring within <paramref name="strB" />.</param>
		/// <param name="length">The maximum number of characters in the substrings to compare.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
		/// <param name="culture">An object that supplies culture-specific comparison information.</param>
		/// <returns>An integer that indicates the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///   The substring in <paramref name="strA" /> precedes the substring in <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///   The substrings occur in the same position in the sort order, or <paramref name="length" /> is zero.  
		///
		///   Greater than zero  
		///
		///   The substring in <paramref name="strA" /> follows the substring in <paramref name="strB" /> in the sort order.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative.  
		/// -or-  
		/// Either <paramref name="strA" /> or <paramref name="strB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		// Token: 0x06000504 RID: 1284 RVA: 0x00012344 File Offset: 0x00010544
		public static int Compare(string strA, int indexA, string strB, int indexB, int length, bool ignoreCase, CultureInfo culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			int num = length;
			int num2 = length;
			if (strA != null && strA.Length - indexA < num)
			{
				num = strA.Length - indexA;
			}
			if (strB != null && strB.Length - indexB < num2)
			{
				num2 = strB.Length - indexB;
			}
			if (ignoreCase)
			{
				return culture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, CompareOptions.IgnoreCase);
			}
			return culture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, CompareOptions.None);
		}

		/// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects using the specified comparison options and culture-specific information to influence the comparison, and returns an integer that indicates the relationship of the two substrings to each other in the sort order.</summary>
		/// <param name="strA">The first string to use in the comparison.</param>
		/// <param name="indexA">The starting position of the substring within <paramref name="strA" />.</param>
		/// <param name="strB">The second string to use in the comparison.</param>
		/// <param name="indexB">The starting position of the substring within <paramref name="strB" />.</param>
		/// <param name="length">The maximum number of characters in the substrings to compare.</param>
		/// <param name="culture">An object that supplies culture-specific comparison information.</param>
		/// <param name="options">Options to use when performing the comparison (such as ignoring case or symbols).</param>
		/// <returns>An integer that indicates the lexical relationship between the two substrings, as shown in the following table.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///   The substring in <paramref name="strA" /> precedes the substring in <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///   The substrings occur in the same position in the sort order, or <paramref name="length" /> is zero.  
		///
		///   Greater than zero  
		///
		///   The substring in <paramref name="strA" /> follows the substring in <paramref name="strB" /> in the sort order.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="options" /> is not a <see cref="T:System.Globalization.CompareOptions" /> value.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="indexA" /> is greater than <paramref name="strA" /><see langword=".Length" />.  
		/// -or-  
		/// <paramref name="indexB" /> is greater than <paramref name="strB" /><see langword=".Length" />.  
		/// -or-  
		/// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative.  
		/// -or-  
		/// Either <paramref name="strA" /> or <paramref name="strB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		// Token: 0x06000505 RID: 1285 RVA: 0x000123C0 File Offset: 0x000105C0
		public static int Compare(string strA, int indexA, string strB, int indexB, int length, CultureInfo culture, CompareOptions options)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			int num = length;
			int num2 = length;
			if (strA != null && strA.Length - indexA < num)
			{
				num = strA.Length - indexA;
			}
			if (strB != null && strB.Length - indexB < num2)
			{
				num2 = strB.Length - indexB;
			}
			return culture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, options);
		}

		/// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects using the specified rules, and returns an integer that indicates their relative position in the sort order.</summary>
		/// <param name="strA">The first string to use in the comparison.</param>
		/// <param name="indexA">The position of the substring within <paramref name="strA" />.</param>
		/// <param name="strB">The second string to use in the comparison.</param>
		/// <param name="indexB">The position of the substring within <paramref name="strB" />.</param>
		/// <param name="length">The maximum number of characters in the substrings to compare.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison.</param>
		/// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///   The substring in <paramref name="strA" /> precedes the substring in <paramref name="strB" /> in the sort order.  
		///
		///   Zero  
		///
		///   The substrings occur in the same position in the sort order, or the <paramref name="length" /> parameter is zero.  
		///
		///   Greater than zero  
		///
		///   The substring in <paramref name="strA" /> follllows the substring in <paramref name="strB" /> in the sort order.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative.  
		/// -or-  
		/// Either <paramref name="indexA" /> or <paramref name="indexB" /> is <see langword="null" />, and <paramref name="length" /> is greater than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x06000506 RID: 1286 RVA: 0x00012424 File Offset: 0x00010624
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static int Compare(string strA, int indexA, string strB, int indexB, int length, StringComparison comparisonType)
		{
			if (comparisonType < StringComparison.CurrentCulture || comparisonType > StringComparison.OrdinalIgnoreCase)
			{
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
			if (strA == null || strB == null)
			{
				if (strA == strB)
				{
					return 0;
				}
				if (strA != null)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				if (length < 0)
				{
					throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
				}
				if (indexA < 0)
				{
					throw new ArgumentOutOfRangeException("indexA", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				if (indexB < 0)
				{
					throw new ArgumentOutOfRangeException("indexB", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				if (strA.Length - indexA < 0)
				{
					throw new ArgumentOutOfRangeException("indexA", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				if (strB.Length - indexB < 0)
				{
					throw new ArgumentOutOfRangeException("indexB", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				if (length == 0 || (strA == strB && indexA == indexB))
				{
					return 0;
				}
				int num = length;
				int num2 = length;
				if (strA != null && strA.Length - indexA < num)
				{
					num = strA.Length - indexA;
				}
				if (strB != null && strB.Length - indexB < num2)
				{
					num2 = strB.Length - indexB;
				}
				switch (comparisonType)
				{
				case StringComparison.CurrentCulture:
					return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, CompareOptions.None);
				case StringComparison.CurrentCultureIgnoreCase:
					return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, CompareOptions.IgnoreCase);
				case StringComparison.InvariantCulture:
					return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, CompareOptions.None);
				case StringComparison.InvariantCultureIgnoreCase:
					return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, CompareOptions.IgnoreCase);
				case StringComparison.Ordinal:
					return string.nativeCompareOrdinalEx(strA, indexA, strB, indexB, length);
				case StringComparison.OrdinalIgnoreCase:
					return TextInfo.CompareOrdinalIgnoreCaseEx(strA, indexA, strB, indexB, num, num2);
				default:
					throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"));
				}
			}
		}

		/// <summary>Compares this instance with a specified <see cref="T:System.Object" /> and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified <see cref="T:System.Object" />.</summary>
		/// <param name="value">An object that evaluates to a <see cref="T:System.String" />.</param>
		/// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="value" /> parameter.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///   This instance precedes <paramref name="value" />.  
		///
		///   Zero  
		///
		///   This instance has the same position in the sort order as <paramref name="value" />.  
		///
		///   Greater than zero  
		///
		///   This instance follows <paramref name="value" />.  
		///
		///  -or-  
		///
		///  <paramref name="value" /> is <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="value" /> is not a <see cref="T:System.String" />.</exception>
		// Token: 0x06000507 RID: 1287 RVA: 0x000125DA File Offset: 0x000107DA
		public int CompareTo(object value)
		{
			if (value == null)
			{
				return 1;
			}
			if (!(value is string))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeString"));
			}
			return string.Compare(this, (string)value, StringComparison.CurrentCulture);
		}

		/// <summary>Compares this instance with a specified <see cref="T:System.String" /> object and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified string.</summary>
		/// <param name="strB">The string to compare with this instance.</param>
		/// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="strB" /> parameter.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///   This instance precedes <paramref name="strB" />.  
		///
		///   Zero  
		///
		///   This instance has the same position in the sort order as <paramref name="strB" />.  
		///
		///   Greater than zero  
		///
		///   This instance follows <paramref name="strB" />.  
		///
		///  -or-  
		///
		///  <paramref name="strB" /> is <see langword="null" />.</returns>
		// Token: 0x06000508 RID: 1288 RVA: 0x00012606 File Offset: 0x00010806
		[__DynamicallyInvokable]
		public int CompareTo(string strB)
		{
			if (strB == null)
			{
				return 1;
			}
			return CultureInfo.CurrentCulture.CompareInfo.Compare(this, strB, CompareOptions.None);
		}

		/// <summary>Compares two specified <see cref="T:System.String" /> objects by evaluating the numeric values of the corresponding <see cref="T:System.Char" /> objects in each string.</summary>
		/// <param name="strA">The first string to compare.</param>
		/// <param name="strB">The second string to compare.</param>
		/// <returns>An integer that indicates the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///  <paramref name="strA" /> is less than <paramref name="strB" />.  
		///
		///   Zero  
		///
		///  <paramref name="strA" /> and <paramref name="strB" /> are equal.  
		///
		///   Greater than zero  
		///
		///  <paramref name="strA" /> is greater than <paramref name="strB" />.</returns>
		// Token: 0x06000509 RID: 1289 RVA: 0x0001261F File Offset: 0x0001081F
		[__DynamicallyInvokable]
		public static int CompareOrdinal(string strA, string strB)
		{
			if (strA == strB)
			{
				return 0;
			}
			if (strA == null)
			{
				return -1;
			}
			if (strB == null)
			{
				return 1;
			}
			if (strA.m_firstChar - strB.m_firstChar != '\0')
			{
				return (int)(strA.m_firstChar - strB.m_firstChar);
			}
			return string.CompareOrdinalHelper(strA, strB);
		}

		/// <summary>Compares substrings of two specified <see cref="T:System.String" /> objects by evaluating the numeric values of the corresponding <see cref="T:System.Char" /> objects in each substring.</summary>
		/// <param name="strA">The first string to use in the comparison.</param>
		/// <param name="indexA">The starting index of the substring in <paramref name="strA" />.</param>
		/// <param name="strB">The second string to use in the comparison.</param>
		/// <param name="indexB">The starting index of the substring in <paramref name="strB" />.</param>
		/// <param name="length">The maximum number of characters in the substrings to compare.</param>
		/// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.  
		///   Value  
		///
		///   Condition  
		///
		///   Less than zero  
		///
		///   The substring in <paramref name="strA" /> is less than the substring in <paramref name="strB" />.  
		///
		///   Zero  
		///
		///   The substrings are equal, or <paramref name="length" /> is zero.  
		///
		///   Greater than zero  
		///
		///   The substring in <paramref name="strA" /> is greater than the substring in <paramref name="strB" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="strA" /> is not <see langword="null" /> and <paramref name="indexA" /> is greater than <paramref name="strA" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="strB" /> is not <see langword="null" /> and <paramref name="indexB" /> is greater than <paramref name="strB" />.<see cref="P:System.String.Length" />.  
		/// -or-  
		/// <paramref name="indexA" />, <paramref name="indexB" />, or <paramref name="length" /> is negative.</exception>
		// Token: 0x0600050A RID: 1290 RVA: 0x00012655 File Offset: 0x00010855
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static int CompareOrdinal(string strA, int indexA, string strB, int indexB, int length)
		{
			if (strA != null && strB != null)
			{
				return string.nativeCompareOrdinalEx(strA, indexA, strB, indexB, length);
			}
			if (strA == strB)
			{
				return 0;
			}
			if (strA != null)
			{
				return 1;
			}
			return -1;
		}

		/// <summary>Returns a value indicating whether a specified substring occurs within this string.</summary>
		/// <param name="value">The string to seek.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="value" /> parameter occurs within this string, or if <paramref name="value" /> is the empty string (""); otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x0600050B RID: 1291 RVA: 0x00012675 File Offset: 0x00010875
		[__DynamicallyInvokable]
		public bool Contains(string value)
		{
			return this.IndexOf(value, StringComparison.Ordinal) >= 0;
		}

		/// <summary>Determines whether the end of this string instance matches the specified string.</summary>
		/// <param name="value">The string to compare to the substring at the end of this instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="value" /> matches the end of this instance; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x0600050C RID: 1292 RVA: 0x00012685 File Offset: 0x00010885
		[__DynamicallyInvokable]
		public bool EndsWith(string value)
		{
			return this.EndsWith(value, StringComparison.CurrentCulture);
		}

		/// <summary>Determines whether the end of this string instance matches the specified string when compared using the specified comparison option.</summary>
		/// <param name="value">The string to compare to the substring at the end of this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that determines how this string and <paramref name="value" /> are compared.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="value" /> parameter matches the end of this string; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x0600050D RID: 1293 RVA: 0x00012690 File Offset: 0x00010890
		[SecuritySafeCritical]
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public bool EndsWith(string value, StringComparison comparisonType)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (comparisonType < StringComparison.CurrentCulture || comparisonType > StringComparison.OrdinalIgnoreCase)
			{
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
			if (this == value)
			{
				return true;
			}
			if (value.Length == 0)
			{
				return true;
			}
			switch (comparisonType)
			{
			case StringComparison.CurrentCulture:
				return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(this, value, CompareOptions.None);
			case StringComparison.CurrentCultureIgnoreCase:
				return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(this, value, CompareOptions.IgnoreCase);
			case StringComparison.InvariantCulture:
				return CultureInfo.InvariantCulture.CompareInfo.IsSuffix(this, value, CompareOptions.None);
			case StringComparison.InvariantCultureIgnoreCase:
				return CultureInfo.InvariantCulture.CompareInfo.IsSuffix(this, value, CompareOptions.IgnoreCase);
			case StringComparison.Ordinal:
				return this.Length >= value.Length && string.nativeCompareOrdinalEx(this, this.Length - value.Length, value, 0, value.Length) == 0;
			case StringComparison.OrdinalIgnoreCase:
				return this.Length >= value.Length && TextInfo.CompareOrdinalIgnoreCaseEx(this, this.Length - value.Length, value, 0, value.Length, value.Length) == 0;
			default:
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
		}

		/// <summary>Determines whether the end of this string instance matches the specified string when compared using the specified culture.</summary>
		/// <param name="value">The string to compare to the substring at the end of this instance.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
		/// <param name="culture">Cultural information that determines how this instance and <paramref name="value" /> are compared. If <paramref name="culture" /> is <see langword="null" />, the current culture is used.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="value" /> parameter matches the end of this string; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x0600050E RID: 1294 RVA: 0x000127C0 File Offset: 0x000109C0
		public bool EndsWith(string value, bool ignoreCase, CultureInfo culture)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this == value)
			{
				return true;
			}
			CultureInfo cultureInfo;
			if (culture == null)
			{
				cultureInfo = CultureInfo.CurrentCulture;
			}
			else
			{
				cultureInfo = culture;
			}
			return cultureInfo.CompareInfo.IsSuffix(this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00012804 File Offset: 0x00010A04
		internal bool EndsWith(char value)
		{
			int length = this.Length;
			return length != 0 && this[length - 1] == value;
		}

		/// <summary>Reports the zero-based index of the first occurrence of the specified Unicode character in this string.</summary>
		/// <param name="value">A Unicode character to seek.</param>
		/// <returns>The zero-based index position of <paramref name="value" /> if that character is found, or -1 if it is not.</returns>
		// Token: 0x06000510 RID: 1296 RVA: 0x0001282A File Offset: 0x00010A2A
		[__DynamicallyInvokable]
		public int IndexOf(char value)
		{
			return this.IndexOf(value, 0, this.Length);
		}

		/// <summary>Reports the zero-based index of the first occurrence of the specified Unicode character in this string. The search starts at a specified character position.</summary>
		/// <param name="value">A Unicode character to seek.</param>
		/// <param name="startIndex">The search starting position.</param>
		/// <returns>The zero-based index position of <paramref name="value" /> from the start of the string if that character is found, or -1 if it is not.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> is less than 0 (zero) or greater than the length of the string.</exception>
		// Token: 0x06000511 RID: 1297 RVA: 0x0001283A File Offset: 0x00010A3A
		[__DynamicallyInvokable]
		public int IndexOf(char value, int startIndex)
		{
			return this.IndexOf(value, startIndex, this.Length - startIndex);
		}

		/// <summary>Reports the zero-based index of the first occurrence of the specified character in this instance. The search starts at a specified character position and examines a specified number of character positions.</summary>
		/// <param name="value">A Unicode character to seek.</param>
		/// <param name="startIndex">The search starting position.</param>
		/// <param name="count">The number of character positions to examine.</param>
		/// <returns>The zero-based index position of <paramref name="value" /> from the start of the string if that character is found, or -1 if it is not.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> or <paramref name="startIndex" /> is negative.  
		/// -or-  
		/// <paramref name="startIndex" /> is greater than the length of this string.  
		/// -or-  
		/// <paramref name="count" /> is greater than the length of this string minus <paramref name="startIndex" />.</exception>
		// Token: 0x06000512 RID: 1298
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int IndexOf(char value, int startIndex, int count);

		/// <summary>Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters.</summary>
		/// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
		/// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="anyOf" /> is <see langword="null" />.</exception>
		// Token: 0x06000513 RID: 1299 RVA: 0x0001284C File Offset: 0x00010A4C
		[__DynamicallyInvokable]
		public int IndexOfAny(char[] anyOf)
		{
			return this.IndexOfAny(anyOf, 0, this.Length);
		}

		/// <summary>Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position.</summary>
		/// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
		/// <param name="startIndex">The search starting position.</param>
		/// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="anyOf" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> is negative.  
		/// -or-  
		/// <paramref name="startIndex" /> is greater than the number of characters in this instance.</exception>
		// Token: 0x06000514 RID: 1300 RVA: 0x0001285C File Offset: 0x00010A5C
		[__DynamicallyInvokable]
		public int IndexOfAny(char[] anyOf, int startIndex)
		{
			return this.IndexOfAny(anyOf, startIndex, this.Length - startIndex);
		}

		/// <summary>Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position and examines a specified number of character positions.</summary>
		/// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
		/// <param name="startIndex">The search starting position.</param>
		/// <param name="count">The number of character positions to examine.</param>
		/// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="anyOf" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> or <paramref name="startIndex" /> is negative.  
		/// -or-  
		/// <paramref name="count" /> + <paramref name="startIndex" /> is greater than the number of characters in this instance.</exception>
		// Token: 0x06000515 RID: 1301
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int IndexOfAny(char[] anyOf, int startIndex, int count);

		/// <summary>Reports the zero-based index of the first occurrence of the specified string in this instance.</summary>
		/// <param name="value">The string to seek.</param>
		/// <returns>The zero-based index position of <paramref name="value" /> if that string is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is 0.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x06000516 RID: 1302 RVA: 0x0001286E File Offset: 0x00010A6E
		[__DynamicallyInvokable]
		public int IndexOf(string value)
		{
			return this.IndexOf(value, StringComparison.CurrentCulture);
		}

		/// <summary>Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="startIndex">The search starting position.</param>
		/// <returns>The zero-based index position of <paramref name="value" /> from the start of the current instance if that string is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is <paramref name="startIndex" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> is less than 0 (zero) or greater than the length of this string.</exception>
		// Token: 0x06000517 RID: 1303 RVA: 0x00012878 File Offset: 0x00010A78
		[__DynamicallyInvokable]
		public int IndexOf(string value, int startIndex)
		{
			return this.IndexOf(value, startIndex, StringComparison.CurrentCulture);
		}

		/// <summary>Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position and examines a specified number of character positions.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="startIndex">The search starting position.</param>
		/// <param name="count">The number of character positions to examine.</param>
		/// <returns>The zero-based index position of <paramref name="value" /> from the start of the current instance if that string is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is <paramref name="startIndex" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> or <paramref name="startIndex" /> is negative.  
		/// -or-  
		/// <paramref name="startIndex" /> is greater than the length of this string.  
		/// -or-  
		/// <paramref name="count" /> is greater than the length of this string minus <paramref name="startIndex" />.</exception>
		// Token: 0x06000518 RID: 1304 RVA: 0x00012884 File Offset: 0x00010A84
		[__DynamicallyInvokable]
		public int IndexOf(string value, int startIndex, int count)
		{
			if (startIndex < 0 || startIndex > this.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (count < 0 || count > this.Length - startIndex)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_Count"));
			}
			return this.IndexOf(value, startIndex, count, StringComparison.CurrentCulture);
		}

		/// <summary>Reports the zero-based index of the first occurrence of the specified string in the current <see cref="T:System.String" /> object. A parameter specifies the type of search to use for the specified string.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
		/// <returns>The index position of the <paramref name="value" /> parameter if that string is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is 0.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x06000519 RID: 1305 RVA: 0x000128E1 File Offset: 0x00010AE1
		[__DynamicallyInvokable]
		public int IndexOf(string value, StringComparison comparisonType)
		{
			return this.IndexOf(value, 0, this.Length, comparisonType);
		}

		/// <summary>Reports the zero-based index of the first occurrence of the specified string in the current <see cref="T:System.String" /> object. Parameters specify the starting search position in the current string and the type of search to use for the specified string.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="startIndex">The search starting position.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
		/// <returns>The zero-based index position of the <paramref name="value" /> parameter from the start of the current instance if that string is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is <paramref name="startIndex" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> is less than 0 (zero) or greater than the length of this string.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x0600051A RID: 1306 RVA: 0x000128F2 File Offset: 0x00010AF2
		[__DynamicallyInvokable]
		public int IndexOf(string value, int startIndex, StringComparison comparisonType)
		{
			return this.IndexOf(value, startIndex, this.Length - startIndex, comparisonType);
		}

		/// <summary>Reports the zero-based index of the first occurrence of the specified string in the current <see cref="T:System.String" /> object. Parameters specify the starting search position in the current string, the number of characters in the current string to search, and the type of search to use for the specified string.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="startIndex">The search starting position.</param>
		/// <param name="count">The number of character positions to examine.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
		/// <returns>The zero-based index position of the <paramref name="value" /> parameter from the start of the current instance if that string is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is <paramref name="startIndex" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> or <paramref name="startIndex" /> is negative.  
		/// -or-  
		/// <paramref name="startIndex" /> is greater than the length of this instance.  
		/// -or-  
		/// <paramref name="count" /> is greater than the length of this string minus <paramref name="startIndex" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x0600051B RID: 1307 RVA: 0x00012908 File Offset: 0x00010B08
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (startIndex < 0 || startIndex > this.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (count < 0 || startIndex > this.Length - count)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_Count"));
			}
			switch (comparisonType)
			{
			case StringComparison.CurrentCulture:
				return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.None);
			case StringComparison.CurrentCultureIgnoreCase:
				return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
			case StringComparison.InvariantCulture:
				return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.None);
			case StringComparison.InvariantCultureIgnoreCase:
				return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
			case StringComparison.Ordinal:
				return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.Ordinal);
			case StringComparison.OrdinalIgnoreCase:
				if (value.IsAscii() && this.IsAscii())
				{
					return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
				}
				return TextInfo.IndexOfStringOrdinalIgnoreCase(this, value, startIndex, count);
			default:
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
		}

		/// <summary>Reports the zero-based index position of the last occurrence of a specified Unicode character within this instance.</summary>
		/// <param name="value">The Unicode character to seek.</param>
		/// <returns>The zero-based index position of <paramref name="value" /> if that character is found, or -1 if it is not.</returns>
		// Token: 0x0600051C RID: 1308 RVA: 0x00012A3D File Offset: 0x00010C3D
		[__DynamicallyInvokable]
		public int LastIndexOf(char value)
		{
			return this.LastIndexOf(value, this.Length - 1, this.Length);
		}

		/// <summary>Reports the zero-based index position of the last occurrence of a specified Unicode character within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string.</summary>
		/// <param name="value">The Unicode character to seek.</param>
		/// <param name="startIndex">The starting position of the search. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
		/// <returns>The zero-based index position of <paramref name="value" /> if that character is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than zero or greater than or equal to the length of this instance.</exception>
		// Token: 0x0600051D RID: 1309 RVA: 0x00012A54 File Offset: 0x00010C54
		[__DynamicallyInvokable]
		public int LastIndexOf(char value, int startIndex)
		{
			return this.LastIndexOf(value, startIndex, startIndex + 1);
		}

		/// <summary>Reports the zero-based index position of the last occurrence of the specified Unicode character in a substring within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.</summary>
		/// <param name="value">The Unicode character to seek.</param>
		/// <param name="startIndex">The starting position of the search. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
		/// <param name="count">The number of character positions to examine.</param>
		/// <returns>The zero-based index position of <paramref name="value" /> if that character is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than zero or greater than or equal to the length of this instance.  
		///  -or-  
		///  The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> - <paramref name="count" /> + 1 is less than zero.</exception>
		// Token: 0x0600051E RID: 1310
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int LastIndexOf(char value, int startIndex, int count);

		/// <summary>Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array.</summary>
		/// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
		/// <returns>The index position of the last occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="anyOf" /> is <see langword="null" />.</exception>
		// Token: 0x0600051F RID: 1311 RVA: 0x00012A61 File Offset: 0x00010C61
		[__DynamicallyInvokable]
		public int LastIndexOfAny(char[] anyOf)
		{
			return this.LastIndexOfAny(anyOf, this.Length - 1, this.Length);
		}

		/// <summary>Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the string.</summary>
		/// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
		/// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
		/// <returns>The index position of the last occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found or if the current instance equals <see cref="F:System.String.Empty" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="anyOf" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> specifies a position that is not within this instance.</exception>
		// Token: 0x06000520 RID: 1312 RVA: 0x00012A78 File Offset: 0x00010C78
		[__DynamicallyInvokable]
		public int LastIndexOfAny(char[] anyOf, int startIndex)
		{
			return this.LastIndexOfAny(anyOf, startIndex, startIndex + 1);
		}

		/// <summary>Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.</summary>
		/// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
		/// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
		/// <param name="count">The number of character positions to examine.</param>
		/// <returns>The index position of the last occurrence in this instance where any character in <paramref name="anyOf" /> was found; -1 if no character in <paramref name="anyOf" /> was found or if the current instance equals <see cref="F:System.String.Empty" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="anyOf" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="count" /> or <paramref name="startIndex" /> is negative.  
		///  -or-  
		///  The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> minus <paramref name="count" /> + 1 is less than zero.</exception>
		// Token: 0x06000521 RID: 1313
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int LastIndexOfAny(char[] anyOf, int startIndex, int count);

		/// <summary>Reports the zero-based index position of the last occurrence of a specified string within this instance.</summary>
		/// <param name="value">The string to seek.</param>
		/// <returns>The zero-based starting index position of <paramref name="value" /> if that string is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the last index position in this instance.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x06000522 RID: 1314 RVA: 0x00012A85 File Offset: 0x00010C85
		[__DynamicallyInvokable]
		public int LastIndexOf(string value)
		{
			return this.LastIndexOf(value, this.Length - 1, this.Length, StringComparison.CurrentCulture);
		}

		/// <summary>Reports the zero-based index position of the last occurrence of a specified string within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
		/// <returns>The zero-based starting index position of <paramref name="value" /> if that string is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the smaller of <paramref name="startIndex" /> and the last index position in this instance.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than zero or greater than the length of the current instance.  
		///  -or-  
		///  The current instance equals <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than -1 or greater than zero.</exception>
		// Token: 0x06000523 RID: 1315 RVA: 0x00012A9D File Offset: 0x00010C9D
		[__DynamicallyInvokable]
		public int LastIndexOf(string value, int startIndex)
		{
			return this.LastIndexOf(value, startIndex, startIndex + 1, StringComparison.CurrentCulture);
		}

		/// <summary>Reports the zero-based index position of the last occurrence of a specified string within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
		/// <param name="count">The number of character positions to examine.</param>
		/// <returns>The zero-based starting index position of <paramref name="value" /> if that string is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the smaller of <paramref name="startIndex" /> and the last index position in this instance.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is negative.  
		/// -or-  
		/// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is negative.  
		/// -or-  
		/// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is greater than the length of this instance.  
		/// -or-  
		/// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> - <paramref name="count" />+ 1 specifies a position that is not within this instance.  
		/// -or-  
		/// The current instance equals <see cref="F:System.String.Empty" /> and <paramref name="start" /> is less than -1 or greater than zero.  
		/// -or-  
		/// The current instance equals <see cref="F:System.String.Empty" /> and <paramref name="count" /> is greater than 1.</exception>
		// Token: 0x06000524 RID: 1316 RVA: 0x00012AAB File Offset: 0x00010CAB
		[__DynamicallyInvokable]
		public int LastIndexOf(string value, int startIndex, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_Count"));
			}
			return this.LastIndexOf(value, startIndex, count, StringComparison.CurrentCulture);
		}

		/// <summary>Reports the zero-based index of the last occurrence of a specified string within the current <see cref="T:System.String" /> object. A parameter specifies the type of search to use for the specified string.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
		/// <returns>The zero-based starting index position of the <paramref name="value" /> parameter if that string is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the last index position in this instance.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x06000525 RID: 1317 RVA: 0x00012AD0 File Offset: 0x00010CD0
		[__DynamicallyInvokable]
		public int LastIndexOf(string value, StringComparison comparisonType)
		{
			return this.LastIndexOf(value, this.Length - 1, this.Length, comparisonType);
		}

		/// <summary>Reports the zero-based index of the last occurrence of a specified string within the current <see cref="T:System.String" /> object. The search starts at a specified character position and proceeds backward toward the beginning of the string. A parameter specifies the type of comparison to perform when searching for the specified string.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
		/// <returns>The zero-based starting index position of the <paramref name="value" /> parameter if that string is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the smaller of <paramref name="startIndex" /> and the last index position in this instance.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than zero or greater than the length of the current instance.  
		///  -or-  
		///  The current instance equals <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is less than -1 or greater than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x06000526 RID: 1318 RVA: 0x00012AE8 File Offset: 0x00010CE8
		[__DynamicallyInvokable]
		public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
		{
			return this.LastIndexOf(value, startIndex, startIndex + 1, comparisonType);
		}

		/// <summary>Reports the zero-based index position of the last occurrence of a specified string within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string for the specified number of character positions. A parameter specifies the type of comparison to perform when searching for the specified string.</summary>
		/// <param name="value">The string to seek.</param>
		/// <param name="startIndex">The search starting position. The search proceeds from <paramref name="startIndex" /> toward the beginning of this instance.</param>
		/// <param name="count">The number of character positions to examine.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
		/// <returns>The zero-based starting index position of the <paramref name="value" /> parameter if that string is found, or -1 if it is not found or if the current instance equals <see cref="F:System.String.Empty" />. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is the smaller of <paramref name="startIndex" /> and the last index position in this instance.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is negative.  
		/// -or-  
		/// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is negative.  
		/// -or-  
		/// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> is greater than the length of this instance.  
		/// -or-  
		/// The current instance does not equal <see cref="F:System.String.Empty" />, and <paramref name="startIndex" /> + 1 - <paramref name="count" /> specifies a position that is not within this instance.  
		/// -or-  
		/// The current instance equals <see cref="F:System.String.Empty" /> and <paramref name="start" /> is less than -1 or greater than zero.  
		/// -or-  
		/// The current instance equals <see cref="F:System.String.Empty" /> and <paramref name="count" /> is greater than 1.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a valid <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x06000527 RID: 1319 RVA: 0x00012AF8 File Offset: 0x00010CF8
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this.Length == 0 && (startIndex == -1 || startIndex == 0))
			{
				if (value.Length != 0)
				{
					return -1;
				}
				return 0;
			}
			else
			{
				if (startIndex < 0 || startIndex > this.Length)
				{
					throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				if (startIndex == this.Length)
				{
					startIndex--;
					if (count > 0)
					{
						count--;
					}
					if (value.Length == 0 && count >= 0 && startIndex - count + 1 >= 0)
					{
						return startIndex;
					}
				}
				if (count < 0 || startIndex - count + 1 < 0)
				{
					throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_Count"));
				}
				switch (comparisonType)
				{
				case StringComparison.CurrentCulture:
					return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.None);
				case StringComparison.CurrentCultureIgnoreCase:
					return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
				case StringComparison.InvariantCulture:
					return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.None);
				case StringComparison.InvariantCultureIgnoreCase:
					return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
				case StringComparison.Ordinal:
					return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.Ordinal);
				case StringComparison.OrdinalIgnoreCase:
					if (value.IsAscii() && this.IsAscii())
					{
						return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
					}
					return TextInfo.LastIndexOfStringOrdinalIgnoreCase(this, value, startIndex, count);
				default:
					throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
				}
			}
		}

		/// <summary>Returns a new string that right-aligns the characters in this instance by padding them with spaces on the left, for a specified total length.</summary>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but right-aligned and padded on the left with as many spaces as needed to create a length of <paramref name="totalWidth" />. However, if <paramref name="totalWidth" /> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth" /> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="totalWidth" /> is less than zero.</exception>
		// Token: 0x06000528 RID: 1320 RVA: 0x00012C72 File Offset: 0x00010E72
		[__DynamicallyInvokable]
		public string PadLeft(int totalWidth)
		{
			return this.PadHelper(totalWidth, ' ', false);
		}

		/// <summary>Returns a new string that right-aligns the characters in this instance by padding them on the left with a specified Unicode character, for a specified total length.</summary>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but right-aligned and padded on the left with as many <paramref name="paddingChar" /> characters as needed to create a length of <paramref name="totalWidth" />. However, if <paramref name="totalWidth" /> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth" /> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="totalWidth" /> is less than zero.</exception>
		// Token: 0x06000529 RID: 1321 RVA: 0x00012C7E File Offset: 0x00010E7E
		[__DynamicallyInvokable]
		public string PadLeft(int totalWidth, char paddingChar)
		{
			return this.PadHelper(totalWidth, paddingChar, false);
		}

		/// <summary>Returns a new string that left-aligns the characters in this string by padding them with spaces on the right, for a specified total length.</summary>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of <paramref name="totalWidth" />. However, if <paramref name="totalWidth" /> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth" /> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="totalWidth" /> is less than zero.</exception>
		// Token: 0x0600052A RID: 1322 RVA: 0x00012C89 File Offset: 0x00010E89
		[__DynamicallyInvokable]
		public string PadRight(int totalWidth)
		{
			return this.PadHelper(totalWidth, ' ', true);
		}

		/// <summary>Returns a new string that left-aligns the characters in this string by padding them on the right with a specified Unicode character, for a specified total length.</summary>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar" /> characters as needed to create a length of <paramref name="totalWidth" />. However, if <paramref name="totalWidth" /> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth" /> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="totalWidth" /> is less than zero.</exception>
		// Token: 0x0600052B RID: 1323 RVA: 0x00012C95 File Offset: 0x00010E95
		[__DynamicallyInvokable]
		public string PadRight(int totalWidth, char paddingChar)
		{
			return this.PadHelper(totalWidth, paddingChar, true);
		}

		// Token: 0x0600052C RID: 1324
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string PadHelper(int totalWidth, char paddingChar, bool isRightPadded);

		/// <summary>Determines whether the beginning of this string instance matches the specified string.</summary>
		/// <param name="value">The string to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="value" /> matches the beginning of this string; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x0600052D RID: 1325 RVA: 0x00012CA0 File Offset: 0x00010EA0
		[__DynamicallyInvokable]
		public bool StartsWith(string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return this.StartsWith(value, StringComparison.CurrentCulture);
		}

		/// <summary>Determines whether the beginning of this string instance matches the specified string when compared using the specified comparison option.</summary>
		/// <param name="value">The string to compare.</param>
		/// <param name="comparisonType">One of the enumeration values that determines how this string and <paramref name="value" /> are compared.</param>
		/// <returns>
		///   <see langword="true" /> if this instance begins with <paramref name="value" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value.</exception>
		// Token: 0x0600052E RID: 1326 RVA: 0x00012CB8 File Offset: 0x00010EB8
		[SecuritySafeCritical]
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public bool StartsWith(string value, StringComparison comparisonType)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (comparisonType < StringComparison.CurrentCulture || comparisonType > StringComparison.OrdinalIgnoreCase)
			{
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
			if (this == value)
			{
				return true;
			}
			if (value.Length == 0)
			{
				return true;
			}
			switch (comparisonType)
			{
			case StringComparison.CurrentCulture:
				return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, value, CompareOptions.None);
			case StringComparison.CurrentCultureIgnoreCase:
				return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, value, CompareOptions.IgnoreCase);
			case StringComparison.InvariantCulture:
				return CultureInfo.InvariantCulture.CompareInfo.IsPrefix(this, value, CompareOptions.None);
			case StringComparison.InvariantCultureIgnoreCase:
				return CultureInfo.InvariantCulture.CompareInfo.IsPrefix(this, value, CompareOptions.IgnoreCase);
			case StringComparison.Ordinal:
				return this.Length >= value.Length && string.nativeCompareOrdinalEx(this, 0, value, 0, value.Length) == 0;
			case StringComparison.OrdinalIgnoreCase:
				return this.Length >= value.Length && TextInfo.CompareOrdinalIgnoreCaseEx(this, 0, value, 0, value.Length, value.Length) == 0;
			default:
				throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
			}
		}

		/// <summary>Determines whether the beginning of this string instance matches the specified string when compared using the specified culture.</summary>
		/// <param name="value">The string to compare.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore case during the comparison; otherwise, <see langword="false" />.</param>
		/// <param name="culture">Cultural information that determines how this string and <paramref name="value" /> are compared. If <paramref name="culture" /> is <see langword="null" />, the current culture is used.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="value" /> parameter matches the beginning of this string; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x0600052F RID: 1327 RVA: 0x00012DD0 File Offset: 0x00010FD0
		public bool StartsWith(string value, bool ignoreCase, CultureInfo culture)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this == value)
			{
				return true;
			}
			CultureInfo cultureInfo;
			if (culture == null)
			{
				cultureInfo = CultureInfo.CurrentCulture;
			}
			else
			{
				cultureInfo = culture;
			}
			return cultureInfo.CompareInfo.IsPrefix(this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
		}

		/// <summary>Returns a copy of this string converted to lowercase.</summary>
		/// <returns>A string in lowercase.</returns>
		// Token: 0x06000530 RID: 1328 RVA: 0x00012E12 File Offset: 0x00011012
		[__DynamicallyInvokable]
		public string ToLower()
		{
			return this.ToLower(CultureInfo.CurrentCulture);
		}

		/// <summary>Returns a copy of this string converted to lowercase, using the casing rules of the specified culture.</summary>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of the current string.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		// Token: 0x06000531 RID: 1329 RVA: 0x00012E1F File Offset: 0x0001101F
		public string ToLower(CultureInfo culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			return culture.TextInfo.ToLower(this);
		}

		/// <summary>Returns a copy of this <see cref="T:System.String" /> object converted to lowercase using the casing rules of the invariant culture.</summary>
		/// <returns>The lowercase equivalent of the current string.</returns>
		// Token: 0x06000532 RID: 1330 RVA: 0x00012E3B File Offset: 0x0001103B
		[__DynamicallyInvokable]
		public string ToLowerInvariant()
		{
			return this.ToLower(CultureInfo.InvariantCulture);
		}

		/// <summary>Returns a copy of this string converted to uppercase.</summary>
		/// <returns>The uppercase equivalent of the current string.</returns>
		// Token: 0x06000533 RID: 1331 RVA: 0x00012E48 File Offset: 0x00011048
		[__DynamicallyInvokable]
		public string ToUpper()
		{
			return this.ToUpper(CultureInfo.CurrentCulture);
		}

		/// <summary>Returns a copy of this string converted to uppercase, using the casing rules of the specified culture.</summary>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of the current string.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		// Token: 0x06000534 RID: 1332 RVA: 0x00012E55 File Offset: 0x00011055
		public string ToUpper(CultureInfo culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			return culture.TextInfo.ToUpper(this);
		}

		/// <summary>Returns a copy of this <see cref="T:System.String" /> object converted to uppercase using the casing rules of the invariant culture.</summary>
		/// <returns>The uppercase equivalent of the current string.</returns>
		// Token: 0x06000535 RID: 1333 RVA: 0x00012E71 File Offset: 0x00011071
		[__DynamicallyInvokable]
		public string ToUpperInvariant()
		{
			return this.ToUpper(CultureInfo.InvariantCulture);
		}

		/// <summary>Returns this instance of <see cref="T:System.String" />; no actual conversion is performed.</summary>
		/// <returns>The current string.</returns>
		// Token: 0x06000536 RID: 1334 RVA: 0x00012E7E File Offset: 0x0001107E
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return this;
		}

		/// <summary>Returns this instance of <see cref="T:System.String" />; no actual conversion is performed.</summary>
		/// <param name="provider">(Reserved) An object that supplies culture-specific formatting information.</param>
		/// <returns>The current string.</returns>
		// Token: 0x06000537 RID: 1335 RVA: 0x00012E81 File Offset: 0x00011081
		public string ToString(IFormatProvider provider)
		{
			return this;
		}

		/// <summary>Returns a reference to this instance of <see cref="T:System.String" />.</summary>
		/// <returns>This instance of <see cref="T:System.String" />.</returns>
		// Token: 0x06000538 RID: 1336 RVA: 0x00012E84 File Offset: 0x00011084
		public object Clone()
		{
			return this;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00012E87 File Offset: 0x00011087
		private static bool IsBOMWhitespace(char c)
		{
			return false;
		}

		/// <summary>Removes all leading and trailing white-space characters from the current <see cref="T:System.String" /> object.</summary>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		// Token: 0x0600053A RID: 1338 RVA: 0x00012E8A File Offset: 0x0001108A
		[__DynamicallyInvokable]
		public string Trim()
		{
			return this.TrimHelper(2);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00012E94 File Offset: 0x00011094
		[SecuritySafeCritical]
		private string TrimHelper(int trimType)
		{
			int num = this.Length - 1;
			int num2 = 0;
			if (trimType != 1)
			{
				num2 = 0;
				while (num2 < this.Length && (char.IsWhiteSpace(this[num2]) || string.IsBOMWhitespace(this[num2])))
				{
					num2++;
				}
			}
			if (trimType != 0)
			{
				num = this.Length - 1;
				while (num >= num2 && (char.IsWhiteSpace(this[num]) || string.IsBOMWhitespace(this[num2])))
				{
					num--;
				}
			}
			return this.CreateTrimmedString(num2, num);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00012F18 File Offset: 0x00011118
		[SecuritySafeCritical]
		private string TrimHelper(char[] trimChars, int trimType)
		{
			int i = this.Length - 1;
			int j = 0;
			if (trimType != 1)
			{
				for (j = 0; j < this.Length; j++)
				{
					char c = this[j];
					int num = 0;
					while (num < trimChars.Length && trimChars[num] != c)
					{
						num++;
					}
					if (num == trimChars.Length)
					{
						break;
					}
				}
			}
			if (trimType != 0)
			{
				for (i = this.Length - 1; i >= j; i--)
				{
					char c2 = this[i];
					int num2 = 0;
					while (num2 < trimChars.Length && trimChars[num2] != c2)
					{
						num2++;
					}
					if (num2 == trimChars.Length)
					{
						break;
					}
				}
			}
			return this.CreateTrimmedString(j, i);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00012FB4 File Offset: 0x000111B4
		[SecurityCritical]
		private string CreateTrimmedString(int start, int end)
		{
			int num = end - start + 1;
			if (num == this.Length)
			{
				return this;
			}
			if (num == 0)
			{
				return string.Empty;
			}
			return this.InternalSubString(start, num);
		}

		/// <summary>Returns a new string in which a specified string is inserted at a specified index position in this instance.</summary>
		/// <param name="startIndex">The zero-based index position of the insertion.</param>
		/// <param name="value">The string to insert.</param>
		/// <returns>A new string that is equivalent to this instance, but with <paramref name="value" /> inserted at position <paramref name="startIndex" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> is negative or greater than the length of this instance.</exception>
		// Token: 0x0600053E RID: 1342 RVA: 0x00012FE4 File Offset: 0x000111E4
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe string Insert(int startIndex, string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (startIndex < 0 || startIndex > this.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			int length = this.Length;
			int length2 = value.Length;
			int num = length + length2;
			if (num == 0)
			{
				return string.Empty;
			}
			string text = string.FastAllocateString(num);
			fixed (char* ptr = &this.m_firstChar)
			{
				fixed (char* ptr2 = &value.m_firstChar)
				{
					fixed (char* ptr3 = &text.m_firstChar)
					{
						string.wstrcpy(ptr3, ptr, startIndex);
						string.wstrcpy(ptr3 + startIndex, ptr2, length2);
						string.wstrcpy(ptr3 + startIndex + length2, ptr + startIndex, length - startIndex);
					}
				}
			}
			return text;
		}

		// Token: 0x0600053F RID: 1343
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string ReplaceInternal(char oldChar, char newChar);

		/// <summary>Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.</summary>
		/// <param name="oldChar">The Unicode character to be replaced.</param>
		/// <param name="newChar">The Unicode character to replace all occurrences of <paramref name="oldChar" />.</param>
		/// <returns>A string that is equivalent to this instance except that all instances of <paramref name="oldChar" /> are replaced with <paramref name="newChar" />. If <paramref name="oldChar" /> is not found in the current instance, the method returns the current instance unchanged.</returns>
		// Token: 0x06000540 RID: 1344 RVA: 0x00013098 File Offset: 0x00011298
		[__DynamicallyInvokable]
		public string Replace(char oldChar, char newChar)
		{
			return this.ReplaceInternal(oldChar, newChar);
		}

		// Token: 0x06000541 RID: 1345
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string ReplaceInternal(string oldValue, string newValue);

		/// <summary>Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string.</summary>
		/// <param name="oldValue">The string to be replaced.</param>
		/// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue" />.</param>
		/// <returns>A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue" />. If <paramref name="oldValue" /> is not found in the current instance, the method returns the current instance unchanged.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="oldValue" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="oldValue" /> is the empty string ("").</exception>
		// Token: 0x06000542 RID: 1346 RVA: 0x000130A4 File Offset: 0x000112A4
		[__DynamicallyInvokable]
		public string Replace(string oldValue, string newValue)
		{
			if (oldValue == null)
			{
				throw new ArgumentNullException("oldValue");
			}
			return this.ReplaceInternal(oldValue, newValue);
		}

		/// <summary>Returns a new string in which a specified number of characters in the current instance beginning at a specified position have been deleted.</summary>
		/// <param name="startIndex">The zero-based position to begin deleting characters.</param>
		/// <param name="count">The number of characters to delete.</param>
		/// <returns>A new string that is equivalent to this instance except for the removed characters.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">Either <paramref name="startIndex" /> or <paramref name="count" /> is less than zero.  
		///  -or-  
		///  <paramref name="startIndex" /> plus <paramref name="count" /> specify a position outside this instance.</exception>
		// Token: 0x06000543 RID: 1347 RVA: 0x000130CC File Offset: 0x000112CC
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe string Remove(int startIndex, int count)
		{
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
			}
			if (count > this.Length - startIndex)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
			}
			int num = this.Length - count;
			if (num == 0)
			{
				return string.Empty;
			}
			string text = string.FastAllocateString(num);
			fixed (char* ptr = &this.m_firstChar)
			{
				fixed (char* ptr2 = &text.m_firstChar)
				{
					string.wstrcpy(ptr2, ptr, startIndex);
					string.wstrcpy(ptr2 + startIndex, ptr + startIndex + count, num - startIndex);
				}
			}
			return text;
		}

		/// <summary>Returns a new string in which all the characters in the current instance, beginning at a specified position and continuing through the last position, have been deleted.</summary>
		/// <param name="startIndex">The zero-based position to begin deleting characters.</param>
		/// <returns>A new string that is equivalent to this string except for the removed characters.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> is less than zero.  
		/// -or-  
		/// <paramref name="startIndex" /> specifies a position that is not within this string.</exception>
		// Token: 0x06000544 RID: 1348 RVA: 0x00013180 File Offset: 0x00011380
		[__DynamicallyInvokable]
		public string Remove(int startIndex)
		{
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
			}
			if (startIndex >= this.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_StartIndexLessThanLength"));
			}
			return this.Substring(0, startIndex);
		}

		/// <summary>Replaces one or more format items in a string with the string representation of a specified object.</summary>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The object to format.</param>
		/// <returns>A copy of <paramref name="format" /> in which any format items are replaced by the string representation of <paramref name="arg0" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="format" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">The format item in <paramref name="format" /> is invalid.  
		///  -or-  
		///  The index of a format item is not zero.</exception>
		// Token: 0x06000545 RID: 1349 RVA: 0x000131CC File Offset: 0x000113CC
		[__DynamicallyInvokable]
		public static string Format(string format, object arg0)
		{
			return string.FormatHelper(null, format, new ParamsArray(arg0));
		}

		/// <summary>Replaces the format items in a string with the string representation of two specified objects.</summary>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <returns>A copy of <paramref name="format" /> in which format items are replaced by the string representations of <paramref name="arg0" /> and <paramref name="arg1" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="format" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="format" /> is invalid.  
		/// -or-  
		/// The index of a format item is not zero or one.</exception>
		// Token: 0x06000546 RID: 1350 RVA: 0x000131DB File Offset: 0x000113DB
		[__DynamicallyInvokable]
		public static string Format(string format, object arg0, object arg1)
		{
			return string.FormatHelper(null, format, new ParamsArray(arg0, arg1));
		}

		/// <summary>Replaces the format items in a string with the string representation of three specified objects.</summary>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <param name="arg2">The third object to format.</param>
		/// <returns>A copy of <paramref name="format" /> in which the format items have been replaced by the string representations of <paramref name="arg0" />, <paramref name="arg1" />, and <paramref name="arg2" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="format" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="format" /> is invalid.  
		/// -or-  
		/// The index of a format item is less than zero, or greater than two.</exception>
		// Token: 0x06000547 RID: 1351 RVA: 0x000131EB File Offset: 0x000113EB
		[__DynamicallyInvokable]
		public static string Format(string format, object arg0, object arg1, object arg2)
		{
			return string.FormatHelper(null, format, new ParamsArray(arg0, arg1, arg2));
		}

		/// <summary>Replaces the format item in a specified string with the string representation of a corresponding object in a specified array.</summary>
		/// <param name="format">A composite format string.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>A copy of <paramref name="format" /> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="format" /> or <paramref name="args" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="format" /> is invalid.  
		/// -or-  
		/// The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args" /> array.</exception>
		// Token: 0x06000548 RID: 1352 RVA: 0x000131FC File Offset: 0x000113FC
		[__DynamicallyInvokable]
		public static string Format(string format, params object[] args)
		{
			if (args == null)
			{
				throw new ArgumentNullException((format == null) ? "format" : "args");
			}
			return string.FormatHelper(null, format, new ParamsArray(args));
		}

		/// <summary>Replaces the format item or items in a specified string with the string representation of the corresponding object. A parameter supplies culture-specific formatting information.</summary>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The object to format.</param>
		/// <returns>A copy of <paramref name="format" /> in which the format item or items have been replaced by the string representation of <paramref name="arg0" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="format" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="format" /> is invalid.  
		/// -or-  
		/// The index of a format item is not zero.</exception>
		// Token: 0x06000549 RID: 1353 RVA: 0x00013223 File Offset: 0x00011423
		[__DynamicallyInvokable]
		public static string Format(IFormatProvider provider, string format, object arg0)
		{
			return string.FormatHelper(provider, format, new ParamsArray(arg0));
		}

		/// <summary>Replaces the format items in a string with the string representation of two specified objects. A parameter supplies culture-specific formatting information.</summary>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <returns>A copy of <paramref name="format" /> in which format items are replaced by the string representations of <paramref name="arg0" /> and <paramref name="arg1" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="format" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="format" /> is invalid.  
		/// -or-  
		/// The index of a format item is not zero or one.</exception>
		// Token: 0x0600054A RID: 1354 RVA: 0x00013232 File Offset: 0x00011432
		[__DynamicallyInvokable]
		public static string Format(IFormatProvider provider, string format, object arg0, object arg1)
		{
			return string.FormatHelper(provider, format, new ParamsArray(arg0, arg1));
		}

		/// <summary>Replaces the format items in a string with the string representation of three specified objects. An parameter supplies culture-specific formatting information.</summary>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <param name="arg2">The third object to format.</param>
		/// <returns>A copy of <paramref name="format" /> in which the format items have been replaced by the string representations of <paramref name="arg0" />, <paramref name="arg1" />, and <paramref name="arg2" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="format" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="format" /> is invalid.  
		/// -or-  
		/// The index of a format item is less than zero, or greater than two.</exception>
		// Token: 0x0600054B RID: 1355 RVA: 0x00013242 File Offset: 0x00011442
		[__DynamicallyInvokable]
		public static string Format(IFormatProvider provider, string format, object arg0, object arg1, object arg2)
		{
			return string.FormatHelper(provider, format, new ParamsArray(arg0, arg1, arg2));
		}

		/// <summary>Replaces the format items in a string with the string representations of corresponding objects in a specified array. A parameter supplies culture-specific formatting information.</summary>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>A copy of <paramref name="format" /> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="format" /> or <paramref name="args" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="format" /> is invalid.  
		/// -or-  
		/// The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args" /> array.</exception>
		// Token: 0x0600054C RID: 1356 RVA: 0x00013254 File Offset: 0x00011454
		[__DynamicallyInvokable]
		public static string Format(IFormatProvider provider, string format, params object[] args)
		{
			if (args == null)
			{
				throw new ArgumentNullException((format == null) ? "format" : "args");
			}
			return string.FormatHelper(provider, format, new ParamsArray(args));
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0001327B File Offset: 0x0001147B
		private static string FormatHelper(IFormatProvider provider, string format, ParamsArray args)
		{
			if (format == null)
			{
				throw new ArgumentNullException("format");
			}
			return StringBuilderCache.GetStringAndRelease(StringBuilderCache.Acquire(format.Length + args.Length * 8).AppendFormatHelper(provider, format, args));
		}

		/// <summary>Creates a new instance of <see cref="T:System.String" /> with the same value as a specified <see cref="T:System.String" />.</summary>
		/// <param name="str">The string to copy.</param>
		/// <returns>A new string with the same value as <paramref name="str" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="str" /> is <see langword="null" />.</exception>
		// Token: 0x0600054E RID: 1358 RVA: 0x000132B0 File Offset: 0x000114B0
		[SecuritySafeCritical]
		public unsafe static string Copy(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			int length = str.Length;
			string text = string.FastAllocateString(length);
			fixed (char* ptr = &text.m_firstChar)
			{
				fixed (char* ptr2 = &str.m_firstChar)
				{
					string.wstrcpy(ptr, ptr2, length);
				}
			}
			return text;
		}

		/// <summary>Creates the string  representation of a specified object.</summary>
		/// <param name="arg0">The object to represent, or <see langword="null" />.</param>
		/// <returns>The string representation of the value of <paramref name="arg0" />, or <see cref="F:System.String.Empty" /> if <paramref name="arg0" /> is <see langword="null" />.</returns>
		// Token: 0x0600054F RID: 1359 RVA: 0x000132F8 File Offset: 0x000114F8
		[__DynamicallyInvokable]
		public static string Concat(object arg0)
		{
			if (arg0 == null)
			{
				return string.Empty;
			}
			return arg0.ToString();
		}

		/// <summary>Concatenates the string representations of two specified objects.</summary>
		/// <param name="arg0">The first object to concatenate.</param>
		/// <param name="arg1">The second object to concatenate.</param>
		/// <returns>The concatenated string representations of the values of <paramref name="arg0" /> and <paramref name="arg1" />.</returns>
		// Token: 0x06000550 RID: 1360 RVA: 0x00013309 File Offset: 0x00011509
		[__DynamicallyInvokable]
		public static string Concat(object arg0, object arg1)
		{
			if (arg0 == null)
			{
				arg0 = string.Empty;
			}
			if (arg1 == null)
			{
				arg1 = string.Empty;
			}
			return arg0.ToString() + arg1.ToString();
		}

		/// <summary>Concatenates the string representations of three specified objects.</summary>
		/// <param name="arg0">The first object to concatenate.</param>
		/// <param name="arg1">The second object to concatenate.</param>
		/// <param name="arg2">The third object to concatenate.</param>
		/// <returns>The concatenated string representations of the values of <paramref name="arg0" />, <paramref name="arg1" />, and <paramref name="arg2" />.</returns>
		// Token: 0x06000551 RID: 1361 RVA: 0x00013330 File Offset: 0x00011530
		[__DynamicallyInvokable]
		public static string Concat(object arg0, object arg1, object arg2)
		{
			if (arg0 == null)
			{
				arg0 = string.Empty;
			}
			if (arg1 == null)
			{
				arg1 = string.Empty;
			}
			if (arg2 == null)
			{
				arg2 = string.Empty;
			}
			return arg0.ToString() + arg1.ToString() + arg2.ToString();
		}

		/// <summary>Concatenates the string representations of four specified objects and any objects specified in an optional variable length parameter list.</summary>
		/// <param name="arg0">The first object to concatenate.</param>
		/// <param name="arg1">The second object to concatenate.</param>
		/// <param name="arg2">The third object to concatenate.</param>
		/// <param name="arg3">The fourth object to concatenate.</param>
		/// <param name="…">An optional comma-delimited list of one or more additional objects to concatenate. </param>
		/// <returns>The concatenated string representation of each value in the parameter list.</returns>
		// Token: 0x06000552 RID: 1362 RVA: 0x00013368 File Offset: 0x00011568
		[CLSCompliant(false)]
		public static string Concat(object arg0, object arg1, object arg2, object arg3, __arglist)
		{
			ArgIterator argIterator = new ArgIterator(__arglist);
			int num = argIterator.GetRemainingCount() + 4;
			object[] array = new object[num];
			array[0] = arg0;
			array[1] = arg1;
			array[2] = arg2;
			array[3] = arg3;
			for (int i = 4; i < num; i++)
			{
				array[i] = TypedReference.ToObject(argIterator.GetNextArg());
			}
			return string.Concat(array);
		}

		/// <summary>Concatenates the string representations of the elements in a specified <see cref="T:System.Object" /> array.</summary>
		/// <param name="args">An object array that contains the elements to concatenate.</param>
		/// <returns>The concatenated string representations of the values of the elements in <paramref name="args" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="args" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.OutOfMemoryException">Out of memory.</exception>
		// Token: 0x06000553 RID: 1363 RVA: 0x000133C0 File Offset: 0x000115C0
		[__DynamicallyInvokable]
		public static string Concat(params object[] args)
		{
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			string[] array = new string[args.Length];
			int num = 0;
			for (int i = 0; i < args.Length; i++)
			{
				object obj = args[i];
				array[i] = ((obj == null) ? string.Empty : obj.ToString());
				if (array[i] == null)
				{
					array[i] = string.Empty;
				}
				num += array[i].Length;
				if (num < 0)
				{
					throw new OutOfMemoryException();
				}
			}
			return string.ConcatArray(array, num);
		}

		/// <summary>Concatenates the members of an <see cref="T:System.Collections.Generic.IEnumerable`1" /> implementation.</summary>
		/// <param name="values">A collection object that implements the <see cref="T:System.Collections.Generic.IEnumerable`1" /> interface.</param>
		/// <typeparam name="T">The type of the members of <paramref name="values" />.</typeparam>
		/// <returns>The concatenated members in <paramref name="values" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="values" /> is <see langword="null" />.</exception>
		// Token: 0x06000554 RID: 1364 RVA: 0x00013434 File Offset: 0x00011634
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static string Concat<T>(IEnumerable<T> values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(16);
			using (IEnumerator<T> enumerator = values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current != null)
					{
						T t = enumerator.Current;
						string text = t.ToString();
						if (text != null)
						{
							stringBuilder.Append(text);
						}
					}
				}
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		/// <summary>Concatenates the members of a constructed <see cref="T:System.Collections.Generic.IEnumerable`1" /> collection of type <see cref="T:System.String" />.</summary>
		/// <param name="values">A collection object that implements <see cref="T:System.Collections.Generic.IEnumerable`1" /> and whose generic type argument is <see cref="T:System.String" />.</param>
		/// <returns>The concatenated strings in <paramref name="values" />, or <see cref="F:System.String.Empty" /> if <paramref name="values" /> is an empty <see langword="IEnumerable(Of String)" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="values" /> is <see langword="null" />.</exception>
		// Token: 0x06000555 RID: 1365 RVA: 0x000134B8 File Offset: 0x000116B8
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static string Concat(IEnumerable<string> values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(16);
			using (IEnumerator<string> enumerator = values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current != null)
					{
						stringBuilder.Append(enumerator.Current);
					}
				}
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		/// <summary>Concatenates two specified instances of <see cref="T:System.String" />.</summary>
		/// <param name="str0">The first string to concatenate.</param>
		/// <param name="str1">The second string to concatenate.</param>
		/// <returns>The concatenation of <paramref name="str0" /> and <paramref name="str1" />.</returns>
		// Token: 0x06000556 RID: 1366 RVA: 0x00013524 File Offset: 0x00011724
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static string Concat(string str0, string str1)
		{
			if (string.IsNullOrEmpty(str0))
			{
				if (string.IsNullOrEmpty(str1))
				{
					return string.Empty;
				}
				return str1;
			}
			else
			{
				if (string.IsNullOrEmpty(str1))
				{
					return str0;
				}
				int length = str0.Length;
				string text = string.FastAllocateString(length + str1.Length);
				string.FillStringChecked(text, 0, str0);
				string.FillStringChecked(text, length, str1);
				return text;
			}
		}

		/// <summary>Concatenates three specified instances of <see cref="T:System.String" />.</summary>
		/// <param name="str0">The first string to concatenate.</param>
		/// <param name="str1">The second string to concatenate.</param>
		/// <param name="str2">The third string to concatenate.</param>
		/// <returns>The concatenation of <paramref name="str0" />, <paramref name="str1" />, and <paramref name="str2" />.</returns>
		// Token: 0x06000557 RID: 1367 RVA: 0x0001357C File Offset: 0x0001177C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static string Concat(string str0, string str1, string str2)
		{
			if (str0 == null && str1 == null && str2 == null)
			{
				return string.Empty;
			}
			if (str0 == null)
			{
				str0 = string.Empty;
			}
			if (str1 == null)
			{
				str1 = string.Empty;
			}
			if (str2 == null)
			{
				str2 = string.Empty;
			}
			int length = str0.Length + str1.Length + str2.Length;
			string text = string.FastAllocateString(length);
			string.FillStringChecked(text, 0, str0);
			string.FillStringChecked(text, str0.Length, str1);
			string.FillStringChecked(text, str0.Length + str1.Length, str2);
			return text;
		}

		/// <summary>Concatenates four specified instances of <see cref="T:System.String" />.</summary>
		/// <param name="str0">The first string to concatenate.</param>
		/// <param name="str1">The second string to concatenate.</param>
		/// <param name="str2">The third string to concatenate.</param>
		/// <param name="str3">The fourth string to concatenate.</param>
		/// <returns>The concatenation of <paramref name="str0" />, <paramref name="str1" />, <paramref name="str2" />, and <paramref name="str3" />.</returns>
		// Token: 0x06000558 RID: 1368 RVA: 0x000135FC File Offset: 0x000117FC
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static string Concat(string str0, string str1, string str2, string str3)
		{
			if (str0 == null && str1 == null && str2 == null && str3 == null)
			{
				return string.Empty;
			}
			if (str0 == null)
			{
				str0 = string.Empty;
			}
			if (str1 == null)
			{
				str1 = string.Empty;
			}
			if (str2 == null)
			{
				str2 = string.Empty;
			}
			if (str3 == null)
			{
				str3 = string.Empty;
			}
			int length = str0.Length + str1.Length + str2.Length + str3.Length;
			string text = string.FastAllocateString(length);
			string.FillStringChecked(text, 0, str0);
			string.FillStringChecked(text, str0.Length, str1);
			string.FillStringChecked(text, str0.Length + str1.Length, str2);
			string.FillStringChecked(text, str0.Length + str1.Length + str2.Length, str3);
			return text;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x000136AC File Offset: 0x000118AC
		[SecuritySafeCritical]
		private static string ConcatArray(string[] values, int totalLength)
		{
			string text = string.FastAllocateString(totalLength);
			int num = 0;
			for (int i = 0; i < values.Length; i++)
			{
				string.FillStringChecked(text, num, values[i]);
				num += values[i].Length;
			}
			return text;
		}

		/// <summary>Concatenates the elements of a specified <see cref="T:System.String" /> array.</summary>
		/// <param name="values">An array of string instances.</param>
		/// <returns>The concatenated elements of <paramref name="values" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="values" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.OutOfMemoryException">Out of memory.</exception>
		// Token: 0x0600055A RID: 1370 RVA: 0x000136E8 File Offset: 0x000118E8
		[__DynamicallyInvokable]
		public static string Concat(params string[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			int num = 0;
			string[] array = new string[values.Length];
			for (int i = 0; i < values.Length; i++)
			{
				string text = values[i];
				array[i] = ((text == null) ? string.Empty : text);
				num += array[i].Length;
				if (num < 0)
				{
					throw new OutOfMemoryException();
				}
			}
			return string.ConcatArray(array, num);
		}

		/// <summary>Retrieves the system's reference to the specified <see cref="T:System.String" />.</summary>
		/// <param name="str">A string to search for in the intern pool.</param>
		/// <returns>The system's reference to <paramref name="str" />, if it is interned; otherwise, a new reference to a string with the value of <paramref name="str" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="str" /> is <see langword="null" />.</exception>
		// Token: 0x0600055B RID: 1371 RVA: 0x0001374A File Offset: 0x0001194A
		[SecuritySafeCritical]
		public static string Intern(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			return Thread.GetDomain().GetOrInternString(str);
		}

		/// <summary>Retrieves a reference to a specified <see cref="T:System.String" />.</summary>
		/// <param name="str">The string to search for in the intern pool.</param>
		/// <returns>A reference to <paramref name="str" /> if it is in the common language runtime intern pool; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="str" /> is <see langword="null" />.</exception>
		// Token: 0x0600055C RID: 1372 RVA: 0x00013765 File Offset: 0x00011965
		[SecuritySafeCritical]
		public static string IsInterned(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			return Thread.GetDomain().IsStringInterned(str);
		}

		/// <summary>Returns the <see cref="T:System.TypeCode" /> for class <see cref="T:System.String" />.</summary>
		/// <returns>The enumerated constant, <see cref="F:System.TypeCode.String" />.</returns>
		// Token: 0x0600055D RID: 1373 RVA: 0x00013780 File Offset: 0x00011980
		public TypeCode GetTypeCode()
		{
			return TypeCode.String;
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToBoolean(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>
		///   <see langword="true" /> if the value of the current string is <see cref="F:System.Boolean.TrueString" />; <see langword="false" /> if the value of the current string is <see cref="F:System.Boolean.FalseString" />.</returns>
		/// <exception cref="T:System.FormatException">The value of the current string is not <see cref="F:System.Boolean.TrueString" /> or <see cref="F:System.Boolean.FalseString" />.</exception>
		// Token: 0x0600055E RID: 1374 RVA: 0x00013784 File Offset: 0x00011984
		[__DynamicallyInvokable]
		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToChar(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The character at index 0 in the current <see cref="T:System.String" /> object.</returns>
		// Token: 0x0600055F RID: 1375 RVA: 0x0001378D File Offset: 0x0001198D
		[__DynamicallyInvokable]
		char IConvertible.ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToSByte(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		/// <exception cref="T:System.FormatException">The value of the current <see cref="T:System.String" /> object cannot be parsed.</exception>
		/// <exception cref="T:System.OverflowException">The value of the current <see cref="T:System.String" /> object is a number greater than <see cref="F:System.SByte.MaxValue" /> or less than <see cref="F:System.SByte.MinValue" />.</exception>
		// Token: 0x06000560 RID: 1376 RVA: 0x00013796 File Offset: 0x00011996
		[__DynamicallyInvokable]
		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToByte(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		/// <exception cref="T:System.FormatException">The value of the current <see cref="T:System.String" /> object cannot be parsed.</exception>
		/// <exception cref="T:System.OverflowException">The value of the current <see cref="T:System.String" /> object is a number greater than <see cref="F:System.Byte.MaxValue" /> or less than <see cref="F:System.Byte.MinValue" />.</exception>
		// Token: 0x06000561 RID: 1377 RVA: 0x0001379F File Offset: 0x0001199F
		[__DynamicallyInvokable]
		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToInt16(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		/// <exception cref="T:System.FormatException">The value of the current <see cref="T:System.String" /> object cannot be parsed.</exception>
		/// <exception cref="T:System.OverflowException">The value of the current <see cref="T:System.String" /> object is a number greater than <see cref="F:System.Int16.MaxValue" /> or less than <see cref="F:System.Int16.MinValue" />.</exception>
		// Token: 0x06000562 RID: 1378 RVA: 0x000137A8 File Offset: 0x000119A8
		[__DynamicallyInvokable]
		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToUInt16(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		/// <exception cref="T:System.FormatException">The value of the current <see cref="T:System.String" /> object cannot be parsed.</exception>
		/// <exception cref="T:System.OverflowException">The value of the current <see cref="T:System.String" /> object is a number greater than <see cref="F:System.UInt16.MaxValue" /> or less than <see cref="F:System.UInt16.MinValue" />.</exception>
		// Token: 0x06000563 RID: 1379 RVA: 0x000137B1 File Offset: 0x000119B1
		[__DynamicallyInvokable]
		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToInt32(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		// Token: 0x06000564 RID: 1380 RVA: 0x000137BA File Offset: 0x000119BA
		[__DynamicallyInvokable]
		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return Convert.ToInt32(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToUInt32(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		/// <exception cref="T:System.FormatException">The value of the current <see cref="T:System.String" /> object cannot be parsed.</exception>
		/// <exception cref="T:System.OverflowException">The value of the current <see cref="T:System.String" /> object is a number greater <see cref="F:System.UInt32.MaxValue" /> or less than <see cref="F:System.UInt32.MinValue" /></exception>
		// Token: 0x06000565 RID: 1381 RVA: 0x000137C3 File Offset: 0x000119C3
		[__DynamicallyInvokable]
		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToInt64(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		// Token: 0x06000566 RID: 1382 RVA: 0x000137CC File Offset: 0x000119CC
		[__DynamicallyInvokable]
		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return Convert.ToInt64(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToUInt64(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		// Token: 0x06000567 RID: 1383 RVA: 0x000137D5 File Offset: 0x000119D5
		[__DynamicallyInvokable]
		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToSingle(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		// Token: 0x06000568 RID: 1384 RVA: 0x000137DE File Offset: 0x000119DE
		[__DynamicallyInvokable]
		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToDouble(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		/// <exception cref="T:System.FormatException">The value of the current <see cref="T:System.String" /> object cannot be parsed.</exception>
		/// <exception cref="T:System.OverflowException">The value of the current <see cref="T:System.String" /> object is a number less than <see cref="F:System.Double.MinValue" /> or greater than <see cref="F:System.Double.MaxValue" />.</exception>
		// Token: 0x06000569 RID: 1385 RVA: 0x000137E7 File Offset: 0x000119E7
		[__DynamicallyInvokable]
		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToDecimal(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		/// <exception cref="T:System.FormatException">The value of the current <see cref="T:System.String" /> object cannot be parsed.</exception>
		/// <exception cref="T:System.OverflowException">The value of the current <see cref="T:System.String" /> object is a number less than <see cref="F:System.Decimal.MinValue" /> or than <see cref="F:System.Decimal.MaxValue" /> greater.</exception>
		// Token: 0x0600056A RID: 1386 RVA: 0x000137F0 File Offset: 0x000119F0
		[__DynamicallyInvokable]
		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return Convert.ToDecimal(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToDateTime(System.IFormatProvider)" />.</summary>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		// Token: 0x0600056B RID: 1387 RVA: 0x000137F9 File Offset: 0x000119F9
		[__DynamicallyInvokable]
		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return Convert.ToDateTime(this, provider);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToType(System.Type,System.IFormatProvider)" />.</summary>
		/// <param name="type">The type of the returned object.</param>
		/// <param name="provider">An object that provides culture-specific formatting information.</param>
		/// <returns>The converted value of the current <see cref="T:System.String" /> object.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="type" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidCastException">The value of the current <see cref="T:System.String" /> object cannot be converted to the type specified by the <paramref name="type" /> parameter.</exception>
		// Token: 0x0600056C RID: 1388 RVA: 0x00013802 File Offset: 0x00011A02
		[__DynamicallyInvokable]
		object IConvertible.ToType(Type type, IFormatProvider provider)
		{
			return Convert.DefaultToType(this, type, provider);
		}

		// Token: 0x0600056D RID: 1389
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern bool IsFastSort();

		// Token: 0x0600056E RID: 1390
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern bool IsAscii();

		// Token: 0x0600056F RID: 1391
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void SetTrailByte(byte data);

		// Token: 0x06000570 RID: 1392
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern bool TryGetTrailByte(out byte data);

		/// <summary>Retrieves an object that can iterate through the individual characters in this string.</summary>
		/// <returns>An enumerator object.</returns>
		// Token: 0x06000571 RID: 1393 RVA: 0x0001380C File Offset: 0x00011A0C
		public CharEnumerator GetEnumerator()
		{
			return new CharEnumerator(this);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00013814 File Offset: 0x00011A14
		[__DynamicallyInvokable]
		IEnumerator<char> IEnumerable<char>.GetEnumerator()
		{
			return new CharEnumerator(this);
		}

		/// <summary>Returns an enumerator that iterates through the current <see cref="T:System.String" /> object.</summary>
		/// <returns>An enumerator that can be used to iterate through the current string.</returns>
		// Token: 0x06000573 RID: 1395 RVA: 0x0001381C File Offset: 0x00011A1C
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new CharEnumerator(this);
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00013824 File Offset: 0x00011A24
		[SecurityCritical]
		internal unsafe static void InternalCopy(string src, IntPtr dest, int len)
		{
			if (len == 0)
			{
				return;
			}
			fixed (char* ptr = &src.m_firstChar)
			{
				byte* src2 = (byte*)ptr;
				byte* dest2 = (byte*)((void*)dest);
				Buffer.Memcpy(dest2, src2, len);
			}
		}

		// Token: 0x04000283 RID: 643
		[NonSerialized]
		private int m_stringLength;

		// Token: 0x04000284 RID: 644
		[NonSerialized]
		private char m_firstChar;

		// Token: 0x04000285 RID: 645
		private const int TrimHead = 0;

		// Token: 0x04000286 RID: 646
		private const int TrimTail = 1;

		// Token: 0x04000287 RID: 647
		private const int TrimBoth = 2;

		/// <summary>Represents the empty string. This field is read-only.</summary>
		// Token: 0x04000288 RID: 648
		[__DynamicallyInvokable]
		public static readonly string Empty;

		// Token: 0x04000289 RID: 649
		private const int charPtrAlignConst = 3;

		// Token: 0x0400028A RID: 650
		private const int alignConst = 7;
	}
}

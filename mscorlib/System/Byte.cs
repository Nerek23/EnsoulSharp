using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;

namespace System
{
	/// <summary>Represents an 8-bit unsigned integer.</summary>
	// Token: 0x020000B4 RID: 180
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public struct Byte : IComparable, IFormattable, IConvertible, IComparable<byte>, IEquatable<byte>
	{
		/// <summary>Compares this instance to a specified object and returns an indication of their relative values.</summary>
		/// <param name="value">An object to compare, or <see langword="null" />.</param>
		/// <returns>A signed integer that indicates the relative order of this instance and <paramref name="value" />.  
		///   Return Value  
		///
		///   Description  
		///
		///   Less than zero  
		///
		///   This instance is less than <paramref name="value" />.  
		///
		///   Zero  
		///
		///   This instance is equal to <paramref name="value" />.  
		///
		///   Greater than zero  
		///
		///   This instance is greater than <paramref name="value" />.  
		///
		///  -or-  
		///
		///  <paramref name="value" /> is <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="value" /> is not a <see cref="T:System.Byte" />.</exception>
		// Token: 0x06000A61 RID: 2657 RVA: 0x00021587 File Offset: 0x0001F787
		public int CompareTo(object value)
		{
			if (value == null)
			{
				return 1;
			}
			if (!(value is byte))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeByte"));
			}
			return (int)(this - (byte)value);
		}

		/// <summary>Compares this instance to a specified 8-bit unsigned integer and returns an indication of their relative values.</summary>
		/// <param name="value">An 8-bit unsigned integer to compare.</param>
		/// <returns>A signed integer that indicates the relative order of this instance and <paramref name="value" />.  
		///   Return Value  
		///
		///   Description  
		///
		///   Less than zero  
		///
		///   This instance is less than <paramref name="value" />.  
		///
		///   Zero  
		///
		///   This instance is equal to <paramref name="value" />.  
		///
		///   Greater than zero  
		///
		///   This instance is greater than <paramref name="value" />.</returns>
		// Token: 0x06000A62 RID: 2658 RVA: 0x000215AF File Offset: 0x0001F7AF
		[__DynamicallyInvokable]
		public int CompareTo(byte value)
		{
			return (int)(this - value);
		}

		/// <summary>Returns a value indicating whether this instance is equal to a specified object.</summary>
		/// <param name="obj">An object to compare with this instance, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see cref="T:System.Byte" /> and equals the value of this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000A63 RID: 2659 RVA: 0x000215B5 File Offset: 0x0001F7B5
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return obj is byte && this == (byte)obj;
		}

		/// <summary>Returns a value indicating whether this instance and a specified <see cref="T:System.Byte" /> object represent the same value.</summary>
		/// <param name="obj">An object to compare to this instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000A64 RID: 2660 RVA: 0x000215CB File Offset: 0x0001F7CB
		[NonVersionable]
		[__DynamicallyInvokable]
		public bool Equals(byte obj)
		{
			return this == obj;
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A hash code for the current <see cref="T:System.Byte" />.</returns>
		// Token: 0x06000A65 RID: 2661 RVA: 0x000215D2 File Offset: 0x0001F7D2
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return (int)this;
		}

		/// <summary>Converts the string representation of a number to its <see cref="T:System.Byte" /> equivalent.</summary>
		/// <param name="s">A string that contains a number to convert. The string is interpreted using the <see cref="F:System.Globalization.NumberStyles.Integer" /> style.</param>
		/// <returns>A byte value that is equivalent to the number contained in <paramref name="s" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="s" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="s" /> is not of the correct format.</exception>
		/// <exception cref="T:System.OverflowException">
		///   <paramref name="s" /> represents a number less than <see cref="F:System.Byte.MinValue" /> or greater than <see cref="F:System.Byte.MaxValue" />.</exception>
		// Token: 0x06000A66 RID: 2662 RVA: 0x000215D6 File Offset: 0x0001F7D6
		[__DynamicallyInvokable]
		public static byte Parse(string s)
		{
			return byte.Parse(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
		}

		/// <summary>Converts the string representation of a number in a specified style to its <see cref="T:System.Byte" /> equivalent.</summary>
		/// <param name="s">A string that contains a number to convert. The string is interpreted using the style specified by <paramref name="style" />.</param>
		/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
		/// <returns>A byte value that is equivalent to the number contained in <paramref name="s" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="s" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="s" /> is not of the correct format.</exception>
		/// <exception cref="T:System.OverflowException">
		///   <paramref name="s" /> represents a number less than <see cref="F:System.Byte.MinValue" /> or greater than <see cref="F:System.Byte.MaxValue" />.  
		/// -or-  
		/// <paramref name="s" /> includes non-zero, fractional digits.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.  
		/// -or-  
		/// <paramref name="style" /> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> and <see cref="F:System.Globalization.NumberStyles.HexNumber" /> values.</exception>
		// Token: 0x06000A67 RID: 2663 RVA: 0x000215E4 File Offset: 0x0001F7E4
		[__DynamicallyInvokable]
		public static byte Parse(string s, NumberStyles style)
		{
			NumberFormatInfo.ValidateParseStyleInteger(style);
			return byte.Parse(s, style, NumberFormatInfo.CurrentInfo);
		}

		/// <summary>Converts the string representation of a number in a specified culture-specific format to its <see cref="T:System.Byte" /> equivalent.</summary>
		/// <param name="s">A string that contains a number to convert. The string is interpreted using the <see cref="F:System.Globalization.NumberStyles.Integer" /> style.</param>
		/// <param name="provider">An object that supplies culture-specific parsing information about <paramref name="s" />. If <paramref name="provider" /> is <see langword="null" />, the thread current culture is used.</param>
		/// <returns>A byte value that is equivalent to the number contained in <paramref name="s" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="s" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="s" /> is not of the correct format.</exception>
		/// <exception cref="T:System.OverflowException">
		///   <paramref name="s" /> represents a number less than <see cref="F:System.Byte.MinValue" /> or greater than <see cref="F:System.Byte.MaxValue" />.</exception>
		// Token: 0x06000A68 RID: 2664 RVA: 0x000215F8 File Offset: 0x0001F7F8
		[__DynamicallyInvokable]
		public static byte Parse(string s, IFormatProvider provider)
		{
			return byte.Parse(s, NumberStyles.Integer, NumberFormatInfo.GetInstance(provider));
		}

		/// <summary>Converts the string representation of a number in a specified style and culture-specific format to its <see cref="T:System.Byte" /> equivalent.</summary>
		/// <param name="s">A string that contains a number to convert. The string is interpreted using the style specified by <paramref name="style" />.</param>
		/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
		/// <param name="provider">An object that supplies culture-specific information about the format of <paramref name="s" />. If <paramref name="provider" /> is <see langword="null" />, the thread current culture is used.</param>
		/// <returns>A byte value that is equivalent to the number contained in <paramref name="s" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="s" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="s" /> is not of the correct format.</exception>
		/// <exception cref="T:System.OverflowException">
		///   <paramref name="s" /> represents a number less than <see cref="F:System.Byte.MinValue" /> or greater than <see cref="F:System.Byte.MaxValue" />.  
		/// -or-  
		/// <paramref name="s" /> includes non-zero, fractional digits.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.  
		/// -or-  
		/// <paramref name="style" /> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> and <see cref="F:System.Globalization.NumberStyles.HexNumber" /> values.</exception>
		// Token: 0x06000A69 RID: 2665 RVA: 0x00021607 File Offset: 0x0001F807
		[__DynamicallyInvokable]
		public static byte Parse(string s, NumberStyles style, IFormatProvider provider)
		{
			NumberFormatInfo.ValidateParseStyleInteger(style);
			return byte.Parse(s, style, NumberFormatInfo.GetInstance(provider));
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0002161C File Offset: 0x0001F81C
		private static byte Parse(string s, NumberStyles style, NumberFormatInfo info)
		{
			int num = 0;
			try
			{
				num = Number.ParseInt32(s, style, info);
			}
			catch (OverflowException innerException)
			{
				throw new OverflowException(Environment.GetResourceString("Overflow_Byte"), innerException);
			}
			if (num < 0 || num > 255)
			{
				throw new OverflowException(Environment.GetResourceString("Overflow_Byte"));
			}
			return (byte)num;
		}

		/// <summary>Tries to convert the string representation of a number to its <see cref="T:System.Byte" /> equivalent, and returns a value that indicates whether the conversion succeeded.</summary>
		/// <param name="s">A string that contains a number to convert. The string is interpreted using the <see cref="F:System.Globalization.NumberStyles.Integer" /> style.</param>
		/// <param name="result">When this method returns, contains the <see cref="T:System.Byte" /> value equivalent to the number contained in <paramref name="s" /> if the conversion succeeded, or zero if the conversion failed. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000A6B RID: 2667 RVA: 0x00021678 File Offset: 0x0001F878
		[__DynamicallyInvokable]
		public static bool TryParse(string s, out byte result)
		{
			return byte.TryParse(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
		}

		/// <summary>Converts the string representation of a number in a specified style and culture-specific format to its <see cref="T:System.Byte" /> equivalent. A return value indicates whether the conversion succeeded or failed.</summary>
		/// <param name="s">A string containing a number to convert. The string is interpreted using the style specified by <paramref name="style" />.</param>
		/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />. If <paramref name="provider" /> is <see langword="null" />, the thread current culture is used.</param>
		/// <param name="result">When this method returns, contains the 8-bit unsigned integer value equivalent to the number contained in <paramref name="s" /> if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" />, is not of the correct format, or represents a number less than <see cref="F:System.Byte.MinValue" /> or greater than <see cref="F:System.Byte.MaxValue" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.  
		/// -or-  
		/// <paramref name="style" /> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> and <see cref="F:System.Globalization.NumberStyles.HexNumber" /> values.</exception>
		// Token: 0x06000A6C RID: 2668 RVA: 0x00021687 File Offset: 0x0001F887
		[__DynamicallyInvokable]
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out byte result)
		{
			NumberFormatInfo.ValidateParseStyleInteger(style);
			return byte.TryParse(s, style, NumberFormatInfo.GetInstance(provider), out result);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x000216A0 File Offset: 0x0001F8A0
		private static bool TryParse(string s, NumberStyles style, NumberFormatInfo info, out byte result)
		{
			result = 0;
			int num;
			if (!Number.TryParseInt32(s, style, info, out num))
			{
				return false;
			}
			if (num < 0 || num > 255)
			{
				return false;
			}
			result = (byte)num;
			return true;
		}

		/// <summary>Converts the value of the current <see cref="T:System.Byte" /> object to its equivalent string representation.</summary>
		/// <returns>The string representation of the value of this object, which consists of a sequence of digits that range from 0 to 9 with no leading zeroes.</returns>
		// Token: 0x06000A6E RID: 2670 RVA: 0x000216D1 File Offset: 0x0001F8D1
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return Number.FormatInt32((int)this, null, NumberFormatInfo.CurrentInfo);
		}

		/// <summary>Converts the value of the current <see cref="T:System.Byte" /> object to its equivalent string representation using the specified format.</summary>
		/// <param name="format">A numeric format string.</param>
		/// <returns>The string representation of the current <see cref="T:System.Byte" /> object, formatted as specified by the <paramref name="format" /> parameter.</returns>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="format" /> includes an unsupported specifier. Supported format specifiers are listed in the Remarks section.</exception>
		// Token: 0x06000A6F RID: 2671 RVA: 0x000216E0 File Offset: 0x0001F8E0
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public string ToString(string format)
		{
			return Number.FormatInt32((int)this, format, NumberFormatInfo.CurrentInfo);
		}

		/// <summary>Converts the numeric value of the current <see cref="T:System.Byte" /> object to its equivalent string representation using the specified culture-specific formatting information.</summary>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <returns>The string representation of the value of this object in the format specified by the <paramref name="provider" /> parameter.</returns>
		// Token: 0x06000A70 RID: 2672 RVA: 0x000216EF File Offset: 0x0001F8EF
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public string ToString(IFormatProvider provider)
		{
			return Number.FormatInt32((int)this, null, NumberFormatInfo.GetInstance(provider));
		}

		/// <summary>Converts the value of the current <see cref="T:System.Byte" /> object to its equivalent string representation using the specified format and culture-specific formatting information.</summary>
		/// <param name="format">A standard or custom numeric format string.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <returns>The string representation of the current <see cref="T:System.Byte" /> object, formatted as specified by the <paramref name="format" /> and <paramref name="provider" /> parameters.</returns>
		/// <exception cref="T:System.FormatException">
		///   <paramref name="format" /> includes an unsupported specifier. Supported format specifiers are listed in the Remarks section.</exception>
		// Token: 0x06000A71 RID: 2673 RVA: 0x000216FF File Offset: 0x0001F8FF
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public string ToString(string format, IFormatProvider provider)
		{
			return Number.FormatInt32((int)this, format, NumberFormatInfo.GetInstance(provider));
		}

		/// <summary>Returns the <see cref="T:System.TypeCode" /> for value type <see cref="T:System.Byte" />.</summary>
		/// <returns>The enumerated constant, <see cref="F:System.TypeCode.Byte" />.</returns>
		// Token: 0x06000A72 RID: 2674 RVA: 0x0002170F File Offset: 0x0001F90F
		public TypeCode GetTypeCode()
		{
			return TypeCode.Byte;
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToBoolean(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>
		///   <see langword="true" /> if the value of the current instance is not zero; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000A73 RID: 2675 RVA: 0x00021712 File Offset: 0x0001F912
		[__DynamicallyInvokable]
		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToChar(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to a <see cref="T:System.Char" />.</returns>
		// Token: 0x06000A74 RID: 2676 RVA: 0x0002171B File Offset: 0x0001F91B
		[__DynamicallyInvokable]
		char IConvertible.ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToSByte(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to an <see cref="T:System.SByte" />.</returns>
		// Token: 0x06000A75 RID: 2677 RVA: 0x00021724 File Offset: 0x0001F924
		[__DynamicallyInvokable]
		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToByte(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, unchanged.</returns>
		// Token: 0x06000A76 RID: 2678 RVA: 0x0002172D File Offset: 0x0001F92D
		[__DynamicallyInvokable]
		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return this;
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToInt16(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to an <see cref="T:System.Int16" />.</returns>
		// Token: 0x06000A77 RID: 2679 RVA: 0x00021731 File Offset: 0x0001F931
		[__DynamicallyInvokable]
		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToUInt16(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to a <see cref="T:System.UInt16" />.</returns>
		// Token: 0x06000A78 RID: 2680 RVA: 0x0002173A File Offset: 0x0001F93A
		[__DynamicallyInvokable]
		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToInt32(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to an <see cref="T:System.Int32" />.</returns>
		// Token: 0x06000A79 RID: 2681 RVA: 0x00021743 File Offset: 0x0001F943
		[__DynamicallyInvokable]
		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return Convert.ToInt32(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToUInt32(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to a <see cref="T:System.UInt32" />.</returns>
		// Token: 0x06000A7A RID: 2682 RVA: 0x0002174C File Offset: 0x0001F94C
		[__DynamicallyInvokable]
		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToInt64(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to an <see cref="T:System.Int64" />.</returns>
		// Token: 0x06000A7B RID: 2683 RVA: 0x00021755 File Offset: 0x0001F955
		[__DynamicallyInvokable]
		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return Convert.ToInt64(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToUInt64(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to a <see cref="T:System.UInt64" />.</returns>
		// Token: 0x06000A7C RID: 2684 RVA: 0x0002175E File Offset: 0x0001F95E
		[__DynamicallyInvokable]
		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToSingle(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to a <see cref="T:System.Single" />.</returns>
		// Token: 0x06000A7D RID: 2685 RVA: 0x00021767 File Offset: 0x0001F967
		[__DynamicallyInvokable]
		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToDouble(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to a <see cref="T:System.Double" />.</returns>
		// Token: 0x06000A7E RID: 2686 RVA: 0x00021770 File Offset: 0x0001F970
		[__DynamicallyInvokable]
		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(this);
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToDecimal(System.IFormatProvider)" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>The value of the current instance, converted to a <see cref="T:System.Decimal" />.</returns>
		// Token: 0x06000A7F RID: 2687 RVA: 0x00021779 File Offset: 0x0001F979
		[__DynamicallyInvokable]
		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return Convert.ToDecimal(this);
		}

		/// <summary>This conversion is not supported. Attempting to use this method throws an <see cref="T:System.InvalidCastException" />.</summary>
		/// <param name="provider">This parameter is ignored.</param>
		/// <returns>This conversion is not supported. No value is returned.</returns>
		/// <exception cref="T:System.InvalidCastException">In all cases.</exception>
		// Token: 0x06000A80 RID: 2688 RVA: 0x00021782 File Offset: 0x0001F982
		[__DynamicallyInvokable]
		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", new object[]
			{
				"Byte",
				"DateTime"
			}));
		}

		/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToType(System.Type,System.IFormatProvider)" />.</summary>
		/// <param name="type">The type to which to convert this <see cref="T:System.Byte" /> value.</param>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> implementation that supplies information about the format of the returned value.</param>
		/// <returns>The value of the current instance, converted to <paramref name="type" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="type" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidCastException">The requested type conversion is not supported.</exception>
		// Token: 0x06000A81 RID: 2689 RVA: 0x000217A9 File Offset: 0x0001F9A9
		[__DynamicallyInvokable]
		object IConvertible.ToType(Type type, IFormatProvider provider)
		{
			return Convert.DefaultToType(this, type, provider);
		}

		// Token: 0x040003F4 RID: 1012
		private byte m_value;

		/// <summary>Represents the largest possible value of a <see cref="T:System.Byte" />. This field is constant.</summary>
		// Token: 0x040003F5 RID: 1013
		[__DynamicallyInvokable]
		public const byte MaxValue = 255;

		/// <summary>Represents the smallest possible value of a <see cref="T:System.Byte" />. This field is constant.</summary>
		// Token: 0x040003F6 RID: 1014
		[__DynamicallyInvokable]
		public const byte MinValue = 0;
	}
}

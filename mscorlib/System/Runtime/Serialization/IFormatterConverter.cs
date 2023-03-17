using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	/// <summary>Provides the connection between an instance of <see cref="T:System.Runtime.Serialization.SerializationInfo" /> and the formatter-provided class best suited to parse the data inside the <see cref="T:System.Runtime.Serialization.SerializationInfo" />.</summary>
	// Token: 0x02000706 RID: 1798
	[CLSCompliant(false)]
	[ComVisible(true)]
	public interface IFormatterConverter
	{
		/// <summary>Converts a value to the given <see cref="T:System.Type" />.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <param name="type">The <see cref="T:System.Type" /> into which <paramref name="value" /> is to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x0600508F RID: 20623
		object Convert(object value, Type type);

		/// <summary>Converts a value to the given <see cref="T:System.TypeCode" />.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <param name="typeCode">The <see cref="T:System.TypeCode" /> into which <paramref name="value" /> is to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005090 RID: 20624
		object Convert(object value, TypeCode typeCode);

		/// <summary>Converts a value to a <see cref="T:System.Boolean" />.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005091 RID: 20625
		bool ToBoolean(object value);

		/// <summary>Converts a value to a Unicode character.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005092 RID: 20626
		char ToChar(object value);

		/// <summary>Converts a value to a <see cref="T:System.SByte" />.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005093 RID: 20627
		sbyte ToSByte(object value);

		/// <summary>Converts a value to an 8-bit unsigned integer.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005094 RID: 20628
		byte ToByte(object value);

		/// <summary>Converts a value to a 16-bit signed integer.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005095 RID: 20629
		short ToInt16(object value);

		/// <summary>Converts a value to a 16-bit unsigned integer.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005096 RID: 20630
		ushort ToUInt16(object value);

		/// <summary>Converts a value to a 32-bit signed integer.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005097 RID: 20631
		int ToInt32(object value);

		/// <summary>Converts a value to a 32-bit unsigned integer.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005098 RID: 20632
		uint ToUInt32(object value);

		/// <summary>Converts a value to a 64-bit signed integer.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x06005099 RID: 20633
		long ToInt64(object value);

		/// <summary>Converts a value to a 64-bit unsigned integer.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x0600509A RID: 20634
		ulong ToUInt64(object value);

		/// <summary>Converts a value to a single-precision floating-point number.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x0600509B RID: 20635
		float ToSingle(object value);

		/// <summary>Converts a value to a double-precision floating-point number.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x0600509C RID: 20636
		double ToDouble(object value);

		/// <summary>Converts a value to a <see cref="T:System.Decimal" />.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x0600509D RID: 20637
		decimal ToDecimal(object value);

		/// <summary>Converts a value to a <see cref="T:System.DateTime" />.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x0600509E RID: 20638
		DateTime ToDateTime(object value);

		/// <summary>Converts a value to a <see cref="T:System.String" />.</summary>
		/// <param name="value">The object to be converted.</param>
		/// <returns>The converted <paramref name="value" />.</returns>
		// Token: 0x0600509F RID: 20639
		string ToString(object value);
	}
}

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x0200008D RID: 141
	[NullableContext(1)]
	[Nullable(0)]
	internal class JsonFormatterConverter : IFormatterConverter
	{
		// Token: 0x060006E3 RID: 1763 RVA: 0x0001CEAD File Offset: 0x0001B0AD
		public JsonFormatterConverter(JsonSerializerInternalReader reader, JsonISerializableContract contract, [Nullable(2)] JsonProperty member)
		{
			ValidationUtils.ArgumentNotNull(reader, "reader");
			ValidationUtils.ArgumentNotNull(contract, "contract");
			this._reader = reader;
			this._contract = contract;
			this._member = member;
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0001CEE0 File Offset: 0x0001B0E0
		private T GetTokenValue<[Nullable(2)] T>(object value)
		{
			ValidationUtils.ArgumentNotNull(value, "value");
			return (T)((object)System.Convert.ChangeType(((JValue)value).Value, typeof(T), CultureInfo.InvariantCulture));
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0001CF14 File Offset: 0x0001B114
		[return: Nullable(2)]
		public object Convert(object value, Type type)
		{
			ValidationUtils.ArgumentNotNull(value, "value");
			JToken jtoken = value as JToken;
			if (jtoken == null)
			{
				throw new ArgumentException("Value is not a JToken.", "value");
			}
			return this._reader.CreateISerializableItem(jtoken, type, this._contract, this._member);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0001CF60 File Offset: 0x0001B160
		public object Convert(object value, TypeCode typeCode)
		{
			ValidationUtils.ArgumentNotNull(value, "value");
			JValue jvalue = value as JValue;
			return System.Convert.ChangeType((jvalue != null) ? jvalue.Value : value, typeCode, CultureInfo.InvariantCulture);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0001CF96 File Offset: 0x0001B196
		public bool ToBoolean(object value)
		{
			return this.GetTokenValue<bool>(value);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0001CF9F File Offset: 0x0001B19F
		public byte ToByte(object value)
		{
			return this.GetTokenValue<byte>(value);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0001CFA8 File Offset: 0x0001B1A8
		public char ToChar(object value)
		{
			return this.GetTokenValue<char>(value);
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0001CFB1 File Offset: 0x0001B1B1
		public DateTime ToDateTime(object value)
		{
			return this.GetTokenValue<DateTime>(value);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0001CFBA File Offset: 0x0001B1BA
		public decimal ToDecimal(object value)
		{
			return this.GetTokenValue<decimal>(value);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0001CFC3 File Offset: 0x0001B1C3
		public double ToDouble(object value)
		{
			return this.GetTokenValue<double>(value);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0001CFCC File Offset: 0x0001B1CC
		public short ToInt16(object value)
		{
			return this.GetTokenValue<short>(value);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0001CFD5 File Offset: 0x0001B1D5
		public int ToInt32(object value)
		{
			return this.GetTokenValue<int>(value);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0001CFDE File Offset: 0x0001B1DE
		public long ToInt64(object value)
		{
			return this.GetTokenValue<long>(value);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0001CFE7 File Offset: 0x0001B1E7
		public sbyte ToSByte(object value)
		{
			return this.GetTokenValue<sbyte>(value);
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0001CFF0 File Offset: 0x0001B1F0
		public float ToSingle(object value)
		{
			return this.GetTokenValue<float>(value);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0001CFF9 File Offset: 0x0001B1F9
		public string ToString(object value)
		{
			return this.GetTokenValue<string>(value);
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0001D002 File Offset: 0x0001B202
		public ushort ToUInt16(object value)
		{
			return this.GetTokenValue<ushort>(value);
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x0001D00B File Offset: 0x0001B20B
		public uint ToUInt32(object value)
		{
			return this.GetTokenValue<uint>(value);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0001D014 File Offset: 0x0001B214
		public ulong ToUInt64(object value)
		{
			return this.GetTokenValue<ulong>(value);
		}

		// Token: 0x04000273 RID: 627
		private readonly JsonSerializerInternalReader _reader;

		// Token: 0x04000274 RID: 628
		private readonly JsonISerializableContract _contract;

		// Token: 0x04000275 RID: 629
		[Nullable(2)]
		private readonly JsonProperty _member;
	}
}

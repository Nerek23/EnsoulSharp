using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000E6 RID: 230
	[NullableContext(1)]
	[Nullable(0)]
	public class IsoDateTimeConverter : DateTimeConverterBase
	{
		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000C4B RID: 3147 RVA: 0x00031B97 File Offset: 0x0002FD97
		// (set) Token: 0x06000C4C RID: 3148 RVA: 0x00031B9F File Offset: 0x0002FD9F
		public DateTimeStyles DateTimeStyles
		{
			get
			{
				return this._dateTimeStyles;
			}
			set
			{
				this._dateTimeStyles = value;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000C4D RID: 3149 RVA: 0x00031BA8 File Offset: 0x0002FDA8
		// (set) Token: 0x06000C4E RID: 3150 RVA: 0x00031BB9 File Offset: 0x0002FDB9
		[Nullable(2)]
		public string DateTimeFormat
		{
			[NullableContext(2)]
			get
			{
				return this._dateTimeFormat ?? string.Empty;
			}
			[NullableContext(2)]
			set
			{
				this._dateTimeFormat = (StringUtils.IsNullOrEmpty(value) ? null : value);
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000C4F RID: 3151 RVA: 0x00031BCD File Offset: 0x0002FDCD
		// (set) Token: 0x06000C50 RID: 3152 RVA: 0x00031BDE File Offset: 0x0002FDDE
		public CultureInfo Culture
		{
			get
			{
				return this._culture ?? CultureInfo.CurrentCulture;
			}
			set
			{
				this._culture = value;
			}
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x00031BE8 File Offset: 0x0002FDE8
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
		{
			string value2;
			if (value is DateTime)
			{
				DateTime dateTime = (DateTime)value;
				if ((this._dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal || (this._dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
				{
					dateTime = dateTime.ToUniversalTime();
				}
				value2 = dateTime.ToString(this._dateTimeFormat ?? "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK", this.Culture);
			}
			else
			{
				if (!(value is DateTimeOffset))
				{
					throw new JsonSerializationException("Unexpected value when converting date. Expected DateTime or DateTimeOffset, got {0}.".FormatWith(CultureInfo.InvariantCulture, ReflectionUtils.GetObjectType(value)));
				}
				DateTimeOffset dateTimeOffset = (DateTimeOffset)value;
				if ((this._dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal || (this._dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
				{
					dateTimeOffset = dateTimeOffset.ToUniversalTime();
				}
				value2 = dateTimeOffset.ToString(this._dateTimeFormat ?? "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK", this.Culture);
			}
			writer.WriteValue(value2);
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00031CB8 File Offset: 0x0002FEB8
		[return: Nullable(2)]
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer)
		{
			bool flag = ReflectionUtils.IsNullableType(objectType);
			if (reader.TokenType == JsonToken.Null)
			{
				if (!flag)
				{
					throw JsonSerializationException.Create(reader, "Cannot convert null value to {0}.".FormatWith(CultureInfo.InvariantCulture, objectType));
				}
				return null;
			}
			else
			{
				Type left = flag ? Nullable.GetUnderlyingType(objectType) : objectType;
				if (reader.TokenType == JsonToken.Date)
				{
					if (left == typeof(DateTimeOffset))
					{
						if (!(reader.Value is DateTimeOffset))
						{
							return new DateTimeOffset((DateTime)reader.Value);
						}
						return reader.Value;
					}
					else
					{
						object value = reader.Value;
						if (value is DateTimeOffset)
						{
							return ((DateTimeOffset)value).DateTime;
						}
						return reader.Value;
					}
				}
				else
				{
					if (reader.TokenType != JsonToken.String)
					{
						throw JsonSerializationException.Create(reader, "Unexpected token parsing date. Expected String, got {0}.".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
					}
					object value2 = reader.Value;
					string text = (value2 != null) ? value2.ToString() : null;
					if (StringUtils.IsNullOrEmpty(text) && flag)
					{
						return null;
					}
					if (left == typeof(DateTimeOffset))
					{
						if (!StringUtils.IsNullOrEmpty(this._dateTimeFormat))
						{
							return DateTimeOffset.ParseExact(text, this._dateTimeFormat, this.Culture, this._dateTimeStyles);
						}
						return DateTimeOffset.Parse(text, this.Culture, this._dateTimeStyles);
					}
					else
					{
						if (!StringUtils.IsNullOrEmpty(this._dateTimeFormat))
						{
							return DateTime.ParseExact(text, this._dateTimeFormat, this.Culture, this._dateTimeStyles);
						}
						return DateTime.Parse(text, this.Culture, this._dateTimeStyles);
					}
				}
			}
		}

		// Token: 0x040003D9 RID: 985
		private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

		// Token: 0x040003DA RID: 986
		private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;

		// Token: 0x040003DB RID: 987
		[Nullable(2)]
		private string _dateTimeFormat;

		// Token: 0x040003DC RID: 988
		[Nullable(2)]
		private CultureInfo _culture;
	}
}

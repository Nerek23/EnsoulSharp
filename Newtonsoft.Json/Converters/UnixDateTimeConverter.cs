﻿using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000EB RID: 235
	[NullableContext(1)]
	[Nullable(0)]
	public class UnixDateTimeConverter : DateTimeConverterBase
	{
		// Token: 0x06000C76 RID: 3190 RVA: 0x00032830 File Offset: 0x00030A30
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
		{
			long num;
			if (value is DateTime)
			{
				num = (long)(((DateTime)value).ToUniversalTime() - UnixDateTimeConverter.UnixEpoch).TotalSeconds;
			}
			else
			{
				if (!(value is DateTimeOffset))
				{
					throw new JsonSerializationException("Expected date object value.");
				}
				num = (long)(((DateTimeOffset)value).ToUniversalTime() - UnixDateTimeConverter.UnixEpoch).TotalSeconds;
			}
			if (num < 0L)
			{
				throw new JsonSerializationException("Cannot convert date value that is before Unix epoch of 00:00:00 UTC on 1 January 1970.");
			}
			writer.WriteValue(num);
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x000328BC File Offset: 0x00030ABC
		[return: Nullable(2)]
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer)
		{
			bool flag = ReflectionUtils.IsNullable(objectType);
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
				long num;
				if (reader.TokenType == JsonToken.Integer)
				{
					num = (long)reader.Value;
				}
				else
				{
					if (reader.TokenType != JsonToken.String)
					{
						throw JsonSerializationException.Create(reader, "Unexpected token parsing date. Expected Integer or String, got {0}.".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
					}
					if (!long.TryParse((string)reader.Value, out num))
					{
						throw JsonSerializationException.Create(reader, "Cannot convert invalid value to {0}.".FormatWith(CultureInfo.InvariantCulture, objectType));
					}
				}
				if (num < 0L)
				{
					throw JsonSerializationException.Create(reader, "Cannot convert value that is before Unix epoch of 00:00:00 UTC on 1 January 1970 to {0}.".FormatWith(CultureInfo.InvariantCulture, objectType));
				}
				DateTime dateTime = UnixDateTimeConverter.UnixEpoch.AddSeconds((double)num);
				if ((flag ? Nullable.GetUnderlyingType(objectType) : objectType) == typeof(DateTimeOffset))
				{
					return new DateTimeOffset(dateTime, TimeSpan.Zero);
				}
				return dateTime;
			}
		}

		// Token: 0x040003E4 RID: 996
		internal static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	}
}

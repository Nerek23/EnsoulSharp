using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000DF RID: 223
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class CustomCreationConverter<[Nullable(2)] T> : JsonConverter
	{
		// Token: 0x06000C24 RID: 3108 RVA: 0x00030C31 File Offset: 0x0002EE31
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
		{
			throw new NotSupportedException("CustomCreationConverter should only be used while deserializing.");
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x00030C40 File Offset: 0x0002EE40
		[return: Nullable(2)]
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}
			T t = this.Create(objectType);
			if (t == null)
			{
				throw new JsonSerializationException("No object created.");
			}
			serializer.Populate(reader, t);
			return t;
		}

		// Token: 0x06000C26 RID: 3110
		public abstract T Create(Type objectType);

		// Token: 0x06000C27 RID: 3111 RVA: 0x00030C88 File Offset: 0x0002EE88
		public override bool CanConvert(Type objectType)
		{
			return typeof(T).IsAssignableFrom(objectType);
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x00030C9A File Offset: 0x0002EE9A
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}
	}
}

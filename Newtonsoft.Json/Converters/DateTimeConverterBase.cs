using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000E2 RID: 226
	public abstract class DateTimeConverterBase : JsonConverter
	{
		// Token: 0x06000C34 RID: 3124 RVA: 0x00031248 File Offset: 0x0002F448
		[NullableContext(1)]
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime) || objectType == typeof(DateTime?) || (objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?));
		}
	}
}

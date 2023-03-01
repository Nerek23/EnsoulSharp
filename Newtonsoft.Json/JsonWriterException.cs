using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Newtonsoft.Json
{
	// Token: 0x02000033 RID: 51
	[NullableContext(1)]
	[Nullable(0)]
	[Serializable]
	public class JsonWriterException : JsonException
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x00010149 File Offset: 0x0000E349
		[Nullable(2)]
		public string Path { [NullableContext(2)] get; }

		// Token: 0x06000415 RID: 1045 RVA: 0x00010151 File Offset: 0x0000E351
		public JsonWriterException()
		{
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00010159 File Offset: 0x0000E359
		public JsonWriterException(string message) : base(message)
		{
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00010162 File Offset: 0x0000E362
		public JsonWriterException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0001016C File Offset: 0x0000E36C
		public JsonWriterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00010176 File Offset: 0x0000E376
		public JsonWriterException(string message, string path, [Nullable(2)] Exception innerException) : base(message, innerException)
		{
			this.Path = path;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00010187 File Offset: 0x0000E387
		internal static JsonWriterException Create(JsonWriter writer, string message, [Nullable(2)] Exception ex)
		{
			return JsonWriterException.Create(writer.ContainerPath, message, ex);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00010196 File Offset: 0x0000E396
		internal static JsonWriterException Create(string path, string message, [Nullable(2)] Exception ex)
		{
			message = JsonPosition.FormatMessage(null, path, message);
			return new JsonWriterException(message, path, ex);
		}
	}
}

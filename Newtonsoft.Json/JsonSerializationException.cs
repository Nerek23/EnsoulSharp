using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Newtonsoft.Json
{
	// Token: 0x0200002A RID: 42
	[NullableContext(1)]
	[Nullable(0)]
	[Serializable]
	public class JsonSerializationException : JsonException
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00004BE4 File Offset: 0x00002DE4
		public int LineNumber { get; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00004BEC File Offset: 0x00002DEC
		public int LinePosition { get; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00004BF4 File Offset: 0x00002DF4
		[Nullable(2)]
		public string Path { [NullableContext(2)] get; }

		// Token: 0x06000137 RID: 311 RVA: 0x00004BFC File Offset: 0x00002DFC
		public JsonSerializationException()
		{
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00004C04 File Offset: 0x00002E04
		public JsonSerializationException(string message) : base(message)
		{
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00004C0D File Offset: 0x00002E0D
		public JsonSerializationException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00004C17 File Offset: 0x00002E17
		public JsonSerializationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00004C21 File Offset: 0x00002E21
		public JsonSerializationException(string message, string path, int lineNumber, int linePosition, [Nullable(2)] Exception innerException) : base(message, innerException)
		{
			this.Path = path;
			this.LineNumber = lineNumber;
			this.LinePosition = linePosition;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00004C42 File Offset: 0x00002E42
		internal static JsonSerializationException Create(JsonReader reader, string message)
		{
			return JsonSerializationException.Create(reader, message, null);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00004C4C File Offset: 0x00002E4C
		internal static JsonSerializationException Create(JsonReader reader, string message, [Nullable(2)] Exception ex)
		{
			return JsonSerializationException.Create(reader as IJsonLineInfo, reader.Path, message, ex);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00004C64 File Offset: 0x00002E64
		internal static JsonSerializationException Create([Nullable(2)] IJsonLineInfo lineInfo, string path, string message, [Nullable(2)] Exception ex)
		{
			message = JsonPosition.FormatMessage(lineInfo, path, message);
			int lineNumber;
			int linePosition;
			if (lineInfo != null && lineInfo.HasLineInfo())
			{
				lineNumber = lineInfo.LineNumber;
				linePosition = lineInfo.LinePosition;
			}
			else
			{
				lineNumber = 0;
				linePosition = 0;
			}
			return new JsonSerializationException(message, path, lineNumber, linePosition, ex);
		}
	}
}

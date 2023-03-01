using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Newtonsoft.Json
{
	// Token: 0x02000028 RID: 40
	[NullableContext(1)]
	[Nullable(0)]
	[Serializable]
	public class JsonReaderException : JsonException
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00004B1E File Offset: 0x00002D1E
		public int LineNumber { get; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00004B26 File Offset: 0x00002D26
		public int LinePosition { get; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00004B2E File Offset: 0x00002D2E
		[Nullable(2)]
		public string Path { [NullableContext(2)] get; }

		// Token: 0x0600012B RID: 299 RVA: 0x00004B36 File Offset: 0x00002D36
		public JsonReaderException()
		{
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004B3E File Offset: 0x00002D3E
		public JsonReaderException(string message) : base(message)
		{
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00004B47 File Offset: 0x00002D47
		public JsonReaderException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00004B51 File Offset: 0x00002D51
		public JsonReaderException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004B5B File Offset: 0x00002D5B
		public JsonReaderException(string message, string path, int lineNumber, int linePosition, [Nullable(2)] Exception innerException) : base(message, innerException)
		{
			this.Path = path;
			this.LineNumber = lineNumber;
			this.LinePosition = linePosition;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00004B7C File Offset: 0x00002D7C
		internal static JsonReaderException Create(JsonReader reader, string message)
		{
			return JsonReaderException.Create(reader, message, null);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00004B86 File Offset: 0x00002D86
		internal static JsonReaderException Create(JsonReader reader, string message, [Nullable(2)] Exception ex)
		{
			return JsonReaderException.Create(reader as IJsonLineInfo, reader.Path, message, ex);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00004B9C File Offset: 0x00002D9C
		internal static JsonReaderException Create([Nullable(2)] IJsonLineInfo lineInfo, string path, string message, [Nullable(2)] Exception ex)
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
			return new JsonReaderException(message, path, lineNumber, linePosition, ex);
		}
	}
}

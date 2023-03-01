using System;
using System.Runtime.Serialization;

namespace Newtonsoft.Json.Schema
{
	// Token: 0x020000A9 RID: 169
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	[Serializable]
	public class JsonSchemaException : JsonException
	{
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x00025F07 File Offset: 0x00024107
		public int LineNumber { get; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x00025F0F File Offset: 0x0002410F
		public int LinePosition { get; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00025F17 File Offset: 0x00024117
		public string Path { get; }

		// Token: 0x060008F9 RID: 2297 RVA: 0x00025F1F File Offset: 0x0002411F
		public JsonSchemaException()
		{
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00025F27 File Offset: 0x00024127
		public JsonSchemaException(string message) : base(message)
		{
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00025F30 File Offset: 0x00024130
		public JsonSchemaException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00025F3A File Offset: 0x0002413A
		public JsonSchemaException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00025F44 File Offset: 0x00024144
		internal JsonSchemaException(string message, Exception innerException, string path, int lineNumber, int linePosition) : base(message, innerException)
		{
			this.Path = path;
			this.LineNumber = lineNumber;
			this.LinePosition = linePosition;
		}
	}
}

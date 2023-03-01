using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x020000A3 RID: 163
	[NullableContext(1)]
	[Nullable(0)]
	internal class TraceJsonReader : JsonReader, IJsonLineInfo
	{
		// Token: 0x0600083F RID: 2111 RVA: 0x00023DB4 File Offset: 0x00021FB4
		public TraceJsonReader(JsonReader innerReader)
		{
			this._innerReader = innerReader;
			this._sw = new StringWriter(CultureInfo.InvariantCulture);
			this._sw.Write("Deserialized JSON: " + Environment.NewLine);
			this._textWriter = new JsonTextWriter(this._sw);
			this._textWriter.Formatting = Formatting.Indented;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00023E15 File Offset: 0x00022015
		public string GetDeserializedJsonMessage()
		{
			return this._sw.ToString();
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00023E22 File Offset: 0x00022022
		public override bool Read()
		{
			bool result = this._innerReader.Read();
			this.WriteCurrentToken();
			return result;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00023E35 File Offset: 0x00022035
		public override int? ReadAsInt32()
		{
			int? result = this._innerReader.ReadAsInt32();
			this.WriteCurrentToken();
			return result;
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00023E48 File Offset: 0x00022048
		[NullableContext(2)]
		public override string ReadAsString()
		{
			string result = this._innerReader.ReadAsString();
			this.WriteCurrentToken();
			return result;
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00023E5B File Offset: 0x0002205B
		[NullableContext(2)]
		public override byte[] ReadAsBytes()
		{
			byte[] result = this._innerReader.ReadAsBytes();
			this.WriteCurrentToken();
			return result;
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x00023E6E File Offset: 0x0002206E
		public override decimal? ReadAsDecimal()
		{
			decimal? result = this._innerReader.ReadAsDecimal();
			this.WriteCurrentToken();
			return result;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00023E81 File Offset: 0x00022081
		public override double? ReadAsDouble()
		{
			double? result = this._innerReader.ReadAsDouble();
			this.WriteCurrentToken();
			return result;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00023E94 File Offset: 0x00022094
		public override bool? ReadAsBoolean()
		{
			bool? result = this._innerReader.ReadAsBoolean();
			this.WriteCurrentToken();
			return result;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00023EA7 File Offset: 0x000220A7
		public override DateTime? ReadAsDateTime()
		{
			DateTime? result = this._innerReader.ReadAsDateTime();
			this.WriteCurrentToken();
			return result;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00023EBA File Offset: 0x000220BA
		public override DateTimeOffset? ReadAsDateTimeOffset()
		{
			DateTimeOffset? result = this._innerReader.ReadAsDateTimeOffset();
			this.WriteCurrentToken();
			return result;
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x00023ECD File Offset: 0x000220CD
		public void WriteCurrentToken()
		{
			this._textWriter.WriteToken(this._innerReader, false, false, true);
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x00023EE3 File Offset: 0x000220E3
		public override int Depth
		{
			get
			{
				return this._innerReader.Depth;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x00023EF0 File Offset: 0x000220F0
		public override string Path
		{
			get
			{
				return this._innerReader.Path;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x00023EFD File Offset: 0x000220FD
		// (set) Token: 0x0600084E RID: 2126 RVA: 0x00023F0A File Offset: 0x0002210A
		public override char QuoteChar
		{
			get
			{
				return this._innerReader.QuoteChar;
			}
			protected internal set
			{
				this._innerReader.QuoteChar = value;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x00023F18 File Offset: 0x00022118
		public override JsonToken TokenType
		{
			get
			{
				return this._innerReader.TokenType;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x00023F25 File Offset: 0x00022125
		[Nullable(2)]
		public override object Value
		{
			[NullableContext(2)]
			get
			{
				return this._innerReader.Value;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x00023F32 File Offset: 0x00022132
		[Nullable(2)]
		public override Type ValueType
		{
			[NullableContext(2)]
			get
			{
				return this._innerReader.ValueType;
			}
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00023F3F File Offset: 0x0002213F
		public override void Close()
		{
			this._innerReader.Close();
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00023F4C File Offset: 0x0002214C
		bool IJsonLineInfo.HasLineInfo()
		{
			IJsonLineInfo jsonLineInfo = this._innerReader as IJsonLineInfo;
			return jsonLineInfo != null && jsonLineInfo.HasLineInfo();
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x00023F70 File Offset: 0x00022170
		int IJsonLineInfo.LineNumber
		{
			get
			{
				IJsonLineInfo jsonLineInfo = this._innerReader as IJsonLineInfo;
				if (jsonLineInfo == null)
				{
					return 0;
				}
				return jsonLineInfo.LineNumber;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000855 RID: 2133 RVA: 0x00023F94 File Offset: 0x00022194
		int IJsonLineInfo.LinePosition
		{
			get
			{
				IJsonLineInfo jsonLineInfo = this._innerReader as IJsonLineInfo;
				if (jsonLineInfo == null)
				{
					return 0;
				}
				return jsonLineInfo.LinePosition;
			}
		}

		// Token: 0x040002CA RID: 714
		private readonly JsonReader _innerReader;

		// Token: 0x040002CB RID: 715
		private readonly JsonTextWriter _textWriter;

		// Token: 0x040002CC RID: 716
		private readonly StringWriter _sw;
	}
}

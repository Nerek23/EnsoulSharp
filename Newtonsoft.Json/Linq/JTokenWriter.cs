using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000C8 RID: 200
	[NullableContext(2)]
	[Nullable(0)]
	public class JTokenWriter : JsonWriter
	{
		// Token: 0x06000B6B RID: 2923 RVA: 0x0002D765 File Offset: 0x0002B965
		[NullableContext(1)]
		internal override Task WriteTokenAsync(JsonReader reader, bool writeChildren, bool writeDateConstructorAsDate, bool writeComments, CancellationToken cancellationToken)
		{
			if (reader is JTokenReader)
			{
				this.WriteToken(reader, writeChildren, writeDateConstructorAsDate, writeComments);
				return AsyncUtils.CompletedTask;
			}
			return base.WriteTokenSyncReadingAsync(reader, cancellationToken);
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x0002D789 File Offset: 0x0002B989
		public JToken CurrentToken
		{
			get
			{
				return this._current;
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000B6D RID: 2925 RVA: 0x0002D791 File Offset: 0x0002B991
		public JToken Token
		{
			get
			{
				if (this._token != null)
				{
					return this._token;
				}
				return this._value;
			}
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x0002D7A8 File Offset: 0x0002B9A8
		[NullableContext(1)]
		public JTokenWriter(JContainer container)
		{
			ValidationUtils.ArgumentNotNull(container, "container");
			this._token = container;
			this._parent = container;
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x0002D7C9 File Offset: 0x0002B9C9
		public JTokenWriter()
		{
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x0002D7D1 File Offset: 0x0002B9D1
		public override void Flush()
		{
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0002D7D3 File Offset: 0x0002B9D3
		public override void Close()
		{
			base.Close();
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0002D7DB File Offset: 0x0002B9DB
		public override void WriteStartObject()
		{
			base.WriteStartObject();
			this.AddParent(new JObject());
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0002D7EE File Offset: 0x0002B9EE
		[NullableContext(1)]
		private void AddParent(JContainer container)
		{
			if (this._parent == null)
			{
				this._token = container;
			}
			else
			{
				this._parent.AddAndSkipParentCheck(container);
			}
			this._parent = container;
			this._current = container;
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0002D81C File Offset: 0x0002BA1C
		private void RemoveParent()
		{
			this._current = this._parent;
			this._parent = this._parent.Parent;
			if (this._parent != null && this._parent.Type == JTokenType.Property)
			{
				this._parent = this._parent.Parent;
			}
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x0002D86D File Offset: 0x0002BA6D
		public override void WriteStartArray()
		{
			base.WriteStartArray();
			this.AddParent(new JArray());
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x0002D880 File Offset: 0x0002BA80
		[NullableContext(1)]
		public override void WriteStartConstructor(string name)
		{
			base.WriteStartConstructor(name);
			this.AddParent(new JConstructor(name));
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x0002D895 File Offset: 0x0002BA95
		protected override void WriteEnd(JsonToken token)
		{
			this.RemoveParent();
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x0002D89D File Offset: 0x0002BA9D
		[NullableContext(1)]
		public override void WritePropertyName(string name)
		{
			JObject jobject = this._parent as JObject;
			if (jobject != null)
			{
				jobject.Remove(name);
			}
			this.AddParent(new JProperty(name));
			base.WritePropertyName(name);
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x0002D8CA File Offset: 0x0002BACA
		private void AddValue(object value, JsonToken token)
		{
			this.AddValue(new JValue(value), token);
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x0002D8DC File Offset: 0x0002BADC
		internal void AddValue(JValue value, JsonToken token)
		{
			if (this._parent != null)
			{
				this._parent.Add(value);
				this._current = this._parent.Last;
				if (this._parent.Type == JTokenType.Property)
				{
					this._parent = this._parent.Parent;
					return;
				}
			}
			else
			{
				this._value = (value ?? JValue.CreateNull());
				this._current = this._value;
			}
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0002D94A File Offset: 0x0002BB4A
		public override void WriteValue(object value)
		{
			if (value is BigInteger)
			{
				base.InternalWriteValue(JsonToken.Integer);
				this.AddValue(value, JsonToken.Integer);
				return;
			}
			base.WriteValue(value);
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0002D96B File Offset: 0x0002BB6B
		public override void WriteNull()
		{
			base.WriteNull();
			this.AddValue(null, JsonToken.Null);
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0002D97C File Offset: 0x0002BB7C
		public override void WriteUndefined()
		{
			base.WriteUndefined();
			this.AddValue(null, JsonToken.Undefined);
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0002D98D File Offset: 0x0002BB8D
		public override void WriteRaw(string json)
		{
			base.WriteRaw(json);
			this.AddValue(new JRaw(json), JsonToken.Raw);
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x0002D9A3 File Offset: 0x0002BBA3
		public override void WriteComment(string text)
		{
			base.WriteComment(text);
			this.AddValue(JValue.CreateComment(text), JsonToken.Comment);
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x0002D9B9 File Offset: 0x0002BBB9
		public override void WriteValue(string value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.String);
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0002D9CB File Offset: 0x0002BBCB
		public override void WriteValue(int value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Integer);
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x0002D9E1 File Offset: 0x0002BBE1
		[CLSCompliant(false)]
		public override void WriteValue(uint value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Integer);
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0002D9F7 File Offset: 0x0002BBF7
		public override void WriteValue(long value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Integer);
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0002DA0D File Offset: 0x0002BC0D
		[CLSCompliant(false)]
		public override void WriteValue(ulong value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Integer);
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0002DA23 File Offset: 0x0002BC23
		public override void WriteValue(float value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Float);
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x0002DA39 File Offset: 0x0002BC39
		public override void WriteValue(double value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Float);
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0002DA4F File Offset: 0x0002BC4F
		public override void WriteValue(bool value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Boolean);
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x0002DA66 File Offset: 0x0002BC66
		public override void WriteValue(short value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Integer);
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x0002DA7C File Offset: 0x0002BC7C
		[CLSCompliant(false)]
		public override void WriteValue(ushort value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Integer);
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x0002DA94 File Offset: 0x0002BC94
		public override void WriteValue(char value)
		{
			base.WriteValue(value);
			string value2 = value.ToString(CultureInfo.InvariantCulture);
			this.AddValue(value2, JsonToken.String);
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0002DABE File Offset: 0x0002BCBE
		public override void WriteValue(byte value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Integer);
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x0002DAD4 File Offset: 0x0002BCD4
		[CLSCompliant(false)]
		public override void WriteValue(sbyte value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Integer);
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x0002DAEA File Offset: 0x0002BCEA
		public override void WriteValue(decimal value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Float);
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x0002DB00 File Offset: 0x0002BD00
		public override void WriteValue(DateTime value)
		{
			base.WriteValue(value);
			value = DateTimeUtils.EnsureDateTime(value, base.DateTimeZoneHandling);
			this.AddValue(value, JsonToken.Date);
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0002DB25 File Offset: 0x0002BD25
		public override void WriteValue(DateTimeOffset value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Date);
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0002DB3C File Offset: 0x0002BD3C
		public override void WriteValue(byte[] value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.Bytes);
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x0002DB4E File Offset: 0x0002BD4E
		public override void WriteValue(TimeSpan value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.String);
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x0002DB65 File Offset: 0x0002BD65
		public override void WriteValue(Guid value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.String);
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0002DB7C File Offset: 0x0002BD7C
		public override void WriteValue(Uri value)
		{
			base.WriteValue(value);
			this.AddValue(value, JsonToken.String);
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0002DB90 File Offset: 0x0002BD90
		[NullableContext(1)]
		internal override void WriteToken(JsonReader reader, bool writeChildren, bool writeDateConstructorAsDate, bool writeComments)
		{
			JTokenReader jtokenReader = reader as JTokenReader;
			if (jtokenReader == null || !writeChildren || !writeDateConstructorAsDate || !writeComments)
			{
				base.WriteToken(reader, writeChildren, writeDateConstructorAsDate, writeComments);
				return;
			}
			if (jtokenReader.TokenType == JsonToken.None && !jtokenReader.Read())
			{
				return;
			}
			JToken jtoken = jtokenReader.CurrentToken.CloneToken();
			if (this._parent != null)
			{
				this._parent.Add(jtoken);
				this._current = this._parent.Last;
				if (this._parent.Type == JTokenType.Property)
				{
					this._parent = this._parent.Parent;
					base.InternalWriteValue(JsonToken.Null);
				}
			}
			else
			{
				this._current = jtoken;
				if (this._token == null && this._value == null)
				{
					this._token = (jtoken as JContainer);
					this._value = (jtoken as JValue);
				}
			}
			jtokenReader.Skip();
		}

		// Token: 0x0400039A RID: 922
		private JContainer _token;

		// Token: 0x0400039B RID: 923
		private JContainer _parent;

		// Token: 0x0400039C RID: 924
		private JValue _value;

		// Token: 0x0400039D RID: 925
		private JToken _current;
	}
}

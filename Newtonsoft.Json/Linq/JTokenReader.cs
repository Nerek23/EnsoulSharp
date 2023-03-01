using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000C6 RID: 198
	[NullableContext(1)]
	[Nullable(0)]
	public class JTokenReader : JsonReader, IJsonLineInfo
	{
		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0002D24C File Offset: 0x0002B44C
		[Nullable(2)]
		public JToken CurrentToken
		{
			[NullableContext(2)]
			get
			{
				return this._current;
			}
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0002D254 File Offset: 0x0002B454
		public JTokenReader(JToken token)
		{
			ValidationUtils.ArgumentNotNull(token, "token");
			this._root = token;
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x0002D26E File Offset: 0x0002B46E
		public JTokenReader(JToken token, string initialPath) : this(token)
		{
			this._initialPath = initialPath;
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x0002D280 File Offset: 0x0002B480
		public override bool Read()
		{
			if (base.CurrentState != JsonReader.State.Start)
			{
				if (this._current == null)
				{
					return false;
				}
				JContainer jcontainer = this._current as JContainer;
				if (jcontainer != null && this._parent != jcontainer)
				{
					return this.ReadInto(jcontainer);
				}
				return this.ReadOver(this._current);
			}
			else
			{
				if (this._current == this._root)
				{
					return false;
				}
				this._current = this._root;
				this.SetToken(this._current);
				return true;
			}
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x0002D2F8 File Offset: 0x0002B4F8
		private bool ReadOver(JToken t)
		{
			if (t == this._root)
			{
				return this.ReadToEnd();
			}
			JToken next = t.Next;
			if (next != null && next != t && t != t.Parent.Last)
			{
				this._current = next;
				this.SetToken(this._current);
				return true;
			}
			if (t.Parent == null)
			{
				return this.ReadToEnd();
			}
			return this.SetEnd(t.Parent);
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x0002D361 File Offset: 0x0002B561
		private bool ReadToEnd()
		{
			this._current = null;
			base.SetToken(JsonToken.None);
			return false;
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0002D374 File Offset: 0x0002B574
		private JsonToken? GetEndToken(JContainer c)
		{
			switch (c.Type)
			{
			case JTokenType.Object:
				return new JsonToken?(JsonToken.EndObject);
			case JTokenType.Array:
				return new JsonToken?(JsonToken.EndArray);
			case JTokenType.Constructor:
				return new JsonToken?(JsonToken.EndConstructor);
			case JTokenType.Property:
				return null;
			default:
				throw MiscellaneousUtils.CreateArgumentOutOfRangeException("Type", c.Type, "Unexpected JContainer type.");
			}
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x0002D3E0 File Offset: 0x0002B5E0
		private bool ReadInto(JContainer c)
		{
			JToken first = c.First;
			if (first == null)
			{
				return this.SetEnd(c);
			}
			this.SetToken(first);
			this._current = first;
			this._parent = c;
			return true;
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x0002D418 File Offset: 0x0002B618
		private bool SetEnd(JContainer c)
		{
			JsonToken? endToken = this.GetEndToken(c);
			if (endToken != null)
			{
				base.SetToken(endToken.GetValueOrDefault());
				this._current = c;
				this._parent = c;
				return true;
			}
			return this.ReadOver(c);
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x0002D45C File Offset: 0x0002B65C
		private void SetToken(JToken token)
		{
			switch (token.Type)
			{
			case JTokenType.Object:
				base.SetToken(JsonToken.StartObject);
				return;
			case JTokenType.Array:
				base.SetToken(JsonToken.StartArray);
				return;
			case JTokenType.Constructor:
				base.SetToken(JsonToken.StartConstructor, ((JConstructor)token).Name);
				return;
			case JTokenType.Property:
				base.SetToken(JsonToken.PropertyName, ((JProperty)token).Name);
				return;
			case JTokenType.Comment:
				base.SetToken(JsonToken.Comment, ((JValue)token).Value);
				return;
			case JTokenType.Integer:
				base.SetToken(JsonToken.Integer, ((JValue)token).Value);
				return;
			case JTokenType.Float:
				base.SetToken(JsonToken.Float, ((JValue)token).Value);
				return;
			case JTokenType.String:
				base.SetToken(JsonToken.String, ((JValue)token).Value);
				return;
			case JTokenType.Boolean:
				base.SetToken(JsonToken.Boolean, ((JValue)token).Value);
				return;
			case JTokenType.Null:
				base.SetToken(JsonToken.Null, ((JValue)token).Value);
				return;
			case JTokenType.Undefined:
				base.SetToken(JsonToken.Undefined, ((JValue)token).Value);
				return;
			case JTokenType.Date:
			{
				object obj = ((JValue)token).Value;
				if (obj is DateTime)
				{
					DateTime value = (DateTime)obj;
					obj = DateTimeUtils.EnsureDateTime(value, base.DateTimeZoneHandling);
				}
				base.SetToken(JsonToken.Date, obj);
				return;
			}
			case JTokenType.Raw:
				base.SetToken(JsonToken.Raw, ((JValue)token).Value);
				return;
			case JTokenType.Bytes:
				base.SetToken(JsonToken.Bytes, ((JValue)token).Value);
				return;
			case JTokenType.Guid:
				base.SetToken(JsonToken.String, this.SafeToString(((JValue)token).Value));
				return;
			case JTokenType.Uri:
			{
				object value2 = ((JValue)token).Value;
				JsonToken newToken = JsonToken.String;
				Uri uri = value2 as Uri;
				base.SetToken(newToken, (uri != null) ? uri.OriginalString : this.SafeToString(value2));
				return;
			}
			case JTokenType.TimeSpan:
				base.SetToken(JsonToken.String, this.SafeToString(((JValue)token).Value));
				return;
			default:
				throw MiscellaneousUtils.CreateArgumentOutOfRangeException("Type", token.Type, "Unexpected JTokenType.");
			}
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0002D65D File Offset: 0x0002B85D
		[NullableContext(2)]
		private string SafeToString(object value)
		{
			if (value == null)
			{
				return null;
			}
			return value.ToString();
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x0002D66C File Offset: 0x0002B86C
		bool IJsonLineInfo.HasLineInfo()
		{
			if (base.CurrentState == JsonReader.State.Start)
			{
				return false;
			}
			IJsonLineInfo current = this._current;
			return current != null && current.HasLineInfo();
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000B68 RID: 2920 RVA: 0x0002D698 File Offset: 0x0002B898
		int IJsonLineInfo.LineNumber
		{
			get
			{
				if (base.CurrentState == JsonReader.State.Start)
				{
					return 0;
				}
				IJsonLineInfo current = this._current;
				if (current != null)
				{
					return current.LineNumber;
				}
				return 0;
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x0002D6C4 File Offset: 0x0002B8C4
		int IJsonLineInfo.LinePosition
		{
			get
			{
				if (base.CurrentState == JsonReader.State.Start)
				{
					return 0;
				}
				IJsonLineInfo current = this._current;
				if (current != null)
				{
					return current.LinePosition;
				}
				return 0;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000B6A RID: 2922 RVA: 0x0002D6F0 File Offset: 0x0002B8F0
		public override string Path
		{
			get
			{
				string text = base.Path;
				if (this._initialPath == null)
				{
					this._initialPath = this._root.Path;
				}
				if (!StringUtils.IsNullOrEmpty(this._initialPath))
				{
					if (StringUtils.IsNullOrEmpty(text))
					{
						return this._initialPath;
					}
					if (text.StartsWith('['))
					{
						text = this._initialPath + text;
					}
					else
					{
						text = this._initialPath + "." + text;
					}
				}
				return text;
			}
		}

		// Token: 0x04000383 RID: 899
		private readonly JToken _root;

		// Token: 0x04000384 RID: 900
		[Nullable(2)]
		private string _initialPath;

		// Token: 0x04000385 RID: 901
		[Nullable(2)]
		private JToken _parent;

		// Token: 0x04000386 RID: 902
		[Nullable(2)]
		private JToken _current;
	}
}

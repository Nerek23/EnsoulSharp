using System;
using System.Collections;
using System.Text;
using System.Xml;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout
{
	// Token: 0x02000074 RID: 116
	public class XmlLayout : XmlLayoutBase
	{
		// Token: 0x060003B7 RID: 951 RVA: 0x0000C244 File Offset: 0x0000B244
		public XmlLayout()
		{
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000C2A4 File Offset: 0x0000B2A4
		public XmlLayout(bool locationInfo) : base(locationInfo)
		{
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x0000C305 File Offset: 0x0000B305
		// (set) Token: 0x060003BA RID: 954 RVA: 0x0000C30D File Offset: 0x0000B30D
		public string Prefix
		{
			get
			{
				return this.m_prefix;
			}
			set
			{
				this.m_prefix = value;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060003BB RID: 955 RVA: 0x0000C316 File Offset: 0x0000B316
		// (set) Token: 0x060003BC RID: 956 RVA: 0x0000C31E File Offset: 0x0000B31E
		public bool Base64EncodeMessage
		{
			get
			{
				return this.m_base64Message;
			}
			set
			{
				this.m_base64Message = value;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060003BD RID: 957 RVA: 0x0000C327 File Offset: 0x0000B327
		// (set) Token: 0x060003BE RID: 958 RVA: 0x0000C32F File Offset: 0x0000B32F
		public bool Base64EncodeProperties
		{
			get
			{
				return this.m_base64Properties;
			}
			set
			{
				this.m_base64Properties = value;
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000C338 File Offset: 0x0000B338
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			if (this.m_prefix != null && this.m_prefix.Length > 0)
			{
				this.m_elmEvent = this.m_prefix + ":event";
				this.m_elmMessage = this.m_prefix + ":message";
				this.m_elmProperties = this.m_prefix + ":properties";
				this.m_elmData = this.m_prefix + ":data";
				this.m_elmException = this.m_prefix + ":exception";
				this.m_elmLocation = this.m_prefix + ":locationInfo";
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0000C3EC File Offset: 0x0000B3EC
		protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
		{
			writer.WriteStartElement(this.m_elmEvent);
			writer.WriteAttributeString("logger", loggingEvent.LoggerName);
			writer.WriteAttributeString("timestamp", XmlConvert.ToString(loggingEvent.TimeStamp, XmlDateTimeSerializationMode.Local));
			writer.WriteAttributeString("level", loggingEvent.Level.DisplayName);
			writer.WriteAttributeString("thread", loggingEvent.ThreadName);
			if (loggingEvent.Domain != null && loggingEvent.Domain.Length > 0)
			{
				writer.WriteAttributeString("domain", loggingEvent.Domain);
			}
			if (loggingEvent.Identity != null && loggingEvent.Identity.Length > 0)
			{
				writer.WriteAttributeString("identity", loggingEvent.Identity);
			}
			if (loggingEvent.UserName != null && loggingEvent.UserName.Length > 0)
			{
				writer.WriteAttributeString("username", loggingEvent.UserName);
			}
			writer.WriteStartElement(this.m_elmMessage);
			if (!this.Base64EncodeMessage)
			{
				Transform.WriteEscapedXmlString(writer, loggingEvent.RenderedMessage, base.InvalidCharReplacement);
			}
			else
			{
				byte[] bytes = Encoding.UTF8.GetBytes(loggingEvent.RenderedMessage);
				string textData = Convert.ToBase64String(bytes, 0, bytes.Length);
				Transform.WriteEscapedXmlString(writer, textData, base.InvalidCharReplacement);
			}
			writer.WriteEndElement();
			PropertiesDictionary properties = loggingEvent.GetProperties();
			if (properties.Count > 0)
			{
				writer.WriteStartElement(this.m_elmProperties);
				foreach (object obj in ((IEnumerable)properties))
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					writer.WriteStartElement(this.m_elmData);
					writer.WriteAttributeString("name", Transform.MaskXmlInvalidCharacters((string)dictionaryEntry.Key, base.InvalidCharReplacement));
					string value;
					if (!this.Base64EncodeProperties)
					{
						value = Transform.MaskXmlInvalidCharacters(loggingEvent.Repository.RendererMap.FindAndRender(dictionaryEntry.Value), base.InvalidCharReplacement);
					}
					else
					{
						byte[] bytes2 = Encoding.UTF8.GetBytes(loggingEvent.Repository.RendererMap.FindAndRender(dictionaryEntry.Value));
						value = Convert.ToBase64String(bytes2, 0, bytes2.Length);
					}
					writer.WriteAttributeString("value", value);
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
			}
			string exceptionString = loggingEvent.GetExceptionString();
			if (exceptionString != null && exceptionString.Length > 0)
			{
				writer.WriteStartElement(this.m_elmException);
				Transform.WriteEscapedXmlString(writer, exceptionString, base.InvalidCharReplacement);
				writer.WriteEndElement();
			}
			if (base.LocationInfo)
			{
				LocationInfo locationInformation = loggingEvent.LocationInformation;
				writer.WriteStartElement(this.m_elmLocation);
				writer.WriteAttributeString("class", locationInformation.ClassName);
				writer.WriteAttributeString("method", locationInformation.MethodName);
				writer.WriteAttributeString("file", locationInformation.FileName);
				writer.WriteAttributeString("line", locationInformation.LineNumber);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}

		// Token: 0x040000DF RID: 223
		private string m_prefix = "log4net";

		// Token: 0x040000E0 RID: 224
		private string m_elmEvent = "event";

		// Token: 0x040000E1 RID: 225
		private string m_elmMessage = "message";

		// Token: 0x040000E2 RID: 226
		private string m_elmData = "data";

		// Token: 0x040000E3 RID: 227
		private string m_elmProperties = "properties";

		// Token: 0x040000E4 RID: 228
		private string m_elmException = "exception";

		// Token: 0x040000E5 RID: 229
		private string m_elmLocation = "locationInfo";

		// Token: 0x040000E6 RID: 230
		private bool m_base64Message;

		// Token: 0x040000E7 RID: 231
		private bool m_base64Properties;

		// Token: 0x040000E8 RID: 232
		private const string PREFIX = "log4net";

		// Token: 0x040000E9 RID: 233
		private const string ELM_EVENT = "event";

		// Token: 0x040000EA RID: 234
		private const string ELM_MESSAGE = "message";

		// Token: 0x040000EB RID: 235
		private const string ELM_PROPERTIES = "properties";

		// Token: 0x040000EC RID: 236
		private const string ELM_GLOBAL_PROPERTIES = "global-properties";

		// Token: 0x040000ED RID: 237
		private const string ELM_DATA = "data";

		// Token: 0x040000EE RID: 238
		private const string ELM_EXCEPTION = "exception";

		// Token: 0x040000EF RID: 239
		private const string ELM_LOCATION = "locationInfo";

		// Token: 0x040000F0 RID: 240
		private const string ATTR_LOGGER = "logger";

		// Token: 0x040000F1 RID: 241
		private const string ATTR_TIMESTAMP = "timestamp";

		// Token: 0x040000F2 RID: 242
		private const string ATTR_LEVEL = "level";

		// Token: 0x040000F3 RID: 243
		private const string ATTR_THREAD = "thread";

		// Token: 0x040000F4 RID: 244
		private const string ATTR_DOMAIN = "domain";

		// Token: 0x040000F5 RID: 245
		private const string ATTR_IDENTITY = "identity";

		// Token: 0x040000F6 RID: 246
		private const string ATTR_USERNAME = "username";

		// Token: 0x040000F7 RID: 247
		private const string ATTR_CLASS = "class";

		// Token: 0x040000F8 RID: 248
		private const string ATTR_METHOD = "method";

		// Token: 0x040000F9 RID: 249
		private const string ATTR_FILE = "file";

		// Token: 0x040000FA RID: 250
		private const string ATTR_LINE = "line";

		// Token: 0x040000FB RID: 251
		private const string ATTR_NAME = "name";

		// Token: 0x040000FC RID: 252
		private const string ATTR_VALUE = "value";
	}
}

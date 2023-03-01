using System;
using System.IO;
using System.Xml;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout
{
	// Token: 0x02000075 RID: 117
	public abstract class XmlLayoutBase : LayoutSkeleton
	{
		// Token: 0x060003C1 RID: 961 RVA: 0x0000C6D8 File Offset: 0x0000B6D8
		protected XmlLayoutBase() : this(false)
		{
			this.IgnoresException = false;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000C6E8 File Offset: 0x0000B6E8
		protected XmlLayoutBase(bool locationInfo)
		{
			this.IgnoresException = false;
			this.m_locationInfo = locationInfo;
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000C709 File Offset: 0x0000B709
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x0000C711 File Offset: 0x0000B711
		public bool LocationInfo
		{
			get
			{
				return this.m_locationInfo;
			}
			set
			{
				this.m_locationInfo = value;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0000C71A File Offset: 0x0000B71A
		// (set) Token: 0x060003C6 RID: 966 RVA: 0x0000C722 File Offset: 0x0000B722
		public string InvalidCharReplacement
		{
			get
			{
				return this.m_invalidCharReplacement;
			}
			set
			{
				this.m_invalidCharReplacement = value;
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000C72B File Offset: 0x0000B72B
		public override void ActivateOptions()
		{
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0000C72D File Offset: 0x0000B72D
		public override string ContentType
		{
			get
			{
				return "text/xml";
			}
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000C734 File Offset: 0x0000B734
		public override void Format(TextWriter writer, LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			using (XmlTextWriter xmlTextWriter = new XmlTextWriter(new ProtectCloseTextWriter(writer)))
			{
				xmlTextWriter.Formatting = Formatting.None;
				xmlTextWriter.Namespaces = false;
				this.FormatXml(xmlTextWriter, loggingEvent);
				xmlTextWriter.WriteWhitespace(SystemInfo.NewLine);
			}
		}

		// Token: 0x060003CA RID: 970
		protected abstract void FormatXml(XmlWriter writer, LoggingEvent loggingEvent);

		// Token: 0x040000FD RID: 253
		private bool m_locationInfo;

		// Token: 0x040000FE RID: 254
		private string m_invalidCharReplacement = "?";
	}
}

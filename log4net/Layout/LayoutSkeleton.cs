using System;
using System.Globalization;
using System.IO;
using log4net.Core;

namespace log4net.Layout
{
	// Token: 0x0200006D RID: 109
	public abstract class LayoutSkeleton : ILayout, IOptionHandler
	{
		// Token: 0x06000395 RID: 917
		public abstract void ActivateOptions();

		// Token: 0x06000396 RID: 918
		public abstract void Format(TextWriter writer, LoggingEvent loggingEvent);

		// Token: 0x06000397 RID: 919 RVA: 0x0000B958 File Offset: 0x0000A958
		public string Format(LoggingEvent loggingEvent)
		{
			string result;
			using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
			{
				this.Format(stringWriter, loggingEvent);
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000398 RID: 920 RVA: 0x0000B99C File Offset: 0x0000A99C
		public virtual string ContentType
		{
			get
			{
				return "text/plain";
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000399 RID: 921 RVA: 0x0000B9A3 File Offset: 0x0000A9A3
		// (set) Token: 0x0600039A RID: 922 RVA: 0x0000B9AB File Offset: 0x0000A9AB
		public virtual string Header
		{
			get
			{
				return this.m_header;
			}
			set
			{
				this.m_header = value;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600039B RID: 923 RVA: 0x0000B9B4 File Offset: 0x0000A9B4
		// (set) Token: 0x0600039C RID: 924 RVA: 0x0000B9BC File Offset: 0x0000A9BC
		public virtual string Footer
		{
			get
			{
				return this.m_footer;
			}
			set
			{
				this.m_footer = value;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600039D RID: 925 RVA: 0x0000B9C5 File Offset: 0x0000A9C5
		// (set) Token: 0x0600039E RID: 926 RVA: 0x0000B9CD File Offset: 0x0000A9CD
		public virtual bool IgnoresException
		{
			get
			{
				return this.m_ignoresException;
			}
			set
			{
				this.m_ignoresException = value;
			}
		}

		// Token: 0x040000D5 RID: 213
		private string m_header;

		// Token: 0x040000D6 RID: 214
		private string m_footer;

		// Token: 0x040000D7 RID: 215
		private bool m_ignoresException = true;
	}
}

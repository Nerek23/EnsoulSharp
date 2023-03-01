using System;
using System.IO;
using log4net.Core;
using log4net.DateFormatter;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000042 RID: 66
	internal class DatePatternConverter : PatternConverter, IOptionHandler
	{
		// Token: 0x06000257 RID: 599 RVA: 0x000075B0 File Offset: 0x000065B0
		public void ActivateOptions()
		{
			string text = this.Option;
			if (text == null)
			{
				text = "ISO8601";
			}
			if (SystemInfo.EqualsIgnoringCase(text, "ISO8601"))
			{
				this.m_dateFormatter = new Iso8601DateFormatter();
				return;
			}
			if (SystemInfo.EqualsIgnoringCase(text, "ABSOLUTE"))
			{
				this.m_dateFormatter = new AbsoluteTimeDateFormatter();
				return;
			}
			if (SystemInfo.EqualsIgnoringCase(text, "DATE"))
			{
				this.m_dateFormatter = new DateTimeDateFormatter();
				return;
			}
			try
			{
				this.m_dateFormatter = new SimpleDateFormatter(text);
			}
			catch (Exception exception)
			{
				LogLog.Error(DatePatternConverter.declaringType, "Could not instantiate SimpleDateFormatter with [" + text + "]", exception);
				this.m_dateFormatter = new Iso8601DateFormatter();
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00007660 File Offset: 0x00006660
		protected override void Convert(TextWriter writer, object state)
		{
			try
			{
				this.m_dateFormatter.FormatDate(DateTime.Now, writer);
			}
			catch (Exception exception)
			{
				LogLog.Error(DatePatternConverter.declaringType, "Error occurred while converting date.", exception);
			}
		}

		// Token: 0x0400007F RID: 127
		protected IDateFormatter m_dateFormatter;

		// Token: 0x04000080 RID: 128
		private static readonly Type declaringType = typeof(DatePatternConverter);
	}
}

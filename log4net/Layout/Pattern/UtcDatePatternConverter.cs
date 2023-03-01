using System;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000091 RID: 145
	internal class UtcDatePatternConverter : DatePatternConverter
	{
		// Token: 0x06000413 RID: 1043 RVA: 0x0000D49C File Offset: 0x0000C49C
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			try
			{
				this.m_dateFormatter.FormatDate(loggingEvent.TimeStampUtc, writer);
			}
			catch (Exception exception)
			{
				LogLog.Error(UtcDatePatternConverter.declaringType, "Error occurred while converting date.", exception);
			}
		}

		// Token: 0x04000109 RID: 265
		private static readonly Type declaringType = typeof(UtcDatePatternConverter);
	}
}

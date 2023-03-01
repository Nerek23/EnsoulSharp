using System;
using System.IO;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x0200004C RID: 76
	internal class UtcDatePatternConverter : DatePatternConverter
	{
		// Token: 0x06000276 RID: 630 RVA: 0x00007C14 File Offset: 0x00006C14
		protected override void Convert(TextWriter writer, object state)
		{
			try
			{
				this.m_dateFormatter.FormatDate(DateTime.UtcNow, writer);
			}
			catch (Exception exception)
			{
				LogLog.Error(UtcDatePatternConverter.declaringType, "Error occurred while converting date.", exception);
			}
		}

		// Token: 0x04000089 RID: 137
		private static readonly Type declaringType = typeof(UtcDatePatternConverter);
	}
}

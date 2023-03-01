using System;
using System.Globalization;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200008B RID: 139
	internal sealed class RelativeTimePatternConverter : PatternLayoutConverter
	{
		// Token: 0x06000402 RID: 1026 RVA: 0x0000D1E8 File Offset: 0x0000C1E8
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(RelativeTimePatternConverter.TimeDifferenceInMillis(LoggingEvent.StartTimeUtc, loggingEvent.TimeStampUtc).ToString(NumberFormatInfo.InvariantInfo));
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0000D218 File Offset: 0x0000C218
		private static long TimeDifferenceInMillis(DateTime start, DateTime end)
		{
			return (long)(end.ToUniversalTime() - start.ToUniversalTime()).TotalMilliseconds;
		}
	}
}

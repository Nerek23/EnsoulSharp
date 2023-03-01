using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200008E RID: 142
	internal sealed class ThreadPatternConverter : PatternLayoutConverter
	{
		// Token: 0x0600040D RID: 1037 RVA: 0x0000D443 File Offset: 0x0000C443
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(loggingEvent.ThreadName);
		}
	}
}

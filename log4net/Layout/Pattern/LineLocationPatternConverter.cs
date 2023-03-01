using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000083 RID: 131
	internal sealed class LineLocationPatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003EC RID: 1004 RVA: 0x0000CF73 File Offset: 0x0000BF73
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(loggingEvent.LocationInformation.LineNumber);
		}
	}
}

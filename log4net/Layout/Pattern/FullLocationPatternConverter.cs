using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000080 RID: 128
	internal sealed class FullLocationPatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003E6 RID: 998 RVA: 0x0000CF27 File Offset: 0x0000BF27
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(loggingEvent.LocationInformation.FullInfo);
		}
	}
}

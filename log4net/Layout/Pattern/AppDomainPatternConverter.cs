using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000077 RID: 119
	internal sealed class AppDomainPatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003D1 RID: 977 RVA: 0x0000CB07 File Offset: 0x0000BB07
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(loggingEvent.Domain);
		}
	}
}

using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000082 RID: 130
	internal sealed class LevelPatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003EA RID: 1002 RVA: 0x0000CF58 File Offset: 0x0000BF58
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(loggingEvent.Level.DisplayName);
		}
	}
}

using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200007F RID: 127
	internal sealed class FileLocationPatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003E4 RID: 996 RVA: 0x0000CF0C File Offset: 0x0000BF0C
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(loggingEvent.LocationInformation.FileName);
		}
	}
}

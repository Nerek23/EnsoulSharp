using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000090 RID: 144
	internal sealed class UserNamePatternConverter : PatternLayoutConverter
	{
		// Token: 0x06000411 RID: 1041 RVA: 0x0000D485 File Offset: 0x0000C485
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(loggingEvent.UserName);
		}
	}
}

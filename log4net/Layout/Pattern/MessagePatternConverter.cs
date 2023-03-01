using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000085 RID: 133
	internal sealed class MessagePatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003F0 RID: 1008 RVA: 0x0000CF9E File Offset: 0x0000BF9E
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			loggingEvent.WriteRenderedMessage(writer);
		}
	}
}

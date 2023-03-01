using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000081 RID: 129
	internal sealed class IdentityPatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003E8 RID: 1000 RVA: 0x0000CF42 File Offset: 0x0000BF42
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(loggingEvent.Identity);
		}
	}
}

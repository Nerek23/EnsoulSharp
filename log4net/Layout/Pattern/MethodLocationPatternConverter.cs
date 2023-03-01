using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000086 RID: 134
	internal sealed class MethodLocationPatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003F2 RID: 1010 RVA: 0x0000CFAF File Offset: 0x0000BFAF
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(loggingEvent.LocationInformation.MethodName);
		}
	}
}

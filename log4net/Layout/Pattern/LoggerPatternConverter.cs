using System;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000084 RID: 132
	internal sealed class LoggerPatternConverter : NamedPatternConverter
	{
		// Token: 0x060003EE RID: 1006 RVA: 0x0000CF8E File Offset: 0x0000BF8E
		protected override string GetFullyQualifiedName(LoggingEvent loggingEvent)
		{
			return loggingEvent.LoggerName;
		}
	}
}

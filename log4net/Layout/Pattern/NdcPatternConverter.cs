using System;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000088 RID: 136
	internal sealed class NdcPatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003F9 RID: 1017 RVA: 0x0000D11F File Offset: 0x0000C11F
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			PatternConverter.WriteObject(writer, loggingEvent.Repository, loggingEvent.LookupProperty("NDC"));
		}
	}
}

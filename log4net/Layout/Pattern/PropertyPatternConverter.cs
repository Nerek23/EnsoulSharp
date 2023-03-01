using System;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200008A RID: 138
	internal sealed class PropertyPatternConverter : PatternLayoutConverter
	{
		// Token: 0x06000400 RID: 1024 RVA: 0x0000D1A8 File Offset: 0x0000C1A8
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			if (this.Option != null)
			{
				PatternConverter.WriteObject(writer, loggingEvent.Repository, loggingEvent.LookupProperty(this.Option));
				return;
			}
			PatternConverter.WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
		}
	}
}

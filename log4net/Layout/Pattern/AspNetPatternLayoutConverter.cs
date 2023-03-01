using System;
using System.IO;
using System.Web;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200007A RID: 122
	internal abstract class AspNetPatternLayoutConverter : PatternLayoutConverter
	{
		// Token: 0x060003D7 RID: 983 RVA: 0x0000CBC5 File Offset: 0x0000BBC5
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			if (HttpContext.Current == null)
			{
				writer.Write(SystemInfo.NotAvailableText);
				return;
			}
			this.Convert(writer, loggingEvent, HttpContext.Current);
		}

		// Token: 0x060003D8 RID: 984
		protected abstract void Convert(TextWriter writer, LoggingEvent loggingEvent, HttpContext httpContext);
	}
}

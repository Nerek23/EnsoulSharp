using System;
using System.IO;
using System.Web;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200007C RID: 124
	internal sealed class AspNetSessionPatternConverter : AspNetPatternLayoutConverter
	{
		// Token: 0x060003DC RID: 988 RVA: 0x0000CC74 File Offset: 0x0000BC74
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent, HttpContext httpContext)
		{
			if (httpContext.Session == null)
			{
				writer.Write(SystemInfo.NotAvailableText);
				return;
			}
			if (this.Option != null)
			{
				PatternConverter.WriteObject(writer, loggingEvent.Repository, httpContext.Session.Contents[this.Option]);
				return;
			}
			PatternConverter.WriteObject(writer, loggingEvent.Repository, httpContext.Session);
		}
	}
}

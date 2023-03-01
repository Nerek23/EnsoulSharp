using System;
using System.IO;
using System.Web;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200007B RID: 123
	internal sealed class AspNetRequestPatternConverter : AspNetPatternLayoutConverter
	{
		// Token: 0x060003DA RID: 986 RVA: 0x0000CBF0 File Offset: 0x0000BBF0
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent, HttpContext httpContext)
		{
			HttpRequest httpRequest = null;
			try
			{
				httpRequest = httpContext.Request;
			}
			catch (HttpException)
			{
			}
			if (httpRequest == null)
			{
				writer.Write(SystemInfo.NotAvailableText);
				return;
			}
			if (this.Option != null)
			{
				PatternConverter.WriteObject(writer, loggingEvent.Repository, httpContext.Request.Params[this.Option]);
				return;
			}
			PatternConverter.WriteObject(writer, loggingEvent.Repository, httpContext.Request.Params);
		}
	}
}

using System;
using System.IO;
using System.Web;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000078 RID: 120
	internal sealed class AspNetCachePatternConverter : AspNetPatternLayoutConverter
	{
		// Token: 0x060003D3 RID: 979 RVA: 0x0000CB20 File Offset: 0x0000BB20
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent, HttpContext httpContext)
		{
			if (HttpRuntime.Cache == null)
			{
				writer.Write(SystemInfo.NotAvailableText);
				return;
			}
			if (this.Option != null)
			{
				PatternConverter.WriteObject(writer, loggingEvent.Repository, HttpRuntime.Cache[this.Option]);
				return;
			}
			PatternConverter.WriteObject(writer, loggingEvent.Repository, HttpRuntime.Cache.GetEnumerator());
		}
	}
}

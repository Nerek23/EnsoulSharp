using System;
using System.IO;
using System.Web;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000079 RID: 121
	internal sealed class AspNetContextPatternConverter : AspNetPatternLayoutConverter
	{
		// Token: 0x060003D5 RID: 981 RVA: 0x0000CB83 File Offset: 0x0000BB83
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent, HttpContext httpContext)
		{
			if (this.Option != null)
			{
				PatternConverter.WriteObject(writer, loggingEvent.Repository, httpContext.Items[this.Option]);
				return;
			}
			PatternConverter.WriteObject(writer, loggingEvent.Repository, httpContext.Items);
		}
	}
}

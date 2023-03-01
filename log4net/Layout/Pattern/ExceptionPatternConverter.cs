using System;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200007E RID: 126
	internal sealed class ExceptionPatternConverter : PatternLayoutConverter
	{
		// Token: 0x060003E2 RID: 994 RVA: 0x0000CDE9 File Offset: 0x0000BDE9
		public ExceptionPatternConverter()
		{
			this.IgnoresException = false;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000CDF8 File Offset: 0x0000BDF8
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			if (loggingEvent.ExceptionObject == null || this.Option == null || this.Option.Length <= 0)
			{
				string exceptionString = loggingEvent.GetExceptionString();
				if (exceptionString != null && exceptionString.Length > 0)
				{
					writer.WriteLine(exceptionString);
				}
				return;
			}
			string a = this.Option.ToLower();
			if (a == "message")
			{
				PatternConverter.WriteObject(writer, loggingEvent.Repository, loggingEvent.ExceptionObject.Message);
				return;
			}
			if (a == "source")
			{
				PatternConverter.WriteObject(writer, loggingEvent.Repository, loggingEvent.ExceptionObject.Source);
				return;
			}
			if (a == "stacktrace")
			{
				PatternConverter.WriteObject(writer, loggingEvent.Repository, loggingEvent.ExceptionObject.StackTrace);
				return;
			}
			if (a == "targetsite")
			{
				PatternConverter.WriteObject(writer, loggingEvent.Repository, loggingEvent.ExceptionObject.TargetSite);
				return;
			}
			if (!(a == "helplink"))
			{
				return;
			}
			PatternConverter.WriteObject(writer, loggingEvent.Repository, loggingEvent.ExceptionObject.HelpLink);
		}
	}
}

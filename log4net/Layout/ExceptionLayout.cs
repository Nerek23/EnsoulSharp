using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout
{
	// Token: 0x02000069 RID: 105
	public class ExceptionLayout : LayoutSkeleton
	{
		// Token: 0x06000389 RID: 905 RVA: 0x0000B8BE File Offset: 0x0000A8BE
		public ExceptionLayout()
		{
			this.IgnoresException = false;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000B8CD File Offset: 0x0000A8CD
		public override void ActivateOptions()
		{
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000B8CF File Offset: 0x0000A8CF
		public override void Format(TextWriter writer, LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			writer.Write(loggingEvent.GetExceptionString());
		}
	}
}

using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout
{
	// Token: 0x02000073 RID: 115
	public class SimpleLayout : LayoutSkeleton
	{
		// Token: 0x060003B4 RID: 948 RVA: 0x0000C1F7 File Offset: 0x0000B1F7
		public SimpleLayout()
		{
			this.IgnoresException = true;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000C206 File Offset: 0x0000B206
		public override void ActivateOptions()
		{
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000C208 File Offset: 0x0000B208
		public override void Format(TextWriter writer, LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			writer.Write(loggingEvent.Level.DisplayName);
			writer.Write(" - ");
			loggingEvent.WriteRenderedMessage(writer);
			writer.WriteLine();
		}
	}
}

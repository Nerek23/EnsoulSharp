using System;
using log4net.Core;
using log4net.Layout;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000D9 RID: 217
	public class ConsoleAppender : AppenderSkeleton
	{
		// Token: 0x0600068E RID: 1678 RVA: 0x00014C31 File Offset: 0x00013C31
		public ConsoleAppender()
		{
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00014C39 File Offset: 0x00013C39
		[Obsolete("Instead use the default constructor and set the Layout property")]
		public ConsoleAppender(ILayout layout) : this(layout, false)
		{
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00014C43 File Offset: 0x00013C43
		[Obsolete("Instead use the default constructor and set the Layout & Target properties")]
		public ConsoleAppender(ILayout layout, bool writeToErrorStream)
		{
			this.Layout = layout;
			this.m_writeToErrorStream = writeToErrorStream;
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x00014C59 File Offset: 0x00013C59
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x00014C70 File Offset: 0x00013C70
		public virtual string Target
		{
			get
			{
				if (!this.m_writeToErrorStream)
				{
					return "Console.Out";
				}
				return "Console.Error";
			}
			set
			{
				string b = value.Trim();
				if (SystemInfo.EqualsIgnoringCase("Console.Error", b))
				{
					this.m_writeToErrorStream = true;
					return;
				}
				this.m_writeToErrorStream = false;
			}
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00014CA0 File Offset: 0x00013CA0
		protected override void Append(LoggingEvent loggingEvent)
		{
			if (this.m_writeToErrorStream)
			{
				Console.Error.Write(base.RenderLoggingEvent(loggingEvent));
				return;
			}
			Console.Write(base.RenderLoggingEvent(loggingEvent));
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000694 RID: 1684 RVA: 0x00014CC8 File Offset: 0x00013CC8
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x040001E9 RID: 489
		public const string ConsoleOut = "Console.Out";

		// Token: 0x040001EA RID: 490
		public const string ConsoleError = "Console.Error";

		// Token: 0x040001EB RID: 491
		private bool m_writeToErrorStream;
	}
}

using System;
using System.Diagnostics;
using log4net.Core;
using log4net.Layout;

namespace log4net.Appender
{
	// Token: 0x020000ED RID: 237
	public class TraceAppender : AppenderSkeleton
	{
		// Token: 0x060007A9 RID: 1961 RVA: 0x0001869D File Offset: 0x0001769D
		public TraceAppender()
		{
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x000186BC File Offset: 0x000176BC
		[Obsolete("Instead use the default constructor and set the Layout property")]
		public TraceAppender(ILayout layout)
		{
			this.Layout = layout;
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x000186E2 File Offset: 0x000176E2
		// (set) Token: 0x060007AC RID: 1964 RVA: 0x000186EA File Offset: 0x000176EA
		public bool ImmediateFlush
		{
			get
			{
				return this.m_immediateFlush;
			}
			set
			{
				this.m_immediateFlush = value;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x000186F3 File Offset: 0x000176F3
		// (set) Token: 0x060007AE RID: 1966 RVA: 0x000186FB File Offset: 0x000176FB
		public PatternLayout Category
		{
			get
			{
				return this.m_category;
			}
			set
			{
				this.m_category = value;
			}
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00018704 File Offset: 0x00017704
		protected override void Append(LoggingEvent loggingEvent)
		{
			Trace.Write(base.RenderLoggingEvent(loggingEvent), this.m_category.Format(loggingEvent));
			if (this.m_immediateFlush)
			{
				Trace.Flush();
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0001872B File Offset: 0x0001772B
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0001872E File Offset: 0x0001772E
		public override bool Flush(int millisecondsTimeout)
		{
			if (this.m_immediateFlush)
			{
				return true;
			}
			Trace.Flush();
			return true;
		}

		// Token: 0x04000248 RID: 584
		private bool m_immediateFlush = true;

		// Token: 0x04000249 RID: 585
		private PatternLayout m_category = new PatternLayout("%logger");
	}
}

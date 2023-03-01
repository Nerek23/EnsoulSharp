using System;
using System.Web;
using log4net.Core;
using log4net.Layout;

namespace log4net.Appender
{
	// Token: 0x020000D5 RID: 213
	public class AspNetTraceAppender : AppenderSkeleton
	{
		// Token: 0x0600065D RID: 1629 RVA: 0x00014398 File Offset: 0x00013398
		protected override void Append(LoggingEvent loggingEvent)
		{
			if (HttpContext.Current != null && HttpContext.Current.Trace.IsEnabled)
			{
				if (loggingEvent.Level >= Level.Warn)
				{
					HttpContext.Current.Trace.Warn(this.m_category.Format(loggingEvent), base.RenderLoggingEvent(loggingEvent));
					return;
				}
				HttpContext.Current.Trace.Write(this.m_category.Format(loggingEvent), base.RenderLoggingEvent(loggingEvent));
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x00014414 File Offset: 0x00013414
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x00014417 File Offset: 0x00013417
		// (set) Token: 0x06000660 RID: 1632 RVA: 0x0001441F File Offset: 0x0001341F
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

		// Token: 0x040001D7 RID: 471
		private PatternLayout m_category = new PatternLayout("%logger");
	}
}

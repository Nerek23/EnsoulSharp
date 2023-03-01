using System;
using System.Diagnostics;
using log4net.Core;
using log4net.Layout;

namespace log4net.Appender
{
	// Token: 0x020000DA RID: 218
	public class DebugAppender : AppenderSkeleton
	{
		// Token: 0x06000695 RID: 1685 RVA: 0x00014CCB File Offset: 0x00013CCB
		public DebugAppender()
		{
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00014CEA File Offset: 0x00013CEA
		[Obsolete("Instead use the default constructor and set the Layout property")]
		public DebugAppender(ILayout layout)
		{
			this.Layout = layout;
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x00014D10 File Offset: 0x00013D10
		// (set) Token: 0x06000698 RID: 1688 RVA: 0x00014D18 File Offset: 0x00013D18
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

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x00014D21 File Offset: 0x00013D21
		// (set) Token: 0x0600069A RID: 1690 RVA: 0x00014D29 File Offset: 0x00013D29
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

		// Token: 0x0600069B RID: 1691 RVA: 0x00014D32 File Offset: 0x00013D32
		public override bool Flush(int millisecondsTimeout)
		{
			if (this.m_immediateFlush)
			{
				return true;
			}
			Debug.Flush();
			return true;
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00014D44 File Offset: 0x00013D44
		protected override void Append(LoggingEvent loggingEvent)
		{
			if (this.m_category == null)
			{
				Debug.Write(base.RenderLoggingEvent(loggingEvent));
			}
			else
			{
				string text = this.m_category.Format(loggingEvent);
				if (string.IsNullOrEmpty(text))
				{
					Debug.Write(base.RenderLoggingEvent(loggingEvent));
				}
				else
				{
					Debug.Write(base.RenderLoggingEvent(loggingEvent), text);
				}
			}
			if (this.m_immediateFlush)
			{
				Debug.Flush();
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x00014DA4 File Offset: 0x00013DA4
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x040001EC RID: 492
		private bool m_immediateFlush = true;

		// Token: 0x040001ED RID: 493
		private PatternLayout m_category = new PatternLayout("%logger");
	}
}

using System;
using log4net.Core;

namespace log4net.Filter
{
	// Token: 0x02000094 RID: 148
	public abstract class FilterSkeleton : IFilter, IOptionHandler
	{
		// Token: 0x06000418 RID: 1048 RVA: 0x0000D504 File Offset: 0x0000C504
		public virtual void ActivateOptions()
		{
		}

		// Token: 0x06000419 RID: 1049
		public abstract FilterDecision Decide(LoggingEvent loggingEvent);

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000D506 File Offset: 0x0000C506
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x0000D50E File Offset: 0x0000C50E
		public IFilter Next
		{
			get
			{
				return this.m_next;
			}
			set
			{
				this.m_next = value;
			}
		}

		// Token: 0x0400010E RID: 270
		private IFilter m_next;
	}
}

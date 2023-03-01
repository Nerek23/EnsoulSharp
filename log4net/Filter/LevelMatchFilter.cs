using System;
using log4net.Core;

namespace log4net.Filter
{
	// Token: 0x02000096 RID: 150
	public class LevelMatchFilter : FilterSkeleton
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x0000D52E File Offset: 0x0000C52E
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x0000D536 File Offset: 0x0000C536
		public bool AcceptOnMatch
		{
			get
			{
				return this.m_acceptOnMatch;
			}
			set
			{
				this.m_acceptOnMatch = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0000D53F File Offset: 0x0000C53F
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x0000D547 File Offset: 0x0000C547
		public Level LevelToMatch
		{
			get
			{
				return this.m_levelToMatch;
			}
			set
			{
				this.m_levelToMatch = value;
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000D550 File Offset: 0x0000C550
		public override FilterDecision Decide(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			if (!(this.m_levelToMatch != null) || !(this.m_levelToMatch == loggingEvent.Level))
			{
				return FilterDecision.Neutral;
			}
			if (!this.m_acceptOnMatch)
			{
				return FilterDecision.Deny;
			}
			return FilterDecision.Accept;
		}

		// Token: 0x0400010F RID: 271
		private bool m_acceptOnMatch = true;

		// Token: 0x04000110 RID: 272
		private Level m_levelToMatch;
	}
}

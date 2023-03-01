using System;
using log4net.Core;

namespace log4net.Filter
{
	// Token: 0x02000097 RID: 151
	public class LevelRangeFilter : FilterSkeleton
	{
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0000D59D File Offset: 0x0000C59D
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x0000D5A5 File Offset: 0x0000C5A5
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

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0000D5AE File Offset: 0x0000C5AE
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x0000D5B6 File Offset: 0x0000C5B6
		public Level LevelMin
		{
			get
			{
				return this.m_levelMin;
			}
			set
			{
				this.m_levelMin = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0000D5BF File Offset: 0x0000C5BF
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x0000D5C7 File Offset: 0x0000C5C7
		public Level LevelMax
		{
			get
			{
				return this.m_levelMax;
			}
			set
			{
				this.m_levelMax = value;
			}
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000D5D0 File Offset: 0x0000C5D0
		public override FilterDecision Decide(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			if (this.m_levelMin != null && loggingEvent.Level < this.m_levelMin)
			{
				return FilterDecision.Deny;
			}
			if (this.m_levelMax != null && loggingEvent.Level > this.m_levelMax)
			{
				return FilterDecision.Deny;
			}
			if (this.m_acceptOnMatch)
			{
				return FilterDecision.Accept;
			}
			return FilterDecision.Neutral;
		}

		// Token: 0x04000111 RID: 273
		private bool m_acceptOnMatch = true;

		// Token: 0x04000112 RID: 274
		private Level m_levelMin;

		// Token: 0x04000113 RID: 275
		private Level m_levelMax;
	}
}

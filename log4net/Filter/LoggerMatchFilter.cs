using System;
using log4net.Core;

namespace log4net.Filter
{
	// Token: 0x02000098 RID: 152
	public class LoggerMatchFilter : FilterSkeleton
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x0000D64B File Offset: 0x0000C64B
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x0000D653 File Offset: 0x0000C653
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

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000D65C File Offset: 0x0000C65C
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x0000D664 File Offset: 0x0000C664
		public string LoggerToMatch
		{
			get
			{
				return this.m_loggerToMatch;
			}
			set
			{
				this.m_loggerToMatch = value;
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0000D670 File Offset: 0x0000C670
		public override FilterDecision Decide(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			if (this.m_loggerToMatch == null || this.m_loggerToMatch.Length == 0 || !loggingEvent.LoggerName.StartsWith(this.m_loggerToMatch))
			{
				return FilterDecision.Neutral;
			}
			if (this.m_acceptOnMatch)
			{
				return FilterDecision.Accept;
			}
			return FilterDecision.Deny;
		}

		// Token: 0x04000114 RID: 276
		private bool m_acceptOnMatch = true;

		// Token: 0x04000115 RID: 277
		private string m_loggerToMatch;
	}
}

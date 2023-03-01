using System;

namespace log4net.Core
{
	// Token: 0x020000B2 RID: 178
	public class LevelEvaluator : ITriggeringEventEvaluator
	{
		// Token: 0x060004D2 RID: 1234 RVA: 0x0000F76D File Offset: 0x0000E76D
		public LevelEvaluator() : this(Level.Off)
		{
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0000F77A File Offset: 0x0000E77A
		public LevelEvaluator(Level threshold)
		{
			if (threshold == null)
			{
				throw new ArgumentNullException("threshold");
			}
			this.m_threshold = threshold;
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x0000F79D File Offset: 0x0000E79D
		// (set) Token: 0x060004D5 RID: 1237 RVA: 0x0000F7A5 File Offset: 0x0000E7A5
		public Level Threshold
		{
			get
			{
				return this.m_threshold;
			}
			set
			{
				this.m_threshold = value;
			}
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0000F7AE File Offset: 0x0000E7AE
		public bool IsTriggeringEvent(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			return loggingEvent.Level >= this.m_threshold;
		}

		// Token: 0x04000153 RID: 339
		private Level m_threshold;
	}
}

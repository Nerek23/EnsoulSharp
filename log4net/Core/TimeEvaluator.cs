using System;

namespace log4net.Core
{
	// Token: 0x020000C0 RID: 192
	public class TimeEvaluator : ITriggeringEventEvaluator
	{
		// Token: 0x06000579 RID: 1401 RVA: 0x00011929 File Offset: 0x00010929
		public TimeEvaluator() : this(0)
		{
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00011932 File Offset: 0x00010932
		public TimeEvaluator(int interval)
		{
			this.m_interval = interval;
			this.m_lastTimeUtc = DateTime.UtcNow;
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x0001194C File Offset: 0x0001094C
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x00011954 File Offset: 0x00010954
		public int Interval
		{
			get
			{
				return this.m_interval;
			}
			set
			{
				this.m_interval = value;
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00011960 File Offset: 0x00010960
		public bool IsTriggeringEvent(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			if (this.m_interval == 0)
			{
				return false;
			}
			bool result;
			lock (this)
			{
				if (DateTime.UtcNow.Subtract(this.m_lastTimeUtc).TotalSeconds > (double)this.m_interval)
				{
					this.m_lastTimeUtc = DateTime.UtcNow;
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x04000199 RID: 409
		private int m_interval;

		// Token: 0x0400019A RID: 410
		private DateTime m_lastTimeUtc;

		// Token: 0x0400019B RID: 411
		private const int DEFAULT_INTERVAL = 0;
	}
}

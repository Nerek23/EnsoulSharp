using System;

namespace log4net.Util
{
	// Token: 0x0200001C RID: 28
	public class LogReceivedEventArgs : EventArgs
	{
		// Token: 0x0600012D RID: 301 RVA: 0x000045D0 File Offset: 0x000035D0
		public LogReceivedEventArgs(LogLog loglog)
		{
			this.loglog = loglog;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600012E RID: 302 RVA: 0x000045DF File Offset: 0x000035DF
		public LogLog LogLog
		{
			get
			{
				return this.loglog;
			}
		}

		// Token: 0x04000034 RID: 52
		private readonly LogLog loglog;
	}
}

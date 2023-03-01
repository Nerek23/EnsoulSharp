using System;

namespace log4net.Repository.Hierarchy
{
	// Token: 0x02000057 RID: 87
	public class LoggerCreationEventArgs : EventArgs
	{
		// Token: 0x060002D3 RID: 723 RVA: 0x000082A0 File Offset: 0x000072A0
		public LoggerCreationEventArgs(Logger log)
		{
			this.m_log = log;
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x000082AF File Offset: 0x000072AF
		public Logger Logger
		{
			get
			{
				return this.m_log;
			}
		}

		// Token: 0x04000097 RID: 151
		private Logger m_log;
	}
}

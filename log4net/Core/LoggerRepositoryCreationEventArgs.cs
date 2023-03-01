using System;
using log4net.Repository;

namespace log4net.Core
{
	// Token: 0x020000AD RID: 173
	public class LoggerRepositoryCreationEventArgs : EventArgs
	{
		// Token: 0x0600048A RID: 1162 RVA: 0x0000ED98 File Offset: 0x0000DD98
		public LoggerRepositoryCreationEventArgs(ILoggerRepository repository)
		{
			this.m_repository = repository;
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x0000EDA7 File Offset: 0x0000DDA7
		public ILoggerRepository LoggerRepository
		{
			get
			{
				return this.m_repository;
			}
		}

		// Token: 0x04000139 RID: 313
		private ILoggerRepository m_repository;
	}
}

using System;
using System.Collections;
using log4net.Repository;

namespace log4net.Core
{
	// Token: 0x020000C2 RID: 194
	public class WrapperMap
	{
		// Token: 0x06000582 RID: 1410 RVA: 0x000119E8 File Offset: 0x000109E8
		public WrapperMap(WrapperCreationHandler createWrapperHandler)
		{
			this.m_createWrapperHandler = createWrapperHandler;
			this.m_shutdownHandler = new LoggerRepositoryShutdownEventHandler(this.ILoggerRepository_Shutdown);
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00011A14 File Offset: 0x00010A14
		public virtual ILoggerWrapper GetWrapper(ILogger logger)
		{
			if (logger == null)
			{
				return null;
			}
			ILoggerWrapper result;
			lock (this)
			{
				Hashtable hashtable = (Hashtable)this.m_repositories[logger.Repository];
				if (hashtable == null)
				{
					hashtable = new Hashtable();
					this.m_repositories[logger.Repository] = hashtable;
					logger.Repository.ShutdownEvent += this.m_shutdownHandler;
				}
				ILoggerWrapper loggerWrapper = hashtable[logger] as ILoggerWrapper;
				if (loggerWrapper == null)
				{
					loggerWrapper = this.CreateNewWrapperObject(logger);
					hashtable[logger] = loggerWrapper;
				}
				result = loggerWrapper;
			}
			return result;
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x00011AB8 File Offset: 0x00010AB8
		protected Hashtable Repositories
		{
			get
			{
				return this.m_repositories;
			}
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00011AC0 File Offset: 0x00010AC0
		protected virtual ILoggerWrapper CreateNewWrapperObject(ILogger logger)
		{
			if (this.m_createWrapperHandler != null)
			{
				return this.m_createWrapperHandler(logger);
			}
			return null;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00011AD8 File Offset: 0x00010AD8
		protected virtual void RepositoryShutdown(ILoggerRepository repository)
		{
			lock (this)
			{
				this.m_repositories.Remove(repository);
				repository.ShutdownEvent -= this.m_shutdownHandler;
			}
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00011B28 File Offset: 0x00010B28
		private void ILoggerRepository_Shutdown(object sender, EventArgs e)
		{
			ILoggerRepository loggerRepository = sender as ILoggerRepository;
			if (loggerRepository != null)
			{
				this.RepositoryShutdown(loggerRepository);
			}
		}

		// Token: 0x0400019C RID: 412
		private readonly Hashtable m_repositories = new Hashtable();

		// Token: 0x0400019D RID: 413
		private readonly WrapperCreationHandler m_createWrapperHandler;

		// Token: 0x0400019E RID: 414
		private readonly LoggerRepositoryShutdownEventHandler m_shutdownHandler;
	}
}

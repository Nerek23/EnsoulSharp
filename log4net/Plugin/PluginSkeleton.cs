using System;
using log4net.Repository;

namespace log4net.Plugin
{
	// Token: 0x02000063 RID: 99
	public abstract class PluginSkeleton : IPlugin
	{
		// Token: 0x06000365 RID: 869 RVA: 0x0000B284 File Offset: 0x0000A284
		protected PluginSkeleton(string name)
		{
			this.m_name = name;
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0000B293 File Offset: 0x0000A293
		// (set) Token: 0x06000367 RID: 871 RVA: 0x0000B29B File Offset: 0x0000A29B
		public virtual string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000B2A4 File Offset: 0x0000A2A4
		public virtual void Attach(ILoggerRepository repository)
		{
			this.m_repository = repository;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000B2AD File Offset: 0x0000A2AD
		public virtual void Shutdown()
		{
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600036A RID: 874 RVA: 0x0000B2AF File Offset: 0x0000A2AF
		// (set) Token: 0x0600036B RID: 875 RVA: 0x0000B2B7 File Offset: 0x0000A2B7
		protected virtual ILoggerRepository LoggerRepository
		{
			get
			{
				return this.m_repository;
			}
			set
			{
				this.m_repository = value;
			}
		}

		// Token: 0x040000C9 RID: 201
		private string m_name;

		// Token: 0x040000CA RID: 202
		private ILoggerRepository m_repository;
	}
}

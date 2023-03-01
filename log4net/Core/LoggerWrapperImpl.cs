using System;

namespace log4net.Core
{
	// Token: 0x020000B7 RID: 183
	public abstract class LoggerWrapperImpl : ILoggerWrapper
	{
		// Token: 0x0600050C RID: 1292 RVA: 0x00010251 File Offset: 0x0000F251
		protected LoggerWrapperImpl(ILogger logger)
		{
			this.m_logger = logger;
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x00010260 File Offset: 0x0000F260
		public virtual ILogger Logger
		{
			get
			{
				return this.m_logger;
			}
		}

		// Token: 0x0400015F RID: 351
		private readonly ILogger m_logger;
	}
}

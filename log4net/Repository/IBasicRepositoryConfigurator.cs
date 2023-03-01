using System;
using log4net.Appender;

namespace log4net.Repository
{
	// Token: 0x0200004E RID: 78
	public interface IBasicRepositoryConfigurator
	{
		// Token: 0x0600027B RID: 635
		void Configure(IAppender appender);

		// Token: 0x0600027C RID: 636
		void Configure(params IAppender[] appenders);
	}
}

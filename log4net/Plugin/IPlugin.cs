using System;
using log4net.Repository;

namespace log4net.Plugin
{
	// Token: 0x0200005F RID: 95
	public interface IPlugin
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000330 RID: 816
		string Name { get; }

		// Token: 0x06000331 RID: 817
		void Attach(ILoggerRepository repository);

		// Token: 0x06000332 RID: 818
		void Shutdown();
	}
}

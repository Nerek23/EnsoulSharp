using System;

namespace log4net.Repository.Hierarchy
{
	// Token: 0x02000059 RID: 89
	public interface ILoggerFactory
	{
		// Token: 0x060002F9 RID: 761
		Logger CreateLogger(ILoggerRepository repository, string name);
	}
}

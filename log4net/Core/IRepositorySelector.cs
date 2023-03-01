using System;
using System.Reflection;
using log4net.Repository;

namespace log4net.Core
{
	// Token: 0x020000AE RID: 174
	public interface IRepositorySelector
	{
		// Token: 0x0600048C RID: 1164
		ILoggerRepository GetRepository(Assembly assembly);

		// Token: 0x0600048D RID: 1165
		ILoggerRepository GetRepository(string repositoryName);

		// Token: 0x0600048E RID: 1166
		ILoggerRepository CreateRepository(Assembly assembly, Type repositoryType);

		// Token: 0x0600048F RID: 1167
		ILoggerRepository CreateRepository(string repositoryName, Type repositoryType);

		// Token: 0x06000490 RID: 1168
		bool ExistsRepository(string repositoryName);

		// Token: 0x06000491 RID: 1169
		ILoggerRepository[] GetAllRepositories();

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000492 RID: 1170
		// (remove) Token: 0x06000493 RID: 1171
		event LoggerRepositoryCreationEventHandler LoggerRepositoryCreatedEvent;
	}
}

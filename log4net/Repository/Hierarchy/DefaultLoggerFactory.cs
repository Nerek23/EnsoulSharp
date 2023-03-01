using System;
using log4net.Core;

namespace log4net.Repository.Hierarchy
{
	// Token: 0x02000055 RID: 85
	internal class DefaultLoggerFactory : ILoggerFactory
	{
		// Token: 0x060002CD RID: 717 RVA: 0x00008277 File Offset: 0x00007277
		internal DefaultLoggerFactory()
		{
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000827F File Offset: 0x0000727F
		public Logger CreateLogger(ILoggerRepository repository, string name)
		{
			if (name == null)
			{
				return new RootLogger(repository.LevelMap.LookupWithDefault(Level.Debug));
			}
			return new DefaultLoggerFactory.LoggerImpl(name);
		}

		// Token: 0x020000F8 RID: 248
		internal sealed class LoggerImpl : Logger
		{
			// Token: 0x060007D7 RID: 2007 RVA: 0x00018D9A File Offset: 0x00017D9A
			internal LoggerImpl(string name) : base(name)
			{
			}
		}
	}
}

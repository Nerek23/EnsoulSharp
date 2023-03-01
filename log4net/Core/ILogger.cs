using System;
using log4net.Repository;

namespace log4net.Core
{
	// Token: 0x020000A9 RID: 169
	public interface ILogger
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600047F RID: 1151
		string Name { get; }

		// Token: 0x06000480 RID: 1152
		void Log(Type callerStackBoundaryDeclaringType, Level level, object message, Exception exception);

		// Token: 0x06000481 RID: 1153
		void Log(LoggingEvent logEvent);

		// Token: 0x06000482 RID: 1154
		bool IsEnabledFor(Level level);

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000483 RID: 1155
		ILoggerRepository Repository { get; }
	}
}

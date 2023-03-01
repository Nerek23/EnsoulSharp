using System;
using log4net.Appender;

namespace log4net.Core
{
	// Token: 0x020000A6 RID: 166
	public interface IAppenderAttachable
	{
		// Token: 0x06000475 RID: 1141
		void AddAppender(IAppender appender);

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000476 RID: 1142
		AppenderCollection Appenders { get; }

		// Token: 0x06000477 RID: 1143
		IAppender GetAppender(string name);

		// Token: 0x06000478 RID: 1144
		void RemoveAllAppenders();

		// Token: 0x06000479 RID: 1145
		IAppender RemoveAppender(IAppender appender);

		// Token: 0x0600047A RID: 1146
		IAppender RemoveAppender(string name);
	}
}

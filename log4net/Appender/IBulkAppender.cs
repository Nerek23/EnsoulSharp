using System;
using log4net.Core;

namespace log4net.Appender
{
	// Token: 0x020000DF RID: 223
	public interface IBulkAppender : IAppender
	{
		// Token: 0x060006DF RID: 1759
		void DoAppend(LoggingEvent[] loggingEvents);
	}
}

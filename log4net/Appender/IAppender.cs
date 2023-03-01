using System;
using log4net.Core;

namespace log4net.Appender
{
	// Token: 0x020000DE RID: 222
	public interface IAppender
	{
		// Token: 0x060006DB RID: 1755
		void Close();

		// Token: 0x060006DC RID: 1756
		void DoAppend(LoggingEvent loggingEvent);

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060006DD RID: 1757
		// (set) Token: 0x060006DE RID: 1758
		string Name { get; set; }
	}
}

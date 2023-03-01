using System;
using log4net.Core;

namespace log4net.Filter
{
	// Token: 0x02000095 RID: 149
	public interface IFilter : IOptionHandler
	{
		// Token: 0x0600041D RID: 1053
		FilterDecision Decide(LoggingEvent loggingEvent);

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600041E RID: 1054
		// (set) Token: 0x0600041F RID: 1055
		IFilter Next { get; set; }
	}
}

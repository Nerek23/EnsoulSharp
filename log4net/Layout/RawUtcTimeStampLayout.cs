using System;
using log4net.Core;

namespace log4net.Layout
{
	// Token: 0x02000072 RID: 114
	public class RawUtcTimeStampLayout : IRawLayout
	{
		// Token: 0x060003B3 RID: 947 RVA: 0x0000C1EA File Offset: 0x0000B1EA
		public virtual object Format(LoggingEvent loggingEvent)
		{
			return loggingEvent.TimeStampUtc;
		}
	}
}

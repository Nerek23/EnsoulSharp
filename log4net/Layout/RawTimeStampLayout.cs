using System;
using log4net.Core;

namespace log4net.Layout
{
	// Token: 0x02000071 RID: 113
	public class RawTimeStampLayout : IRawLayout
	{
		// Token: 0x060003B1 RID: 945 RVA: 0x0000C1D5 File Offset: 0x0000B1D5
		public virtual object Format(LoggingEvent loggingEvent)
		{
			return loggingEvent.TimeStamp;
		}
	}
}

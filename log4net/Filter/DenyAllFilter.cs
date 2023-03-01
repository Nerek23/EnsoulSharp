using System;
using log4net.Core;

namespace log4net.Filter
{
	// Token: 0x02000092 RID: 146
	public sealed class DenyAllFilter : FilterSkeleton
	{
		// Token: 0x06000417 RID: 1047 RVA: 0x0000D501 File Offset: 0x0000C501
		public override FilterDecision Decide(LoggingEvent loggingEvent)
		{
			return FilterDecision.Deny;
		}
	}
}

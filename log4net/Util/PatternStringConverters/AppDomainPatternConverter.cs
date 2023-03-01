using System;
using System.IO;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000040 RID: 64
	internal sealed class AppDomainPatternConverter : PatternConverter
	{
		// Token: 0x06000252 RID: 594 RVA: 0x000074E4 File Offset: 0x000064E4
		protected override void Convert(TextWriter writer, object state)
		{
			writer.Write(SystemInfo.ApplicationFriendlyName);
		}
	}
}

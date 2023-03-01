using System;
using log4net.Core;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200008F RID: 143
	internal sealed class TypeNamePatternConverter : NamedPatternConverter
	{
		// Token: 0x0600040F RID: 1039 RVA: 0x0000D459 File Offset: 0x0000C459
		protected override string GetFullyQualifiedName(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				return string.Empty;
			}
			if (loggingEvent.LocationInformation == null)
			{
				return string.Empty;
			}
			return loggingEvent.LocationInformation.ClassName;
		}
	}
}

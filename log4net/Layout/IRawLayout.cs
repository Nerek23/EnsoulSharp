using System;
using log4net.Core;
using log4net.Util.TypeConverters;

namespace log4net.Layout
{
	// Token: 0x0200006B RID: 107
	[TypeConverter(typeof(RawLayoutConverter))]
	public interface IRawLayout
	{
		// Token: 0x06000391 RID: 913
		object Format(LoggingEvent loggingEvent);
	}
}

using System;

namespace log4net.Util.TypeConverters
{
	// Token: 0x0200003A RID: 58
	public interface IConvertTo
	{
		// Token: 0x0600023C RID: 572
		bool CanConvertTo(Type targetType);

		// Token: 0x0600023D RID: 573
		object ConvertTo(object source, Type targetType);
	}
}

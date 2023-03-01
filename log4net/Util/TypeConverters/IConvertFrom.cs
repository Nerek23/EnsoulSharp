using System;

namespace log4net.Util.TypeConverters
{
	// Token: 0x02000039 RID: 57
	public interface IConvertFrom
	{
		// Token: 0x0600023A RID: 570
		bool CanConvertFrom(Type sourceType);

		// Token: 0x0600023B RID: 571
		object ConvertFrom(object source);
	}
}

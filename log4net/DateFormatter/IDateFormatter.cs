using System;
using System.IO;

namespace log4net.DateFormatter
{
	// Token: 0x0200009F RID: 159
	public interface IDateFormatter
	{
		// Token: 0x06000449 RID: 1097
		void FormatDate(DateTime dateToFormat, TextWriter writer);
	}
}

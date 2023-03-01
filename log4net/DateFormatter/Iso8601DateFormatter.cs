using System;
using System.Text;

namespace log4net.DateFormatter
{
	// Token: 0x020000A0 RID: 160
	public class Iso8601DateFormatter : AbsoluteTimeDateFormatter
	{
		// Token: 0x0600044B RID: 1099 RVA: 0x0000DAF4 File Offset: 0x0000CAF4
		protected override void FormatDateWithoutMillis(DateTime dateToFormat, StringBuilder buffer)
		{
			buffer.Append(dateToFormat.Year);
			buffer.Append('-');
			int month = dateToFormat.Month;
			if (month < 10)
			{
				buffer.Append('0');
			}
			buffer.Append(month);
			buffer.Append('-');
			int day = dateToFormat.Day;
			if (day < 10)
			{
				buffer.Append('0');
			}
			buffer.Append(day);
			buffer.Append(' ');
			base.FormatDateWithoutMillis(dateToFormat, buffer);
		}
	}
}

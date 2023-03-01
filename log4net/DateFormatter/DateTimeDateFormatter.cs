using System;
using System.Globalization;
using System.Text;

namespace log4net.DateFormatter
{
	// Token: 0x0200009E RID: 158
	public class DateTimeDateFormatter : AbsoluteTimeDateFormatter
	{
		// Token: 0x06000447 RID: 1095 RVA: 0x0000DA61 File Offset: 0x0000CA61
		public DateTimeDateFormatter()
		{
			this.m_dateTimeFormatInfo = DateTimeFormatInfo.InvariantInfo;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000DA74 File Offset: 0x0000CA74
		protected override void FormatDateWithoutMillis(DateTime dateToFormat, StringBuilder buffer)
		{
			int day = dateToFormat.Day;
			if (day < 10)
			{
				buffer.Append('0');
			}
			buffer.Append(day);
			buffer.Append(' ');
			buffer.Append(this.m_dateTimeFormatInfo.GetAbbreviatedMonthName(dateToFormat.Month));
			buffer.Append(' ');
			buffer.Append(dateToFormat.Year);
			buffer.Append(' ');
			base.FormatDateWithoutMillis(dateToFormat, buffer);
		}

		// Token: 0x04000121 RID: 289
		private readonly DateTimeFormatInfo m_dateTimeFormatInfo;
	}
}

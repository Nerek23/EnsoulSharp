using System;
using System.Globalization;
using System.IO;

namespace log4net.DateFormatter
{
	// Token: 0x020000A1 RID: 161
	public class SimpleDateFormatter : IDateFormatter
	{
		// Token: 0x0600044C RID: 1100 RVA: 0x0000DB6E File Offset: 0x0000CB6E
		public SimpleDateFormatter(string format)
		{
			this.m_formatString = format;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0000DB7D File Offset: 0x0000CB7D
		public virtual void FormatDate(DateTime dateToFormat, TextWriter writer)
		{
			writer.Write(dateToFormat.ToString(this.m_formatString, DateTimeFormatInfo.InvariantInfo));
		}

		// Token: 0x04000122 RID: 290
		private readonly string m_formatString;
	}
}

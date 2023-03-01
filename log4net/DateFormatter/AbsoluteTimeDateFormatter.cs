using System;
using System.Collections;
using System.IO;
using System.Text;

namespace log4net.DateFormatter
{
	// Token: 0x0200009D RID: 157
	public class AbsoluteTimeDateFormatter : IDateFormatter
	{
		// Token: 0x06000443 RID: 1091 RVA: 0x0000D884 File Offset: 0x0000C884
		protected virtual void FormatDateWithoutMillis(DateTime dateToFormat, StringBuilder buffer)
		{
			int hour = dateToFormat.Hour;
			if (hour < 10)
			{
				buffer.Append('0');
			}
			buffer.Append(hour);
			buffer.Append(':');
			int minute = dateToFormat.Minute;
			if (minute < 10)
			{
				buffer.Append('0');
			}
			buffer.Append(minute);
			buffer.Append(':');
			int second = dateToFormat.Second;
			if (second < 10)
			{
				buffer.Append('0');
			}
			buffer.Append(second);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0000D900 File Offset: 0x0000C900
		public virtual void FormatDate(DateTime dateToFormat, TextWriter writer)
		{
			Hashtable obj = AbsoluteTimeDateFormatter.s_lastTimeStrings;
			lock (obj)
			{
				long num = dateToFormat.Ticks - dateToFormat.Ticks % 10000000L;
				string text = null;
				if (AbsoluteTimeDateFormatter.s_lastTimeToTheSecond != num)
				{
					AbsoluteTimeDateFormatter.s_lastTimeStrings.Clear();
				}
				else
				{
					text = (string)AbsoluteTimeDateFormatter.s_lastTimeStrings[base.GetType()];
				}
				if (text == null)
				{
					StringBuilder obj2 = AbsoluteTimeDateFormatter.s_lastTimeBuf;
					lock (obj2)
					{
						text = (string)AbsoluteTimeDateFormatter.s_lastTimeStrings[base.GetType()];
						if (text == null)
						{
							AbsoluteTimeDateFormatter.s_lastTimeBuf.Length = 0;
							this.FormatDateWithoutMillis(dateToFormat, AbsoluteTimeDateFormatter.s_lastTimeBuf);
							text = AbsoluteTimeDateFormatter.s_lastTimeBuf.ToString();
							AbsoluteTimeDateFormatter.s_lastTimeStrings[base.GetType()] = text;
							AbsoluteTimeDateFormatter.s_lastTimeToTheSecond = num;
						}
					}
				}
				writer.Write(text);
				writer.Write(',');
				int millisecond = dateToFormat.Millisecond;
				if (millisecond < 100)
				{
					writer.Write('0');
				}
				if (millisecond < 10)
				{
					writer.Write('0');
				}
				writer.Write(millisecond);
			}
		}

		// Token: 0x0400011B RID: 283
		public const string AbsoluteTimeDateFormat = "ABSOLUTE";

		// Token: 0x0400011C RID: 284
		public const string DateAndTimeDateFormat = "DATE";

		// Token: 0x0400011D RID: 285
		public const string Iso8601TimeDateFormat = "ISO8601";

		// Token: 0x0400011E RID: 286
		private static long s_lastTimeToTheSecond = 0L;

		// Token: 0x0400011F RID: 287
		private static StringBuilder s_lastTimeBuf = new StringBuilder();

		// Token: 0x04000120 RID: 288
		private static Hashtable s_lastTimeStrings = new Hashtable();
	}
}

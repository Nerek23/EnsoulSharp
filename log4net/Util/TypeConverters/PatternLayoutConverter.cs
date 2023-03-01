using System;
using log4net.Layout;

namespace log4net.Util.TypeConverters
{
	// Token: 0x0200003C RID: 60
	internal class PatternLayoutConverter : IConvertFrom
	{
		// Token: 0x06000242 RID: 578 RVA: 0x0000738D File Offset: 0x0000638D
		public bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(string);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x000073A0 File Offset: 0x000063A0
		public object ConvertFrom(object source)
		{
			string text = source as string;
			if (text != null)
			{
				return new PatternLayout(text);
			}
			throw ConversionNotSupportedException.Create(typeof(PatternLayout), source);
		}
	}
}

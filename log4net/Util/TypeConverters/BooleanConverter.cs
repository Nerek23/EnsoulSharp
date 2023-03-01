using System;

namespace log4net.Util.TypeConverters
{
	// Token: 0x02000035 RID: 53
	internal class BooleanConverter : IConvertFrom
	{
		// Token: 0x06000226 RID: 550 RVA: 0x00006E5C File Offset: 0x00005E5C
		public bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(string);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00006E70 File Offset: 0x00005E70
		public object ConvertFrom(object source)
		{
			string text = source as string;
			if (text != null)
			{
				return bool.Parse(text);
			}
			throw ConversionNotSupportedException.Create(typeof(bool), source);
		}
	}
}

using System;

namespace log4net.Util.TypeConverters
{
	// Token: 0x0200003E RID: 62
	internal class TypeConverter : IConvertFrom
	{
		// Token: 0x0600024A RID: 586 RVA: 0x0000745E File Offset: 0x0000645E
		public bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(string);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00007470 File Offset: 0x00006470
		public object ConvertFrom(object source)
		{
			string text = source as string;
			if (text != null)
			{
				return SystemInfo.GetTypeFromString(text, true, true);
			}
			throw ConversionNotSupportedException.Create(typeof(Type), source);
		}
	}
}

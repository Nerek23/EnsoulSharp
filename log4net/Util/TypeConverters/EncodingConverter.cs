using System;
using System.Text;

namespace log4net.Util.TypeConverters
{
	// Token: 0x02000038 RID: 56
	internal class EncodingConverter : IConvertFrom
	{
		// Token: 0x06000237 RID: 567 RVA: 0x00007278 File Offset: 0x00006278
		public bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(string);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000728C File Offset: 0x0000628C
		public object ConvertFrom(object source)
		{
			string text = source as string;
			if (text != null)
			{
				return Encoding.GetEncoding(text);
			}
			throw ConversionNotSupportedException.Create(typeof(Encoding), source);
		}
	}
}

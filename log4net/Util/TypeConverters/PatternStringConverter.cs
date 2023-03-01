using System;

namespace log4net.Util.TypeConverters
{
	// Token: 0x0200003D RID: 61
	internal class PatternStringConverter : IConvertTo, IConvertFrom
	{
		// Token: 0x06000245 RID: 581 RVA: 0x000073D6 File Offset: 0x000063D6
		public bool CanConvertTo(Type targetType)
		{
			return typeof(string).IsAssignableFrom(targetType);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000073E8 File Offset: 0x000063E8
		public object ConvertTo(object source, Type targetType)
		{
			PatternString patternString = source as PatternString;
			if (patternString != null && this.CanConvertTo(targetType))
			{
				return patternString.Format();
			}
			throw ConversionNotSupportedException.Create(targetType, source);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00007416 File Offset: 0x00006416
		public bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(string);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00007428 File Offset: 0x00006428
		public object ConvertFrom(object source)
		{
			string text = source as string;
			if (text != null)
			{
				return new PatternString(text);
			}
			throw ConversionNotSupportedException.Create(typeof(PatternString), source);
		}
	}
}

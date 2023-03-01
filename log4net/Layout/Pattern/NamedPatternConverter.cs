using System;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000087 RID: 135
	public abstract class NamedPatternConverter : PatternLayoutConverter, IOptionHandler
	{
		// Token: 0x060003F4 RID: 1012 RVA: 0x0000CFCC File Offset: 0x0000BFCC
		public void ActivateOptions()
		{
			this.m_precision = 0;
			if (this.Option != null)
			{
				string text = this.Option.Trim();
				if (text.Length > 0)
				{
					int num;
					if (SystemInfo.TryParse(text, out num))
					{
						if (num <= 0)
						{
							LogLog.Error(NamedPatternConverter.declaringType, "NamedPatternConverter: Precision option (" + text + ") isn't a positive integer.");
							return;
						}
						this.m_precision = num;
						return;
					}
					else
					{
						LogLog.Error(NamedPatternConverter.declaringType, "NamedPatternConverter: Precision option \"" + text + "\" not a decimal integer.");
					}
				}
			}
		}

		// Token: 0x060003F5 RID: 1013
		protected abstract string GetFullyQualifiedName(LoggingEvent loggingEvent);

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000D048 File Offset: 0x0000C048
		protected sealed override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			string text = this.GetFullyQualifiedName(loggingEvent);
			if (this.m_precision <= 0 || text == null || text.Length < 2)
			{
				writer.Write(text);
				return;
			}
			int num = text.Length;
			string str = string.Empty;
			if (text.EndsWith("."))
			{
				str = ".";
				text = text.Substring(0, num - 1);
				num--;
			}
			int num2 = text.LastIndexOf(".");
			int num3 = 1;
			while (num2 > 0 && num3 < this.m_precision)
			{
				num2 = text.LastIndexOf('.', num2 - 1);
				num3++;
			}
			if (num2 == -1)
			{
				writer.Write(text + str);
				return;
			}
			writer.Write(text.Substring(num2 + 1, num - num2 - 1) + str);
		}

		// Token: 0x04000102 RID: 258
		private int m_precision;

		// Token: 0x04000103 RID: 259
		private static readonly Type declaringType = typeof(NamedPatternConverter);

		// Token: 0x04000104 RID: 260
		private const string DOT = ".";
	}
}

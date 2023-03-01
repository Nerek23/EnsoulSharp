using System;
using System.IO;
using log4net.Core;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x0200004A RID: 74
	internal sealed class RandomStringPatternConverter : PatternConverter, IOptionHandler
	{
		// Token: 0x0600026F RID: 623 RVA: 0x00007A70 File Offset: 0x00006A70
		public void ActivateOptions()
		{
			string option = this.Option;
			if (option != null && option.Length > 0)
			{
				int length;
				if (SystemInfo.TryParse(option, out length))
				{
					this.m_length = length;
					return;
				}
				LogLog.Error(RandomStringPatternConverter.declaringType, "RandomStringPatternConverter: Could not convert Option [" + option + "] to Length Int32");
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00007ABC File Offset: 0x00006ABC
		protected override void Convert(TextWriter writer, object state)
		{
			try
			{
				Random obj = RandomStringPatternConverter.s_random;
				lock (obj)
				{
					for (int i = 0; i < this.m_length; i++)
					{
						int num = RandomStringPatternConverter.s_random.Next(36);
						if (num < 26)
						{
							char value = (char)(65 + num);
							writer.Write(value);
						}
						else if (num < 36)
						{
							char value2 = (char)(48 + (num - 26));
							writer.Write(value2);
						}
						else
						{
							writer.Write('X');
						}
					}
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(RandomStringPatternConverter.declaringType, "Error occurred while converting.", exception);
			}
		}

		// Token: 0x04000085 RID: 133
		private static readonly Random s_random = new Random();

		// Token: 0x04000086 RID: 134
		private int m_length = 4;

		// Token: 0x04000087 RID: 135
		private static readonly Type declaringType = typeof(RandomStringPatternConverter);
	}
}

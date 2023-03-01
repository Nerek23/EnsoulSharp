using System;
using System.Collections;
using System.Globalization;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000024 RID: 36
	public sealed class PatternParser
	{
		// Token: 0x06000171 RID: 369 RVA: 0x0000500E File Offset: 0x0000400E
		public PatternParser(string pattern)
		{
			this.m_pattern = pattern;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00005028 File Offset: 0x00004028
		public PatternConverter Parse()
		{
			string[] matches = this.BuildCache();
			this.ParseInternal(this.m_pattern, matches);
			return this.m_head;
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000173 RID: 371 RVA: 0x0000504F File Offset: 0x0000404F
		public Hashtable PatternConverters
		{
			get
			{
				return this.m_patternConverters;
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00005058 File Offset: 0x00004058
		private string[] BuildCache()
		{
			string[] array = new string[this.m_patternConverters.Keys.Count];
			this.m_patternConverters.Keys.CopyTo(array, 0);
			Array.Sort(array, 0, array.Length, PatternParser.StringLengthComparer.Instance);
			return array;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000050A0 File Offset: 0x000040A0
		private void ParseInternal(string pattern, string[] matches)
		{
			int i = 0;
			while (i < pattern.Length)
			{
				int num = pattern.IndexOf('%', i);
				if (num < 0 || num == pattern.Length - 1)
				{
					this.ProcessLiteral(pattern.Substring(i));
					i = pattern.Length;
				}
				else if (pattern[num + 1] == '%')
				{
					this.ProcessLiteral(pattern.Substring(i, num - i + 1));
					i = num + 2;
				}
				else
				{
					this.ProcessLiteral(pattern.Substring(i, num - i));
					i = num + 1;
					FormattingInfo formattingInfo = new FormattingInfo();
					if (i < pattern.Length && pattern[i] == '-')
					{
						formattingInfo.LeftAlign = true;
						i++;
					}
					while (i < pattern.Length && char.IsDigit(pattern[i]))
					{
						if (formattingInfo.Min < 0)
						{
							formattingInfo.Min = 0;
						}
						formattingInfo.Min = formattingInfo.Min * 10 + int.Parse(pattern[i].ToString(), NumberFormatInfo.InvariantInfo);
						i++;
					}
					if (i < pattern.Length && pattern[i] == '.')
					{
						i++;
					}
					while (i < pattern.Length && char.IsDigit(pattern[i]))
					{
						if (formattingInfo.Max == 2147483647)
						{
							formattingInfo.Max = 0;
						}
						formattingInfo.Max = formattingInfo.Max * 10 + int.Parse(pattern[i].ToString(), NumberFormatInfo.InvariantInfo);
						i++;
					}
					int num2 = pattern.Length - i;
					for (int j = 0; j < matches.Length; j++)
					{
						string text = matches[j];
						if (text.Length <= num2 && string.Compare(pattern, i, text, 0, text.Length) == 0)
						{
							i += matches[j].Length;
							string option = null;
							if (i < pattern.Length && pattern[i] == '{')
							{
								i++;
								int num3 = pattern.IndexOf('}', i);
								if (num3 >= 0)
								{
									option = pattern.Substring(i, num3 - i);
									i = num3 + 1;
								}
							}
							this.ProcessConverter(matches[j], option, formattingInfo);
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000052B9 File Offset: 0x000042B9
		private void ProcessLiteral(string text)
		{
			if (text.Length > 0)
			{
				this.ProcessConverter("literal", text, new FormattingInfo());
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000052D8 File Offset: 0x000042D8
		private void ProcessConverter(string converterName, string option, FormattingInfo formattingInfo)
		{
			LogLog.Debug(PatternParser.declaringType, string.Concat(new string[]
			{
				"Converter [",
				converterName,
				"] Option [",
				option,
				"] Format [min=",
				formattingInfo.Min.ToString(),
				",max=",
				formattingInfo.Max.ToString(),
				",leftAlign=",
				formattingInfo.LeftAlign.ToString(),
				"]"
			}));
			ConverterInfo converterInfo = (ConverterInfo)this.m_patternConverters[converterName];
			if (converterInfo == null)
			{
				LogLog.Error(PatternParser.declaringType, "Unknown converter name [" + converterName + "] in conversion pattern.");
				return;
			}
			PatternConverter patternConverter = null;
			try
			{
				patternConverter = (PatternConverter)Activator.CreateInstance(converterInfo.Type);
			}
			catch (Exception ex)
			{
				LogLog.Error(PatternParser.declaringType, "Failed to create instance of Type [" + converterInfo.Type.FullName + "] using default constructor. Exception: " + ex.ToString());
			}
			patternConverter.FormattingInfo = formattingInfo;
			patternConverter.Option = option;
			patternConverter.Properties = converterInfo.Properties;
			IOptionHandler optionHandler = patternConverter as IOptionHandler;
			if (optionHandler != null)
			{
				optionHandler.ActivateOptions();
			}
			this.AddConverter(patternConverter);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00005420 File Offset: 0x00004420
		private void AddConverter(PatternConverter pc)
		{
			if (this.m_head == null)
			{
				this.m_tail = pc;
				this.m_head = pc;
				return;
			}
			this.m_tail = this.m_tail.SetNext(pc);
		}

		// Token: 0x04000050 RID: 80
		private const char ESCAPE_CHAR = '%';

		// Token: 0x04000051 RID: 81
		private PatternConverter m_head;

		// Token: 0x04000052 RID: 82
		private PatternConverter m_tail;

		// Token: 0x04000053 RID: 83
		private string m_pattern;

		// Token: 0x04000054 RID: 84
		private Hashtable m_patternConverters = new Hashtable();

		// Token: 0x04000055 RID: 85
		private static readonly Type declaringType = typeof(PatternParser);

		// Token: 0x020000F3 RID: 243
		private sealed class StringLengthComparer : IComparer
		{
			// Token: 0x060007CD RID: 1997 RVA: 0x00018C84 File Offset: 0x00017C84
			private StringLengthComparer()
			{
			}

			// Token: 0x060007CE RID: 1998 RVA: 0x00018C8C File Offset: 0x00017C8C
			public int Compare(object x, object y)
			{
				string text = x as string;
				string text2 = y as string;
				if (text == null && text2 == null)
				{
					return 0;
				}
				if (text == null)
				{
					return 1;
				}
				if (text2 == null)
				{
					return -1;
				}
				return text2.Length.CompareTo(text.Length);
			}

			// Token: 0x04000258 RID: 600
			public static readonly PatternParser.StringLengthComparer Instance = new PatternParser.StringLengthComparer();
		}
	}
}

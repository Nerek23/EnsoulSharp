using System;
using System.Collections;
using System.Globalization;
using System.IO;
using log4net.Core;
using log4net.Util.PatternStringConverters;

namespace log4net.Util
{
	// Token: 0x02000025 RID: 37
	public class PatternString : IOptionHandler
	{
		// Token: 0x0600017A RID: 378 RVA: 0x0000546C File Offset: 0x0000446C
		static PatternString()
		{
			PatternString.s_globalRulesRegistry.Add("appdomain", typeof(AppDomainPatternConverter));
			PatternString.s_globalRulesRegistry.Add("date", typeof(DatePatternConverter));
			PatternString.s_globalRulesRegistry.Add("env", typeof(EnvironmentPatternConverter));
			PatternString.s_globalRulesRegistry.Add("envFolderPath", typeof(EnvironmentFolderPathPatternConverter));
			PatternString.s_globalRulesRegistry.Add("identity", typeof(IdentityPatternConverter));
			PatternString.s_globalRulesRegistry.Add("literal", typeof(LiteralPatternConverter));
			PatternString.s_globalRulesRegistry.Add("newline", typeof(NewLinePatternConverter));
			PatternString.s_globalRulesRegistry.Add("processid", typeof(ProcessIdPatternConverter));
			PatternString.s_globalRulesRegistry.Add("property", typeof(PropertyPatternConverter));
			PatternString.s_globalRulesRegistry.Add("random", typeof(RandomStringPatternConverter));
			PatternString.s_globalRulesRegistry.Add("username", typeof(UserNamePatternConverter));
			PatternString.s_globalRulesRegistry.Add("utcdate", typeof(UtcDatePatternConverter));
			PatternString.s_globalRulesRegistry.Add("utcDate", typeof(UtcDatePatternConverter));
			PatternString.s_globalRulesRegistry.Add("UtcDate", typeof(UtcDatePatternConverter));
			PatternString.s_globalRulesRegistry.Add("appsetting", typeof(AppSettingPatternConverter));
			PatternString.s_globalRulesRegistry.Add("appSetting", typeof(AppSettingPatternConverter));
			PatternString.s_globalRulesRegistry.Add("AppSetting", typeof(AppSettingPatternConverter));
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000562E File Offset: 0x0000462E
		public PatternString()
		{
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00005641 File Offset: 0x00004641
		public PatternString(string pattern)
		{
			this.m_pattern = pattern;
			this.ActivateOptions();
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00005661 File Offset: 0x00004661
		// (set) Token: 0x0600017E RID: 382 RVA: 0x00005669 File Offset: 0x00004669
		public string ConversionPattern
		{
			get
			{
				return this.m_pattern;
			}
			set
			{
				this.m_pattern = value;
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00005672 File Offset: 0x00004672
		public virtual void ActivateOptions()
		{
			this.m_head = this.CreatePatternParser(this.m_pattern).Parse();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000568C File Offset: 0x0000468C
		private PatternParser CreatePatternParser(string pattern)
		{
			PatternParser patternParser = new PatternParser(pattern);
			foreach (object obj in PatternString.s_globalRulesRegistry)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				ConverterInfo converterInfo = new ConverterInfo();
				converterInfo.Name = (string)dictionaryEntry.Key;
				converterInfo.Type = (Type)dictionaryEntry.Value;
				patternParser.PatternConverters.Add(dictionaryEntry.Key, converterInfo);
			}
			foreach (object obj2 in this.m_instanceRulesRegistry)
			{
				DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
				patternParser.PatternConverters[dictionaryEntry2.Key] = dictionaryEntry2.Value;
			}
			return patternParser;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00005784 File Offset: 0x00004784
		public void Format(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			for (PatternConverter patternConverter = this.m_head; patternConverter != null; patternConverter = patternConverter.Next)
			{
				patternConverter.Format(writer, null);
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000057BC File Offset: 0x000047BC
		public string Format()
		{
			string result;
			using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
			{
				this.Format(stringWriter);
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00005800 File Offset: 0x00004800
		public void AddConverter(ConverterInfo converterInfo)
		{
			if (converterInfo == null)
			{
				throw new ArgumentNullException("converterInfo");
			}
			if (!typeof(PatternConverter).IsAssignableFrom(converterInfo.Type))
			{
				string str = "The converter type specified [";
				Type type = converterInfo.Type;
				throw new ArgumentException(str + ((type != null) ? type.ToString() : null) + "] must be a subclass of log4net.Util.PatternConverter", "converterInfo");
			}
			this.m_instanceRulesRegistry[converterInfo.Name] = converterInfo;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00005870 File Offset: 0x00004870
		public void AddConverter(string name, Type type)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.AddConverter(new ConverterInfo
			{
				Name = name,
				Type = type
			});
		}

		// Token: 0x04000056 RID: 86
		private static Hashtable s_globalRulesRegistry = new Hashtable(18);

		// Token: 0x04000057 RID: 87
		private string m_pattern;

		// Token: 0x04000058 RID: 88
		private PatternConverter m_head;

		// Token: 0x04000059 RID: 89
		private Hashtable m_instanceRulesRegistry = new Hashtable();
	}
}

using System;
using System.Collections;
using System.IO;
using log4net.Core;
using log4net.Layout.Pattern;
using log4net.Util;
using log4net.Util.PatternStringConverters;

namespace log4net.Layout
{
	// Token: 0x0200006E RID: 110
	public class PatternLayout : LayoutSkeleton
	{
		// Token: 0x0600039F RID: 927 RVA: 0x0000B9D8 File Offset: 0x0000A9D8
		static PatternLayout()
		{
			PatternLayout.s_globalRulesRegistry.Add("literal", typeof(LiteralPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("newline", typeof(NewLinePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("n", typeof(NewLinePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("aspnet-cache", typeof(AspNetCachePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("aspnet-context", typeof(AspNetContextPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("aspnet-request", typeof(AspNetRequestPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("aspnet-session", typeof(AspNetSessionPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("c", typeof(LoggerPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("logger", typeof(LoggerPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("C", typeof(TypeNamePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("class", typeof(TypeNamePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("type", typeof(TypeNamePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("d", typeof(log4net.Layout.Pattern.DatePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("date", typeof(log4net.Layout.Pattern.DatePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("exception", typeof(ExceptionPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("F", typeof(FileLocationPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("file", typeof(FileLocationPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("l", typeof(FullLocationPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("location", typeof(FullLocationPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("L", typeof(LineLocationPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("line", typeof(LineLocationPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("m", typeof(MessagePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("message", typeof(MessagePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("M", typeof(MethodLocationPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("method", typeof(MethodLocationPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("p", typeof(LevelPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("level", typeof(LevelPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("P", typeof(log4net.Layout.Pattern.PropertyPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("property", typeof(log4net.Layout.Pattern.PropertyPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("properties", typeof(log4net.Layout.Pattern.PropertyPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("r", typeof(RelativeTimePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("timestamp", typeof(RelativeTimePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("stacktrace", typeof(StackTracePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("stacktracedetail", typeof(StackTraceDetailPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("t", typeof(ThreadPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("thread", typeof(ThreadPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("x", typeof(NdcPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("ndc", typeof(NdcPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("X", typeof(log4net.Layout.Pattern.PropertyPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("mdc", typeof(log4net.Layout.Pattern.PropertyPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("a", typeof(log4net.Layout.Pattern.AppDomainPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("appdomain", typeof(log4net.Layout.Pattern.AppDomainPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("u", typeof(log4net.Layout.Pattern.IdentityPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("identity", typeof(log4net.Layout.Pattern.IdentityPatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("utcdate", typeof(log4net.Layout.Pattern.UtcDatePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("utcDate", typeof(log4net.Layout.Pattern.UtcDatePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("UtcDate", typeof(log4net.Layout.Pattern.UtcDatePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("w", typeof(log4net.Layout.Pattern.UserNamePatternConverter));
			PatternLayout.s_globalRulesRegistry.Add("username", typeof(log4net.Layout.Pattern.UserNamePatternConverter));
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0000BEBA File Offset: 0x0000AEBA
		public PatternLayout() : this("%message%newline")
		{
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000BEC7 File Offset: 0x0000AEC7
		public PatternLayout(string pattern)
		{
			this.IgnoresException = true;
			this.m_pattern = pattern;
			if (this.m_pattern == null)
			{
				this.m_pattern = "%message%newline";
			}
			this.ActivateOptions();
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x0000BF01 File Offset: 0x0000AF01
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x0000BF09 File Offset: 0x0000AF09
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

		// Token: 0x060003A4 RID: 932 RVA: 0x0000BF14 File Offset: 0x0000AF14
		protected virtual PatternParser CreatePatternParser(string pattern)
		{
			PatternParser patternParser = new PatternParser(pattern);
			foreach (object obj in PatternLayout.s_globalRulesRegistry)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				ConverterInfo converterInfo = new ConverterInfo();
				converterInfo.Name = (string)dictionaryEntry.Key;
				converterInfo.Type = (Type)dictionaryEntry.Value;
				patternParser.PatternConverters[dictionaryEntry.Key] = converterInfo;
			}
			foreach (object obj2 in this.m_instanceRulesRegistry)
			{
				DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
				patternParser.PatternConverters[dictionaryEntry2.Key] = dictionaryEntry2.Value;
			}
			return patternParser;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0000C00C File Offset: 0x0000B00C
		public override void ActivateOptions()
		{
			this.m_head = this.CreatePatternParser(this.m_pattern).Parse();
			for (PatternConverter patternConverter = this.m_head; patternConverter != null; patternConverter = patternConverter.Next)
			{
				PatternLayoutConverter patternLayoutConverter = patternConverter as PatternLayoutConverter;
				if (patternLayoutConverter != null && !patternLayoutConverter.IgnoresException)
				{
					this.IgnoresException = false;
					return;
				}
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000C060 File Offset: 0x0000B060
		public override void Format(TextWriter writer, LoggingEvent loggingEvent)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			for (PatternConverter patternConverter = this.m_head; patternConverter != null; patternConverter = patternConverter.Next)
			{
				patternConverter.Format(writer, loggingEvent);
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000C0A4 File Offset: 0x0000B0A4
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

		// Token: 0x060003A8 RID: 936 RVA: 0x0000C114 File Offset: 0x0000B114
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

		// Token: 0x040000D8 RID: 216
		public const string DefaultConversionPattern = "%message%newline";

		// Token: 0x040000D9 RID: 217
		public const string DetailConversionPattern = "%timestamp [%thread] %level %logger %ndc - %message%newline";

		// Token: 0x040000DA RID: 218
		private static Hashtable s_globalRulesRegistry = new Hashtable(45);

		// Token: 0x040000DB RID: 219
		private string m_pattern;

		// Token: 0x040000DC RID: 220
		private PatternConverter m_head;

		// Token: 0x040000DD RID: 221
		private Hashtable m_instanceRulesRegistry = new Hashtable();
	}
}

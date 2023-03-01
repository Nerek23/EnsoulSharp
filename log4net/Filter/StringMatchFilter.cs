using System;
using System.Text.RegularExpressions;
using log4net.Core;

namespace log4net.Filter
{
	// Token: 0x0200009C RID: 156
	public class StringMatchFilter : FilterSkeleton
	{
		// Token: 0x0600043B RID: 1083 RVA: 0x0000D7AB File Offset: 0x0000C7AB
		public override void ActivateOptions()
		{
			if (this.m_stringRegexToMatch != null)
			{
				this.m_regexToMatch = new Regex(this.m_stringRegexToMatch, RegexOptions.Compiled);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x0000D7C7 File Offset: 0x0000C7C7
		// (set) Token: 0x0600043D RID: 1085 RVA: 0x0000D7CF File Offset: 0x0000C7CF
		public bool AcceptOnMatch
		{
			get
			{
				return this.m_acceptOnMatch;
			}
			set
			{
				this.m_acceptOnMatch = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x0000D7D8 File Offset: 0x0000C7D8
		// (set) Token: 0x0600043F RID: 1087 RVA: 0x0000D7E0 File Offset: 0x0000C7E0
		public string StringToMatch
		{
			get
			{
				return this.m_stringToMatch;
			}
			set
			{
				this.m_stringToMatch = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x0000D7E9 File Offset: 0x0000C7E9
		// (set) Token: 0x06000441 RID: 1089 RVA: 0x0000D7F1 File Offset: 0x0000C7F1
		public string RegexToMatch
		{
			get
			{
				return this.m_stringRegexToMatch;
			}
			set
			{
				this.m_stringRegexToMatch = value;
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0000D7FC File Offset: 0x0000C7FC
		public override FilterDecision Decide(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			string renderedMessage = loggingEvent.RenderedMessage;
			if (renderedMessage == null || (this.m_stringToMatch == null && this.m_regexToMatch == null))
			{
				return FilterDecision.Neutral;
			}
			if (this.m_regexToMatch != null)
			{
				if (!this.m_regexToMatch.Match(renderedMessage).Success)
				{
					return FilterDecision.Neutral;
				}
				if (this.m_acceptOnMatch)
				{
					return FilterDecision.Accept;
				}
				return FilterDecision.Deny;
			}
			else
			{
				if (this.m_stringToMatch == null)
				{
					return FilterDecision.Neutral;
				}
				if (renderedMessage.IndexOf(this.m_stringToMatch) == -1)
				{
					return FilterDecision.Neutral;
				}
				if (this.m_acceptOnMatch)
				{
					return FilterDecision.Accept;
				}
				return FilterDecision.Deny;
			}
		}

		// Token: 0x04000117 RID: 279
		protected bool m_acceptOnMatch = true;

		// Token: 0x04000118 RID: 280
		protected string m_stringToMatch;

		// Token: 0x04000119 RID: 281
		protected string m_stringRegexToMatch;

		// Token: 0x0400011A RID: 282
		protected Regex m_regexToMatch;
	}
}

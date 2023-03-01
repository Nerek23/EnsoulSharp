using System;
using log4net.Core;

namespace log4net.Filter
{
	// Token: 0x0200009B RID: 155
	public class PropertyFilter : StringMatchFilter
	{
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x0000D6E3 File Offset: 0x0000C6E3
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x0000D6EB File Offset: 0x0000C6EB
		public string Key
		{
			get
			{
				return this.m_key;
			}
			set
			{
				this.m_key = value;
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0000D6F4 File Offset: 0x0000C6F4
		public override FilterDecision Decide(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			if (this.m_key == null)
			{
				return FilterDecision.Neutral;
			}
			object obj = loggingEvent.LookupProperty(this.m_key);
			string text = loggingEvent.Repository.RendererMap.FindAndRender(obj);
			if (text == null || (this.m_stringToMatch == null && this.m_regexToMatch == null))
			{
				return FilterDecision.Neutral;
			}
			if (this.m_regexToMatch != null)
			{
				if (!this.m_regexToMatch.Match(text).Success)
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
				if (text.IndexOf(this.m_stringToMatch) == -1)
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

		// Token: 0x04000116 RID: 278
		private string m_key;
	}
}

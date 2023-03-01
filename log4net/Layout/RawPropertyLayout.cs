using System;
using log4net.Core;

namespace log4net.Layout
{
	// Token: 0x02000070 RID: 112
	public class RawPropertyLayout : IRawLayout
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060003AD RID: 941 RVA: 0x0000C1AE File Offset: 0x0000B1AE
		// (set) Token: 0x060003AE RID: 942 RVA: 0x0000C1B6 File Offset: 0x0000B1B6
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

		// Token: 0x060003AF RID: 943 RVA: 0x0000C1BF File Offset: 0x0000B1BF
		public virtual object Format(LoggingEvent loggingEvent)
		{
			return loggingEvent.LookupProperty(this.m_key);
		}

		// Token: 0x040000DE RID: 222
		private string m_key;
	}
}

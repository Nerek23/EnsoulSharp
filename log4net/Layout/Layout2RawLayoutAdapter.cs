using System;
using System.Globalization;
using System.IO;
using log4net.Core;

namespace log4net.Layout
{
	// Token: 0x0200006C RID: 108
	public class Layout2RawLayoutAdapter : IRawLayout
	{
		// Token: 0x06000392 RID: 914 RVA: 0x0000B8EB File Offset: 0x0000A8EB
		public Layout2RawLayoutAdapter(ILayout layout)
		{
			this.m_layout = layout;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000B8FC File Offset: 0x0000A8FC
		public virtual object Format(LoggingEvent loggingEvent)
		{
			object result;
			using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
			{
				this.m_layout.Format(stringWriter, loggingEvent);
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x040000D4 RID: 212
		private ILayout m_layout;
	}
}

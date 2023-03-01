using System;
using System.IO;
using log4net.Core;

namespace log4net.Layout
{
	// Token: 0x0200006A RID: 106
	public interface ILayout
	{
		// Token: 0x0600038C RID: 908
		void Format(TextWriter writer, LoggingEvent loggingEvent);

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600038D RID: 909
		string ContentType { get; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600038E RID: 910
		string Header { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600038F RID: 911
		string Footer { get; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000390 RID: 912
		bool IgnoresException { get; }
	}
}

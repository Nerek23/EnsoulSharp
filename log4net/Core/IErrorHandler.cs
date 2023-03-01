using System;

namespace log4net.Core
{
	// Token: 0x020000A7 RID: 167
	public interface IErrorHandler
	{
		// Token: 0x0600047B RID: 1147
		void Error(string message, Exception e, ErrorCode errorCode);

		// Token: 0x0600047C RID: 1148
		void Error(string message, Exception e);

		// Token: 0x0600047D RID: 1149
		void Error(string message);
	}
}

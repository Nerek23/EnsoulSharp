using System;
using log4net.Core;

namespace log4net
{
	// Token: 0x02000003 RID: 3
	public interface ILog : ILoggerWrapper
	{
		// Token: 0x06000004 RID: 4
		void Debug(object message);

		// Token: 0x06000005 RID: 5
		void Debug(object message, Exception exception);

		// Token: 0x06000006 RID: 6
		void DebugFormat(string format, params object[] args);

		// Token: 0x06000007 RID: 7
		void DebugFormat(string format, object arg0);

		// Token: 0x06000008 RID: 8
		void DebugFormat(string format, object arg0, object arg1);

		// Token: 0x06000009 RID: 9
		void DebugFormat(string format, object arg0, object arg1, object arg2);

		// Token: 0x0600000A RID: 10
		void DebugFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x0600000B RID: 11
		void Info(object message);

		// Token: 0x0600000C RID: 12
		void Info(object message, Exception exception);

		// Token: 0x0600000D RID: 13
		void InfoFormat(string format, params object[] args);

		// Token: 0x0600000E RID: 14
		void InfoFormat(string format, object arg0);

		// Token: 0x0600000F RID: 15
		void InfoFormat(string format, object arg0, object arg1);

		// Token: 0x06000010 RID: 16
		void InfoFormat(string format, object arg0, object arg1, object arg2);

		// Token: 0x06000011 RID: 17
		void InfoFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x06000012 RID: 18
		void Warn(object message);

		// Token: 0x06000013 RID: 19
		void Warn(object message, Exception exception);

		// Token: 0x06000014 RID: 20
		void WarnFormat(string format, params object[] args);

		// Token: 0x06000015 RID: 21
		void WarnFormat(string format, object arg0);

		// Token: 0x06000016 RID: 22
		void WarnFormat(string format, object arg0, object arg1);

		// Token: 0x06000017 RID: 23
		void WarnFormat(string format, object arg0, object arg1, object arg2);

		// Token: 0x06000018 RID: 24
		void WarnFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x06000019 RID: 25
		void Error(object message);

		// Token: 0x0600001A RID: 26
		void Error(object message, Exception exception);

		// Token: 0x0600001B RID: 27
		void ErrorFormat(string format, params object[] args);

		// Token: 0x0600001C RID: 28
		void ErrorFormat(string format, object arg0);

		// Token: 0x0600001D RID: 29
		void ErrorFormat(string format, object arg0, object arg1);

		// Token: 0x0600001E RID: 30
		void ErrorFormat(string format, object arg0, object arg1, object arg2);

		// Token: 0x0600001F RID: 31
		void ErrorFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x06000020 RID: 32
		void Fatal(object message);

		// Token: 0x06000021 RID: 33
		void Fatal(object message, Exception exception);

		// Token: 0x06000022 RID: 34
		void FatalFormat(string format, params object[] args);

		// Token: 0x06000023 RID: 35
		void FatalFormat(string format, object arg0);

		// Token: 0x06000024 RID: 36
		void FatalFormat(string format, object arg0, object arg1);

		// Token: 0x06000025 RID: 37
		void FatalFormat(string format, object arg0, object arg1, object arg2);

		// Token: 0x06000026 RID: 38
		void FatalFormat(IFormatProvider provider, string format, params object[] args);

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000027 RID: 39
		bool IsDebugEnabled { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000028 RID: 40
		bool IsInfoEnabled { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000029 RID: 41
		bool IsWarnEnabled { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002A RID: 42
		bool IsErrorEnabled { get; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002B RID: 43
		bool IsFatalEnabled { get; }
	}
}

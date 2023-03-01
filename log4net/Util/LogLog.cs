using System;
using System.Collections;
using System.Diagnostics;

namespace log4net.Util
{
	// Token: 0x0200001B RID: 27
	public sealed class LogLog
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000110 RID: 272 RVA: 0x00004230 File Offset: 0x00003230
		// (remove) Token: 0x06000111 RID: 273 RVA: 0x00004264 File Offset: 0x00003264
		public static event LogReceivedEventHandler LogReceived;

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00004297 File Offset: 0x00003297
		public Type Source
		{
			get
			{
				return this.source;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000113 RID: 275 RVA: 0x000042A0 File Offset: 0x000032A0
		public DateTime TimeStamp
		{
			get
			{
				return this.timeStampUtc.ToLocalTime();
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000114 RID: 276 RVA: 0x000042BB File Offset: 0x000032BB
		public DateTime TimeStampUtc
		{
			get
			{
				return this.timeStampUtc;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000115 RID: 277 RVA: 0x000042C3 File Offset: 0x000032C3
		public string Prefix
		{
			get
			{
				return this.prefix;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000116 RID: 278 RVA: 0x000042CB File Offset: 0x000032CB
		public string Message
		{
			get
			{
				return this.message;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000117 RID: 279 RVA: 0x000042D3 File Offset: 0x000032D3
		public Exception Exception
		{
			get
			{
				return this.exception;
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000042DB File Offset: 0x000032DB
		public override string ToString()
		{
			return this.Prefix + this.Source.Name + ": " + this.Message;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000042FE File Offset: 0x000032FE
		public LogLog(Type source, string prefix, string message, Exception exception)
		{
			this.timeStampUtc = DateTime.UtcNow;
			this.source = source;
			this.prefix = prefix;
			this.message = message;
			this.exception = exception;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00004330 File Offset: 0x00003330
		static LogLog()
		{
			try
			{
				LogLog.InternalDebugging = OptionConverter.ToBoolean(SystemInfo.GetAppSetting("log4net.Internal.Debug"), false);
				LogLog.QuietMode = OptionConverter.ToBoolean(SystemInfo.GetAppSetting("log4net.Internal.Quiet"), false);
				LogLog.EmitInternalMessages = OptionConverter.ToBoolean(SystemInfo.GetAppSetting("log4net.Internal.Emit"), true);
			}
			catch (Exception ex)
			{
				LogLog.Error(typeof(LogLog), "Exception while reading ConfigurationSettings. Check your .config file is well formed XML.", ex);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600011B RID: 283 RVA: 0x000043B8 File Offset: 0x000033B8
		// (set) Token: 0x0600011C RID: 284 RVA: 0x000043BF File Offset: 0x000033BF
		public static bool InternalDebugging
		{
			get
			{
				return LogLog.s_debugEnabled;
			}
			set
			{
				LogLog.s_debugEnabled = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600011D RID: 285 RVA: 0x000043C7 File Offset: 0x000033C7
		// (set) Token: 0x0600011E RID: 286 RVA: 0x000043CE File Offset: 0x000033CE
		public static bool QuietMode
		{
			get
			{
				return LogLog.s_quietMode;
			}
			set
			{
				LogLog.s_quietMode = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600011F RID: 287 RVA: 0x000043D6 File Offset: 0x000033D6
		// (set) Token: 0x06000120 RID: 288 RVA: 0x000043DD File Offset: 0x000033DD
		public static bool EmitInternalMessages
		{
			get
			{
				return LogLog.s_emitInternalMessages;
			}
			set
			{
				LogLog.s_emitInternalMessages = value;
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000043E5 File Offset: 0x000033E5
		public static void OnLogReceived(Type source, string prefix, string message, Exception exception)
		{
			if (LogLog.LogReceived != null)
			{
				LogLog.LogReceived(null, new LogReceivedEventArgs(new LogLog(source, prefix, message, exception)));
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00004407 File Offset: 0x00003407
		public static bool IsDebugEnabled
		{
			get
			{
				return LogLog.s_debugEnabled && !LogLog.s_quietMode;
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000441A File Offset: 0x0000341A
		public static void Debug(Type source, string message)
		{
			if (LogLog.IsDebugEnabled)
			{
				if (LogLog.EmitInternalMessages)
				{
					LogLog.EmitOutLine("log4net: " + message);
				}
				LogLog.OnLogReceived(source, "log4net: ", message, null);
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004447 File Offset: 0x00003447
		public static void Debug(Type source, string message, Exception exception)
		{
			if (LogLog.IsDebugEnabled)
			{
				if (LogLog.EmitInternalMessages)
				{
					LogLog.EmitOutLine("log4net: " + message);
					if (exception != null)
					{
						LogLog.EmitOutLine(exception.ToString());
					}
				}
				LogLog.OnLogReceived(source, "log4net: ", message, exception);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00004482 File Offset: 0x00003482
		public static bool IsWarnEnabled
		{
			get
			{
				return !LogLog.s_quietMode;
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000448C File Offset: 0x0000348C
		public static void Warn(Type source, string message)
		{
			if (LogLog.IsWarnEnabled)
			{
				if (LogLog.EmitInternalMessages)
				{
					LogLog.EmitErrorLine("log4net:WARN " + message);
				}
				LogLog.OnLogReceived(source, "log4net:WARN ", message, null);
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000044B9 File Offset: 0x000034B9
		public static void Warn(Type source, string message, Exception exception)
		{
			if (LogLog.IsWarnEnabled)
			{
				if (LogLog.EmitInternalMessages)
				{
					LogLog.EmitErrorLine("log4net:WARN " + message);
					if (exception != null)
					{
						LogLog.EmitErrorLine(exception.ToString());
					}
				}
				LogLog.OnLogReceived(source, "log4net:WARN ", message, exception);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000128 RID: 296 RVA: 0x000044F4 File Offset: 0x000034F4
		public static bool IsErrorEnabled
		{
			get
			{
				return !LogLog.s_quietMode;
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000044FE File Offset: 0x000034FE
		public static void Error(Type source, string message)
		{
			if (LogLog.IsErrorEnabled)
			{
				if (LogLog.EmitInternalMessages)
				{
					LogLog.EmitErrorLine("log4net:ERROR " + message);
				}
				LogLog.OnLogReceived(source, "log4net:ERROR ", message, null);
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000452B File Offset: 0x0000352B
		public static void Error(Type source, string message, Exception exception)
		{
			if (LogLog.IsErrorEnabled)
			{
				if (LogLog.EmitInternalMessages)
				{
					LogLog.EmitErrorLine("log4net:ERROR " + message);
					if (exception != null)
					{
						LogLog.EmitErrorLine(exception.ToString());
					}
				}
				LogLog.OnLogReceived(source, "log4net:ERROR ", message, exception);
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004568 File Offset: 0x00003568
		private static void EmitOutLine(string message)
		{
			try
			{
				Console.Out.WriteLine(message);
				Trace.WriteLine(message);
			}
			catch
			{
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000459C File Offset: 0x0000359C
		private static void EmitErrorLine(string message)
		{
			try
			{
				Console.Error.WriteLine(message);
				Trace.WriteLine(message);
			}
			catch
			{
			}
		}

		// Token: 0x04000029 RID: 41
		private readonly Type source;

		// Token: 0x0400002A RID: 42
		private readonly DateTime timeStampUtc;

		// Token: 0x0400002B RID: 43
		private readonly string prefix;

		// Token: 0x0400002C RID: 44
		private readonly string message;

		// Token: 0x0400002D RID: 45
		private readonly Exception exception;

		// Token: 0x0400002E RID: 46
		private static bool s_debugEnabled = false;

		// Token: 0x0400002F RID: 47
		private static bool s_quietMode = false;

		// Token: 0x04000030 RID: 48
		private static bool s_emitInternalMessages = true;

		// Token: 0x04000031 RID: 49
		private const string PREFIX = "log4net: ";

		// Token: 0x04000032 RID: 50
		private const string ERR_PREFIX = "log4net:ERROR ";

		// Token: 0x04000033 RID: 51
		private const string WARN_PREFIX = "log4net:WARN ";

		// Token: 0x020000F2 RID: 242
		public class LogReceivedAdapter : IDisposable
		{
			// Token: 0x060007C9 RID: 1993 RVA: 0x00018C2F File Offset: 0x00017C2F
			public LogReceivedAdapter(IList items)
			{
				this.items = items;
				this.handler = new LogReceivedEventHandler(this.LogLog_LogReceived);
				LogLog.LogReceived += this.handler;
			}

			// Token: 0x060007CA RID: 1994 RVA: 0x00018C5B File Offset: 0x00017C5B
			private void LogLog_LogReceived(object source, LogReceivedEventArgs e)
			{
				this.items.Add(e.LogLog);
			}

			// Token: 0x17000196 RID: 406
			// (get) Token: 0x060007CB RID: 1995 RVA: 0x00018C6F File Offset: 0x00017C6F
			public IList Items
			{
				get
				{
					return this.items;
				}
			}

			// Token: 0x060007CC RID: 1996 RVA: 0x00018C77 File Offset: 0x00017C77
			public void Dispose()
			{
				LogLog.LogReceived -= this.handler;
			}

			// Token: 0x04000256 RID: 598
			private readonly IList items;

			// Token: 0x04000257 RID: 599
			private readonly LogReceivedEventHandler handler;
		}
	}
}

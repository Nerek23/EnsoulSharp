using System;
using log4net;
using log4net.Config;

namespace EnsoulSharp
{
	// Token: 0x0200003C RID: 60
	public class Log
	{
		// Token: 0x0600026F RID: 623 RVA: 0x000011E4 File Offset: 0x000005E4
		private static ILog GetLogger()
		{
			if (Log.Logger == null)
			{
				XmlConfigurator.Configure(typeof(Log).Assembly.GetManifestResourceStream("log4net.config"));
				Log.Logger = LogManager.GetLogger("Default");
			}
			return Log.Logger;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00001264 File Offset: 0x00000664
		internal static void Debug(object message, Exception exception)
		{
			Log.GetLogger().Debug(message, exception);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000124C File Offset: 0x0000064C
		internal static void Debug(object message)
		{
			Log.GetLogger().Debug(message);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000012F0 File Offset: 0x000006F0
		internal static void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			Log.GetLogger().DebugFormat(provider, format, args);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x000012D4 File Offset: 0x000006D4
		internal static void DebugFormat(string format, params object[] args)
		{
			Log.GetLogger().DebugFormat(format, args);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000012B8 File Offset: 0x000006B8
		internal static void DebugFormat(string format, object arg0, object arg1, object arg2)
		{
			Log.GetLogger().DebugFormat(format, arg0, arg1, arg2);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000129C File Offset: 0x0000069C
		internal static void DebugFormat(string format, object arg0, object arg1)
		{
			Log.GetLogger().DebugFormat(format, arg0, arg1);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00001280 File Offset: 0x00000680
		internal static void DebugFormat(string format, object arg0)
		{
			Log.GetLogger().DebugFormat(format, arg0);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00001324 File Offset: 0x00000724
		internal static void Error(object message, Exception exception)
		{
			Log.GetLogger().Error(message, exception);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000130C File Offset: 0x0000070C
		internal static void Error(object message)
		{
			Log.GetLogger().Error(message);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000013B0 File Offset: 0x000007B0
		internal static void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			Log.GetLogger().ErrorFormat(provider, format, args);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00001394 File Offset: 0x00000794
		internal static void ErrorFormat(string format, params object[] args)
		{
			Log.GetLogger().ErrorFormat(format, args);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00001378 File Offset: 0x00000778
		internal static void ErrorFormat(string format, object arg0, object arg1, object arg2)
		{
			Log.GetLogger().ErrorFormat(format, arg0, arg1, arg2);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000135C File Offset: 0x0000075C
		internal static void ErrorFormat(string format, object arg0, object arg1)
		{
			Log.GetLogger().ErrorFormat(format, arg0, arg1);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00001340 File Offset: 0x00000740
		internal static void ErrorFormat(string format, object arg0)
		{
			Log.GetLogger().ErrorFormat(format, arg0);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000013E4 File Offset: 0x000007E4
		internal static void Fatal(object message, Exception exception)
		{
			Log.GetLogger().Fatal(message, exception);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x000013CC File Offset: 0x000007CC
		internal static void Fatal(object message)
		{
			Log.GetLogger().Fatal(message);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00001470 File Offset: 0x00000870
		internal static void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			Log.GetLogger().FatalFormat(provider, format, args);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00001454 File Offset: 0x00000854
		internal static void FatalFormat(string format, params object[] args)
		{
			Log.GetLogger().FatalFormat(format, args);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00001438 File Offset: 0x00000838
		internal static void FatalFormat(string format, object arg0, object arg1, object arg2)
		{
			Log.GetLogger().FatalFormat(format, arg0, arg1, arg2);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000141C File Offset: 0x0000081C
		internal static void FatalFormat(string format, object arg0, object arg1)
		{
			Log.GetLogger().FatalFormat(format, arg0, arg1);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00001400 File Offset: 0x00000800
		internal static void FatalFormat(string format, object arg0)
		{
			Log.GetLogger().FatalFormat(format, arg0);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000014A4 File Offset: 0x000008A4
		internal static void Info(object message, Exception exception)
		{
			Log.GetLogger().Info(message, exception);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000148C File Offset: 0x0000088C
		internal static void Info(object message)
		{
			Log.GetLogger().Info(message);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00001530 File Offset: 0x00000930
		internal static void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			Log.GetLogger().InfoFormat(provider, format, args);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00001514 File Offset: 0x00000914
		internal static void InfoFormat(string format, params object[] args)
		{
			Log.GetLogger().InfoFormat(format, args);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000014F8 File Offset: 0x000008F8
		internal static void InfoFormat(string format, object arg0, object arg1, object arg2)
		{
			Log.GetLogger().InfoFormat(format, arg0, arg1, arg2);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000014DC File Offset: 0x000008DC
		internal static void InfoFormat(string format, object arg0, object arg1)
		{
			Log.GetLogger().InfoFormat(format, arg0, arg1);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000014C0 File Offset: 0x000008C0
		internal static void InfoFormat(string format, object arg0)
		{
			Log.GetLogger().InfoFormat(format, arg0);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00001564 File Offset: 0x00000964
		internal static void Warn(object message, Exception exception)
		{
			Log.GetLogger().Warn(message, exception);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000154C File Offset: 0x0000094C
		internal static void Warn(object message)
		{
			Log.GetLogger().Warn(message);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x000015F0 File Offset: 0x000009F0
		internal static void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			Log.GetLogger().WarnFormat(provider, format, args);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x000015D4 File Offset: 0x000009D4
		internal static void WarnFormat(string format, params object[] args)
		{
			Log.GetLogger().WarnFormat(format, args);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000015B8 File Offset: 0x000009B8
		internal static void WarnFormat(string format, object arg0, object arg1, object arg2)
		{
			Log.GetLogger().WarnFormat(format, arg0, arg1, arg2);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000159C File Offset: 0x0000099C
		internal static void WarnFormat(string format, object arg0, object arg1)
		{
			Log.GetLogger().WarnFormat(format, arg0, arg1);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00001580 File Offset: 0x00000980
		internal static void WarnFormat(string format, object arg0)
		{
			Log.GetLogger().WarnFormat(format, arg0);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000122C File Offset: 0x0000062C
		public static void Configure(string logFilePath)
		{
			GlobalContext.Properties["LogFilePath"] = logFilePath;
		}

		// Token: 0x04000347 RID: 839
		private static ILog Logger = null;
	}
}

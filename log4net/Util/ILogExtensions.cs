using System;

namespace log4net.Util
{
	// Token: 0x02000013 RID: 19
	public static class ILogExtensions
	{
		// Token: 0x060000BB RID: 187 RVA: 0x000030D8 File Offset: 0x000020D8
		public static void DebugExt(this ILog logger, Func<object> callback)
		{
			try
			{
				if (logger.IsDebugEnabled)
				{
					logger.Debug(callback());
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003120 File Offset: 0x00002120
		public static void DebugExt(this ILog logger, Func<object> callback, Exception exception)
		{
			try
			{
				if (logger.IsDebugEnabled)
				{
					logger.Debug(callback(), exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000316C File Offset: 0x0000216C
		public static void DebugExt(this ILog logger, object message)
		{
			try
			{
				if (logger.IsDebugEnabled)
				{
					logger.Debug(message);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000031B0 File Offset: 0x000021B0
		public static void DebugExt(this ILog logger, object message, Exception exception)
		{
			try
			{
				if (logger.IsDebugEnabled)
				{
					logger.Debug(message, exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000031F4 File Offset: 0x000021F4
		public static void DebugFormatExt(this ILog logger, string format, object arg0)
		{
			try
			{
				if (logger.IsDebugEnabled)
				{
					logger.DebugFormat(format, arg0);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003238 File Offset: 0x00002238
		public static void DebugFormatExt(this ILog logger, string format, params object[] args)
		{
			try
			{
				if (logger.IsDebugEnabled)
				{
					logger.DebugFormat(format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000327C File Offset: 0x0000227C
		public static void DebugFormatExt(this ILog logger, IFormatProvider provider, string format, params object[] args)
		{
			try
			{
				if (logger.IsDebugEnabled)
				{
					logger.DebugFormat(provider, format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000032C4 File Offset: 0x000022C4
		public static void DebugFormatExt(this ILog logger, string format, object arg0, object arg1)
		{
			try
			{
				if (logger.IsDebugEnabled)
				{
					logger.DebugFormat(format, arg0, arg1);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000330C File Offset: 0x0000230C
		public static void DebugFormatExt(this ILog logger, string format, object arg0, object arg1, object arg2)
		{
			try
			{
				if (logger.IsDebugEnabled)
				{
					logger.DebugFormat(format, arg0, arg1, arg2);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003354 File Offset: 0x00002354
		public static void InfoExt(this ILog logger, Func<object> callback)
		{
			try
			{
				if (logger.IsInfoEnabled)
				{
					logger.Info(callback());
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000339C File Offset: 0x0000239C
		public static void InfoExt(this ILog logger, Func<object> callback, Exception exception)
		{
			try
			{
				if (logger.IsInfoEnabled)
				{
					logger.Info(callback(), exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000033E8 File Offset: 0x000023E8
		public static void InfoExt(this ILog logger, object message)
		{
			try
			{
				if (logger.IsInfoEnabled)
				{
					logger.Info(message);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000342C File Offset: 0x0000242C
		public static void InfoExt(this ILog logger, object message, Exception exception)
		{
			try
			{
				if (logger.IsInfoEnabled)
				{
					logger.Info(message, exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003470 File Offset: 0x00002470
		public static void InfoFormatExt(this ILog logger, string format, object arg0)
		{
			try
			{
				if (logger.IsInfoEnabled)
				{
					logger.InfoFormat(format, arg0);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000034B4 File Offset: 0x000024B4
		public static void InfoFormatExt(this ILog logger, string format, params object[] args)
		{
			try
			{
				if (logger.IsInfoEnabled)
				{
					logger.InfoFormat(format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000034F8 File Offset: 0x000024F8
		public static void InfoFormatExt(this ILog logger, IFormatProvider provider, string format, params object[] args)
		{
			try
			{
				if (logger.IsInfoEnabled)
				{
					logger.InfoFormat(provider, format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003540 File Offset: 0x00002540
		public static void InfoFormatExt(this ILog logger, string format, object arg0, object arg1)
		{
			try
			{
				if (logger.IsInfoEnabled)
				{
					logger.InfoFormat(format, arg0, arg1);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003588 File Offset: 0x00002588
		public static void InfoFormatExt(this ILog logger, string format, object arg0, object arg1, object arg2)
		{
			try
			{
				if (logger.IsInfoEnabled)
				{
					logger.InfoFormat(format, arg0, arg1, arg2);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000035D0 File Offset: 0x000025D0
		public static void WarnExt(this ILog logger, Func<object> callback)
		{
			try
			{
				if (logger.IsWarnEnabled)
				{
					logger.Warn(callback());
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003618 File Offset: 0x00002618
		public static void WarnExt(this ILog logger, Func<object> callback, Exception exception)
		{
			try
			{
				if (logger.IsWarnEnabled)
				{
					logger.Warn(callback(), exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003664 File Offset: 0x00002664
		public static void WarnExt(this ILog logger, object message)
		{
			try
			{
				if (logger.IsWarnEnabled)
				{
					logger.Warn(message);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000036A8 File Offset: 0x000026A8
		public static void WarnExt(this ILog logger, object message, Exception exception)
		{
			try
			{
				if (logger.IsWarnEnabled)
				{
					logger.Warn(message, exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000036EC File Offset: 0x000026EC
		public static void WarnFormatExt(this ILog logger, string format, object arg0)
		{
			try
			{
				if (logger.IsWarnEnabled)
				{
					logger.WarnFormat(format, arg0);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003730 File Offset: 0x00002730
		public static void WarnFormatExt(this ILog logger, string format, params object[] args)
		{
			try
			{
				if (logger.IsWarnEnabled)
				{
					logger.WarnFormat(format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003774 File Offset: 0x00002774
		public static void WarnFormatExt(this ILog logger, IFormatProvider provider, string format, params object[] args)
		{
			try
			{
				if (logger.IsWarnEnabled)
				{
					logger.WarnFormat(provider, format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000037BC File Offset: 0x000027BC
		public static void WarnFormatExt(this ILog logger, string format, object arg0, object arg1)
		{
			try
			{
				if (logger.IsWarnEnabled)
				{
					logger.WarnFormat(format, arg0, arg1);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00003804 File Offset: 0x00002804
		public static void WarnFormatExt(this ILog logger, string format, object arg0, object arg1, object arg2)
		{
			try
			{
				if (logger.IsWarnEnabled)
				{
					logger.WarnFormat(format, arg0, arg1, arg2);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000384C File Offset: 0x0000284C
		public static void ErrorExt(this ILog logger, Func<object> callback)
		{
			try
			{
				if (logger.IsErrorEnabled)
				{
					logger.Error(callback());
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00003894 File Offset: 0x00002894
		public static void ErrorExt(this ILog logger, Func<object> callback, Exception exception)
		{
			try
			{
				if (logger.IsErrorEnabled)
				{
					logger.Error(callback(), exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000038E0 File Offset: 0x000028E0
		public static void ErrorExt(this ILog logger, object message)
		{
			try
			{
				if (logger.IsErrorEnabled)
				{
					logger.Error(message);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003924 File Offset: 0x00002924
		public static void ErrorExt(this ILog logger, object message, Exception exception)
		{
			try
			{
				if (logger.IsErrorEnabled)
				{
					logger.Error(message, exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003968 File Offset: 0x00002968
		public static void ErrorFormatExt(this ILog logger, string format, object arg0)
		{
			try
			{
				if (logger.IsErrorEnabled)
				{
					logger.ErrorFormat(format, arg0);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000039AC File Offset: 0x000029AC
		public static void ErrorFormatExt(this ILog logger, string format, params object[] args)
		{
			try
			{
				if (logger.IsErrorEnabled)
				{
					logger.ErrorFormat(format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000039F0 File Offset: 0x000029F0
		public static void ErrorFormatExt(this ILog logger, IFormatProvider provider, string format, params object[] args)
		{
			try
			{
				if (logger.IsErrorEnabled)
				{
					logger.ErrorFormat(provider, format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00003A38 File Offset: 0x00002A38
		public static void ErrorFormatExt(this ILog logger, string format, object arg0, object arg1)
		{
			try
			{
				if (logger.IsErrorEnabled)
				{
					logger.ErrorFormat(format, arg0, arg1);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003A80 File Offset: 0x00002A80
		public static void ErrorFormatExt(this ILog logger, string format, object arg0, object arg1, object arg2)
		{
			try
			{
				if (logger.IsErrorEnabled)
				{
					logger.ErrorFormat(format, arg0, arg1, arg2);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003AC8 File Offset: 0x00002AC8
		public static void FatalExt(this ILog logger, Func<object> callback)
		{
			try
			{
				if (logger.IsFatalEnabled)
				{
					logger.Fatal(callback());
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00003B10 File Offset: 0x00002B10
		public static void FatalExt(this ILog logger, Func<object> callback, Exception exception)
		{
			try
			{
				if (logger.IsFatalEnabled)
				{
					logger.Fatal(callback(), exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003B5C File Offset: 0x00002B5C
		public static void FatalExt(this ILog logger, object message)
		{
			try
			{
				if (logger.IsFatalEnabled)
				{
					logger.Fatal(message);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003BA0 File Offset: 0x00002BA0
		public static void FatalExt(this ILog logger, object message, Exception exception)
		{
			try
			{
				if (logger.IsFatalEnabled)
				{
					logger.Fatal(message, exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003BE4 File Offset: 0x00002BE4
		public static void FatalFormatExt(this ILog logger, string format, object arg0)
		{
			try
			{
				if (logger.IsFatalEnabled)
				{
					logger.FatalFormat(format, arg0);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003C28 File Offset: 0x00002C28
		public static void FatalFormatExt(this ILog logger, string format, params object[] args)
		{
			try
			{
				if (logger.IsFatalEnabled)
				{
					logger.FatalFormat(format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00003C6C File Offset: 0x00002C6C
		public static void FatalFormatExt(this ILog logger, IFormatProvider provider, string format, params object[] args)
		{
			try
			{
				if (logger.IsFatalEnabled)
				{
					logger.FatalFormat(provider, format, args);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003CB4 File Offset: 0x00002CB4
		public static void FatalFormatExt(this ILog logger, string format, object arg0, object arg1)
		{
			try
			{
				if (logger.IsFatalEnabled)
				{
					logger.FatalFormat(format, arg0, arg1);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00003CFC File Offset: 0x00002CFC
		public static void FatalFormatExt(this ILog logger, string format, object arg0, object arg1, object arg2)
		{
			try
			{
				if (logger.IsFatalEnabled)
				{
					logger.FatalFormat(format, arg0, arg1, arg2);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(ILogExtensions.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x0400001C RID: 28
		private static readonly Type declaringType = typeof(ILogExtensions);
	}
}

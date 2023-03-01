using System;
using System.Globalization;
using log4net.Repository;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000BB RID: 187
	public class LogImpl : LoggerWrapperImpl, ILog, ILoggerWrapper
	{
		// Token: 0x06000537 RID: 1335 RVA: 0x00010E88 File Offset: 0x0000FE88
		public LogImpl(ILogger logger) : base(logger)
		{
			logger.Repository.ConfigurationChanged += this.LoggerRepositoryConfigurationChanged;
			this.ReloadLevels(logger.Repository);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00010EB4 File Offset: 0x0000FEB4
		protected virtual void ReloadLevels(ILoggerRepository repository)
		{
			LevelMap levelMap = repository.LevelMap;
			this.m_levelDebug = levelMap.LookupWithDefault(Level.Debug);
			this.m_levelInfo = levelMap.LookupWithDefault(Level.Info);
			this.m_levelWarn = levelMap.LookupWithDefault(Level.Warn);
			this.m_levelError = levelMap.LookupWithDefault(Level.Error);
			this.m_levelFatal = levelMap.LookupWithDefault(Level.Fatal);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00010F1D File Offset: 0x0000FF1D
		public virtual void Debug(object message)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelDebug, message, null);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00010F37 File Offset: 0x0000FF37
		public virtual void Debug(object message, Exception exception)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelDebug, message, exception);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00010F51 File Offset: 0x0000FF51
		public virtual void DebugFormat(string format, params object[] args)
		{
			if (this.IsDebugEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelDebug, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
			}
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00010F80 File Offset: 0x0000FF80
		public virtual void DebugFormat(string format, object arg0)
		{
			if (this.IsDebugEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelDebug, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0
				}), null);
			}
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00010FC4 File Offset: 0x0000FFC4
		public virtual void DebugFormat(string format, object arg0, object arg1)
		{
			if (this.IsDebugEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelDebug, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1
				}), null);
			}
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0001100C File Offset: 0x0001000C
		public virtual void DebugFormat(string format, object arg0, object arg1, object arg2)
		{
			if (this.IsDebugEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelDebug, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1,
					arg2
				}), null);
			}
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00011056 File Offset: 0x00010056
		public virtual void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			if (this.IsDebugEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelDebug, new SystemStringFormat(provider, format, args), null);
			}
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001107F File Offset: 0x0001007F
		public virtual void Info(object message)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelInfo, message, null);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00011099 File Offset: 0x00010099
		public virtual void Info(object message, Exception exception)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelInfo, message, exception);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x000110B3 File Offset: 0x000100B3
		public virtual void InfoFormat(string format, params object[] args)
		{
			if (this.IsInfoEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelInfo, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
			}
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x000110E0 File Offset: 0x000100E0
		public virtual void InfoFormat(string format, object arg0)
		{
			if (this.IsInfoEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelInfo, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0
				}), null);
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00011124 File Offset: 0x00010124
		public virtual void InfoFormat(string format, object arg0, object arg1)
		{
			if (this.IsInfoEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelInfo, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1
				}), null);
			}
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0001116C File Offset: 0x0001016C
		public virtual void InfoFormat(string format, object arg0, object arg1, object arg2)
		{
			if (this.IsInfoEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelInfo, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1,
					arg2
				}), null);
			}
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x000111B6 File Offset: 0x000101B6
		public virtual void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			if (this.IsInfoEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelInfo, new SystemStringFormat(provider, format, args), null);
			}
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x000111DF File Offset: 0x000101DF
		public virtual void Warn(object message)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelWarn, message, null);
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x000111F9 File Offset: 0x000101F9
		public virtual void Warn(object message, Exception exception)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelWarn, message, exception);
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00011213 File Offset: 0x00010213
		public virtual void WarnFormat(string format, params object[] args)
		{
			if (this.IsWarnEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelWarn, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00011240 File Offset: 0x00010240
		public virtual void WarnFormat(string format, object arg0)
		{
			if (this.IsWarnEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelWarn, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0
				}), null);
			}
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00011284 File Offset: 0x00010284
		public virtual void WarnFormat(string format, object arg0, object arg1)
		{
			if (this.IsWarnEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelWarn, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1
				}), null);
			}
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x000112CC File Offset: 0x000102CC
		public virtual void WarnFormat(string format, object arg0, object arg1, object arg2)
		{
			if (this.IsWarnEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelWarn, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1,
					arg2
				}), null);
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00011316 File Offset: 0x00010316
		public virtual void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			if (this.IsWarnEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelWarn, new SystemStringFormat(provider, format, args), null);
			}
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0001133F File Offset: 0x0001033F
		public virtual void Error(object message)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelError, message, null);
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00011359 File Offset: 0x00010359
		public virtual void Error(object message, Exception exception)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelError, message, exception);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00011373 File Offset: 0x00010373
		public virtual void ErrorFormat(string format, params object[] args)
		{
			if (this.IsErrorEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelError, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x000113A0 File Offset: 0x000103A0
		public virtual void ErrorFormat(string format, object arg0)
		{
			if (this.IsErrorEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelError, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0
				}), null);
			}
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x000113E4 File Offset: 0x000103E4
		public virtual void ErrorFormat(string format, object arg0, object arg1)
		{
			if (this.IsErrorEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelError, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1
				}), null);
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001142C File Offset: 0x0001042C
		public virtual void ErrorFormat(string format, object arg0, object arg1, object arg2)
		{
			if (this.IsErrorEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelError, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1,
					arg2
				}), null);
			}
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00011476 File Offset: 0x00010476
		public virtual void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			if (this.IsErrorEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelError, new SystemStringFormat(provider, format, args), null);
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0001149F File Offset: 0x0001049F
		public virtual void Fatal(object message)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelFatal, message, null);
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x000114B9 File Offset: 0x000104B9
		public virtual void Fatal(object message, Exception exception)
		{
			this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelFatal, message, exception);
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x000114D3 File Offset: 0x000104D3
		public virtual void FatalFormat(string format, params object[] args)
		{
			if (this.IsFatalEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelFatal, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
			}
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00011500 File Offset: 0x00010500
		public virtual void FatalFormat(string format, object arg0)
		{
			if (this.IsFatalEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelFatal, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0
				}), null);
			}
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00011544 File Offset: 0x00010544
		public virtual void FatalFormat(string format, object arg0, object arg1)
		{
			if (this.IsFatalEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelFatal, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1
				}), null);
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0001158C File Offset: 0x0001058C
		public virtual void FatalFormat(string format, object arg0, object arg1, object arg2)
		{
			if (this.IsFatalEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelFatal, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[]
				{
					arg0,
					arg1,
					arg2
				}), null);
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x000115D6 File Offset: 0x000105D6
		public virtual void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			if (this.IsFatalEnabled)
			{
				this.Logger.Log(LogImpl.ThisDeclaringType, this.m_levelFatal, new SystemStringFormat(provider, format, args), null);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x000115FF File Offset: 0x000105FF
		public virtual bool IsDebugEnabled
		{
			get
			{
				return this.Logger.IsEnabledFor(this.m_levelDebug);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x00011612 File Offset: 0x00010612
		public virtual bool IsInfoEnabled
		{
			get
			{
				return this.Logger.IsEnabledFor(this.m_levelInfo);
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x00011625 File Offset: 0x00010625
		public virtual bool IsWarnEnabled
		{
			get
			{
				return this.Logger.IsEnabledFor(this.m_levelWarn);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x00011638 File Offset: 0x00010638
		public virtual bool IsErrorEnabled
		{
			get
			{
				return this.Logger.IsEnabledFor(this.m_levelError);
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x0001164B File Offset: 0x0001064B
		public virtual bool IsFatalEnabled
		{
			get
			{
				return this.Logger.IsEnabledFor(this.m_levelFatal);
			}
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00011660 File Offset: 0x00010660
		private void LoggerRepositoryConfigurationChanged(object sender, EventArgs e)
		{
			ILoggerRepository loggerRepository = sender as ILoggerRepository;
			if (loggerRepository != null)
			{
				this.ReloadLevels(loggerRepository);
			}
		}

		// Token: 0x04000187 RID: 391
		private static readonly Type ThisDeclaringType = typeof(LogImpl);

		// Token: 0x04000188 RID: 392
		private Level m_levelDebug;

		// Token: 0x04000189 RID: 393
		private Level m_levelInfo;

		// Token: 0x0400018A RID: 394
		private Level m_levelWarn;

		// Token: 0x0400018B RID: 395
		private Level m_levelError;

		// Token: 0x0400018C RID: 396
		private Level m_levelFatal;
	}
}

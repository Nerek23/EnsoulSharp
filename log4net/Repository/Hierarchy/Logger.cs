using System;
using System.Security;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace log4net.Repository.Hierarchy
{
	// Token: 0x0200005A RID: 90
	public abstract class Logger : IAppenderAttachable, ILogger
	{
		// Token: 0x060002FA RID: 762 RVA: 0x00008C8E File Offset: 0x00007C8E
		protected Logger(string name)
		{
			this.m_name = string.Intern(name);
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002FB RID: 763 RVA: 0x00008CB4 File Offset: 0x00007CB4
		// (set) Token: 0x060002FC RID: 764 RVA: 0x00008CBC File Offset: 0x00007CBC
		public virtual Logger Parent
		{
			get
			{
				return this.m_parent;
			}
			set
			{
				this.m_parent = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00008CC5 File Offset: 0x00007CC5
		// (set) Token: 0x060002FE RID: 766 RVA: 0x00008CCD File Offset: 0x00007CCD
		public virtual bool Additivity
		{
			get
			{
				return this.m_additive;
			}
			set
			{
				this.m_additive = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00008CD8 File Offset: 0x00007CD8
		public virtual Level EffectiveLevel
		{
			get
			{
				for (Logger logger = this; logger != null; logger = logger.m_parent)
				{
					Level level = logger.m_level;
					if (level != null)
					{
						return level;
					}
				}
				return null;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00008D00 File Offset: 0x00007D00
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00008D08 File Offset: 0x00007D08
		public virtual Hierarchy Hierarchy
		{
			get
			{
				return this.m_hierarchy;
			}
			set
			{
				this.m_hierarchy = value;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00008D11 File Offset: 0x00007D11
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00008D19 File Offset: 0x00007D19
		public virtual Level Level
		{
			get
			{
				return this.m_level;
			}
			set
			{
				this.m_level = value;
			}
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00008D24 File Offset: 0x00007D24
		public virtual void AddAppender(IAppender newAppender)
		{
			if (newAppender == null)
			{
				throw new ArgumentNullException("newAppender");
			}
			this.m_appenderLock.AcquireWriterLock();
			try
			{
				if (this.m_appenderAttachedImpl == null)
				{
					this.m_appenderAttachedImpl = new AppenderAttachedImpl();
				}
				this.m_appenderAttachedImpl.AddAppender(newAppender);
			}
			finally
			{
				this.m_appenderLock.ReleaseWriterLock();
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000305 RID: 773 RVA: 0x00008D88 File Offset: 0x00007D88
		public virtual AppenderCollection Appenders
		{
			get
			{
				this.m_appenderLock.AcquireReaderLock();
				AppenderCollection result;
				try
				{
					if (this.m_appenderAttachedImpl == null)
					{
						result = AppenderCollection.EmptyCollection;
					}
					else
					{
						result = this.m_appenderAttachedImpl.Appenders;
					}
				}
				finally
				{
					this.m_appenderLock.ReleaseReaderLock();
				}
				return result;
			}
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00008DDC File Offset: 0x00007DDC
		public virtual IAppender GetAppender(string name)
		{
			this.m_appenderLock.AcquireReaderLock();
			IAppender result;
			try
			{
				if (this.m_appenderAttachedImpl == null || name == null)
				{
					result = null;
				}
				else
				{
					result = this.m_appenderAttachedImpl.GetAppender(name);
				}
			}
			finally
			{
				this.m_appenderLock.ReleaseReaderLock();
			}
			return result;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00008E30 File Offset: 0x00007E30
		public virtual void RemoveAllAppenders()
		{
			this.m_appenderLock.AcquireWriterLock();
			try
			{
				if (this.m_appenderAttachedImpl != null)
				{
					this.m_appenderAttachedImpl.RemoveAllAppenders();
					this.m_appenderAttachedImpl = null;
				}
			}
			finally
			{
				this.m_appenderLock.ReleaseWriterLock();
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00008E80 File Offset: 0x00007E80
		public virtual IAppender RemoveAppender(IAppender appender)
		{
			this.m_appenderLock.AcquireWriterLock();
			try
			{
				if (appender != null && this.m_appenderAttachedImpl != null)
				{
					return this.m_appenderAttachedImpl.RemoveAppender(appender);
				}
			}
			finally
			{
				this.m_appenderLock.ReleaseWriterLock();
			}
			return null;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00008ED4 File Offset: 0x00007ED4
		public virtual IAppender RemoveAppender(string name)
		{
			this.m_appenderLock.AcquireWriterLock();
			try
			{
				if (name != null && this.m_appenderAttachedImpl != null)
				{
					return this.m_appenderAttachedImpl.RemoveAppender(name);
				}
			}
			finally
			{
				this.m_appenderLock.ReleaseWriterLock();
			}
			return null;
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600030A RID: 778 RVA: 0x00008F28 File Offset: 0x00007F28
		public virtual string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00008F30 File Offset: 0x00007F30
		public virtual void Log(Type callerStackBoundaryDeclaringType, Level level, object message, Exception exception)
		{
			try
			{
				if (this.IsEnabledFor(level))
				{
					this.ForcedLog((callerStackBoundaryDeclaringType != null) ? callerStackBoundaryDeclaringType : Logger.declaringType, level, message, exception);
				}
			}
			catch (Exception exception2)
			{
				LogLog.Error(Logger.declaringType, "Exception while logging", exception2);
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00008F88 File Offset: 0x00007F88
		public virtual void Log(LoggingEvent logEvent)
		{
			try
			{
				if (logEvent != null && this.IsEnabledFor(logEvent.Level))
				{
					this.ForcedLog(logEvent);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(Logger.declaringType, "Exception while logging", exception);
			}
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00008FD4 File Offset: 0x00007FD4
		public virtual bool IsEnabledFor(Level level)
		{
			try
			{
				if (level != null)
				{
					if (this.m_hierarchy.IsDisabled(level))
					{
						return false;
					}
					return level >= this.EffectiveLevel;
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(Logger.declaringType, "Exception while logging", exception);
			}
			return false;
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600030E RID: 782 RVA: 0x00009034 File Offset: 0x00008034
		public ILoggerRepository Repository
		{
			get
			{
				return this.m_hierarchy;
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000903C File Offset: 0x0000803C
		protected virtual void CallAppenders(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			int num = 0;
			for (Logger logger = this; logger != null; logger = logger.m_parent)
			{
				if (logger.m_appenderAttachedImpl != null)
				{
					logger.m_appenderLock.AcquireReaderLock();
					try
					{
						if (logger.m_appenderAttachedImpl != null)
						{
							num += logger.m_appenderAttachedImpl.AppendLoopOnAppenders(loggingEvent);
						}
					}
					finally
					{
						logger.m_appenderLock.ReleaseReaderLock();
					}
				}
				if (!logger.m_additive)
				{
					break;
				}
			}
			if (!this.m_hierarchy.EmittedNoAppenderWarning && num == 0)
			{
				this.m_hierarchy.EmittedNoAppenderWarning = true;
				LogLog.Debug(Logger.declaringType, string.Concat(new string[]
				{
					"No appenders could be found for logger [",
					this.Name,
					"] repository [",
					this.Repository.Name,
					"]"
				}));
				LogLog.Debug(Logger.declaringType, "Please initialize the log4net system properly.");
				try
				{
					LogLog.Debug(Logger.declaringType, "    Current AppDomain context information: ");
					LogLog.Debug(Logger.declaringType, "       BaseDirectory   : " + SystemInfo.ApplicationBaseDirectory);
					LogLog.Debug(Logger.declaringType, "       FriendlyName    : " + AppDomain.CurrentDomain.FriendlyName);
					LogLog.Debug(Logger.declaringType, "       DynamicDirectory: " + AppDomain.CurrentDomain.DynamicDirectory);
				}
				catch (SecurityException)
				{
				}
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000091A4 File Offset: 0x000081A4
		public virtual void CloseNestedAppenders()
		{
			this.m_appenderLock.AcquireWriterLock();
			try
			{
				if (this.m_appenderAttachedImpl != null)
				{
					foreach (IAppender appender in this.m_appenderAttachedImpl.Appenders)
					{
						if (appender is IAppenderAttachable)
						{
							appender.Close();
						}
					}
				}
			}
			finally
			{
				this.m_appenderLock.ReleaseWriterLock();
			}
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00009234 File Offset: 0x00008234
		public virtual void Log(Level level, object message, Exception exception)
		{
			if (this.IsEnabledFor(level))
			{
				this.ForcedLog(Logger.declaringType, level, message, exception);
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0000924D File Offset: 0x0000824D
		protected virtual void ForcedLog(Type callerStackBoundaryDeclaringType, Level level, object message, Exception exception)
		{
			this.CallAppenders(new LoggingEvent(callerStackBoundaryDeclaringType, this.Hierarchy, this.Name, level, message, exception));
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0000926B File Offset: 0x0000826B
		protected virtual void ForcedLog(LoggingEvent logEvent)
		{
			logEvent.EnsureRepository(this.Hierarchy);
			this.CallAppenders(logEvent);
		}

		// Token: 0x0400009E RID: 158
		private static readonly Type declaringType = typeof(Logger);

		// Token: 0x0400009F RID: 159
		private readonly string m_name;

		// Token: 0x040000A0 RID: 160
		private Level m_level;

		// Token: 0x040000A1 RID: 161
		private Logger m_parent;

		// Token: 0x040000A2 RID: 162
		private Hierarchy m_hierarchy;

		// Token: 0x040000A3 RID: 163
		private AppenderAttachedImpl m_appenderAttachedImpl;

		// Token: 0x040000A4 RID: 164
		private bool m_additive = true;

		// Token: 0x040000A5 RID: 165
		private readonly ReaderWriterLock m_appenderLock = new ReaderWriterLock();
	}
}

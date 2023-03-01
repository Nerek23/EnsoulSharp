using System;
using log4net.Appender;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000009 RID: 9
	public class AppenderAttachedImpl : IAppenderAttachable
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00002420 File Offset: 0x00001420
		public int AppendLoopOnAppenders(LoggingEvent loggingEvent)
		{
			if (loggingEvent == null)
			{
				throw new ArgumentNullException("loggingEvent");
			}
			if (this.m_appenderList == null)
			{
				return 0;
			}
			if (this.m_appenderArray == null)
			{
				this.m_appenderArray = this.m_appenderList.ToArray();
			}
			foreach (IAppender appender in this.m_appenderArray)
			{
				try
				{
					appender.DoAppend(loggingEvent);
				}
				catch (Exception exception)
				{
					LogLog.Error(AppenderAttachedImpl.declaringType, "Failed to append to appender [" + appender.Name + "]", exception);
				}
			}
			return this.m_appenderList.Count;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000024C0 File Offset: 0x000014C0
		public int AppendLoopOnAppenders(LoggingEvent[] loggingEvents)
		{
			if (loggingEvents == null)
			{
				throw new ArgumentNullException("loggingEvents");
			}
			if (loggingEvents.Length == 0)
			{
				throw new ArgumentException("loggingEvents array must not be empty", "loggingEvents");
			}
			if (loggingEvents.Length == 1)
			{
				return this.AppendLoopOnAppenders(loggingEvents[0]);
			}
			if (this.m_appenderList == null)
			{
				return 0;
			}
			if (this.m_appenderArray == null)
			{
				this.m_appenderArray = this.m_appenderList.ToArray();
			}
			foreach (IAppender appender in this.m_appenderArray)
			{
				try
				{
					AppenderAttachedImpl.CallAppend(appender, loggingEvents);
				}
				catch (Exception exception)
				{
					LogLog.Error(AppenderAttachedImpl.declaringType, "Failed to append to appender [" + appender.Name + "]", exception);
				}
			}
			return this.m_appenderList.Count;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002584 File Offset: 0x00001584
		private static void CallAppend(IAppender appender, LoggingEvent[] loggingEvents)
		{
			IBulkAppender bulkAppender = appender as IBulkAppender;
			if (bulkAppender != null)
			{
				bulkAppender.DoAppend(loggingEvents);
				return;
			}
			foreach (LoggingEvent loggingEvent in loggingEvents)
			{
				appender.DoAppend(loggingEvent);
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000025C0 File Offset: 0x000015C0
		public void AddAppender(IAppender newAppender)
		{
			if (newAppender == null)
			{
				throw new ArgumentNullException("newAppender");
			}
			this.m_appenderArray = null;
			if (this.m_appenderList == null)
			{
				this.m_appenderList = new AppenderCollection(1);
			}
			if (!this.m_appenderList.Contains(newAppender))
			{
				this.m_appenderList.Add(newAppender);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002611 File Offset: 0x00001611
		public AppenderCollection Appenders
		{
			get
			{
				if (this.m_appenderList == null)
				{
					return AppenderCollection.EmptyCollection;
				}
				return AppenderCollection.ReadOnly(this.m_appenderList);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000262C File Offset: 0x0000162C
		public IAppender GetAppender(string name)
		{
			if (this.m_appenderList != null && name != null)
			{
				foreach (IAppender appender in this.m_appenderList)
				{
					if (name == appender.Name)
					{
						return appender;
					}
				}
			}
			return null;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000269C File Offset: 0x0000169C
		public void RemoveAllAppenders()
		{
			if (this.m_appenderList != null)
			{
				foreach (IAppender appender in this.m_appenderList)
				{
					try
					{
						appender.Close();
					}
					catch (Exception exception)
					{
						LogLog.Error(AppenderAttachedImpl.declaringType, "Failed to Close appender [" + appender.Name + "]", exception);
					}
				}
				this.m_appenderList = null;
				this.m_appenderArray = null;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002738 File Offset: 0x00001738
		public IAppender RemoveAppender(IAppender appender)
		{
			if (appender != null && this.m_appenderList != null)
			{
				this.m_appenderList.Remove(appender);
				if (this.m_appenderList.Count == 0)
				{
					this.m_appenderList = null;
				}
				this.m_appenderArray = null;
			}
			return appender;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000276D File Offset: 0x0000176D
		public IAppender RemoveAppender(string name)
		{
			return this.RemoveAppender(this.GetAppender(name));
		}

		// Token: 0x04000007 RID: 7
		private AppenderCollection m_appenderList;

		// Token: 0x04000008 RID: 8
		private IAppender[] m_appenderArray;

		// Token: 0x04000009 RID: 9
		private static readonly Type declaringType = typeof(AppenderAttachedImpl);
	}
}

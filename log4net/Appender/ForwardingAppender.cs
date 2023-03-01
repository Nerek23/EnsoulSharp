using System;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000DD RID: 221
	public class ForwardingAppender : AppenderSkeleton, IAppenderAttachable
	{
		// Token: 0x060006D2 RID: 1746 RVA: 0x00015894 File Offset: 0x00014894
		protected override void OnClose()
		{
			lock (this)
			{
				if (this.m_appenderAttachedImpl != null)
				{
					this.m_appenderAttachedImpl.RemoveAllAppenders();
				}
			}
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x000158DC File Offset: 0x000148DC
		protected override void Append(LoggingEvent loggingEvent)
		{
			if (this.m_appenderAttachedImpl != null)
			{
				this.m_appenderAttachedImpl.AppendLoopOnAppenders(loggingEvent);
			}
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x000158F3 File Offset: 0x000148F3
		protected override void Append(LoggingEvent[] loggingEvents)
		{
			if (this.m_appenderAttachedImpl != null)
			{
				this.m_appenderAttachedImpl.AppendLoopOnAppenders(loggingEvents);
			}
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0001590C File Offset: 0x0001490C
		public virtual void AddAppender(IAppender newAppender)
		{
			if (newAppender == null)
			{
				throw new ArgumentNullException("newAppender");
			}
			lock (this)
			{
				if (this.m_appenderAttachedImpl == null)
				{
					this.m_appenderAttachedImpl = new AppenderAttachedImpl();
				}
				this.m_appenderAttachedImpl.AddAppender(newAppender);
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x00015970 File Offset: 0x00014970
		public virtual AppenderCollection Appenders
		{
			get
			{
				AppenderCollection result;
				lock (this)
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
				return result;
			}
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x000159C4 File Offset: 0x000149C4
		public virtual IAppender GetAppender(string name)
		{
			IAppender result;
			lock (this)
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
			return result;
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00015A18 File Offset: 0x00014A18
		public virtual void RemoveAllAppenders()
		{
			lock (this)
			{
				if (this.m_appenderAttachedImpl != null)
				{
					this.m_appenderAttachedImpl.RemoveAllAppenders();
					this.m_appenderAttachedImpl = null;
				}
			}
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00015A68 File Offset: 0x00014A68
		public virtual IAppender RemoveAppender(IAppender appender)
		{
			lock (this)
			{
				if (appender != null && this.m_appenderAttachedImpl != null)
				{
					return this.m_appenderAttachedImpl.RemoveAppender(appender);
				}
			}
			return null;
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x00015ABC File Offset: 0x00014ABC
		public virtual IAppender RemoveAppender(string name)
		{
			lock (this)
			{
				if (name != null && this.m_appenderAttachedImpl != null)
				{
					return this.m_appenderAttachedImpl.RemoveAppender(name);
				}
			}
			return null;
		}

		// Token: 0x04000200 RID: 512
		private AppenderAttachedImpl m_appenderAttachedImpl;
	}
}

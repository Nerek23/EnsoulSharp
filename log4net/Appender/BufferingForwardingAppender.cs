using System;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000D7 RID: 215
	public class BufferingForwardingAppender : BufferingAppenderSkeleton, IAppenderAttachable
	{
		// Token: 0x06000678 RID: 1656 RVA: 0x000147CC File Offset: 0x000137CC
		protected override void OnClose()
		{
			lock (this)
			{
				base.OnClose();
				if (this.m_appenderAttachedImpl != null)
				{
					this.m_appenderAttachedImpl.RemoveAllAppenders();
				}
			}
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0001481C File Offset: 0x0001381C
		protected override void SendBuffer(LoggingEvent[] events)
		{
			if (this.m_appenderAttachedImpl != null)
			{
				this.m_appenderAttachedImpl.AppendLoopOnAppenders(events);
			}
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00014834 File Offset: 0x00013834
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

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x00014898 File Offset: 0x00013898
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

		// Token: 0x0600067C RID: 1660 RVA: 0x000148EC File Offset: 0x000138EC
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

		// Token: 0x0600067D RID: 1661 RVA: 0x00014940 File Offset: 0x00013940
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

		// Token: 0x0600067E RID: 1662 RVA: 0x00014990 File Offset: 0x00013990
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

		// Token: 0x0600067F RID: 1663 RVA: 0x000149E4 File Offset: 0x000139E4
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

		// Token: 0x040001E0 RID: 480
		private AppenderAttachedImpl m_appenderAttachedImpl;
	}
}

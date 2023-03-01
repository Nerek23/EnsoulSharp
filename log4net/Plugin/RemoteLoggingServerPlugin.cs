using System;
using System.Runtime.Remoting;
using System.Security;
using log4net.Appender;
using log4net.Core;
using log4net.Repository;
using log4net.Util;

namespace log4net.Plugin
{
	// Token: 0x02000064 RID: 100
	public class RemoteLoggingServerPlugin : PluginSkeleton
	{
		// Token: 0x0600036C RID: 876 RVA: 0x0000B2C0 File Offset: 0x0000A2C0
		public RemoteLoggingServerPlugin() : base("RemoteLoggingServerPlugin:Unset URI")
		{
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000B2CD File Offset: 0x0000A2CD
		public RemoteLoggingServerPlugin(string sinkUri) : base("RemoteLoggingServerPlugin:" + sinkUri)
		{
			this.m_sinkUri = sinkUri;
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600036E RID: 878 RVA: 0x0000B2E7 File Offset: 0x0000A2E7
		// (set) Token: 0x0600036F RID: 879 RVA: 0x0000B2EF File Offset: 0x0000A2EF
		public virtual string SinkUri
		{
			get
			{
				return this.m_sinkUri;
			}
			set
			{
				this.m_sinkUri = value;
			}
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000B2F8 File Offset: 0x0000A2F8
		[SecuritySafeCritical]
		public override void Attach(ILoggerRepository repository)
		{
			base.Attach(repository);
			this.m_sink = new RemoteLoggingServerPlugin.RemoteLoggingSinkImpl(repository);
			try
			{
				RemotingServices.Marshal(this.m_sink, this.m_sinkUri, typeof(RemotingAppender.IRemoteLoggingSink));
			}
			catch (Exception exception)
			{
				LogLog.Error(RemoteLoggingServerPlugin.declaringType, "Failed to Marshal remoting sink", exception);
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000B35C File Offset: 0x0000A35C
		[SecuritySafeCritical]
		public override void Shutdown()
		{
			RemotingServices.Disconnect(this.m_sink);
			this.m_sink = null;
			base.Shutdown();
		}

		// Token: 0x040000CB RID: 203
		private RemoteLoggingServerPlugin.RemoteLoggingSinkImpl m_sink;

		// Token: 0x040000CC RID: 204
		private string m_sinkUri;

		// Token: 0x040000CD RID: 205
		private static readonly Type declaringType = typeof(RemoteLoggingServerPlugin);

		// Token: 0x020000FF RID: 255
		private class RemoteLoggingSinkImpl : MarshalByRefObject, RemotingAppender.IRemoteLoggingSink
		{
			// Token: 0x060007FE RID: 2046 RVA: 0x00018FDB File Offset: 0x00017FDB
			public RemoteLoggingSinkImpl(ILoggerRepository repository)
			{
				this.m_repository = repository;
			}

			// Token: 0x060007FF RID: 2047 RVA: 0x00018FEC File Offset: 0x00017FEC
			public void LogEvents(LoggingEvent[] events)
			{
				if (events != null)
				{
					foreach (LoggingEvent loggingEvent in events)
					{
						if (loggingEvent != null)
						{
							this.m_repository.Log(loggingEvent);
						}
					}
				}
			}

			// Token: 0x06000800 RID: 2048 RVA: 0x0001901F File Offset: 0x0001801F
			[SecurityCritical]
			public override object InitializeLifetimeService()
			{
				return null;
			}

			// Token: 0x0400026E RID: 622
			private readonly ILoggerRepository m_repository;
		}
	}
}

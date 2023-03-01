using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000E4 RID: 228
	public class NetSendAppender : AppenderSkeleton
	{
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x00015F8C File Offset: 0x00014F8C
		// (set) Token: 0x06000702 RID: 1794 RVA: 0x00015F94 File Offset: 0x00014F94
		public string Sender
		{
			get
			{
				return this.m_sender;
			}
			set
			{
				this.m_sender = value;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x00015F9D File Offset: 0x00014F9D
		// (set) Token: 0x06000704 RID: 1796 RVA: 0x00015FA5 File Offset: 0x00014FA5
		public string Recipient
		{
			get
			{
				return this.m_recipient;
			}
			set
			{
				this.m_recipient = value;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00015FAE File Offset: 0x00014FAE
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x00015FB6 File Offset: 0x00014FB6
		public string Server
		{
			get
			{
				return this.m_server;
			}
			set
			{
				this.m_server = value;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00015FBF File Offset: 0x00014FBF
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x00015FC7 File Offset: 0x00014FC7
		public log4net.Core.SecurityContext SecurityContext
		{
			get
			{
				return this.m_securityContext;
			}
			set
			{
				this.m_securityContext = value;
			}
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00015FD0 File Offset: 0x00014FD0
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			if (this.Recipient == null)
			{
				throw new ArgumentNullException("Recipient", "The required property 'Recipient' was not specified.");
			}
			if (this.m_securityContext == null)
			{
				this.m_securityContext = SecurityContextProvider.DefaultProvider.CreateSecurityContext(this);
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x0001600C File Offset: 0x0001500C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		protected override void Append(LoggingEvent loggingEvent)
		{
			NativeError nativeError = null;
			string text = base.RenderLoggingEvent(loggingEvent);
			using (this.m_securityContext.Impersonate(this))
			{
				int num = NetSendAppender.NetMessageBufferSend(this.Server, this.Recipient, this.Sender, text, text.Length * Marshal.SystemDefaultCharSize);
				if (num != 0)
				{
					nativeError = NativeError.GetError(num);
				}
			}
			if (nativeError != null)
			{
				this.ErrorHandler.Error(string.Concat(new string[]
				{
					nativeError.ToString(),
					" (Params: Server=",
					this.Server,
					", Recipient=",
					this.Recipient,
					", Sender=",
					this.Sender,
					")"
				}));
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x000160D8 File Offset: 0x000150D8
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600070C RID: 1804
		[DllImport("netapi32.dll", SetLastError = true)]
		protected static extern int NetMessageBufferSend([MarshalAs(UnmanagedType.LPWStr)] string serverName, [MarshalAs(UnmanagedType.LPWStr)] string msgName, [MarshalAs(UnmanagedType.LPWStr)] string fromName, [MarshalAs(UnmanagedType.LPWStr)] string buffer, int bufferSize);

		// Token: 0x0400020B RID: 523
		private string m_server;

		// Token: 0x0400020C RID: 524
		private string m_sender;

		// Token: 0x0400020D RID: 525
		private string m_recipient;

		// Token: 0x0400020E RID: 526
		private log4net.Core.SecurityContext m_securityContext;
	}
}

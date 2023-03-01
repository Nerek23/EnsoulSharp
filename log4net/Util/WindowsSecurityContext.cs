using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000034 RID: 52
	public class WindowsSecurityContext : log4net.Core.SecurityContext, IOptionHandler
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00006CA7 File Offset: 0x00005CA7
		// (set) Token: 0x0600021A RID: 538 RVA: 0x00006CAF File Offset: 0x00005CAF
		public WindowsSecurityContext.ImpersonationMode Credentials
		{
			get
			{
				return this.m_impersonationMode;
			}
			set
			{
				this.m_impersonationMode = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00006CB8 File Offset: 0x00005CB8
		// (set) Token: 0x0600021C RID: 540 RVA: 0x00006CC0 File Offset: 0x00005CC0
		public string UserName
		{
			get
			{
				return this.m_userName;
			}
			set
			{
				this.m_userName = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600021D RID: 541 RVA: 0x00006CC9 File Offset: 0x00005CC9
		// (set) Token: 0x0600021E RID: 542 RVA: 0x00006CD1 File Offset: 0x00005CD1
		public string DomainName
		{
			get
			{
				return this.m_domainName;
			}
			set
			{
				this.m_domainName = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (set) Token: 0x0600021F RID: 543 RVA: 0x00006CDA File Offset: 0x00005CDA
		public string Password
		{
			set
			{
				this.m_password = value;
			}
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00006CE4 File Offset: 0x00005CE4
		public void ActivateOptions()
		{
			if (this.m_impersonationMode == WindowsSecurityContext.ImpersonationMode.User)
			{
				if (this.m_userName == null)
				{
					throw new ArgumentNullException("m_userName");
				}
				if (this.m_domainName == null)
				{
					throw new ArgumentNullException("m_domainName");
				}
				if (this.m_password == null)
				{
					throw new ArgumentNullException("m_password");
				}
				this.m_identity = WindowsSecurityContext.LogonUser(this.m_userName, this.m_domainName, this.m_password);
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00006D4F File Offset: 0x00005D4F
		public override IDisposable Impersonate(object state)
		{
			if (this.m_impersonationMode == WindowsSecurityContext.ImpersonationMode.User)
			{
				if (this.m_identity != null)
				{
					return new WindowsSecurityContext.DisposableImpersonationContext(this.m_identity.Impersonate());
				}
			}
			else if (this.m_impersonationMode == WindowsSecurityContext.ImpersonationMode.Process)
			{
				return new WindowsSecurityContext.DisposableImpersonationContext(WindowsIdentity.Impersonate(IntPtr.Zero));
			}
			return null;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00006D8C File Offset: 0x00005D8C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		private static WindowsIdentity LogonUser(string userName, string domainName, string password)
		{
			IntPtr zero = IntPtr.Zero;
			if (!WindowsSecurityContext.LogonUser(userName, domainName, password, 2, 0, ref zero))
			{
				NativeError lastError = NativeError.GetLastError();
				throw new Exception(string.Concat(new string[]
				{
					"Failed to LogonUser [",
					userName,
					"] in Domain [",
					domainName,
					"]. Error: ",
					lastError.ToString()
				}));
			}
			IntPtr zero2 = IntPtr.Zero;
			if (!WindowsSecurityContext.DuplicateToken(zero, 2, ref zero2))
			{
				NativeError lastError2 = NativeError.GetLastError();
				if (zero != IntPtr.Zero)
				{
					WindowsSecurityContext.CloseHandle(zero);
				}
				throw new Exception("Failed to DuplicateToken after LogonUser. Error: " + lastError2.ToString());
			}
			WindowsIdentity result = new WindowsIdentity(zero2);
			if (zero2 != IntPtr.Zero)
			{
				WindowsSecurityContext.CloseHandle(zero2);
			}
			if (zero != IntPtr.Zero)
			{
				WindowsSecurityContext.CloseHandle(zero);
			}
			return result;
		}

		// Token: 0x06000223 RID: 547
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

		// Token: 0x06000224 RID: 548
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern bool CloseHandle(IntPtr handle);

		// Token: 0x06000225 RID: 549
		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool DuplicateToken(IntPtr ExistingTokenHandle, int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);

		// Token: 0x04000075 RID: 117
		private WindowsSecurityContext.ImpersonationMode m_impersonationMode;

		// Token: 0x04000076 RID: 118
		private string m_userName;

		// Token: 0x04000077 RID: 119
		private string m_domainName = Environment.MachineName;

		// Token: 0x04000078 RID: 120
		private string m_password;

		// Token: 0x04000079 RID: 121
		private WindowsIdentity m_identity;

		// Token: 0x020000F6 RID: 246
		public enum ImpersonationMode
		{
			// Token: 0x0400025F RID: 607
			User,
			// Token: 0x04000260 RID: 608
			Process
		}

		// Token: 0x020000F7 RID: 247
		private sealed class DisposableImpersonationContext : IDisposable
		{
			// Token: 0x060007D5 RID: 2005 RVA: 0x00018D7E File Offset: 0x00017D7E
			public DisposableImpersonationContext(WindowsImpersonationContext impersonationContext)
			{
				this.m_impersonationContext = impersonationContext;
			}

			// Token: 0x060007D6 RID: 2006 RVA: 0x00018D8D File Offset: 0x00017D8D
			public void Dispose()
			{
				this.m_impersonationContext.Undo();
			}

			// Token: 0x04000261 RID: 609
			private readonly WindowsImpersonationContext m_impersonationContext;
		}
	}
}

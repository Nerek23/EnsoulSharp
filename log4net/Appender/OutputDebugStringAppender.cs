using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using log4net.Core;

namespace log4net.Appender
{
	// Token: 0x020000E5 RID: 229
	public class OutputDebugStringAppender : AppenderSkeleton
	{
		// Token: 0x0600070E RID: 1806 RVA: 0x000160E3 File Offset: 0x000150E3
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		protected override void Append(LoggingEvent loggingEvent)
		{
			OutputDebugStringAppender.OutputDebugString(base.RenderLoggingEvent(loggingEvent));
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x000160F1 File Offset: 0x000150F1
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000710 RID: 1808
		[DllImport("Kernel32.dll")]
		protected static extern void OutputDebugString(string message);
	}
}

using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000E1 RID: 225
	public class LocalSyslogAppender : AppenderSkeleton
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060006E2 RID: 1762 RVA: 0x00015B35 File Offset: 0x00014B35
		// (set) Token: 0x060006E3 RID: 1763 RVA: 0x00015B3D File Offset: 0x00014B3D
		public string Identity
		{
			get
			{
				return this.m_identity;
			}
			set
			{
				this.m_identity = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060006E4 RID: 1764 RVA: 0x00015B46 File Offset: 0x00014B46
		// (set) Token: 0x060006E5 RID: 1765 RVA: 0x00015B4E File Offset: 0x00014B4E
		public LocalSyslogAppender.SyslogFacility Facility
		{
			get
			{
				return this.m_facility;
			}
			set
			{
				this.m_facility = value;
			}
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00015B57 File Offset: 0x00014B57
		public void AddMapping(LocalSyslogAppender.LevelSeverity mapping)
		{
			this.m_levelMapping.Add(mapping);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00015B68 File Offset: 0x00014B68
		[SecuritySafeCritical]
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			this.m_levelMapping.ActivateOptions();
			string text = this.m_identity;
			if (text == null)
			{
				text = SystemInfo.ApplicationFriendlyName;
			}
			this.m_handleToIdentity = Marshal.StringToHGlobalAnsi(text);
			LocalSyslogAppender.openlog(this.m_handleToIdentity, 1, this.m_facility);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00015BB4 File Offset: 0x00014BB4
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		protected override void Append(LoggingEvent loggingEvent)
		{
			int priority = LocalSyslogAppender.GeneratePriority(this.m_facility, this.GetSeverity(loggingEvent.Level));
			string message = base.RenderLoggingEvent(loggingEvent);
			LocalSyslogAppender.syslog(priority, "%s", message);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00015BEC File Offset: 0x00014BEC
		[SecuritySafeCritical]
		protected override void OnClose()
		{
			base.OnClose();
			try
			{
				LocalSyslogAppender.closelog();
			}
			catch (DllNotFoundException)
			{
			}
			if (this.m_handleToIdentity != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_handleToIdentity);
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060006EA RID: 1770 RVA: 0x00015C38 File Offset: 0x00014C38
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00015C3C File Offset: 0x00014C3C
		protected virtual LocalSyslogAppender.SyslogSeverity GetSeverity(Level level)
		{
			LocalSyslogAppender.LevelSeverity levelSeverity = this.m_levelMapping.Lookup(level) as LocalSyslogAppender.LevelSeverity;
			if (levelSeverity != null)
			{
				return levelSeverity.Severity;
			}
			if (level >= Level.Alert)
			{
				return LocalSyslogAppender.SyslogSeverity.Alert;
			}
			if (level >= Level.Critical)
			{
				return LocalSyslogAppender.SyslogSeverity.Critical;
			}
			if (level >= Level.Error)
			{
				return LocalSyslogAppender.SyslogSeverity.Error;
			}
			if (level >= Level.Warn)
			{
				return LocalSyslogAppender.SyslogSeverity.Warning;
			}
			if (level >= Level.Notice)
			{
				return LocalSyslogAppender.SyslogSeverity.Notice;
			}
			if (level >= Level.Info)
			{
				return LocalSyslogAppender.SyslogSeverity.Informational;
			}
			return LocalSyslogAppender.SyslogSeverity.Debug;
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00015CC0 File Offset: 0x00014CC0
		private static int GeneratePriority(LocalSyslogAppender.SyslogFacility facility, LocalSyslogAppender.SyslogSeverity severity)
		{
			return (int)(facility * LocalSyslogAppender.SyslogFacility.Uucp + (int)severity);
		}

		// Token: 0x060006ED RID: 1773
		[DllImport("libc")]
		private static extern void openlog(IntPtr ident, int option, LocalSyslogAppender.SyslogFacility facility);

		// Token: 0x060006EE RID: 1774
		[DllImport("libc", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern void syslog(int priority, string format, string message);

		// Token: 0x060006EF RID: 1775
		[DllImport("libc")]
		private static extern void closelog();

		// Token: 0x04000201 RID: 513
		private LocalSyslogAppender.SyslogFacility m_facility = LocalSyslogAppender.SyslogFacility.User;

		// Token: 0x04000202 RID: 514
		private string m_identity;

		// Token: 0x04000203 RID: 515
		private IntPtr m_handleToIdentity = IntPtr.Zero;

		// Token: 0x04000204 RID: 516
		private LevelMapping m_levelMapping = new LevelMapping();

		// Token: 0x02000117 RID: 279
		public enum SyslogSeverity
		{
			// Token: 0x040002BB RID: 699
			Emergency,
			// Token: 0x040002BC RID: 700
			Alert,
			// Token: 0x040002BD RID: 701
			Critical,
			// Token: 0x040002BE RID: 702
			Error,
			// Token: 0x040002BF RID: 703
			Warning,
			// Token: 0x040002C0 RID: 704
			Notice,
			// Token: 0x040002C1 RID: 705
			Informational,
			// Token: 0x040002C2 RID: 706
			Debug
		}

		// Token: 0x02000118 RID: 280
		public enum SyslogFacility
		{
			// Token: 0x040002C4 RID: 708
			Kernel,
			// Token: 0x040002C5 RID: 709
			User,
			// Token: 0x040002C6 RID: 710
			Mail,
			// Token: 0x040002C7 RID: 711
			Daemons,
			// Token: 0x040002C8 RID: 712
			Authorization,
			// Token: 0x040002C9 RID: 713
			Syslog,
			// Token: 0x040002CA RID: 714
			Printer,
			// Token: 0x040002CB RID: 715
			News,
			// Token: 0x040002CC RID: 716
			Uucp,
			// Token: 0x040002CD RID: 717
			Clock,
			// Token: 0x040002CE RID: 718
			Authorization2,
			// Token: 0x040002CF RID: 719
			Ftp,
			// Token: 0x040002D0 RID: 720
			Ntp,
			// Token: 0x040002D1 RID: 721
			Audit,
			// Token: 0x040002D2 RID: 722
			Alert,
			// Token: 0x040002D3 RID: 723
			Clock2,
			// Token: 0x040002D4 RID: 724
			Local0,
			// Token: 0x040002D5 RID: 725
			Local1,
			// Token: 0x040002D6 RID: 726
			Local2,
			// Token: 0x040002D7 RID: 727
			Local3,
			// Token: 0x040002D8 RID: 728
			Local4,
			// Token: 0x040002D9 RID: 729
			Local5,
			// Token: 0x040002DA RID: 730
			Local6,
			// Token: 0x040002DB RID: 731
			Local7
		}

		// Token: 0x02000119 RID: 281
		public class LevelSeverity : LevelMappingEntry
		{
			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x06000891 RID: 2193 RVA: 0x00019E03 File Offset: 0x00018E03
			// (set) Token: 0x06000892 RID: 2194 RVA: 0x00019E0B File Offset: 0x00018E0B
			public LocalSyslogAppender.SyslogSeverity Severity
			{
				get
				{
					return this.m_severity;
				}
				set
				{
					this.m_severity = value;
				}
			}

			// Token: 0x040002DC RID: 732
			private LocalSyslogAppender.SyslogSeverity m_severity;
		}
	}
}

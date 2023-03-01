using System;
using System.Net;
using System.Text;
using log4net.Core;
using log4net.Layout;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000E6 RID: 230
	public class RemoteSyslogAppender : UdpAppender
	{
		// Token: 0x06000711 RID: 1809 RVA: 0x000160F4 File Offset: 0x000150F4
		public RemoteSyslogAppender()
		{
			base.RemotePort = 514;
			base.RemoteAddress = IPAddress.Parse("127.0.0.1");
			base.Encoding = Encoding.ASCII;
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000712 RID: 1810 RVA: 0x00016134 File Offset: 0x00015134
		// (set) Token: 0x06000713 RID: 1811 RVA: 0x0001613C File Offset: 0x0001513C
		public PatternLayout Identity
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

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000714 RID: 1812 RVA: 0x00016145 File Offset: 0x00015145
		// (set) Token: 0x06000715 RID: 1813 RVA: 0x0001614D File Offset: 0x0001514D
		public RemoteSyslogAppender.SyslogFacility Facility
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

		// Token: 0x06000716 RID: 1814 RVA: 0x00016156 File Offset: 0x00015156
		public void AddMapping(RemoteSyslogAppender.LevelSeverity mapping)
		{
			this.m_levelMapping.Add(mapping);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00016164 File Offset: 0x00015164
		protected override void Append(LoggingEvent loggingEvent)
		{
			try
			{
				int value = RemoteSyslogAppender.GeneratePriority(this.m_facility, this.GetSeverity(loggingEvent.Level));
				string value2;
				if (this.m_identity != null)
				{
					value2 = this.m_identity.Format(loggingEvent);
				}
				else
				{
					value2 = loggingEvent.Domain;
				}
				string text = base.RenderLoggingEvent(loggingEvent);
				int i = 0;
				StringBuilder stringBuilder = new StringBuilder();
				while (i < text.Length)
				{
					stringBuilder.Length = 0;
					stringBuilder.Append('<');
					stringBuilder.Append(value);
					stringBuilder.Append('>');
					stringBuilder.Append(value2);
					stringBuilder.Append(": ");
					while (i < text.Length)
					{
						char c = text[i];
						if (c >= ' ' && c <= '~')
						{
							stringBuilder.Append(c);
						}
						else if (c == '\r' || c == '\n')
						{
							if (text.Length > i + 1 && (text[i + 1] == '\r' || text[i + 1] == '\n'))
							{
								i++;
							}
							i++;
							break;
						}
						i++;
					}
					byte[] bytes = base.Encoding.GetBytes(stringBuilder.ToString());
					base.Client.SendAsync(bytes, bytes.Length, base.RemoteEndPoint).Wait();
				}
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error(string.Concat(new string[]
				{
					"Unable to send logging event to remote syslog ",
					base.RemoteAddress.ToString(),
					" on port ",
					base.RemotePort.ToString(),
					"."
				}), e, ErrorCode.WriteFailure);
			}
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0001631C File Offset: 0x0001531C
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			this.m_levelMapping.ActivateOptions();
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00016330 File Offset: 0x00015330
		protected virtual RemoteSyslogAppender.SyslogSeverity GetSeverity(Level level)
		{
			RemoteSyslogAppender.LevelSeverity levelSeverity = this.m_levelMapping.Lookup(level) as RemoteSyslogAppender.LevelSeverity;
			if (levelSeverity != null)
			{
				return levelSeverity.Severity;
			}
			if (level >= Level.Alert)
			{
				return RemoteSyslogAppender.SyslogSeverity.Alert;
			}
			if (level >= Level.Critical)
			{
				return RemoteSyslogAppender.SyslogSeverity.Critical;
			}
			if (level >= Level.Error)
			{
				return RemoteSyslogAppender.SyslogSeverity.Error;
			}
			if (level >= Level.Warn)
			{
				return RemoteSyslogAppender.SyslogSeverity.Warning;
			}
			if (level >= Level.Notice)
			{
				return RemoteSyslogAppender.SyslogSeverity.Notice;
			}
			if (level >= Level.Info)
			{
				return RemoteSyslogAppender.SyslogSeverity.Informational;
			}
			return RemoteSyslogAppender.SyslogSeverity.Debug;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x000163B4 File Offset: 0x000153B4
		public static int GeneratePriority(RemoteSyslogAppender.SyslogFacility facility, RemoteSyslogAppender.SyslogSeverity severity)
		{
			if (facility < RemoteSyslogAppender.SyslogFacility.Kernel || facility > RemoteSyslogAppender.SyslogFacility.Local7)
			{
				throw new ArgumentException("SyslogFacility out of range", "facility");
			}
			if (severity < RemoteSyslogAppender.SyslogSeverity.Emergency || severity > RemoteSyslogAppender.SyslogSeverity.Debug)
			{
				throw new ArgumentException("SyslogSeverity out of range", "severity");
			}
			return (int)(facility * RemoteSyslogAppender.SyslogFacility.Uucp + (int)severity);
		}

		// Token: 0x0400020F RID: 527
		private const int DefaultSyslogPort = 514;

		// Token: 0x04000210 RID: 528
		private RemoteSyslogAppender.SyslogFacility m_facility = RemoteSyslogAppender.SyslogFacility.User;

		// Token: 0x04000211 RID: 529
		private PatternLayout m_identity;

		// Token: 0x04000212 RID: 530
		private LevelMapping m_levelMapping = new LevelMapping();

		// Token: 0x04000213 RID: 531
		private const int c_renderBufferSize = 256;

		// Token: 0x04000214 RID: 532
		private const int c_renderBufferMaxCapacity = 1024;

		// Token: 0x0200011B RID: 283
		public enum SyslogSeverity
		{
			// Token: 0x040002E2 RID: 738
			Emergency,
			// Token: 0x040002E3 RID: 739
			Alert,
			// Token: 0x040002E4 RID: 740
			Critical,
			// Token: 0x040002E5 RID: 741
			Error,
			// Token: 0x040002E6 RID: 742
			Warning,
			// Token: 0x040002E7 RID: 743
			Notice,
			// Token: 0x040002E8 RID: 744
			Informational,
			// Token: 0x040002E9 RID: 745
			Debug
		}

		// Token: 0x0200011C RID: 284
		public enum SyslogFacility
		{
			// Token: 0x040002EB RID: 747
			Kernel,
			// Token: 0x040002EC RID: 748
			User,
			// Token: 0x040002ED RID: 749
			Mail,
			// Token: 0x040002EE RID: 750
			Daemons,
			// Token: 0x040002EF RID: 751
			Authorization,
			// Token: 0x040002F0 RID: 752
			Syslog,
			// Token: 0x040002F1 RID: 753
			Printer,
			// Token: 0x040002F2 RID: 754
			News,
			// Token: 0x040002F3 RID: 755
			Uucp,
			// Token: 0x040002F4 RID: 756
			Clock,
			// Token: 0x040002F5 RID: 757
			Authorization2,
			// Token: 0x040002F6 RID: 758
			Ftp,
			// Token: 0x040002F7 RID: 759
			Ntp,
			// Token: 0x040002F8 RID: 760
			Audit,
			// Token: 0x040002F9 RID: 761
			Alert,
			// Token: 0x040002FA RID: 762
			Clock2,
			// Token: 0x040002FB RID: 763
			Local0,
			// Token: 0x040002FC RID: 764
			Local1,
			// Token: 0x040002FD RID: 765
			Local2,
			// Token: 0x040002FE RID: 766
			Local3,
			// Token: 0x040002FF RID: 767
			Local4,
			// Token: 0x04000300 RID: 768
			Local5,
			// Token: 0x04000301 RID: 769
			Local6,
			// Token: 0x04000302 RID: 770
			Local7
		}

		// Token: 0x0200011D RID: 285
		public class LevelSeverity : LevelMappingEntry
		{
			// Token: 0x170001CD RID: 461
			// (get) Token: 0x0600089B RID: 2203 RVA: 0x00019E64 File Offset: 0x00018E64
			// (set) Token: 0x0600089C RID: 2204 RVA: 0x00019E6C File Offset: 0x00018E6C
			public RemoteSyslogAppender.SyslogSeverity Severity
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

			// Token: 0x04000303 RID: 771
			private RemoteSyslogAppender.SyslogSeverity m_severity;
		}
	}
}

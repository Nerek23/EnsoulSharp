using System;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000EA RID: 234
	public class SmtpPickupDirAppender : BufferingAppenderSkeleton
	{
		// Token: 0x06000778 RID: 1912 RVA: 0x00017E62 File Offset: 0x00016E62
		public SmtpPickupDirAppender()
		{
			this.m_fileExtension = string.Empty;
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x00017E75 File Offset: 0x00016E75
		// (set) Token: 0x0600077A RID: 1914 RVA: 0x00017E7D File Offset: 0x00016E7D
		public string To
		{
			get
			{
				return this.m_to;
			}
			set
			{
				this.m_to = value;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x00017E86 File Offset: 0x00016E86
		// (set) Token: 0x0600077C RID: 1916 RVA: 0x00017E8E File Offset: 0x00016E8E
		public string From
		{
			get
			{
				return this.m_from;
			}
			set
			{
				this.m_from = value;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x00017E97 File Offset: 0x00016E97
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x00017E9F File Offset: 0x00016E9F
		public string Subject
		{
			get
			{
				return this.m_subject;
			}
			set
			{
				this.m_subject = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x00017EA8 File Offset: 0x00016EA8
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x00017EB0 File Offset: 0x00016EB0
		public string PickupDir
		{
			get
			{
				return this.m_pickupDir;
			}
			set
			{
				this.m_pickupDir = value;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x00017EB9 File Offset: 0x00016EB9
		// (set) Token: 0x06000782 RID: 1922 RVA: 0x00017EC4 File Offset: 0x00016EC4
		public string FileExtension
		{
			get
			{
				return this.m_fileExtension;
			}
			set
			{
				this.m_fileExtension = value;
				if (this.m_fileExtension == null)
				{
					this.m_fileExtension = string.Empty;
				}
				if (!string.IsNullOrEmpty(this.m_fileExtension) && !this.m_fileExtension.StartsWith("."))
				{
					this.m_fileExtension = "." + this.m_fileExtension;
				}
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x00017F20 File Offset: 0x00016F20
		// (set) Token: 0x06000784 RID: 1924 RVA: 0x00017F28 File Offset: 0x00016F28
		public SecurityContext SecurityContext
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

		// Token: 0x06000785 RID: 1925 RVA: 0x00017F34 File Offset: 0x00016F34
		protected override void SendBuffer(LoggingEvent[] events)
		{
			try
			{
				string text = null;
				StreamWriter streamWriter = null;
				using (this.SecurityContext.Impersonate(this))
				{
					text = Path.Combine(this.m_pickupDir, SystemInfo.NewGuid().ToString("N") + this.m_fileExtension);
					streamWriter = File.CreateText(text);
				}
				if (streamWriter == null)
				{
					this.ErrorHandler.Error("Failed to create output file for writing [" + text + "]", null, ErrorCode.FileOpenFailure);
				}
				else
				{
					using (streamWriter)
					{
						streamWriter.WriteLine("To: " + this.m_to);
						streamWriter.WriteLine("From: " + this.m_from);
						streamWriter.WriteLine("Subject: " + this.m_subject);
						streamWriter.WriteLine("Date: " + DateTime.UtcNow.ToString("r"));
						streamWriter.WriteLine("");
						string text2 = this.Layout.Header;
						if (text2 != null)
						{
							streamWriter.Write(text2);
						}
						for (int i = 0; i < events.Length; i++)
						{
							base.RenderLoggingEvent(streamWriter, events[i]);
						}
						text2 = this.Layout.Footer;
						if (text2 != null)
						{
							streamWriter.Write(text2);
						}
						streamWriter.WriteLine("");
						streamWriter.WriteLine(".");
					}
				}
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error("Error occurred while sending e-mail notification.", e);
			}
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x00018100 File Offset: 0x00017100
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			if (this.m_securityContext == null)
			{
				this.m_securityContext = SecurityContextProvider.DefaultProvider.CreateSecurityContext(this);
			}
			using (this.SecurityContext.Impersonate(this))
			{
				this.m_pickupDir = SmtpPickupDirAppender.ConvertToFullPath(this.m_pickupDir.Trim());
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x0001816C File Offset: 0x0001716C
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0001816F File Offset: 0x0001716F
		protected static string ConvertToFullPath(string path)
		{
			return SystemInfo.ConvertToFullPath(path);
		}

		// Token: 0x0400023C RID: 572
		private string m_to;

		// Token: 0x0400023D RID: 573
		private string m_from;

		// Token: 0x0400023E RID: 574
		private string m_subject;

		// Token: 0x0400023F RID: 575
		private string m_pickupDir;

		// Token: 0x04000240 RID: 576
		private string m_fileExtension;

		// Token: 0x04000241 RID: 577
		private SecurityContext m_securityContext;
	}
}

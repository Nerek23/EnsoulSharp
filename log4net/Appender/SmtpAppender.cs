using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using log4net.Core;

namespace log4net.Appender
{
	// Token: 0x020000E9 RID: 233
	public class SmtpAppender : BufferingAppenderSkeleton
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x00017AE2 File Offset: 0x00016AE2
		// (set) Token: 0x06000754 RID: 1876 RVA: 0x00017AEA File Offset: 0x00016AEA
		public string To
		{
			get
			{
				return this.m_to;
			}
			set
			{
				this.m_to = SmtpAppender.MaybeTrimSeparators(value);
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x00017AF8 File Offset: 0x00016AF8
		// (set) Token: 0x06000756 RID: 1878 RVA: 0x00017B00 File Offset: 0x00016B00
		public string Cc
		{
			get
			{
				return this.m_cc;
			}
			set
			{
				this.m_cc = SmtpAppender.MaybeTrimSeparators(value);
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x00017B0E File Offset: 0x00016B0E
		// (set) Token: 0x06000758 RID: 1880 RVA: 0x00017B16 File Offset: 0x00016B16
		public string Bcc
		{
			get
			{
				return this.m_bcc;
			}
			set
			{
				this.m_bcc = SmtpAppender.MaybeTrimSeparators(value);
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x00017B24 File Offset: 0x00016B24
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x00017B2C File Offset: 0x00016B2C
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

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x00017B35 File Offset: 0x00016B35
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x00017B3D File Offset: 0x00016B3D
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

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x00017B46 File Offset: 0x00016B46
		// (set) Token: 0x0600075E RID: 1886 RVA: 0x00017B4E File Offset: 0x00016B4E
		public string SmtpHost
		{
			get
			{
				return this.m_smtpHost;
			}
			set
			{
				this.m_smtpHost = value;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00017B57 File Offset: 0x00016B57
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x00017B5A File Offset: 0x00016B5A
		[Obsolete("Use the BufferingAppenderSkeleton Fix methods")]
		public bool LocationInfo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x00017B5C File Offset: 0x00016B5C
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x00017B64 File Offset: 0x00016B64
		public SmtpAppender.SmtpAuthentication Authentication
		{
			get
			{
				return this.m_authentication;
			}
			set
			{
				this.m_authentication = value;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x00017B6D File Offset: 0x00016B6D
		// (set) Token: 0x06000764 RID: 1892 RVA: 0x00017B75 File Offset: 0x00016B75
		public string Username
		{
			get
			{
				return this.m_username;
			}
			set
			{
				this.m_username = value;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x00017B7E File Offset: 0x00016B7E
		// (set) Token: 0x06000766 RID: 1894 RVA: 0x00017B86 File Offset: 0x00016B86
		public string Password
		{
			get
			{
				return this.m_password;
			}
			set
			{
				this.m_password = value;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x00017B8F File Offset: 0x00016B8F
		// (set) Token: 0x06000768 RID: 1896 RVA: 0x00017B97 File Offset: 0x00016B97
		public int Port
		{
			get
			{
				return this.m_port;
			}
			set
			{
				this.m_port = value;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x00017BA0 File Offset: 0x00016BA0
		// (set) Token: 0x0600076A RID: 1898 RVA: 0x00017BA8 File Offset: 0x00016BA8
		public MailPriority Priority
		{
			get
			{
				return this.m_mailPriority;
			}
			set
			{
				this.m_mailPriority = value;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x00017BB1 File Offset: 0x00016BB1
		// (set) Token: 0x0600076C RID: 1900 RVA: 0x00017BB9 File Offset: 0x00016BB9
		public bool EnableSsl
		{
			get
			{
				return this.m_enableSsl;
			}
			set
			{
				this.m_enableSsl = value;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x00017BC2 File Offset: 0x00016BC2
		// (set) Token: 0x0600076E RID: 1902 RVA: 0x00017BCA File Offset: 0x00016BCA
		public string ReplyTo
		{
			get
			{
				return this.m_replyTo;
			}
			set
			{
				this.m_replyTo = value;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x00017BD3 File Offset: 0x00016BD3
		// (set) Token: 0x06000770 RID: 1904 RVA: 0x00017BDB File Offset: 0x00016BDB
		public Encoding SubjectEncoding
		{
			get
			{
				return this.m_subjectEncoding;
			}
			set
			{
				this.m_subjectEncoding = value;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x00017BE4 File Offset: 0x00016BE4
		// (set) Token: 0x06000772 RID: 1906 RVA: 0x00017BEC File Offset: 0x00016BEC
		public Encoding BodyEncoding
		{
			get
			{
				return this.m_bodyEncoding;
			}
			set
			{
				this.m_bodyEncoding = value;
			}
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00017BF8 File Offset: 0x00016BF8
		protected override void SendBuffer(LoggingEvent[] events)
		{
			try
			{
				using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
				{
					string text = this.Layout.Header;
					if (text != null)
					{
						stringWriter.Write(text);
					}
					for (int i = 0; i < events.Length; i++)
					{
						base.RenderLoggingEvent(stringWriter, events[i]);
					}
					text = this.Layout.Footer;
					if (text != null)
					{
						stringWriter.Write(text);
					}
					this.SendEmail(stringWriter.ToString());
				}
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error("Error occurred while sending e-mail notification.", e);
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x00017CA0 File Offset: 0x00016CA0
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00017CA4 File Offset: 0x00016CA4
		protected virtual void SendEmail(string messageBody)
		{
			using (SmtpClient smtpClient = new SmtpClient())
			{
				if (!string.IsNullOrEmpty(this.m_smtpHost))
				{
					smtpClient.Host = this.m_smtpHost;
				}
				smtpClient.Port = this.m_port;
				smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtpClient.EnableSsl = this.m_enableSsl;
				if (this.m_authentication == SmtpAppender.SmtpAuthentication.Basic)
				{
					smtpClient.Credentials = new NetworkCredential(this.m_username, this.m_password);
				}
				else if (this.m_authentication == SmtpAppender.SmtpAuthentication.Ntlm)
				{
					smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
				}
				using (MailMessage mailMessage = new MailMessage())
				{
					mailMessage.Body = messageBody;
					mailMessage.BodyEncoding = this.m_bodyEncoding;
					mailMessage.From = new MailAddress(this.m_from);
					mailMessage.To.Add(this.m_to);
					if (!string.IsNullOrEmpty(this.m_cc))
					{
						mailMessage.CC.Add(this.m_cc);
					}
					if (!string.IsNullOrEmpty(this.m_bcc))
					{
						mailMessage.Bcc.Add(this.m_bcc);
					}
					if (!string.IsNullOrEmpty(this.m_replyTo))
					{
						mailMessage.ReplyToList.Add(new MailAddress(this.m_replyTo));
					}
					mailMessage.Subject = this.m_subject;
					mailMessage.SubjectEncoding = this.m_subjectEncoding;
					mailMessage.Priority = this.m_mailPriority;
					smtpClient.Send(mailMessage);
				}
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00017E34 File Offset: 0x00016E34
		private static string MaybeTrimSeparators(string s)
		{
			if (!string.IsNullOrEmpty(s))
			{
				return s.Trim(SmtpAppender.ADDRESS_DELIMITERS);
			}
			return s;
		}

		// Token: 0x0400022C RID: 556
		private string m_to;

		// Token: 0x0400022D RID: 557
		private string m_cc;

		// Token: 0x0400022E RID: 558
		private string m_bcc;

		// Token: 0x0400022F RID: 559
		private string m_from;

		// Token: 0x04000230 RID: 560
		private string m_subject;

		// Token: 0x04000231 RID: 561
		private string m_smtpHost;

		// Token: 0x04000232 RID: 562
		private Encoding m_subjectEncoding = Encoding.UTF8;

		// Token: 0x04000233 RID: 563
		private Encoding m_bodyEncoding = Encoding.UTF8;

		// Token: 0x04000234 RID: 564
		private SmtpAppender.SmtpAuthentication m_authentication;

		// Token: 0x04000235 RID: 565
		private string m_username;

		// Token: 0x04000236 RID: 566
		private string m_password;

		// Token: 0x04000237 RID: 567
		private int m_port = 25;

		// Token: 0x04000238 RID: 568
		private MailPriority m_mailPriority;

		// Token: 0x04000239 RID: 569
		private bool m_enableSsl;

		// Token: 0x0400023A RID: 570
		private string m_replyTo;

		// Token: 0x0400023B RID: 571
		private static readonly char[] ADDRESS_DELIMITERS = new char[]
		{
			',',
			';'
		};

		// Token: 0x02000124 RID: 292
		public enum SmtpAuthentication
		{
			// Token: 0x04000312 RID: 786
			None,
			// Token: 0x04000313 RID: 787
			Basic,
			// Token: 0x04000314 RID: 788
			Ntlm
		}
	}
}

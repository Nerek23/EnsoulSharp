using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000EE RID: 238
	public class UdpAppender : AppenderSkeleton
	{
		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x00018753 File Offset: 0x00017753
		// (set) Token: 0x060007B4 RID: 1972 RVA: 0x0001875B File Offset: 0x0001775B
		public IPAddress RemoteAddress
		{
			get
			{
				return this.m_remoteAddress;
			}
			set
			{
				this.m_remoteAddress = value;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x00018764 File Offset: 0x00017764
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x0001876C File Offset: 0x0001776C
		public int RemotePort
		{
			get
			{
				return this.m_remotePort;
			}
			set
			{
				if (value < 0 || value > 65535)
				{
					throw SystemInfo.CreateArgumentOutOfRangeException("value", value, string.Concat(new string[]
					{
						"The value specified is less than ",
						0.ToString(NumberFormatInfo.InvariantInfo),
						" or greater than ",
						65535.ToString(NumberFormatInfo.InvariantInfo),
						"."
					}));
				}
				this.m_remotePort = value;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x000187E6 File Offset: 0x000177E6
		// (set) Token: 0x060007B8 RID: 1976 RVA: 0x000187F0 File Offset: 0x000177F0
		public int LocalPort
		{
			get
			{
				return this.m_localPort;
			}
			set
			{
				if (value != 0 && (value < 0 || value > 65535))
				{
					throw SystemInfo.CreateArgumentOutOfRangeException("value", value, string.Concat(new string[]
					{
						"The value specified is less than ",
						0.ToString(NumberFormatInfo.InvariantInfo),
						" or greater than ",
						65535.ToString(NumberFormatInfo.InvariantInfo),
						"."
					}));
				}
				this.m_localPort = value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0001886D File Offset: 0x0001786D
		// (set) Token: 0x060007BA RID: 1978 RVA: 0x00018875 File Offset: 0x00017875
		public Encoding Encoding
		{
			get
			{
				return this.m_encoding;
			}
			set
			{
				this.m_encoding = value;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x0001887E File Offset: 0x0001787E
		// (set) Token: 0x060007BC RID: 1980 RVA: 0x00018886 File Offset: 0x00017886
		protected UdpClient Client
		{
			get
			{
				return this.m_client;
			}
			set
			{
				this.m_client = value;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x0001888F File Offset: 0x0001788F
		// (set) Token: 0x060007BE RID: 1982 RVA: 0x00018897 File Offset: 0x00017897
		protected IPEndPoint RemoteEndPoint
		{
			get
			{
				return this.m_remoteEndPoint;
			}
			set
			{
				this.m_remoteEndPoint = value;
			}
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x000188A0 File Offset: 0x000178A0
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			if (this.RemoteAddress == null)
			{
				throw new ArgumentNullException("The required property 'Address' was not specified.");
			}
			if (this.RemotePort < 0 || this.RemotePort > 65535)
			{
				throw SystemInfo.CreateArgumentOutOfRangeException("this.RemotePort", this.RemotePort, string.Concat(new string[]
				{
					"The RemotePort is less than ",
					0.ToString(NumberFormatInfo.InvariantInfo),
					" or greater than ",
					65535.ToString(NumberFormatInfo.InvariantInfo),
					"."
				}));
			}
			if (this.LocalPort != 0 && (this.LocalPort < 0 || this.LocalPort > 65535))
			{
				throw SystemInfo.CreateArgumentOutOfRangeException("this.LocalPort", this.LocalPort, string.Concat(new string[]
				{
					"The LocalPort is less than ",
					0.ToString(NumberFormatInfo.InvariantInfo),
					" or greater than ",
					65535.ToString(NumberFormatInfo.InvariantInfo),
					"."
				}));
			}
			this.RemoteEndPoint = new IPEndPoint(this.RemoteAddress, this.RemotePort);
			this.InitializeClientConnection();
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x000189D8 File Offset: 0x000179D8
		protected override void Append(LoggingEvent loggingEvent)
		{
			try
			{
				byte[] bytes = this.m_encoding.GetBytes(base.RenderLoggingEvent(loggingEvent).ToCharArray());
				this.Client.Send(bytes, bytes.Length, this.RemoteEndPoint);
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error(string.Concat(new string[]
				{
					"Unable to send logging event to remote host ",
					this.RemoteAddress.ToString(),
					" on port ",
					this.RemotePort.ToString(),
					"."
				}), e, ErrorCode.WriteFailure);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x00018A78 File Offset: 0x00017A78
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00018A7B File Offset: 0x00017A7B
		protected override void OnClose()
		{
			base.OnClose();
			if (this.Client != null)
			{
				this.Client.Close();
			}
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00018A98 File Offset: 0x00017A98
		protected virtual void InitializeClientConnection()
		{
			try
			{
				if (this.LocalPort == 0)
				{
					this.Client = new UdpClient(this.RemoteAddress.AddressFamily);
				}
				else
				{
					this.Client = new UdpClient(this.LocalPort, this.RemoteAddress.AddressFamily);
				}
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error("Could not initialize the UdpClient connection on port " + this.LocalPort.ToString(NumberFormatInfo.InvariantInfo) + ".", e, ErrorCode.GenericFailure);
				this.Client = null;
			}
		}

		// Token: 0x0400024A RID: 586
		private IPAddress m_remoteAddress;

		// Token: 0x0400024B RID: 587
		private int m_remotePort;

		// Token: 0x0400024C RID: 588
		private IPEndPoint m_remoteEndPoint;

		// Token: 0x0400024D RID: 589
		private int m_localPort;

		// Token: 0x0400024E RID: 590
		private UdpClient m_client;

		// Token: 0x0400024F RID: 591
		private Encoding m_encoding = Encoding.Default;
	}
}

using System;
using System.IO;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000029 RID: 41
	public class QuietTextWriter : TextWriterAdapter
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x00005A8E File Offset: 0x00004A8E
		public QuietTextWriter(TextWriter writer, IErrorHandler errorHandler) : base(writer)
		{
			if (errorHandler == null)
			{
				throw new ArgumentNullException("errorHandler");
			}
			this.ErrorHandler = errorHandler;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00005AAC File Offset: 0x00004AAC
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x00005AB4 File Offset: 0x00004AB4
		public IErrorHandler ErrorHandler
		{
			get
			{
				return this.m_errorHandler;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.m_errorHandler = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00005ACB File Offset: 0x00004ACB
		public bool Closed
		{
			get
			{
				return this.m_closed;
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00005AD4 File Offset: 0x00004AD4
		public override void Write(char value)
		{
			try
			{
				base.Write(value);
			}
			catch (Exception e)
			{
				this.m_errorHandler.Error("Failed to write [" + value.ToString() + "].", e, ErrorCode.WriteFailure);
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00005B20 File Offset: 0x00004B20
		public override void Write(char[] buffer, int index, int count)
		{
			try
			{
				base.Write(buffer, index, count);
			}
			catch (Exception e)
			{
				this.m_errorHandler.Error("Failed to write buffer.", e, ErrorCode.WriteFailure);
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00005B60 File Offset: 0x00004B60
		public override void Write(string value)
		{
			try
			{
				base.Write(value);
			}
			catch (Exception e)
			{
				this.m_errorHandler.Error("Failed to write [" + value + "].", e, ErrorCode.WriteFailure);
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00005BA8 File Offset: 0x00004BA8
		public override void Close()
		{
			this.m_closed = true;
			base.Close();
		}

		// Token: 0x0400005C RID: 92
		private IErrorHandler m_errorHandler;

		// Token: 0x0400005D RID: 93
		private bool m_closed;
	}
}

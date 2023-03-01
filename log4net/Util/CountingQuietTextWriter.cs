using System;
using System.IO;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x0200000D RID: 13
	public class CountingQuietTextWriter : QuietTextWriter
	{
		// Token: 0x06000084 RID: 132 RVA: 0x00002942 File Offset: 0x00001942
		public CountingQuietTextWriter(TextWriter writer, IErrorHandler errorHandler) : base(writer, errorHandler)
		{
			this.m_countBytes = 0L;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002954 File Offset: 0x00001954
		public override void Write(char value)
		{
			try
			{
				base.Write(value);
				this.m_countBytes += (long)this.Encoding.GetByteCount(new char[]
				{
					value
				});
			}
			catch (Exception e)
			{
				base.ErrorHandler.Error("Failed to write [" + value.ToString() + "].", e, ErrorCode.WriteFailure);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000029C4 File Offset: 0x000019C4
		public override void Write(char[] buffer, int index, int count)
		{
			if (count > 0)
			{
				try
				{
					base.Write(buffer, index, count);
					this.m_countBytes += (long)this.Encoding.GetByteCount(buffer, index, count);
				}
				catch (Exception e)
				{
					base.ErrorHandler.Error("Failed to write buffer.", e, ErrorCode.WriteFailure);
				}
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00002A24 File Offset: 0x00001A24
		public override void Write(string str)
		{
			if (str != null && str.Length > 0)
			{
				try
				{
					base.Write(str);
					this.m_countBytes += (long)this.Encoding.GetByteCount(str);
				}
				catch (Exception e)
				{
					base.ErrorHandler.Error("Failed to write [" + str + "].", e, ErrorCode.WriteFailure);
				}
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00002A90 File Offset: 0x00001A90
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00002A98 File Offset: 0x00001A98
		public long Count
		{
			get
			{
				return this.m_countBytes;
			}
			set
			{
				this.m_countBytes = value;
			}
		}

		// Token: 0x0400000F RID: 15
		private long m_countBytes;
	}
}

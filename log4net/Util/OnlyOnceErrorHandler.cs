using System;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000021 RID: 33
	public class OnlyOnceErrorHandler : IErrorHandler
	{
		// Token: 0x06000149 RID: 329 RVA: 0x00004772 File Offset: 0x00003772
		public OnlyOnceErrorHandler()
		{
			this.m_prefix = "";
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000478C File Offset: 0x0000378C
		public OnlyOnceErrorHandler(string prefix)
		{
			this.m_prefix = prefix;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000047A2 File Offset: 0x000037A2
		public void Reset()
		{
			this.m_enabledDateUtc = DateTime.MinValue;
			this.m_errorCode = ErrorCode.GenericFailure;
			this.m_exception = null;
			this.m_message = null;
			this.m_firstTime = true;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000047CB File Offset: 0x000037CB
		public void Error(string message, Exception e, ErrorCode errorCode)
		{
			if (this.m_firstTime)
			{
				this.FirstError(message, e, errorCode);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000047E0 File Offset: 0x000037E0
		public virtual void FirstError(string message, Exception e, ErrorCode errorCode)
		{
			this.m_enabledDateUtc = DateTime.UtcNow;
			this.m_errorCode = errorCode;
			this.m_exception = e;
			this.m_message = message;
			this.m_firstTime = false;
			if (LogLog.InternalDebugging && !LogLog.QuietMode)
			{
				LogLog.Error(OnlyOnceErrorHandler.declaringType, string.Concat(new string[]
				{
					"[",
					this.m_prefix,
					"] ErrorCode: ",
					errorCode.ToString(),
					". ",
					message
				}), e);
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000486D File Offset: 0x0000386D
		public void Error(string message, Exception e)
		{
			this.Error(message, e, ErrorCode.GenericFailure);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00004878 File Offset: 0x00003878
		public void Error(string message)
		{
			this.Error(message, null, ErrorCode.GenericFailure);
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00004883 File Offset: 0x00003883
		public bool IsEnabled
		{
			get
			{
				return this.m_firstTime;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0000488B File Offset: 0x0000388B
		public DateTime EnabledDate
		{
			get
			{
				if (this.m_enabledDateUtc == DateTime.MinValue)
				{
					return DateTime.MinValue;
				}
				return this.m_enabledDateUtc.ToLocalTime();
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000048B0 File Offset: 0x000038B0
		public DateTime EnabledDateUtc
		{
			get
			{
				return this.m_enabledDateUtc;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000153 RID: 339 RVA: 0x000048B8 File Offset: 0x000038B8
		public string ErrorMessage
		{
			get
			{
				return this.m_message;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000048C0 File Offset: 0x000038C0
		public Exception Exception
		{
			get
			{
				return this.m_exception;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000155 RID: 341 RVA: 0x000048C8 File Offset: 0x000038C8
		public ErrorCode ErrorCode
		{
			get
			{
				return this.m_errorCode;
			}
		}

		// Token: 0x0400003A RID: 58
		private DateTime m_enabledDateUtc;

		// Token: 0x0400003B RID: 59
		private bool m_firstTime = true;

		// Token: 0x0400003C RID: 60
		private string m_message;

		// Token: 0x0400003D RID: 61
		private Exception m_exception;

		// Token: 0x0400003E RID: 62
		private ErrorCode m_errorCode;

		// Token: 0x0400003F RID: 63
		private readonly string m_prefix;

		// Token: 0x04000040 RID: 64
		private static readonly Type declaringType = typeof(OnlyOnceErrorHandler);
	}
}

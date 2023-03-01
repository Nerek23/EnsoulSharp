using System;

namespace SharpDX.Win32
{
	// Token: 0x0200004E RID: 78
	public class ErrorCodeHelper
	{
		// Token: 0x06000240 RID: 576 RVA: 0x00006A64 File Offset: 0x00004C64
		public static Result ToResult(ErrorCode errorCode)
		{
			return ErrorCodeHelper.ToResult((int)errorCode);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00006A6C File Offset: 0x00004C6C
		public static Result ToResult(int errorCode)
		{
			return new Result((uint)((errorCode <= 0) ? errorCode : ((errorCode & 65535) | -2147024896)));
		}
	}
}

using System;

namespace log4net.Core
{
	// Token: 0x020000B9 RID: 185
	[Flags]
	public enum FixFlags
	{
		// Token: 0x0400016D RID: 365
		[Obsolete("Replaced by composite Properties")]
		Mdc = 1,
		// Token: 0x0400016E RID: 366
		Ndc = 2,
		// Token: 0x0400016F RID: 367
		Message = 4,
		// Token: 0x04000170 RID: 368
		ThreadName = 8,
		// Token: 0x04000171 RID: 369
		LocationInfo = 16,
		// Token: 0x04000172 RID: 370
		UserName = 32,
		// Token: 0x04000173 RID: 371
		Domain = 64,
		// Token: 0x04000174 RID: 372
		Identity = 128,
		// Token: 0x04000175 RID: 373
		Exception = 256,
		// Token: 0x04000176 RID: 374
		Properties = 512,
		// Token: 0x04000177 RID: 375
		None = 0,
		// Token: 0x04000178 RID: 376
		All = 268435455,
		// Token: 0x04000179 RID: 377
		Partial = 844
	}
}

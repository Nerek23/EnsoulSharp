using System;

namespace SharpDX.IO
{
	// Token: 0x02000098 RID: 152
	[Flags]
	public enum NativeFileAccess : uint
	{
		// Token: 0x040011A4 RID: 4516
		Read = 2147483648U,
		// Token: 0x040011A5 RID: 4517
		Write = 1073741824U,
		// Token: 0x040011A6 RID: 4518
		ReadWrite = 3221225472U,
		// Token: 0x040011A7 RID: 4519
		Execute = 536870912U,
		// Token: 0x040011A8 RID: 4520
		All = 268435456U
	}
}

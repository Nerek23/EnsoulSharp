using System;

namespace SharpDX.IO
{
	// Token: 0x0200009B RID: 155
	[Flags]
	public enum NativeFileShare : uint
	{
		// Token: 0x040011CB RID: 4555
		None = 0U,
		// Token: 0x040011CC RID: 4556
		Read = 1U,
		// Token: 0x040011CD RID: 4557
		Write = 2U,
		// Token: 0x040011CE RID: 4558
		ReadWrite = 3U,
		// Token: 0x040011CF RID: 4559
		Delete = 4U
	}
}

using System;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000256 RID: 598
	[Flags]
	public enum BitmapOptions
	{
		// Token: 0x040006F3 RID: 1779
		None = 0,
		// Token: 0x040006F4 RID: 1780
		Target = 1,
		// Token: 0x040006F5 RID: 1781
		CannotDraw = 2,
		// Token: 0x040006F6 RID: 1782
		CpuRead = 4,
		// Token: 0x040006F7 RID: 1783
		GdiCompatible = 8
	}
}

using System;

namespace SharpDX.WIC
{
	// Token: 0x0200003C RID: 60
	[Flags]
	public enum BitmapTransformOptions
	{
		// Token: 0x040000BE RID: 190
		Rotate0 = 0,
		// Token: 0x040000BF RID: 191
		Rotate90 = 1,
		// Token: 0x040000C0 RID: 192
		Rotate180 = 2,
		// Token: 0x040000C1 RID: 193
		Rotate270 = 3,
		// Token: 0x040000C2 RID: 194
		FlipHorizontal = 8,
		// Token: 0x040000C3 RID: 195
		FlipVertical = 16
	}
}

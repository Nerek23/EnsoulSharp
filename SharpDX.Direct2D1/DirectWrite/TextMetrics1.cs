using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200016D RID: 365
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TextMetrics1
	{
		// Token: 0x040005CA RID: 1482
		public float Left;

		// Token: 0x040005CB RID: 1483
		public float Top;

		// Token: 0x040005CC RID: 1484
		public float Width;

		// Token: 0x040005CD RID: 1485
		public float WidthIncludingTrailingWhitespace;

		// Token: 0x040005CE RID: 1486
		public float Height;

		// Token: 0x040005CF RID: 1487
		public float LayoutWidth;

		// Token: 0x040005D0 RID: 1488
		public float LayoutHeight;

		// Token: 0x040005D1 RID: 1489
		public int MaxBidiReorderingDepth;

		// Token: 0x040005D2 RID: 1490
		public int LineCount;

		// Token: 0x040005D3 RID: 1491
		public float HeightIncludingTrailingWhitespace;
	}
}

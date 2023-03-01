using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200016C RID: 364
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TextMetrics
	{
		// Token: 0x040005C1 RID: 1473
		public float Left;

		// Token: 0x040005C2 RID: 1474
		public float Top;

		// Token: 0x040005C3 RID: 1475
		public float Width;

		// Token: 0x040005C4 RID: 1476
		public float WidthIncludingTrailingWhitespace;

		// Token: 0x040005C5 RID: 1477
		public float Height;

		// Token: 0x040005C6 RID: 1478
		public float LayoutWidth;

		// Token: 0x040005C7 RID: 1479
		public float LayoutHeight;

		// Token: 0x040005C8 RID: 1480
		public int MaxBidiReorderingDepth;

		// Token: 0x040005C9 RID: 1481
		public int LineCount;
	}
}

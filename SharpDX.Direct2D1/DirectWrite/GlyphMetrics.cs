using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000158 RID: 344
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct GlyphMetrics
	{
		// Token: 0x0400052F RID: 1327
		public int LeftSideBearing;

		// Token: 0x04000530 RID: 1328
		public int AdvanceWidth;

		// Token: 0x04000531 RID: 1329
		public int RightSideBearing;

		// Token: 0x04000532 RID: 1330
		public int TopSideBearing;

		// Token: 0x04000533 RID: 1331
		public int AdvanceHeight;

		// Token: 0x04000534 RID: 1332
		public int BottomSideBearing;

		// Token: 0x04000535 RID: 1333
		public int VerticalOriginY;
	}
}

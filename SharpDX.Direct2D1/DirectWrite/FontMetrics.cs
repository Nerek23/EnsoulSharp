using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000153 RID: 339
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FontMetrics
	{
		// Token: 0x040004FF RID: 1279
		public short DesignUnitsPerEm;

		// Token: 0x04000500 RID: 1280
		public short Ascent;

		// Token: 0x04000501 RID: 1281
		public short Descent;

		// Token: 0x04000502 RID: 1282
		public short LineGap;

		// Token: 0x04000503 RID: 1283
		public short CapHeight;

		// Token: 0x04000504 RID: 1284
		public short XHeight;

		// Token: 0x04000505 RID: 1285
		public short UnderlinePosition;

		// Token: 0x04000506 RID: 1286
		public short UnderlineThickness;

		// Token: 0x04000507 RID: 1287
		public short StrikethroughPosition;

		// Token: 0x04000508 RID: 1288
		public short StrikethroughThickness;
	}
}

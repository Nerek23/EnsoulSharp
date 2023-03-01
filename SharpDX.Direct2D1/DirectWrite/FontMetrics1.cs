using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000154 RID: 340
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FontMetrics1
	{
		// Token: 0x04000509 RID: 1289
		public short DesignUnitsPerEm;

		// Token: 0x0400050A RID: 1290
		public short Ascent;

		// Token: 0x0400050B RID: 1291
		public short Descent;

		// Token: 0x0400050C RID: 1292
		public short LineGap;

		// Token: 0x0400050D RID: 1293
		public short CapHeight;

		// Token: 0x0400050E RID: 1294
		public short XHeight;

		// Token: 0x0400050F RID: 1295
		public short UnderlinePosition;

		// Token: 0x04000510 RID: 1296
		public short UnderlineThickness;

		// Token: 0x04000511 RID: 1297
		public short StrikethroughPosition;

		// Token: 0x04000512 RID: 1298
		public short StrikethroughThickness;

		// Token: 0x04000513 RID: 1299
		public short GlyphBoxLeft;

		// Token: 0x04000514 RID: 1300
		public short GlyphBoxTop;

		// Token: 0x04000515 RID: 1301
		public short GlyphBoxRight;

		// Token: 0x04000516 RID: 1302
		public short GlyphBoxBottom;

		// Token: 0x04000517 RID: 1303
		public short SubscriptPositionX;

		// Token: 0x04000518 RID: 1304
		public short SubscriptPositionY;

		// Token: 0x04000519 RID: 1305
		public short SubscriptSizeX;

		// Token: 0x0400051A RID: 1306
		public short SubscriptSizeY;

		// Token: 0x0400051B RID: 1307
		public short SuperscriptPositionX;

		// Token: 0x0400051C RID: 1308
		public short SuperscriptPositionY;

		// Token: 0x0400051D RID: 1309
		public short SuperscriptSizeX;

		// Token: 0x0400051E RID: 1310
		public short SuperscriptSizeY;

		// Token: 0x0400051F RID: 1311
		public RawBool HasTypographicMetrics;
	}
}

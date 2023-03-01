using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000157 RID: 343
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct GlyphImageData
	{
		// Token: 0x04000526 RID: 1318
		public IntPtr ImageData;

		// Token: 0x04000527 RID: 1319
		public int ImageDataSize;

		// Token: 0x04000528 RID: 1320
		public int UniqueDataId;

		// Token: 0x04000529 RID: 1321
		public int PixelsPerEm;

		// Token: 0x0400052A RID: 1322
		public Size2 PixelSize;

		// Token: 0x0400052B RID: 1323
		public RawPoint HorizontalLeftOrigin;

		// Token: 0x0400052C RID: 1324
		public RawPoint HorizontalRightOrigin;

		// Token: 0x0400052D RID: 1325
		public RawPoint VerticalTopOrigin;

		// Token: 0x0400052E RID: 1326
		public RawPoint VerticalBottomOrigin;
	}
}

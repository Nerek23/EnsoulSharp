using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.WIC
{
	// Token: 0x0200007B RID: 123
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DdsParameters
	{
		// Token: 0x040001DD RID: 477
		public int Width;

		// Token: 0x040001DE RID: 478
		public int Height;

		// Token: 0x040001DF RID: 479
		public int Depth;

		// Token: 0x040001E0 RID: 480
		public int MipLevels;

		// Token: 0x040001E1 RID: 481
		public int ArraySize;

		// Token: 0x040001E2 RID: 482
		public Format DxgiFormat;

		// Token: 0x040001E3 RID: 483
		public DdsDimension Dimension;

		// Token: 0x040001E4 RID: 484
		public DdsAlphaMode AlphaMode;
	}
}

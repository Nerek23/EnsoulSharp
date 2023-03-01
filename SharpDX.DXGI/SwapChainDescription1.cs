using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200009C RID: 156
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SwapChainDescription1
	{
		// Token: 0x04000DEA RID: 3562
		public int Width;

		// Token: 0x04000DEB RID: 3563
		public int Height;

		// Token: 0x04000DEC RID: 3564
		public Format Format;

		// Token: 0x04000DED RID: 3565
		public RawBool Stereo;

		// Token: 0x04000DEE RID: 3566
		public SampleDescription SampleDescription;

		// Token: 0x04000DEF RID: 3567
		public Usage Usage;

		// Token: 0x04000DF0 RID: 3568
		public int BufferCount;

		// Token: 0x04000DF1 RID: 3569
		public Scaling Scaling;

		// Token: 0x04000DF2 RID: 3570
		public SwapEffect SwapEffect;

		// Token: 0x04000DF3 RID: 3571
		public AlphaMode AlphaMode;

		// Token: 0x04000DF4 RID: 3572
		public SwapChainFlags Flags;
	}
}

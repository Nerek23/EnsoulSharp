using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000155 RID: 341
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Texture2DDescription1
	{
		// Token: 0x04000A98 RID: 2712
		public int Width;

		// Token: 0x04000A99 RID: 2713
		public int Height;

		// Token: 0x04000A9A RID: 2714
		public int MipLevels;

		// Token: 0x04000A9B RID: 2715
		public int ArraySize;

		// Token: 0x04000A9C RID: 2716
		public Format Format;

		// Token: 0x04000A9D RID: 2717
		public SampleDescription SampleDescription;

		// Token: 0x04000A9E RID: 2718
		public ResourceUsage Usage;

		// Token: 0x04000A9F RID: 2719
		public BindFlags BindFlags;

		// Token: 0x04000AA0 RID: 2720
		public CpuAccessFlags CpuAccessFlags;

		// Token: 0x04000AA1 RID: 2721
		public ResourceOptionFlags OptionFlags;

		// Token: 0x04000AA2 RID: 2722
		public TextureLayout TextureLayout;
	}
}

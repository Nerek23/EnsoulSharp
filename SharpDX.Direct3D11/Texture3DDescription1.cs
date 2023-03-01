using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200015A RID: 346
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Texture3DDescription1
	{
		// Token: 0x04000AB0 RID: 2736
		public int Width;

		// Token: 0x04000AB1 RID: 2737
		public int Height;

		// Token: 0x04000AB2 RID: 2738
		public int Depth;

		// Token: 0x04000AB3 RID: 2739
		public int MipLevels;

		// Token: 0x04000AB4 RID: 2740
		public Format Format;

		// Token: 0x04000AB5 RID: 2741
		public ResourceUsage Usage;

		// Token: 0x04000AB6 RID: 2742
		public BindFlags BindFlags;

		// Token: 0x04000AB7 RID: 2743
		public CpuAccessFlags CpuAccessFlags;

		// Token: 0x04000AB8 RID: 2744
		public ResourceOptionFlags OptionFlags;

		// Token: 0x04000AB9 RID: 2745
		public TextureLayout TextureLayout;
	}
}

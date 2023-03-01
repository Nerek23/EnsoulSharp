using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000152 RID: 338
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Texture1DDescription
	{
		// Token: 0x04000A83 RID: 2691
		public int Width;

		// Token: 0x04000A84 RID: 2692
		public int MipLevels;

		// Token: 0x04000A85 RID: 2693
		public int ArraySize;

		// Token: 0x04000A86 RID: 2694
		public Format Format;

		// Token: 0x04000A87 RID: 2695
		public ResourceUsage Usage;

		// Token: 0x04000A88 RID: 2696
		public BindFlags BindFlags;

		// Token: 0x04000A89 RID: 2697
		public CpuAccessFlags CpuAccessFlags;

		// Token: 0x04000A8A RID: 2698
		public ResourceOptionFlags OptionFlags;
	}
}

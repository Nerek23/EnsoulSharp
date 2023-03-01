using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000159 RID: 345
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Texture3DDescription
	{
		// Token: 0x04000AA7 RID: 2727
		public int Width;

		// Token: 0x04000AA8 RID: 2728
		public int Height;

		// Token: 0x04000AA9 RID: 2729
		public int Depth;

		// Token: 0x04000AAA RID: 2730
		public int MipLevels;

		// Token: 0x04000AAB RID: 2731
		public Format Format;

		// Token: 0x04000AAC RID: 2732
		public ResourceUsage Usage;

		// Token: 0x04000AAD RID: 2733
		public BindFlags BindFlags;

		// Token: 0x04000AAE RID: 2734
		public CpuAccessFlags CpuAccessFlags;

		// Token: 0x04000AAF RID: 2735
		public ResourceOptionFlags OptionFlags;
	}
}

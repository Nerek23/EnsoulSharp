using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000154 RID: 340
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Texture2DDescription
	{
		// Token: 0x04000A8E RID: 2702
		public int Width;

		// Token: 0x04000A8F RID: 2703
		public int Height;

		// Token: 0x04000A90 RID: 2704
		public int MipLevels;

		// Token: 0x04000A91 RID: 2705
		public int ArraySize;

		// Token: 0x04000A92 RID: 2706
		public Format Format;

		// Token: 0x04000A93 RID: 2707
		public SampleDescription SampleDescription;

		// Token: 0x04000A94 RID: 2708
		public ResourceUsage Usage;

		// Token: 0x04000A95 RID: 2709
		public BindFlags BindFlags;

		// Token: 0x04000A96 RID: 2710
		public CpuAccessFlags CpuAccessFlags;

		// Token: 0x04000A97 RID: 2711
		public ResourceOptionFlags OptionFlags;
	}
}

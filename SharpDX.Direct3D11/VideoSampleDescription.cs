using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000181 RID: 385
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoSampleDescription
	{
		// Token: 0x04000B85 RID: 2949
		public int Width;

		// Token: 0x04000B86 RID: 2950
		public int Height;

		// Token: 0x04000B87 RID: 2951
		public Format Format;

		// Token: 0x04000B88 RID: 2952
		public ColorSpaceType ColorSpace;
	}
}

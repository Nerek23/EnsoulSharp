using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200009A RID: 154
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SurfaceDescription
	{
		// Token: 0x04000DDE RID: 3550
		public int Width;

		// Token: 0x04000DDF RID: 3551
		public int Height;

		// Token: 0x04000DE0 RID: 3552
		public Format Format;

		// Token: 0x04000DE1 RID: 3553
		public SampleDescription SampleDescription;
	}
}

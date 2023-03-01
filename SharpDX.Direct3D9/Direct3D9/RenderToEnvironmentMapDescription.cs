using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000104 RID: 260
	public struct RenderToEnvironmentMapDescription
	{
		// Token: 0x04000E0A RID: 3594
		public int Size;

		// Token: 0x04000E0B RID: 3595
		public int MipLevels;

		// Token: 0x04000E0C RID: 3596
		public Format Format;

		// Token: 0x04000E0D RID: 3597
		public RawBool DepthStencil;

		// Token: 0x04000E0E RID: 3598
		public Format DepthStencilFormat;
	}
}

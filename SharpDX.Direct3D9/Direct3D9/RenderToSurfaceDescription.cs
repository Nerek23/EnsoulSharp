using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000105 RID: 261
	public struct RenderToSurfaceDescription
	{
		// Token: 0x04000E0F RID: 3599
		public int Width;

		// Token: 0x04000E10 RID: 3600
		public int Height;

		// Token: 0x04000E11 RID: 3601
		public Format Format;

		// Token: 0x04000E12 RID: 3602
		public RawBool DepthStencil;

		// Token: 0x04000E13 RID: 3603
		public Format DepthStencilFormat;
	}
}

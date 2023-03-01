using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200016A RID: 362
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoColorYCbCrA
	{
		// Token: 0x04000AF0 RID: 2800
		public float Y;

		// Token: 0x04000AF1 RID: 2801
		public float Cb;

		// Token: 0x04000AF2 RID: 2802
		public float Cr;

		// Token: 0x04000AF3 RID: 2803
		public float A;
	}
}

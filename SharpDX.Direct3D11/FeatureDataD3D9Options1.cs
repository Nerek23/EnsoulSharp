using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200011A RID: 282
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct FeatureDataD3D9Options1
	{
		// Token: 0x040009A1 RID: 2465
		public RawBool FullNonPow2TextureSupported;

		// Token: 0x040009A2 RID: 2466
		public RawBool DepthAsTextureWithLessEqualComparisonFilterSupported;

		// Token: 0x040009A3 RID: 2467
		public RawBool SimpleInstancingSupported;

		// Token: 0x040009A4 RID: 2468
		public RawBool TextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported;
	}
}

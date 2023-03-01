using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200011B RID: 283
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct FeatureDataD3D9ShadowSupport
	{
		// Token: 0x040009A5 RID: 2469
		public RawBool SupportsDepthAsTextureWithLessEqualComparisonFilter;
	}
}

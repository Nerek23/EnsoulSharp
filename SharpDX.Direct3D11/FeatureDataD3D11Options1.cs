using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000115 RID: 277
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FeatureDataD3D11Options1
	{
		// Token: 0x04000992 RID: 2450
		public TiledResourcesTier TiledResourcesTier;

		// Token: 0x04000993 RID: 2451
		public RawBool MinMaxFiltering;

		// Token: 0x04000994 RID: 2452
		public RawBool ClearViewAlsoSupportsDepthOnlyFormats;

		// Token: 0x04000995 RID: 2453
		public RawBool MapOnDefaultBuffers;
	}
}

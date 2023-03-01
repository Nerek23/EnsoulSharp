using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200011F RID: 287
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct FeatureDataFormatSupport2
	{
		// Token: 0x040009AA RID: 2474
		public Format InFormat;

		// Token: 0x040009AB RID: 2475
		public ComputeShaderFormatSupport OutFormatSupport2;
	}
}

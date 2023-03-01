using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200011E RID: 286
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct FeatureDataFormatSupport
	{
		// Token: 0x040009A8 RID: 2472
		public Format InFormat;

		// Token: 0x040009A9 RID: 2473
		public FormatSupport OutFormatSupport;
	}
}

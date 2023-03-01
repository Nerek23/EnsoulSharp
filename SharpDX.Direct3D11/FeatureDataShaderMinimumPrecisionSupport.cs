using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000123 RID: 291
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FeatureDataShaderMinimumPrecisionSupport
	{
		// Token: 0x040009B0 RID: 2480
		public int PixelShaderMinPrecision;

		// Token: 0x040009B1 RID: 2481
		public int AllOtherShaderStagesMinPrecision;
	}
}

using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000116 RID: 278
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FeatureDataD3D11Options2
	{
		// Token: 0x04000996 RID: 2454
		public RawBool PSSpecifiedStencilRefSupported;

		// Token: 0x04000997 RID: 2455
		public RawBool TypedUAVLoadAdditionalFormats;

		// Token: 0x04000998 RID: 2456
		public RawBool ROVsSupported;

		// Token: 0x04000999 RID: 2457
		public ConservativeRasterizationTier ConservativeRasterizationTier;

		// Token: 0x0400099A RID: 2458
		public TiledResourcesTier TiledResourcesTier;

		// Token: 0x0400099B RID: 2459
		public RawBool MapOnDefaultTextures;

		// Token: 0x0400099C RID: 2460
		public RawBool StandardSwizzle;

		// Token: 0x0400099D RID: 2461
		public RawBool UnifiedMemoryArchitecture;
	}
}

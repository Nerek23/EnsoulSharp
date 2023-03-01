using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200007E RID: 126
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RawCapabilitiesInfo
	{
		// Token: 0x040001F5 RID: 501
		public int CbSize;

		// Token: 0x040001F6 RID: 502
		public int CodecMajorVersion;

		// Token: 0x040001F7 RID: 503
		public int CodecMinorVersion;

		// Token: 0x040001F8 RID: 504
		public RawCapabilities ExposureCompensationSupport;

		// Token: 0x040001F9 RID: 505
		public RawCapabilities ContrastSupport;

		// Token: 0x040001FA RID: 506
		public RawCapabilities RGBWhitePointSupport;

		// Token: 0x040001FB RID: 507
		public RawCapabilities NamedWhitePointSupport;

		// Token: 0x040001FC RID: 508
		public int NamedWhitePointSupportMask;

		// Token: 0x040001FD RID: 509
		public RawCapabilities KelvinWhitePointSupport;

		// Token: 0x040001FE RID: 510
		public RawCapabilities GammaSupport;

		// Token: 0x040001FF RID: 511
		public RawCapabilities TintSupport;

		// Token: 0x04000200 RID: 512
		public RawCapabilities SaturationSupport;

		// Token: 0x04000201 RID: 513
		public RawCapabilities SharpnessSupport;

		// Token: 0x04000202 RID: 514
		public RawCapabilities NoiseReductionSupport;

		// Token: 0x04000203 RID: 515
		public RawCapabilities DestinationColorProfileSupport;

		// Token: 0x04000204 RID: 516
		public RawCapabilities ToneCurveSupport;

		// Token: 0x04000205 RID: 517
		public RawRotationCapabilities RotationSupport;

		// Token: 0x04000206 RID: 518
		public RawCapabilities RenderModeSupport;
	}
}

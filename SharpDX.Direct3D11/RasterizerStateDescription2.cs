using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000133 RID: 307
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RasterizerStateDescription2
	{
		// Token: 0x040009FB RID: 2555
		public FillMode FillMode;

		// Token: 0x040009FC RID: 2556
		public CullMode CullMode;

		// Token: 0x040009FD RID: 2557
		public RawBool IsFrontCounterClockwise;

		// Token: 0x040009FE RID: 2558
		public int DepthBias;

		// Token: 0x040009FF RID: 2559
		public float DepthBiasClamp;

		// Token: 0x04000A00 RID: 2560
		public float SlopeScaledDepthBias;

		// Token: 0x04000A01 RID: 2561
		public RawBool IsDepthClipEnabled;

		// Token: 0x04000A02 RID: 2562
		public RawBool IsScissorEnabled;

		// Token: 0x04000A03 RID: 2563
		public RawBool IsMultisampleEnabled;

		// Token: 0x04000A04 RID: 2564
		public RawBool IsAntialiasedLineEnabled;

		// Token: 0x04000A05 RID: 2565
		public int ForcedSampleCount;

		// Token: 0x04000A06 RID: 2566
		public ConservativeRasterizationMode ConservativeRasterizationMode;
	}
}

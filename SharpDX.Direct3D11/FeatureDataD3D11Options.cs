using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000114 RID: 276
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FeatureDataD3D11Options
	{
		// Token: 0x04000984 RID: 2436
		public RawBool OutputMergerLogicOp;

		// Token: 0x04000985 RID: 2437
		public RawBool UAVOnlyRenderingForcedSampleCount;

		// Token: 0x04000986 RID: 2438
		public RawBool DiscardAPIsSeenByDriver;

		// Token: 0x04000987 RID: 2439
		public RawBool FlagsForUpdateAndCopySeenByDriver;

		// Token: 0x04000988 RID: 2440
		public RawBool ClearView;

		// Token: 0x04000989 RID: 2441
		public RawBool CopyWithOverlap;

		// Token: 0x0400098A RID: 2442
		public RawBool ConstantBufferPartialUpdate;

		// Token: 0x0400098B RID: 2443
		public RawBool ConstantBufferOffsetting;

		// Token: 0x0400098C RID: 2444
		public RawBool MapNoOverwriteOnDynamicConstantBuffer;

		// Token: 0x0400098D RID: 2445
		public RawBool MapNoOverwriteOnDynamicBufferSRV;

		// Token: 0x0400098E RID: 2446
		public RawBool MultisampleRTVWithForcedSampleCountOne;

		// Token: 0x0400098F RID: 2447
		public RawBool SAD4ShaderInstructions;

		// Token: 0x04000990 RID: 2448
		public RawBool ExtendedDoublesShaderInstructions;

		// Token: 0x04000991 RID: 2449
		public RawBool ExtendedResourceSharing;
	}
}

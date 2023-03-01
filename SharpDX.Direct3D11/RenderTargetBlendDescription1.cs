using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000134 RID: 308
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RenderTargetBlendDescription1
	{
		// Token: 0x04000A07 RID: 2567
		public RawBool IsBlendEnabled;

		// Token: 0x04000A08 RID: 2568
		public RawBool IsLogicOperationEnabled;

		// Token: 0x04000A09 RID: 2569
		public BlendOption SourceBlend;

		// Token: 0x04000A0A RID: 2570
		public BlendOption DestinationBlend;

		// Token: 0x04000A0B RID: 2571
		public BlendOperation BlendOperation;

		// Token: 0x04000A0C RID: 2572
		public BlendOption SourceAlphaBlend;

		// Token: 0x04000A0D RID: 2573
		public BlendOption DestinationAlphaBlend;

		// Token: 0x04000A0E RID: 2574
		public BlendOperation AlphaBlendOperation;

		// Token: 0x04000A0F RID: 2575
		public LogicOperation LogicOperation;

		// Token: 0x04000A10 RID: 2576
		public ColorWriteMaskFlags RenderTargetWriteMask;
	}
}

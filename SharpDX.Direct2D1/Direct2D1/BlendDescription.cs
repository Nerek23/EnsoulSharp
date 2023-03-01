using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200031A RID: 794
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BlendDescription
	{
		// Token: 0x04000AAE RID: 2734
		public Blend SourceBlend;

		// Token: 0x04000AAF RID: 2735
		public Blend DestinationBlend;

		// Token: 0x04000AB0 RID: 2736
		public BlendOperation BlendOperation;

		// Token: 0x04000AB1 RID: 2737
		public Blend SourceBlendAlpha;

		// Token: 0x04000AB2 RID: 2738
		public Blend DestinationBlendAlpha;

		// Token: 0x04000AB3 RID: 2739
		public BlendOperation BlendOperationAlpha;

		// Token: 0x04000AB4 RID: 2740
		public RawColor4 BlendFactor;
	}
}

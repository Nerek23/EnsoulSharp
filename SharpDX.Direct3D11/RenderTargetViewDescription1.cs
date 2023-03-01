using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200013E RID: 318
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct RenderTargetViewDescription1
	{
		// Token: 0x04000A2D RID: 2605
		[FieldOffset(0)]
		public Format Format;

		// Token: 0x04000A2E RID: 2606
		[FieldOffset(4)]
		public RenderTargetViewDimension Dimension;

		// Token: 0x04000A2F RID: 2607
		[FieldOffset(8)]
		public RenderTargetViewDescription.BufferResource Buffer;

		// Token: 0x04000A30 RID: 2608
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture1DResource Texture1D;

		// Token: 0x04000A31 RID: 2609
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture1DArrayResource Texture1DArray;

		// Token: 0x04000A32 RID: 2610
		[FieldOffset(8)]
		public RenderTargetViewDescription1.Texture2DResource Texture2D;

		// Token: 0x04000A33 RID: 2611
		[FieldOffset(8)]
		public RenderTargetViewDescription1.Texture2DArrayResource Texture2DArray;

		// Token: 0x04000A34 RID: 2612
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture2DMultisampledResource Texture2DMS;

		// Token: 0x04000A35 RID: 2613
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture2DMultisampledArrayResource Texture2DMSArray;

		// Token: 0x04000A36 RID: 2614
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture3DResource Texture3D;

		// Token: 0x0200013F RID: 319
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DResource
		{
			// Token: 0x04000A37 RID: 2615
			public int MipSlice;

			// Token: 0x04000A38 RID: 2616
			public int PlaneSlice;
		}

		// Token: 0x02000140 RID: 320
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DArrayResource
		{
			// Token: 0x04000A39 RID: 2617
			public int MipSlice;

			// Token: 0x04000A3A RID: 2618
			public int FirstArraySlice;

			// Token: 0x04000A3B RID: 2619
			public int ArraySize;

			// Token: 0x04000A3C RID: 2620
			public int PlaneSlice;
		}
	}
}

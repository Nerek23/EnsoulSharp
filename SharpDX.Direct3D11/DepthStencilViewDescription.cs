using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000108 RID: 264
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct DepthStencilViewDescription
	{
		// Token: 0x04000962 RID: 2402
		[FieldOffset(0)]
		public Format Format;

		// Token: 0x04000963 RID: 2403
		[FieldOffset(4)]
		public DepthStencilViewDimension Dimension;

		// Token: 0x04000964 RID: 2404
		[FieldOffset(8)]
		public DepthStencilViewFlags Flags;

		// Token: 0x04000965 RID: 2405
		[FieldOffset(12)]
		public DepthStencilViewDescription.Texture1DResource Texture1D;

		// Token: 0x04000966 RID: 2406
		[FieldOffset(12)]
		public DepthStencilViewDescription.Texture1DArrayResource Texture1DArray;

		// Token: 0x04000967 RID: 2407
		[FieldOffset(12)]
		public DepthStencilViewDescription.Texture2DResource Texture2D;

		// Token: 0x04000968 RID: 2408
		[FieldOffset(12)]
		public DepthStencilViewDescription.Texture2DArrayResource Texture2DArray;

		// Token: 0x04000969 RID: 2409
		[FieldOffset(12)]
		public DepthStencilViewDescription.Texture2DMultisampledResource Texture2DMS;

		// Token: 0x0400096A RID: 2410
		[FieldOffset(12)]
		public DepthStencilViewDescription.Texture2DMultisampledArrayResource Texture2DMSArray;

		// Token: 0x02000109 RID: 265
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture1DResource
		{
			// Token: 0x0400096B RID: 2411
			public int MipSlice;
		}

		// Token: 0x0200010A RID: 266
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture1DArrayResource
		{
			// Token: 0x0400096C RID: 2412
			public int MipSlice;

			// Token: 0x0400096D RID: 2413
			public int FirstArraySlice;

			// Token: 0x0400096E RID: 2414
			public int ArraySize;
		}

		// Token: 0x0200010B RID: 267
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DResource
		{
			// Token: 0x0400096F RID: 2415
			public int MipSlice;
		}

		// Token: 0x0200010C RID: 268
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DArrayResource
		{
			// Token: 0x04000970 RID: 2416
			public int MipSlice;

			// Token: 0x04000971 RID: 2417
			public int FirstArraySlice;

			// Token: 0x04000972 RID: 2418
			public int ArraySize;
		}

		// Token: 0x0200010D RID: 269
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DMultisampledResource
		{
			// Token: 0x04000973 RID: 2419
			public int UnusedFieldNothingToDefine;
		}

		// Token: 0x0200010E RID: 270
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DMultisampledArrayResource
		{
			// Token: 0x04000974 RID: 2420
			public int FirstArraySlice;

			// Token: 0x04000975 RID: 2421
			public int ArraySize;
		}
	}
}

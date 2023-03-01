using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200001F RID: 31
	public struct PresentParameters
	{
		// Token: 0x0400001F RID: 31
		public RawRectangle[] DirtyRectangles;

		// Token: 0x04000020 RID: 32
		public RawRectangle? ScrollRectangle;

		// Token: 0x04000021 RID: 33
		public RawPoint? ScrollOffset;

		// Token: 0x04000022 RID: 34
		internal int DirtyRectsCount;

		// Token: 0x04000023 RID: 35
		internal IntPtr PDirtyRects;

		// Token: 0x04000024 RID: 36
		internal IntPtr PScrollRect;

		// Token: 0x04000025 RID: 37
		internal IntPtr PScrollOffset;

		// Token: 0x02000020 RID: 32
		internal struct __Native
		{
			// Token: 0x04000026 RID: 38
			public int DirtyRectsCount;

			// Token: 0x04000027 RID: 39
			public IntPtr PDirtyRects;

			// Token: 0x04000028 RID: 40
			public IntPtr PScrollRect;

			// Token: 0x04000029 RID: 41
			public IntPtr PScrollOffset;
		}
	}
}

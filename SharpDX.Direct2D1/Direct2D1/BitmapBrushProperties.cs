using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000318 RID: 792
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BitmapBrushProperties
	{
		// Token: 0x04000AA8 RID: 2728
		public ExtendMode ExtendModeX;

		// Token: 0x04000AA9 RID: 2729
		public ExtendMode ExtendModeY;

		// Token: 0x04000AAA RID: 2730
		public BitmapInterpolationMode InterpolationMode;
	}
}

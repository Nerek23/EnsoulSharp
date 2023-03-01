using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000327 RID: 807
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ImageBrushProperties
	{
		// Token: 0x04000AEC RID: 2796
		public RawRectangleF SourceRectangle;

		// Token: 0x04000AED RID: 2797
		public ExtendMode ExtendModeX;

		// Token: 0x04000AEE RID: 2798
		public ExtendMode ExtendModeY;

		// Token: 0x04000AEF RID: 2799
		public InterpolationMode InterpolationMode;
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000168 RID: 360
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct VideoColor
	{
		// Token: 0x04000AEA RID: 2794
		[FieldOffset(0)]
		public VideoColorYCbCrA YCbCr;

		// Token: 0x04000AEB RID: 2795
		[FieldOffset(0)]
		public VideoColorRgba Rgba;
	}
}

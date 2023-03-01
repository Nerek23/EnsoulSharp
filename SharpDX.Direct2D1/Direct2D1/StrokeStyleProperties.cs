using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000334 RID: 820
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct StrokeStyleProperties
	{
		// Token: 0x04000B14 RID: 2836
		public CapStyle StartCap;

		// Token: 0x04000B15 RID: 2837
		public CapStyle EndCap;

		// Token: 0x04000B16 RID: 2838
		public CapStyle DashCap;

		// Token: 0x04000B17 RID: 2839
		public LineJoin LineJoin;

		// Token: 0x04000B18 RID: 2840
		public float MiterLimit;

		// Token: 0x04000B19 RID: 2841
		public DashStyle DashStyle;

		// Token: 0x04000B1A RID: 2842
		public float DashOffset;
	}
}

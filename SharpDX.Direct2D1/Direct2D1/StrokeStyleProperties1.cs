using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000335 RID: 821
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct StrokeStyleProperties1
	{
		// Token: 0x04000B1B RID: 2843
		public CapStyle StartCap;

		// Token: 0x04000B1C RID: 2844
		public CapStyle EndCap;

		// Token: 0x04000B1D RID: 2845
		public CapStyle DashCap;

		// Token: 0x04000B1E RID: 2846
		public LineJoin LineJoin;

		// Token: 0x04000B1F RID: 2847
		public float MiterLimit;

		// Token: 0x04000B20 RID: 2848
		public DashStyle DashStyle;

		// Token: 0x04000B21 RID: 2849
		public float DashOffset;

		// Token: 0x04000B22 RID: 2850
		public StrokeTransformType TransformType;
	}
}

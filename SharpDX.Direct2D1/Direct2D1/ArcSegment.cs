using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000316 RID: 790
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ArcSegment
	{
		// Token: 0x04000AA0 RID: 2720
		public RawVector2 Point;

		// Token: 0x04000AA1 RID: 2721
		public Size2F Size;

		// Token: 0x04000AA2 RID: 2722
		public float RotationAngle;

		// Token: 0x04000AA3 RID: 2723
		public SweepDirection SweepDirection;

		// Token: 0x04000AA4 RID: 2724
		public ArcSize ArcSize;
	}
}

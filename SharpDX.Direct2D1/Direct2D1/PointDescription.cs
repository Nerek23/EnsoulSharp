using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200032D RID: 813
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PointDescription
	{
		// Token: 0x04000AFC RID: 2812
		public RawVector2 Point;

		// Token: 0x04000AFD RID: 2813
		public RawVector2 UnitTangentVector;

		// Token: 0x04000AFE RID: 2814
		public int EndSegment;

		// Token: 0x04000AFF RID: 2815
		public int EndFigure;

		// Token: 0x04000B00 RID: 2816
		public float LengthToEndSegment;
	}
}

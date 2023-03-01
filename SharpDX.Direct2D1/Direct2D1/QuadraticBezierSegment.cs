using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200032F RID: 815
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct QuadraticBezierSegment
	{
		// Token: 0x04000B04 RID: 2820
		public RawVector2 Point1;

		// Token: 0x04000B05 RID: 2821
		public RawVector2 Point2;
	}
}

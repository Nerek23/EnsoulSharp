using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000317 RID: 791
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BezierSegment
	{
		// Token: 0x04000AA5 RID: 2725
		public RawVector2 Point1;

		// Token: 0x04000AA6 RID: 2726
		public RawVector2 Point2;

		// Token: 0x04000AA7 RID: 2727
		public RawVector2 Point3;
	}
}

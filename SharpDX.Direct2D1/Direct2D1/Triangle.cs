using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200033A RID: 826
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Triangle
	{
		// Token: 0x04000B31 RID: 2865
		public RawVector2 Point1;

		// Token: 0x04000B32 RID: 2866
		public RawVector2 Point2;

		// Token: 0x04000B33 RID: 2867
		public RawVector2 Point3;
	}
}

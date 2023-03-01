using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000328 RID: 808
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct InkBezierSegment
	{
		// Token: 0x04000AF0 RID: 2800
		public InkPoint Point1;

		// Token: 0x04000AF1 RID: 2801
		public InkPoint Point2;

		// Token: 0x04000AF2 RID: 2802
		public InkPoint Point3;
	}
}

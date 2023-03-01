using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000329 RID: 809
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct InkPoint
	{
		// Token: 0x04000AF3 RID: 2803
		public float X;

		// Token: 0x04000AF4 RID: 2804
		public float Y;

		// Token: 0x04000AF5 RID: 2805
		public float Radius;
	}
}

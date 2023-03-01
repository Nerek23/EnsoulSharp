using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000332 RID: 818
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RoundedRectangle
	{
		// Token: 0x04000B0C RID: 2828
		public RawRectangleF Rect;

		// Token: 0x04000B0D RID: 2829
		public float RadiusX;

		// Token: 0x04000B0E RID: 2830
		public float RadiusY;
	}
}

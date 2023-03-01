using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000325 RID: 805
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct GradientStop
	{
		// Token: 0x04000AE7 RID: 2791
		public float Position;

		// Token: 0x04000AE8 RID: 2792
		public RawColor4 Color;
	}
}

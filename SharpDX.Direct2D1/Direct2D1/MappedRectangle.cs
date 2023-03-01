using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200032C RID: 812
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct MappedRectangle
	{
		// Token: 0x04000AFA RID: 2810
		public int Pitch;

		// Token: 0x04000AFB RID: 2811
		public IntPtr Bits;
	}
}

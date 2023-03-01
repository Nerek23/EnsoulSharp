using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x0200007F RID: 127
	[DebuggerDisplay("X: {X}, Y: {Y}, Z: {Z}, W: {W}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawBool4
	{
		// Token: 0x04001125 RID: 4389
		public int X;

		// Token: 0x04001126 RID: 4390
		public int Y;

		// Token: 0x04001127 RID: 4391
		public int Z;

		// Token: 0x04001128 RID: 4392
		public int W;
	}
}

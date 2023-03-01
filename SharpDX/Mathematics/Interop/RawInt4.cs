using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000085 RID: 133
	[DebuggerDisplay("X: {X}, Y: {Y}, Z: {Z}, W: {W}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawInt4
	{
		// Token: 0x0600030A RID: 778 RVA: 0x00009097 File Offset: 0x00007297
		public RawInt4(int x, int y, int z, int w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x0400113B RID: 4411
		public int X;

		// Token: 0x0400113C RID: 4412
		public int Y;

		// Token: 0x0400113D RID: 4413
		public int Z;

		// Token: 0x0400113E RID: 4414
		public int W;
	}
}

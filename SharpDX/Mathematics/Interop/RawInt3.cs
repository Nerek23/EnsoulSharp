using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000084 RID: 132
	[DebuggerDisplay("X: {X}, Y: {Y}, Z: {Z}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawInt3
	{
		// Token: 0x06000309 RID: 777 RVA: 0x00009080 File Offset: 0x00007280
		public RawInt3(int x, int y, int z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x04001138 RID: 4408
		public int X;

		// Token: 0x04001139 RID: 4409
		public int Y;

		// Token: 0x0400113A RID: 4410
		public int Z;
	}
}

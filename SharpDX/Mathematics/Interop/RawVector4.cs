using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000091 RID: 145
	[DebuggerDisplay("X: {X}, Y: {Y}, Z: {Z}, W: {W}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawVector4
	{
		// Token: 0x06000314 RID: 788 RVA: 0x000091AE File Offset: 0x000073AE
		public RawVector4(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x0400118A RID: 4490
		public float X;

		// Token: 0x0400118B RID: 4491
		public float Y;

		// Token: 0x0400118C RID: 4492
		public float Z;

		// Token: 0x0400118D RID: 4493
		public float W;
	}
}

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000090 RID: 144
	[DebuggerDisplay("X: {X}, Y: {Y}, Z: {Z}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawVector3
	{
		// Token: 0x06000313 RID: 787 RVA: 0x00009197 File Offset: 0x00007397
		public RawVector3(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x04001187 RID: 4487
		public float X;

		// Token: 0x04001188 RID: 4488
		public float Y;

		// Token: 0x04001189 RID: 4489
		public float Z;
	}
}

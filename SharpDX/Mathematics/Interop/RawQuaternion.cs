using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x0200008C RID: 140
	[DebuggerDisplay("X: {X}, Y: {Y}, Z: {Z}, W: {W}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawQuaternion
	{
		// Token: 0x0600030E RID: 782 RVA: 0x00009105 File Offset: 0x00007305
		public RawQuaternion(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x04001179 RID: 4473
		public float X;

		// Token: 0x0400117A RID: 4474
		public float Y;

		// Token: 0x0400117B RID: 4475
		public float Z;

		// Token: 0x0400117C RID: 4476
		public float W;
	}
}

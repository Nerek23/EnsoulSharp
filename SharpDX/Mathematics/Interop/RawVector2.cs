using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x0200008F RID: 143
	[DebuggerDisplay("X: {X}, Y: {Y}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawVector2
	{
		// Token: 0x06000312 RID: 786 RVA: 0x00009187 File Offset: 0x00007387
		public RawVector2(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x04001185 RID: 4485
		public float X;

		// Token: 0x04001186 RID: 4486
		public float Y;
	}
}

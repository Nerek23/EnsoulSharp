using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000081 RID: 129
	[DebuggerDisplay("R: {R}, G: {G}, B: {B}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawColor3
	{
		// Token: 0x06000306 RID: 774 RVA: 0x0000902B File Offset: 0x0000722B
		public RawColor3(float r, float g, float b)
		{
			this.R = r;
			this.G = g;
			this.B = b;
		}

		// Token: 0x0400112D RID: 4397
		public float R;

		// Token: 0x0400112E RID: 4398
		public float G;

		// Token: 0x0400112F RID: 4399
		public float B;
	}
}

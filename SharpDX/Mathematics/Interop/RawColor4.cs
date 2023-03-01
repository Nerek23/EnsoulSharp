using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000082 RID: 130
	[DebuggerDisplay("R:{R} G:{G} B:{B} A:{A}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawColor4
	{
		// Token: 0x06000307 RID: 775 RVA: 0x00009042 File Offset: 0x00007242
		public RawColor4(float r, float g, float b, float a)
		{
			this.R = r;
			this.G = g;
			this.B = b;
			this.A = a;
		}

		// Token: 0x04001130 RID: 4400
		public float R;

		// Token: 0x04001131 RID: 4401
		public float G;

		// Token: 0x04001132 RID: 4402
		public float B;

		// Token: 0x04001133 RID: 4403
		public float A;
	}
}

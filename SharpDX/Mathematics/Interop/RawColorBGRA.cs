using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000083 RID: 131
	[DebuggerDisplay("R:{R} G:{G} B:{B} A:{A}")]
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct RawColorBGRA
	{
		// Token: 0x06000308 RID: 776 RVA: 0x00009061 File Offset: 0x00007261
		public RawColorBGRA(byte b, byte g, byte r, byte a)
		{
			this.B = b;
			this.G = g;
			this.R = r;
			this.A = a;
		}

		// Token: 0x04001134 RID: 4404
		public byte B;

		// Token: 0x04001135 RID: 4405
		public byte G;

		// Token: 0x04001136 RID: 4406
		public byte R;

		// Token: 0x04001137 RID: 4407
		public byte A;
	}
}

using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200031D RID: 797
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DrawingStateDescription
	{
		// Token: 0x04000ABA RID: 2746
		public AntialiasMode AntialiasMode;

		// Token: 0x04000ABB RID: 2747
		public TextAntialiasMode TextAntialiasMode;

		// Token: 0x04000ABC RID: 2748
		public long Tag1;

		// Token: 0x04000ABD RID: 2749
		public long Tag2;

		// Token: 0x04000ABE RID: 2750
		public RawMatrix3x2 Transform;
	}
}

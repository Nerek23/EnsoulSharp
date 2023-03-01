using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200031E RID: 798
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DrawingStateDescription1
	{
		// Token: 0x04000ABF RID: 2751
		public AntialiasMode AntialiasMode;

		// Token: 0x04000AC0 RID: 2752
		public TextAntialiasMode TextAntialiasMode;

		// Token: 0x04000AC1 RID: 2753
		public long Tag1;

		// Token: 0x04000AC2 RID: 2754
		public long Tag2;

		// Token: 0x04000AC3 RID: 2755
		public RawMatrix3x2 Transform;

		// Token: 0x04000AC4 RID: 2756
		public PrimitiveBlend PrimitiveBlend;

		// Token: 0x04000AC5 RID: 2757
		public UnitMode UnitMode;
	}
}

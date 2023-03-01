using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200031B RID: 795
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BrushProperties
	{
		// Token: 0x04000AB5 RID: 2741
		public float Opacity;

		// Token: 0x04000AB6 RID: 2742
		public RawMatrix3x2 Transform;
	}
}

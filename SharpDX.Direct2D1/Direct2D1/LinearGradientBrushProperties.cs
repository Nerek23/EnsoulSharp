using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200032B RID: 811
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LinearGradientBrushProperties
	{
		// Token: 0x04000AF8 RID: 2808
		public RawVector2 StartPoint;

		// Token: 0x04000AF9 RID: 2809
		public RawVector2 EndPoint;
	}
}

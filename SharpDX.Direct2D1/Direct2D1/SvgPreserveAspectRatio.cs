using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000337 RID: 823
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SvgPreserveAspectRatio
	{
		// Token: 0x04000B25 RID: 2853
		public RawBool Defer;

		// Token: 0x04000B26 RID: 2854
		public SvgAspectAlign Align;

		// Token: 0x04000B27 RID: 2855
		public SvgAspectScaling MeetOrSlice;
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000319 RID: 793
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BitmapBrushProperties1
	{
		// Token: 0x04000AAB RID: 2731
		public ExtendMode ExtendModeX;

		// Token: 0x04000AAC RID: 2732
		public ExtendMode ExtendModeY;

		// Token: 0x04000AAD RID: 2733
		public InterpolationMode InterpolationMode;
	}
}

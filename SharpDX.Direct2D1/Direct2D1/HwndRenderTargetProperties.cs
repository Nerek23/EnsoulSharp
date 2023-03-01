using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000326 RID: 806
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HwndRenderTargetProperties
	{
		// Token: 0x04000AE9 RID: 2793
		public IntPtr Hwnd;

		// Token: 0x04000AEA RID: 2794
		public Size2 PixelSize;

		// Token: 0x04000AEB RID: 2795
		public PresentOptions PresentOptions;
	}
}

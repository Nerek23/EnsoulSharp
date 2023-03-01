using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200008E RID: 142
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ModeDescription1
	{
		// Token: 0x04000D56 RID: 3414
		public int Width;

		// Token: 0x04000D57 RID: 3415
		public int Height;

		// Token: 0x04000D58 RID: 3416
		public Rational RefreshRate;

		// Token: 0x04000D59 RID: 3417
		public Format Format;

		// Token: 0x04000D5A RID: 3418
		public DisplayModeScanlineOrder ScanlineOrdering;

		// Token: 0x04000D5B RID: 3419
		public DisplayModeScaling Scaling;

		// Token: 0x04000D5C RID: 3420
		public RawBool Stereo;
	}
}

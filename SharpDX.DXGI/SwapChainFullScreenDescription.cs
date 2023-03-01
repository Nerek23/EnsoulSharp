using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200009D RID: 157
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SwapChainFullScreenDescription
	{
		// Token: 0x04000DF5 RID: 3573
		public Rational RefreshRate;

		// Token: 0x04000DF6 RID: 3574
		public DisplayModeScanlineOrder ScanlineOrdering;

		// Token: 0x04000DF7 RID: 3575
		public DisplayModeScaling Scaling;

		// Token: 0x04000DF8 RID: 3576
		public RawBool Windowed;
	}
}

using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200009B RID: 155
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SwapChainDescription
	{
		// Token: 0x04000DE2 RID: 3554
		public ModeDescription ModeDescription;

		// Token: 0x04000DE3 RID: 3555
		public SampleDescription SampleDescription;

		// Token: 0x04000DE4 RID: 3556
		public Usage Usage;

		// Token: 0x04000DE5 RID: 3557
		public int BufferCount;

		// Token: 0x04000DE6 RID: 3558
		public IntPtr OutputHandle;

		// Token: 0x04000DE7 RID: 3559
		public RawBool IsWindowed;

		// Token: 0x04000DE8 RID: 3560
		public SwapEffect SwapEffect;

		// Token: 0x04000DE9 RID: 3561
		public SwapChainFlags Flags;
	}
}

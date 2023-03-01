using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000094 RID: 148
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OutputDuplicateFrameInformation
	{
		// Token: 0x04000DC8 RID: 3528
		public long LastPresentTime;

		// Token: 0x04000DC9 RID: 3529
		public long LastMouseUpdateTime;

		// Token: 0x04000DCA RID: 3530
		public int AccumulatedFrames;

		// Token: 0x04000DCB RID: 3531
		public RawBool RectsCoalesced;

		// Token: 0x04000DCC RID: 3532
		public RawBool ProtectedContentMaskedOut;

		// Token: 0x04000DCD RID: 3533
		public OutputDuplicatePointerPosition PointerPosition;

		// Token: 0x04000DCE RID: 3534
		public int TotalMetadataBufferSize;

		// Token: 0x04000DCF RID: 3535
		public int PointerShapeBufferSize;
	}
}

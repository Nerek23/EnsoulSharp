using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000093 RID: 147
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OutputDuplicateDescription
	{
		// Token: 0x04000DC5 RID: 3525
		public ModeDescription ModeDescription;

		// Token: 0x04000DC6 RID: 3526
		public DisplayModeRotation Rotation;

		// Token: 0x04000DC7 RID: 3527
		public RawBool DesktopImageInSystemMemory;
	}
}

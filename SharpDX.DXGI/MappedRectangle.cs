using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200008D RID: 141
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct MappedRectangle
	{
		// Token: 0x04000D54 RID: 3412
		public int Pitch;

		// Token: 0x04000D55 RID: 3413
		public IntPtr PBits;
	}
}

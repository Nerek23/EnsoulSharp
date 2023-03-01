using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000DE RID: 222
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct AuthenticatedProtectionFlags
	{
		// Token: 0x040008E2 RID: 2274
		[FieldOffset(0)]
		public AuthenticatedProtectionFlagsMidlMidlItfD3d11000000340001Inner Flags;

		// Token: 0x040008E3 RID: 2275
		[FieldOffset(0)]
		public int Value;
	}
}

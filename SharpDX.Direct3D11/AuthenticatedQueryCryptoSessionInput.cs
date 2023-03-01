using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000E9 RID: 233
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AuthenticatedQueryCryptoSessionInput
	{
		// Token: 0x040008FF RID: 2303
		public AuthenticatedQueryInput Input;

		// Token: 0x04000900 RID: 2304
		public IntPtr DecoderHandle;
	}
}

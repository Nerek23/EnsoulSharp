using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000F3 RID: 243
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AuthenticatedQueryOutputIdCountInput
	{
		// Token: 0x0400091E RID: 2334
		public AuthenticatedQueryInput Input;

		// Token: 0x0400091F RID: 2335
		public IntPtr DeviceHandle;

		// Token: 0x04000920 RID: 2336
		public IntPtr CryptoSessionHandle;
	}
}

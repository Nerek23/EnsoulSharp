using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000F6 RID: 246
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AuthenticatedQueryOutputIdInput
	{
		// Token: 0x04000929 RID: 2345
		public AuthenticatedQueryInput Input;

		// Token: 0x0400092A RID: 2346
		public IntPtr DeviceHandle;

		// Token: 0x0400092B RID: 2347
		public IntPtr CryptoSessionHandle;

		// Token: 0x0400092C RID: 2348
		public int OutputIDIndex;
	}
}

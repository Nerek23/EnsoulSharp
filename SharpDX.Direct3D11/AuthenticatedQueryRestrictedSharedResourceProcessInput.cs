using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000FD RID: 253
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AuthenticatedQueryRestrictedSharedResourceProcessInput
	{
		// Token: 0x0400093F RID: 2367
		public AuthenticatedQueryInput Input;

		// Token: 0x04000940 RID: 2368
		public int ProcessIndex;
	}
}

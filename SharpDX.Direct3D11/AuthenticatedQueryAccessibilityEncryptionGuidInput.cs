using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000E2 RID: 226
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AuthenticatedQueryAccessibilityEncryptionGuidInput
	{
		// Token: 0x040008EB RID: 2283
		public AuthenticatedQueryInput Input;

		// Token: 0x040008EC RID: 2284
		public int EncryptionGuidIndex;
	}
}

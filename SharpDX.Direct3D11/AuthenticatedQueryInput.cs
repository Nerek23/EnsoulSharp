using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000F0 RID: 240
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AuthenticatedQueryInput
	{
		// Token: 0x04000911 RID: 2321
		public Guid QueryType;

		// Token: 0x04000912 RID: 2322
		public IntPtr HChannel;

		// Token: 0x04000913 RID: 2323
		public int SequenceNumber;
	}
}

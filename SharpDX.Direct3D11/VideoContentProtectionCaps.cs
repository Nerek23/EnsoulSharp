using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200016B RID: 363
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoContentProtectionCaps
	{
		// Token: 0x04000AF4 RID: 2804
		public int Caps;

		// Token: 0x04000AF5 RID: 2805
		public int KeyExchangeTypeCount;

		// Token: 0x04000AF6 RID: 2806
		public int BlockAlignmentSize;

		// Token: 0x04000AF7 RID: 2807
		public long ProtectedMemorySize;
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000111 RID: 273
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EncryptedBlockInformation
	{
		// Token: 0x0400097F RID: 2431
		public int NumEncryptedBytesAtBeginning;

		// Token: 0x04000980 RID: 2432
		public int NumBytesInSkipPattern;

		// Token: 0x04000981 RID: 2433
		public int NumBytesInEncryptPattern;
	}
}

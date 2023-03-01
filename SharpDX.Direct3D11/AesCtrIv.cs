using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000CF RID: 207
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AesCtrIv
	{
		// Token: 0x040008B0 RID: 2224
		public long Iv;

		// Token: 0x040008B1 RID: 2225
		public long Count;
	}
}

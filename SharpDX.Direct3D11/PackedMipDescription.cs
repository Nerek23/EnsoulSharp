using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200012E RID: 302
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PackedMipDescription
	{
		// Token: 0x040009E5 RID: 2533
		public byte StandardMipCount;

		// Token: 0x040009E6 RID: 2534
		public byte PackedMipCount;

		// Token: 0x040009E7 RID: 2535
		public int TilesForPackedMipCount;

		// Token: 0x040009E8 RID: 2536
		public int StartTileIndexInOverallResource;
	}
}

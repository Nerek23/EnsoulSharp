using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000151 RID: 337
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SubResourceTiling
	{
		// Token: 0x04000A7F RID: 2687
		public int WidthInTiles;

		// Token: 0x04000A80 RID: 2688
		public short HeightInTiles;

		// Token: 0x04000A81 RID: 2689
		public short DepthInTiles;

		// Token: 0x04000A82 RID: 2690
		public int StartTileIndexInOverallResource;
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200015D RID: 349
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TileShape
	{
		// Token: 0x04000AC3 RID: 2755
		public int WidthInTexels;

		// Token: 0x04000AC4 RID: 2756
		public int HeightInTexels;

		// Token: 0x04000AC5 RID: 2757
		public int DepthInTexels;
	}
}

using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200015C RID: 348
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TileRegionSize
	{
		// Token: 0x04000ABE RID: 2750
		public int TileCount;

		// Token: 0x04000ABF RID: 2751
		public RawBool BUseBox;

		// Token: 0x04000AC0 RID: 2752
		public int Width;

		// Token: 0x04000AC1 RID: 2753
		public short Height;

		// Token: 0x04000AC2 RID: 2754
		public short Depth;
	}
}

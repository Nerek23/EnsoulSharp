using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000331 RID: 817
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RenderingControls
	{
		// Token: 0x04000B0A RID: 2826
		public BufferPrecision BufferPrecision;

		// Token: 0x04000B0B RID: 2827
		public Size2 TileSize;
	}
}

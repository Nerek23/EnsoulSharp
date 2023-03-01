using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200015B RID: 347
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TiledResourceCoordinate
	{
		// Token: 0x04000ABA RID: 2746
		public int X;

		// Token: 0x04000ABB RID: 2747
		public int Y;

		// Token: 0x04000ABC RID: 2748
		public int Z;

		// Token: 0x04000ABD RID: 2749
		public int Subresource;
	}
}

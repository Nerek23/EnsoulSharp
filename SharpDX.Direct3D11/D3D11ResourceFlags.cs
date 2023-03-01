using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000106 RID: 262
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct D3D11ResourceFlags
	{
		// Token: 0x0400095A RID: 2394
		public int BindFlags;

		// Token: 0x0400095B RID: 2395
		public int MiscFlags;

		// Token: 0x0400095C RID: 2396
		public int CPUAccessFlags;

		// Token: 0x0400095D RID: 2397
		public int StructureByteStride;
	}
}

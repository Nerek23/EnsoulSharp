using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000153 RID: 339
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Texture2DArrayVpov
	{
		// Token: 0x04000A8B RID: 2699
		public int MipSlice;

		// Token: 0x04000A8C RID: 2700
		public int FirstArraySlice;

		// Token: 0x04000A8D RID: 2701
		public int ArraySize;
	}
}

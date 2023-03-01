using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000157 RID: 343
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Texture2DVpiv
	{
		// Token: 0x04000AA4 RID: 2724
		public int MipSlice;

		// Token: 0x04000AA5 RID: 2725
		public int ArraySlice;
	}
}

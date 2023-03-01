using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200017B RID: 379
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoProcessorInputViewDescription
	{
		// Token: 0x04000B60 RID: 2912
		public int FourCC;

		// Token: 0x04000B61 RID: 2913
		public VpivDimension Dimension;

		// Token: 0x04000B62 RID: 2914
		public Texture2DVpiv Texture2D;
	}
}

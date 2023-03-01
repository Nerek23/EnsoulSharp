using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000110 RID: 272
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DrawInstancedIndirectArguments
	{
		// Token: 0x0400097B RID: 2427
		public int VertexCountPerInstance;

		// Token: 0x0400097C RID: 2428
		public int InstanceCount;

		// Token: 0x0400097D RID: 2429
		public int StartVertexLocation;

		// Token: 0x0400097E RID: 2430
		public int StartInstanceLocation;
	}
}

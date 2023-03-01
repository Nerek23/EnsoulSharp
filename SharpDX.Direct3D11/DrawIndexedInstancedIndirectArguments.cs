using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200010F RID: 271
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DrawIndexedInstancedIndirectArguments
	{
		// Token: 0x04000976 RID: 2422
		public int IndexCountPerInstance;

		// Token: 0x04000977 RID: 2423
		public int InstanceCount;

		// Token: 0x04000978 RID: 2424
		public int StartIndexLocation;

		// Token: 0x04000979 RID: 2425
		public int BaseVertexLocation;

		// Token: 0x0400097A RID: 2426
		public int StartInstanceLocation;
	}
}

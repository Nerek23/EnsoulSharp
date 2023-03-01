using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000103 RID: 259
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ClassInstanceDescription
	{
		// Token: 0x0400094D RID: 2381
		public int InstanceId;

		// Token: 0x0400094E RID: 2382
		public int InstanceIndex;

		// Token: 0x0400094F RID: 2383
		public int TypeId;

		// Token: 0x04000950 RID: 2384
		public int ConstantBuffer;

		// Token: 0x04000951 RID: 2385
		public int BaseConstantBufferOffset;

		// Token: 0x04000952 RID: 2386
		public int BaseTexture;

		// Token: 0x04000953 RID: 2387
		public int BaseSampler;

		// Token: 0x04000954 RID: 2388
		public RawBool IsCreated;
	}
}

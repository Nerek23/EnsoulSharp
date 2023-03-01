using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000089 RID: 137
	public enum ShaderTrackingResourceType
	{
		// Token: 0x040007C0 RID: 1984
		None,
		// Token: 0x040007C1 RID: 1985
		UnorderedAccessViewDevicememory,
		// Token: 0x040007C2 RID: 1986
		NonUnorderedAccessViewDevicememory,
		// Token: 0x040007C3 RID: 1987
		AllDevicememory,
		// Token: 0x040007C4 RID: 1988
		GroupsharedMemory,
		// Token: 0x040007C5 RID: 1989
		AllSharedMemory,
		// Token: 0x040007C6 RID: 1990
		GroupsharedNonUnorderedAccessView,
		// Token: 0x040007C7 RID: 1991
		All
	}
}

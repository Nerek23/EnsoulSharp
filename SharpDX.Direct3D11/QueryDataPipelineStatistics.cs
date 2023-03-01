using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200012F RID: 303
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct QueryDataPipelineStatistics
	{
		// Token: 0x040009E9 RID: 2537
		public long IAVerticeCount;

		// Token: 0x040009EA RID: 2538
		public long IAPrimitiveCount;

		// Token: 0x040009EB RID: 2539
		public long VSInvocationCount;

		// Token: 0x040009EC RID: 2540
		public long GSInvocationCount;

		// Token: 0x040009ED RID: 2541
		public long GSPrimitiveCount;

		// Token: 0x040009EE RID: 2542
		public long CInvocationCount;

		// Token: 0x040009EF RID: 2543
		public long CPrimitiveCount;

		// Token: 0x040009F0 RID: 2544
		public long PSInvocationCount;

		// Token: 0x040009F1 RID: 2545
		public long HSInvocationCount;

		// Token: 0x040009F2 RID: 2546
		public long DSInvocationCount;

		// Token: 0x040009F3 RID: 2547
		public long CSInvocationCount;
	}
}

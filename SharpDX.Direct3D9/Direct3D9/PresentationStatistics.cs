using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000100 RID: 256
	public struct PresentationStatistics
	{
		// Token: 0x04000DEE RID: 3566
		public int PresentCount;

		// Token: 0x04000DEF RID: 3567
		public int PresentRefreshCount;

		// Token: 0x04000DF0 RID: 3568
		public int SyncRefreshCount;

		// Token: 0x04000DF1 RID: 3569
		public long SyncQPCTime;

		// Token: 0x04000DF2 RID: 3570
		public long SyncGPUTime;
	}
}

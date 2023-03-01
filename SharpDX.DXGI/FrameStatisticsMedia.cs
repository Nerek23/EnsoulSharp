using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200007C RID: 124
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FrameStatisticsMedia
	{
		// Token: 0x04000406 RID: 1030
		public int PresentCount;

		// Token: 0x04000407 RID: 1031
		public int PresentRefreshCount;

		// Token: 0x04000408 RID: 1032
		public int SyncRefreshCount;

		// Token: 0x04000409 RID: 1033
		public long SyncQPCTime;

		// Token: 0x0400040A RID: 1034
		public long SyncGPUTime;

		// Token: 0x0400040B RID: 1035
		public FramePresentationMode CompositionMode;

		// Token: 0x0400040C RID: 1036
		public int ApprovedPresentDuration;
	}
}

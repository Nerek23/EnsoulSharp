using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200007B RID: 123
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FrameStatistics
	{
		// Token: 0x04000401 RID: 1025
		public int PresentCount;

		// Token: 0x04000402 RID: 1026
		public int PresentRefreshCount;

		// Token: 0x04000403 RID: 1027
		public int SyncRefreshCount;

		// Token: 0x04000404 RID: 1028
		public long SyncQPCTime;

		// Token: 0x04000405 RID: 1029
		public long SyncGPUTime;
	}
}

using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000108 RID: 264
	public struct ResourceStats
	{
		// Token: 0x04000E1D RID: 3613
		public RawBool Thrashing;

		// Token: 0x04000E1E RID: 3614
		public int ApproximateBytesDownloaded;

		// Token: 0x04000E1F RID: 3615
		public int NumberEvicted;

		// Token: 0x04000E20 RID: 3616
		public int NumberVideoCreated;

		// Token: 0x04000E21 RID: 3617
		public int LastPriority;

		// Token: 0x04000E22 RID: 3618
		public int NumberUsed;

		// Token: 0x04000E23 RID: 3619
		public int NumberUsedInVideoMemory;

		// Token: 0x04000E24 RID: 3620
		public int WorkingSet;

		// Token: 0x04000E25 RID: 3621
		public int WorkingSetBytes;

		// Token: 0x04000E26 RID: 3622
		public int TotalManaged;

		// Token: 0x04000E27 RID: 3623
		public int TotalBytes;
	}
}

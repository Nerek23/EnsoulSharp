using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000EF RID: 239
	public struct InterfaceTimings
	{
		// Token: 0x04000D90 RID: 3472
		public float WaitingForGPUToUseApplicationResourceTimePercent;

		// Token: 0x04000D91 RID: 3473
		public float WaitingForGPUToAcceptMoreCommandsTimePercent;

		// Token: 0x04000D92 RID: 3474
		public float WaitingForGPUToStayWithinLatencyTimePercent;

		// Token: 0x04000D93 RID: 3475
		public float WaitingForGPUExclusiveResourceTimePercent;

		// Token: 0x04000D94 RID: 3476
		public float WaitingForGPUOtherTimePercent;
	}
}

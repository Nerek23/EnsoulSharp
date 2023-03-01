using System;

namespace SharpDX.DXGI
{
	// Token: 0x02000031 RID: 49
	public enum ComputePreemptionGranularity
	{
		// Token: 0x0400005D RID: 93
		DmaBufferBoundary,
		// Token: 0x0400005E RID: 94
		DispatchBoundary,
		// Token: 0x0400005F RID: 95
		ThreadGroupBoundary,
		// Token: 0x04000060 RID: 96
		ThreadBoundary,
		// Token: 0x04000061 RID: 97
		InstructionBoundary
	}
}

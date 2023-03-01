using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000069 RID: 105
	[Flags]
	public enum DebugFeatureFlags
	{
		// Token: 0x0400018B RID: 395
		FlushPerRender = 1,
		// Token: 0x0400018C RID: 396
		FinishPerRender = 2,
		// Token: 0x0400018D RID: 397
		PresentPerRender = 4,
		// Token: 0x0400018E RID: 398
		AlwaysDiscardOfferedResource = 8,
		// Token: 0x0400018F RID: 399
		NeverDiscardOfferedResource = 16,
		// Token: 0x04000190 RID: 400
		AvoidBehaviorChangingDebugAids = 64,
		// Token: 0x04000191 RID: 401
		DisableTiledResourceMappingTrackingAndValidation = 128
	}
}

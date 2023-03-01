using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000055 RID: 85
	[Flags]
	public enum DeviceCaps2
	{
		// Token: 0x0400062C RID: 1580
		StreamOffset = 1,
		// Token: 0x0400062D RID: 1581
		DMapNPatch = 2,
		// Token: 0x0400062E RID: 1582
		AdaptiveTessRTPatch = 4,
		// Token: 0x0400062F RID: 1583
		AdaptiveTessNPatch = 8,
		// Token: 0x04000630 RID: 1584
		CanStretchRectFromTextures = 16,
		// Token: 0x04000631 RID: 1585
		PresampledMapNPatch = 32,
		// Token: 0x04000632 RID: 1586
		VertexElementsCanShareStreamOffset = 64
	}
}

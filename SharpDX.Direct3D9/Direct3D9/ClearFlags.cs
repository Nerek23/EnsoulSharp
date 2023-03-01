using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000042 RID: 66
	[Flags]
	public enum ClearFlags
	{
		// Token: 0x04000586 RID: 1414
		Target = 1,
		// Token: 0x04000587 RID: 1415
		ZBuffer = 2,
		// Token: 0x04000588 RID: 1416
		Stencil = 4,
		// Token: 0x04000589 RID: 1417
		All = 7,
		// Token: 0x0400058A RID: 1418
		None = 0
	}
}

using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000043 RID: 67
	[Flags]
	public enum ClipFlags
	{
		// Token: 0x0400058C RID: 1420
		Left = 1,
		// Token: 0x0400058D RID: 1421
		Right = 2,
		// Token: 0x0400058E RID: 1422
		Top = 4,
		// Token: 0x0400058F RID: 1423
		Bottom = 8,
		// Token: 0x04000590 RID: 1424
		Front = 16,
		// Token: 0x04000591 RID: 1425
		Back = 32,
		// Token: 0x04000592 RID: 1426
		Plane0 = 64,
		// Token: 0x04000593 RID: 1427
		Plane1 = 128,
		// Token: 0x04000594 RID: 1428
		Plane2 = 256,
		// Token: 0x04000595 RID: 1429
		Plane3 = 512,
		// Token: 0x04000596 RID: 1430
		Plane4 = 1024,
		// Token: 0x04000597 RID: 1431
		Plane5 = 2048,
		// Token: 0x04000598 RID: 1432
		All = 4095
	}
}

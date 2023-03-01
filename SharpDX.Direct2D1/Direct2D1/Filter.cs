using System;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000296 RID: 662
	public enum Filter
	{
		// Token: 0x04000848 RID: 2120
		MinimumMagMipPoint,
		// Token: 0x04000849 RID: 2121
		MinimumMagPointMipLinear,
		// Token: 0x0400084A RID: 2122
		MinimumPointMagLinearMipPoint = 4,
		// Token: 0x0400084B RID: 2123
		MinimumPointMagMipLinear,
		// Token: 0x0400084C RID: 2124
		MinimumLinearMagMipPoint = 16,
		// Token: 0x0400084D RID: 2125
		MinimumLinearMagPointMipLinear,
		// Token: 0x0400084E RID: 2126
		MinimumMagLinearMipPoint = 20,
		// Token: 0x0400084F RID: 2127
		MinimumMagMipLinear,
		// Token: 0x04000850 RID: 2128
		Anisotropic = 85
	}
}

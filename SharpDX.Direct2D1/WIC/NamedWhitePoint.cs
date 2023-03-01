using System;

namespace SharpDX.WIC
{
	// Token: 0x02000050 RID: 80
	[Flags]
	public enum NamedWhitePoint
	{
		// Token: 0x0400011E RID: 286
		Default = 1,
		// Token: 0x0400011F RID: 287
		Daylight = 2,
		// Token: 0x04000120 RID: 288
		Cloudy = 4,
		// Token: 0x04000121 RID: 289
		Shade = 8,
		// Token: 0x04000122 RID: 290
		Tungsten = 16,
		// Token: 0x04000123 RID: 291
		Fluorescent = 32,
		// Token: 0x04000124 RID: 292
		Flash = 64,
		// Token: 0x04000125 RID: 293
		Underwater = 128,
		// Token: 0x04000126 RID: 294
		Custom = 256,
		// Token: 0x04000127 RID: 295
		AutoWhiteBalance = 512,
		// Token: 0x04000128 RID: 296
		AsShot = 1
	}
}

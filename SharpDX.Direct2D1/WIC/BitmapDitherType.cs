using System;

namespace SharpDX.WIC
{
	// Token: 0x02000037 RID: 55
	public enum BitmapDitherType
	{
		// Token: 0x04000097 RID: 151
		None,
		// Token: 0x04000098 RID: 152
		Solid = 0,
		// Token: 0x04000099 RID: 153
		Ordered4x4,
		// Token: 0x0400009A RID: 154
		Ordered8x8,
		// Token: 0x0400009B RID: 155
		Ordered16x16,
		// Token: 0x0400009C RID: 156
		Spiral4x4,
		// Token: 0x0400009D RID: 157
		Spiral8x8,
		// Token: 0x0400009E RID: 158
		DualSpiral4x4,
		// Token: 0x0400009F RID: 159
		DualSpiral8x8,
		// Token: 0x040000A0 RID: 160
		ErrorDiffusion
	}
}

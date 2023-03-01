using System;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000EB RID: 235
	public enum FontFaceType
	{
		// Token: 0x04000289 RID: 649
		Cff,
		// Token: 0x0400028A RID: 650
		Truetype,
		// Token: 0x0400028B RID: 651
		OpenTypeCollection,
		// Token: 0x0400028C RID: 652
		Type1,
		// Token: 0x0400028D RID: 653
		Vector,
		// Token: 0x0400028E RID: 654
		Bitmap,
		// Token: 0x0400028F RID: 655
		Unknown,
		// Token: 0x04000290 RID: 656
		RawCff,
		// Token: 0x04000291 RID: 657
		TruetypeCollection = 2
	}
}

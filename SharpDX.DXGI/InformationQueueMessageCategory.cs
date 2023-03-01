using System;

namespace SharpDX.DXGI
{
	// Token: 0x0200003E RID: 62
	public enum InformationQueueMessageCategory
	{
		// Token: 0x04000115 RID: 277
		Unknown,
		// Token: 0x04000116 RID: 278
		Miscellaneous,
		// Token: 0x04000117 RID: 279
		Initialization,
		// Token: 0x04000118 RID: 280
		Cleanup,
		// Token: 0x04000119 RID: 281
		Compilation,
		// Token: 0x0400011A RID: 282
		StateCreation,
		// Token: 0x0400011B RID: 283
		StateSetting,
		// Token: 0x0400011C RID: 284
		StateGetting,
		// Token: 0x0400011D RID: 285
		ResourceManipulation,
		// Token: 0x0400011E RID: 286
		Execution,
		// Token: 0x0400011F RID: 287
		Shader
	}
}

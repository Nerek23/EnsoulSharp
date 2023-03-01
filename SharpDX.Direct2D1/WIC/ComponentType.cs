using System;

namespace SharpDX.WIC
{
	// Token: 0x02000040 RID: 64
	[Flags]
	public enum ComponentType
	{
		// Token: 0x040000D4 RID: 212
		Decoder = 1,
		// Token: 0x040000D5 RID: 213
		Encoder = 2,
		// Token: 0x040000D6 RID: 214
		PixelFormatConverter = 4,
		// Token: 0x040000D7 RID: 215
		MetadataReader = 8,
		// Token: 0x040000D8 RID: 216
		MetadataWriter = 16,
		// Token: 0x040000D9 RID: 217
		PixelFormat = 32,
		// Token: 0x040000DA RID: 218
		AllComponents = 63
	}
}

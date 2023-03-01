using System;

namespace SharpDX.WIC
{
	// Token: 0x02000036 RID: 54
	[Flags]
	public enum BitmapDecoderCapabilities
	{
		// Token: 0x04000090 RID: 144
		SameEncoder = 1,
		// Token: 0x04000091 RID: 145
		CanDecodeAllImages = 2,
		// Token: 0x04000092 RID: 146
		CanDecodeSomeImages = 4,
		// Token: 0x04000093 RID: 147
		CanEnumerateMetadata = 8,
		// Token: 0x04000094 RID: 148
		CanDecodeThumbnail = 16,
		// Token: 0x04000095 RID: 149
		None = 0
	}
}

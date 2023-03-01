using System;

namespace SharpDX.Win32
{
	// Token: 0x0200003B RID: 59
	public struct BitmapInfoHeader
	{
		// Token: 0x04000093 RID: 147
		public int SizeInBytes;

		// Token: 0x04000094 RID: 148
		public int Width;

		// Token: 0x04000095 RID: 149
		public int Height;

		// Token: 0x04000096 RID: 150
		public short PlaneCount;

		// Token: 0x04000097 RID: 151
		public short BitCount;

		// Token: 0x04000098 RID: 152
		public int Compression;

		// Token: 0x04000099 RID: 153
		public int SizeImage;

		// Token: 0x0400009A RID: 154
		public int XPixelsPerMeter;

		// Token: 0x0400009B RID: 155
		public int YPixelsPerMeter;

		// Token: 0x0400009C RID: 156
		public int ColorUsedCount;

		// Token: 0x0400009D RID: 157
		public int ColorImportantCount;
	}
}

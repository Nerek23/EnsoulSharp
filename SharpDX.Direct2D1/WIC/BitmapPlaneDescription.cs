using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000079 RID: 121
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BitmapPlaneDescription
	{
		// Token: 0x040001D6 RID: 470
		public Guid Format;

		// Token: 0x040001D7 RID: 471
		public int Width;

		// Token: 0x040001D8 RID: 472
		public int Height;
	}
}

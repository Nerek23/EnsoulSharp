using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.WIC
{
	// Token: 0x0200007A RID: 122
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DdsFormatInfo
	{
		// Token: 0x040001D9 RID: 473
		public Format DxgiFormat;

		// Token: 0x040001DA RID: 474
		public int BytesPerBlock;

		// Token: 0x040001DB RID: 475
		public int BlockWidth;

		// Token: 0x040001DC RID: 476
		public int BlockHeight;
	}
}

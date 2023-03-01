using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000078 RID: 120
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BitmapPlane
	{
		// Token: 0x040001D2 RID: 466
		public Guid Format;

		// Token: 0x040001D3 RID: 467
		public IntPtr PbBuffer;

		// Token: 0x040001D4 RID: 468
		public int CbStride;

		// Token: 0x040001D5 RID: 469
		public int CbBufferSize;
	}
}

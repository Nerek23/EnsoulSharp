using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000152 RID: 338
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FileFragment
	{
		// Token: 0x040004FD RID: 1277
		public long FileOffset;

		// Token: 0x040004FE RID: 1278
		public long FragmentSize;
	}
}

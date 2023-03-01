using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000150 RID: 336
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct StreamOutputStatistics
	{
		// Token: 0x04000A7D RID: 2685
		public long NumPrimitivesWritten;

		// Token: 0x04000A7E RID: 2686
		public long PrimitivesStorageNeeded;
	}
}

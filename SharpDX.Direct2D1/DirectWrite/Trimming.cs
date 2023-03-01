using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200016E RID: 366
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Trimming
	{
		// Token: 0x040005D4 RID: 1492
		public TrimmingGranularity Granularity;

		// Token: 0x040005D5 RID: 1493
		public int Delimiter;

		// Token: 0x040005D6 RID: 1494
		public int DelimiterCount;
	}
}

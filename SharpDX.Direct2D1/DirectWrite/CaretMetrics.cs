using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200014C RID: 332
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CaretMetrics
	{
		// Token: 0x040004D6 RID: 1238
		public short SlopeRise;

		// Token: 0x040004D7 RID: 1239
		public short SlopeRun;

		// Token: 0x040004D8 RID: 1240
		public short Offset;
	}
}

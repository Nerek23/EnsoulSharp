using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200015D RID: 349
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LineMetrics
	{
		// Token: 0x0400054F RID: 1359
		public int Length;

		// Token: 0x04000550 RID: 1360
		public int TrailingWhitespaceLength;

		// Token: 0x04000551 RID: 1361
		public int NewlineLength;

		// Token: 0x04000552 RID: 1362
		public float Height;

		// Token: 0x04000553 RID: 1363
		public float Baseline;

		// Token: 0x04000554 RID: 1364
		public RawBool IsTrimmed;
	}
}

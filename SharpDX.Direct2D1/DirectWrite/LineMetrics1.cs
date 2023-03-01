using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200015E RID: 350
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LineMetrics1
	{
		// Token: 0x04000555 RID: 1365
		public int Length;

		// Token: 0x04000556 RID: 1366
		public int TrailingWhitespaceLength;

		// Token: 0x04000557 RID: 1367
		public int NewlineLength;

		// Token: 0x04000558 RID: 1368
		public float Height;

		// Token: 0x04000559 RID: 1369
		public float Baseline;

		// Token: 0x0400055A RID: 1370
		public RawBool IsTrimmed;

		// Token: 0x0400055B RID: 1371
		public float LeadingBefore;

		// Token: 0x0400055C RID: 1372
		public float LeadingAfter;
	}
}

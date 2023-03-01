using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200015F RID: 351
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LineSpacing
	{
		// Token: 0x0400055D RID: 1373
		public LineSpacingMethod Method;

		// Token: 0x0400055E RID: 1374
		public float Height;

		// Token: 0x0400055F RID: 1375
		public float Baseline;

		// Token: 0x04000560 RID: 1376
		public float LeadingBefore;

		// Token: 0x04000561 RID: 1377
		public FontLineGapUsage FontLineGapUsage;
	}
}

using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200015B RID: 347
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct InlineObjectMetrics
	{
		// Token: 0x04000541 RID: 1345
		public float Width;

		// Token: 0x04000542 RID: 1346
		public float Height;

		// Token: 0x04000543 RID: 1347
		public float Baseline;

		// Token: 0x04000544 RID: 1348
		public RawBool SupportsSideways;
	}
}

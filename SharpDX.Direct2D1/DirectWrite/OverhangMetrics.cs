using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000160 RID: 352
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OverhangMetrics
	{
		// Token: 0x04000562 RID: 1378
		public float Left;

		// Token: 0x04000563 RID: 1379
		public float Top;

		// Token: 0x04000564 RID: 1380
		public float Right;

		// Token: 0x04000565 RID: 1381
		public float Bottom;
	}
}

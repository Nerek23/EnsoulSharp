using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200015A RID: 346
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HitTestMetrics
	{
		// Token: 0x04000538 RID: 1336
		public int TextPosition;

		// Token: 0x04000539 RID: 1337
		public int Length;

		// Token: 0x0400053A RID: 1338
		public float Left;

		// Token: 0x0400053B RID: 1339
		public float Top;

		// Token: 0x0400053C RID: 1340
		public float Width;

		// Token: 0x0400053D RID: 1341
		public float Height;

		// Token: 0x0400053E RID: 1342
		public int BidiLevel;

		// Token: 0x0400053F RID: 1343
		public RawBool IsText;

		// Token: 0x04000540 RID: 1344
		public RawBool IsTrimmed;
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000339 RID: 825
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TransformedImageSourceProperties
	{
		// Token: 0x04000B2C RID: 2860
		public Orientation Orientation;

		// Token: 0x04000B2D RID: 2861
		public float ScaleX;

		// Token: 0x04000B2E RID: 2862
		public float ScaleY;

		// Token: 0x04000B2F RID: 2863
		public InterpolationMode InterpolationMode;

		// Token: 0x04000B30 RID: 2864
		public TransformedImageSourceOptions Options;
	}
}

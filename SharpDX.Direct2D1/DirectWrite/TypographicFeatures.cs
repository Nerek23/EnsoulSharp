using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200016F RID: 367
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct TypographicFeatures
	{
		// Token: 0x040005D7 RID: 1495
		public IntPtr Features;

		// Token: 0x040005D8 RID: 1496
		public int FeatureCount;
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200017A RID: 378
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoProcessorFilterRange
	{
		// Token: 0x04000B5C RID: 2908
		public int Minimum;

		// Token: 0x04000B5D RID: 2909
		public int Maximum;

		// Token: 0x04000B5E RID: 2910
		public int Default;

		// Token: 0x04000B5F RID: 2911
		public float Multiplier;
	}
}

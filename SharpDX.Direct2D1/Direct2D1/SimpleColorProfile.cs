using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000333 RID: 819
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SimpleColorProfile
	{
		// Token: 0x04000B0F RID: 2831
		public RawVector2 RedPrimary;

		// Token: 0x04000B10 RID: 2832
		public RawVector2 GreenPrimary;

		// Token: 0x04000B11 RID: 2833
		public RawVector2 BluePrimary;

		// Token: 0x04000B12 RID: 2834
		public RawVector2 WhitePointXZ;

		// Token: 0x04000B13 RID: 2835
		public Gamma1 Gamma;
	}
}

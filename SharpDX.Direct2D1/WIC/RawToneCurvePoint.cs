using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000081 RID: 129
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RawToneCurvePoint
	{
		// Token: 0x0400020B RID: 523
		public double Input;

		// Token: 0x0400020C RID: 524
		public double Output;
	}
}

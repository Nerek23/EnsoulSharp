using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200032A RID: 810
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct InkStyleProperties
	{
		// Token: 0x04000AF6 RID: 2806
		public InkNibShape NibShape;

		// Token: 0x04000AF7 RID: 2807
		public RawMatrix3x2 NibTransform;
	}
}

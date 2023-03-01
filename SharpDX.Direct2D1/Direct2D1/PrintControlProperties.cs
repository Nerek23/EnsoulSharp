using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200032E RID: 814
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PrintControlProperties
	{
		// Token: 0x04000B01 RID: 2817
		public PrintFontSubsetMode FontSubset;

		// Token: 0x04000B02 RID: 2818
		public float RasterDPI;

		// Token: 0x04000B03 RID: 2819
		public ColorSpace ColorSpace;
	}
}

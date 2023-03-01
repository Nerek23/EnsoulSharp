using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000209 RID: 521
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PixelFormat
	{
		// Token: 0x06000B1E RID: 2846 RVA: 0x0001FBA3 File Offset: 0x0001DDA3
		public PixelFormat(Format format, AlphaMode alphaMode)
		{
			this.Format = format;
			this.AlphaMode = alphaMode;
		}

		// Token: 0x04000692 RID: 1682
		public Format Format;

		// Token: 0x04000693 RID: 1683
		public AlphaMode AlphaMode;
	}
}

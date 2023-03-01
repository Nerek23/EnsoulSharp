using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000171 RID: 369
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoDecoderDescription
	{
		// Token: 0x04000B2A RID: 2858
		public Guid Guid;

		// Token: 0x04000B2B RID: 2859
		public int SampleWidth;

		// Token: 0x04000B2C RID: 2860
		public int SampleHeight;

		// Token: 0x04000B2D RID: 2861
		public Format OutputFormat;
	}
}

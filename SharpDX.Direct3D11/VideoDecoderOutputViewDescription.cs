using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000174 RID: 372
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoDecoderOutputViewDescription
	{
		// Token: 0x04000B3C RID: 2876
		public Guid DecodeProfile;

		// Token: 0x04000B3D RID: 2877
		public VdovDimension Dimension;

		// Token: 0x04000B3E RID: 2878
		public Texture2DVdov Texture2D;
	}
}

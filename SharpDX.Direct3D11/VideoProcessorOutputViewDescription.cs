using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200017C RID: 380
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct VideoProcessorOutputViewDescription
	{
		// Token: 0x04000B63 RID: 2915
		[FieldOffset(0)]
		public VpovDimension Dimension;

		// Token: 0x04000B64 RID: 2916
		[FieldOffset(4)]
		public Texture2DVpov Texture2D;

		// Token: 0x04000B65 RID: 2917
		[FieldOffset(4)]
		public Texture2DArrayVpov Texture2DArray;
	}
}

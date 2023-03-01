using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000180 RID: 384
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoProcessorStreamBehaviorHint
	{
		// Token: 0x04000B81 RID: 2945
		public RawBool Enable;

		// Token: 0x04000B82 RID: 2946
		public int Width;

		// Token: 0x04000B83 RID: 2947
		public int Height;

		// Token: 0x04000B84 RID: 2948
		public Format Format;
	}
}

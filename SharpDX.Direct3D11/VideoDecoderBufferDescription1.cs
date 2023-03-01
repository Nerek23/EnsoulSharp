using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200016F RID: 367
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoDecoderBufferDescription1
	{
		// Token: 0x04000B12 RID: 2834
		public VideoDecoderBufferType BufferType;

		// Token: 0x04000B13 RID: 2835
		public int DataOffset;

		// Token: 0x04000B14 RID: 2836
		public int DataSize;

		// Token: 0x04000B15 RID: 2837
		public IntPtr PIV;

		// Token: 0x04000B16 RID: 2838
		public int IVSize;

		// Token: 0x04000B17 RID: 2839
		public IntPtr PSubSampleMappingBlock;

		// Token: 0x04000B18 RID: 2840
		public int SubSampleMappingCount;
	}
}

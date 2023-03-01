using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200016E RID: 366
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoDecoderBufferDescription
	{
		// Token: 0x04000B04 RID: 2820
		public VideoDecoderBufferType BufferType;

		// Token: 0x04000B05 RID: 2821
		public int BufferIndex;

		// Token: 0x04000B06 RID: 2822
		public int DataOffset;

		// Token: 0x04000B07 RID: 2823
		public int DataSize;

		// Token: 0x04000B08 RID: 2824
		public int FirstMBaddress;

		// Token: 0x04000B09 RID: 2825
		public int NumMBsInBuffer;

		// Token: 0x04000B0A RID: 2826
		public int Width;

		// Token: 0x04000B0B RID: 2827
		public int Height;

		// Token: 0x04000B0C RID: 2828
		public int Stride;

		// Token: 0x04000B0D RID: 2829
		public int ReservedBits;

		// Token: 0x04000B0E RID: 2830
		public IntPtr PIV;

		// Token: 0x04000B0F RID: 2831
		public int IVSize;

		// Token: 0x04000B10 RID: 2832
		public RawBool PartialEncryption;

		// Token: 0x04000B11 RID: 2833
		public EncryptedBlockInformation EncryptedBlockInfo;
	}
}

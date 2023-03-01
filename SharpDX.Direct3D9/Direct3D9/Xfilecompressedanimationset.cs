using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200011C RID: 284
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Xfilecompressedanimationset
	{
		// Token: 0x04000E8E RID: 3726
		public int CompressedBlockSize;

		// Token: 0x04000E8F RID: 3727
		public float TicksPerSec;

		// Token: 0x04000E90 RID: 3728
		public int PlaybackType;

		// Token: 0x04000E91 RID: 3729
		public int BufferLength;
	}
}

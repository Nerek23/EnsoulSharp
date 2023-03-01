using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000112 RID: 274
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct TrackDescription
	{
		// Token: 0x04000E4C RID: 3660
		public TrackPriority Priority;

		// Token: 0x04000E4D RID: 3661
		public float Weight;

		// Token: 0x04000E4E RID: 3662
		public float Speed;

		// Token: 0x04000E4F RID: 3663
		public double Position;

		// Token: 0x04000E50 RID: 3664
		public RawBool Enable;
	}
}

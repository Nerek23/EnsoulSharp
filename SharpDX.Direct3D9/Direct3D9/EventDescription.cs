using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000E2 RID: 226
	[StructLayout(LayoutKind.Explicit, Pack = 8)]
	public struct EventDescription
	{
		// Token: 0x04000A33 RID: 2611
		[FieldOffset(0)]
		public EventType Type;

		// Token: 0x04000A34 RID: 2612
		[FieldOffset(4)]
		public int Track;

		// Token: 0x04000A35 RID: 2613
		[FieldOffset(8)]
		public double StartTime;

		// Token: 0x04000A36 RID: 2614
		[FieldOffset(16)]
		public double Duration;

		// Token: 0x04000A37 RID: 2615
		[FieldOffset(24)]
		public TransitionType Transition;

		// Token: 0x04000A38 RID: 2616
		[FieldOffset(28)]
		public float Weight;

		// Token: 0x04000A39 RID: 2617
		[FieldOffset(28)]
		public float Speed;

		// Token: 0x04000A3A RID: 2618
		[FieldOffset(28)]
		public double Position;

		// Token: 0x04000A3B RID: 2619
		[FieldOffset(28)]
		public RawBool Enable;
	}
}

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000092 RID: 146
	[DebuggerDisplay("X: {X}, Y: {Y}, Width: {Width}, Height: {Height}, MinDepth: {MinDepth}, MaxDepth: {MaxDepth}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawViewport
	{
		// Token: 0x0400118E RID: 4494
		public int X;

		// Token: 0x0400118F RID: 4495
		public int Y;

		// Token: 0x04001190 RID: 4496
		public int Width;

		// Token: 0x04001191 RID: 4497
		public int Height;

		// Token: 0x04001192 RID: 4498
		public float MinDepth;

		// Token: 0x04001193 RID: 4499
		public float MaxDepth;
	}
}

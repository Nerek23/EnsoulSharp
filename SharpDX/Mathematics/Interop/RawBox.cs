using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000080 RID: 128
	[DebuggerDisplay("X: {X}, Y: {Y}, Width: {Width}, Height: {Height}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawBox
	{
		// Token: 0x06000305 RID: 773 RVA: 0x0000900C File Offset: 0x0000720C
		public RawBox(int x, int y, int width, int height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x04001129 RID: 4393
		public int X;

		// Token: 0x0400112A RID: 4394
		public int Y;

		// Token: 0x0400112B RID: 4395
		public int Width;

		// Token: 0x0400112C RID: 4396
		public int Height;
	}
}

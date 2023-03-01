using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x0200008E RID: 142
	[DebuggerDisplay("Left: {Left}, Top: {Top}, Right: {Right}, Bottom: {Bottom}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawRectangleF
	{
		// Token: 0x06000311 RID: 785 RVA: 0x00009168 File Offset: 0x00007368
		public RawRectangleF(float left, float top, float right, float bottom)
		{
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}

		// Token: 0x04001181 RID: 4481
		public float Left;

		// Token: 0x04001182 RID: 4482
		public float Top;

		// Token: 0x04001183 RID: 4483
		public float Right;

		// Token: 0x04001184 RID: 4484
		public float Bottom;
	}
}

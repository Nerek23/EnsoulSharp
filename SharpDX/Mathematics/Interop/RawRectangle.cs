using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x0200008D RID: 141
	[DebuggerDisplay("Left: {Left}, Top: {Top}, Right: {Right}, Bottom: {Bottom}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawRectangle
	{
		// Token: 0x0600030F RID: 783 RVA: 0x00009124 File Offset: 0x00007324
		public RawRectangle(int left, int top, int right, int bottom)
		{
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000310 RID: 784 RVA: 0x00009143 File Offset: 0x00007343
		public bool IsEmpty
		{
			get
			{
				return this.Left == 0 && this.Top == 0 && this.Right == 0 && this.Bottom == 0;
			}
		}

		// Token: 0x0400117D RID: 4477
		public int Left;

		// Token: 0x0400117E RID: 4478
		public int Top;

		// Token: 0x0400117F RID: 4479
		public int Right;

		// Token: 0x04001180 RID: 4480
		public int Bottom;
	}
}

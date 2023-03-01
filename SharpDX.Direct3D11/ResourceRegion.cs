using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000040 RID: 64
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ResourceRegion
	{
		// Token: 0x060002BF RID: 703 RVA: 0x0000B40F File Offset: 0x0000960F
		public ResourceRegion(int left, int top, int front, int right, int bottom, int back)
		{
			this.Left = left;
			this.Top = top;
			this.Front = front;
			this.Right = right;
			this.Bottom = bottom;
			this.Back = back;
		}

		// Token: 0x040000D6 RID: 214
		public int Left;

		// Token: 0x040000D7 RID: 215
		public int Top;

		// Token: 0x040000D8 RID: 216
		public int Front;

		// Token: 0x040000D9 RID: 217
		public int Right;

		// Token: 0x040000DA RID: 218
		public int Bottom;

		// Token: 0x040000DB RID: 219
		public int Back;
	}
}

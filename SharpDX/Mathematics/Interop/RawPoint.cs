using System;
using System.Diagnostics;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x0200008B RID: 139
	[DebuggerDisplay("X: {X}, Y: {Y}")]
	public struct RawPoint
	{
		// Token: 0x0600030D RID: 781 RVA: 0x000090F5 File Offset: 0x000072F5
		public RawPoint(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x04001177 RID: 4471
		public int X;

		// Token: 0x04001178 RID: 4472
		public int Y;
	}
}

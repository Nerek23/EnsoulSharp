using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000DC RID: 220
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TextRange
	{
		// Token: 0x060004C2 RID: 1218 RVA: 0x0000FD15 File Offset: 0x0000DF15
		public TextRange(int startPosition, int length)
		{
			this.StartPosition = startPosition;
			this.Length = length;
		}

		// Token: 0x0400026A RID: 618
		public int StartPosition;

		// Token: 0x0400026B RID: 619
		public int Length;
	}
}

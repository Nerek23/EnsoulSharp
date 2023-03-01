using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000165 RID: 357
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PanoseSymbol
	{
		// Token: 0x0400058F RID: 1423
		public byte FamilyKind;

		// Token: 0x04000590 RID: 1424
		public byte SymbolKind;

		// Token: 0x04000591 RID: 1425
		public byte Weight;

		// Token: 0x04000592 RID: 1426
		public byte Spacing;

		// Token: 0x04000593 RID: 1427
		public byte AspectRatioAndContrast;

		// Token: 0x04000594 RID: 1428
		public byte AspectRatio94;

		// Token: 0x04000595 RID: 1429
		public byte AspectRatio119;

		// Token: 0x04000596 RID: 1430
		public byte AspectRatio157;

		// Token: 0x04000597 RID: 1431
		public byte AspectRatio163;

		// Token: 0x04000598 RID: 1432
		public byte AspectRatio211;
	}
}

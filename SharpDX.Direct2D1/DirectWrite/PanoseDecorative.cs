using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000163 RID: 355
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PanoseDecorative
	{
		// Token: 0x0400057B RID: 1403
		public byte FamilyKind;

		// Token: 0x0400057C RID: 1404
		public byte DecorativeClass;

		// Token: 0x0400057D RID: 1405
		public byte Weight;

		// Token: 0x0400057E RID: 1406
		public byte Aspect;

		// Token: 0x0400057F RID: 1407
		public byte Contrast;

		// Token: 0x04000580 RID: 1408
		public byte SerifVariant;

		// Token: 0x04000581 RID: 1409
		public byte Fill;

		// Token: 0x04000582 RID: 1410
		public byte Lining;

		// Token: 0x04000583 RID: 1411
		public byte DecorativeTopology;

		// Token: 0x04000584 RID: 1412
		public byte CharacterRange;
	}
}

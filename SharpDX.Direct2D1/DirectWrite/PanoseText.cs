using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000166 RID: 358
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PanoseText
	{
		// Token: 0x04000599 RID: 1433
		public byte FamilyKind;

		// Token: 0x0400059A RID: 1434
		public byte SerifStyle;

		// Token: 0x0400059B RID: 1435
		public byte Weight;

		// Token: 0x0400059C RID: 1436
		public byte Proportion;

		// Token: 0x0400059D RID: 1437
		public byte Contrast;

		// Token: 0x0400059E RID: 1438
		public byte StrokeVariation;

		// Token: 0x0400059F RID: 1439
		public byte ArmStyle;

		// Token: 0x040005A0 RID: 1440
		public byte Letterform;

		// Token: 0x040005A1 RID: 1441
		public byte Midline;

		// Token: 0x040005A2 RID: 1442
		public byte XHeight;
	}
}

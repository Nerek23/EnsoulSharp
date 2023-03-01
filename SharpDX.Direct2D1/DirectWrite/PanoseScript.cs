using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000164 RID: 356
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PanoseScript
	{
		// Token: 0x04000585 RID: 1413
		public byte FamilyKind;

		// Token: 0x04000586 RID: 1414
		public byte ToolKind;

		// Token: 0x04000587 RID: 1415
		public byte Weight;

		// Token: 0x04000588 RID: 1416
		public byte Spacing;

		// Token: 0x04000589 RID: 1417
		public byte AspectRatio;

		// Token: 0x0400058A RID: 1418
		public byte Contrast;

		// Token: 0x0400058B RID: 1419
		public byte ScriptTopology;

		// Token: 0x0400058C RID: 1420
		public byte ScriptForm;

		// Token: 0x0400058D RID: 1421
		public byte Finials;

		// Token: 0x0400058E RID: 1422
		public byte XAscent;
	}
}

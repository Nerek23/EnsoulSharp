using System;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x0200006F RID: 111
	internal class OutRec
	{
		// Token: 0x0400025A RID: 602
		public int Idx;

		// Token: 0x0400025B RID: 603
		public bool IsHole;

		// Token: 0x0400025C RID: 604
		public bool IsOpen;

		// Token: 0x0400025D RID: 605
		public OutPt BottomPt;

		// Token: 0x0400025E RID: 606
		public OutPt Pts;

		// Token: 0x0400025F RID: 607
		public OutRec FirstLeft;

		// Token: 0x04000260 RID: 608
		public PolyNode PolyNode;
	}
}

using System;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000078 RID: 120
	internal class TEdge
	{
		// Token: 0x0400027B RID: 635
		public IntPoint Bot;

		// Token: 0x0400027C RID: 636
		public IntPoint Curr;

		// Token: 0x0400027D RID: 637
		public IntPoint Delta;

		// Token: 0x0400027E RID: 638
		public IntPoint Top;

		// Token: 0x0400027F RID: 639
		public int OutIdx;

		// Token: 0x04000280 RID: 640
		public int WindCnt;

		// Token: 0x04000281 RID: 641
		public int WindCnt2;

		// Token: 0x04000282 RID: 642
		public int WindDelta;

		// Token: 0x04000283 RID: 643
		public double Dx;

		// Token: 0x04000284 RID: 644
		public TEdge Next;

		// Token: 0x04000285 RID: 645
		public TEdge NextInAEL;

		// Token: 0x04000286 RID: 646
		public TEdge NextInLML;

		// Token: 0x04000287 RID: 647
		public TEdge NextInSEL;

		// Token: 0x04000288 RID: 648
		public TEdge Prev;

		// Token: 0x04000289 RID: 649
		public TEdge PrevInAEL;

		// Token: 0x0400028A RID: 650
		public TEdge PrevInSEL;

		// Token: 0x0400028B RID: 651
		public PolyType PolyTyp;

		// Token: 0x0400028C RID: 652
		public EdgeSide Side;
	}
}

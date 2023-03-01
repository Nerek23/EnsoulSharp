using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000069 RID: 105
	internal class MyIntersectNodeSort : IComparer<IntersectNode>
	{
		// Token: 0x0600045B RID: 1115 RVA: 0x000229B4 File Offset: 0x00020BB4
		public int Compare(IntersectNode node1, IntersectNode node2)
		{
			if (node1 == null || node2 == null)
			{
				return 0;
			}
			long num = node2.Pt.Y - node1.Pt.Y;
			if (num > 0L)
			{
				return 1;
			}
			if (num < 0L)
			{
				return -1;
			}
			return 0;
		}
	}
}

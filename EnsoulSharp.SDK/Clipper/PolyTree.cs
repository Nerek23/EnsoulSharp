using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000075 RID: 117
	public class PolyTree : PolyNode
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x00022F7C File Offset: 0x0002117C
		public int Total
		{
			get
			{
				int num = this.m_AllPolys.Count;
				if (num > 0 && this.m_Childs[0] != this.m_AllPolys[0])
				{
					num--;
				}
				return num;
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00022FB8 File Offset: 0x000211B8
		public void Clear()
		{
			for (int i = 0; i < this.m_AllPolys.Count; i++)
			{
				this.m_AllPolys[i] = null;
			}
			this.m_AllPolys.Clear();
			this.m_Childs.Clear();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00022FFE File Offset: 0x000211FE
		public PolyNode GetFirst()
		{
			if (this.m_Childs.Count <= 0)
			{
				return null;
			}
			return this.m_Childs[0];
		}

		// Token: 0x04000272 RID: 626
		internal List<PolyNode> m_AllPolys = new List<PolyNode>();
	}
}

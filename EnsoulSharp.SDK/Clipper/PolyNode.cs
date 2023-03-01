using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000074 RID: 116
	public class PolyNode
	{
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x00022E4A File Offset: 0x0002104A
		public int ChildCount
		{
			get
			{
				return this.m_Childs.Count;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x00022E57 File Offset: 0x00021057
		public List<IntPoint> Contour
		{
			get
			{
				return this.m_polygon;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x00022E5F File Offset: 0x0002105F
		public List<PolyNode> Childs
		{
			get
			{
				return this.m_Childs;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x00022E67 File Offset: 0x00021067
		public PolyNode Parent
		{
			get
			{
				return this.m_Parent;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00022E6F File Offset: 0x0002106F
		public bool IsHole
		{
			get
			{
				return this.IsHoleNode();
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00022E77 File Offset: 0x00021077
		// (set) Token: 0x06000484 RID: 1156 RVA: 0x00022E7F File Offset: 0x0002107F
		public bool IsOpen { get; set; }

		// Token: 0x06000485 RID: 1157 RVA: 0x00022E88 File Offset: 0x00021088
		private bool IsHoleNode()
		{
			bool flag = true;
			for (PolyNode parent = this.m_Parent; parent != null; parent = parent.m_Parent)
			{
				flag = !flag;
			}
			return flag;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00022EB0 File Offset: 0x000210B0
		internal void AddChild(PolyNode Child)
		{
			int count = this.m_Childs.Count;
			this.m_Childs.Add(Child);
			Child.m_Parent = this;
			Child.m_Index = count;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00022EE3 File Offset: 0x000210E3
		public PolyNode GetNext()
		{
			if (this.m_Childs.Count <= 0)
			{
				return this.GetNextSiblingUp();
			}
			return this.m_Childs[0];
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00022F08 File Offset: 0x00021108
		internal PolyNode GetNextSiblingUp()
		{
			if (this.m_Parent == null)
			{
				return null;
			}
			if (this.m_Index != this.m_Parent.m_Childs.Count - 1)
			{
				return this.m_Parent.m_Childs[this.m_Index + 1];
			}
			return this.m_Parent.GetNextSiblingUp();
		}

		// Token: 0x0400026B RID: 619
		internal List<PolyNode> m_Childs = new List<PolyNode>();

		// Token: 0x0400026C RID: 620
		internal EndType m_endtype;

		// Token: 0x0400026D RID: 621
		internal int m_Index;

		// Token: 0x0400026E RID: 622
		internal JoinType m_jointype;

		// Token: 0x0400026F RID: 623
		internal PolyNode m_Parent;

		// Token: 0x04000270 RID: 624
		internal List<IntPoint> m_polygon = new List<IntPoint>();
	}
}

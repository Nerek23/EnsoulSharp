using System;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000073 RID: 115
	public struct IntRect
	{
		// Token: 0x0600047C RID: 1148 RVA: 0x00022DF9 File Offset: 0x00020FF9
		public IntRect(long l, long t, long r, long b)
		{
			this.left = l;
			this.top = t;
			this.right = r;
			this.bottom = b;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00022E18 File Offset: 0x00021018
		public IntRect(IntRect ir)
		{
			this.left = ir.left;
			this.top = ir.top;
			this.right = ir.right;
			this.bottom = ir.bottom;
		}

		// Token: 0x04000267 RID: 615
		public long left;

		// Token: 0x04000268 RID: 616
		public long top;

		// Token: 0x04000269 RID: 617
		public long right;

		// Token: 0x0400026A RID: 618
		public long bottom;
	}
}

using System;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000070 RID: 112
	public struct DoublePoint
	{
		// Token: 0x06000463 RID: 1123 RVA: 0x00022A28 File Offset: 0x00020C28
		public DoublePoint(double x = 0.0, double y = 0.0)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00022A38 File Offset: 0x00020C38
		public DoublePoint(DoublePoint dp)
		{
			this.X = dp.X;
			this.Y = dp.Y;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00022A52 File Offset: 0x00020C52
		public DoublePoint(IntPoint ip)
		{
			this.X = (double)ip.X;
			this.Y = (double)ip.Y;
		}

		// Token: 0x04000261 RID: 609
		public double X;

		// Token: 0x04000262 RID: 610
		public double Y;
	}
}

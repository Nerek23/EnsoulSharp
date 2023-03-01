using System;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000072 RID: 114
	public struct IntPoint
	{
		// Token: 0x06000475 RID: 1141 RVA: 0x00022D25 File Offset: 0x00020F25
		public IntPoint(long X, long Y)
		{
			this.X = X;
			this.Y = Y;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00022D35 File Offset: 0x00020F35
		public IntPoint(double x, double y)
		{
			this.X = (long)x;
			this.Y = (long)y;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00022D47 File Offset: 0x00020F47
		public IntPoint(IntPoint pt)
		{
			this.X = pt.X;
			this.Y = pt.Y;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00022D61 File Offset: 0x00020F61
		public static bool operator ==(IntPoint a, IntPoint b)
		{
			return a.X == b.X && a.Y == b.Y;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00022D81 File Offset: 0x00020F81
		public static bool operator !=(IntPoint a, IntPoint b)
		{
			return a.X != b.X || a.Y != b.Y;
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00022DA4 File Offset: 0x00020FA4
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is IntPoint)
			{
				IntPoint intPoint = (IntPoint)obj;
				return this.X == intPoint.X && this.Y == intPoint.Y;
			}
			return false;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00022DE7 File Offset: 0x00020FE7
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x04000265 RID: 613
		public long X;

		// Token: 0x04000266 RID: 614
		public long Y;
	}
}

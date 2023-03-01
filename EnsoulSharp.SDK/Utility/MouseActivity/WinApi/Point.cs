using System;

namespace EnsoulSharp.SDK.Utility.MouseActivity.WinApi
{
	// Token: 0x02000090 RID: 144
	internal struct Point
	{
		// Token: 0x0600052E RID: 1326 RVA: 0x00025521 File Offset: 0x00023721
		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00025531 File Offset: 0x00023731
		public static bool operator ==(Point a, Point b)
		{
			return a.X == b.X && a.Y == b.Y;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00025551 File Offset: 0x00023751
		public static bool operator !=(Point a, Point b)
		{
			return !(a == b);
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0002555D File Offset: 0x0002375D
		public bool Equals(Point other)
		{
			return other.X == this.X && other.Y == this.Y;
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0002557D File Offset: 0x0002377D
		public override bool Equals(object obj)
		{
			return obj != null && !(obj.GetType() != typeof(Point)) && this.Equals((Point)obj);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x000255A9 File Offset: 0x000237A9
		public override int GetHashCode()
		{
			return this.X * 397 ^ this.Y;
		}

		// Token: 0x040002E9 RID: 745
		public int X;

		// Token: 0x040002EA RID: 746
		public int Y;
	}
}

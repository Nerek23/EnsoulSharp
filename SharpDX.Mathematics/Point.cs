using System;
using System.Runtime.CompilerServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x0200001F RID: 31
	public struct Point : IEquatable<Point>
	{
		// Token: 0x06000502 RID: 1282 RVA: 0x00019DD6 File Offset: 0x00017FD6
		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00019DE6 File Offset: 0x00017FE6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Point other)
		{
			return other.X == this.X && other.Y == this.Y;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00019E06 File Offset: 0x00018006
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Point other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00019E10 File Offset: 0x00018010
		public override bool Equals(object obj)
		{
			if (!(obj is Point))
			{
				return false;
			}
			Point point = (Point)obj;
			return this.Equals(ref point);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00019E36 File Offset: 0x00018036
		public override int GetHashCode()
		{
			return this.X * 397 ^ this.Y;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00019E4B File Offset: 0x0001804B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Point left, Point right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00019E56 File Offset: 0x00018056
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Point left, Point right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00019E64 File Offset: 0x00018064
		public override string ToString()
		{
			return string.Format("({0},{1})", this.X, this.Y);
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00019E86 File Offset: 0x00018086
		public static explicit operator Point(Vector2 value)
		{
			return new Point((int)value.X, (int)value.Y);
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00019E9B File Offset: 0x0001809B
		public static implicit operator Vector2(Point value)
		{
			return new Vector2((float)value.X, (float)value.Y);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00019EB0 File Offset: 0x000180B0
		public unsafe static implicit operator RawPoint(Point value)
		{
			return *(RawPoint*)(&value);
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00019EBA File Offset: 0x000180BA
		public unsafe static implicit operator Point(RawPoint value)
		{
			return *(Point*)(&value);
		}

		// Token: 0x0400014E RID: 334
		public static readonly Point Zero = new Point(0, 0);

		// Token: 0x0400014F RID: 335
		public int X;

		// Token: 0x04000150 RID: 336
		public int Y;
	}
}

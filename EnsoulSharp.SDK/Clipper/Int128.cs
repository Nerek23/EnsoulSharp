using System;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000071 RID: 113
	internal struct Int128
	{
		// Token: 0x06000466 RID: 1126 RVA: 0x00022A6E File Offset: 0x00020C6E
		public Int128(long _lo)
		{
			this.lo = (ulong)_lo;
			if (_lo < 0L)
			{
				this.hi = -1L;
				return;
			}
			this.hi = 0L;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00022A8D File Offset: 0x00020C8D
		public Int128(long _hi, ulong _lo)
		{
			this.lo = _lo;
			this.hi = _hi;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00022A9D File Offset: 0x00020C9D
		public Int128(Int128 val)
		{
			this.hi = val.hi;
			this.lo = val.lo;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00022AB7 File Offset: 0x00020CB7
		public bool IsNegative()
		{
			return this.hi < 0L;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00022AC3 File Offset: 0x00020CC3
		public static bool operator ==(Int128 val1, Int128 val2)
		{
			return val1 == val2 || (val1.hi == val2.hi && val1.lo == val2.lo);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00022AF3 File Offset: 0x00020CF3
		public static bool operator !=(Int128 val1, Int128 val2)
		{
			return !(val1 == val2);
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00022B00 File Offset: 0x00020D00
		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is Int128))
			{
				return false;
			}
			Int128 @int = (Int128)obj;
			return @int.hi == this.hi && @int.lo == this.lo;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00022B3F File Offset: 0x00020D3F
		public override int GetHashCode()
		{
			return this.hi.GetHashCode() ^ this.lo.GetHashCode();
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00022B58 File Offset: 0x00020D58
		public static bool operator >(Int128 val1, Int128 val2)
		{
			if (val1.hi != val2.hi)
			{
				return val1.hi > val2.hi;
			}
			return val1.lo > val2.lo;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00022B85 File Offset: 0x00020D85
		public static bool operator <(Int128 val1, Int128 val2)
		{
			if (val1.hi != val2.hi)
			{
				return val1.hi < val2.hi;
			}
			return val1.lo < val2.lo;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00022BB2 File Offset: 0x00020DB2
		public static Int128 operator +(Int128 lhs, Int128 rhs)
		{
			lhs.hi += rhs.hi;
			lhs.lo += rhs.lo;
			if (lhs.lo < rhs.lo)
			{
				lhs.hi += 1L;
			}
			return lhs;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00022BF2 File Offset: 0x00020DF2
		public static Int128 operator -(Int128 lhs, Int128 rhs)
		{
			return lhs + -rhs;
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00022C00 File Offset: 0x00020E00
		public static Int128 operator -(Int128 val)
		{
			if (val.lo != 0UL)
			{
				return new Int128(~val.hi, ~val.lo + 1UL);
			}
			return new Int128(-val.hi, 0UL);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00022C30 File Offset: 0x00020E30
		public static explicit operator double(Int128 val)
		{
			if (val.hi >= 0L)
			{
				return val.lo + (double)val.hi * 1.8446744073709552E+19;
			}
			if (val.lo == 0UL)
			{
				return (double)val.hi * 1.8446744073709552E+19;
			}
			return -(~val.lo + (double)(~(double)val.hi) * 1.8446744073709552E+19);
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00022C9C File Offset: 0x00020E9C
		public static Int128 Int128Mul(long lhs, long rhs)
		{
			bool flag = lhs < 0L != rhs < 0L;
			if (lhs < 0L)
			{
				lhs = -lhs;
			}
			if (rhs < 0L)
			{
				rhs = -rhs;
			}
			ulong num = (ulong)lhs >> 32;
			ulong num2 = (ulong)(lhs & (long)((ulong)-1));
			ulong num3 = (ulong)rhs >> 32;
			ulong num4 = (ulong)(rhs & (long)((ulong)-1));
			ulong num5 = num * num3;
			ulong num6 = num2 * num4;
			ulong num7 = num * num4 + num2 * num3;
			long num8 = (long)(num5 + (num7 >> 32));
			ulong num9 = (num7 << 32) + num6;
			if (num9 < num6)
			{
				num8 += 1L;
			}
			Int128 @int = new Int128(num8, num9);
			if (!flag)
			{
				return @int;
			}
			return -@int;
		}

		// Token: 0x04000263 RID: 611
		private long hi;

		// Token: 0x04000264 RID: 612
		private ulong lo;
	}
}

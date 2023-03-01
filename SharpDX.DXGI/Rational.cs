using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000021 RID: 33
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Rational : IEquatable<Rational>
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x000049D8 File Offset: 0x00002BD8
		public Rational(int numerator, int denominator)
		{
			this.Numerator = numerator;
			this.Denominator = denominator;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000049E8 File Offset: 0x00002BE8
		public bool Equals(Rational other)
		{
			return this.Numerator == other.Numerator && this.Denominator == other.Denominator;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004A08 File Offset: 0x00002C08
		public override bool Equals(object obj)
		{
			return obj != null && obj is Rational && this.Equals((Rational)obj);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00004A25 File Offset: 0x00002C25
		public override int GetHashCode()
		{
			return this.Numerator * 397 ^ this.Denominator;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00004A3A File Offset: 0x00002C3A
		public static bool operator ==(Rational left, Rational right)
		{
			return left.Equals(right);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00004A44 File Offset: 0x00002C44
		public static bool operator !=(Rational left, Rational right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004A51 File Offset: 0x00002C51
		public override string ToString()
		{
			return string.Format("{0}/{1}", this.Numerator, this.Denominator);
		}

		// Token: 0x0400002A RID: 42
		public static readonly Rational Empty;

		// Token: 0x0400002B RID: 43
		public int Numerator;

		// Token: 0x0400002C RID: 44
		public int Denominator;
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x0200007E RID: 126
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct RawBool : IEquatable<RawBool>
	{
		// Token: 0x060002FC RID: 764 RVA: 0x00008F84 File Offset: 0x00007184
		public RawBool(bool boolValue)
		{
			this.boolValue = (boolValue ? 1 : 0);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00008F93 File Offset: 0x00007193
		public bool Equals(RawBool other)
		{
			return this.boolValue == other.boolValue;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00008FA3 File Offset: 0x000071A3
		public override bool Equals(object obj)
		{
			return obj != null && obj is RawBool && this.Equals((RawBool)obj);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00008FC0 File Offset: 0x000071C0
		public override int GetHashCode()
		{
			return this.boolValue;
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00008FC8 File Offset: 0x000071C8
		public static bool operator ==(RawBool left, RawBool right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00008FD2 File Offset: 0x000071D2
		public static bool operator !=(RawBool left, RawBool right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00008FDF File Offset: 0x000071DF
		public static implicit operator bool(RawBool booleanValue)
		{
			return booleanValue.boolValue != 0;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00008FEA File Offset: 0x000071EA
		public static implicit operator RawBool(bool boolValue)
		{
			return new RawBool(boolValue);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00008FF2 File Offset: 0x000071F2
		public override string ToString()
		{
			return string.Format("{0}", this.boolValue != 0);
		}

		// Token: 0x04001124 RID: 4388
		private readonly int boolValue;
	}
}

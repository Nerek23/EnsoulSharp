using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000012 RID: 18
	public struct Half3 : IEquatable<Half3>
	{
		// Token: 0x0600024A RID: 586 RVA: 0x0000AFC1 File Offset: 0x000091C1
		public Half3(Half x, Half y, Half z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000AFD8 File Offset: 0x000091D8
		public Half3(float x, float y, float z)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
			this.Z = new Half(z);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000AFFE File Offset: 0x000091FE
		public Half3(ushort x, ushort y, ushort z)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
			this.Z = new Half(z);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000B024 File Offset: 0x00009224
		public Half3(Half value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000B03B File Offset: 0x0000923B
		public static implicit operator Half3(Vector3 value)
		{
			return new Half3(value.X, value.Y, value.Z);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000B054 File Offset: 0x00009254
		public static implicit operator Vector3(Half3 value)
		{
			return new Vector3(value.X, value.Y, value.Z);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000B07C File Offset: 0x0000927C
		public static explicit operator Half3(Vector2 value)
		{
			return new Half3(value.X, value.Y, 0f);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000B094 File Offset: 0x00009294
		public static explicit operator Vector2(Half3 value)
		{
			return new Vector2(value.X, value.Y);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000B0B1 File Offset: 0x000092B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Half3 left, Half3 right)
		{
			return Half3.Equals(ref left, ref right);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000B0BC File Offset: 0x000092BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MarshalAs(UnmanagedType.U1)]
		public static bool operator !=(Half3 left, Half3 right)
		{
			return !Half3.Equals(ref left, ref right);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000B0CC File Offset: 0x000092CC
		public override int GetHashCode()
		{
			return (this.X.GetHashCode() * 397 ^ this.Y.GetHashCode()) * 397 ^ this.Z.GetHashCode();
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000B11A File Offset: 0x0000931A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Equals(ref Half3 value1, ref Half3 value2)
		{
			return value1.X == value2.X && value1.Y == value2.Y && value1.Z == value2.Z;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000B11A File Offset: 0x0000931A
		public bool Equals(Half3 other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000B155 File Offset: 0x00009355
		public override bool Equals(object obj)
		{
			return obj is Half3 && this.Equals((Half3)obj);
		}

		// Token: 0x040000E6 RID: 230
		public Half X;

		// Token: 0x040000E7 RID: 231
		public Half Y;

		// Token: 0x040000E8 RID: 232
		public Half Z;
	}
}

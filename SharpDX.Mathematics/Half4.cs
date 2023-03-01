using System;
using System.Runtime.CompilerServices;

namespace SharpDX
{
	// Token: 0x02000013 RID: 19
	public struct Half4 : IEquatable<Half4>
	{
		// Token: 0x06000258 RID: 600 RVA: 0x0000B16D File Offset: 0x0000936D
		public Half4(Half x, Half y, Half z, Half w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000B18C File Offset: 0x0000938C
		public Half4(float x, float y, float z, float w)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
			this.Z = new Half(z);
			this.W = new Half(w);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000B1BF File Offset: 0x000093BF
		public Half4(ushort x, ushort y, ushort z, ushort w)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
			this.Z = new Half(z);
			this.W = new Half(w);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000B1F2 File Offset: 0x000093F2
		public Half4(Half value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
			this.W = value;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000B210 File Offset: 0x00009410
		public static implicit operator Half4(Vector4 value)
		{
			return new Half4(value.X, value.Y, value.Z, value.W);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000B22F File Offset: 0x0000942F
		public static implicit operator Vector4(Half4 value)
		{
			return new Vector4(value.X, value.Y, value.Z, value.W);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000B262 File Offset: 0x00009462
		public static explicit operator Half4(Vector3 value)
		{
			return new Half4(value.X, value.Y, value.Z, 0f);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000B280 File Offset: 0x00009480
		public static explicit operator Vector3(Half4 value)
		{
			return new Vector3(value.X, value.Y, value.Z);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000B2A8 File Offset: 0x000094A8
		public static explicit operator Half4(Vector2 value)
		{
			return new Half4(value.X, value.Y, 0f, 0f);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000B2C5 File Offset: 0x000094C5
		public static explicit operator Vector2(Half4 value)
		{
			return new Vector2(value.X, value.Y);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000B2E2 File Offset: 0x000094E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Half4 left, Half4 right)
		{
			return Half4.Equals(ref left, ref right);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000B2ED File Offset: 0x000094ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Half4 left, Half4 right)
		{
			return !Half4.Equals(ref left, ref right);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000B2FC File Offset: 0x000094FC
		public override int GetHashCode()
		{
			return ((this.X.GetHashCode() * 397 ^ this.Y.GetHashCode()) * 397 ^ this.Z.GetHashCode()) * 397 ^ this.W.GetHashCode();
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000B364 File Offset: 0x00009564
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Equals(ref Half4 value1, ref Half4 value2)
		{
			return value1.X == value2.X && value1.Y == value2.Y && value1.Z == value2.Z && value1.W == value2.W;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public bool Equals(Half4 other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z && this.W == other.W;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000B41B File Offset: 0x0000961B
		public override bool Equals(object obj)
		{
			return obj is Half4 && this.Equals((Half4)obj);
		}

		// Token: 0x040000E9 RID: 233
		public Half X;

		// Token: 0x040000EA RID: 234
		public Half Y;

		// Token: 0x040000EB RID: 235
		public Half Z;

		// Token: 0x040000EC RID: 236
		public Half W;
	}
}

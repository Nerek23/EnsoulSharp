using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000011 RID: 17
	public struct Half2 : IEquatable<Half2>
	{
		// Token: 0x0600023D RID: 573 RVA: 0x0000AE9F File Offset: 0x0000909F
		public Half2(Half x, Half y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000AEAF File Offset: 0x000090AF
		public Half2(float x, float y)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000AEC9 File Offset: 0x000090C9
		public Half2(ushort x, ushort y)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000AEE3 File Offset: 0x000090E3
		public Half2(Half value)
		{
			this.X = value;
			this.Y = value;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000AEF3 File Offset: 0x000090F3
		public Half2(float value)
		{
			this.X = new Half(value);
			this.Y = new Half(value);
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000AF0D File Offset: 0x0000910D
		public static implicit operator Half2(Vector2 value)
		{
			return new Half2(value.X, value.Y);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000AF20 File Offset: 0x00009120
		public static implicit operator Vector2(Half2 value)
		{
			return new Vector2(value.X, value.Y);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000AF3D File Offset: 0x0000913D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Half2 left, Half2 right)
		{
			return Half2.Equals(ref left, ref right);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000AF48 File Offset: 0x00009148
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MarshalAs(UnmanagedType.U1)]
		public static bool operator !=(Half2 left, Half2 right)
		{
			return !Half2.Equals(ref left, ref right);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000AF56 File Offset: 0x00009156
		public override int GetHashCode()
		{
			return this.X.GetHashCode() * 397 ^ this.Y.GetHashCode();
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000AF81 File Offset: 0x00009181
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Equals(ref Half2 value1, ref Half2 value2)
		{
			return value1.X == value2.X && value1.Y == value2.Y;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000AF81 File Offset: 0x00009181
		public bool Equals(Half2 other)
		{
			return this.X == other.X && this.Y == other.Y;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000AFA9 File Offset: 0x000091A9
		public override bool Equals(object obj)
		{
			return obj is Half2 && this.Equals((Half2)obj);
		}

		// Token: 0x040000E4 RID: 228
		public Half X;

		// Token: 0x040000E5 RID: 229
		public Half Y;
	}
}

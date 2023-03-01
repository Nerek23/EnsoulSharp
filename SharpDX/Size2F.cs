using System;

namespace SharpDX
{
	// Token: 0x02000031 RID: 49
	public struct Size2F : IEquatable<Size2F>
	{
		// Token: 0x0600017D RID: 381 RVA: 0x00005063 File Offset: 0x00003263
		public Size2F(float width, float height)
		{
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00005073 File Offset: 0x00003273
		public bool Equals(Size2F other)
		{
			return other.Width == this.Width && other.Height == this.Height;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00005093 File Offset: 0x00003293
		public override bool Equals(object obj)
		{
			return obj is Size2F && this.Equals((Size2F)obj);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000050AB File Offset: 0x000032AB
		public override int GetHashCode()
		{
			return this.Width.GetHashCode() * 397 ^ this.Height.GetHashCode();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000050CA File Offset: 0x000032CA
		public static bool operator ==(Size2F left, Size2F right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000050D4 File Offset: 0x000032D4
		public static bool operator !=(Size2F left, Size2F right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000050E1 File Offset: 0x000032E1
		public override string ToString()
		{
			return string.Format("({0},{1})", this.Width, this.Height);
		}

		// Token: 0x0400005F RID: 95
		public static readonly Size2F Zero = new Size2F(0f, 0f);

		// Token: 0x04000060 RID: 96
		public static readonly Size2F Empty = Size2F.Zero;

		// Token: 0x04000061 RID: 97
		public float Width;

		// Token: 0x04000062 RID: 98
		public float Height;
	}
}

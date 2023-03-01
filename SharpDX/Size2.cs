using System;

namespace SharpDX
{
	// Token: 0x02000030 RID: 48
	public struct Size2 : IEquatable<Size2>
	{
		// Token: 0x06000175 RID: 373 RVA: 0x00004FB5 File Offset: 0x000031B5
		public Size2(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00004FC5 File Offset: 0x000031C5
		public bool Equals(Size2 other)
		{
			return other.Width == this.Width && other.Height == this.Height;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00004FE5 File Offset: 0x000031E5
		public override bool Equals(object obj)
		{
			return obj is Size2 && this.Equals((Size2)obj);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00004FFD File Offset: 0x000031FD
		public override int GetHashCode()
		{
			return this.Width * 397 ^ this.Height;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00005012 File Offset: 0x00003212
		public static bool operator ==(Size2 left, Size2 right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000501C File Offset: 0x0000321C
		public static bool operator !=(Size2 left, Size2 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00005029 File Offset: 0x00003229
		public override string ToString()
		{
			return string.Format("({0},{1})", this.Width, this.Height);
		}

		// Token: 0x0400005B RID: 91
		public static readonly Size2 Zero = new Size2(0, 0);

		// Token: 0x0400005C RID: 92
		public static readonly Size2 Empty = Size2.Zero;

		// Token: 0x0400005D RID: 93
		public int Width;

		// Token: 0x0400005E RID: 94
		public int Height;
	}
}

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000028 RID: 40
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Viewport : IEquatable<Viewport>
	{
		// Token: 0x0600071A RID: 1818 RVA: 0x00021534 File Offset: 0x0001F734
		public Viewport(int x, int y, int width, int height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
			this.MinDepth = 0f;
			this.MaxDepth = 1f;
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00021569 File Offset: 0x0001F769
		public Viewport(int x, int y, int width, int height, float minDepth, float maxDepth)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
			this.MinDepth = minDepth;
			this.MaxDepth = maxDepth;
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00021598 File Offset: 0x0001F798
		public Viewport(Rectangle bounds)
		{
			this.X = bounds.X;
			this.Y = bounds.Y;
			this.Width = bounds.Width;
			this.Height = bounds.Height;
			this.MinDepth = 0f;
			this.MaxDepth = 1f;
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x000215EF File Offset: 0x0001F7EF
		// (set) Token: 0x0600071E RID: 1822 RVA: 0x0002160E File Offset: 0x0001F80E
		public Rectangle Bounds
		{
			get
			{
				return new Rectangle(this.X, this.Y, this.Width, this.Height);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Width = value.Width;
				this.Height = value.Height;
			}
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00021644 File Offset: 0x0001F844
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Viewport other)
		{
			return this.X == other.X && this.Y == other.Y && this.Width == other.Width && this.Height == other.Height && MathUtil.NearEqual(this.MinDepth, other.MinDepth) && MathUtil.NearEqual(this.MaxDepth, other.MaxDepth);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x000216AF File Offset: 0x0001F8AF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Viewport other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x000216BC File Offset: 0x0001F8BC
		public override bool Equals(object obj)
		{
			if (!(obj is Viewport))
			{
				return false;
			}
			Viewport viewport = (Viewport)obj;
			return this.Equals(ref viewport);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x000216E4 File Offset: 0x0001F8E4
		public override int GetHashCode()
		{
			return ((((this.X * 397 ^ this.Y) * 397 ^ this.Width) * 397 ^ this.Height) * 397 ^ this.MinDepth.GetHashCode()) * 397 ^ this.MaxDepth.GetHashCode();
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00021742 File Offset: 0x0001F942
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Viewport left, Viewport right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0002174D File Offset: 0x0001F94D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Viewport left, Viewport right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0002175C File Offset: 0x0001F95C
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{{X:{0} Y:{1} Width:{2} Height:{3} MinDepth:{4} MaxDepth:{5}}}", new object[]
			{
				this.X,
				this.Y,
				this.Width,
				this.Height,
				this.MinDepth,
				this.MaxDepth
			});
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x000217D4 File Offset: 0x0001F9D4
		public Vector3 Project(Vector3 source, Matrix projection, Matrix view, Matrix world)
		{
			Matrix matrix;
			Matrix.Multiply(ref world, ref view, out matrix);
			Matrix.Multiply(ref matrix, ref projection, out matrix);
			Vector3 result;
			this.Project(ref source, ref matrix, out result);
			return result;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00021804 File Offset: 0x0001FA04
		public void Project(ref Vector3 source, ref Matrix matrix, out Vector3 vector)
		{
			Vector3.Transform(ref source, ref matrix, out vector);
			float num = source.X * matrix.M14 + source.Y * matrix.M24 + source.Z * matrix.M34 + matrix.M44;
			if (!MathUtil.IsOne(num))
			{
				vector /= num;
			}
			vector.X = (vector.X + 1f) * 0.5f * (float)this.Width + (float)this.X;
			vector.Y = (-vector.Y + 1f) * 0.5f * (float)this.Height + (float)this.Y;
			vector.Z = vector.Z * (this.MaxDepth - this.MinDepth) + this.MinDepth;
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x000218D8 File Offset: 0x0001FAD8
		public Vector3 Unproject(Vector3 source, Matrix projection, Matrix view, Matrix world)
		{
			Matrix matrix;
			Matrix.Multiply(ref world, ref view, out matrix);
			Matrix.Multiply(ref matrix, ref projection, out matrix);
			Matrix.Invert(ref matrix, out matrix);
			Vector3 result;
			this.Unproject(ref source, ref matrix, out result);
			return result;
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00021914 File Offset: 0x0001FB14
		public void Unproject(ref Vector3 source, ref Matrix matrix, out Vector3 vector)
		{
			vector.X = (source.X - (float)this.X) / (float)this.Width * 2f - 1f;
			vector.Y = -((source.Y - (float)this.Y) / (float)this.Height * 2f - 1f);
			vector.Z = (source.Z - this.MinDepth) / (this.MaxDepth - this.MinDepth);
			float num = vector.X * matrix.M14 + vector.Y * matrix.M24 + vector.Z * matrix.M34 + matrix.M44;
			Vector3.Transform(ref vector, ref matrix, out vector);
			if (!MathUtil.IsOne(num))
			{
				vector /= num;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x000219E6 File Offset: 0x0001FBE6
		public float AspectRatio
		{
			get
			{
				if (this.Height != 0)
				{
					return (float)this.Width / (float)this.Height;
				}
				return 0f;
			}
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00021A05 File Offset: 0x0001FC05
		public unsafe static implicit operator RawViewport(Viewport value)
		{
			return *(RawViewport*)(&value);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00021A10 File Offset: 0x0001FC10
		public unsafe static implicit operator RawViewportF(Viewport value)
		{
			ViewportF viewportF = value;
			return *(RawViewportF*)(&viewportF);
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00021A2C File Offset: 0x0001FC2C
		public unsafe static implicit operator Viewport(RawViewport value)
		{
			return *(Viewport*)(&value);
		}

		// Token: 0x04000189 RID: 393
		public int X;

		// Token: 0x0400018A RID: 394
		public int Y;

		// Token: 0x0400018B RID: 395
		public int Width;

		// Token: 0x0400018C RID: 396
		public int Height;

		// Token: 0x0400018D RID: 397
		public float MinDepth;

		// Token: 0x0400018E RID: 398
		public float MaxDepth;
	}
}

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000029 RID: 41
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct ViewportF : IEquatable<ViewportF>
	{
		// Token: 0x0600072E RID: 1838 RVA: 0x00021A36 File Offset: 0x0001FC36
		public ViewportF(float x, float y, float width, float height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
			this.MinDepth = 0f;
			this.MaxDepth = 1f;
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00021A6B File Offset: 0x0001FC6B
		public ViewportF(float x, float y, float width, float height, float minDepth, float maxDepth)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
			this.MinDepth = minDepth;
			this.MaxDepth = maxDepth;
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00021A9C File Offset: 0x0001FC9C
		public ViewportF(RectangleF bounds)
		{
			this.X = bounds.X;
			this.Y = bounds.Y;
			this.Width = bounds.Width;
			this.Height = bounds.Height;
			this.MinDepth = 0f;
			this.MaxDepth = 1f;
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x00021AF3 File Offset: 0x0001FCF3
		// (set) Token: 0x06000732 RID: 1842 RVA: 0x00021B12 File Offset: 0x0001FD12
		public RectangleF Bounds
		{
			get
			{
				return new RectangleF(this.X, this.Y, this.Width, this.Height);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Width = value.Width;
				this.Height = value.Height;
			}
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x00021B48 File Offset: 0x0001FD48
		public bool Equals(ref ViewportF other)
		{
			return MathUtil.NearEqual(this.X, other.X) && MathUtil.NearEqual(this.Y, other.Y) && MathUtil.NearEqual(this.Width, other.Width) && MathUtil.NearEqual(this.Height, other.Height) && MathUtil.NearEqual(this.MinDepth, other.MinDepth) && MathUtil.NearEqual(this.MaxDepth, other.MaxDepth);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00021BC7 File Offset: 0x0001FDC7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ViewportF other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00021BD4 File Offset: 0x0001FDD4
		public override bool Equals(object obj)
		{
			if (!(obj is ViewportF))
			{
				return false;
			}
			ViewportF viewportF = (ViewportF)obj;
			return this.Equals(ref viewportF);
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00021BFC File Offset: 0x0001FDFC
		public override int GetHashCode()
		{
			return ((((this.X.GetHashCode() * 397 ^ this.Y.GetHashCode()) * 397 ^ this.Width.GetHashCode()) * 397 ^ this.Height.GetHashCode()) * 397 ^ this.MinDepth.GetHashCode()) * 397 ^ this.MaxDepth.GetHashCode();
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00021C6E File Offset: 0x0001FE6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(ViewportF left, ViewportF right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00021C79 File Offset: 0x0001FE79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(ViewportF left, ViewportF right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00021C88 File Offset: 0x0001FE88
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

		// Token: 0x0600073A RID: 1850 RVA: 0x00021D00 File Offset: 0x0001FF00
		public Vector3 Project(Vector3 source, Matrix projection, Matrix view, Matrix world)
		{
			Matrix matrix;
			Matrix.Multiply(ref world, ref view, out matrix);
			Matrix.Multiply(ref matrix, ref projection, out matrix);
			Vector3 result;
			this.Project(ref source, ref matrix, out result);
			return result;
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00021D30 File Offset: 0x0001FF30
		public void Project(ref Vector3 source, ref Matrix matrix, out Vector3 vector)
		{
			Vector3.Transform(ref source, ref matrix, out vector);
			float num = source.X * matrix.M14 + source.Y * matrix.M24 + source.Z * matrix.M34 + matrix.M44;
			if (!MathUtil.IsOne(num))
			{
				vector /= num;
			}
			vector.X = (vector.X + 1f) * 0.5f * this.Width + this.X;
			vector.Y = (-vector.Y + 1f) * 0.5f * this.Height + this.Y;
			vector.Z = vector.Z * (this.MaxDepth - this.MinDepth) + this.MinDepth;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00021E00 File Offset: 0x00020000
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

		// Token: 0x0600073D RID: 1853 RVA: 0x00021E3C File Offset: 0x0002003C
		public void Unproject(ref Vector3 source, ref Matrix matrix, out Vector3 vector)
		{
			vector.X = (source.X - this.X) / this.Width * 2f - 1f;
			vector.Y = -((source.Y - this.Y) / this.Height * 2f - 1f);
			vector.Z = (source.Z - this.MinDepth) / (this.MaxDepth - this.MinDepth);
			float num = vector.X * matrix.M14 + vector.Y * matrix.M24 + vector.Z * matrix.M34 + matrix.M44;
			Vector3.Transform(ref vector, ref matrix, out vector);
			if (!MathUtil.IsOne(num))
			{
				vector /= num;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x00021F0A File Offset: 0x0002010A
		public float AspectRatio
		{
			get
			{
				if (!MathUtil.IsZero(this.Height))
				{
					return this.Width / this.Height;
				}
				return 0f;
			}
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00021F2C File Offset: 0x0002012C
		public static implicit operator ViewportF(Viewport value)
		{
			return new ViewportF((float)value.X, (float)value.Y, (float)value.Width, (float)value.Height, value.MinDepth, value.MaxDepth);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00021F5B File Offset: 0x0002015B
		public unsafe static implicit operator RawViewportF(ViewportF value)
		{
			return *(RawViewportF*)(&value);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00021F65 File Offset: 0x00020165
		public unsafe static implicit operator ViewportF(RawViewportF value)
		{
			return *(ViewportF*)(&value);
		}

		// Token: 0x0400018F RID: 399
		public float X;

		// Token: 0x04000190 RID: 400
		public float Y;

		// Token: 0x04000191 RID: 401
		public float Width;

		// Token: 0x04000192 RID: 402
		public float Height;

		// Token: 0x04000193 RID: 403
		public float MinDepth;

		// Token: 0x04000194 RID: 404
		public float MaxDepth;
	}
}

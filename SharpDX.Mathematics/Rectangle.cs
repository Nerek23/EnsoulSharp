using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000023 RID: 35
	public struct Rectangle : IEquatable<Rectangle>
	{
		// Token: 0x06000591 RID: 1425 RVA: 0x0001BC33 File Offset: 0x00019E33
		public Rectangle(int x, int y, int width, int height)
		{
			this.Left = x;
			this.Top = y;
			this.Right = x + width;
			this.Bottom = y + height;
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x0001BC56 File Offset: 0x00019E56
		// (set) Token: 0x06000593 RID: 1427 RVA: 0x0001BC5E File Offset: 0x00019E5E
		public int X
		{
			get
			{
				return this.Left;
			}
			set
			{
				this.Right = value + this.Width;
				this.Left = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x0001BC75 File Offset: 0x00019E75
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x0001BC7D File Offset: 0x00019E7D
		public int Y
		{
			get
			{
				return this.Top;
			}
			set
			{
				this.Bottom = value + this.Height;
				this.Top = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x0001BC94 File Offset: 0x00019E94
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x0001BCA3 File Offset: 0x00019EA3
		public int Width
		{
			get
			{
				return this.Right - this.Left;
			}
			set
			{
				this.Right = this.Left + value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x0001BCB3 File Offset: 0x00019EB3
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x0001BCC2 File Offset: 0x00019EC2
		public int Height
		{
			get
			{
				return this.Bottom - this.Top;
			}
			set
			{
				this.Bottom = this.Top + value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0001BCD2 File Offset: 0x00019ED2
		public bool IsEmpty
		{
			get
			{
				return this.Width == 0 && this.Height == 0 && this.X == 0 && this.Y == 0;
			}
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0001BCF7 File Offset: 0x00019EF7
		public void Offset(int offsetX, int offsetY)
		{
			this.X += offsetX;
			this.Y += offsetY;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0001BD15 File Offset: 0x00019F15
		public void Inflate(int horizontalAmount, int verticalAmount)
		{
			this.X -= horizontalAmount;
			this.Y -= verticalAmount;
			this.Width += horizontalAmount * 2;
			this.Height += verticalAmount * 2;
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0001BD53 File Offset: 0x00019F53
		public bool Contains(int x, int y)
		{
			return this.X <= x && x < this.Right && this.Y <= y && y < this.Bottom;
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0001BD7C File Offset: 0x00019F7C
		public bool Contains(Rectangle value)
		{
			bool result;
			this.Contains(ref value, out result);
			return result;
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0001BD94 File Offset: 0x00019F94
		public void Contains(ref Rectangle value, out bool result)
		{
			result = (this.X <= value.X && value.Right <= this.Right && this.Y <= value.Y && value.Bottom <= this.Bottom);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0001BDE1 File Offset: 0x00019FE1
		public bool Contains(float x, float y)
		{
			return x >= (float)this.Left && x <= (float)this.Right && y >= (float)this.Top && y <= (float)this.Bottom;
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0001BE10 File Offset: 0x0001A010
		public bool Intersects(Rectangle value)
		{
			bool result;
			this.Intersects(ref value, out result);
			return result;
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0001BE28 File Offset: 0x0001A028
		public void Intersects(ref Rectangle value, out bool result)
		{
			result = (value.X < this.Right && this.X < value.Right && value.Y < this.Bottom && this.Y < value.Bottom);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0001BE68 File Offset: 0x0001A068
		public static Rectangle Intersect(Rectangle value1, Rectangle value2)
		{
			Rectangle result;
			Rectangle.Intersect(ref value1, ref value2, out result);
			return result;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0001BE84 File Offset: 0x0001A084
		public static void Intersect(ref Rectangle value1, ref Rectangle value2, out Rectangle result)
		{
			int num = (value1.X > value2.X) ? value1.X : value2.X;
			int num2 = (value1.Y > value2.Y) ? value1.Y : value2.Y;
			int num3 = (value1.Right < value2.Right) ? value1.Right : value2.Right;
			int num4 = (value1.Bottom < value2.Bottom) ? value1.Bottom : value2.Bottom;
			if (num3 > num && num4 > num2)
			{
				result = new Rectangle(num, num2, num3 - num, num4 - num2);
				return;
			}
			result = Rectangle.Empty;
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0001BF2C File Offset: 0x0001A12C
		public static Rectangle Union(Rectangle value1, Rectangle value2)
		{
			Rectangle result;
			Rectangle.Union(ref value1, ref value2, out result);
			return result;
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0001BF48 File Offset: 0x0001A148
		public static void Union(ref Rectangle value1, ref Rectangle value2, out Rectangle result)
		{
			int num = Math.Min(value1.Left, value2.Left);
			int num2 = Math.Max(value1.Right, value2.Right);
			int num3 = Math.Min(value1.Top, value2.Top);
			int num4 = Math.Max(value1.Bottom, value2.Bottom);
			result = new Rectangle(num, num3, num2 - num, num4 - num3);
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0001BFB0 File Offset: 0x0001A1B0
		public override bool Equals(object obj)
		{
			if (!(obj is Rectangle))
			{
				return false;
			}
			Rectangle rectangle = (Rectangle)obj;
			return this.Equals(ref rectangle);
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0001BFD6 File Offset: 0x0001A1D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Rectangle other)
		{
			return other.Left == this.Left && other.Top == this.Top && other.Right == this.Right && other.Bottom == this.Bottom;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0001C012 File Offset: 0x0001A212
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Rectangle other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0001C01C File Offset: 0x0001A21C
		public override int GetHashCode()
		{
			return ((this.Left * 397 ^ this.Top) * 397 ^ this.Right) * 397 ^ this.Bottom;
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0001C04B File Offset: 0x0001A24B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Rectangle left, Rectangle right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0001C056 File Offset: 0x0001A256
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Rectangle left, Rectangle right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0001C064 File Offset: 0x0001A264
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Width:{2} Height:{3}", new object[]
			{
				this.X,
				this.Y,
				this.Width,
				this.Height
			});
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0001C0BE File Offset: 0x0001A2BE
		internal void MakeXYAndWidthHeight()
		{
			this.Right -= this.Left;
			this.Bottom -= this.Top;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0001C0E6 File Offset: 0x0001A2E6
		public unsafe static implicit operator RawRectangle(Rectangle value)
		{
			return *(RawRectangle*)(&value);
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0001C0F0 File Offset: 0x0001A2F0
		public unsafe static implicit operator Rectangle(RawRectangle value)
		{
			return *(Rectangle*)(&value);
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0001C0FA File Offset: 0x0001A2FA
		public static implicit operator RawBox(Rectangle value)
		{
			return new RawBox(value.X, value.Y, value.Width, value.Height);
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0001C11D File Offset: 0x0001A31D
		public static implicit operator Rectangle(RawBox value)
		{
			return new Rectangle(value.X, value.Y, value.Width, value.Height);
		}

		// Token: 0x0400015B RID: 347
		public int Left;

		// Token: 0x0400015C RID: 348
		public int Top;

		// Token: 0x0400015D RID: 349
		public int Right;

		// Token: 0x0400015E RID: 350
		public int Bottom;

		// Token: 0x0400015F RID: 351
		public static readonly Rectangle Empty = default(Rectangle);
	}
}

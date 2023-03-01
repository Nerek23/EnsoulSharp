using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000024 RID: 36
	public struct RectangleF : IEquatable<RectangleF>
	{
		// Token: 0x060005B4 RID: 1460 RVA: 0x0001C192 File Offset: 0x0001A392
		public RectangleF(float x, float y, float width, float height)
		{
			this.Left = x;
			this.Top = y;
			this.Right = x + width;
			this.Bottom = y + height;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x0001C1B5 File Offset: 0x0001A3B5
		// (set) Token: 0x060005B6 RID: 1462 RVA: 0x0001C1BD File Offset: 0x0001A3BD
		public float X
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x0001C1D4 File Offset: 0x0001A3D4
		// (set) Token: 0x060005B8 RID: 1464 RVA: 0x0001C1DC File Offset: 0x0001A3DC
		public float Y
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

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0001C1F3 File Offset: 0x0001A3F3
		// (set) Token: 0x060005BA RID: 1466 RVA: 0x0001C202 File Offset: 0x0001A402
		public float Width
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

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0001C212 File Offset: 0x0001A412
		// (set) Token: 0x060005BC RID: 1468 RVA: 0x0001C221 File Offset: 0x0001A421
		public float Height
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

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060005BD RID: 1469 RVA: 0x0001C231 File Offset: 0x0001A431
		// (set) Token: 0x060005BE RID: 1470 RVA: 0x0001C244 File Offset: 0x0001A444
		public Vector2 Location
		{
			get
			{
				return new Vector2(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x0001C25E File Offset: 0x0001A45E
		public Vector2 Center
		{
			get
			{
				return new Vector2(this.X + this.Width / 2f, this.Y + this.Height / 2f);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x0001C28B File Offset: 0x0001A48B
		public bool IsEmpty
		{
			get
			{
				return this.Width == 0f && this.Height == 0f && this.X == 0f && this.Y == 0f;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x0001C2C3 File Offset: 0x0001A4C3
		// (set) Token: 0x060005C2 RID: 1474 RVA: 0x0001C2D6 File Offset: 0x0001A4D6
		public Size2F Size
		{
			get
			{
				return new Size2F(this.Width, this.Height);
			}
			set
			{
				this.Width = value.Width;
				this.Height = value.Height;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x0001C2F0 File Offset: 0x0001A4F0
		public Vector2 TopLeft
		{
			get
			{
				return new Vector2(this.Left, this.Top);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x0001C303 File Offset: 0x0001A503
		public Vector2 TopRight
		{
			get
			{
				return new Vector2(this.Right, this.Top);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x0001C316 File Offset: 0x0001A516
		public Vector2 BottomLeft
		{
			get
			{
				return new Vector2(this.Left, this.Bottom);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x0001C329 File Offset: 0x0001A529
		public Vector2 BottomRight
		{
			get
			{
				return new Vector2(this.Right, this.Bottom);
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0001C33C File Offset: 0x0001A53C
		public void Offset(Point amount)
		{
			this.Offset((float)amount.X, (float)amount.Y);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0001C352 File Offset: 0x0001A552
		public void Offset(Vector2 amount)
		{
			this.Offset(amount.X, amount.Y);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0001C366 File Offset: 0x0001A566
		public void Offset(float offsetX, float offsetY)
		{
			this.X += offsetX;
			this.Y += offsetY;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0001C384 File Offset: 0x0001A584
		public void Inflate(float horizontalAmount, float verticalAmount)
		{
			this.X -= horizontalAmount;
			this.Y -= verticalAmount;
			this.Width += horizontalAmount * 2f;
			this.Height += verticalAmount * 2f;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0001C3D8 File Offset: 0x0001A5D8
		public void Contains(ref Vector2 value, out bool result)
		{
			result = (value.X >= this.Left && value.X <= this.Right && value.Y >= this.Top && value.Y <= this.Bottom);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0001C428 File Offset: 0x0001A628
		public bool Contains(Rectangle value)
		{
			return this.X <= (float)value.X && (float)value.Right <= this.Right && this.Y <= (float)value.Y && (float)value.Bottom <= this.Bottom;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0001C478 File Offset: 0x0001A678
		public void Contains(ref RectangleF value, out bool result)
		{
			result = (this.X <= value.X && value.Right <= this.Right && this.Y <= value.Y && value.Bottom <= this.Bottom);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0001C4C5 File Offset: 0x0001A6C5
		public bool Contains(float x, float y)
		{
			return x >= this.Left && x <= this.Right && y >= this.Top && y <= this.Bottom;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0001C4F0 File Offset: 0x0001A6F0
		public bool Contains(Vector2 vector2D)
		{
			return this.Contains(vector2D.X, vector2D.Y);
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0001C504 File Offset: 0x0001A704
		public bool Contains(Point point)
		{
			return this.Contains((float)point.X, (float)point.Y);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0001C51C File Offset: 0x0001A71C
		public bool Intersects(RectangleF value)
		{
			bool result;
			this.Intersects(ref value, out result);
			return result;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0001C534 File Offset: 0x0001A734
		public void Intersects(ref RectangleF value, out bool result)
		{
			result = (value.X < this.Right && this.X < value.Right && value.Y < this.Bottom && this.Y < value.Bottom);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0001C574 File Offset: 0x0001A774
		public static RectangleF Intersect(RectangleF value1, RectangleF value2)
		{
			RectangleF result;
			RectangleF.Intersect(ref value1, ref value2, out result);
			return result;
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0001C590 File Offset: 0x0001A790
		public static void Intersect(ref RectangleF value1, ref RectangleF value2, out RectangleF result)
		{
			float num = (value1.X > value2.X) ? value1.X : value2.X;
			float num2 = (value1.Y > value2.Y) ? value1.Y : value2.Y;
			float num3 = (value1.Right < value2.Right) ? value1.Right : value2.Right;
			float num4 = (value1.Bottom < value2.Bottom) ? value1.Bottom : value2.Bottom;
			if (num3 > num && num4 > num2)
			{
				result = new RectangleF(num, num2, num3 - num, num4 - num2);
				return;
			}
			result = RectangleF.Empty;
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001C638 File Offset: 0x0001A838
		public static RectangleF Union(RectangleF value1, RectangleF value2)
		{
			RectangleF result;
			RectangleF.Union(ref value1, ref value2, out result);
			return result;
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001C654 File Offset: 0x0001A854
		public static void Union(ref RectangleF value1, ref RectangleF value2, out RectangleF result)
		{
			float num = Math.Min(value1.Left, value2.Left);
			float num2 = Math.Max(value1.Right, value2.Right);
			float num3 = Math.Min(value1.Top, value2.Top);
			float num4 = Math.Max(value1.Bottom, value2.Bottom);
			result = new RectangleF(num, num3, num2 - num, num4 - num3);
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0001C6BC File Offset: 0x0001A8BC
		public override bool Equals(object obj)
		{
			if (!(obj is RectangleF))
			{
				return false;
			}
			RectangleF rectangleF = (RectangleF)obj;
			return this.Equals(ref rectangleF);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001C6E4 File Offset: 0x0001A8E4
		public bool Equals(ref RectangleF other)
		{
			return MathUtil.NearEqual(other.Left, this.Left) && MathUtil.NearEqual(other.Right, this.Right) && MathUtil.NearEqual(other.Top, this.Top) && MathUtil.NearEqual(other.Bottom, this.Bottom);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001C73D File Offset: 0x0001A93D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(RectangleF other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001C748 File Offset: 0x0001A948
		public override int GetHashCode()
		{
			return ((this.Left.GetHashCode() * 397 ^ this.Top.GetHashCode()) * 397 ^ this.Right.GetHashCode()) * 397 ^ this.Bottom.GetHashCode();
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0001C798 File Offset: 0x0001A998
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

		// Token: 0x060005DC RID: 1500 RVA: 0x0001C7F2 File Offset: 0x0001A9F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(RectangleF left, RectangleF right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0001C7FD File Offset: 0x0001A9FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(RectangleF left, RectangleF right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0001C80B File Offset: 0x0001AA0B
		public static explicit operator Rectangle(RectangleF value)
		{
			return new Rectangle((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0001C832 File Offset: 0x0001AA32
		public static implicit operator RawRectangle(RectangleF value)
		{
			return new RawRectangle((int)value.X, (int)value.Y, (int)value.Right, (int)value.Bottom);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001C857 File Offset: 0x0001AA57
		public static implicit operator RawRectangleF(RectangleF value)
		{
			return new RawRectangleF(value.X, value.Y, value.Right, value.Bottom);
		}

		// Token: 0x04000160 RID: 352
		public float Left;

		// Token: 0x04000161 RID: 353
		public float Top;

		// Token: 0x04000162 RID: 354
		public float Right;

		// Token: 0x04000163 RID: 355
		public float Bottom;

		// Token: 0x04000164 RID: 356
		public static readonly RectangleF Empty = default(RectangleF);

		// Token: 0x04000165 RID: 357
		public static readonly RectangleF Infinite = new RectangleF
		{
			Left = float.NegativeInfinity,
			Top = float.NegativeInfinity,
			Right = float.PositiveInfinity,
			Bottom = float.PositiveInfinity
		};
	}
}

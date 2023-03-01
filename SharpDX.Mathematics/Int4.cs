using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000017 RID: 23
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Int4 : IEquatable<Int4>, IFormattable
	{
		// Token: 0x0600029C RID: 668 RVA: 0x0000BF5E File Offset: 0x0000A15E
		public Int4(int value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
			this.W = value;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000BF7C File Offset: 0x0000A17C
		public Int4(int x, int y, int z, int w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000BF9C File Offset: 0x0000A19C
		public Int4(int[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Int4.");
			}
			this.X = values[0];
			this.Y = values[1];
			this.Z = values[2];
			this.W = values[3];
		}

		// Token: 0x1700002D RID: 45
		public int this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.X;
				case 1:
					return this.Y;
				case 2:
					return this.Z;
				case 3:
					return this.W;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Int4 run from 0 to 3, inclusive.");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.X = value;
					return;
				case 1:
					this.Y = value;
					return;
				case 2:
					this.Z = value;
					return;
				case 3:
					this.W = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Int4 run from 0 to 3, inclusive.");
				}
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000C098 File Offset: 0x0000A298
		public int[] ToArray()
		{
			return new int[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			};
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000C0C4 File Offset: 0x0000A2C4
		public static void Add(ref Int4 left, ref Int4 right, out Int4 result)
		{
			result = new Int4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000C110 File Offset: 0x0000A310
		public static Int4 Add(Int4 left, Int4 right)
		{
			return new Int4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000C14C File Offset: 0x0000A34C
		public static void Subtract(ref Int4 left, ref Int4 right, out Int4 result)
		{
			result = new Int4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000C198 File Offset: 0x0000A398
		public static Int4 Subtract(Int4 left, Int4 right)
		{
			return new Int4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000C1D3 File Offset: 0x0000A3D3
		public static void Multiply(ref Int4 value, int scale, out Int4 result)
		{
			result = new Int4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000C200 File Offset: 0x0000A400
		public static Int4 Multiply(Int4 value, int scale)
		{
			return new Int4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000C228 File Offset: 0x0000A428
		public static void Modulate(ref Int4 left, ref Int4 right, out Int4 result)
		{
			result = new Int4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000C274 File Offset: 0x0000A474
		public static Int4 Modulate(Int4 left, Int4 right)
		{
			return new Int4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000C2AF File Offset: 0x0000A4AF
		public static void Divide(ref Int4 value, int scale, out Int4 result)
		{
			result = new Int4(value.X / scale, value.Y / scale, value.Z / scale, value.W / scale);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000C2DC File Offset: 0x0000A4DC
		public static Int4 Divide(Int4 value, int scale)
		{
			return new Int4(value.X / scale, value.Y / scale, value.Z / scale, value.W / scale);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000C303 File Offset: 0x0000A503
		public static void Negate(ref Int4 value, out Int4 result)
		{
			result = new Int4(-value.X, -value.Y, -value.Z, -value.W);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000C32C File Offset: 0x0000A52C
		public static Int4 Negate(Int4 value)
		{
			return new Int4(-value.X, -value.Y, -value.Z, -value.W);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000C350 File Offset: 0x0000A550
		public static void Clamp(ref Int4 value, ref Int4 min, ref Int4 max, out Int4 result)
		{
			int num = value.X;
			num = ((num > max.X) ? max.X : num);
			num = ((num < min.X) ? min.X : num);
			int num2 = value.Y;
			num2 = ((num2 > max.Y) ? max.Y : num2);
			num2 = ((num2 < min.Y) ? min.Y : num2);
			int num3 = value.Z;
			num3 = ((num3 > max.Z) ? max.Z : num3);
			num3 = ((num3 < min.Z) ? min.Z : num3);
			int num4 = value.W;
			num4 = ((num4 > max.W) ? max.W : num4);
			num4 = ((num4 < min.W) ? min.W : num4);
			result = new Int4(num, num2, num3, num4);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000C420 File Offset: 0x0000A620
		public static Int4 Clamp(Int4 value, Int4 min, Int4 max)
		{
			Int4 result;
			Int4.Clamp(ref value, ref min, ref max, out result);
			return result;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000C43C File Offset: 0x0000A63C
		public static void Max(ref Int4 left, ref Int4 right, out Int4 result)
		{
			result.X = ((left.X > right.X) ? left.X : right.X);
			result.Y = ((left.Y > right.Y) ? left.Y : right.Y);
			result.Z = ((left.Z > right.Z) ? left.Z : right.Z);
			result.W = ((left.W > right.W) ? left.W : right.W);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000C4D4 File Offset: 0x0000A6D4
		public static Int4 Max(Int4 left, Int4 right)
		{
			Int4 result;
			Int4.Max(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000C4F0 File Offset: 0x0000A6F0
		public static void Min(ref Int4 left, ref Int4 right, out Int4 result)
		{
			result.X = ((left.X < right.X) ? left.X : right.X);
			result.Y = ((left.Y < right.Y) ? left.Y : right.Y);
			result.Z = ((left.Z < right.Z) ? left.Z : right.Z);
			result.W = ((left.W < right.W) ? left.W : right.W);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000C588 File Offset: 0x0000A788
		public static Int4 Min(Int4 left, Int4 right)
		{
			Int4 result;
			Int4.Min(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000C110 File Offset: 0x0000A310
		public static Int4 operator +(Int4 left, Int4 right)
		{
			return new Int4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00002505 File Offset: 0x00000705
		public static Int4 operator +(Int4 value)
		{
			return value;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000C198 File Offset: 0x0000A398
		public static Int4 operator -(Int4 left, Int4 right)
		{
			return new Int4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000C32C File Offset: 0x0000A52C
		public static Int4 operator -(Int4 value)
		{
			return new Int4(-value.X, -value.Y, -value.Z, -value.W);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000C5A1 File Offset: 0x0000A7A1
		public static Int4 operator *(int scale, Int4 value)
		{
			return new Int4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000C200 File Offset: 0x0000A400
		public static Int4 operator *(Int4 value, int scale)
		{
			return new Int4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000C2DC File Offset: 0x0000A4DC
		public static Int4 operator /(Int4 value, int scale)
		{
			return new Int4(value.X / scale, value.Y / scale, value.Z / scale, value.W / scale);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Int4 left, Int4 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000C5D3 File Offset: 0x0000A7D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Int4 left, Int4 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000C5E1 File Offset: 0x0000A7E1
		public static explicit operator Vector2(Int4 value)
		{
			return new Vector2((float)value.X, (float)value.Y);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000C5F6 File Offset: 0x0000A7F6
		public static explicit operator Vector3(Int4 value)
		{
			return new Vector3((float)value.X, (float)value.Y, (float)value.Z);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000C612 File Offset: 0x0000A812
		public static explicit operator Vector4(Int4 value)
		{
			return new Vector4((float)value.X, (float)value.Y, (float)value.Z, (float)value.W);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000C638 File Offset: 0x0000A838
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2} W:{3}", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			});
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000C694 File Offset: 0x0000A894
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2} W:{3}", new object[]
			{
				this.X.ToString(format, CultureInfo.CurrentCulture),
				this.Y.ToString(format, CultureInfo.CurrentCulture),
				this.Z.ToString(format, CultureInfo.CurrentCulture),
				this.W.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000C718 File Offset: 0x0000A918
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "X:{0} Y:{1} Z:{2} W:{3}", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			});
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000C770 File Offset: 0x0000A970
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "X:{0} Y:{1} Z:{2} W:{3}", new object[]
			{
				this.X.ToString(format, formatProvider),
				this.Y.ToString(format, formatProvider),
				this.Z.ToString(format, formatProvider),
				this.W.ToString(format, formatProvider)
			});
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000C7D9 File Offset: 0x0000A9D9
		public override int GetHashCode()
		{
			return ((this.X * 397 ^ this.Y) * 397 ^ this.Z) * 397 ^ this.W;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000C808 File Offset: 0x0000AA08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Int4 other)
		{
			return other.X == this.X && other.Y == this.Y && other.Z == this.Z && other.W == this.W;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000C844 File Offset: 0x0000AA44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Int4 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000C850 File Offset: 0x0000AA50
		public override bool Equals(object value)
		{
			if (!(value is Int4))
			{
				return false;
			}
			Int4 @int = (Int4)value;
			return this.Equals(ref @int);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000C876 File Offset: 0x0000AA76
		public static implicit operator Int4(int[] input)
		{
			return new Int4(input);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000C87E File Offset: 0x0000AA7E
		public static implicit operator int[](Int4 input)
		{
			return input.ToArray();
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000C887 File Offset: 0x0000AA87
		public unsafe static implicit operator RawInt4(Int4 value)
		{
			return *(RawInt4*)(&value);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000C891 File Offset: 0x0000AA91
		public unsafe static implicit operator Int4(RawInt4 value)
		{
			return *(Int4*)(&value);
		}

		// Token: 0x040000FD RID: 253
		public static readonly int SizeInBytes = Utilities.SizeOf<Int4>();

		// Token: 0x040000FE RID: 254
		public static readonly Int4 Zero = default(Int4);

		// Token: 0x040000FF RID: 255
		public static readonly Int4 UnitX = new Int4(1, 0, 0, 0);

		// Token: 0x04000100 RID: 256
		public static readonly Int4 UnitY = new Int4(0, 1, 0, 0);

		// Token: 0x04000101 RID: 257
		public static readonly Int4 UnitZ = new Int4(0, 0, 1, 0);

		// Token: 0x04000102 RID: 258
		public static readonly Int4 UnitW = new Int4(0, 0, 0, 1);

		// Token: 0x04000103 RID: 259
		public static readonly Int4 One = new Int4(1, 1, 1, 1);

		// Token: 0x04000104 RID: 260
		public int X;

		// Token: 0x04000105 RID: 261
		public int Y;

		// Token: 0x04000106 RID: 262
		public int Z;

		// Token: 0x04000107 RID: 263
		public int W;
	}
}

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000016 RID: 22
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Int3 : IEquatable<Int3>, IFormattable
	{
		// Token: 0x0600026C RID: 620 RVA: 0x0000B7C3 File Offset: 0x000099C3
		public Int3(int value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000B7DA File Offset: 0x000099DA
		public Int3(int x, int y, int z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000B7F4 File Offset: 0x000099F4
		public Int3(int[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 3)
			{
				throw new ArgumentOutOfRangeException("values", "There must be three and only three input values for Int3.");
			}
			this.X = values[0];
			this.Y = values[1];
			this.Z = values[2];
		}

		// Token: 0x1700002C RID: 44
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
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Int3 run from 0 to 2, inclusive.");
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
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Int3 run from 0 to 2, inclusive.");
				}
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000B8B7 File Offset: 0x00009AB7
		public int[] ToArray()
		{
			return new int[]
			{
				this.X,
				this.Y,
				this.Z
			};
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000B8DA File Offset: 0x00009ADA
		public static void Add(ref Int3 left, ref Int3 right, out Int3 result)
		{
			result = new Int3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000B90E File Offset: 0x00009B0E
		public static Int3 Add(Int3 left, Int3 right)
		{
			return new Int3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000B93C File Offset: 0x00009B3C
		public static void Subtract(ref Int3 left, ref Int3 right, out Int3 result)
		{
			result = new Int3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000B970 File Offset: 0x00009B70
		public static Int3 Subtract(Int3 left, Int3 right)
		{
			return new Int3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000B99E File Offset: 0x00009B9E
		public static void Multiply(ref Int3 value, int scale, out Int3 result)
		{
			result = new Int3(value.X * scale, value.Y * scale, value.Z * scale);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000B9C3 File Offset: 0x00009BC3
		public static Int3 Multiply(Int3 value, int scale)
		{
			return new Int3(value.X * scale, value.Y * scale, value.Z * scale);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000B9E2 File Offset: 0x00009BE2
		public static void Modulate(ref Int3 left, ref Int3 right, out Int3 result)
		{
			result = new Int3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000BA16 File Offset: 0x00009C16
		public static Int3 Modulate(Int3 left, Int3 right)
		{
			return new Int3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000BA44 File Offset: 0x00009C44
		public static void Divide(ref Int3 value, int scale, out Int3 result)
		{
			result = new Int3(value.X / scale, value.Y / scale, value.Z / scale);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000BA69 File Offset: 0x00009C69
		public static Int3 Divide(Int3 value, int scale)
		{
			return new Int3(value.X / scale, value.Y / scale, value.Z / scale);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000BA88 File Offset: 0x00009C88
		public static void Negate(ref Int3 value, out Int3 result)
		{
			result = new Int3(-value.X, -value.Y, -value.Z);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000BAAA File Offset: 0x00009CAA
		public static Int3 Negate(Int3 value)
		{
			return new Int3(-value.X, -value.Y, -value.Z);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000BAC8 File Offset: 0x00009CC8
		public static void Clamp(ref Int3 value, ref Int3 min, ref Int3 max, out Int3 result)
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
			result = new Int3(num, num2, num3);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000BB6C File Offset: 0x00009D6C
		public static Int3 Clamp(Int3 value, Int3 min, Int3 max)
		{
			Int3 result;
			Int3.Clamp(ref value, ref min, ref max, out result);
			return result;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000BB88 File Offset: 0x00009D88
		public static void Max(ref Int3 left, ref Int3 right, out Int3 result)
		{
			result.X = ((left.X > right.X) ? left.X : right.X);
			result.Y = ((left.Y > right.Y) ? left.Y : right.Y);
			result.Z = ((left.Z > right.Z) ? left.Z : right.Z);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000BBFC File Offset: 0x00009DFC
		public static Int3 Max(Int3 left, Int3 right)
		{
			Int3 result;
			Int3.Max(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000BC18 File Offset: 0x00009E18
		public static void Min(ref Int3 left, ref Int3 right, out Int3 result)
		{
			result.X = ((left.X < right.X) ? left.X : right.X);
			result.Y = ((left.Y < right.Y) ? left.Y : right.Y);
			result.Z = ((left.Z < right.Z) ? left.Z : right.Z);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000BC8C File Offset: 0x00009E8C
		public static Int3 Min(Int3 left, Int3 right)
		{
			Int3 result;
			Int3.Min(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000B90E File Offset: 0x00009B0E
		public static Int3 operator +(Int3 left, Int3 right)
		{
			return new Int3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00002505 File Offset: 0x00000705
		public static Int3 operator +(Int3 value)
		{
			return value;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000B970 File Offset: 0x00009B70
		public static Int3 operator -(Int3 left, Int3 right)
		{
			return new Int3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000BAAA File Offset: 0x00009CAA
		public static Int3 operator -(Int3 value)
		{
			return new Int3(-value.X, -value.Y, -value.Z);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000BCA5 File Offset: 0x00009EA5
		public static Int3 operator *(int scale, Int3 value)
		{
			return new Int3(value.X * scale, value.Y * scale, value.Z * scale);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000B9C3 File Offset: 0x00009BC3
		public static Int3 operator *(Int3 value, int scale)
		{
			return new Int3(value.X * scale, value.Y * scale, value.Z * scale);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000BA69 File Offset: 0x00009C69
		public static Int3 operator /(Int3 value, int scale)
		{
			return new Int3(value.X / scale, value.Y / scale, value.Z / scale);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000BCC4 File Offset: 0x00009EC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Int3 left, Int3 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000BCCF File Offset: 0x00009ECF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Int3 left, Int3 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000BCDD File Offset: 0x00009EDD
		public static explicit operator Vector2(Int3 value)
		{
			return new Vector2((float)value.X, (float)value.Y);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000BCF2 File Offset: 0x00009EF2
		public static explicit operator Vector3(Int3 value)
		{
			return new Vector3((float)value.X, (float)value.Y, (float)value.Z);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000BD10 File Offset: 0x00009F10
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2}", new object[]
			{
				this.X,
				this.Y,
				this.Z
			});
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000BD5C File Offset: 0x00009F5C
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2}", new object[]
			{
				this.X.ToString(format, CultureInfo.CurrentCulture),
				this.Y.ToString(format, CultureInfo.CurrentCulture),
				this.Z.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000BDCA File Offset: 0x00009FCA
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "X:{0} Y:{1} Z:{2}", new object[]
			{
				this.X,
				this.Y,
				this.Z
			});
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000BE08 File Offset: 0x0000A008
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "X:{0} Y:{1} Z:{2}", new object[]
			{
				this.X.ToString(format, formatProvider),
				this.Y.ToString(format, formatProvider),
				this.Z.ToString(format, formatProvider)
			});
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000BE61 File Offset: 0x0000A061
		public override int GetHashCode()
		{
			return (this.X * 397 ^ this.Y) * 397 ^ this.Z;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000BE83 File Offset: 0x0000A083
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Int3 other)
		{
			return other.X == this.X && other.Y == this.Y && other.Z == this.Z;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000BEB1 File Offset: 0x0000A0B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Int3 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000BEBC File Offset: 0x0000A0BC
		public override bool Equals(object value)
		{
			if (!(value is Int3))
			{
				return false;
			}
			Int3 @int = (Int3)value;
			return this.Equals(ref @int);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000BEE2 File Offset: 0x0000A0E2
		public static implicit operator Int3(int[] input)
		{
			return new Int3(input);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000BEEA File Offset: 0x0000A0EA
		public static implicit operator int[](Int3 input)
		{
			return input.ToArray();
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000BEF3 File Offset: 0x0000A0F3
		public unsafe static implicit operator RawInt3(Int3 value)
		{
			return *(RawInt3*)(&value);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000BEFD File Offset: 0x0000A0FD
		public unsafe static implicit operator Int3(RawInt3 value)
		{
			return *(Int3*)(&value);
		}

		// Token: 0x040000F4 RID: 244
		public static readonly int SizeInBytes = Utilities.SizeOf<Int3>();

		// Token: 0x040000F5 RID: 245
		public static readonly Int3 Zero = default(Int3);

		// Token: 0x040000F6 RID: 246
		public static readonly Int3 UnitX = new Int3(1, 0, 0);

		// Token: 0x040000F7 RID: 247
		public static readonly Int3 UnitY = new Int3(0, 1, 0);

		// Token: 0x040000F8 RID: 248
		public static readonly Int3 UnitZ = new Int3(0, 0, 1);

		// Token: 0x040000F9 RID: 249
		public static readonly Int3 One = new Int3(1, 1, 1);

		// Token: 0x040000FA RID: 250
		public int X;

		// Token: 0x040000FB RID: 251
		public int Y;

		// Token: 0x040000FC RID: 252
		public int Z;
	}
}

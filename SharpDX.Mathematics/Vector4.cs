using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000027 RID: 39
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Vector4 : IEquatable<Vector4>, IFormattable
	{
		// Token: 0x060006BA RID: 1722 RVA: 0x0001F9EA File Offset: 0x0001DBEA
		public Vector4(float value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
			this.W = value;
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0001FA08 File Offset: 0x0001DC08
		public Vector4(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x0001FA27 File Offset: 0x0001DC27
		public Vector4(Vector3 value, float w)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = value.Z;
			this.W = w;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0001FA54 File Offset: 0x0001DC54
		public Vector4(Vector2 value, float z, float w)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x0001FA7C File Offset: 0x0001DC7C
		public Vector4(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Vector4.");
			}
			this.X = values[0];
			this.Y = values[1];
			this.Z = values[2];
			this.W = values[3];
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0001FAD1 File Offset: 0x0001DCD1
		public bool IsNormalized
		{
			get
			{
				return MathUtil.IsOne(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060006C0 RID: 1728 RVA: 0x0001FB0F File Offset: 0x0001DD0F
		public bool IsZero
		{
			get
			{
				return this.X == 0f && this.Y == 0f && this.Z == 0f && this.W == 0f;
			}
		}

		// Token: 0x17000080 RID: 128
		public float this[int index]
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
					throw new ArgumentOutOfRangeException("index", "Indices for Vector4 run from 0 to 3, inclusive.");
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
					throw new ArgumentOutOfRangeException("index", "Indices for Vector4 run from 0 to 3, inclusive.");
				}
			}
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x0001FBEC File Offset: 0x0001DDEC
		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W));
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0001FC2C File Offset: 0x0001DE2C
		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0001FC68 File Offset: 0x0001DE68
		public void Normalize()
		{
			float num = this.Length();
			if (!MathUtil.IsZero(num))
			{
				float num2 = 1f / num;
				this.X *= num2;
				this.Y *= num2;
				this.Z *= num2;
				this.W *= num2;
			}
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0001FCC4 File Offset: 0x0001DEC4
		public float[] ToArray()
		{
			return new float[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			};
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0001FCF0 File Offset: 0x0001DEF0
		public static void Add(ref Vector4 left, ref Vector4 right, out Vector4 result)
		{
			result = new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x0001FD3C File Offset: 0x0001DF3C
		public static Vector4 Add(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0001FD77 File Offset: 0x0001DF77
		public static void Add(ref Vector4 left, ref float right, out Vector4 result)
		{
			result = new Vector4(left.X + right, left.Y + right, left.Z + right, left.W + right);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0001FDA8 File Offset: 0x0001DFA8
		public static Vector4 Add(Vector4 left, float right)
		{
			return new Vector4(left.X + right, left.Y + right, left.Z + right, left.W + right);
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0001FDD0 File Offset: 0x0001DFD0
		public static void Subtract(ref Vector4 left, ref Vector4 right, out Vector4 result)
		{
			result = new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0001FE1C File Offset: 0x0001E01C
		public static Vector4 Subtract(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0001FE57 File Offset: 0x0001E057
		public static void Subtract(ref Vector4 left, ref float right, out Vector4 result)
		{
			result = new Vector4(left.X - right, left.Y - right, left.Z - right, left.W - right);
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0001FE88 File Offset: 0x0001E088
		public static Vector4 Subtract(Vector4 left, float right)
		{
			return new Vector4(left.X - right, left.Y - right, left.Z - right, left.W - right);
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0001FEAF File Offset: 0x0001E0AF
		public static void Subtract(ref float left, ref Vector4 right, out Vector4 result)
		{
			result = new Vector4(left - right.X, left - right.Y, left - right.Z, left - right.W);
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0001FEE0 File Offset: 0x0001E0E0
		public static Vector4 Subtract(float left, Vector4 right)
		{
			return new Vector4(left - right.X, left - right.Y, left - right.Z, left - right.W);
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0001FF07 File Offset: 0x0001E107
		public static void Multiply(ref Vector4 value, float scale, out Vector4 result)
		{
			result = new Vector4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x0001FF34 File Offset: 0x0001E134
		public static Vector4 Multiply(Vector4 value, float scale)
		{
			return new Vector4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0001FF5C File Offset: 0x0001E15C
		public static void Multiply(ref Vector4 left, ref Vector4 right, out Vector4 result)
		{
			result = new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0001FFA8 File Offset: 0x0001E1A8
		public static Vector4 Multiply(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0001FFE3 File Offset: 0x0001E1E3
		public static void Divide(ref Vector4 value, float scale, out Vector4 result)
		{
			result = new Vector4(value.X / scale, value.Y / scale, value.Z / scale, value.W / scale);
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00020010 File Offset: 0x0001E210
		public static Vector4 Divide(Vector4 value, float scale)
		{
			return new Vector4(value.X / scale, value.Y / scale, value.Z / scale, value.W / scale);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00020037 File Offset: 0x0001E237
		public static void Divide(float scale, ref Vector4 value, out Vector4 result)
		{
			result = new Vector4(scale / value.X, scale / value.Y, scale / value.Z, scale / value.W);
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00020064 File Offset: 0x0001E264
		public static Vector4 Divide(float scale, Vector4 value)
		{
			return new Vector4(scale / value.X, scale / value.Y, scale / value.Z, scale / value.W);
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0002008B File Offset: 0x0001E28B
		public static void Negate(ref Vector4 value, out Vector4 result)
		{
			result = new Vector4(-value.X, -value.Y, -value.Z, -value.W);
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x000200B4 File Offset: 0x0001E2B4
		public static Vector4 Negate(Vector4 value)
		{
			return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x000200D8 File Offset: 0x0001E2D8
		public static void Barycentric(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, float amount1, float amount2, out Vector4 result)
		{
			result = new Vector4(value1.X + amount1 * (value2.X - value1.X) + amount2 * (value3.X - value1.X), value1.Y + amount1 * (value2.Y - value1.Y) + amount2 * (value3.Y - value1.Y), value1.Z + amount1 * (value2.Z - value1.Z) + amount2 * (value3.Z - value1.Z), value1.W + amount1 * (value2.W - value1.W) + amount2 * (value3.W - value1.W));
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x00020190 File Offset: 0x0001E390
		public static Vector4 Barycentric(Vector4 value1, Vector4 value2, Vector4 value3, float amount1, float amount2)
		{
			Vector4 result;
			Vector4.Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
			return result;
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x000201B0 File Offset: 0x0001E3B0
		public static void Clamp(ref Vector4 value, ref Vector4 min, ref Vector4 max, out Vector4 result)
		{
			float num = value.X;
			num = ((num > max.X) ? max.X : num);
			num = ((num < min.X) ? min.X : num);
			float num2 = value.Y;
			num2 = ((num2 > max.Y) ? max.Y : num2);
			num2 = ((num2 < min.Y) ? min.Y : num2);
			float num3 = value.Z;
			num3 = ((num3 > max.Z) ? max.Z : num3);
			num3 = ((num3 < min.Z) ? min.Z : num3);
			float num4 = value.W;
			num4 = ((num4 > max.W) ? max.W : num4);
			num4 = ((num4 < min.W) ? min.W : num4);
			result = new Vector4(num, num2, num3, num4);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x00020280 File Offset: 0x0001E480
		public static Vector4 Clamp(Vector4 value, Vector4 min, Vector4 max)
		{
			Vector4 result;
			Vector4.Clamp(ref value, ref min, ref max, out result);
			return result;
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x0002029C File Offset: 0x0001E49C
		public static void Distance(ref Vector4 value1, ref Vector4 value2, out float result)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			float num3 = value1.Z - value2.Z;
			float num4 = value1.W - value2.W;
			result = (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3 + num4 * num4));
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x000202FC File Offset: 0x0001E4FC
		public static float Distance(Vector4 value1, Vector4 value2)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			float num3 = value1.Z - value2.Z;
			float num4 = value1.W - value2.W;
			return (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3 + num4 * num4));
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00020358 File Offset: 0x0001E558
		public static void DistanceSquared(ref Vector4 value1, ref Vector4 value2, out float result)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			float num3 = value1.Z - value2.Z;
			float num4 = value1.W - value2.W;
			result = num * num + num2 * num2 + num3 * num3 + num4 * num4;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x000203B0 File Offset: 0x0001E5B0
		public static float DistanceSquared(Vector4 value1, Vector4 value2)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			float num3 = value1.Z - value2.Z;
			float num4 = value1.W - value2.W;
			return num * num + num2 * num2 + num3 * num3 + num4 * num4;
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00020402 File Offset: 0x0001E602
		public static void Dot(ref Vector4 left, ref Vector4 right, out float result)
		{
			result = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0002043D File Offset: 0x0001E63D
		public static float Dot(Vector4 left, Vector4 right)
		{
			return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00020478 File Offset: 0x0001E678
		public static void Normalize(ref Vector4 value, out Vector4 result)
		{
			Vector4 vector = value;
			result = vector;
			result.Normalize();
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00020499 File Offset: 0x0001E699
		public static Vector4 Normalize(Vector4 value)
		{
			value.Normalize();
			return value;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x000204A4 File Offset: 0x0001E6A4
		public static void Lerp(ref Vector4 start, ref Vector4 end, float amount, out Vector4 result)
		{
			result.X = MathUtil.Lerp(start.X, end.X, amount);
			result.Y = MathUtil.Lerp(start.Y, end.Y, amount);
			result.Z = MathUtil.Lerp(start.Z, end.Z, amount);
			result.W = MathUtil.Lerp(start.W, end.W, amount);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00020514 File Offset: 0x0001E714
		public static Vector4 Lerp(Vector4 start, Vector4 end, float amount)
		{
			Vector4 result;
			Vector4.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0002052E File Offset: 0x0001E72E
		public static void SmoothStep(ref Vector4 start, ref Vector4 end, float amount, out Vector4 result)
		{
			amount = MathUtil.SmoothStep(amount);
			Vector4.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00020544 File Offset: 0x0001E744
		public static Vector4 SmoothStep(Vector4 start, Vector4 end, float amount)
		{
			Vector4 result;
			Vector4.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00020560 File Offset: 0x0001E760
		public static void Hermite(ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2, float amount, out Vector4 result)
		{
			float num = amount * amount;
			float num2 = amount * num;
			float num3 = 2f * num2 - 3f * num + 1f;
			float num4 = -2f * num2 + 3f * num;
			float num5 = num2 - 2f * num + amount;
			float num6 = num2 - num;
			result = new Vector4(value1.X * num3 + value2.X * num4 + tangent1.X * num5 + tangent2.X * num6, value1.Y * num3 + value2.Y * num4 + tangent1.Y * num5 + tangent2.Y * num6, value1.Z * num3 + value2.Z * num4 + tangent1.Z * num5 + tangent2.Z * num6, value1.W * num3 + value2.W * num4 + tangent1.W * num5 + tangent2.W * num6);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00020654 File Offset: 0x0001E854
		public static Vector4 Hermite(Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, float amount)
		{
			Vector4 result;
			Vector4.Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
			return result;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00020674 File Offset: 0x0001E874
		public static void CatmullRom(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4, float amount, out Vector4 result)
		{
			float num = amount * amount;
			float num2 = amount * num;
			result.X = 0.5f * (2f * value2.X + (-value1.X + value3.X) * amount + (2f * value1.X - 5f * value2.X + 4f * value3.X - value4.X) * num + (-value1.X + 3f * value2.X - 3f * value3.X + value4.X) * num2);
			result.Y = 0.5f * (2f * value2.Y + (-value1.Y + value3.Y) * amount + (2f * value1.Y - 5f * value2.Y + 4f * value3.Y - value4.Y) * num + (-value1.Y + 3f * value2.Y - 3f * value3.Y + value4.Y) * num2);
			result.Z = 0.5f * (2f * value2.Z + (-value1.Z + value3.Z) * amount + (2f * value1.Z - 5f * value2.Z + 4f * value3.Z - value4.Z) * num + (-value1.Z + 3f * value2.Z - 3f * value3.Z + value4.Z) * num2);
			result.W = 0.5f * (2f * value2.W + (-value1.W + value3.W) * amount + (2f * value1.W - 5f * value2.W + 4f * value3.W - value4.W) * num + (-value1.W + 3f * value2.W - 3f * value3.W + value4.W) * num2);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x000208A4 File Offset: 0x0001EAA4
		public static Vector4 CatmullRom(Vector4 value1, Vector4 value2, Vector4 value3, Vector4 value4, float amount)
		{
			Vector4 result;
			Vector4.CatmullRom(ref value1, ref value2, ref value3, ref value4, amount, out result);
			return result;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x000208C4 File Offset: 0x0001EAC4
		public static void Max(ref Vector4 left, ref Vector4 right, out Vector4 result)
		{
			result.X = ((left.X > right.X) ? left.X : right.X);
			result.Y = ((left.Y > right.Y) ? left.Y : right.Y);
			result.Z = ((left.Z > right.Z) ? left.Z : right.Z);
			result.W = ((left.W > right.W) ? left.W : right.W);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0002095C File Offset: 0x0001EB5C
		public static Vector4 Max(Vector4 left, Vector4 right)
		{
			Vector4 result;
			Vector4.Max(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00020978 File Offset: 0x0001EB78
		public static void Min(ref Vector4 left, ref Vector4 right, out Vector4 result)
		{
			result.X = ((left.X < right.X) ? left.X : right.X);
			result.Y = ((left.Y < right.Y) ? left.Y : right.Y);
			result.Z = ((left.Z < right.Z) ? left.Z : right.Z);
			result.W = ((left.W < right.W) ? left.W : right.W);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00020A10 File Offset: 0x0001EC10
		public static Vector4 Min(Vector4 left, Vector4 right)
		{
			Vector4 result;
			Vector4.Min(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00020A2C File Offset: 0x0001EC2C
		public static void Orthogonalize(Vector4[] destination, params Vector4[] source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < source.Length)
			{
				throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
			}
			for (int i = 0; i < source.Length; i++)
			{
				Vector4 vector = source[i];
				for (int j = 0; j < i; j++)
				{
					vector -= Vector4.Dot(destination[j], vector) / Vector4.Dot(destination[j], destination[j]) * destination[j];
				}
				destination[i] = vector;
			}
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00020ACC File Offset: 0x0001ECCC
		public static void Orthonormalize(Vector4[] destination, params Vector4[] source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < source.Length)
			{
				throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
			}
			for (int i = 0; i < source.Length; i++)
			{
				Vector4 vector = source[i];
				for (int j = 0; j < i; j++)
				{
					vector -= Vector4.Dot(destination[j], vector) * destination[j];
				}
				vector.Normalize();
				destination[i] = vector;
			}
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00020B60 File Offset: 0x0001ED60
		public static void Transform(ref Vector4 vector, ref Quaternion rotation, out Vector4 result)
		{
			float num = rotation.X + rotation.X;
			float num2 = rotation.Y + rotation.Y;
			float num3 = rotation.Z + rotation.Z;
			float num4 = rotation.W * num;
			float num5 = rotation.W * num2;
			float num6 = rotation.W * num3;
			float num7 = rotation.X * num;
			float num8 = rotation.X * num2;
			float num9 = rotation.X * num3;
			float num10 = rotation.Y * num2;
			float num11 = rotation.Y * num3;
			float num12 = rotation.Z * num3;
			result = new Vector4(vector.X * (1f - num10 - num12) + vector.Y * (num8 - num6) + vector.Z * (num9 + num5), vector.X * (num8 + num6) + vector.Y * (1f - num7 - num12) + vector.Z * (num11 - num4), vector.X * (num9 - num5) + vector.Y * (num11 + num4) + vector.Z * (1f - num7 - num10), vector.W);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00020C84 File Offset: 0x0001EE84
		public static Vector4 Transform(Vector4 vector, Quaternion rotation)
		{
			Vector4 result;
			Vector4.Transform(ref vector, ref rotation, out result);
			return result;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00020CA0 File Offset: 0x0001EEA0
		public static void Transform(Vector4[] source, ref Quaternion rotation, Vector4[] destination)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < source.Length)
			{
				throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
			}
			float num = rotation.X + rotation.X;
			float num2 = rotation.Y + rotation.Y;
			float num3 = rotation.Z + rotation.Z;
			float num4 = rotation.W * num;
			float num5 = rotation.W * num2;
			float num6 = rotation.W * num3;
			float num7 = rotation.X * num;
			float num8 = rotation.X * num2;
			float num9 = rotation.X * num3;
			float num10 = rotation.Y * num2;
			float num11 = rotation.Y * num3;
			float num12 = rotation.Z * num3;
			float num13 = 1f - num10 - num12;
			float num14 = num8 - num6;
			float num15 = num9 + num5;
			float num16 = num8 + num6;
			float num17 = 1f - num7 - num12;
			float num18 = num11 - num4;
			float num19 = num9 - num5;
			float num20 = num11 + num4;
			float num21 = 1f - num7 - num10;
			for (int i = 0; i < source.Length; i++)
			{
				destination[i] = new Vector4(source[i].X * num13 + source[i].Y * num14 + source[i].Z * num15, source[i].X * num16 + source[i].Y * num17 + source[i].Z * num18, source[i].X * num19 + source[i].Y * num20 + source[i].Z * num21, source[i].W);
			}
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00020E78 File Offset: 0x0001F078
		public static void Transform(ref Vector4 vector, ref Matrix transform, out Vector4 result)
		{
			result = new Vector4(vector.X * transform.M11 + vector.Y * transform.M21 + vector.Z * transform.M31 + vector.W * transform.M41, vector.X * transform.M12 + vector.Y * transform.M22 + vector.Z * transform.M32 + vector.W * transform.M42, vector.X * transform.M13 + vector.Y * transform.M23 + vector.Z * transform.M33 + vector.W * transform.M43, vector.X * transform.M14 + vector.Y * transform.M24 + vector.Z * transform.M34 + vector.W * transform.M44);
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00020F6C File Offset: 0x0001F16C
		public static Vector4 Transform(Vector4 vector, Matrix transform)
		{
			Vector4 result;
			Vector4.Transform(ref vector, ref transform, out result);
			return result;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00020F88 File Offset: 0x0001F188
		public static void Transform(ref Vector4 vector, ref Matrix5x4 transform, out Vector4 result)
		{
			result = new Vector4(vector.X * transform.M11 + vector.Y * transform.M21 + vector.Z * transform.M31 + vector.W * transform.M41 + transform.M51, vector.X * transform.M12 + vector.Y * transform.M22 + vector.Z * transform.M32 + vector.W * transform.M42 + transform.M52, vector.X * transform.M13 + vector.Y * transform.M23 + vector.Z * transform.M33 + vector.W * transform.M43 + transform.M53, vector.X * transform.M14 + vector.Y * transform.M24 + vector.Z * transform.M34 + vector.W * transform.M44 + transform.M54);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00021098 File Offset: 0x0001F298
		public static Vector4 Transform(Vector4 vector, Matrix5x4 transform)
		{
			Vector4 result;
			Vector4.Transform(ref vector, ref transform, out result);
			return result;
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x000210B4 File Offset: 0x0001F2B4
		public static void Transform(Vector4[] source, ref Matrix transform, Vector4[] destination)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < source.Length)
			{
				throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
			}
			for (int i = 0; i < source.Length; i++)
			{
				Vector4.Transform(ref source[i], ref transform, out destination[i]);
			}
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0001FD3C File Offset: 0x0001DF3C
		public static Vector4 operator +(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0001FFA8 File Offset: 0x0001E1A8
		public static Vector4 operator *(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00002505 File Offset: 0x00000705
		public static Vector4 operator +(Vector4 value)
		{
			return value;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0001FE1C File Offset: 0x0001E01C
		public static Vector4 operator -(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x000200B4 File Offset: 0x0001E2B4
		public static Vector4 operator -(Vector4 value)
		{
			return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00021117 File Offset: 0x0001F317
		public static Vector4 operator *(float scale, Vector4 value)
		{
			return new Vector4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0001FF34 File Offset: 0x0001E134
		public static Vector4 operator *(Vector4 value, float scale)
		{
			return new Vector4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00020010 File Offset: 0x0001E210
		public static Vector4 operator /(Vector4 value, float scale)
		{
			return new Vector4(value.X / scale, value.Y / scale, value.Z / scale, value.W / scale);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00020064 File Offset: 0x0001E264
		public static Vector4 operator /(float scale, Vector4 value)
		{
			return new Vector4(scale / value.X, scale / value.Y, scale / value.Z, scale / value.W);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0002113E File Offset: 0x0001F33E
		public static Vector4 operator /(Vector4 value, Vector4 scale)
		{
			return new Vector4(value.X / scale.X, value.Y / scale.Y, value.Z / scale.Z, value.W / scale.W);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0001FDA8 File Offset: 0x0001DFA8
		public static Vector4 operator +(Vector4 value, float scalar)
		{
			return new Vector4(value.X + scalar, value.Y + scalar, value.Z + scalar, value.W + scalar);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00021179 File Offset: 0x0001F379
		public static Vector4 operator +(float scalar, Vector4 value)
		{
			return new Vector4(scalar + value.X, scalar + value.Y, scalar + value.Z, scalar + value.W);
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x0001FE88 File Offset: 0x0001E088
		public static Vector4 operator -(Vector4 value, float scalar)
		{
			return new Vector4(value.X - scalar, value.Y - scalar, value.Z - scalar, value.W - scalar);
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x0001FEE0 File Offset: 0x0001E0E0
		public static Vector4 operator -(float scalar, Vector4 value)
		{
			return new Vector4(scalar - value.X, scalar - value.Y, scalar - value.Z, scalar - value.W);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x000211A0 File Offset: 0x0001F3A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Vector4 left, Vector4 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x000211AB File Offset: 0x0001F3AB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Vector4 left, Vector4 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x000211B9 File Offset: 0x0001F3B9
		public static explicit operator Vector2(Vector4 value)
		{
			return new Vector2(value.X, value.Y);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000211CC File Offset: 0x0001F3CC
		public static explicit operator Vector3(Vector4 value)
		{
			return new Vector3(value.X, value.Y, value.Z);
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x000211E8 File Offset: 0x0001F3E8
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

		// Token: 0x06000710 RID: 1808 RVA: 0x00021244 File Offset: 0x0001F444
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

		// Token: 0x06000711 RID: 1809 RVA: 0x000212C8 File Offset: 0x0001F4C8
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

		// Token: 0x06000712 RID: 1810 RVA: 0x00021320 File Offset: 0x0001F520
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

		// Token: 0x06000713 RID: 1811 RVA: 0x0002138C File Offset: 0x0001F58C
		public override int GetHashCode()
		{
			return ((this.X.GetHashCode() * 397 ^ this.Y.GetHashCode()) * 397 ^ this.Z.GetHashCode()) * 397 ^ this.W.GetHashCode();
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x000213DC File Offset: 0x0001F5DC
		public bool Equals(ref Vector4 other)
		{
			return MathUtil.NearEqual(other.X, this.X) && MathUtil.NearEqual(other.Y, this.Y) && MathUtil.NearEqual(other.Z, this.Z) && MathUtil.NearEqual(other.W, this.W);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00021435 File Offset: 0x0001F635
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Vector4 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00021440 File Offset: 0x0001F640
		public override bool Equals(object value)
		{
			if (!(value is Vector4))
			{
				return false;
			}
			Vector4 vector = (Vector4)value;
			return this.Equals(ref vector);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00021466 File Offset: 0x0001F666
		public unsafe static implicit operator RawVector4(Vector4 value)
		{
			return *(RawVector4*)(&value);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00021470 File Offset: 0x0001F670
		public unsafe static implicit operator Vector4(RawVector4 value)
		{
			return *(Vector4*)(&value);
		}

		// Token: 0x0400017E RID: 382
		public static readonly int SizeInBytes = Utilities.SizeOf<Vector4>();

		// Token: 0x0400017F RID: 383
		public static readonly Vector4 Zero = default(Vector4);

		// Token: 0x04000180 RID: 384
		public static readonly Vector4 UnitX = new Vector4(1f, 0f, 0f, 0f);

		// Token: 0x04000181 RID: 385
		public static readonly Vector4 UnitY = new Vector4(0f, 1f, 0f, 0f);

		// Token: 0x04000182 RID: 386
		public static readonly Vector4 UnitZ = new Vector4(0f, 0f, 1f, 0f);

		// Token: 0x04000183 RID: 387
		public static readonly Vector4 UnitW = new Vector4(0f, 0f, 0f, 1f);

		// Token: 0x04000184 RID: 388
		public static readonly Vector4 One = new Vector4(1f, 1f, 1f, 1f);

		// Token: 0x04000185 RID: 389
		public float X;

		// Token: 0x04000186 RID: 390
		public float Y;

		// Token: 0x04000187 RID: 391
		public float Z;

		// Token: 0x04000188 RID: 392
		public float W;
	}
}

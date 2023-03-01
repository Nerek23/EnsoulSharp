using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000026 RID: 38
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Vector3 : IEquatable<Vector3>, IFormattable
	{
		// Token: 0x06000648 RID: 1608 RVA: 0x0001DC62 File Offset: 0x0001BE62
		public Vector3(float value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0001DC79 File Offset: 0x0001BE79
		public Vector3(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001DC90 File Offset: 0x0001BE90
		public Vector3(Vector2 value, float z)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = z;
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x0001DCB4 File Offset: 0x0001BEB4
		public Vector3(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 3)
			{
				throw new ArgumentOutOfRangeException("values", "There must be three and only three input values for Vector3.");
			}
			this.X = values[0];
			this.Y = values[1];
			this.Z = values[2];
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x0001DD00 File Offset: 0x0001BF00
		public bool IsNormalized
		{
			get
			{
				return MathUtil.IsOne(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x0001DD30 File Offset: 0x0001BF30
		public bool IsZero
		{
			get
			{
				return this.X == 0f && this.Y == 0f && this.Z == 0f;
			}
		}

		// Token: 0x1700007D RID: 125
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
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Vector3 run from 0 to 2, inclusive.");
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
					throw new ArgumentOutOfRangeException("index", "Indices for Vector3 run from 0 to 2, inclusive.");
				}
			}
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001DDD2 File Offset: 0x0001BFD2
		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z));
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0001DE04 File Offset: 0x0001C004
		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0001DE30 File Offset: 0x0001C030
		public void Normalize()
		{
			float num = this.Length();
			if (!MathUtil.IsZero(num))
			{
				float num2 = 1f / num;
				this.X *= num2;
				this.Y *= num2;
				this.Z *= num2;
			}
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0001DE7E File Offset: 0x0001C07E
		public float[] ToArray()
		{
			return new float[]
			{
				this.X,
				this.Y,
				this.Z
			};
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0001DEA1 File Offset: 0x0001C0A1
		public static void Add(ref Vector3 left, ref Vector3 right, out Vector3 result)
		{
			result = new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0001DED5 File Offset: 0x0001C0D5
		public static Vector3 Add(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001DF03 File Offset: 0x0001C103
		public static void Add(ref Vector3 left, ref float right, out Vector3 result)
		{
			result = new Vector3(left.X + right, left.Y + right, left.Z + right);
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0001DF2B File Offset: 0x0001C12B
		public static Vector3 Add(Vector3 left, float right)
		{
			return new Vector3(left.X + right, left.Y + right, left.Z + right);
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0001DF4A File Offset: 0x0001C14A
		public static void Subtract(ref Vector3 left, ref Vector3 right, out Vector3 result)
		{
			result = new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001DF7E File Offset: 0x0001C17E
		public static Vector3 Subtract(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0001DFAC File Offset: 0x0001C1AC
		public static void Subtract(ref Vector3 left, ref float right, out Vector3 result)
		{
			result = new Vector3(left.X - right, left.Y - right, left.Z - right);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0001DFD4 File Offset: 0x0001C1D4
		public static Vector3 Subtract(Vector3 left, float right)
		{
			return new Vector3(left.X - right, left.Y - right, left.Z - right);
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0001DFF3 File Offset: 0x0001C1F3
		public static void Subtract(ref float left, ref Vector3 right, out Vector3 result)
		{
			result = new Vector3(left - right.X, left - right.Y, left - right.Z);
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0001E01B File Offset: 0x0001C21B
		public static Vector3 Subtract(float left, Vector3 right)
		{
			return new Vector3(left - right.X, left - right.Y, left - right.Z);
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0001E03A File Offset: 0x0001C23A
		public static void Multiply(ref Vector3 value, float scale, out Vector3 result)
		{
			result = new Vector3(value.X * scale, value.Y * scale, value.Z * scale);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0001E05F File Offset: 0x0001C25F
		public static Vector3 Multiply(Vector3 value, float scale)
		{
			return new Vector3(value.X * scale, value.Y * scale, value.Z * scale);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0001E07E File Offset: 0x0001C27E
		public static void Multiply(ref Vector3 left, ref Vector3 right, out Vector3 result)
		{
			result = new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0001E0B2 File Offset: 0x0001C2B2
		public static Vector3 Multiply(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0001E0E0 File Offset: 0x0001C2E0
		public static void Divide(ref Vector3 value, float scale, out Vector3 result)
		{
			result = new Vector3(value.X / scale, value.Y / scale, value.Z / scale);
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0001E105 File Offset: 0x0001C305
		public static Vector3 Divide(Vector3 value, float scale)
		{
			return new Vector3(value.X / scale, value.Y / scale, value.Z / scale);
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0001E124 File Offset: 0x0001C324
		public static void Divide(float scale, ref Vector3 value, out Vector3 result)
		{
			result = new Vector3(scale / value.X, scale / value.Y, scale / value.Z);
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0001E149 File Offset: 0x0001C349
		public static Vector3 Divide(float scale, Vector3 value)
		{
			return new Vector3(scale / value.X, scale / value.Y, scale / value.Z);
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0001E168 File Offset: 0x0001C368
		public static void Negate(ref Vector3 value, out Vector3 result)
		{
			result = new Vector3(-value.X, -value.Y, -value.Z);
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0001E18A File Offset: 0x0001C38A
		public static Vector3 Negate(Vector3 value)
		{
			return new Vector3(-value.X, -value.Y, -value.Z);
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0001E1A8 File Offset: 0x0001C3A8
		public static void Abs(ref Vector3 value, out Vector3 result)
		{
			result = new Vector3((value.X > 0f) ? value.X : (-value.X), (value.Y > 0f) ? value.Y : (-value.Y), (value.Z > 0f) ? value.Z : (-value.Z));
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0001E214 File Offset: 0x0001C414
		public static Vector3 Abs(Vector3 value)
		{
			return new Vector3((value.X > 0f) ? value.X : (-value.X), (value.Y > 0f) ? value.Y : (-value.Y), (value.Z > 0f) ? value.Z : (-value.Z));
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0001E27C File Offset: 0x0001C47C
		public static void Barycentric(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, float amount1, float amount2, out Vector3 result)
		{
			result = new Vector3(value1.X + amount1 * (value2.X - value1.X) + amount2 * (value3.X - value1.X), value1.Y + amount1 * (value2.Y - value1.Y) + amount2 * (value3.Y - value1.Y), value1.Z + amount1 * (value2.Z - value1.Z) + amount2 * (value3.Z - value1.Z));
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0001E30C File Offset: 0x0001C50C
		public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, float amount1, float amount2)
		{
			Vector3 result;
			Vector3.Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
			return result;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001E32C File Offset: 0x0001C52C
		public static void Clamp(ref Vector3 value, ref Vector3 min, ref Vector3 max, out Vector3 result)
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
			result = new Vector3(num, num2, num3);
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0001E3D0 File Offset: 0x0001C5D0
		public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
		{
			Vector3 result;
			Vector3.Clamp(ref value, ref min, ref max, out result);
			return result;
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0001E3EC File Offset: 0x0001C5EC
		public static void Cross(ref Vector3 left, ref Vector3 right, out Vector3 result)
		{
			result = new Vector3(left.Y * right.Z - left.Z * right.Y, left.Z * right.X - left.X * right.Z, left.X * right.Y - left.Y * right.X);
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0001E458 File Offset: 0x0001C658
		public static Vector3 Cross(Vector3 left, Vector3 right)
		{
			Vector3 result;
			Vector3.Cross(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0001E474 File Offset: 0x0001C674
		public static void Distance(ref Vector3 value1, ref Vector3 value2, out float result)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			float num3 = value1.Z - value2.Z;
			result = (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3));
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0001E4C0 File Offset: 0x0001C6C0
		public static float Distance(Vector3 value1, Vector3 value2)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			float num3 = value1.Z - value2.Z;
			return (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3));
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0001E508 File Offset: 0x0001C708
		public static void DistanceSquared(ref Vector3 value1, ref Vector3 value2, out float result)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			float num3 = value1.Z - value2.Z;
			result = num * num + num2 * num2 + num3 * num3;
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0001E54C File Offset: 0x0001C74C
		public static float DistanceSquared(Vector3 value1, Vector3 value2)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			float num3 = value1.Z - value2.Z;
			return num * num + num2 * num2 + num3 * num3;
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0001E58C File Offset: 0x0001C78C
		public static bool NearEqual(Vector3 left, Vector3 right, Vector3 epsilon)
		{
			return Vector3.NearEqual(ref left, ref right, ref epsilon);
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0001E59C File Offset: 0x0001C79C
		public static bool NearEqual(ref Vector3 left, ref Vector3 right, ref Vector3 epsilon)
		{
			return MathUtil.WithinEpsilon(left.X, right.X, epsilon.X) && MathUtil.WithinEpsilon(left.Y, right.Y, epsilon.Y) && MathUtil.WithinEpsilon(left.Z, right.Z, epsilon.Z);
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0001E5F4 File Offset: 0x0001C7F4
		public static void Dot(ref Vector3 left, ref Vector3 right, out float result)
		{
			result = left.X * right.X + left.Y * right.Y + left.Z * right.Z;
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0001E621 File Offset: 0x0001C821
		public static float Dot(Vector3 left, Vector3 right)
		{
			return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0001E64C File Offset: 0x0001C84C
		public static void Normalize(ref Vector3 value, out Vector3 result)
		{
			result = value;
			result.Normalize();
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0001E660 File Offset: 0x0001C860
		public static Vector3 Normalize(Vector3 value)
		{
			value.Normalize();
			return value;
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0001E66C File Offset: 0x0001C86C
		public static void Lerp(ref Vector3 start, ref Vector3 end, float amount, out Vector3 result)
		{
			result.X = MathUtil.Lerp(start.X, end.X, amount);
			result.Y = MathUtil.Lerp(start.Y, end.Y, amount);
			result.Z = MathUtil.Lerp(start.Z, end.Z, amount);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0001E6C4 File Offset: 0x0001C8C4
		public static Vector3 Lerp(Vector3 start, Vector3 end, float amount)
		{
			Vector3 result;
			Vector3.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0001E6DE File Offset: 0x0001C8DE
		public static void SmoothStep(ref Vector3 start, ref Vector3 end, float amount, out Vector3 result)
		{
			amount = MathUtil.SmoothStep(amount);
			Vector3.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0001E6F4 File Offset: 0x0001C8F4
		public static Vector3 SmoothStep(Vector3 start, Vector3 end, float amount)
		{
			Vector3 result;
			Vector3.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0001E710 File Offset: 0x0001C910
		public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float amount, out Vector3 result)
		{
			float num = amount * amount;
			float num2 = amount * num;
			float num3 = 2f * num2 - 3f * num + 1f;
			float num4 = -2f * num2 + 3f * num;
			float num5 = num2 - 2f * num + amount;
			float num6 = num2 - num;
			result.X = value1.X * num3 + value2.X * num4 + tangent1.X * num5 + tangent2.X * num6;
			result.Y = value1.Y * num3 + value2.Y * num4 + tangent1.Y * num5 + tangent2.Y * num6;
			result.Z = value1.Z * num3 + value2.Z * num4 + tangent1.Z * num5 + tangent2.Z * num6;
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0001E7E8 File Offset: 0x0001C9E8
		public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
		{
			Vector3 result;
			Vector3.Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
			return result;
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0001E808 File Offset: 0x0001CA08
		public static void CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, float amount, out Vector3 result)
		{
			float num = amount * amount;
			float num2 = amount * num;
			result.X = 0.5f * (2f * value2.X + (-value1.X + value3.X) * amount + (2f * value1.X - 5f * value2.X + 4f * value3.X - value4.X) * num + (-value1.X + 3f * value2.X - 3f * value3.X + value4.X) * num2);
			result.Y = 0.5f * (2f * value2.Y + (-value1.Y + value3.Y) * amount + (2f * value1.Y - 5f * value2.Y + 4f * value3.Y - value4.Y) * num + (-value1.Y + 3f * value2.Y - 3f * value3.Y + value4.Y) * num2);
			result.Z = 0.5f * (2f * value2.Z + (-value1.Z + value3.Z) * amount + (2f * value1.Z - 5f * value2.Z + 4f * value3.Z - value4.Z) * num + (-value1.Z + 3f * value2.Z - 3f * value3.Z + value4.Z) * num2);
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0001E9B4 File Offset: 0x0001CBB4
		public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float amount)
		{
			Vector3 result;
			Vector3.CatmullRom(ref value1, ref value2, ref value3, ref value4, amount, out result);
			return result;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0001E9D4 File Offset: 0x0001CBD4
		public static void Max(ref Vector3 left, ref Vector3 right, out Vector3 result)
		{
			result.X = ((left.X > right.X) ? left.X : right.X);
			result.Y = ((left.Y > right.Y) ? left.Y : right.Y);
			result.Z = ((left.Z > right.Z) ? left.Z : right.Z);
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0001EA48 File Offset: 0x0001CC48
		public static Vector3 Max(Vector3 left, Vector3 right)
		{
			Vector3 result;
			Vector3.Max(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0001EA64 File Offset: 0x0001CC64
		public static void Min(ref Vector3 left, ref Vector3 right, out Vector3 result)
		{
			result.X = ((left.X < right.X) ? left.X : right.X);
			result.Y = ((left.Y < right.Y) ? left.Y : right.Y);
			result.Z = ((left.Z < right.Z) ? left.Z : right.Z);
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0001EAD8 File Offset: 0x0001CCD8
		public static Vector3 Min(Vector3 left, Vector3 right)
		{
			Vector3 result;
			Vector3.Min(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0001EAF4 File Offset: 0x0001CCF4
		public static void Project(ref Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, ref Matrix worldViewProjection, out Vector3 result)
		{
			Vector3 vector2 = default(Vector3);
			Vector3.TransformCoordinate(ref vector, ref worldViewProjection, out vector2);
			result = new Vector3((1f + vector2.X) * 0.5f * width + x, (1f - vector2.Y) * 0.5f * height + y, vector2.Z * (maxZ - minZ) + minZ);
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0001EB5C File Offset: 0x0001CD5C
		public static Vector3 Project(Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, Matrix worldViewProjection)
		{
			Vector3 result;
			Vector3.Project(ref vector, x, y, width, height, minZ, maxZ, ref worldViewProjection, out result);
			return result;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0001EB80 File Offset: 0x0001CD80
		public static void Unproject(ref Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, ref Matrix worldViewProjection, out Vector3 result)
		{
			Vector3 vector2 = default(Vector3);
			Matrix matrix = default(Matrix);
			Matrix.Invert(ref worldViewProjection, out matrix);
			vector2.X = (vector.X - x) / width * 2f - 1f;
			vector2.Y = -((vector.Y - y) / height * 2f - 1f);
			vector2.Z = (vector.Z - minZ) / (maxZ - minZ);
			Vector3.TransformCoordinate(ref vector2, ref matrix, out result);
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0001EC04 File Offset: 0x0001CE04
		public static Vector3 Unproject(Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, Matrix worldViewProjection)
		{
			Vector3 result;
			Vector3.Unproject(ref vector, x, y, width, height, minZ, maxZ, ref worldViewProjection, out result);
			return result;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001EC28 File Offset: 0x0001CE28
		public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
		{
			float num = vector.X * normal.X + vector.Y * normal.Y + vector.Z * normal.Z;
			result.X = vector.X - 2f * num * normal.X;
			result.Y = vector.Y - 2f * num * normal.Y;
			result.Z = vector.Z - 2f * num * normal.Z;
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0001ECB0 File Offset: 0x0001CEB0
		public static Vector3 Reflect(Vector3 vector, Vector3 normal)
		{
			Vector3 result;
			Vector3.Reflect(ref vector, ref normal, out result);
			return result;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0001ECCC File Offset: 0x0001CECC
		public static void Orthogonalize(Vector3[] destination, params Vector3[] source)
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
				Vector3 vector = source[i];
				for (int j = 0; j < i; j++)
				{
					vector -= Vector3.Dot(destination[j], vector) / Vector3.Dot(destination[j], destination[j]) * destination[j];
				}
				destination[i] = vector;
			}
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0001ED6C File Offset: 0x0001CF6C
		public static void Orthonormalize(Vector3[] destination, params Vector3[] source)
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
				Vector3 vector = source[i];
				for (int j = 0; j < i; j++)
				{
					vector -= Vector3.Dot(destination[j], vector) * destination[j];
				}
				vector.Normalize();
				destination[i] = vector;
			}
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001EE00 File Offset: 0x0001D000
		public static void Transform(ref Vector3 vector, ref Quaternion rotation, out Vector3 result)
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
			result = new Vector3(vector.X * (1f - num10 - num12) + vector.Y * (num8 - num6) + vector.Z * (num9 + num5), vector.X * (num8 + num6) + vector.Y * (1f - num7 - num12) + vector.Z * (num11 - num4), vector.X * (num9 - num5) + vector.Y * (num11 + num4) + vector.Z * (1f - num7 - num10));
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001EF20 File Offset: 0x0001D120
		public static Vector3 Transform(Vector3 vector, Quaternion rotation)
		{
			Vector3 result;
			Vector3.Transform(ref vector, ref rotation, out result);
			return result;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0001EF3C File Offset: 0x0001D13C
		public static void Transform(Vector3[] source, ref Quaternion rotation, Vector3[] destination)
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
				destination[i] = new Vector3(source[i].X * num13 + source[i].Y * num14 + source[i].Z * num15, source[i].X * num16 + source[i].Y * num17 + source[i].Z * num18, source[i].X * num19 + source[i].Y * num20 + source[i].Z * num21);
			}
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0001F108 File Offset: 0x0001D308
		public static void Transform(ref Vector3 vector, ref Matrix3x3 transform, out Vector3 result)
		{
			result = new Vector3(vector.X * transform.M11 + vector.Y * transform.M21 + vector.Z * transform.M31, vector.X * transform.M12 + vector.Y * transform.M22 + vector.Z * transform.M32, vector.X * transform.M13 + vector.Y * transform.M23 + vector.Z * transform.M33);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0001F19C File Offset: 0x0001D39C
		public static Vector3 Transform(Vector3 vector, Matrix3x3 transform)
		{
			Vector3 result;
			Vector3.Transform(ref vector, ref transform, out result);
			return result;
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0001F1B8 File Offset: 0x0001D3B8
		public static void Transform(ref Vector3 vector, ref Matrix transform, out Vector3 result)
		{
			Vector4 value;
			Vector3.Transform(ref vector, ref transform, out value);
			result = (Vector3)value;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0001F1DC File Offset: 0x0001D3DC
		public static void Transform(ref Vector3 vector, ref Matrix transform, out Vector4 result)
		{
			result = new Vector4(vector.X * transform.M11 + vector.Y * transform.M21 + vector.Z * transform.M31 + transform.M41, vector.X * transform.M12 + vector.Y * transform.M22 + vector.Z * transform.M32 + transform.M42, vector.X * transform.M13 + vector.Y * transform.M23 + vector.Z * transform.M33 + transform.M43, vector.X * transform.M14 + vector.Y * transform.M24 + vector.Z * transform.M34 + transform.M44);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0001F2B4 File Offset: 0x0001D4B4
		public static Vector4 Transform(Vector3 vector, Matrix transform)
		{
			Vector4 result;
			Vector3.Transform(ref vector, ref transform, out result);
			return result;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0001F2D0 File Offset: 0x0001D4D0
		public static void Transform(Vector3[] source, ref Matrix transform, Vector4[] destination)
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
				Vector3.Transform(ref source[i], ref transform, out destination[i]);
			}
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0001F334 File Offset: 0x0001D534
		public static void TransformCoordinate(ref Vector3 coordinate, ref Matrix transform, out Vector3 result)
		{
			Vector4 vector = default(Vector4);
			vector.X = coordinate.X * transform.M11 + coordinate.Y * transform.M21 + coordinate.Z * transform.M31 + transform.M41;
			vector.Y = coordinate.X * transform.M12 + coordinate.Y * transform.M22 + coordinate.Z * transform.M32 + transform.M42;
			vector.Z = coordinate.X * transform.M13 + coordinate.Y * transform.M23 + coordinate.Z * transform.M33 + transform.M43;
			vector.W = 1f / (coordinate.X * transform.M14 + coordinate.Y * transform.M24 + coordinate.Z * transform.M34 + transform.M44);
			result = new Vector3(vector.X * vector.W, vector.Y * vector.W, vector.Z * vector.W);
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0001F460 File Offset: 0x0001D660
		public static Vector3 TransformCoordinate(Vector3 coordinate, Matrix transform)
		{
			Vector3 result;
			Vector3.TransformCoordinate(ref coordinate, ref transform, out result);
			return result;
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0001F47C File Offset: 0x0001D67C
		public static void TransformCoordinate(Vector3[] source, ref Matrix transform, Vector3[] destination)
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
				Vector3.TransformCoordinate(ref source[i], ref transform, out destination[i]);
			}
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0001F4E0 File Offset: 0x0001D6E0
		public static void TransformNormal(ref Vector3 normal, ref Matrix transform, out Vector3 result)
		{
			result = new Vector3(normal.X * transform.M11 + normal.Y * transform.M21 + normal.Z * transform.M31, normal.X * transform.M12 + normal.Y * transform.M22 + normal.Z * transform.M32, normal.X * transform.M13 + normal.Y * transform.M23 + normal.Z * transform.M33);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0001F574 File Offset: 0x0001D774
		public static Vector3 TransformNormal(Vector3 normal, Matrix transform)
		{
			Vector3 result;
			Vector3.TransformNormal(ref normal, ref transform, out result);
			return result;
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0001F590 File Offset: 0x0001D790
		public static void TransformNormal(Vector3[] source, ref Matrix transform, Vector3[] destination)
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
				Vector3.TransformNormal(ref source[i], ref transform, out destination[i]);
			}
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0001DED5 File Offset: 0x0001C0D5
		public static Vector3 operator +(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0001E0B2 File Offset: 0x0001C2B2
		public static Vector3 operator *(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00002505 File Offset: 0x00000705
		public static Vector3 operator +(Vector3 value)
		{
			return value;
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0001DF7E File Offset: 0x0001C17E
		public static Vector3 operator -(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0001E18A File Offset: 0x0001C38A
		public static Vector3 operator -(Vector3 value)
		{
			return new Vector3(-value.X, -value.Y, -value.Z);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0001F5F3 File Offset: 0x0001D7F3
		public static Vector3 operator *(float scale, Vector3 value)
		{
			return new Vector3(value.X * scale, value.Y * scale, value.Z * scale);
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0001E05F File Offset: 0x0001C25F
		public static Vector3 operator *(Vector3 value, float scale)
		{
			return new Vector3(value.X * scale, value.Y * scale, value.Z * scale);
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0001E105 File Offset: 0x0001C305
		public static Vector3 operator /(Vector3 value, float scale)
		{
			return new Vector3(value.X / scale, value.Y / scale, value.Z / scale);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0001E149 File Offset: 0x0001C349
		public static Vector3 operator /(float scale, Vector3 value)
		{
			return new Vector3(scale / value.X, scale / value.Y, scale / value.Z);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0001F612 File Offset: 0x0001D812
		public static Vector3 operator /(Vector3 value, Vector3 scale)
		{
			return new Vector3(value.X / scale.X, value.Y / scale.Y, value.Z / scale.Z);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x0001DF2B File Offset: 0x0001C12B
		public static Vector3 operator +(Vector3 value, float scalar)
		{
			return new Vector3(value.X + scalar, value.Y + scalar, value.Z + scalar);
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0001F640 File Offset: 0x0001D840
		public static Vector3 operator +(float scalar, Vector3 value)
		{
			return new Vector3(scalar + value.X, scalar + value.Y, scalar + value.Z);
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x0001DFD4 File Offset: 0x0001C1D4
		public static Vector3 operator -(Vector3 value, float scalar)
		{
			return new Vector3(value.X - scalar, value.Y - scalar, value.Z - scalar);
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0001E01B File Offset: 0x0001C21B
		public static Vector3 operator -(float scalar, Vector3 value)
		{
			return new Vector3(scalar - value.X, scalar - value.Y, scalar - value.Z);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0001F65F File Offset: 0x0001D85F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Vector3 left, Vector3 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0001F66A File Offset: 0x0001D86A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Vector3 left, Vector3 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0001F678 File Offset: 0x0001D878
		public static explicit operator Vector2(Vector3 value)
		{
			return new Vector2(value.X, value.Y);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0001F68B File Offset: 0x0001D88B
		public static explicit operator Vector4(Vector3 value)
		{
			return new Vector4(value, 0f);
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0001F698 File Offset: 0x0001D898
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2}", new object[]
			{
				this.X,
				this.Y,
				this.Z
			});
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0001F6E4 File Offset: 0x0001D8E4
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

		// Token: 0x060006B1 RID: 1713 RVA: 0x0001F752 File Offset: 0x0001D952
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "X:{0} Y:{1} Z:{2}", new object[]
			{
				this.X,
				this.Y,
				this.Z
			});
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0001F790 File Offset: 0x0001D990
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "X:{0} Y:{1} Z:{2}", new object[]
			{
				this.X.ToString(format, formatProvider),
				this.Y.ToString(format, formatProvider),
				this.Z.ToString(format, formatProvider)
			});
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0001F7E9 File Offset: 0x0001D9E9
		public override int GetHashCode()
		{
			return (this.X.GetHashCode() * 397 ^ this.Y.GetHashCode()) * 397 ^ this.Z.GetHashCode();
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0001F81A File Offset: 0x0001DA1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Vector3 other)
		{
			return MathUtil.NearEqual(other.X, this.X) && MathUtil.NearEqual(other.Y, this.Y) && MathUtil.NearEqual(other.Z, this.Z);
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0001F855 File Offset: 0x0001DA55
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Vector3 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0001F860 File Offset: 0x0001DA60
		public override bool Equals(object value)
		{
			if (!(value is Vector3))
			{
				return false;
			}
			Vector3 vector = (Vector3)value;
			return this.Equals(ref vector);
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x0001F886 File Offset: 0x0001DA86
		public unsafe static implicit operator RawVector3(Vector3 value)
		{
			return *(RawVector3*)(&value);
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x0001F890 File Offset: 0x0001DA90
		public unsafe static implicit operator Vector3(RawVector3 value)
		{
			return *(Vector3*)(&value);
		}

		// Token: 0x0400016D RID: 365
		public static readonly int SizeInBytes = Utilities.SizeOf<Vector3>();

		// Token: 0x0400016E RID: 366
		public static readonly Vector3 Zero = default(Vector3);

		// Token: 0x0400016F RID: 367
		public static readonly Vector3 UnitX = new Vector3(1f, 0f, 0f);

		// Token: 0x04000170 RID: 368
		public static readonly Vector3 UnitY = new Vector3(0f, 1f, 0f);

		// Token: 0x04000171 RID: 369
		public static readonly Vector3 UnitZ = new Vector3(0f, 0f, 1f);

		// Token: 0x04000172 RID: 370
		public static readonly Vector3 One = new Vector3(1f, 1f, 1f);

		// Token: 0x04000173 RID: 371
		public static readonly Vector3 Up = new Vector3(0f, 1f, 0f);

		// Token: 0x04000174 RID: 372
		public static readonly Vector3 Down = new Vector3(0f, -1f, 0f);

		// Token: 0x04000175 RID: 373
		public static readonly Vector3 Left = new Vector3(-1f, 0f, 0f);

		// Token: 0x04000176 RID: 374
		public static readonly Vector3 Right = new Vector3(1f, 0f, 0f);

		// Token: 0x04000177 RID: 375
		public static readonly Vector3 ForwardRH = new Vector3(0f, 0f, -1f);

		// Token: 0x04000178 RID: 376
		public static readonly Vector3 ForwardLH = new Vector3(0f, 0f, 1f);

		// Token: 0x04000179 RID: 377
		public static readonly Vector3 BackwardRH = new Vector3(0f, 0f, 1f);

		// Token: 0x0400017A RID: 378
		public static readonly Vector3 BackwardLH = new Vector3(0f, 0f, -1f);

		// Token: 0x0400017B RID: 379
		public float X;

		// Token: 0x0400017C RID: 380
		public float Y;

		// Token: 0x0400017D RID: 381
		public float Z;
	}
}

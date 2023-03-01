using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000025 RID: 37
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Vector2 : IEquatable<Vector2>, IFormattable
	{
		// Token: 0x060005E1 RID: 1505 RVA: 0x0001C878 File Offset: 0x0001AA78
		public Vector2(float value)
		{
			this.X = value;
			this.Y = value;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0001C888 File Offset: 0x0001AA88
		public Vector2(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0001C898 File Offset: 0x0001AA98
		public Vector2(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 2)
			{
				throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
			}
			this.X = values[0];
			this.Y = values[1];
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x0001C8D0 File Offset: 0x0001AAD0
		public bool IsNormalized
		{
			get
			{
				return MathUtil.IsOne(this.X * this.X + this.Y * this.Y);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x0001C8F2 File Offset: 0x0001AAF2
		public bool IsZero
		{
			get
			{
				return this.X == 0f && this.Y == 0f;
			}
		}

		// Token: 0x1700007A RID: 122
		public float this[int index]
		{
			get
			{
				if (index == 0)
				{
					return this.X;
				}
				if (index != 1)
				{
					throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
				}
				return this.Y;
			}
			set
			{
				if (index == 0)
				{
					this.X = value;
					return;
				}
				if (index != 1)
				{
					throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
				}
				this.Y = value;
			}
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0001C962 File Offset: 0x0001AB62
		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0001C986 File Offset: 0x0001AB86
		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y;
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0001C9A4 File Offset: 0x0001ABA4
		public void Normalize()
		{
			float num = this.Length();
			if (!MathUtil.IsZero(num))
			{
				float num2 = 1f / num;
				this.X *= num2;
				this.Y *= num2;
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0001C9E4 File Offset: 0x0001ABE4
		public float[] ToArray()
		{
			return new float[]
			{
				this.X,
				this.Y
			};
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0001C9FE File Offset: 0x0001ABFE
		public static void Add(ref Vector2 left, ref Vector2 right, out Vector2 result)
		{
			result = new Vector2(left.X + right.X, left.Y + right.Y);
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0001CA25 File Offset: 0x0001AC25
		public static Vector2 Add(Vector2 left, Vector2 right)
		{
			return new Vector2(left.X + right.X, left.Y + right.Y);
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0001CA46 File Offset: 0x0001AC46
		public static void Add(ref Vector2 left, ref float right, out Vector2 result)
		{
			result = new Vector2(left.X + right, left.Y + right);
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0001CA65 File Offset: 0x0001AC65
		public static Vector2 Add(Vector2 left, float right)
		{
			return new Vector2(left.X + right, left.Y + right);
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0001CA7C File Offset: 0x0001AC7C
		public static void Subtract(ref Vector2 left, ref Vector2 right, out Vector2 result)
		{
			result = new Vector2(left.X - right.X, left.Y - right.Y);
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0001CAA3 File Offset: 0x0001ACA3
		public static Vector2 Subtract(Vector2 left, Vector2 right)
		{
			return new Vector2(left.X - right.X, left.Y - right.Y);
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0001CAC4 File Offset: 0x0001ACC4
		public static void Subtract(ref Vector2 left, ref float right, out Vector2 result)
		{
			result = new Vector2(left.X - right, left.Y - right);
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001CAE3 File Offset: 0x0001ACE3
		public static Vector2 Subtract(Vector2 left, float right)
		{
			return new Vector2(left.X - right, left.Y - right);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0001CAFA File Offset: 0x0001ACFA
		public static void Subtract(ref float left, ref Vector2 right, out Vector2 result)
		{
			result = new Vector2(left - right.X, left - right.Y);
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0001CB19 File Offset: 0x0001AD19
		public static Vector2 Subtract(float left, Vector2 right)
		{
			return new Vector2(left - right.X, left - right.Y);
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0001CB30 File Offset: 0x0001AD30
		public static void Multiply(ref Vector2 value, float scale, out Vector2 result)
		{
			result = new Vector2(value.X * scale, value.Y * scale);
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0001CB4D File Offset: 0x0001AD4D
		public static Vector2 Multiply(Vector2 value, float scale)
		{
			return new Vector2(value.X * scale, value.Y * scale);
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0001CB64 File Offset: 0x0001AD64
		public static void Multiply(ref Vector2 left, ref Vector2 right, out Vector2 result)
		{
			result = new Vector2(left.X * right.X, left.Y * right.Y);
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0001CB8B File Offset: 0x0001AD8B
		public static Vector2 Multiply(Vector2 left, Vector2 right)
		{
			return new Vector2(left.X * right.X, left.Y * right.Y);
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0001CBAC File Offset: 0x0001ADAC
		public static void Divide(ref Vector2 value, float scale, out Vector2 result)
		{
			result = new Vector2(value.X / scale, value.Y / scale);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0001CBC9 File Offset: 0x0001ADC9
		public static Vector2 Divide(Vector2 value, float scale)
		{
			return new Vector2(value.X / scale, value.Y / scale);
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0001CBE0 File Offset: 0x0001ADE0
		public static void Divide(float scale, ref Vector2 value, out Vector2 result)
		{
			result = new Vector2(scale / value.X, scale / value.Y);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0001CBFD File Offset: 0x0001ADFD
		public static Vector2 Divide(float scale, Vector2 value)
		{
			return new Vector2(scale / value.X, scale / value.Y);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0001CC14 File Offset: 0x0001AE14
		public static void Negate(ref Vector2 value, out Vector2 result)
		{
			result = new Vector2(-value.X, -value.Y);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0001CC2F File Offset: 0x0001AE2F
		public static Vector2 Negate(Vector2 value)
		{
			return new Vector2(-value.X, -value.Y);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0001CC44 File Offset: 0x0001AE44
		public static void Abs(ref Vector2 value, out Vector2 result)
		{
			result = new Vector2((value.X > 0f) ? value.X : (-value.X), (value.Y > 0f) ? value.Y : (-value.Y));
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001CC94 File Offset: 0x0001AE94
		public static Vector2 Abs(Vector2 value)
		{
			return new Vector2((value.X > 0f) ? value.X : (-value.X), (value.Y > 0f) ? value.Y : (-value.Y));
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0001CCD4 File Offset: 0x0001AED4
		public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float amount1, float amount2, out Vector2 result)
		{
			result = new Vector2(value1.X + amount1 * (value2.X - value1.X) + amount2 * (value3.X - value1.X), value1.Y + amount1 * (value2.Y - value1.Y) + amount2 * (value3.Y - value1.Y));
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0001CD3C File Offset: 0x0001AF3C
		public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
		{
			Vector2 result;
			Vector2.Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
			return result;
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0001CD5C File Offset: 0x0001AF5C
		public static void Clamp(ref Vector2 value, ref Vector2 min, ref Vector2 max, out Vector2 result)
		{
			float num = value.X;
			num = ((num > max.X) ? max.X : num);
			num = ((num < min.X) ? min.X : num);
			float num2 = value.Y;
			num2 = ((num2 > max.Y) ? max.Y : num2);
			num2 = ((num2 < min.Y) ? min.Y : num2);
			result = new Vector2(num, num2);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0001CDD0 File Offset: 0x0001AFD0
		public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
		{
			Vector2 result;
			Vector2.Clamp(ref value, ref min, ref max, out result);
			return result;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0001CDEC File Offset: 0x0001AFEC
		public void Saturate()
		{
			this.X = ((this.X < 0f) ? 0f : ((this.X > 1f) ? 1f : this.X));
			this.Y = ((this.Y < 0f) ? 0f : ((this.Y > 1f) ? 1f : this.Y));
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0001CE64 File Offset: 0x0001B064
		public static void Distance(ref Vector2 value1, ref Vector2 value2, out float result)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			result = (float)Math.Sqrt((double)(num * num + num2 * num2));
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0001CEA0 File Offset: 0x0001B0A0
		public static float Distance(Vector2 value1, Vector2 value2)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			return (float)Math.Sqrt((double)(num * num + num2 * num2));
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0001CED8 File Offset: 0x0001B0D8
		public static void DistanceSquared(ref Vector2 value1, ref Vector2 value2, out float result)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			result = num * num + num2 * num2;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0001CF0C File Offset: 0x0001B10C
		public static float DistanceSquared(Vector2 value1, Vector2 value2)
		{
			float num = value1.X - value2.X;
			float num2 = value1.Y - value2.Y;
			return num * num + num2 * num2;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0001CF3A File Offset: 0x0001B13A
		public static void Dot(ref Vector2 left, ref Vector2 right, out float result)
		{
			result = left.X * right.X + left.Y * right.Y;
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x0001CF59 File Offset: 0x0001B159
		public static float Dot(Vector2 left, Vector2 right)
		{
			return left.X * right.X + left.Y * right.Y;
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0001CF76 File Offset: 0x0001B176
		public static void Normalize(ref Vector2 value, out Vector2 result)
		{
			result = value;
			result.Normalize();
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0001CF8A File Offset: 0x0001B18A
		public static Vector2 Normalize(Vector2 value)
		{
			value.Normalize();
			return value;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0001CF94 File Offset: 0x0001B194
		public static void Lerp(ref Vector2 start, ref Vector2 end, float amount, out Vector2 result)
		{
			result.X = MathUtil.Lerp(start.X, end.X, amount);
			result.Y = MathUtil.Lerp(start.Y, end.Y, amount);
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0001CFC8 File Offset: 0x0001B1C8
		public static Vector2 Lerp(Vector2 start, Vector2 end, float amount)
		{
			Vector2 result;
			Vector2.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0001CFE2 File Offset: 0x0001B1E2
		public static void SmoothStep(ref Vector2 start, ref Vector2 end, float amount, out Vector2 result)
		{
			amount = MathUtil.SmoothStep(amount);
			Vector2.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0001CFF8 File Offset: 0x0001B1F8
		public static Vector2 SmoothStep(Vector2 start, Vector2 end, float amount)
		{
			Vector2 result;
			Vector2.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0001D014 File Offset: 0x0001B214
		public static void Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, float amount, out Vector2 result)
		{
			float num = amount * amount;
			float num2 = amount * num;
			float num3 = 2f * num2 - 3f * num + 1f;
			float num4 = -2f * num2 + 3f * num;
			float num5 = num2 - 2f * num + amount;
			float num6 = num2 - num;
			result.X = value1.X * num3 + value2.X * num4 + tangent1.X * num5 + tangent2.X * num6;
			result.Y = value1.Y * num3 + value2.Y * num4 + tangent1.Y * num5 + tangent2.Y * num6;
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0001D0C0 File Offset: 0x0001B2C0
		public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float amount)
		{
			Vector2 result;
			Vector2.Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
			return result;
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0001D0E0 File Offset: 0x0001B2E0
		public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float amount, out Vector2 result)
		{
			float num = amount * amount;
			float num2 = amount * num;
			result.X = 0.5f * (2f * value2.X + (-value1.X + value3.X) * amount + (2f * value1.X - 5f * value2.X + 4f * value3.X - value4.X) * num + (-value1.X + 3f * value2.X - 3f * value3.X + value4.X) * num2);
			result.Y = 0.5f * (2f * value2.Y + (-value1.Y + value3.Y) * amount + (2f * value1.Y - 5f * value2.Y + 4f * value3.Y - value4.Y) * num + (-value1.Y + 3f * value2.Y - 3f * value3.Y + value4.Y) * num2);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0001D204 File Offset: 0x0001B404
		public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
		{
			Vector2 result;
			Vector2.CatmullRom(ref value1, ref value2, ref value3, ref value4, amount, out result);
			return result;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0001D224 File Offset: 0x0001B424
		public static void Max(ref Vector2 left, ref Vector2 right, out Vector2 result)
		{
			result.X = ((left.X > right.X) ? left.X : right.X);
			result.Y = ((left.Y > right.Y) ? left.Y : right.Y);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0001D278 File Offset: 0x0001B478
		public static Vector2 Max(Vector2 left, Vector2 right)
		{
			Vector2 result;
			Vector2.Max(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0001D294 File Offset: 0x0001B494
		public static void Min(ref Vector2 left, ref Vector2 right, out Vector2 result)
		{
			result.X = ((left.X < right.X) ? left.X : right.X);
			result.Y = ((left.Y < right.Y) ? left.Y : right.Y);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0001D2E8 File Offset: 0x0001B4E8
		public static Vector2 Min(Vector2 left, Vector2 right)
		{
			Vector2 result;
			Vector2.Min(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0001D304 File Offset: 0x0001B504
		public static void Reflect(ref Vector2 vector, ref Vector2 normal, out Vector2 result)
		{
			float num = vector.X * normal.X + vector.Y * normal.Y;
			result.X = vector.X - 2f * num * normal.X;
			result.Y = vector.Y - 2f * num * normal.Y;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0001D364 File Offset: 0x0001B564
		public static Vector2 Reflect(Vector2 vector, Vector2 normal)
		{
			Vector2 result;
			Vector2.Reflect(ref vector, ref normal, out result);
			return result;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0001D380 File Offset: 0x0001B580
		public static void Orthogonalize(Vector2[] destination, params Vector2[] source)
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
				Vector2 vector = source[i];
				for (int j = 0; j < i; j++)
				{
					vector -= Vector2.Dot(destination[j], vector) / Vector2.Dot(destination[j], destination[j]) * destination[j];
				}
				destination[i] = vector;
			}
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0001D420 File Offset: 0x0001B620
		public static void Orthonormalize(Vector2[] destination, params Vector2[] source)
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
				Vector2 vector = source[i];
				for (int j = 0; j < i; j++)
				{
					vector -= Vector2.Dot(destination[j], vector) * destination[j];
				}
				vector.Normalize();
				destination[i] = vector;
			}
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0001D4B4 File Offset: 0x0001B6B4
		public static void Transform(ref Vector2 vector, ref Quaternion rotation, out Vector2 result)
		{
			float num = rotation.X + rotation.X;
			float num2 = rotation.Y + rotation.Y;
			float num3 = rotation.Z + rotation.Z;
			float num4 = rotation.W * num3;
			float num5 = rotation.X * num;
			float num6 = rotation.X * num2;
			float num7 = rotation.Y * num2;
			float num8 = rotation.Z * num3;
			result = new Vector2(vector.X * (1f - num7 - num8) + vector.Y * (num6 - num4), vector.X * (num6 + num4) + vector.Y * (1f - num5 - num8));
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0001D564 File Offset: 0x0001B764
		public static Vector2 Transform(Vector2 vector, Quaternion rotation)
		{
			Vector2 result;
			Vector2.Transform(ref vector, ref rotation, out result);
			return result;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0001D580 File Offset: 0x0001B780
		public static void Transform(Vector2[] source, ref Quaternion rotation, Vector2[] destination)
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
			float num4 = rotation.W * num3;
			float num5 = rotation.X * num;
			float num6 = rotation.X * num2;
			float num7 = rotation.Y * num2;
			float num8 = rotation.Z * num3;
			float num9 = 1f - num7 - num8;
			float num10 = num6 - num4;
			float num11 = num6 + num4;
			float num12 = 1f - num5 - num8;
			for (int i = 0; i < source.Length; i++)
			{
				destination[i] = new Vector2(source[i].X * num9 + source[i].Y * num10, source[i].X * num11 + source[i].Y * num12);
			}
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0001D6A0 File Offset: 0x0001B8A0
		public static void Transform(ref Vector2 vector, ref Matrix transform, out Vector4 result)
		{
			result = new Vector4(vector.X * transform.M11 + vector.Y * transform.M21 + transform.M41, vector.X * transform.M12 + vector.Y * transform.M22 + transform.M42, vector.X * transform.M13 + vector.Y * transform.M23 + transform.M43, vector.X * transform.M14 + vector.Y * transform.M24 + transform.M44);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0001D740 File Offset: 0x0001B940
		public static Vector4 Transform(Vector2 vector, Matrix transform)
		{
			Vector4 result;
			Vector2.Transform(ref vector, ref transform, out result);
			return result;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0001D75C File Offset: 0x0001B95C
		public static void Transform(Vector2[] source, ref Matrix transform, Vector4[] destination)
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
				Vector2.Transform(ref source[i], ref transform, out destination[i]);
			}
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0001D7C0 File Offset: 0x0001B9C0
		public static void TransformCoordinate(ref Vector2 coordinate, ref Matrix transform, out Vector2 result)
		{
			Vector4 vector = default(Vector4);
			vector.X = coordinate.X * transform.M11 + coordinate.Y * transform.M21 + transform.M41;
			vector.Y = coordinate.X * transform.M12 + coordinate.Y * transform.M22 + transform.M42;
			vector.Z = coordinate.X * transform.M13 + coordinate.Y * transform.M23 + transform.M43;
			vector.W = 1f / (coordinate.X * transform.M14 + coordinate.Y * transform.M24 + transform.M44);
			result = new Vector2(vector.X * vector.W, vector.Y * vector.W);
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0001D8A4 File Offset: 0x0001BAA4
		public static Vector2 TransformCoordinate(Vector2 coordinate, Matrix transform)
		{
			Vector2 result;
			Vector2.TransformCoordinate(ref coordinate, ref transform, out result);
			return result;
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0001D8C0 File Offset: 0x0001BAC0
		public static void TransformCoordinate(Vector2[] source, ref Matrix transform, Vector2[] destination)
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
				Vector2.TransformCoordinate(ref source[i], ref transform, out destination[i]);
			}
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0001D924 File Offset: 0x0001BB24
		public static void TransformNormal(ref Vector2 normal, ref Matrix transform, out Vector2 result)
		{
			result = new Vector2(normal.X * transform.M11 + normal.Y * transform.M21, normal.X * transform.M12 + normal.Y * transform.M22);
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001D974 File Offset: 0x0001BB74
		public static Vector2 TransformNormal(Vector2 normal, Matrix transform)
		{
			Vector2 result;
			Vector2.TransformNormal(ref normal, ref transform, out result);
			return result;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0001D990 File Offset: 0x0001BB90
		public static void TransformNormal(Vector2[] source, ref Matrix transform, Vector2[] destination)
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
				Vector2.TransformNormal(ref source[i], ref transform, out destination[i]);
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0001CA25 File Offset: 0x0001AC25
		public static Vector2 operator +(Vector2 left, Vector2 right)
		{
			return new Vector2(left.X + right.X, left.Y + right.Y);
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001CB8B File Offset: 0x0001AD8B
		public static Vector2 operator *(Vector2 left, Vector2 right)
		{
			return new Vector2(left.X * right.X, left.Y * right.Y);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00002505 File Offset: 0x00000705
		public static Vector2 operator +(Vector2 value)
		{
			return value;
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001CAA3 File Offset: 0x0001ACA3
		public static Vector2 operator -(Vector2 left, Vector2 right)
		{
			return new Vector2(left.X - right.X, left.Y - right.Y);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0001CC2F File Offset: 0x0001AE2F
		public static Vector2 operator -(Vector2 value)
		{
			return new Vector2(-value.X, -value.Y);
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0001D9F3 File Offset: 0x0001BBF3
		public static Vector2 operator *(float scale, Vector2 value)
		{
			return new Vector2(value.X * scale, value.Y * scale);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0001CB4D File Offset: 0x0001AD4D
		public static Vector2 operator *(Vector2 value, float scale)
		{
			return new Vector2(value.X * scale, value.Y * scale);
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001CBC9 File Offset: 0x0001ADC9
		public static Vector2 operator /(Vector2 value, float scale)
		{
			return new Vector2(value.X / scale, value.Y / scale);
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0001CBFD File Offset: 0x0001ADFD
		public static Vector2 operator /(float scale, Vector2 value)
		{
			return new Vector2(scale / value.X, scale / value.Y);
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0001DA0A File Offset: 0x0001BC0A
		public static Vector2 operator /(Vector2 value, Vector2 scale)
		{
			return new Vector2(value.X / scale.X, value.Y / scale.Y);
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0001CA65 File Offset: 0x0001AC65
		public static Vector2 operator +(Vector2 value, float scalar)
		{
			return new Vector2(value.X + scalar, value.Y + scalar);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0001DA2B File Offset: 0x0001BC2B
		public static Vector2 operator +(float scalar, Vector2 value)
		{
			return new Vector2(scalar + value.X, scalar + value.Y);
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0001CAE3 File Offset: 0x0001ACE3
		public static Vector2 operator -(Vector2 value, float scalar)
		{
			return new Vector2(value.X - scalar, value.Y - scalar);
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0001CB19 File Offset: 0x0001AD19
		public static Vector2 operator -(float scalar, Vector2 value)
		{
			return new Vector2(scalar - value.X, scalar - value.Y);
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0001DA42 File Offset: 0x0001BC42
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Vector2 left, Vector2 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001DA4D File Offset: 0x0001BC4D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Vector2 left, Vector2 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0001DA5B File Offset: 0x0001BC5B
		public static explicit operator Vector3(Vector2 value)
		{
			return new Vector3(value, 0f);
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0001DA68 File Offset: 0x0001BC68
		public static explicit operator Vector4(Vector2 value)
		{
			return new Vector4(value, 0f, 0f);
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x0001DA7A File Offset: 0x0001BC7A
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[]
			{
				this.X,
				this.Y
			});
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0001DAB0 File Offset: 0x0001BCB0
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[]
			{
				this.X.ToString(format, CultureInfo.CurrentCulture),
				this.Y.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0001DB0A File Offset: 0x0001BD0A
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "X:{0} Y:{1}", new object[]
			{
				this.X,
				this.Y
			});
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0001DB39 File Offset: 0x0001BD39
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "X:{0} Y:{1}", new object[]
			{
				this.X.ToString(format, formatProvider),
				this.Y.ToString(format, formatProvider)
			});
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0001DB77 File Offset: 0x0001BD77
		public override int GetHashCode()
		{
			return this.X.GetHashCode() * 397 ^ this.Y.GetHashCode();
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0001DB96 File Offset: 0x0001BD96
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Vector2 other)
		{
			return MathUtil.NearEqual(other.X, this.X) && MathUtil.NearEqual(other.Y, this.Y);
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0001DBBE File Offset: 0x0001BDBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Vector2 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001DBC8 File Offset: 0x0001BDC8
		public override bool Equals(object value)
		{
			if (!(value is Vector2))
			{
				return false;
			}
			Vector2 vector = (Vector2)value;
			return this.Equals(ref vector);
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0001DBEE File Offset: 0x0001BDEE
		public unsafe static implicit operator RawVector2(Vector2 value)
		{
			return *(RawVector2*)(&value);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0001DBF8 File Offset: 0x0001BDF8
		public unsafe static implicit operator Vector2(RawVector2 value)
		{
			return *(Vector2*)(&value);
		}

		// Token: 0x04000166 RID: 358
		public static readonly int SizeInBytes = Utilities.SizeOf<Vector2>();

		// Token: 0x04000167 RID: 359
		public static readonly Vector2 Zero = default(Vector2);

		// Token: 0x04000168 RID: 360
		public static readonly Vector2 UnitX = new Vector2(1f, 0f);

		// Token: 0x04000169 RID: 361
		public static readonly Vector2 UnitY = new Vector2(0f, 1f);

		// Token: 0x0400016A RID: 362
		public static readonly Vector2 One = new Vector2(1f, 1f);

		// Token: 0x0400016B RID: 363
		public float X;

		// Token: 0x0400016C RID: 364
		public float Y;
	}
}

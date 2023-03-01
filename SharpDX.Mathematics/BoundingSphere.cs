using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000006 RID: 6
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct BoundingSphere : IEquatable<BoundingSphere>, IFormattable
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x000042D5 File Offset: 0x000024D5
		public BoundingSphere(Vector3 center, float radius)
		{
			this.Center = center;
			this.Radius = radius;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000042E8 File Offset: 0x000024E8
		public bool Intersects(ref Ray ray)
		{
			float num;
			return Collision.RayIntersectsSphere(ref ray, ref this, out num);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000042FE File Offset: 0x000024FE
		public bool Intersects(ref Ray ray, out float distance)
		{
			return Collision.RayIntersectsSphere(ref ray, ref this, out distance);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004308 File Offset: 0x00002508
		public bool Intersects(ref Ray ray, out Vector3 point)
		{
			return Collision.RayIntersectsSphere(ref ray, ref this, out point);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004312 File Offset: 0x00002512
		public PlaneIntersectionType Intersects(ref Plane plane)
		{
			return Collision.PlaneIntersectsSphere(ref plane, ref this);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000431B File Offset: 0x0000251B
		public bool Intersects(ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
		{
			return Collision.SphereIntersectsTriangle(ref this, ref vertex1, ref vertex2, ref vertex3);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004326 File Offset: 0x00002526
		public bool Intersects(ref BoundingBox box)
		{
			return Collision.BoxIntersectsSphere(ref box, ref this);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000432F File Offset: 0x0000252F
		public bool Intersects(BoundingBox box)
		{
			return this.Intersects(ref box);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004339 File Offset: 0x00002539
		public bool Intersects(ref BoundingSphere sphere)
		{
			return Collision.SphereIntersectsSphere(ref this, ref sphere);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004342 File Offset: 0x00002542
		public bool Intersects(BoundingSphere sphere)
		{
			return this.Intersects(ref sphere);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000434C File Offset: 0x0000254C
		public ContainmentType Contains(ref Vector3 point)
		{
			return Collision.SphereContainsPoint(ref this, ref point);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004355 File Offset: 0x00002555
		public ContainmentType Contains(ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
		{
			return Collision.SphereContainsTriangle(ref this, ref vertex1, ref vertex2, ref vertex3);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004360 File Offset: 0x00002560
		public ContainmentType Contains(ref BoundingBox box)
		{
			return Collision.SphereContainsBox(ref this, ref box);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004369 File Offset: 0x00002569
		public ContainmentType Contains(ref BoundingSphere sphere)
		{
			return Collision.SphereContainsSphere(ref this, ref sphere);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004374 File Offset: 0x00002574
		public static void FromPoints(Vector3[] points, int start, int count, out BoundingSphere result)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			if (start < 0 || start >= points.Length)
			{
				throw new ArgumentOutOfRangeException("start", start, string.Format("Must be in the range [0, {0}]", points.Length - 1));
			}
			if (count < 0 || start + count > points.Length)
			{
				throw new ArgumentOutOfRangeException("count", count, string.Format("Must be in the range <= {0}", points.Length));
			}
			int num = start + count;
			Vector3 vector = Vector3.Zero;
			for (int i = start; i < num; i++)
			{
				Vector3.Add(ref points[i], ref vector, out vector);
			}
			vector /= (float)count;
			float num2 = 0f;
			for (int j = start; j < num; j++)
			{
				float num3;
				Vector3.DistanceSquared(ref vector, ref points[j], out num3);
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			num2 = (float)Math.Sqrt((double)num2);
			result.Center = vector;
			result.Radius = num2;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004462 File Offset: 0x00002662
		public static void FromPoints(Vector3[] points, out BoundingSphere result)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			BoundingSphere.FromPoints(points, 0, points.Length, out result);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004480 File Offset: 0x00002680
		public static BoundingSphere FromPoints(Vector3[] points)
		{
			BoundingSphere result;
			BoundingSphere.FromPoints(points, out result);
			return result;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004498 File Offset: 0x00002698
		public static void FromBox(ref BoundingBox box, out BoundingSphere result)
		{
			Vector3.Lerp(ref box.Minimum, ref box.Maximum, 0.5f, out result.Center);
			float num = box.Minimum.X - box.Maximum.X;
			float num2 = box.Minimum.Y - box.Maximum.Y;
			float num3 = box.Minimum.Z - box.Maximum.Z;
			float num4 = (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3));
			result.Radius = num4 * 0.5f;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004528 File Offset: 0x00002728
		public static BoundingSphere FromBox(BoundingBox box)
		{
			BoundingSphere result;
			BoundingSphere.FromBox(ref box, out result);
			return result;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004540 File Offset: 0x00002740
		public static void Merge(ref BoundingSphere value1, ref BoundingSphere value2, out BoundingSphere result)
		{
			Vector3 value3 = value2.Center - value1.Center;
			float num = value3.Length();
			float radius = value1.Radius;
			float radius2 = value2.Radius;
			if (radius + radius2 >= num)
			{
				if (radius - radius2 >= num)
				{
					result = value1;
					return;
				}
				if (radius2 - radius >= num)
				{
					result = value2;
					return;
				}
			}
			Vector3 value4 = value3 * (1f / num);
			float num2 = Math.Min(-radius, num - radius2);
			float num3 = (Math.Max(radius, num + radius2) - num2) * 0.5f;
			result.Center = value1.Center + value4 * (num3 + num2);
			result.Radius = num3;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000045F8 File Offset: 0x000027F8
		public static BoundingSphere Merge(BoundingSphere value1, BoundingSphere value2)
		{
			BoundingSphere result;
			BoundingSphere.Merge(ref value1, ref value2, out result);
			return result;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004611 File Offset: 0x00002811
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(BoundingSphere left, BoundingSphere right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000461C File Offset: 0x0000281C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(BoundingSphere left, BoundingSphere right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000462A File Offset: 0x0000282A
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "Center:{0} Radius:{1}", new object[]
			{
				this.Center.ToString(),
				this.Radius.ToString()
			});
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004664 File Offset: 0x00002864
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "Center:{0} Radius:{1}", new object[]
			{
				this.Center.ToString(format, CultureInfo.CurrentCulture),
				this.Radius.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000046BE File Offset: 0x000028BE
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "Center:{0} Radius:{1}", new object[]
			{
				this.Center.ToString(),
				this.Radius.ToString()
			});
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000046F3 File Offset: 0x000028F3
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "Center:{0} Radius:{1}", new object[]
			{
				this.Center.ToString(format, formatProvider),
				this.Radius.ToString(format, formatProvider)
			});
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004731 File Offset: 0x00002931
		public override int GetHashCode()
		{
			return this.Center.GetHashCode() * 397 ^ this.Radius.GetHashCode();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004756 File Offset: 0x00002956
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref BoundingSphere value)
		{
			return this.Center == value.Center && this.Radius == value.Radius;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000477B File Offset: 0x0000297B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BoundingSphere value)
		{
			return this.Equals(ref value);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004788 File Offset: 0x00002988
		public override bool Equals(object value)
		{
			if (!(value is BoundingSphere))
			{
				return false;
			}
			BoundingSphere boundingSphere = (BoundingSphere)value;
			return this.Equals(ref boundingSphere);
		}

		// Token: 0x0400001D RID: 29
		public Vector3 Center;

		// Token: 0x0400001E RID: 30
		public float Radius;
	}
}

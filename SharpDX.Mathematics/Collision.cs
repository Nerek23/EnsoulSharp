using System;

namespace SharpDX
{
	// Token: 0x02000007 RID: 7
	public static class Collision
	{
		// Token: 0x060000D3 RID: 211 RVA: 0x000047B0 File Offset: 0x000029B0
		public static void ClosestPointPointTriangle(ref Vector3 point, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out Vector3 result)
		{
			Vector3 vector = vertex2 - vertex1;
			Vector3 vector2 = vertex3 - vertex1;
			Vector3 right = point - vertex1;
			float num = Vector3.Dot(vector, right);
			float num2 = Vector3.Dot(vector2, right);
			if (num <= 0f && num2 <= 0f)
			{
				result = vertex1;
				return;
			}
			Vector3 right2 = point - vertex2;
			float num3 = Vector3.Dot(vector, right2);
			float num4 = Vector3.Dot(vector2, right2);
			if (num3 >= 0f && num4 <= num3)
			{
				result = vertex2;
				return;
			}
			float num5 = num * num4 - num3 * num2;
			if (num5 <= 0f && num >= 0f && num3 <= 0f)
			{
				float scale = num / (num - num3);
				result = vertex1 + scale * vector;
				return;
			}
			Vector3 right3 = point - vertex3;
			float num6 = Vector3.Dot(vector, right3);
			float num7 = Vector3.Dot(vector2, right3);
			if (num7 >= 0f && num6 <= num7)
			{
				result = vertex3;
				return;
			}
			float num8 = num6 * num2 - num * num7;
			if (num8 <= 0f && num2 >= 0f && num7 <= 0f)
			{
				float scale2 = num2 / (num2 - num7);
				result = vertex1 + scale2 * vector2;
				return;
			}
			float num9 = num3 * num7 - num6 * num4;
			if (num9 <= 0f && num4 - num3 >= 0f && num6 - num7 >= 0f)
			{
				float scale3 = (num4 - num3) / (num4 - num3 + (num6 - num7));
				result = vertex2 + scale3 * (vertex3 - vertex2);
				return;
			}
			float num10 = 1f / (num9 + num8 + num5);
			float scale4 = num8 * num10;
			float scale5 = num5 * num10;
			result = vertex1 + vector * scale4 + vector2 * scale5;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000049F4 File Offset: 0x00002BF4
		public static void ClosestPointPlanePoint(ref Plane plane, ref Vector3 point, out Vector3 result)
		{
			float num;
			Vector3.Dot(ref plane.Normal, ref point, out num);
			float scale = num - plane.D;
			result = point - scale * plane.Normal;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004A38 File Offset: 0x00002C38
		public static void ClosestPointBoxPoint(ref BoundingBox box, ref Vector3 point, out Vector3 result)
		{
			Vector3 vector;
			Vector3.Max(ref point, ref box.Minimum, out vector);
			Vector3.Min(ref vector, ref box.Maximum, out result);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004A64 File Offset: 0x00002C64
		public static void ClosestPointSpherePoint(ref BoundingSphere sphere, ref Vector3 point, out Vector3 result)
		{
			Vector3.Subtract(ref point, ref sphere.Center, out result);
			result.Normalize();
			result *= sphere.Radius;
			result += sphere.Center;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004AB4 File Offset: 0x00002CB4
		public static void ClosestPointSphereSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2, out Vector3 result)
		{
			Vector3.Subtract(ref sphere2.Center, ref sphere1.Center, out result);
			result.Normalize();
			result *= sphere1.Radius;
			result += sphere1.Center;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004B08 File Offset: 0x00002D08
		public static float DistancePlanePoint(ref Plane plane, ref Vector3 point)
		{
			float num;
			Vector3.Dot(ref plane.Normal, ref point, out num);
			return num - plane.D;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004B2C File Offset: 0x00002D2C
		public static float DistanceBoxPoint(ref BoundingBox box, ref Vector3 point)
		{
			float num = 0f;
			if (point.X < box.Minimum.X)
			{
				num += (box.Minimum.X - point.X) * (box.Minimum.X - point.X);
			}
			if (point.X > box.Maximum.X)
			{
				num += (point.X - box.Maximum.X) * (point.X - box.Maximum.X);
			}
			if (point.Y < box.Minimum.Y)
			{
				num += (box.Minimum.Y - point.Y) * (box.Minimum.Y - point.Y);
			}
			if (point.Y > box.Maximum.Y)
			{
				num += (point.Y - box.Maximum.Y) * (point.Y - box.Maximum.Y);
			}
			if (point.Z < box.Minimum.Z)
			{
				num += (box.Minimum.Z - point.Z) * (box.Minimum.Z - point.Z);
			}
			if (point.Z > box.Maximum.Z)
			{
				num += (point.Z - box.Maximum.Z) * (point.Z - box.Maximum.Z);
			}
			return (float)Math.Sqrt((double)num);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004CAC File Offset: 0x00002EAC
		public static float DistanceBoxBox(ref BoundingBox box1, ref BoundingBox box2)
		{
			float num = 0f;
			if (box1.Minimum.X > box2.Maximum.X)
			{
				float num2 = box2.Maximum.X - box1.Minimum.X;
				num += num2 * num2;
			}
			else if (box2.Minimum.X > box1.Maximum.X)
			{
				float num3 = box1.Maximum.X - box2.Minimum.X;
				num += num3 * num3;
			}
			if (box1.Minimum.Y > box2.Maximum.Y)
			{
				float num4 = box2.Maximum.Y - box1.Minimum.Y;
				num += num4 * num4;
			}
			else if (box2.Minimum.Y > box1.Maximum.Y)
			{
				float num5 = box1.Maximum.Y - box2.Minimum.Y;
				num += num5 * num5;
			}
			if (box1.Minimum.Z > box2.Maximum.Z)
			{
				float num6 = box2.Maximum.Z - box1.Minimum.Z;
				num += num6 * num6;
			}
			else if (box2.Minimum.Z > box1.Maximum.Z)
			{
				float num7 = box1.Maximum.Z - box2.Minimum.Z;
				num += num7 * num7;
			}
			return (float)Math.Sqrt((double)num);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004E1C File Offset: 0x0000301C
		public static float DistanceSpherePoint(ref BoundingSphere sphere, ref Vector3 point)
		{
			float num;
			Vector3.Distance(ref sphere.Center, ref point, out num);
			num -= sphere.Radius;
			return Math.Max(num, 0f);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004E4C File Offset: 0x0000304C
		public static float DistanceSphereSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2)
		{
			float num;
			Vector3.Distance(ref sphere1.Center, ref sphere2.Center, out num);
			num -= sphere1.Radius + sphere2.Radius;
			return Math.Max(num, 0f);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004E88 File Offset: 0x00003088
		public static bool RayIntersectsPoint(ref Ray ray, ref Vector3 point)
		{
			Vector3 vector;
			Vector3.Subtract(ref ray.Position, ref point, out vector);
			float num = Vector3.Dot(vector, ray.Direction);
			float num2 = Vector3.Dot(vector, vector) - 1E-06f;
			return (num2 <= 0f || num <= 0f) && num * num - num2 >= 0f;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004EE0 File Offset: 0x000030E0
		public static bool RayIntersectsRay(ref Ray ray1, ref Ray ray2, out Vector3 point)
		{
			Vector3 vector;
			Vector3.Cross(ref ray1.Direction, ref ray2.Direction, out vector);
			float num = vector.Length();
			if (MathUtil.IsZero(num) && MathUtil.NearEqual(ray2.Position.X, ray1.Position.X) && MathUtil.NearEqual(ray2.Position.Y, ray1.Position.Y) && MathUtil.NearEqual(ray2.Position.Z, ray1.Position.Z))
			{
				point = Vector3.Zero;
				return true;
			}
			num *= num;
			float num2 = ray2.Position.X - ray1.Position.X;
			float num3 = ray2.Position.Y - ray1.Position.Y;
			float num4 = ray2.Position.Z - ray1.Position.Z;
			float x = ray2.Direction.X;
			float y = ray2.Direction.Y;
			float z = ray2.Direction.Z;
			float x2 = vector.X;
			float y2 = vector.Y;
			float z2 = vector.Z;
			float num5 = num2 * y * z2 + num3 * z * x2 + num4 * x * y2 - num2 * z * y2 - num3 * x * z2 - num4 * y * x2;
			x = ray1.Direction.X;
			y = ray1.Direction.Y;
			z = ray1.Direction.Z;
			float num6 = num2 * y * z2 + num3 * z * x2 + num4 * x * y2 - num2 * z * y2 - num3 * x * z2 - num4 * y * x2;
			float scale = num5 / num;
			float scale2 = num6 / num;
			Vector3 vector2 = ray1.Position + scale * ray1.Direction;
			Vector3 vector3 = ray2.Position + scale2 * ray2.Direction;
			if (!MathUtil.NearEqual(vector3.X, vector2.X) || !MathUtil.NearEqual(vector3.Y, vector2.Y) || !MathUtil.NearEqual(vector3.Z, vector2.Z))
			{
				point = Vector3.Zero;
				return false;
			}
			point = vector2;
			return true;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005120 File Offset: 0x00003320
		public static bool RayIntersectsPlane(ref Ray ray, ref Plane plane, out float distance)
		{
			float num;
			Vector3.Dot(ref plane.Normal, ref ray.Direction, out num);
			if (MathUtil.IsZero(num))
			{
				distance = 0f;
				return false;
			}
			float num2;
			Vector3.Dot(ref plane.Normal, ref ray.Position, out num2);
			distance = (-plane.D - num2) / num;
			if (distance < 0f)
			{
				distance = 0f;
				return false;
			}
			return true;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005184 File Offset: 0x00003384
		public static bool RayIntersectsPlane(ref Ray ray, ref Plane plane, out Vector3 point)
		{
			float scale;
			if (!Collision.RayIntersectsPlane(ref ray, ref plane, out scale))
			{
				point = Vector3.Zero;
				return false;
			}
			point = ray.Position + ray.Direction * scale;
			return true;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000051C8 File Offset: 0x000033C8
		public static bool RayIntersectsTriangle(ref Ray ray, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out float distance)
		{
			Vector3 vector;
			vector.X = vertex2.X - vertex1.X;
			vector.Y = vertex2.Y - vertex1.Y;
			vector.Z = vertex2.Z - vertex1.Z;
			Vector3 vector2;
			vector2.X = vertex3.X - vertex1.X;
			vector2.Y = vertex3.Y - vertex1.Y;
			vector2.Z = vertex3.Z - vertex1.Z;
			Vector3 vector3;
			vector3.X = ray.Direction.Y * vector2.Z - ray.Direction.Z * vector2.Y;
			vector3.Y = ray.Direction.Z * vector2.X - ray.Direction.X * vector2.Z;
			vector3.Z = ray.Direction.X * vector2.Y - ray.Direction.Y * vector2.X;
			float num = vector.X * vector3.X + vector.Y * vector3.Y + vector.Z * vector3.Z;
			if (MathUtil.IsZero(num))
			{
				distance = 0f;
				return false;
			}
			float num2 = 1f / num;
			Vector3 vector4;
			vector4.X = ray.Position.X - vertex1.X;
			vector4.Y = ray.Position.Y - vertex1.Y;
			vector4.Z = ray.Position.Z - vertex1.Z;
			float num3 = vector4.X * vector3.X + vector4.Y * vector3.Y + vector4.Z * vector3.Z;
			num3 *= num2;
			if (num3 < 0f || num3 > 1f)
			{
				distance = 0f;
				return false;
			}
			Vector3 vector5;
			vector5.X = vector4.Y * vector.Z - vector4.Z * vector.Y;
			vector5.Y = vector4.Z * vector.X - vector4.X * vector.Z;
			vector5.Z = vector4.X * vector.Y - vector4.Y * vector.X;
			float num4 = ray.Direction.X * vector5.X + ray.Direction.Y * vector5.Y + ray.Direction.Z * vector5.Z;
			num4 *= num2;
			if (num4 < 0f || num3 + num4 > 1f)
			{
				distance = 0f;
				return false;
			}
			float num5 = vector2.X * vector5.X + vector2.Y * vector5.Y + vector2.Z * vector5.Z;
			num5 *= num2;
			if (num5 < 0f)
			{
				distance = 0f;
				return false;
			}
			distance = num5;
			return true;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000054D0 File Offset: 0x000036D0
		public static bool RayIntersectsTriangle(ref Ray ray, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out Vector3 point)
		{
			float scale;
			if (!Collision.RayIntersectsTriangle(ref ray, ref vertex1, ref vertex2, ref vertex3, out scale))
			{
				point = Vector3.Zero;
				return false;
			}
			point = ray.Position + ray.Direction * scale;
			return true;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00005518 File Offset: 0x00003718
		public static bool RayIntersectsBox(ref Ray ray, ref BoundingBox box, out float distance)
		{
			distance = 0f;
			float num = float.MaxValue;
			if (MathUtil.IsZero(ray.Direction.X))
			{
				if (ray.Position.X < box.Minimum.X || ray.Position.X > box.Maximum.X)
				{
					distance = 0f;
					return false;
				}
			}
			else
			{
				float num2 = 1f / ray.Direction.X;
				float num3 = (box.Minimum.X - ray.Position.X) * num2;
				float num4 = (box.Maximum.X - ray.Position.X) * num2;
				if (num3 > num4)
				{
					float num5 = num3;
					num3 = num4;
					num4 = num5;
				}
				distance = Math.Max(num3, distance);
				num = Math.Min(num4, num);
				if (distance > num)
				{
					distance = 0f;
					return false;
				}
			}
			if (MathUtil.IsZero(ray.Direction.Y))
			{
				if (ray.Position.Y < box.Minimum.Y || ray.Position.Y > box.Maximum.Y)
				{
					distance = 0f;
					return false;
				}
			}
			else
			{
				float num6 = 1f / ray.Direction.Y;
				float num7 = (box.Minimum.Y - ray.Position.Y) * num6;
				float num8 = (box.Maximum.Y - ray.Position.Y) * num6;
				if (num7 > num8)
				{
					float num9 = num7;
					num7 = num8;
					num8 = num9;
				}
				distance = Math.Max(num7, distance);
				num = Math.Min(num8, num);
				if (distance > num)
				{
					distance = 0f;
					return false;
				}
			}
			if (MathUtil.IsZero(ray.Direction.Z))
			{
				if (ray.Position.Z < box.Minimum.Z || ray.Position.Z > box.Maximum.Z)
				{
					distance = 0f;
					return false;
				}
			}
			else
			{
				float num10 = 1f / ray.Direction.Z;
				float num11 = (box.Minimum.Z - ray.Position.Z) * num10;
				float num12 = (box.Maximum.Z - ray.Position.Z) * num10;
				if (num11 > num12)
				{
					float num13 = num11;
					num11 = num12;
					num12 = num13;
				}
				distance = Math.Max(num11, distance);
				num = Math.Min(num12, num);
				if (distance > num)
				{
					distance = 0f;
					return false;
				}
			}
			return true;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005780 File Offset: 0x00003980
		public static bool RayIntersectsBox(ref Ray ray, ref BoundingBox box, out Vector3 point)
		{
			float scale;
			if (!Collision.RayIntersectsBox(ref ray, ref box, out scale))
			{
				point = Vector3.Zero;
				return false;
			}
			point = ray.Position + ray.Direction * scale;
			return true;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000057C4 File Offset: 0x000039C4
		public static bool RayIntersectsSphere(ref Ray ray, ref BoundingSphere sphere, out float distance)
		{
			Vector3 vector;
			Vector3.Subtract(ref ray.Position, ref sphere.Center, out vector);
			float num = Vector3.Dot(vector, ray.Direction);
			float num2 = Vector3.Dot(vector, vector) - sphere.Radius * sphere.Radius;
			if (num2 > 0f && num > 0f)
			{
				distance = 0f;
				return false;
			}
			float num3 = num * num - num2;
			if (num3 < 0f)
			{
				distance = 0f;
				return false;
			}
			distance = -num - (float)Math.Sqrt((double)num3);
			if (distance < 0f)
			{
				distance = 0f;
			}
			return true;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00005858 File Offset: 0x00003A58
		public static bool RayIntersectsSphere(ref Ray ray, ref BoundingSphere sphere, out Vector3 point)
		{
			float scale;
			if (!Collision.RayIntersectsSphere(ref ray, ref sphere, out scale))
			{
				point = Vector3.Zero;
				return false;
			}
			point = ray.Position + ray.Direction * scale;
			return true;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000589C File Offset: 0x00003A9C
		public static PlaneIntersectionType PlaneIntersectsPoint(ref Plane plane, ref Vector3 point)
		{
			float num;
			Vector3.Dot(ref plane.Normal, ref point, out num);
			num += plane.D;
			if (num > 0f)
			{
				return PlaneIntersectionType.Front;
			}
			if (num < 0f)
			{
				return PlaneIntersectionType.Back;
			}
			return PlaneIntersectionType.Intersecting;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000058D8 File Offset: 0x00003AD8
		public static bool PlaneIntersectsPlane(ref Plane plane1, ref Plane plane2)
		{
			Vector3 vector;
			Vector3.Cross(ref plane1.Normal, ref plane2.Normal, out vector);
			float a;
			Vector3.Dot(ref vector, ref vector, out a);
			return !MathUtil.IsZero(a);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00005910 File Offset: 0x00003B10
		public static bool PlaneIntersectsPlane(ref Plane plane1, ref Plane plane2, out Ray line)
		{
			Vector3 direction;
			Vector3.Cross(ref plane1.Normal, ref plane2.Normal, out direction);
			float a;
			Vector3.Dot(ref direction, ref direction, out a);
			if (MathUtil.IsZero(a))
			{
				line = default(Ray);
				return false;
			}
			Vector3 vector = plane1.D * plane2.Normal - plane2.D * plane1.Normal;
			Vector3 position;
			Vector3.Cross(ref vector, ref direction, out position);
			line.Position = position;
			line.Direction = direction;
			line.Direction.Normalize();
			return true;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000599C File Offset: 0x00003B9C
		public static PlaneIntersectionType PlaneIntersectsTriangle(ref Plane plane, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
		{
			PlaneIntersectionType planeIntersectionType = Collision.PlaneIntersectsPoint(ref plane, ref vertex1);
			PlaneIntersectionType planeIntersectionType2 = Collision.PlaneIntersectsPoint(ref plane, ref vertex2);
			PlaneIntersectionType planeIntersectionType3 = Collision.PlaneIntersectsPoint(ref plane, ref vertex3);
			if (planeIntersectionType == PlaneIntersectionType.Front && planeIntersectionType2 == PlaneIntersectionType.Front && planeIntersectionType3 == PlaneIntersectionType.Front)
			{
				return PlaneIntersectionType.Front;
			}
			if (planeIntersectionType == PlaneIntersectionType.Back && planeIntersectionType2 == PlaneIntersectionType.Back && planeIntersectionType3 == PlaneIntersectionType.Back)
			{
				return PlaneIntersectionType.Back;
			}
			return PlaneIntersectionType.Intersecting;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000059DC File Offset: 0x00003BDC
		public static PlaneIntersectionType PlaneIntersectsBox(ref Plane plane, ref BoundingBox box)
		{
			Vector3 vector;
			vector.X = ((plane.Normal.X >= 0f) ? box.Minimum.X : box.Maximum.X);
			vector.Y = ((plane.Normal.Y >= 0f) ? box.Minimum.Y : box.Maximum.Y);
			vector.Z = ((plane.Normal.Z >= 0f) ? box.Minimum.Z : box.Maximum.Z);
			Vector3 right;
			right.X = ((plane.Normal.X >= 0f) ? box.Maximum.X : box.Minimum.X);
			right.Y = ((plane.Normal.Y >= 0f) ? box.Maximum.Y : box.Minimum.Y);
			right.Z = ((plane.Normal.Z >= 0f) ? box.Maximum.Z : box.Minimum.Z);
			float num;
			Vector3.Dot(ref plane.Normal, ref vector, out num);
			if (num + plane.D > 0f)
			{
				return PlaneIntersectionType.Front;
			}
			num = Vector3.Dot(plane.Normal, right);
			if (num + plane.D < 0f)
			{
				return PlaneIntersectionType.Back;
			}
			return PlaneIntersectionType.Intersecting;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00005B50 File Offset: 0x00003D50
		public static PlaneIntersectionType PlaneIntersectsSphere(ref Plane plane, ref BoundingSphere sphere)
		{
			float num;
			Vector3.Dot(ref plane.Normal, ref sphere.Center, out num);
			num += plane.D;
			if (num > sphere.Radius)
			{
				return PlaneIntersectionType.Front;
			}
			if (num < -sphere.Radius)
			{
				return PlaneIntersectionType.Back;
			}
			return PlaneIntersectionType.Intersecting;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00005B94 File Offset: 0x00003D94
		public static bool BoxIntersectsBox(ref BoundingBox box1, ref BoundingBox box2)
		{
			return box1.Minimum.X <= box2.Maximum.X && box2.Minimum.X <= box1.Maximum.X && box1.Minimum.Y <= box2.Maximum.Y && box2.Minimum.Y <= box1.Maximum.Y && box1.Minimum.Z <= box2.Maximum.Z && box2.Minimum.Z <= box1.Maximum.Z;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005C38 File Offset: 0x00003E38
		public static bool BoxIntersectsSphere(ref BoundingBox box, ref BoundingSphere sphere)
		{
			Vector3 value;
			Vector3.Clamp(ref sphere.Center, ref box.Minimum, ref box.Maximum, out value);
			return Vector3.DistanceSquared(sphere.Center, value) <= sphere.Radius * sphere.Radius;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00005C7C File Offset: 0x00003E7C
		public static bool SphereIntersectsTriangle(ref BoundingSphere sphere, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
		{
			Vector3 left;
			Collision.ClosestPointPointTriangle(ref sphere.Center, ref vertex1, ref vertex2, ref vertex3, out left);
			Vector3 vector = left - sphere.Center;
			float num;
			Vector3.Dot(ref vector, ref vector, out num);
			return num <= sphere.Radius * sphere.Radius;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00005CC4 File Offset: 0x00003EC4
		public static bool SphereIntersectsSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2)
		{
			float num = sphere1.Radius + sphere2.Radius;
			return Vector3.DistanceSquared(sphere1.Center, sphere2.Center) <= num * num;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005CF8 File Offset: 0x00003EF8
		public static ContainmentType BoxContainsPoint(ref BoundingBox box, ref Vector3 point)
		{
			if (box.Minimum.X <= point.X && box.Maximum.X >= point.X && box.Minimum.Y <= point.Y && box.Maximum.Y >= point.Y && box.Minimum.Z <= point.Z && box.Maximum.Z >= point.Z)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Disjoint;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00005D7C File Offset: 0x00003F7C
		public static ContainmentType BoxContainsBox(ref BoundingBox box1, ref BoundingBox box2)
		{
			if (box1.Maximum.X < box2.Minimum.X || box1.Minimum.X > box2.Maximum.X)
			{
				return ContainmentType.Disjoint;
			}
			if (box1.Maximum.Y < box2.Minimum.Y || box1.Minimum.Y > box2.Maximum.Y)
			{
				return ContainmentType.Disjoint;
			}
			if (box1.Maximum.Z < box2.Minimum.Z || box1.Minimum.Z > box2.Maximum.Z)
			{
				return ContainmentType.Disjoint;
			}
			if (box1.Minimum.X <= box2.Minimum.X && box2.Maximum.X <= box1.Maximum.X && box1.Minimum.Y <= box2.Minimum.Y && box2.Maximum.Y <= box1.Maximum.Y && box1.Minimum.Z <= box2.Minimum.Z && box2.Maximum.Z <= box1.Maximum.Z)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Intersects;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00005EB4 File Offset: 0x000040B4
		public static ContainmentType BoxContainsSphere(ref BoundingBox box, ref BoundingSphere sphere)
		{
			Vector3 value;
			Vector3.Clamp(ref sphere.Center, ref box.Minimum, ref box.Maximum, out value);
			if (Vector3.DistanceSquared(sphere.Center, value) > sphere.Radius * sphere.Radius)
			{
				return ContainmentType.Disjoint;
			}
			if (box.Minimum.X + sphere.Radius <= sphere.Center.X && sphere.Center.X <= box.Maximum.X - sphere.Radius && box.Maximum.X - box.Minimum.X > sphere.Radius && box.Minimum.Y + sphere.Radius <= sphere.Center.Y && sphere.Center.Y <= box.Maximum.Y - sphere.Radius && box.Maximum.Y - box.Minimum.Y > sphere.Radius && box.Minimum.Z + sphere.Radius <= sphere.Center.Z && sphere.Center.Z <= box.Maximum.Z - sphere.Radius && box.Maximum.Z - box.Minimum.Z > sphere.Radius)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Intersects;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000601D File Offset: 0x0000421D
		public static ContainmentType SphereContainsPoint(ref BoundingSphere sphere, ref Vector3 point)
		{
			if (Vector3.DistanceSquared(point, sphere.Center) <= sphere.Radius * sphere.Radius)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Disjoint;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00006044 File Offset: 0x00004244
		public static ContainmentType SphereContainsTriangle(ref BoundingSphere sphere, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
		{
			int num = (int)Collision.SphereContainsPoint(ref sphere, ref vertex1);
			ContainmentType containmentType = Collision.SphereContainsPoint(ref sphere, ref vertex2);
			ContainmentType containmentType2 = Collision.SphereContainsPoint(ref sphere, ref vertex3);
			if (num == 1 && containmentType == ContainmentType.Contains && containmentType2 == ContainmentType.Contains)
			{
				return ContainmentType.Contains;
			}
			if (Collision.SphereIntersectsTriangle(ref sphere, ref vertex1, ref vertex2, ref vertex3))
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Disjoint;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00006084 File Offset: 0x00004284
		public static ContainmentType SphereContainsBox(ref BoundingSphere sphere, ref BoundingBox box)
		{
			if (!Collision.BoxIntersectsSphere(ref box, ref sphere))
			{
				return ContainmentType.Disjoint;
			}
			float num = sphere.Radius * sphere.Radius;
			Vector3 vector;
			vector.X = sphere.Center.X - box.Minimum.X;
			vector.Y = sphere.Center.Y - box.Maximum.Y;
			vector.Z = sphere.Center.Z - box.Maximum.Z;
			if (vector.LengthSquared() > num)
			{
				return ContainmentType.Intersects;
			}
			vector.X = sphere.Center.X - box.Maximum.X;
			vector.Y = sphere.Center.Y - box.Maximum.Y;
			vector.Z = sphere.Center.Z - box.Maximum.Z;
			if (vector.LengthSquared() > num)
			{
				return ContainmentType.Intersects;
			}
			vector.X = sphere.Center.X - box.Maximum.X;
			vector.Y = sphere.Center.Y - box.Minimum.Y;
			vector.Z = sphere.Center.Z - box.Maximum.Z;
			if (vector.LengthSquared() > num)
			{
				return ContainmentType.Intersects;
			}
			vector.X = sphere.Center.X - box.Minimum.X;
			vector.Y = sphere.Center.Y - box.Minimum.Y;
			vector.Z = sphere.Center.Z - box.Maximum.Z;
			if (vector.LengthSquared() > num)
			{
				return ContainmentType.Intersects;
			}
			vector.X = sphere.Center.X - box.Minimum.X;
			vector.Y = sphere.Center.Y - box.Maximum.Y;
			vector.Z = sphere.Center.Z - box.Minimum.Z;
			if (vector.LengthSquared() > num)
			{
				return ContainmentType.Intersects;
			}
			vector.X = sphere.Center.X - box.Maximum.X;
			vector.Y = sphere.Center.Y - box.Maximum.Y;
			vector.Z = sphere.Center.Z - box.Minimum.Z;
			if (vector.LengthSquared() > num)
			{
				return ContainmentType.Intersects;
			}
			vector.X = sphere.Center.X - box.Maximum.X;
			vector.Y = sphere.Center.Y - box.Minimum.Y;
			vector.Z = sphere.Center.Z - box.Minimum.Z;
			if (vector.LengthSquared() > num)
			{
				return ContainmentType.Intersects;
			}
			vector.X = sphere.Center.X - box.Minimum.X;
			vector.Y = sphere.Center.Y - box.Minimum.Y;
			vector.Z = sphere.Center.Z - box.Minimum.Z;
			if (vector.LengthSquared() > num)
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Contains;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000063DC File Offset: 0x000045DC
		public static ContainmentType SphereContainsSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2)
		{
			float num = Vector3.Distance(sphere1.Center, sphere2.Center);
			if (sphere1.Radius + sphere2.Radius < num)
			{
				return ContainmentType.Disjoint;
			}
			if (sphere1.Radius - sphere2.Radius < num)
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Contains;
		}
	}
}

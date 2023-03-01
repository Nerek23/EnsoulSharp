using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000022 RID: 34
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Ray : IEquatable<Ray>, IFormattable
	{
		// Token: 0x06000573 RID: 1395 RVA: 0x0001B904 File Offset: 0x00019B04
		public Ray(Vector3 position, Vector3 direction)
		{
			this.Position = position;
			this.Direction = direction;
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0001B914 File Offset: 0x00019B14
		public bool Intersects(ref Vector3 point)
		{
			return Collision.RayIntersectsPoint(ref this, ref point);
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0001B920 File Offset: 0x00019B20
		public bool Intersects(ref Ray ray)
		{
			Vector3 vector;
			return Collision.RayIntersectsRay(ref this, ref ray, out vector);
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0001B936 File Offset: 0x00019B36
		public bool Intersects(ref Ray ray, out Vector3 point)
		{
			return Collision.RayIntersectsRay(ref this, ref ray, out point);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0001B940 File Offset: 0x00019B40
		public bool Intersects(ref Plane plane)
		{
			float num;
			return Collision.RayIntersectsPlane(ref this, ref plane, out num);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0001B956 File Offset: 0x00019B56
		public bool Intersects(ref Plane plane, out float distance)
		{
			return Collision.RayIntersectsPlane(ref this, ref plane, out distance);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0001B960 File Offset: 0x00019B60
		public bool Intersects(ref Plane plane, out Vector3 point)
		{
			return Collision.RayIntersectsPlane(ref this, ref plane, out point);
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0001B96C File Offset: 0x00019B6C
		public bool Intersects(ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
		{
			float num;
			return Collision.RayIntersectsTriangle(ref this, ref vertex1, ref vertex2, ref vertex3, out num);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0001B984 File Offset: 0x00019B84
		public bool Intersects(ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out float distance)
		{
			return Collision.RayIntersectsTriangle(ref this, ref vertex1, ref vertex2, ref vertex3, out distance);
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0001B991 File Offset: 0x00019B91
		public bool Intersects(ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out Vector3 point)
		{
			return Collision.RayIntersectsTriangle(ref this, ref vertex1, ref vertex2, ref vertex3, out point);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0001B9A0 File Offset: 0x00019BA0
		public bool Intersects(ref BoundingBox box)
		{
			float num;
			return Collision.RayIntersectsBox(ref this, ref box, out num);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001B9B6 File Offset: 0x00019BB6
		public bool Intersects(BoundingBox box)
		{
			return this.Intersects(ref box);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001B9C0 File Offset: 0x00019BC0
		public bool Intersects(ref BoundingBox box, out float distance)
		{
			return Collision.RayIntersectsBox(ref this, ref box, out distance);
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0001B9CA File Offset: 0x00019BCA
		public bool Intersects(ref BoundingBox box, out Vector3 point)
		{
			return Collision.RayIntersectsBox(ref this, ref box, out point);
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001B9D4 File Offset: 0x00019BD4
		public bool Intersects(ref BoundingSphere sphere)
		{
			float num;
			return Collision.RayIntersectsSphere(ref this, ref sphere, out num);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001B9EA File Offset: 0x00019BEA
		public bool Intersects(BoundingSphere sphere)
		{
			return this.Intersects(ref sphere);
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0001B9F4 File Offset: 0x00019BF4
		public bool Intersects(ref BoundingSphere sphere, out float distance)
		{
			return Collision.RayIntersectsSphere(ref this, ref sphere, out distance);
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0001B9FE File Offset: 0x00019BFE
		public bool Intersects(ref BoundingSphere sphere, out Vector3 point)
		{
			return Collision.RayIntersectsSphere(ref this, ref sphere, out point);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0001BA08 File Offset: 0x00019C08
		public static Ray GetPickRay(int x, int y, ViewportF viewport, Matrix worldViewProjection)
		{
			Vector3 vector = new Vector3((float)x, (float)y, 0f);
			Vector3 vector2 = new Vector3((float)x, (float)y, 1f);
			vector = Vector3.Unproject(vector, viewport.X, viewport.Y, viewport.Width, viewport.Height, viewport.MinDepth, viewport.MaxDepth, worldViewProjection);
			Vector3 direction = Vector3.Unproject(vector2, viewport.X, viewport.Y, viewport.Width, viewport.Height, viewport.MinDepth, viewport.MaxDepth, worldViewProjection) - vector;
			direction.Normalize();
			return new Ray(vector, direction);
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0001BA9E File Offset: 0x00019C9E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Ray left, Ray right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0001BAA9 File Offset: 0x00019CA9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Ray left, Ray right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x0001BAB7 File Offset: 0x00019CB7
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "Position:{0} Direction:{1}", new object[]
			{
				this.Position.ToString(),
				this.Direction.ToString()
			});
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0001BAF6 File Offset: 0x00019CF6
		public string ToString(string format)
		{
			return string.Format(CultureInfo.CurrentCulture, "Position:{0} Direction:{1}", new object[]
			{
				this.Position.ToString(format, CultureInfo.CurrentCulture),
				this.Direction.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0001BB35 File Offset: 0x00019D35
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "Position:{0} Direction:{1}", new object[]
			{
				this.Position.ToString(),
				this.Direction.ToString()
			});
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0001BB70 File Offset: 0x00019D70
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "Position:{0} Direction:{1}", new object[]
			{
				this.Position.ToString(format, formatProvider),
				this.Direction.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0001BBA3 File Offset: 0x00019DA3
		public override int GetHashCode()
		{
			return this.Position.GetHashCode() * 397 ^ this.Direction.GetHashCode();
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0001BBCE File Offset: 0x00019DCE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Ray value)
		{
			return this.Position == value.Position && this.Direction == value.Direction;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0001BBF6 File Offset: 0x00019DF6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Ray value)
		{
			return this.Equals(ref value);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0001BC00 File Offset: 0x00019E00
		public override bool Equals(object value)
		{
			if (!(value is Ray))
			{
				return false;
			}
			Ray ray = (Ray)value;
			return this.Equals(ref ray);
		}

		// Token: 0x04000159 RID: 345
		public Vector3 Position;

		// Token: 0x0400015A RID: 346
		public Vector3 Direction;
	}
}

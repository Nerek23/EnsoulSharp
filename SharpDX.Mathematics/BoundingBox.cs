using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000004 RID: 4
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct BoundingBox : IEquatable<BoundingBox>, IFormattable
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00002AC8 File Offset: 0x00000CC8
		public BoundingBox(Vector3 minimum, Vector3 maximum)
		{
			this.Minimum = minimum;
			this.Maximum = maximum;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002AD8 File Offset: 0x00000CD8
		public float Width
		{
			get
			{
				return this.Maximum.X - this.Minimum.X;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002AF1 File Offset: 0x00000CF1
		public float Height
		{
			get
			{
				return this.Maximum.Y - this.Minimum.Y;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002B0A File Offset: 0x00000D0A
		public float Depth
		{
			get
			{
				return this.Maximum.Z - this.Minimum.Z;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002B23 File Offset: 0x00000D23
		public Vector3 Size
		{
			get
			{
				return this.Maximum - this.Minimum;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002B36 File Offset: 0x00000D36
		public Vector3 Center
		{
			get
			{
				return (this.Maximum + this.Minimum) * 0.5f;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002B54 File Offset: 0x00000D54
		public Vector3[] GetCorners()
		{
			Vector3[] array = new Vector3[8];
			this.GetCorners(array);
			return array;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002B70 File Offset: 0x00000D70
		public void GetCorners(Vector3[] corners)
		{
			corners[0] = new Vector3(this.Minimum.X, this.Maximum.Y, this.Maximum.Z);
			corners[1] = new Vector3(this.Maximum.X, this.Maximum.Y, this.Maximum.Z);
			corners[2] = new Vector3(this.Maximum.X, this.Minimum.Y, this.Maximum.Z);
			corners[3] = new Vector3(this.Minimum.X, this.Minimum.Y, this.Maximum.Z);
			corners[4] = new Vector3(this.Minimum.X, this.Maximum.Y, this.Minimum.Z);
			corners[5] = new Vector3(this.Maximum.X, this.Maximum.Y, this.Minimum.Z);
			corners[6] = new Vector3(this.Maximum.X, this.Minimum.Y, this.Minimum.Z);
			corners[7] = new Vector3(this.Minimum.X, this.Minimum.Y, this.Minimum.Z);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002CE8 File Offset: 0x00000EE8
		public bool Intersects(ref Ray ray)
		{
			float num;
			return Collision.RayIntersectsBox(ref ray, ref this, out num);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002CFE File Offset: 0x00000EFE
		public bool Intersects(ref Ray ray, out float distance)
		{
			return Collision.RayIntersectsBox(ref ray, ref this, out distance);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002D08 File Offset: 0x00000F08
		public bool Intersects(ref Ray ray, out Vector3 point)
		{
			return Collision.RayIntersectsBox(ref ray, ref this, out point);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002D12 File Offset: 0x00000F12
		public PlaneIntersectionType Intersects(ref Plane plane)
		{
			return Collision.PlaneIntersectsBox(ref plane, ref this);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002D1B File Offset: 0x00000F1B
		public bool Intersects(ref BoundingBox box)
		{
			return Collision.BoxIntersectsBox(ref this, ref box);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002D24 File Offset: 0x00000F24
		public bool Intersects(BoundingBox box)
		{
			return this.Intersects(ref box);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002D2E File Offset: 0x00000F2E
		public bool Intersects(ref BoundingSphere sphere)
		{
			return Collision.BoxIntersectsSphere(ref this, ref sphere);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002D37 File Offset: 0x00000F37
		public bool Intersects(BoundingSphere sphere)
		{
			return this.Intersects(ref sphere);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002D41 File Offset: 0x00000F41
		public ContainmentType Contains(ref Vector3 point)
		{
			return Collision.BoxContainsPoint(ref this, ref point);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002D4A File Offset: 0x00000F4A
		public ContainmentType Contains(Vector3 point)
		{
			return this.Contains(ref point);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002D54 File Offset: 0x00000F54
		public ContainmentType Contains(ref BoundingBox box)
		{
			return Collision.BoxContainsBox(ref this, ref box);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002D5D File Offset: 0x00000F5D
		public ContainmentType Contains(BoundingBox box)
		{
			return this.Contains(ref box);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002D67 File Offset: 0x00000F67
		public ContainmentType Contains(ref BoundingSphere sphere)
		{
			return Collision.BoxContainsSphere(ref this, ref sphere);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002D70 File Offset: 0x00000F70
		public ContainmentType Contains(BoundingSphere sphere)
		{
			return this.Contains(ref sphere);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002D7C File Offset: 0x00000F7C
		public static void FromPoints(Vector3[] points, out BoundingBox result)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			Vector3 minimum = new Vector3(float.MaxValue);
			Vector3 maximum = new Vector3(float.MinValue);
			for (int i = 0; i < points.Length; i++)
			{
				Vector3.Min(ref minimum, ref points[i], out minimum);
				Vector3.Max(ref maximum, ref points[i], out maximum);
			}
			result = new BoundingBox(minimum, maximum);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002DEC File Offset: 0x00000FEC
		public static BoundingBox FromPoints(Vector3[] points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			Vector3 minimum = new Vector3(float.MaxValue);
			Vector3 maximum = new Vector3(float.MinValue);
			for (int i = 0; i < points.Length; i++)
			{
				Vector3.Min(ref minimum, ref points[i], out minimum);
				Vector3.Max(ref maximum, ref points[i], out maximum);
			}
			return new BoundingBox(minimum, maximum);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002E54 File Offset: 0x00001054
		public static void FromSphere(ref BoundingSphere sphere, out BoundingBox result)
		{
			result.Minimum = new Vector3(sphere.Center.X - sphere.Radius, sphere.Center.Y - sphere.Radius, sphere.Center.Z - sphere.Radius);
			result.Maximum = new Vector3(sphere.Center.X + sphere.Radius, sphere.Center.Y + sphere.Radius, sphere.Center.Z + sphere.Radius);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002EE4 File Offset: 0x000010E4
		public static BoundingBox FromSphere(BoundingSphere sphere)
		{
			BoundingBox result;
			result.Minimum = new Vector3(sphere.Center.X - sphere.Radius, sphere.Center.Y - sphere.Radius, sphere.Center.Z - sphere.Radius);
			result.Maximum = new Vector3(sphere.Center.X + sphere.Radius, sphere.Center.Y + sphere.Radius, sphere.Center.Z + sphere.Radius);
			return result;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002F76 File Offset: 0x00001176
		public static void Merge(ref BoundingBox value1, ref BoundingBox value2, out BoundingBox result)
		{
			Vector3.Min(ref value1.Minimum, ref value2.Minimum, out result.Minimum);
			Vector3.Max(ref value1.Maximum, ref value2.Maximum, out result.Maximum);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002FA8 File Offset: 0x000011A8
		public static BoundingBox Merge(BoundingBox value1, BoundingBox value2)
		{
			BoundingBox result;
			Vector3.Min(ref value1.Minimum, ref value2.Minimum, out result.Minimum);
			Vector3.Max(ref value1.Maximum, ref value2.Maximum, out result.Maximum);
			return result;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002FEA File Offset: 0x000011EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(BoundingBox left, BoundingBox right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002FF5 File Offset: 0x000011F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(BoundingBox left, BoundingBox right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003003 File Offset: 0x00001203
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "Minimum:{0} Maximum:{1}", new object[]
			{
				this.Minimum.ToString(),
				this.Maximum.ToString()
			});
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003044 File Offset: 0x00001244
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "Minimum:{0} Maximum:{1}", new object[]
			{
				this.Minimum.ToString(format, CultureInfo.CurrentCulture),
				this.Maximum.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000309E File Offset: 0x0000129E
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "Minimum:{0} Maximum:{1}", new object[]
			{
				this.Minimum.ToString(),
				this.Maximum.ToString()
			});
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000030D9 File Offset: 0x000012D9
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "Minimum:{0} Maximum:{1}", new object[]
			{
				this.Minimum.ToString(format, formatProvider),
				this.Maximum.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003117 File Offset: 0x00001317
		public override int GetHashCode()
		{
			return this.Minimum.GetHashCode() * 397 ^ this.Maximum.GetHashCode();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003142 File Offset: 0x00001342
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref BoundingBox value)
		{
			return this.Minimum == value.Minimum && this.Maximum == value.Maximum;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000316A File Offset: 0x0000136A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BoundingBox value)
		{
			return this.Equals(ref value);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003174 File Offset: 0x00001374
		public override bool Equals(object value)
		{
			if (!(value is BoundingBox))
			{
				return false;
			}
			BoundingBox boundingBox = (BoundingBox)value;
			return this.Equals(ref boundingBox);
		}

		// Token: 0x04000014 RID: 20
		public Vector3 Minimum;

		// Token: 0x04000015 RID: 21
		public Vector3 Maximum;
	}
}

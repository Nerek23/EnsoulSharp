using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200001E RID: 30
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Plane : IEquatable<Plane>, IFormattable
	{
		// Token: 0x060004CB RID: 1227 RVA: 0x00018898 File Offset: 0x00016A98
		public Plane(float value)
		{
			this.D = value;
			this.Normal.Z = value;
			this.Normal.Y = value;
			this.Normal.X = value;
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x000188D6 File Offset: 0x00016AD6
		public Plane(float a, float b, float c, float d)
		{
			this.Normal.X = a;
			this.Normal.Y = b;
			this.Normal.Z = c;
			this.D = d;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00018904 File Offset: 0x00016B04
		public Plane(Vector3 point, Vector3 normal)
		{
			this.Normal = normal;
			this.D = -Vector3.Dot(normal, point);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0001891B File Offset: 0x00016B1B
		public Plane(Vector3 value, float d)
		{
			this.Normal = value;
			this.D = d;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0001892C File Offset: 0x00016B2C
		public Plane(Vector3 point1, Vector3 point2, Vector3 point3)
		{
			float num = point2.X - point1.X;
			float num2 = point2.Y - point1.Y;
			float num3 = point2.Z - point1.Z;
			float num4 = point3.X - point1.X;
			float num5 = point3.Y - point1.Y;
			float num6 = point3.Z - point1.Z;
			float num7 = num2 * num6 - num3 * num5;
			float num8 = num3 * num4 - num * num6;
			float num9 = num * num5 - num2 * num4;
			float num10 = 1f / (float)Math.Sqrt((double)(num7 * num7 + num8 * num8 + num9 * num9));
			this.Normal.X = num7 * num10;
			this.Normal.Y = num8 * num10;
			this.Normal.Z = num9 * num10;
			this.D = -(this.Normal.X * point1.X + this.Normal.Y * point1.Y + this.Normal.Z * point1.Z);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00018A40 File Offset: 0x00016C40
		public Plane(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Plane.");
			}
			this.Normal.X = values[0];
			this.Normal.Y = values[1];
			this.Normal.Z = values[2];
			this.D = values[3];
		}

		// Token: 0x17000061 RID: 97
		public float this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.Normal.X;
				case 1:
					return this.Normal.Y;
				case 2:
					return this.Normal.Z;
				case 3:
					return this.D;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Plane run from 0 to 3, inclusive.");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.Normal.X = value;
					return;
				case 1:
					this.Normal.Y = value;
					return;
				case 2:
					this.Normal.Z = value;
					return;
				case 3:
					this.D = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Plane run from 0 to 3, inclusive.");
				}
			}
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00018B68 File Offset: 0x00016D68
		public void Normalize()
		{
			float num = 1f / (float)Math.Sqrt((double)(this.Normal.X * this.Normal.X + this.Normal.Y * this.Normal.Y + this.Normal.Z * this.Normal.Z));
			this.Normal.X = this.Normal.X * num;
			this.Normal.Y = this.Normal.Y * num;
			this.Normal.Z = this.Normal.Z * num;
			this.D *= num;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00018C08 File Offset: 0x00016E08
		public float[] ToArray()
		{
			return new float[]
			{
				this.Normal.X,
				this.Normal.Y,
				this.Normal.Z,
				this.D
			};
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00018C43 File Offset: 0x00016E43
		public PlaneIntersectionType Intersects(ref Vector3 point)
		{
			return Collision.PlaneIntersectsPoint(ref this, ref point);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00018C4C File Offset: 0x00016E4C
		public bool Intersects(ref Ray ray)
		{
			float num;
			return Collision.RayIntersectsPlane(ref ray, ref this, out num);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00018C62 File Offset: 0x00016E62
		public bool Intersects(ref Ray ray, out float distance)
		{
			return Collision.RayIntersectsPlane(ref ray, ref this, out distance);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00018C6C File Offset: 0x00016E6C
		public bool Intersects(ref Ray ray, out Vector3 point)
		{
			return Collision.RayIntersectsPlane(ref ray, ref this, out point);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00018C76 File Offset: 0x00016E76
		public bool Intersects(ref Plane plane)
		{
			return Collision.PlaneIntersectsPlane(ref this, ref plane);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00018C7F File Offset: 0x00016E7F
		public bool Intersects(ref Plane plane, out Ray line)
		{
			return Collision.PlaneIntersectsPlane(ref this, ref plane, out line);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00018C89 File Offset: 0x00016E89
		public PlaneIntersectionType Intersects(ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
		{
			return Collision.PlaneIntersectsTriangle(ref this, ref vertex1, ref vertex2, ref vertex3);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00018C94 File Offset: 0x00016E94
		public PlaneIntersectionType Intersects(ref BoundingBox box)
		{
			return Collision.PlaneIntersectsBox(ref this, ref box);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00018C9D File Offset: 0x00016E9D
		public PlaneIntersectionType Intersects(ref BoundingSphere sphere)
		{
			return Collision.PlaneIntersectsSphere(ref this, ref sphere);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00018CA8 File Offset: 0x00016EA8
		public void Reflection(out Matrix result)
		{
			float x = this.Normal.X;
			float y = this.Normal.Y;
			float z = this.Normal.Z;
			float num = -2f * x;
			float num2 = -2f * y;
			float num3 = -2f * z;
			result.M11 = num * x + 1f;
			result.M12 = num2 * x;
			result.M13 = num3 * x;
			result.M14 = 0f;
			result.M21 = num * y;
			result.M22 = num2 * y + 1f;
			result.M23 = num3 * y;
			result.M24 = 0f;
			result.M31 = num * z;
			result.M32 = num2 * z;
			result.M33 = num3 * z + 1f;
			result.M34 = 0f;
			result.M41 = num * this.D;
			result.M42 = num2 * this.D;
			result.M43 = num3 * this.D;
			result.M44 = 1f;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00018DB4 File Offset: 0x00016FB4
		public Matrix Reflection()
		{
			Matrix result;
			this.Reflection(out result);
			return result;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00018DCC File Offset: 0x00016FCC
		public void Shadow(ref Vector4 light, out Matrix result)
		{
			float num = this.Normal.X * light.X + this.Normal.Y * light.Y + this.Normal.Z * light.Z + this.D * light.W;
			float num2 = -this.Normal.X;
			float num3 = -this.Normal.Y;
			float num4 = -this.Normal.Z;
			float num5 = -this.D;
			result.M11 = num2 * light.X + num;
			result.M21 = num3 * light.X;
			result.M31 = num4 * light.X;
			result.M41 = num5 * light.X;
			result.M12 = num2 * light.Y;
			result.M22 = num3 * light.Y + num;
			result.M32 = num4 * light.Y;
			result.M42 = num5 * light.Y;
			result.M13 = num2 * light.Z;
			result.M23 = num3 * light.Z;
			result.M33 = num4 * light.Z + num;
			result.M43 = num5 * light.Z;
			result.M14 = num2 * light.W;
			result.M24 = num3 * light.W;
			result.M34 = num4 * light.W;
			result.M44 = num5 * light.W + num;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00018F3C File Offset: 0x0001713C
		public Matrix Shadow(Vector4 light)
		{
			Matrix result;
			this.Shadow(ref light, out result);
			return result;
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00018F54 File Offset: 0x00017154
		public void Reflection(out Matrix3x3 result)
		{
			float x = this.Normal.X;
			float y = this.Normal.Y;
			float z = this.Normal.Z;
			float num = -2f * x;
			float num2 = -2f * y;
			float num3 = -2f * z;
			result.M11 = num * x + 1f;
			result.M12 = num2 * x;
			result.M13 = num3 * x;
			result.M21 = num * y;
			result.M22 = num2 * y + 1f;
			result.M23 = num3 * y;
			result.M31 = num * z;
			result.M32 = num2 * z;
			result.M33 = num3 * z + 1f;
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00019008 File Offset: 0x00017208
		public Matrix3x3 Reflection3x3()
		{
			Matrix3x3 result;
			this.Reflection(out result);
			return result;
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00019020 File Offset: 0x00017220
		public static void Shadow(ref Vector4 light, ref Plane plane, out Matrix3x3 result)
		{
			float num = plane.Normal.X * light.X + plane.Normal.Y * light.Y + plane.Normal.Z * light.Z + plane.D * light.W;
			float num2 = -plane.Normal.X;
			float num3 = -plane.Normal.Y;
			float num4 = -plane.Normal.Z;
			result.M11 = num2 * light.X + num;
			result.M21 = num3 * light.X;
			result.M31 = num4 * light.X;
			result.M12 = num2 * light.Y;
			result.M22 = num3 * light.Y + num;
			result.M32 = num4 * light.Y;
			result.M13 = num2 * light.Z;
			result.M23 = num3 * light.Z;
			result.M33 = num4 * light.Z + num;
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00019120 File Offset: 0x00017320
		public static Matrix3x3 Shadow(Vector4 light, Plane plane)
		{
			Matrix3x3 result;
			Plane.Shadow(ref light, ref plane, out result);
			return result;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0001913C File Offset: 0x0001733C
		public static void Multiply(ref Plane value, float scale, out Plane result)
		{
			result.Normal.X = value.Normal.X * scale;
			result.Normal.Y = value.Normal.Y * scale;
			result.Normal.Z = value.Normal.Z * scale;
			result.D = value.D * scale;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0001919F File Offset: 0x0001739F
		public static Plane Multiply(Plane value, float scale)
		{
			return new Plane(value.Normal.X * scale, value.Normal.Y * scale, value.Normal.Z * scale, value.D * scale);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x000191D8 File Offset: 0x000173D8
		public static void Dot(ref Plane left, ref Vector4 right, out float result)
		{
			result = left.Normal.X * right.X + left.Normal.Y * right.Y + left.Normal.Z * right.Z + left.D * right.W;
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00019230 File Offset: 0x00017430
		public static float Dot(Plane left, Vector4 right)
		{
			return left.Normal.X * right.X + left.Normal.Y * right.Y + left.Normal.Z * right.Z + left.D * right.W;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00019284 File Offset: 0x00017484
		public static void DotCoordinate(ref Plane left, ref Vector3 right, out float result)
		{
			result = left.Normal.X * right.X + left.Normal.Y * right.Y + left.Normal.Z * right.Z + left.D;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x000192D4 File Offset: 0x000174D4
		public static float DotCoordinate(Plane left, Vector3 right)
		{
			return left.Normal.X * right.X + left.Normal.Y * right.Y + left.Normal.Z * right.Z + left.D;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00019320 File Offset: 0x00017520
		public static void DotNormal(ref Plane left, ref Vector3 right, out float result)
		{
			result = left.Normal.X * right.X + left.Normal.Y * right.Y + left.Normal.Z * right.Z;
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0001935C File Offset: 0x0001755C
		public static float DotNormal(Plane left, Vector3 right)
		{
			return left.Normal.X * right.X + left.Normal.Y * right.Y + left.Normal.Z * right.Z;
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00019398 File Offset: 0x00017598
		public static void Normalize(ref Plane plane, out Plane result)
		{
			float num = 1f / (float)Math.Sqrt((double)(plane.Normal.X * plane.Normal.X + plane.Normal.Y * plane.Normal.Y + plane.Normal.Z * plane.Normal.Z));
			result.Normal.X = plane.Normal.X * num;
			result.Normal.Y = plane.Normal.Y * num;
			result.Normal.Z = plane.Normal.Z * num;
			result.D = plane.D * num;
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00019450 File Offset: 0x00017650
		public static Plane Normalize(Plane plane)
		{
			float num = 1f / (float)Math.Sqrt((double)(plane.Normal.X * plane.Normal.X + plane.Normal.Y * plane.Normal.Y + plane.Normal.Z * plane.Normal.Z));
			return new Plane(plane.Normal.X * num, plane.Normal.Y * num, plane.Normal.Z * num, plane.D * num);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x000194E8 File Offset: 0x000176E8
		public static void Transform(ref Plane plane, ref Quaternion rotation, out Plane result)
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
			float x = plane.Normal.X;
			float y = plane.Normal.Y;
			float z = plane.Normal.Z;
			result.Normal.X = x * (1f - num10 - num12) + y * (num8 - num6) + z * (num9 + num5);
			result.Normal.Y = x * (num8 + num6) + y * (1f - num7 - num12) + z * (num11 - num4);
			result.Normal.Z = x * (num9 - num5) + y * (num11 + num4) + z * (1f - num7 - num10);
			result.D = plane.D;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0001962C File Offset: 0x0001782C
		public static Plane Transform(Plane plane, Quaternion rotation)
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
			float x = plane.Normal.X;
			float y = plane.Normal.Y;
			float z = plane.Normal.Z;
			Plane result;
			result.Normal.X = x * (1f - num10 - num12) + y * (num8 - num6) + z * (num9 + num5);
			result.Normal.Y = x * (num8 + num6) + y * (1f - num7 - num12) + z * (num11 - num4);
			result.Normal.Z = x * (num9 - num5) + y * (num11 + num4) + z * (1f - num7 - num10);
			result.D = plane.D;
			return result;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00019778 File Offset: 0x00017978
		public static void Transform(Plane[] planes, ref Quaternion rotation)
		{
			if (planes == null)
			{
				throw new ArgumentNullException("planes");
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
			for (int i = 0; i < planes.Length; i++)
			{
				float x = planes[i].Normal.X;
				float y = planes[i].Normal.Y;
				float z = planes[i].Normal.Z;
				planes[i].Normal.X = x * (1f - num10 - num12) + y * (num8 - num6) + z * (num9 + num5);
				planes[i].Normal.Y = x * (num8 + num6) + y * (1f - num7 - num12) + z * (num11 - num4);
				planes[i].Normal.Z = x * (num9 - num5) + y * (num11 + num4) + z * (1f - num7 - num10);
			}
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00019900 File Offset: 0x00017B00
		public static void Transform(ref Plane plane, ref Matrix transformation, out Plane result)
		{
			float x = plane.Normal.X;
			float y = plane.Normal.Y;
			float z = plane.Normal.Z;
			float d = plane.D;
			Matrix matrix;
			Matrix.Invert(ref transformation, out matrix);
			result.Normal.X = x * matrix.M11 + y * matrix.M12 + z * matrix.M13 + d * matrix.M14;
			result.Normal.Y = x * matrix.M21 + y * matrix.M22 + z * matrix.M23 + d * matrix.M24;
			result.Normal.Z = x * matrix.M31 + y * matrix.M32 + z * matrix.M33 + d * matrix.M34;
			result.D = x * matrix.M41 + y * matrix.M42 + z * matrix.M43 + d * matrix.M44;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00019A04 File Offset: 0x00017C04
		public static Plane Transform(Plane plane, Matrix transformation)
		{
			float x = plane.Normal.X;
			float y = plane.Normal.Y;
			float z = plane.Normal.Z;
			float d = plane.D;
			transformation.Invert();
			Plane result;
			result.Normal.X = x * transformation.M11 + y * transformation.M12 + z * transformation.M13 + d * transformation.M14;
			result.Normal.Y = x * transformation.M21 + y * transformation.M22 + z * transformation.M23 + d * transformation.M24;
			result.Normal.Z = x * transformation.M31 + y * transformation.M32 + z * transformation.M33 + d * transformation.M34;
			result.D = x * transformation.M41 + y * transformation.M42 + z * transformation.M43 + d * transformation.M44;
			return result;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00019B00 File Offset: 0x00017D00
		public static void Transform(Plane[] planes, ref Matrix transformation)
		{
			if (planes == null)
			{
				throw new ArgumentNullException("planes");
			}
			Matrix matrix;
			Matrix.Invert(ref transformation, out matrix);
			for (int i = 0; i < planes.Length; i++)
			{
				Plane.Transform(ref planes[i], ref transformation, out planes[i]);
			}
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00019B45 File Offset: 0x00017D45
		public static Plane operator *(float scale, Plane plane)
		{
			return new Plane(plane.Normal.X * scale, plane.Normal.Y * scale, plane.Normal.Z * scale, plane.D * scale);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0001919F File Offset: 0x0001739F
		public static Plane operator *(Plane plane, float scale)
		{
			return new Plane(plane.Normal.X * scale, plane.Normal.Y * scale, plane.Normal.Z * scale, plane.D * scale);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00019B7B File Offset: 0x00017D7B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Plane left, Plane right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00019B86 File Offset: 0x00017D86
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Plane left, Plane right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00019B94 File Offset: 0x00017D94
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "A:{0} B:{1} C:{2} D:{3}", new object[]
			{
				this.Normal.X,
				this.Normal.Y,
				this.Normal.Z,
				this.D
			});
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00019C00 File Offset: 0x00017E00
		public string ToString(string format)
		{
			return string.Format(CultureInfo.CurrentCulture, "A:{0} B:{1} C:{2} D:{3}", new object[]
			{
				this.Normal.X.ToString(format, CultureInfo.CurrentCulture),
				this.Normal.Y.ToString(format, CultureInfo.CurrentCulture),
				this.Normal.Z.ToString(format, CultureInfo.CurrentCulture),
				this.D.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00019C84 File Offset: 0x00017E84
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "A:{0} B:{1} C:{2} D:{3}", new object[]
			{
				this.Normal.X,
				this.Normal.Y,
				this.Normal.Z,
				this.D
			});
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00019CEC File Offset: 0x00017EEC
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "A:{0} B:{1} C:{2} D:{3}", new object[]
			{
				this.Normal.X.ToString(format, formatProvider),
				this.Normal.Y.ToString(format, formatProvider),
				this.Normal.Z.ToString(format, formatProvider),
				this.D.ToString(format, formatProvider)
			});
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00019D59 File Offset: 0x00017F59
		public override int GetHashCode()
		{
			return this.Normal.GetHashCode() * 397 ^ this.D.GetHashCode();
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00019D7E File Offset: 0x00017F7E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Plane value)
		{
			return this.Normal == value.Normal && this.D == value.D;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00019DA3 File Offset: 0x00017FA3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Plane value)
		{
			return this.Equals(ref value);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00019DB0 File Offset: 0x00017FB0
		public override bool Equals(object value)
		{
			if (!(value is Plane))
			{
				return false;
			}
			Plane plane = (Plane)value;
			return this.Equals(ref plane);
		}

		// Token: 0x0400014C RID: 332
		public Vector3 Normal;

		// Token: 0x0400014D RID: 333
		public float D;
	}
}

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000020 RID: 32
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Quaternion : IEquatable<Quaternion>, IFormattable
	{
		// Token: 0x0600050F RID: 1295 RVA: 0x00019ED2 File Offset: 0x000180D2
		public Quaternion(float value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
			this.W = value;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00019EF0 File Offset: 0x000180F0
		public Quaternion(Vector4 value)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = value.Z;
			this.W = value.W;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00019F22 File Offset: 0x00018122
		public Quaternion(Vector3 value, float w)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = value.Z;
			this.W = w;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00019F4F File Offset: 0x0001814F
		public Quaternion(Vector2 value, float z, float w)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00019F77 File Offset: 0x00018177
		public Quaternion(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00019F98 File Offset: 0x00018198
		public Quaternion(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Quaternion.");
			}
			this.X = values[0];
			this.Y = values[1];
			this.Z = values[2];
			this.W = values[3];
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x00019FED File Offset: 0x000181ED
		public bool IsIdentity
		{
			get
			{
				return this.Equals(Quaternion.Identity);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x00019FFA File Offset: 0x000181FA
		public bool IsNormalized
		{
			get
			{
				return MathUtil.IsOne(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x0001A038 File Offset: 0x00018238
		public float Angle
		{
			get
			{
				if (MathUtil.IsZero(this.X * this.X + this.Y * this.Y + this.Z * this.Z))
				{
					return 0f;
				}
				return (float)(2.0 * Math.Acos((double)MathUtil.Clamp(this.W, -1f, 1f)));
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x0001A0A4 File Offset: 0x000182A4
		public Vector3 Axis
		{
			get
			{
				float num = this.X * this.X + this.Y * this.Y + this.Z * this.Z;
				if (MathUtil.IsZero(num))
				{
					return Vector3.UnitX;
				}
				float num2 = 1f / (float)Math.Sqrt((double)num);
				return new Vector3(this.X * num2, this.Y * num2, this.Z * num2);
			}
		}

		// Token: 0x17000066 RID: 102
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
					throw new ArgumentOutOfRangeException("index", "Indices for Quaternion run from 0 to 3, inclusive.");
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
					throw new ArgumentOutOfRangeException("index", "Indices for Quaternion run from 0 to 3, inclusive.");
				}
			}
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0001A1BC File Offset: 0x000183BC
		public void Conjugate()
		{
			this.X = -this.X;
			this.Y = -this.Y;
			this.Z = -this.Z;
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0001A1E8 File Offset: 0x000183E8
		public void Invert()
		{
			float num = this.LengthSquared();
			if (!MathUtil.IsZero(num))
			{
				num = 1f / num;
				this.X = -this.X * num;
				this.Y = -this.Y * num;
				this.Z = -this.Z * num;
				this.W *= num;
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0001A247 File Offset: 0x00018447
		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W));
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0001A287 File Offset: 0x00018487
		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0001A2C0 File Offset: 0x000184C0
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

		// Token: 0x06000520 RID: 1312 RVA: 0x0001A31C File Offset: 0x0001851C
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

		// Token: 0x06000521 RID: 1313 RVA: 0x0001A348 File Offset: 0x00018548
		public static void Add(ref Quaternion left, ref Quaternion right, out Quaternion result)
		{
			result.X = left.X + right.X;
			result.Y = left.Y + right.Y;
			result.Z = left.Z + right.Z;
			result.W = left.W + right.W;
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0001A3A4 File Offset: 0x000185A4
		public static Quaternion Add(Quaternion left, Quaternion right)
		{
			Quaternion result;
			Quaternion.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001A3C0 File Offset: 0x000185C0
		public static void Subtract(ref Quaternion left, ref Quaternion right, out Quaternion result)
		{
			result.X = left.X - right.X;
			result.Y = left.Y - right.Y;
			result.Z = left.Z - right.Z;
			result.W = left.W - right.W;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0001A41C File Offset: 0x0001861C
		public static Quaternion Subtract(Quaternion left, Quaternion right)
		{
			Quaternion result;
			Quaternion.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0001A435 File Offset: 0x00018635
		public static void Multiply(ref Quaternion value, float scale, out Quaternion result)
		{
			result.X = value.X * scale;
			result.Y = value.Y * scale;
			result.Z = value.Z * scale;
			result.W = value.W * scale;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0001A470 File Offset: 0x00018670
		public static Quaternion Multiply(Quaternion value, float scale)
		{
			Quaternion result;
			Quaternion.Multiply(ref value, scale, out result);
			return result;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0001A488 File Offset: 0x00018688
		public static void Multiply(ref Quaternion left, ref Quaternion right, out Quaternion result)
		{
			float x = left.X;
			float y = left.Y;
			float z = left.Z;
			float w = left.W;
			float x2 = right.X;
			float y2 = right.Y;
			float z2 = right.Z;
			float w2 = right.W;
			float num = y * z2 - z * y2;
			float num2 = z * x2 - x * z2;
			float num3 = x * y2 - y * x2;
			float num4 = x * x2 + y * y2 + z * z2;
			result.X = x * w2 + x2 * w + num;
			result.Y = y * w2 + y2 * w + num2;
			result.Z = z * w2 + z2 * w + num3;
			result.W = w * w2 - num4;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0001A548 File Offset: 0x00018748
		public static Quaternion Multiply(Quaternion left, Quaternion right)
		{
			Quaternion result;
			Quaternion.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0001A561 File Offset: 0x00018761
		public static void Negate(ref Quaternion value, out Quaternion result)
		{
			result.X = -value.X;
			result.Y = -value.Y;
			result.Z = -value.Z;
			result.W = -value.W;
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0001A598 File Offset: 0x00018798
		public static Quaternion Negate(Quaternion value)
		{
			Quaternion result;
			Quaternion.Negate(ref value, out result);
			return result;
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001A5B0 File Offset: 0x000187B0
		public static void Barycentric(ref Quaternion value1, ref Quaternion value2, ref Quaternion value3, float amount1, float amount2, out Quaternion result)
		{
			Quaternion quaternion;
			Quaternion.Slerp(ref value1, ref value2, amount1 + amount2, out quaternion);
			Quaternion quaternion2;
			Quaternion.Slerp(ref value1, ref value3, amount1 + amount2, out quaternion2);
			Quaternion.Slerp(ref quaternion, ref quaternion2, amount2 / (amount1 + amount2), out result);
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0001A5EC File Offset: 0x000187EC
		public static Quaternion Barycentric(Quaternion value1, Quaternion value2, Quaternion value3, float amount1, float amount2)
		{
			Quaternion result;
			Quaternion.Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
			return result;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0001A60A File Offset: 0x0001880A
		public static void Conjugate(ref Quaternion value, out Quaternion result)
		{
			result.X = -value.X;
			result.Y = -value.Y;
			result.Z = -value.Z;
			result.W = value.W;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0001A640 File Offset: 0x00018840
		public static Quaternion Conjugate(Quaternion value)
		{
			Quaternion result;
			Quaternion.Conjugate(ref value, out result);
			return result;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0001A657 File Offset: 0x00018857
		public static void Dot(ref Quaternion left, ref Quaternion right, out float result)
		{
			result = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0001A692 File Offset: 0x00018892
		public static float Dot(Quaternion left, Quaternion right)
		{
			return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0001A6CC File Offset: 0x000188CC
		public static void Exponential(ref Quaternion value, out Quaternion result)
		{
			float num = (float)Math.Sqrt((double)(value.X * value.X + value.Y * value.Y + value.Z * value.Z));
			float num2 = (float)Math.Sin((double)num);
			if (!MathUtil.IsZero(num2))
			{
				float num3 = num2 / num;
				result.X = num3 * value.X;
				result.Y = num3 * value.Y;
				result.Z = num3 * value.Z;
			}
			else
			{
				result = value;
			}
			result.W = (float)Math.Cos((double)num);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0001A768 File Offset: 0x00018968
		public static Quaternion Exponential(Quaternion value)
		{
			Quaternion result;
			Quaternion.Exponential(ref value, out result);
			return result;
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0001A77F File Offset: 0x0001897F
		public static void Invert(ref Quaternion value, out Quaternion result)
		{
			result = value;
			result.Invert();
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0001A794 File Offset: 0x00018994
		public static Quaternion Invert(Quaternion value)
		{
			Quaternion result;
			Quaternion.Invert(ref value, out result);
			return result;
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0001A7AC File Offset: 0x000189AC
		public static void Lerp(ref Quaternion start, ref Quaternion end, float amount, out Quaternion result)
		{
			float num = 1f - amount;
			if (Quaternion.Dot(start, end) >= 0f)
			{
				result.X = num * start.X + amount * end.X;
				result.Y = num * start.Y + amount * end.Y;
				result.Z = num * start.Z + amount * end.Z;
				result.W = num * start.W + amount * end.W;
			}
			else
			{
				result.X = num * start.X - amount * end.X;
				result.Y = num * start.Y - amount * end.Y;
				result.Z = num * start.Z - amount * end.Z;
				result.W = num * start.W - amount * end.W;
			}
			result.Normalize();
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0001A89C File Offset: 0x00018A9C
		public static Quaternion Lerp(Quaternion start, Quaternion end, float amount)
		{
			Quaternion result;
			Quaternion.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0001A8B8 File Offset: 0x00018AB8
		public static void Logarithm(ref Quaternion value, out Quaternion result)
		{
			if ((double)Math.Abs(value.W) < 1.0)
			{
				float num = (float)Math.Acos((double)value.W);
				float num2 = (float)Math.Sin((double)num);
				if (!MathUtil.IsZero(num2))
				{
					float num3 = num / num2;
					result.X = value.X * num3;
					result.Y = value.Y * num3;
					result.Z = value.Z * num3;
				}
				else
				{
					result = value;
				}
			}
			else
			{
				result = value;
			}
			result.W = 0f;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0001A950 File Offset: 0x00018B50
		public static Quaternion Logarithm(Quaternion value)
		{
			Quaternion result;
			Quaternion.Logarithm(ref value, out result);
			return result;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001A968 File Offset: 0x00018B68
		public static void Normalize(ref Quaternion value, out Quaternion result)
		{
			Quaternion quaternion = value;
			result = quaternion;
			result.Normalize();
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0001A989 File Offset: 0x00018B89
		public static Quaternion Normalize(Quaternion value)
		{
			value.Normalize();
			return value;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0001A994 File Offset: 0x00018B94
		public static void RotationAxis(ref Vector3 axis, float angle, out Quaternion result)
		{
			Vector3 vector;
			Vector3.Normalize(ref axis, out vector);
			float num = angle * 0.5f;
			float num2 = (float)Math.Sin((double)num);
			float w = (float)Math.Cos((double)num);
			result.X = vector.X * num2;
			result.Y = vector.Y * num2;
			result.Z = vector.Z * num2;
			result.W = w;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0001A9F4 File Offset: 0x00018BF4
		public static Quaternion RotationAxis(Vector3 axis, float angle)
		{
			Quaternion result;
			Quaternion.RotationAxis(ref axis, angle, out result);
			return result;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0001AA0C File Offset: 0x00018C0C
		public static void RotationMatrix(ref Matrix matrix, out Quaternion result)
		{
			float num = matrix.M11 + matrix.M22 + matrix.M33;
			float num2;
			if (num > 0f)
			{
				num2 = (float)Math.Sqrt((double)(num + 1f));
				result.W = num2 * 0.5f;
				num2 = 0.5f / num2;
				result.X = (matrix.M23 - matrix.M32) * num2;
				result.Y = (matrix.M31 - matrix.M13) * num2;
				result.Z = (matrix.M12 - matrix.M21) * num2;
				return;
			}
			float num3;
			if (matrix.M11 >= matrix.M22 && matrix.M11 >= matrix.M33)
			{
				num2 = (float)Math.Sqrt((double)(1f + matrix.M11 - matrix.M22 - matrix.M33));
				num3 = 0.5f / num2;
				result.X = 0.5f * num2;
				result.Y = (matrix.M12 + matrix.M21) * num3;
				result.Z = (matrix.M13 + matrix.M31) * num3;
				result.W = (matrix.M23 - matrix.M32) * num3;
				return;
			}
			if (matrix.M22 > matrix.M33)
			{
				num2 = (float)Math.Sqrt((double)(1f + matrix.M22 - matrix.M11 - matrix.M33));
				num3 = 0.5f / num2;
				result.X = (matrix.M21 + matrix.M12) * num3;
				result.Y = 0.5f * num2;
				result.Z = (matrix.M32 + matrix.M23) * num3;
				result.W = (matrix.M31 - matrix.M13) * num3;
				return;
			}
			num2 = (float)Math.Sqrt((double)(1f + matrix.M33 - matrix.M11 - matrix.M22));
			num3 = 0.5f / num2;
			result.X = (matrix.M31 + matrix.M13) * num3;
			result.Y = (matrix.M32 + matrix.M23) * num3;
			result.Z = 0.5f * num2;
			result.W = (matrix.M12 - matrix.M21) * num3;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0001AC2C File Offset: 0x00018E2C
		public static void RotationMatrix(ref Matrix3x3 matrix, out Quaternion result)
		{
			float num = matrix.M11 + matrix.M22 + matrix.M33;
			float num2;
			if (num > 0f)
			{
				num2 = (float)Math.Sqrt((double)(num + 1f));
				result.W = num2 * 0.5f;
				num2 = 0.5f / num2;
				result.X = (matrix.M23 - matrix.M32) * num2;
				result.Y = (matrix.M31 - matrix.M13) * num2;
				result.Z = (matrix.M12 - matrix.M21) * num2;
				return;
			}
			float num3;
			if (matrix.M11 >= matrix.M22 && matrix.M11 >= matrix.M33)
			{
				num2 = (float)Math.Sqrt((double)(1f + matrix.M11 - matrix.M22 - matrix.M33));
				num3 = 0.5f / num2;
				result.X = 0.5f * num2;
				result.Y = (matrix.M12 + matrix.M21) * num3;
				result.Z = (matrix.M13 + matrix.M31) * num3;
				result.W = (matrix.M23 - matrix.M32) * num3;
				return;
			}
			if (matrix.M22 > matrix.M33)
			{
				num2 = (float)Math.Sqrt((double)(1f + matrix.M22 - matrix.M11 - matrix.M33));
				num3 = 0.5f / num2;
				result.X = (matrix.M21 + matrix.M12) * num3;
				result.Y = 0.5f * num2;
				result.Z = (matrix.M32 + matrix.M23) * num3;
				result.W = (matrix.M31 - matrix.M13) * num3;
				return;
			}
			num2 = (float)Math.Sqrt((double)(1f + matrix.M33 - matrix.M11 - matrix.M22));
			num3 = 0.5f / num2;
			result.X = (matrix.M31 + matrix.M13) * num3;
			result.Y = (matrix.M32 + matrix.M23) * num3;
			result.Z = 0.5f * num2;
			result.W = (matrix.M12 - matrix.M21) * num3;
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001AE4C File Offset: 0x0001904C
		public static void LookAtLH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Quaternion result)
		{
			Matrix3x3 matrix3x;
			Matrix3x3.LookAtLH(ref eye, ref target, ref up, out matrix3x);
			Quaternion.RotationMatrix(ref matrix3x, out result);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001AE6C File Offset: 0x0001906C
		public static Quaternion LookAtLH(Vector3 eye, Vector3 target, Vector3 up)
		{
			Quaternion result;
			Quaternion.LookAtLH(ref eye, ref target, ref up, out result);
			return result;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0001AE88 File Offset: 0x00019088
		public static void RotationLookAtLH(ref Vector3 forward, ref Vector3 up, out Quaternion result)
		{
			Vector3 zero = Vector3.Zero;
			Quaternion.LookAtLH(ref zero, ref forward, ref up, out result);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001AEA8 File Offset: 0x000190A8
		public static Quaternion RotationLookAtLH(Vector3 forward, Vector3 up)
		{
			Quaternion result;
			Quaternion.RotationLookAtLH(ref forward, ref up, out result);
			return result;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001AEC4 File Offset: 0x000190C4
		public static void LookAtRH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Quaternion result)
		{
			Matrix3x3 matrix3x;
			Matrix3x3.LookAtRH(ref eye, ref target, ref up, out matrix3x);
			Quaternion.RotationMatrix(ref matrix3x, out result);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0001AEE4 File Offset: 0x000190E4
		public static Quaternion LookAtRH(Vector3 eye, Vector3 target, Vector3 up)
		{
			Quaternion result;
			Quaternion.LookAtRH(ref eye, ref target, ref up, out result);
			return result;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0001AF00 File Offset: 0x00019100
		public static void RotationLookAtRH(ref Vector3 forward, ref Vector3 up, out Quaternion result)
		{
			Vector3 zero = Vector3.Zero;
			Quaternion.LookAtRH(ref zero, ref forward, ref up, out result);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0001AF20 File Offset: 0x00019120
		public static Quaternion RotationLookAtRH(Vector3 forward, Vector3 up)
		{
			Quaternion result;
			Quaternion.RotationLookAtRH(ref forward, ref up, out result);
			return result;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0001AF3C File Offset: 0x0001913C
		public static void BillboardLH(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, ref Vector3 cameraForwardVector, out Quaternion result)
		{
			Matrix3x3 matrix3x;
			Matrix3x3.BillboardLH(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out matrix3x);
			Quaternion.RotationMatrix(ref matrix3x, out result);
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0001AF60 File Offset: 0x00019160
		public static Quaternion BillboardLH(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector)
		{
			Quaternion result;
			Quaternion.BillboardLH(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
			return result;
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0001AF80 File Offset: 0x00019180
		public static void BillboardRH(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, ref Vector3 cameraForwardVector, out Quaternion result)
		{
			Matrix3x3 matrix3x;
			Matrix3x3.BillboardRH(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out matrix3x);
			Quaternion.RotationMatrix(ref matrix3x, out result);
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0001AFA4 File Offset: 0x000191A4
		public static Quaternion BillboardRH(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector)
		{
			Quaternion result;
			Quaternion.BillboardRH(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
			return result;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0001AFC4 File Offset: 0x000191C4
		public static Quaternion RotationMatrix(Matrix matrix)
		{
			Quaternion result;
			Quaternion.RotationMatrix(ref matrix, out result);
			return result;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0001AFDC File Offset: 0x000191DC
		public static void RotationYawPitchRoll(float yaw, float pitch, float roll, out Quaternion result)
		{
			float num = roll * 0.5f;
			float num2 = pitch * 0.5f;
			float num3 = yaw * 0.5f;
			float num4 = (float)Math.Sin((double)num);
			float num5 = (float)Math.Cos((double)num);
			float num6 = (float)Math.Sin((double)num2);
			float num7 = (float)Math.Cos((double)num2);
			float num8 = (float)Math.Sin((double)num3);
			float num9 = (float)Math.Cos((double)num3);
			result.X = num9 * num6 * num5 + num8 * num7 * num4;
			result.Y = num8 * num7 * num5 - num9 * num6 * num4;
			result.Z = num9 * num7 * num4 - num8 * num6 * num5;
			result.W = num9 * num7 * num5 + num8 * num6 * num4;
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0001B090 File Offset: 0x00019290
		public static Quaternion RotationYawPitchRoll(float yaw, float pitch, float roll)
		{
			Quaternion result;
			Quaternion.RotationYawPitchRoll(yaw, pitch, roll, out result);
			return result;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0001B0A8 File Offset: 0x000192A8
		public static void Slerp(ref Quaternion start, ref Quaternion end, float amount, out Quaternion result)
		{
			float value = Quaternion.Dot(start, end);
			float num;
			float num2;
			if (Math.Abs(value) > 0.999999f)
			{
				num = 1f - amount;
				num2 = amount * (float)Math.Sign(value);
			}
			else
			{
				float num3 = (float)Math.Acos((double)Math.Abs(value));
				float num4 = (float)(1.0 / Math.Sin((double)num3));
				num = (float)Math.Sin((double)((1f - amount) * num3)) * num4;
				num2 = (float)Math.Sin((double)(amount * num3)) * num4 * (float)Math.Sign(value);
			}
			result.X = num * start.X + num2 * end.X;
			result.Y = num * start.Y + num2 * end.Y;
			result.Z = num * start.Z + num2 * end.Z;
			result.W = num * start.W + num2 * end.W;
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0001B190 File Offset: 0x00019390
		public static Quaternion Slerp(Quaternion start, Quaternion end, float amount)
		{
			Quaternion result;
			Quaternion.Slerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0001B1AC File Offset: 0x000193AC
		public static void Squad(ref Quaternion value1, ref Quaternion value2, ref Quaternion value3, ref Quaternion value4, float amount, out Quaternion result)
		{
			Quaternion quaternion;
			Quaternion.Slerp(ref value1, ref value4, amount, out quaternion);
			Quaternion quaternion2;
			Quaternion.Slerp(ref value2, ref value3, amount, out quaternion2);
			Quaternion.Slerp(ref quaternion, ref quaternion2, 2f * amount * (1f - amount), out result);
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0001B1EC File Offset: 0x000193EC
		public static Quaternion Squad(Quaternion value1, Quaternion value2, Quaternion value3, Quaternion value4, float amount)
		{
			Quaternion result;
			Quaternion.Squad(ref value1, ref value2, ref value3, ref value4, amount, out result);
			return result;
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001B20C File Offset: 0x0001940C
		public static Quaternion[] SquadSetup(Quaternion value1, Quaternion value2, Quaternion value3, Quaternion value4)
		{
			Quaternion right = ((value1 + value2).LengthSquared() < (value1 - value2).LengthSquared()) ? (-value1) : value1;
			Quaternion quaternion = ((value2 + value3).LengthSquared() < (value2 - value3).LengthSquared()) ? (-value3) : value3;
			Quaternion right2 = ((value3 + value4).LengthSquared() < (value3 - value4).LengthSquared()) ? (-value4) : value4;
			Quaternion quaternion2 = value2;
			Quaternion left;
			Quaternion.Exponential(ref quaternion2, out left);
			Quaternion left2;
			Quaternion.Exponential(ref quaternion, out left2);
			return new Quaternion[]
			{
				quaternion2 * Quaternion.Exponential(-0.25f * (Quaternion.Logarithm(left * quaternion) + Quaternion.Logarithm(left * right))),
				quaternion * Quaternion.Exponential(-0.25f * (Quaternion.Logarithm(left2 * right2) + Quaternion.Logarithm(left2 * quaternion2))),
				quaternion
			};
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001B338 File Offset: 0x00019538
		public static Quaternion operator +(Quaternion left, Quaternion right)
		{
			Quaternion result;
			Quaternion.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0001B354 File Offset: 0x00019554
		public static Quaternion operator -(Quaternion left, Quaternion right)
		{
			Quaternion result;
			Quaternion.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0001B370 File Offset: 0x00019570
		public static Quaternion operator -(Quaternion value)
		{
			Quaternion result;
			Quaternion.Negate(ref value, out result);
			return result;
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0001B388 File Offset: 0x00019588
		public static Quaternion operator *(float scale, Quaternion value)
		{
			Quaternion result;
			Quaternion.Multiply(ref value, scale, out result);
			return result;
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0001B3A0 File Offset: 0x000195A0
		public static Quaternion operator *(Quaternion value, float scale)
		{
			Quaternion result;
			Quaternion.Multiply(ref value, scale, out result);
			return result;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0001B3B8 File Offset: 0x000195B8
		public static Quaternion operator *(Quaternion left, Quaternion right)
		{
			Quaternion result;
			Quaternion.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0001B3D1 File Offset: 0x000195D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Quaternion left, Quaternion right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0001B3DC File Offset: 0x000195DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Quaternion left, Quaternion right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0001B3EC File Offset: 0x000195EC
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

		// Token: 0x0600055C RID: 1372 RVA: 0x0001B448 File Offset: 0x00019648
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

		// Token: 0x0600055D RID: 1373 RVA: 0x0001B4CC File Offset: 0x000196CC
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

		// Token: 0x0600055E RID: 1374 RVA: 0x0001B524 File Offset: 0x00019724
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "X:{0} Y:{1} Z:{2} W:{3}", new object[]
			{
				this.X.ToString(format, formatProvider),
				this.Y.ToString(format, formatProvider),
				this.Z.ToString(format, formatProvider),
				this.W.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0001B590 File Offset: 0x00019790
		public override int GetHashCode()
		{
			return ((this.X.GetHashCode() * 397 ^ this.Y.GetHashCode()) * 397 ^ this.Z.GetHashCode()) * 397 ^ this.W.GetHashCode();
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0001B5E0 File Offset: 0x000197E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Quaternion other)
		{
			return MathUtil.NearEqual(other.X, this.X) && MathUtil.NearEqual(other.Y, this.Y) && MathUtil.NearEqual(other.Z, this.Z) && MathUtil.NearEqual(other.W, this.W);
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0001B639 File Offset: 0x00019839
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Quaternion other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0001B644 File Offset: 0x00019844
		public override bool Equals(object value)
		{
			if (!(value is Quaternion))
			{
				return false;
			}
			Quaternion quaternion = (Quaternion)value;
			return this.Equals(ref quaternion);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0001B66A File Offset: 0x0001986A
		public unsafe static implicit operator RawQuaternion(Quaternion value)
		{
			return *(RawQuaternion*)(&value);
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0001B674 File Offset: 0x00019874
		public unsafe static implicit operator Quaternion(RawQuaternion value)
		{
			return *(Quaternion*)(&value);
		}

		// Token: 0x04000151 RID: 337
		public static readonly int SizeInBytes = Utilities.SizeOf<Quaternion>();

		// Token: 0x04000152 RID: 338
		public static readonly Quaternion Zero = default(Quaternion);

		// Token: 0x04000153 RID: 339
		public static readonly Quaternion One = new Quaternion(1f, 1f, 1f, 1f);

		// Token: 0x04000154 RID: 340
		public static readonly Quaternion Identity = new Quaternion(0f, 0f, 0f, 1f);

		// Token: 0x04000155 RID: 341
		public float X;

		// Token: 0x04000156 RID: 342
		public float Y;

		// Token: 0x04000157 RID: 343
		public float Z;

		// Token: 0x04000158 RID: 344
		public float W;
	}
}

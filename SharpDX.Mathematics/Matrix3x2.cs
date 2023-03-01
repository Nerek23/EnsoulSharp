using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x0200001A RID: 26
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Matrix3x2
	{
		// Token: 0x06000396 RID: 918 RVA: 0x000119A0 File Offset: 0x0000FBA0
		public Matrix3x2(float value)
		{
			this.M32 = value;
			this.M31 = value;
			this.M22 = value;
			this.M21 = value;
			this.M12 = value;
			this.M11 = value;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x000119E1 File Offset: 0x0000FBE1
		public Matrix3x2(float M11, float M12, float M21, float M22, float M31, float M32)
		{
			this.M11 = M11;
			this.M12 = M12;
			this.M21 = M21;
			this.M22 = M22;
			this.M31 = M31;
			this.M32 = M32;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00011A10 File Offset: 0x0000FC10
		public Matrix3x2(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 6)
			{
				throw new ArgumentOutOfRangeException("values", "There must be six input values for Matrix3x2.");
			}
			this.M11 = values[0];
			this.M12 = values[1];
			this.M21 = values[2];
			this.M22 = values[3];
			this.M31 = values[4];
			this.M32 = values[5];
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00011A77 File Offset: 0x0000FC77
		// (set) Token: 0x0600039A RID: 922 RVA: 0x00011A8A File Offset: 0x0000FC8A
		public Vector2 Row1
		{
			get
			{
				return new Vector2(this.M11, this.M12);
			}
			set
			{
				this.M11 = value.X;
				this.M12 = value.Y;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00011AA4 File Offset: 0x0000FCA4
		// (set) Token: 0x0600039C RID: 924 RVA: 0x00011AB7 File Offset: 0x0000FCB7
		public Vector2 Row2
		{
			get
			{
				return new Vector2(this.M21, this.M22);
			}
			set
			{
				this.M21 = value.X;
				this.M22 = value.Y;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00011AD1 File Offset: 0x0000FCD1
		// (set) Token: 0x0600039E RID: 926 RVA: 0x00011AE4 File Offset: 0x0000FCE4
		public Vector2 Row3
		{
			get
			{
				return new Vector2(this.M31, this.M32);
			}
			set
			{
				this.M31 = value.X;
				this.M32 = value.Y;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00011AFE File Offset: 0x0000FCFE
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x00011B17 File Offset: 0x0000FD17
		public Vector3 Column1
		{
			get
			{
				return new Vector3(this.M11, this.M21, this.M31);
			}
			set
			{
				this.M11 = value.X;
				this.M21 = value.Y;
				this.M31 = value.Z;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00011B3D File Offset: 0x0000FD3D
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x00011B56 File Offset: 0x0000FD56
		public Vector3 Column2
		{
			get
			{
				return new Vector3(this.M12, this.M22, this.M32);
			}
			set
			{
				this.M12 = value.X;
				this.M22 = value.Y;
				this.M32 = value.Z;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00011AD1 File Offset: 0x0000FCD1
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x00011AE4 File Offset: 0x0000FCE4
		public Vector2 TranslationVector
		{
			get
			{
				return new Vector2(this.M31, this.M32);
			}
			set
			{
				this.M31 = value.X;
				this.M32 = value.Y;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x00011B7C File Offset: 0x0000FD7C
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x00011B8F File Offset: 0x0000FD8F
		public Vector2 ScaleVector
		{
			get
			{
				return new Vector2(this.M11, this.M22);
			}
			set
			{
				this.M11 = value.X;
				this.M22 = value.Y;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00011BA9 File Offset: 0x0000FDA9
		public bool IsIdentity
		{
			get
			{
				return this.Equals(Matrix3x2.Identity);
			}
		}

		// Token: 0x17000049 RID: 73
		public float this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.M11;
				case 1:
					return this.M12;
				case 2:
					return this.M21;
				case 3:
					return this.M22;
				case 4:
					return this.M31;
				case 5:
					return this.M32;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Matrix3x2 run from 0 to 5, inclusive.");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.M11 = value;
					return;
				case 1:
					this.M12 = value;
					return;
				case 2:
					this.M21 = value;
					return;
				case 3:
					this.M22 = value;
					return;
				case 4:
					this.M31 = value;
					return;
				case 5:
					this.M32 = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Matrix3x2 run from 0 to 5, inclusive.");
				}
			}
		}

		// Token: 0x1700004A RID: 74
		public float this[int row, int column]
		{
			get
			{
				if (row < 0 || row > 2)
				{
					throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 2, inclusive.");
				}
				if (column < 0 || column > 1)
				{
					throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 1, inclusive.");
				}
				return this[row * 2 + column];
			}
			set
			{
				if (row < 0 || row > 2)
				{
					throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 2, inclusive.");
				}
				if (column < 0 || column > 1)
				{
					throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 1, inclusive.");
				}
				this[row * 2 + column] = value;
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00011D07 File Offset: 0x0000FF07
		public float[] ToArray()
		{
			return new float[]
			{
				this.M11,
				this.M12,
				this.M21,
				this.M22,
				this.M31,
				this.M32
			};
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00011D48 File Offset: 0x0000FF48
		public static void Add(ref Matrix3x2 left, ref Matrix3x2 right, out Matrix3x2 result)
		{
			result.M11 = left.M11 + right.M11;
			result.M12 = left.M12 + right.M12;
			result.M21 = left.M21 + right.M21;
			result.M22 = left.M22 + right.M22;
			result.M31 = left.M31 + right.M31;
			result.M32 = left.M32 + right.M32;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00011DC8 File Offset: 0x0000FFC8
		public static Matrix3x2 Add(Matrix3x2 left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00011DE4 File Offset: 0x0000FFE4
		public static void Subtract(ref Matrix3x2 left, ref Matrix3x2 right, out Matrix3x2 result)
		{
			result.M11 = left.M11 - right.M11;
			result.M12 = left.M12 - right.M12;
			result.M21 = left.M21 - right.M21;
			result.M22 = left.M22 - right.M22;
			result.M31 = left.M31 - right.M31;
			result.M32 = left.M32 - right.M32;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00011E64 File Offset: 0x00010064
		public static Matrix3x2 Subtract(Matrix3x2 left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00011E80 File Offset: 0x00010080
		public static void Multiply(ref Matrix3x2 left, float right, out Matrix3x2 result)
		{
			result.M11 = left.M11 * right;
			result.M12 = left.M12 * right;
			result.M21 = left.M21 * right;
			result.M22 = left.M22 * right;
			result.M31 = left.M31 * right;
			result.M32 = left.M32 * right;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00011EE4 File Offset: 0x000100E4
		public static Matrix3x2 Multiply(Matrix3x2 left, float right)
		{
			Matrix3x2 result;
			Matrix3x2.Multiply(ref left, right, out result);
			return result;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00011EFC File Offset: 0x000100FC
		public static void Multiply(ref Matrix3x2 left, ref Matrix3x2 right, out Matrix3x2 result)
		{
			result = new Matrix3x2
			{
				M11 = left.M11 * right.M11 + left.M12 * right.M21,
				M12 = left.M11 * right.M12 + left.M12 * right.M22,
				M21 = left.M21 * right.M11 + left.M22 * right.M21,
				M22 = left.M21 * right.M12 + left.M22 * right.M22,
				M31 = left.M31 * right.M11 + left.M32 * right.M21 + right.M31,
				M32 = left.M31 * right.M12 + left.M32 * right.M22 + right.M32
			};
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00011FF4 File Offset: 0x000101F4
		public static Matrix3x2 Multiply(Matrix3x2 left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00012010 File Offset: 0x00010210
		public static void Divide(ref Matrix3x2 left, float right, out Matrix3x2 result)
		{
			float num = 1f / right;
			result.M11 = left.M11 * num;
			result.M12 = left.M12 * num;
			result.M21 = left.M21 * num;
			result.M22 = left.M22 * num;
			result.M31 = left.M31 * num;
			result.M32 = left.M32 * num;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0001207C File Offset: 0x0001027C
		public static void Divide(ref Matrix3x2 left, ref Matrix3x2 right, out Matrix3x2 result)
		{
			result.M11 = left.M11 / right.M11;
			result.M12 = left.M12 / right.M12;
			result.M21 = left.M21 / right.M21;
			result.M22 = left.M22 / right.M22;
			result.M31 = left.M31 / right.M31;
			result.M32 = left.M32 / right.M32;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x000120FC File Offset: 0x000102FC
		public static void Negate(ref Matrix3x2 value, out Matrix3x2 result)
		{
			result.M11 = -value.M11;
			result.M12 = -value.M12;
			result.M21 = -value.M21;
			result.M22 = -value.M22;
			result.M31 = -value.M31;
			result.M32 = -value.M32;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00012158 File Offset: 0x00010358
		public static Matrix3x2 Negate(Matrix3x2 value)
		{
			Matrix3x2 result;
			Matrix3x2.Negate(ref value, out result);
			return result;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00012170 File Offset: 0x00010370
		public static void Lerp(ref Matrix3x2 start, ref Matrix3x2 end, float amount, out Matrix3x2 result)
		{
			result.M11 = MathUtil.Lerp(start.M11, end.M11, amount);
			result.M12 = MathUtil.Lerp(start.M12, end.M12, amount);
			result.M21 = MathUtil.Lerp(start.M21, end.M21, amount);
			result.M22 = MathUtil.Lerp(start.M22, end.M22, amount);
			result.M31 = MathUtil.Lerp(start.M31, end.M31, amount);
			result.M32 = MathUtil.Lerp(start.M32, end.M32, amount);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00012210 File Offset: 0x00010410
		public static Matrix3x2 Lerp(Matrix3x2 start, Matrix3x2 end, float amount)
		{
			Matrix3x2 result;
			Matrix3x2.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0001222A File Offset: 0x0001042A
		public static void SmoothStep(ref Matrix3x2 start, ref Matrix3x2 end, float amount, out Matrix3x2 result)
		{
			amount = MathUtil.SmoothStep(amount);
			Matrix3x2.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00012240 File Offset: 0x00010440
		public static Matrix3x2 SmoothStep(Matrix3x2 start, Matrix3x2 end, float amount)
		{
			Matrix3x2 result;
			Matrix3x2.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0001225A File Offset: 0x0001045A
		public static void Scaling(ref Vector2 scale, out Matrix3x2 result)
		{
			Matrix3x2.Scaling(scale.X, scale.Y, out result);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00012270 File Offset: 0x00010470
		public static Matrix3x2 Scaling(Vector2 scale)
		{
			Matrix3x2 result;
			Matrix3x2.Scaling(ref scale, out result);
			return result;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00012287 File Offset: 0x00010487
		public static void Scaling(float x, float y, out Matrix3x2 result)
		{
			result = Matrix3x2.Identity;
			result.M11 = x;
			result.M22 = y;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000122A4 File Offset: 0x000104A4
		public static Matrix3x2 Scaling(float x, float y)
		{
			Matrix3x2 result;
			Matrix3x2.Scaling(x, y, out result);
			return result;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000122BC File Offset: 0x000104BC
		public static void Scaling(float scale, out Matrix3x2 result)
		{
			result = Matrix3x2.Identity;
			result.M22 = scale;
			result.M11 = scale;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x000122E4 File Offset: 0x000104E4
		public static Matrix3x2 Scaling(float scale)
		{
			Matrix3x2 result;
			Matrix3x2.Scaling(scale, out result);
			return result;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x000122FC File Offset: 0x000104FC
		public static Matrix3x2 Scaling(float x, float y, Vector2 center)
		{
			Matrix3x2 result;
			result.M11 = x;
			result.M12 = 0f;
			result.M21 = 0f;
			result.M22 = y;
			result.M31 = center.X - x * center.X;
			result.M32 = center.Y - y * center.Y;
			return result;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00012360 File Offset: 0x00010560
		public static void Scaling(float x, float y, ref Vector2 center, out Matrix3x2 result)
		{
			Matrix3x2 matrix3x;
			matrix3x.M11 = x;
			matrix3x.M12 = 0f;
			matrix3x.M21 = 0f;
			matrix3x.M22 = y;
			matrix3x.M31 = center.X - x * center.X;
			matrix3x.M32 = center.Y - y * center.Y;
			result = matrix3x;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x000123C8 File Offset: 0x000105C8
		public float Determinant()
		{
			return this.M11 * this.M22 - this.M12 * this.M21;
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x000123E8 File Offset: 0x000105E8
		public static void Rotation(float angle, out Matrix3x2 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix3x2.Identity;
			result.M11 = num;
			result.M12 = num2;
			result.M21 = -num2;
			result.M22 = num;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00012430 File Offset: 0x00010630
		public static Matrix3x2 Rotation(float angle)
		{
			Matrix3x2 result;
			Matrix3x2.Rotation(angle, out result);
			return result;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00012448 File Offset: 0x00010648
		public static Matrix3x2 Rotation(float angle, Vector2 center)
		{
			Matrix3x2 result;
			Matrix3x2.Rotation(angle, center, out result);
			return result;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0001245F File Offset: 0x0001065F
		public static void Rotation(float angle, Vector2 center, out Matrix3x2 result)
		{
			result = Matrix3x2.Translation(-center) * Matrix3x2.Rotation(angle) * Matrix3x2.Translation(center);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00012488 File Offset: 0x00010688
		public static void Transformation(float xScale, float yScale, float angle, float xOffset, float yOffset, out Matrix3x2 result)
		{
			result = Matrix3x2.Scaling(xScale, yScale) * Matrix3x2.Rotation(angle) * Matrix3x2.Translation(xOffset, yOffset);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x000124B0 File Offset: 0x000106B0
		public static Matrix3x2 Transformation(float xScale, float yScale, float angle, float xOffset, float yOffset)
		{
			Matrix3x2 result;
			Matrix3x2.Transformation(xScale, yScale, angle, xOffset, yOffset, out result);
			return result;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000124CB File Offset: 0x000106CB
		public static void Translation(ref Vector2 value, out Matrix3x2 result)
		{
			Matrix3x2.Translation(value.X, value.Y, out result);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x000124E0 File Offset: 0x000106E0
		public static Matrix3x2 Translation(Vector2 value)
		{
			Matrix3x2 result;
			Matrix3x2.Translation(ref value, out result);
			return result;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x000124F7 File Offset: 0x000106F7
		public static void Translation(float x, float y, out Matrix3x2 result)
		{
			result = Matrix3x2.Identity;
			result.M31 = x;
			result.M32 = y;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00012514 File Offset: 0x00010714
		public static Matrix3x2 Translation(float x, float y)
		{
			Matrix3x2 result;
			Matrix3x2.Translation(x, y, out result);
			return result;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0001252C File Offset: 0x0001072C
		public static Vector2 TransformPoint(Matrix3x2 matrix, Vector2 point)
		{
			Vector2 result;
			result.X = point.X * matrix.M11 + point.Y * matrix.M21 + matrix.M31;
			result.Y = point.X * matrix.M12 + point.Y * matrix.M22 + matrix.M32;
			return result;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001258C File Offset: 0x0001078C
		public static void TransformPoint(ref Matrix3x2 matrix, ref Vector2 point, out Vector2 result)
		{
			Vector2 vector;
			vector.X = point.X * matrix.M11 + point.Y * matrix.M21 + matrix.M31;
			vector.Y = point.X * matrix.M12 + point.Y * matrix.M22 + matrix.M32;
			result = vector;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x000125F2 File Offset: 0x000107F2
		public void Invert()
		{
			Matrix3x2.Invert(ref this, out this);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x000125FC File Offset: 0x000107FC
		public static Matrix3x2 Invert(Matrix3x2 value)
		{
			Matrix3x2 result;
			Matrix3x2.Invert(ref value, out result);
			return result;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00012614 File Offset: 0x00010814
		public static Matrix3x2 Skew(float angleX, float angleY)
		{
			Matrix3x2 result;
			Matrix3x2.Skew(angleX, angleY, out result);
			return result;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0001262B File Offset: 0x0001082B
		public static void Skew(float angleX, float angleY, out Matrix3x2 result)
		{
			result = Matrix.Identity;
			result.M12 = (float)Math.Tan((double)angleX);
			result.M21 = (float)Math.Tan((double)angleY);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0001265C File Offset: 0x0001085C
		public static void Invert(ref Matrix3x2 value, out Matrix3x2 result)
		{
			float num = value.Determinant();
			if (MathUtil.IsZero(num))
			{
				result = Matrix3x2.Identity;
				return;
			}
			float num2 = 1f / num;
			float m = value.M31;
			float m2 = value.M32;
			result = new Matrix3x2(value.M22 * num2, -value.M12 * num2, -value.M21 * num2, value.M11 * num2, (value.M21 * m2 - m * value.M22) * num2, (m * value.M12 - value.M11 * m2) * num2);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x000126F0 File Offset: 0x000108F0
		public static Matrix3x2 operator +(Matrix3x2 left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00002505 File Offset: 0x00000705
		public static Matrix3x2 operator +(Matrix3x2 value)
		{
			return value;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0001270C File Offset: 0x0001090C
		public static Matrix3x2 operator -(Matrix3x2 left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00012728 File Offset: 0x00010928
		public static Matrix3x2 operator -(Matrix3x2 value)
		{
			Matrix3x2 result;
			Matrix3x2.Negate(ref value, out result);
			return result;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00012740 File Offset: 0x00010940
		public static Matrix3x2 operator *(float left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Multiply(ref right, left, out result);
			return result;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00012758 File Offset: 0x00010958
		public static Matrix3x2 operator *(Matrix3x2 left, float right)
		{
			Matrix3x2 result;
			Matrix3x2.Multiply(ref left, right, out result);
			return result;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00012770 File Offset: 0x00010970
		public static Matrix3x2 operator *(Matrix3x2 left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0001278C File Offset: 0x0001098C
		public static Matrix3x2 operator /(Matrix3x2 left, float right)
		{
			Matrix3x2 result;
			Matrix3x2.Divide(ref left, right, out result);
			return result;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x000127A4 File Offset: 0x000109A4
		public static Matrix3x2 operator /(Matrix3x2 left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Divide(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x000127BD File Offset: 0x000109BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Matrix3x2 left, Matrix3x2 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x000127C8 File Offset: 0x000109C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Matrix3x2 left, Matrix3x2 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000127D8 File Offset: 0x000109D8
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "[M11:{0} M12:{1}] [M21:{2} M22:{3}] [M31:{4} M32:{5}]", new object[]
			{
				this.M11,
				this.M12,
				this.M21,
				this.M22,
				this.M31,
				this.M32
			});
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00012850 File Offset: 0x00010A50
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(format, new object[]
			{
				CultureInfo.CurrentCulture,
				"[M11:{0} M12:{1}] [M21:{2} M22:{3}] [M31:{4} M32:{5}]",
				this.M11.ToString(format, CultureInfo.CurrentCulture),
				this.M12.ToString(format, CultureInfo.CurrentCulture),
				this.M21.ToString(format, CultureInfo.CurrentCulture),
				this.M22.ToString(format, CultureInfo.CurrentCulture),
				this.M31.ToString(format, CultureInfo.CurrentCulture),
				this.M32.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00012904 File Offset: 0x00010B04
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "[M11:{0} M12:{1}] [M21:{2} M22:{3}] [M31:{4} M32:{5}]", new object[]
			{
				this.M11.ToString(formatProvider),
				this.M12.ToString(formatProvider),
				this.M21.ToString(formatProvider),
				this.M22.ToString(formatProvider),
				this.M31.ToString(formatProvider),
				this.M32.ToString(formatProvider)
			});
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0001297C File Offset: 0x00010B7C
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(format, new object[]
			{
				formatProvider,
				"[M11:{0} M12:{1}] [M21:{2} M22:{3}] [M31:{4} M32:{5}]",
				this.M11.ToString(format, formatProvider),
				this.M12.ToString(format, formatProvider),
				this.M21.ToString(format, formatProvider),
				this.M22.ToString(format, formatProvider),
				this.M31.ToString(format, formatProvider),
				this.M32.ToString(format, formatProvider)
			});
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00012A0C File Offset: 0x00010C0C
		public override int GetHashCode()
		{
			return ((((this.M11.GetHashCode() * 397 ^ this.M12.GetHashCode()) * 397 ^ this.M21.GetHashCode()) * 397 ^ this.M22.GetHashCode()) * 397 ^ this.M31.GetHashCode()) * 397 ^ this.M32.GetHashCode();
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00012A80 File Offset: 0x00010C80
		public bool Equals(ref Matrix3x2 other)
		{
			return MathUtil.NearEqual(other.M11, this.M11) && MathUtil.NearEqual(other.M12, this.M12) && MathUtil.NearEqual(other.M21, this.M21) && MathUtil.NearEqual(other.M22, this.M22) && MathUtil.NearEqual(other.M31, this.M31) && MathUtil.NearEqual(other.M32, this.M32);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00012AFF File Offset: 0x00010CFF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Matrix3x2 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00012B0C File Offset: 0x00010D0C
		public override bool Equals(object value)
		{
			if (!(value is Matrix3x2))
			{
				return false;
			}
			Matrix3x2 matrix3x = (Matrix3x2)value;
			return this.Equals(ref matrix3x);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00012B34 File Offset: 0x00010D34
		public static implicit operator Matrix3x2(Matrix matrix)
		{
			return new Matrix3x2
			{
				M11 = matrix.M11,
				M12 = matrix.M12,
				M21 = matrix.M21,
				M22 = matrix.M22,
				M31 = matrix.M41,
				M32 = matrix.M42
			};
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00012B98 File Offset: 0x00010D98
		public unsafe static implicit operator RawMatrix3x2(Matrix3x2 value)
		{
			return *(RawMatrix3x2*)(&value);
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00012BA2 File Offset: 0x00010DA2
		public unsafe static implicit operator Matrix3x2(RawMatrix3x2 value)
		{
			return *(Matrix3x2*)(&value);
		}

		// Token: 0x04000120 RID: 288
		public static readonly Matrix3x2 Identity = new Matrix3x2(1f, 0f, 0f, 1f, 0f, 0f);

		// Token: 0x04000121 RID: 289
		public float M11;

		// Token: 0x04000122 RID: 290
		public float M12;

		// Token: 0x04000123 RID: 291
		public float M21;

		// Token: 0x04000124 RID: 292
		public float M22;

		// Token: 0x04000125 RID: 293
		public float M31;

		// Token: 0x04000126 RID: 294
		public float M32;
	}
}

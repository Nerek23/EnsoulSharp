using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200001B RID: 27
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Matrix3x3 : IEquatable<Matrix3x3>, IFormattable
	{
		// Token: 0x060003EE RID: 1006 RVA: 0x00012BD8 File Offset: 0x00010DD8
		public Matrix3x3(float value)
		{
			this.M33 = value;
			this.M32 = value;
			this.M31 = value;
			this.M23 = value;
			this.M22 = value;
			this.M21 = value;
			this.M13 = value;
			this.M12 = value;
			this.M11 = value;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00012C34 File Offset: 0x00010E34
		public Matrix3x3(float M11, float M12, float M13, float M21, float M22, float M23, float M31, float M32, float M33)
		{
			this.M11 = M11;
			this.M12 = M12;
			this.M13 = M13;
			this.M21 = M21;
			this.M22 = M22;
			this.M23 = M23;
			this.M31 = M31;
			this.M32 = M32;
			this.M33 = M33;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00012C88 File Offset: 0x00010E88
		public Matrix3x3(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 9)
			{
				throw new ArgumentOutOfRangeException("values", "There must be sixteen and only sixteen input values for Matrix3x3.");
			}
			this.M11 = values[0];
			this.M12 = values[1];
			this.M13 = values[2];
			this.M21 = values[3];
			this.M22 = values[4];
			this.M23 = values[5];
			this.M31 = values[6];
			this.M32 = values[7];
			this.M33 = values[8];
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00012D0B File Offset: 0x00010F0B
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x00012D24 File Offset: 0x00010F24
		public Vector3 Row1
		{
			get
			{
				return new Vector3(this.M11, this.M12, this.M13);
			}
			set
			{
				this.M11 = value.X;
				this.M12 = value.Y;
				this.M13 = value.Z;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00012D4A File Offset: 0x00010F4A
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x00012D63 File Offset: 0x00010F63
		public Vector3 Row2
		{
			get
			{
				return new Vector3(this.M21, this.M22, this.M23);
			}
			set
			{
				this.M21 = value.X;
				this.M22 = value.Y;
				this.M23 = value.Z;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x00012D89 File Offset: 0x00010F89
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x00012DA2 File Offset: 0x00010FA2
		public Vector3 Row3
		{
			get
			{
				return new Vector3(this.M31, this.M32, this.M33);
			}
			set
			{
				this.M31 = value.X;
				this.M32 = value.Y;
				this.M33 = value.Z;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00012DC8 File Offset: 0x00010FC8
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x00012DE1 File Offset: 0x00010FE1
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

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x00012E07 File Offset: 0x00011007
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x00012E20 File Offset: 0x00011020
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

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00012E46 File Offset: 0x00011046
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x00012E5F File Offset: 0x0001105F
		public Vector3 Column3
		{
			get
			{
				return new Vector3(this.M13, this.M23, this.M33);
			}
			set
			{
				this.M13 = value.X;
				this.M23 = value.Y;
				this.M33 = value.Z;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x00012E85 File Offset: 0x00011085
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x00012E9E File Offset: 0x0001109E
		public Vector3 ScaleVector
		{
			get
			{
				return new Vector3(this.M11, this.M22, this.M33);
			}
			set
			{
				this.M11 = value.X;
				this.M22 = value.Y;
				this.M33 = value.Z;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x00012EC4 File Offset: 0x000110C4
		public bool IsIdentity
		{
			get
			{
				return this.Equals(Matrix3x3.Identity);
			}
		}

		// Token: 0x17000053 RID: 83
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
					return this.M13;
				case 3:
					return this.M21;
				case 4:
					return this.M22;
				case 5:
					return this.M23;
				case 6:
					return this.M31;
				case 7:
					return this.M32;
				case 8:
					return this.M33;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Matrix3x3 run from 0 to 8, inclusive.");
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
					this.M13 = value;
					return;
				case 3:
					this.M21 = value;
					return;
				case 4:
					this.M22 = value;
					return;
				case 5:
					this.M23 = value;
					return;
				case 6:
					this.M31 = value;
					return;
				case 7:
					this.M32 = value;
					return;
				case 8:
					this.M33 = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Matrix3x3 run from 0 to 8, inclusive.");
				}
			}
		}

		// Token: 0x17000054 RID: 84
		public float this[int row, int column]
		{
			get
			{
				if (row < 0 || row > 2)
				{
					throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 2, inclusive.");
				}
				if (column < 0 || column > 2)
				{
					throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 2, inclusive.");
				}
				return this[row * 3 + column];
			}
			set
			{
				if (row < 0 || row > 2)
				{
					throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 2, inclusive.");
				}
				if (column < 0 || column > 2)
				{
					throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 2, inclusive.");
				}
				this[row * 3 + column] = value;
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00013068 File Offset: 0x00011268
		public float Determinant()
		{
			return this.M11 * this.M22 * this.M33 + this.M12 * this.M23 * this.M31 + this.M13 * this.M21 * this.M32 - this.M13 * this.M22 * this.M31 - this.M12 * this.M21 * this.M33 - this.M11 * this.M23 * this.M32;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x000130F2 File Offset: 0x000112F2
		public void Invert()
		{
			Matrix3x3.Invert(ref this, out this);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x000130FB File Offset: 0x000112FB
		public void Transpose()
		{
			Matrix3x3.Transpose(ref this, out this);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00013104 File Offset: 0x00011304
		public void Orthogonalize()
		{
			Matrix3x3.Orthogonalize(ref this, out this);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0001310D File Offset: 0x0001130D
		public void Orthonormalize()
		{
			Matrix3x3.Orthonormalize(ref this, out this);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00013118 File Offset: 0x00011318
		public void DecomposeQR(out Matrix3x3 Q, out Matrix3x3 R)
		{
			Matrix3x3 matrix3x = this;
			matrix3x.Transpose();
			Matrix3x3.Orthonormalize(ref matrix3x, out Q);
			Q.Transpose();
			R = default(Matrix3x3);
			R.M11 = Vector3.Dot(Q.Column1, this.Column1);
			R.M12 = Vector3.Dot(Q.Column1, this.Column2);
			R.M13 = Vector3.Dot(Q.Column1, this.Column3);
			R.M22 = Vector3.Dot(Q.Column2, this.Column2);
			R.M23 = Vector3.Dot(Q.Column2, this.Column3);
			R.M33 = Vector3.Dot(Q.Column3, this.Column3);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x000131D4 File Offset: 0x000113D4
		public void DecomposeLQ(out Matrix3x3 L, out Matrix3x3 Q)
		{
			Matrix3x3.Orthonormalize(ref this, out Q);
			L = default(Matrix3x3);
			L.M11 = Vector3.Dot(Q.Row1, this.Row1);
			L.M21 = Vector3.Dot(Q.Row1, this.Row2);
			L.M22 = Vector3.Dot(Q.Row2, this.Row2);
			L.M31 = Vector3.Dot(Q.Row1, this.Row3);
			L.M32 = Vector3.Dot(Q.Row2, this.Row3);
			L.M33 = Vector3.Dot(Q.Row3, this.Row3);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0001327C File Offset: 0x0001147C
		public bool Decompose(out Vector3 scale, out Quaternion rotation)
		{
			scale.X = (float)Math.Sqrt((double)(this.M11 * this.M11 + this.M12 * this.M12 + this.M13 * this.M13));
			scale.Y = (float)Math.Sqrt((double)(this.M21 * this.M21 + this.M22 * this.M22 + this.M23 * this.M23));
			scale.Z = (float)Math.Sqrt((double)(this.M31 * this.M31 + this.M32 * this.M32 + this.M33 * this.M33));
			if (MathUtil.IsZero(scale.X) || MathUtil.IsZero(scale.Y) || MathUtil.IsZero(scale.Z))
			{
				rotation = Quaternion.Identity;
				return false;
			}
			Matrix3x3 matrix3x = default(Matrix3x3);
			matrix3x.M11 = this.M11 / scale.X;
			matrix3x.M12 = this.M12 / scale.X;
			matrix3x.M13 = this.M13 / scale.X;
			matrix3x.M21 = this.M21 / scale.Y;
			matrix3x.M22 = this.M22 / scale.Y;
			matrix3x.M23 = this.M23 / scale.Y;
			matrix3x.M31 = this.M31 / scale.Z;
			matrix3x.M32 = this.M32 / scale.Z;
			matrix3x.M33 = this.M33 / scale.Z;
			Quaternion.RotationMatrix(ref matrix3x, out rotation);
			return true;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00013424 File Offset: 0x00011624
		public bool DecomposeUniformScale(out float scale, out Quaternion rotation)
		{
			scale = (float)Math.Sqrt((double)(this.M11 * this.M11 + this.M12 * this.M12 + this.M13 * this.M13));
			float num = 1f / scale;
			if (Math.Abs(scale) < 1E-06f)
			{
				rotation = Quaternion.Identity;
				return false;
			}
			Matrix3x3 matrix3x = default(Matrix3x3);
			matrix3x.M11 = this.M11 * num;
			matrix3x.M12 = this.M12 * num;
			matrix3x.M13 = this.M13 * num;
			matrix3x.M21 = this.M21 * num;
			matrix3x.M22 = this.M22 * num;
			matrix3x.M23 = this.M23 * num;
			matrix3x.M31 = this.M31 * num;
			matrix3x.M32 = this.M32 * num;
			matrix3x.M33 = this.M33 * num;
			Quaternion.RotationMatrix(ref matrix3x, out rotation);
			return true;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00013520 File Offset: 0x00011720
		public void ExchangeRows(int firstRow, int secondRow)
		{
			if (firstRow < 0)
			{
				throw new ArgumentOutOfRangeException("firstRow", "The parameter firstRow must be greater than or equal to zero.");
			}
			if (firstRow > 2)
			{
				throw new ArgumentOutOfRangeException("firstRow", "The parameter firstRow must be less than or equal to two.");
			}
			if (secondRow < 0)
			{
				throw new ArgumentOutOfRangeException("secondRow", "The parameter secondRow must be greater than or equal to zero.");
			}
			if (secondRow > 2)
			{
				throw new ArgumentOutOfRangeException("secondRow", "The parameter secondRow must be less than or equal to two.");
			}
			if (firstRow == secondRow)
			{
				return;
			}
			float value = this[secondRow, 0];
			float value2 = this[secondRow, 1];
			float value3 = this[secondRow, 2];
			this[secondRow, 0] = this[firstRow, 0];
			this[secondRow, 1] = this[firstRow, 1];
			this[secondRow, 2] = this[firstRow, 2];
			this[firstRow, 0] = value;
			this[firstRow, 1] = value2;
			this[firstRow, 2] = value3;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x000135E8 File Offset: 0x000117E8
		public void ExchangeColumns(int firstColumn, int secondColumn)
		{
			if (firstColumn < 0)
			{
				throw new ArgumentOutOfRangeException("firstColumn", "The parameter firstColumn must be greater than or equal to zero.");
			}
			if (firstColumn > 2)
			{
				throw new ArgumentOutOfRangeException("firstColumn", "The parameter firstColumn must be less than or equal to two.");
			}
			if (secondColumn < 0)
			{
				throw new ArgumentOutOfRangeException("secondColumn", "The parameter secondColumn must be greater than or equal to zero.");
			}
			if (secondColumn > 2)
			{
				throw new ArgumentOutOfRangeException("secondColumn", "The parameter secondColumn must be less than or equal to two.");
			}
			if (firstColumn == secondColumn)
			{
				return;
			}
			float value = this[0, secondColumn];
			float value2 = this[1, secondColumn];
			float value3 = this[2, secondColumn];
			this[0, secondColumn] = this[0, firstColumn];
			this[1, secondColumn] = this[1, firstColumn];
			this[2, secondColumn] = this[2, firstColumn];
			this[0, firstColumn] = value;
			this[1, firstColumn] = value2;
			this[2, firstColumn] = value3;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000136B0 File Offset: 0x000118B0
		public float[] ToArray()
		{
			return new float[]
			{
				this.M11,
				this.M12,
				this.M13,
				this.M21,
				this.M22,
				this.M23,
				this.M31,
				this.M32,
				this.M33
			};
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00013718 File Offset: 0x00011918
		public static void Add(ref Matrix3x3 left, ref Matrix3x3 right, out Matrix3x3 result)
		{
			result.M11 = left.M11 + right.M11;
			result.M12 = left.M12 + right.M12;
			result.M13 = left.M13 + right.M13;
			result.M21 = left.M21 + right.M21;
			result.M22 = left.M22 + right.M22;
			result.M23 = left.M23 + right.M23;
			result.M31 = left.M31 + right.M31;
			result.M32 = left.M32 + right.M32;
			result.M33 = left.M33 + right.M33;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000137D0 File Offset: 0x000119D0
		public static Matrix3x3 Add(Matrix3x3 left, Matrix3x3 right)
		{
			Matrix3x3 result;
			Matrix3x3.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x000137EC File Offset: 0x000119EC
		public static void Subtract(ref Matrix3x3 left, ref Matrix3x3 right, out Matrix3x3 result)
		{
			result.M11 = left.M11 - right.M11;
			result.M12 = left.M12 - right.M12;
			result.M13 = left.M13 - right.M13;
			result.M21 = left.M21 - right.M21;
			result.M22 = left.M22 - right.M22;
			result.M23 = left.M23 - right.M23;
			result.M31 = left.M31 - right.M31;
			result.M32 = left.M32 - right.M32;
			result.M33 = left.M33 - right.M33;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000138A4 File Offset: 0x00011AA4
		public static Matrix3x3 Subtract(Matrix3x3 left, Matrix3x3 right)
		{
			Matrix3x3 result;
			Matrix3x3.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x000138C0 File Offset: 0x00011AC0
		public static void Multiply(ref Matrix3x3 left, float right, out Matrix3x3 result)
		{
			result.M11 = left.M11 * right;
			result.M12 = left.M12 * right;
			result.M13 = left.M13 * right;
			result.M21 = left.M21 * right;
			result.M22 = left.M22 * right;
			result.M23 = left.M23 * right;
			result.M31 = left.M31 * right;
			result.M32 = left.M32 * right;
			result.M33 = left.M33 * right;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0001394C File Offset: 0x00011B4C
		public static Matrix3x3 Multiply(Matrix3x3 left, float right)
		{
			Matrix3x3 result;
			Matrix3x3.Multiply(ref left, right, out result);
			return result;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00013964 File Offset: 0x00011B64
		public static void Multiply(ref Matrix3x3 left, ref Matrix3x3 right, out Matrix3x3 result)
		{
			result = new Matrix3x3
			{
				M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31,
				M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32,
				M13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33,
				M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31,
				M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32,
				M23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33,
				M31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31,
				M32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32,
				M33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33
			};
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00013B30 File Offset: 0x00011D30
		public static Matrix3x3 Multiply(Matrix3x3 left, Matrix3x3 right)
		{
			Matrix3x3 result;
			Matrix3x3.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00013B4C File Offset: 0x00011D4C
		public static void Divide(ref Matrix3x3 left, float right, out Matrix3x3 result)
		{
			float num = 1f / right;
			result.M11 = left.M11 * num;
			result.M12 = left.M12 * num;
			result.M13 = left.M13 * num;
			result.M21 = left.M21 * num;
			result.M22 = left.M22 * num;
			result.M23 = left.M23 * num;
			result.M31 = left.M31 * num;
			result.M32 = left.M32 * num;
			result.M33 = left.M33 * num;
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00013BE0 File Offset: 0x00011DE0
		public static Matrix3x3 Divide(Matrix3x3 left, float right)
		{
			Matrix3x3 result;
			Matrix3x3.Divide(ref left, right, out result);
			return result;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00013BF8 File Offset: 0x00011DF8
		public static void Divide(ref Matrix3x3 left, ref Matrix3x3 right, out Matrix3x3 result)
		{
			result.M11 = left.M11 / right.M11;
			result.M12 = left.M12 / right.M12;
			result.M13 = left.M13 / right.M13;
			result.M21 = left.M21 / right.M21;
			result.M22 = left.M22 / right.M22;
			result.M23 = left.M23 / right.M23;
			result.M31 = left.M31 / right.M31;
			result.M32 = left.M32 / right.M32;
			result.M33 = left.M33 / right.M33;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00013CB0 File Offset: 0x00011EB0
		public static Matrix3x3 Divide(Matrix3x3 left, Matrix3x3 right)
		{
			Matrix3x3 result;
			Matrix3x3.Divide(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00013CCC File Offset: 0x00011ECC
		public static void Exponent(ref Matrix3x3 value, int exponent, out Matrix3x3 result)
		{
			if (exponent < 0)
			{
				throw new ArgumentOutOfRangeException("exponent", "The exponent can not be negative.");
			}
			if (exponent == 0)
			{
				result = Matrix3x3.Identity;
				return;
			}
			if (exponent == 1)
			{
				result = value;
				return;
			}
			Matrix3x3 matrix3x = Matrix3x3.Identity;
			Matrix3x3 matrix3x2 = value;
			for (;;)
			{
				if ((exponent & 1) != 0)
				{
					matrix3x *= matrix3x2;
				}
				exponent /= 2;
				if (exponent <= 0)
				{
					break;
				}
				matrix3x2 *= matrix3x2;
			}
			result = matrix3x;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00013D44 File Offset: 0x00011F44
		public static Matrix3x3 Exponent(Matrix3x3 value, int exponent)
		{
			Matrix3x3 result;
			Matrix3x3.Exponent(ref value, exponent, out result);
			return result;
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00013D5C File Offset: 0x00011F5C
		public static void Negate(ref Matrix3x3 value, out Matrix3x3 result)
		{
			result.M11 = -value.M11;
			result.M12 = -value.M12;
			result.M13 = -value.M13;
			result.M21 = -value.M21;
			result.M22 = -value.M22;
			result.M23 = -value.M23;
			result.M31 = -value.M31;
			result.M32 = -value.M32;
			result.M33 = -value.M33;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00013DE0 File Offset: 0x00011FE0
		public static Matrix3x3 Negate(Matrix3x3 value)
		{
			Matrix3x3 result;
			Matrix3x3.Negate(ref value, out result);
			return result;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00013DF8 File Offset: 0x00011FF8
		public static void Lerp(ref Matrix3x3 start, ref Matrix3x3 end, float amount, out Matrix3x3 result)
		{
			result.M11 = MathUtil.Lerp(start.M11, end.M11, amount);
			result.M12 = MathUtil.Lerp(start.M12, end.M12, amount);
			result.M13 = MathUtil.Lerp(start.M13, end.M13, amount);
			result.M21 = MathUtil.Lerp(start.M21, end.M21, amount);
			result.M22 = MathUtil.Lerp(start.M22, end.M22, amount);
			result.M23 = MathUtil.Lerp(start.M23, end.M23, amount);
			result.M31 = MathUtil.Lerp(start.M31, end.M31, amount);
			result.M32 = MathUtil.Lerp(start.M32, end.M32, amount);
			result.M33 = MathUtil.Lerp(start.M33, end.M33, amount);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00013EE0 File Offset: 0x000120E0
		public static Matrix3x3 Lerp(Matrix3x3 start, Matrix3x3 end, float amount)
		{
			Matrix3x3 result;
			Matrix3x3.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00013EFA File Offset: 0x000120FA
		public static void SmoothStep(ref Matrix3x3 start, ref Matrix3x3 end, float amount, out Matrix3x3 result)
		{
			amount = MathUtil.SmoothStep(amount);
			Matrix3x3.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00013F10 File Offset: 0x00012110
		public static Matrix3x3 SmoothStep(Matrix3x3 start, Matrix3x3 end, float amount)
		{
			Matrix3x3 result;
			Matrix3x3.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00013F2C File Offset: 0x0001212C
		public static void Transpose(ref Matrix3x3 value, out Matrix3x3 result)
		{
			result = new Matrix3x3
			{
				M11 = value.M11,
				M12 = value.M21,
				M13 = value.M31,
				M21 = value.M12,
				M22 = value.M22,
				M23 = value.M32,
				M31 = value.M13,
				M32 = value.M23,
				M33 = value.M33
			};
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00013FC0 File Offset: 0x000121C0
		public static void TransposeByRef(ref Matrix3x3 value, ref Matrix3x3 result)
		{
			result.M11 = value.M11;
			result.M12 = value.M21;
			result.M13 = value.M31;
			result.M21 = value.M12;
			result.M22 = value.M22;
			result.M23 = value.M32;
			result.M31 = value.M13;
			result.M32 = value.M23;
			result.M33 = value.M33;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0001403C File Offset: 0x0001223C
		public static Matrix3x3 Transpose(Matrix3x3 value)
		{
			Matrix3x3 result;
			Matrix3x3.Transpose(ref value, out result);
			return result;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00014054 File Offset: 0x00012254
		public static void Invert(ref Matrix3x3 value, out Matrix3x3 result)
		{
			float num = value.M22 * value.M33 + value.M23 * -value.M32;
			float num2 = value.M21 * value.M33 + value.M23 * -value.M31;
			float num3 = value.M21 * value.M32 + value.M22 * -value.M31;
			float num4 = value.M11 * num - value.M12 * num2 + value.M13 * num3;
			if (Math.Abs(num4) == 0f)
			{
				result = Matrix3x3.Zero;
				return;
			}
			num4 = 1f / num4;
			float num5 = value.M12 * value.M33 + value.M13 * -value.M32;
			float num6 = value.M11 * value.M33 + value.M13 * -value.M31;
			float num7 = value.M11 * value.M32 + value.M12 * -value.M31;
			float num8 = value.M12 * value.M23 - value.M13 * value.M22;
			float num9 = value.M11 * value.M23 - value.M13 * value.M21;
			float num10 = value.M11 * value.M22 - value.M12 * value.M21;
			result.M11 = num * num4;
			result.M12 = -num5 * num4;
			result.M13 = num8 * num4;
			result.M21 = -num2 * num4;
			result.M22 = num6 * num4;
			result.M23 = -num9 * num4;
			result.M31 = num3 * num4;
			result.M32 = -num7 * num4;
			result.M33 = num10 * num4;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00014200 File Offset: 0x00012400
		public static Matrix3x3 Invert(Matrix3x3 value)
		{
			value.Invert();
			return value;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0001420C File Offset: 0x0001240C
		public static void Orthogonalize(ref Matrix3x3 value, out Matrix3x3 result)
		{
			result = value;
			result.Row2 -= Vector3.Dot(result.Row1, result.Row2) / Vector3.Dot(result.Row1, result.Row1) * result.Row1;
			result.Row3 -= Vector3.Dot(result.Row1, result.Row3) / Vector3.Dot(result.Row1, result.Row1) * result.Row1;
			result.Row3 -= Vector3.Dot(result.Row2, result.Row3) / Vector3.Dot(result.Row2, result.Row2) * result.Row2;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x000142E4 File Offset: 0x000124E4
		public static Matrix3x3 Orthogonalize(Matrix3x3 value)
		{
			Matrix3x3 result;
			Matrix3x3.Orthogonalize(ref value, out result);
			return result;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x000142FC File Offset: 0x000124FC
		public static void Orthonormalize(ref Matrix3x3 value, out Matrix3x3 result)
		{
			result = value;
			result.Row1 = Vector3.Normalize(result.Row1);
			result.Row2 -= Vector3.Dot(result.Row1, result.Row2) * result.Row1;
			result.Row2 = Vector3.Normalize(result.Row2);
			result.Row3 -= Vector3.Dot(result.Row1, result.Row3) * result.Row1;
			result.Row3 -= Vector3.Dot(result.Row2, result.Row3) * result.Row2;
			result.Row3 = Vector3.Normalize(result.Row3);
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x000143D0 File Offset: 0x000125D0
		public static Matrix3x3 Orthonormalize(Matrix3x3 value)
		{
			Matrix3x3 result;
			Matrix3x3.Orthonormalize(ref value, out result);
			return result;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x000143E8 File Offset: 0x000125E8
		public static void UpperTriangularForm(ref Matrix3x3 value, out Matrix3x3 result)
		{
			result = value;
			int num = 0;
			int num2 = 3;
			int num3 = 3;
			for (int i = 0; i < num2; i++)
			{
				if (num3 <= num)
				{
					return;
				}
				int j = i;
				while (MathUtil.IsZero(result[j, num]))
				{
					j++;
					if (j == num2)
					{
						j = i;
						num++;
						if (num == num3)
						{
							return;
						}
					}
				}
				if (j != i)
				{
					result.ExchangeRows(j, i);
				}
				float num4 = 1f / result[i, num];
				while (j < num2)
				{
					if (j != i)
					{
						ref Matrix3x3 ptr = ref result;
						int row = j;
						ptr[row, 0] = ptr[row, 0] - result[i, 0] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 1] = ptr[row, 1] - result[i, 1] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 2] = ptr[row, 2] - result[i, 2] * num4 * result[j, num];
					}
					j++;
				}
				num++;
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0001451C File Offset: 0x0001271C
		public static Matrix3x3 UpperTriangularForm(Matrix3x3 value)
		{
			Matrix3x3 result;
			Matrix3x3.UpperTriangularForm(ref value, out result);
			return result;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00014534 File Offset: 0x00012734
		public static void LowerTriangularForm(ref Matrix3x3 value, out Matrix3x3 result)
		{
			Matrix3x3 matrix3x = value;
			Matrix3x3.Transpose(ref matrix3x, out result);
			int num = 0;
			int num2 = 3;
			int num3 = 3;
			for (int i = 0; i < num2; i++)
			{
				if (num3 <= num)
				{
					return;
				}
				int j = i;
				while (MathUtil.IsZero(result[j, num]))
				{
					j++;
					if (j == num2)
					{
						j = i;
						num++;
						if (num == num3)
						{
							return;
						}
					}
				}
				if (j != i)
				{
					result.ExchangeRows(j, i);
				}
				float num4 = 1f / result[i, num];
				while (j < num2)
				{
					if (j != i)
					{
						ref Matrix3x3 ptr = ref result;
						int row = j;
						ptr[row, 0] = ptr[row, 0] - result[i, 0] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 1] = ptr[row, 1] - result[i, 1] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 2] = ptr[row, 2] - result[i, 2] * num4 * result[j, num];
					}
					j++;
				}
				num++;
			}
			Matrix3x3.Transpose(ref result, out result);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00014680 File Offset: 0x00012880
		public static Matrix3x3 LowerTriangularForm(Matrix3x3 value)
		{
			Matrix3x3 result;
			Matrix3x3.LowerTriangularForm(ref value, out result);
			return result;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00014698 File Offset: 0x00012898
		public static void RowEchelonForm(ref Matrix3x3 value, out Matrix3x3 result)
		{
			result = value;
			int num = 0;
			int num2 = 3;
			int num3 = 3;
			for (int i = 0; i < num2; i++)
			{
				if (num3 <= num)
				{
					return;
				}
				int j = i;
				while (MathUtil.IsZero(result[j, num]))
				{
					j++;
					if (j == num2)
					{
						j = i;
						num++;
						if (num == num3)
						{
							return;
						}
					}
				}
				if (j != i)
				{
					result.ExchangeRows(j, i);
				}
				float num4 = 1f / result[i, num];
				ref Matrix3x3 ptr = ref result;
				int row = i;
				ptr[row, 0] = ptr[row, 0] * num4;
				ptr = ref result;
				row = i;
				ptr[row, 1] = ptr[row, 1] * num4;
				ptr = ref result;
				row = i;
				ptr[row, 2] = ptr[row, 2] * num4;
				while (j < num2)
				{
					if (j != i)
					{
						ptr = ref result;
						row = j;
						ptr[row, 0] = ptr[row, 0] - result[i, 0] * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 1] = ptr[row, 1] - result[i, 1] * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 2] = ptr[row, 2] - result[i, 2] * result[j, num];
					}
					j++;
				}
				num++;
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00014818 File Offset: 0x00012A18
		public static Matrix3x3 RowEchelonForm(Matrix3x3 value)
		{
			Matrix3x3 result;
			Matrix3x3.RowEchelonForm(ref value, out result);
			return result;
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00014830 File Offset: 0x00012A30
		public static void BillboardLH(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, ref Vector3 cameraForwardVector, out Matrix3x3 result)
		{
			Vector3 vector = cameraPosition - objectPosition;
			float num = vector.LengthSquared();
			if (MathUtil.IsZero(num))
			{
				vector = -cameraForwardVector;
			}
			else
			{
				vector *= (float)(1.0 / Math.Sqrt((double)num));
			}
			Vector3 vector2;
			Vector3.Cross(ref cameraUpVector, ref vector, out vector2);
			vector2.Normalize();
			Vector3 vector3;
			Vector3.Cross(ref vector, ref vector2, out vector3);
			result.M11 = vector2.X;
			result.M12 = vector2.Y;
			result.M13 = vector2.Z;
			result.M21 = vector3.X;
			result.M22 = vector3.Y;
			result.M23 = vector3.Z;
			result.M31 = vector.X;
			result.M32 = vector.Y;
			result.M33 = vector.Z;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00014918 File Offset: 0x00012B18
		public static Matrix3x3 BillboardLH(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector)
		{
			Matrix3x3 result;
			Matrix3x3.BillboardLH(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
			return result;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00014938 File Offset: 0x00012B38
		public static void BillboardRH(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, ref Vector3 cameraForwardVector, out Matrix3x3 result)
		{
			Vector3 vector = objectPosition - cameraPosition;
			float num = vector.LengthSquared();
			if (MathUtil.IsZero(num))
			{
				vector = -cameraForwardVector;
			}
			else
			{
				vector *= (float)(1.0 / Math.Sqrt((double)num));
			}
			Vector3 vector2;
			Vector3.Cross(ref cameraUpVector, ref vector, out vector2);
			vector2.Normalize();
			Vector3 vector3;
			Vector3.Cross(ref vector, ref vector2, out vector3);
			result.M11 = vector2.X;
			result.M12 = vector2.Y;
			result.M13 = vector2.Z;
			result.M21 = vector3.X;
			result.M22 = vector3.Y;
			result.M23 = vector3.Z;
			result.M31 = vector.X;
			result.M32 = vector.Y;
			result.M33 = vector.Z;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00014A20 File Offset: 0x00012C20
		public static Matrix3x3 BillboardRH(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector)
		{
			Matrix3x3 result;
			Matrix3x3.BillboardRH(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
			return result;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00014A40 File Offset: 0x00012C40
		public static void LookAtLH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Matrix3x3 result)
		{
			Vector3 vector;
			Vector3.Subtract(ref target, ref eye, out vector);
			vector.Normalize();
			Vector3 vector2;
			Vector3.Cross(ref up, ref vector, out vector2);
			vector2.Normalize();
			Vector3 vector3;
			Vector3.Cross(ref vector, ref vector2, out vector3);
			result = Matrix3x3.Identity;
			result.M11 = vector2.X;
			result.M21 = vector2.Y;
			result.M31 = vector2.Z;
			result.M12 = vector3.X;
			result.M22 = vector3.Y;
			result.M32 = vector3.Z;
			result.M13 = vector.X;
			result.M23 = vector.Y;
			result.M33 = vector.Z;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00014AF0 File Offset: 0x00012CF0
		public static Matrix3x3 LookAtLH(Vector3 eye, Vector3 target, Vector3 up)
		{
			Matrix3x3 result;
			Matrix3x3.LookAtLH(ref eye, ref target, ref up, out result);
			return result;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00014B0C File Offset: 0x00012D0C
		public static void LookAtRH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Matrix3x3 result)
		{
			Vector3 vector;
			Vector3.Subtract(ref eye, ref target, out vector);
			vector.Normalize();
			Vector3 vector2;
			Vector3.Cross(ref up, ref vector, out vector2);
			vector2.Normalize();
			Vector3 vector3;
			Vector3.Cross(ref vector, ref vector2, out vector3);
			result = Matrix3x3.Identity;
			result.M11 = vector2.X;
			result.M21 = vector2.Y;
			result.M31 = vector2.Z;
			result.M12 = vector3.X;
			result.M22 = vector3.Y;
			result.M32 = vector3.Z;
			result.M13 = vector.X;
			result.M23 = vector.Y;
			result.M33 = vector.Z;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00014BBC File Offset: 0x00012DBC
		public static Matrix3x3 LookAtRH(Vector3 eye, Vector3 target, Vector3 up)
		{
			Matrix3x3 result;
			Matrix3x3.LookAtRH(ref eye, ref target, ref up, out result);
			return result;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00014BD7 File Offset: 0x00012DD7
		public static void Scaling(ref Vector3 scale, out Matrix3x3 result)
		{
			Matrix3x3.Scaling(scale.X, scale.Y, scale.Z, out result);
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00014BF4 File Offset: 0x00012DF4
		public static Matrix3x3 Scaling(Vector3 scale)
		{
			Matrix3x3 result;
			Matrix3x3.Scaling(ref scale, out result);
			return result;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00014C0B File Offset: 0x00012E0B
		public static void Scaling(float x, float y, float z, out Matrix3x3 result)
		{
			result = Matrix3x3.Identity;
			result.M11 = x;
			result.M22 = y;
			result.M33 = z;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00014C30 File Offset: 0x00012E30
		public static Matrix3x3 Scaling(float x, float y, float z)
		{
			Matrix3x3 result;
			Matrix3x3.Scaling(x, y, z, out result);
			return result;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00014C48 File Offset: 0x00012E48
		public static void Scaling(float scale, out Matrix3x3 result)
		{
			result = Matrix3x3.Identity;
			result.M33 = scale;
			result.M22 = scale;
			result.M11 = scale;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00014C7C File Offset: 0x00012E7C
		public static Matrix3x3 Scaling(float scale)
		{
			Matrix3x3 result;
			Matrix3x3.Scaling(scale, out result);
			return result;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00014C94 File Offset: 0x00012E94
		public static void RotationX(float angle, out Matrix3x3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix3x3.Identity;
			result.M22 = num;
			result.M23 = num2;
			result.M32 = -num2;
			result.M33 = num;
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00014CDC File Offset: 0x00012EDC
		public static Matrix3x3 RotationX(float angle)
		{
			Matrix3x3 result;
			Matrix3x3.RotationX(angle, out result);
			return result;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00014CF4 File Offset: 0x00012EF4
		public static void RotationY(float angle, out Matrix3x3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix3x3.Identity;
			result.M11 = num;
			result.M13 = -num2;
			result.M31 = num2;
			result.M33 = num;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00014D3C File Offset: 0x00012F3C
		public static Matrix3x3 RotationY(float angle)
		{
			Matrix3x3 result;
			Matrix3x3.RotationY(angle, out result);
			return result;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00014D54 File Offset: 0x00012F54
		public static void RotationZ(float angle, out Matrix3x3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix3x3.Identity;
			result.M11 = num;
			result.M12 = num2;
			result.M21 = -num2;
			result.M22 = num;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00014D9C File Offset: 0x00012F9C
		public static Matrix3x3 RotationZ(float angle)
		{
			Matrix3x3 result;
			Matrix3x3.RotationZ(angle, out result);
			return result;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00014DB4 File Offset: 0x00012FB4
		public static void RotationAxis(ref Vector3 axis, float angle, out Matrix3x3 result)
		{
			float x = axis.X;
			float y = axis.Y;
			float z = axis.Z;
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			float num3 = x * x;
			float num4 = y * y;
			float num5 = z * z;
			float num6 = x * y;
			float num7 = x * z;
			float num8 = y * z;
			result = Matrix3x3.Identity;
			result.M11 = num3 + num * (1f - num3);
			result.M12 = num6 - num * num6 + num2 * z;
			result.M13 = num7 - num * num7 - num2 * y;
			result.M21 = num6 - num * num6 - num2 * z;
			result.M22 = num4 + num * (1f - num4);
			result.M23 = num8 - num * num8 + num2 * x;
			result.M31 = num7 - num * num7 + num2 * y;
			result.M32 = num8 - num * num8 - num2 * x;
			result.M33 = num5 + num * (1f - num5);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00014EB8 File Offset: 0x000130B8
		public static Matrix3x3 RotationAxis(Vector3 axis, float angle)
		{
			Matrix3x3 result;
			Matrix3x3.RotationAxis(ref axis, angle, out result);
			return result;
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00014ED0 File Offset: 0x000130D0
		public static void RotationQuaternion(ref Quaternion rotation, out Matrix3x3 result)
		{
			float num = rotation.X * rotation.X;
			float num2 = rotation.Y * rotation.Y;
			float num3 = rotation.Z * rotation.Z;
			float num4 = rotation.X * rotation.Y;
			float num5 = rotation.Z * rotation.W;
			float num6 = rotation.Z * rotation.X;
			float num7 = rotation.Y * rotation.W;
			float num8 = rotation.Y * rotation.Z;
			float num9 = rotation.X * rotation.W;
			result = Matrix3x3.Identity;
			result.M11 = 1f - 2f * (num2 + num3);
			result.M12 = 2f * (num4 + num5);
			result.M13 = 2f * (num6 - num7);
			result.M21 = 2f * (num4 - num5);
			result.M22 = 1f - 2f * (num3 + num);
			result.M23 = 2f * (num8 + num9);
			result.M31 = 2f * (num6 + num7);
			result.M32 = 2f * (num8 - num9);
			result.M33 = 1f - 2f * (num2 + num);
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00015010 File Offset: 0x00013210
		public static Matrix3x3 RotationQuaternion(Quaternion rotation)
		{
			Matrix3x3 result;
			Matrix3x3.RotationQuaternion(ref rotation, out result);
			return result;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00015028 File Offset: 0x00013228
		public static void RotationYawPitchRoll(float yaw, float pitch, float roll, out Matrix3x3 result)
		{
			Quaternion quaternion = default(Quaternion);
			Quaternion.RotationYawPitchRoll(yaw, pitch, roll, out quaternion);
			Matrix3x3.RotationQuaternion(ref quaternion, out result);
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00015050 File Offset: 0x00013250
		public static Matrix3x3 RotationYawPitchRoll(float yaw, float pitch, float roll)
		{
			Matrix3x3 result;
			Matrix3x3.RotationYawPitchRoll(yaw, pitch, roll, out result);
			return result;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00015068 File Offset: 0x00013268
		public static Matrix3x3 operator +(Matrix3x3 left, Matrix3x3 right)
		{
			Matrix3x3 result;
			Matrix3x3.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00002505 File Offset: 0x00000705
		public static Matrix3x3 operator +(Matrix3x3 value)
		{
			return value;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00015084 File Offset: 0x00013284
		public static Matrix3x3 operator -(Matrix3x3 left, Matrix3x3 right)
		{
			Matrix3x3 result;
			Matrix3x3.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x000150A0 File Offset: 0x000132A0
		public static Matrix3x3 operator -(Matrix3x3 value)
		{
			Matrix3x3 result;
			Matrix3x3.Negate(ref value, out result);
			return result;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x000150B8 File Offset: 0x000132B8
		public static Matrix3x3 operator *(float left, Matrix3x3 right)
		{
			Matrix3x3 result;
			Matrix3x3.Multiply(ref right, left, out result);
			return result;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x000150D0 File Offset: 0x000132D0
		public static Matrix3x3 operator *(Matrix3x3 left, float right)
		{
			Matrix3x3 result;
			Matrix3x3.Multiply(ref left, right, out result);
			return result;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000150E8 File Offset: 0x000132E8
		public static Matrix3x3 operator *(Matrix3x3 left, Matrix3x3 right)
		{
			Matrix3x3 result;
			Matrix3x3.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00015104 File Offset: 0x00013304
		public static Matrix3x3 operator /(Matrix3x3 left, float right)
		{
			Matrix3x3 result;
			Matrix3x3.Divide(ref left, right, out result);
			return result;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0001511C File Offset: 0x0001331C
		public static Matrix3x3 operator /(Matrix3x3 left, Matrix3x3 right)
		{
			Matrix3x3 result;
			Matrix3x3.Divide(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00015135 File Offset: 0x00013335
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Matrix3x3 left, Matrix3x3 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00015140 File Offset: 0x00013340
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Matrix3x3 left, Matrix3x3 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00015150 File Offset: 0x00013350
		public static explicit operator Matrix(Matrix3x3 Value)
		{
			return new Matrix(Value.M11, Value.M12, Value.M13, 0f, Value.M21, Value.M22, Value.M23, 0f, Value.M31, Value.M32, Value.M33, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x000151BC File Offset: 0x000133BC
		public static explicit operator Matrix3x3(Matrix Value)
		{
			return new Matrix3x3(Value.M11, Value.M12, Value.M13, Value.M21, Value.M22, Value.M23, Value.M31, Value.M32, Value.M33);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00015204 File Offset: 0x00013404
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "[M11:{0} M12:{1} M13:{2}] [M21:{3} M22:{4} M23:{5}] [M31:{6} M32:{7} M33:{8}]", new object[]
			{
				this.M11,
				this.M12,
				this.M13,
				this.M21,
				this.M22,
				this.M23,
				this.M31,
				this.M32,
				this.M33
			});
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x000152A8 File Offset: 0x000134A8
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(format, new object[]
			{
				CultureInfo.CurrentCulture,
				"[M11:{0} M12:{1} M13:{2}] [M21:{3} M22:{4} M23:{5}] [M31:{6} M32:{7} M33:{8}]",
				this.M11.ToString(format, CultureInfo.CurrentCulture),
				this.M12.ToString(format, CultureInfo.CurrentCulture),
				this.M13.ToString(format, CultureInfo.CurrentCulture),
				this.M21.ToString(format, CultureInfo.CurrentCulture),
				this.M22.ToString(format, CultureInfo.CurrentCulture),
				this.M23.ToString(format, CultureInfo.CurrentCulture),
				this.M31.ToString(format, CultureInfo.CurrentCulture),
				this.M32.ToString(format, CultureInfo.CurrentCulture),
				this.M33.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00015398 File Offset: 0x00013598
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "[M11:{0} M12:{1} M13:{2}] [M21:{3} M22:{4} M23:{5}] [M31:{6} M32:{7} M33:{8}]", new object[]
			{
				this.M11.ToString(formatProvider),
				this.M12.ToString(formatProvider),
				this.M13.ToString(formatProvider),
				this.M21.ToString(formatProvider),
				this.M22.ToString(formatProvider),
				this.M23.ToString(formatProvider),
				this.M31.ToString(formatProvider),
				this.M32.ToString(formatProvider),
				this.M33.ToString(formatProvider)
			});
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00015440 File Offset: 0x00013640
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(format, new object[]
			{
				formatProvider,
				"[M11:{0} M12:{1} M13:{2}] [M21:{3} M22:{4} M23:{5}] [M31:{6} M32:{7} M33:{8}]",
				this.M11.ToString(format, formatProvider),
				this.M12.ToString(format, formatProvider),
				this.M13.ToString(format, formatProvider),
				this.M21.ToString(format, formatProvider),
				this.M22.ToString(format, formatProvider),
				this.M23.ToString(format, formatProvider),
				this.M31.ToString(format, formatProvider),
				this.M32.ToString(format, formatProvider),
				this.M33.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00015504 File Offset: 0x00013704
		public override int GetHashCode()
		{
			return (((((((this.M11.GetHashCode() * 397 ^ this.M12.GetHashCode()) * 397 ^ this.M13.GetHashCode()) * 397 ^ this.M21.GetHashCode()) * 397 ^ this.M22.GetHashCode()) * 397 ^ this.M23.GetHashCode()) * 397 ^ this.M31.GetHashCode()) * 397 ^ this.M32.GetHashCode()) * 397 ^ this.M33.GetHashCode();
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x000155AC File Offset: 0x000137AC
		public bool Equals(ref Matrix3x3 other)
		{
			return MathUtil.NearEqual(other.M11, this.M11) && MathUtil.NearEqual(other.M12, this.M12) && MathUtil.NearEqual(other.M13, this.M13) && MathUtil.NearEqual(other.M21, this.M21) && MathUtil.NearEqual(other.M22, this.M22) && MathUtil.NearEqual(other.M23, this.M23) && MathUtil.NearEqual(other.M31, this.M31) && MathUtil.NearEqual(other.M32, this.M32) && MathUtil.NearEqual(other.M33, this.M33);
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0001566A File Offset: 0x0001386A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Matrix3x3 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00015674 File Offset: 0x00013874
		public static bool Equals(ref Matrix3x3 a, ref Matrix3x3 b)
		{
			return MathUtil.NearEqual(a.M11, b.M11) && MathUtil.NearEqual(a.M12, b.M12) && MathUtil.NearEqual(a.M13, b.M13) && MathUtil.NearEqual(a.M21, b.M21) && MathUtil.NearEqual(a.M22, b.M22) && MathUtil.NearEqual(a.M23, b.M23) && MathUtil.NearEqual(a.M31, b.M31) && MathUtil.NearEqual(a.M32, b.M32) && MathUtil.NearEqual(a.M33, b.M33);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00015734 File Offset: 0x00013934
		public override bool Equals(object value)
		{
			if (!(value is Matrix3x3))
			{
				return false;
			}
			Matrix3x3 matrix3x = (Matrix3x3)value;
			return this.Equals(ref matrix3x);
		}

		// Token: 0x04000127 RID: 295
		public static readonly int SizeInBytes = Utilities.SizeOf<Matrix3x3>();

		// Token: 0x04000128 RID: 296
		public static readonly Matrix3x3 Zero = default(Matrix3x3);

		// Token: 0x04000129 RID: 297
		public static readonly Matrix3x3 Identity = new Matrix3x3
		{
			M11 = 1f,
			M22 = 1f,
			M33 = 1f
		};

		// Token: 0x0400012A RID: 298
		public float M11;

		// Token: 0x0400012B RID: 299
		public float M12;

		// Token: 0x0400012C RID: 300
		public float M13;

		// Token: 0x0400012D RID: 301
		public float M21;

		// Token: 0x0400012E RID: 302
		public float M22;

		// Token: 0x0400012F RID: 303
		public float M23;

		// Token: 0x04000130 RID: 304
		public float M31;

		// Token: 0x04000131 RID: 305
		public float M32;

		// Token: 0x04000132 RID: 306
		public float M33;
	}
}

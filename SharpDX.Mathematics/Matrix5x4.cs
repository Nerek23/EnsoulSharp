using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200001C RID: 28
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Matrix5x4 : IEquatable<Matrix5x4>, IFormattable
	{
		// Token: 0x06000464 RID: 1124 RVA: 0x000157B0 File Offset: 0x000139B0
		public Matrix5x4(float value)
		{
			this.M54 = value;
			this.M53 = value;
			this.M52 = value;
			this.M51 = value;
			this.M44 = value;
			this.M43 = value;
			this.M42 = value;
			this.M41 = value;
			this.M34 = value;
			this.M33 = value;
			this.M32 = value;
			this.M31 = value;
			this.M24 = value;
			this.M23 = value;
			this.M22 = value;
			this.M21 = value;
			this.M14 = value;
			this.M13 = value;
			this.M12 = value;
			this.M11 = value;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00015870 File Offset: 0x00013A70
		public Matrix5x4(float M11, float M12, float M13, float M14, float M21, float M22, float M23, float M24, float M31, float M32, float M33, float M34, float M41, float M42, float M43, float M44, float M51, float M52, float M53, float M54)
		{
			this.M11 = M11;
			this.M12 = M12;
			this.M13 = M13;
			this.M14 = M14;
			this.M21 = M21;
			this.M22 = M22;
			this.M23 = M23;
			this.M24 = M24;
			this.M31 = M31;
			this.M32 = M32;
			this.M33 = M33;
			this.M34 = M34;
			this.M41 = M41;
			this.M42 = M42;
			this.M43 = M43;
			this.M44 = M44;
			this.M51 = M51;
			this.M52 = M52;
			this.M53 = M53;
			this.M54 = M54;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0001591C File Offset: 0x00013B1C
		public Matrix5x4(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 20)
			{
				throw new ArgumentOutOfRangeException("values", "There must be 20 input values for Matrix5x4.");
			}
			this.M11 = values[0];
			this.M12 = values[1];
			this.M13 = values[2];
			this.M14 = values[3];
			this.M21 = values[4];
			this.M22 = values[5];
			this.M23 = values[6];
			this.M24 = values[7];
			this.M31 = values[8];
			this.M32 = values[9];
			this.M33 = values[10];
			this.M34 = values[11];
			this.M41 = values[12];
			this.M42 = values[13];
			this.M43 = values[14];
			this.M44 = values[15];
			this.M51 = values[16];
			this.M52 = values[17];
			this.M53 = values[18];
			this.M54 = values[19];
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x00015A0D File Offset: 0x00013C0D
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x00015A2C File Offset: 0x00013C2C
		public Vector4 Row1
		{
			get
			{
				return new Vector4(this.M11, this.M12, this.M13, this.M14);
			}
			set
			{
				this.M11 = value.X;
				this.M12 = value.Y;
				this.M13 = value.Z;
				this.M14 = value.W;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00015A5E File Offset: 0x00013C5E
		// (set) Token: 0x0600046A RID: 1130 RVA: 0x00015A7D File Offset: 0x00013C7D
		public Vector4 Row2
		{
			get
			{
				return new Vector4(this.M21, this.M22, this.M23, this.M24);
			}
			set
			{
				this.M21 = value.X;
				this.M22 = value.Y;
				this.M23 = value.Z;
				this.M24 = value.W;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00015AAF File Offset: 0x00013CAF
		// (set) Token: 0x0600046C RID: 1132 RVA: 0x00015ACE File Offset: 0x00013CCE
		public Vector4 Row3
		{
			get
			{
				return new Vector4(this.M31, this.M32, this.M33, this.M34);
			}
			set
			{
				this.M31 = value.X;
				this.M32 = value.Y;
				this.M33 = value.Z;
				this.M34 = value.W;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x00015B00 File Offset: 0x00013D00
		// (set) Token: 0x0600046E RID: 1134 RVA: 0x00015B1F File Offset: 0x00013D1F
		public Vector4 Row4
		{
			get
			{
				return new Vector4(this.M41, this.M42, this.M43, this.M44);
			}
			set
			{
				this.M41 = value.X;
				this.M42 = value.Y;
				this.M43 = value.Z;
				this.M44 = value.W;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x00015B51 File Offset: 0x00013D51
		// (set) Token: 0x06000470 RID: 1136 RVA: 0x00015B70 File Offset: 0x00013D70
		public Vector4 Row5
		{
			get
			{
				return new Vector4(this.M51, this.M52, this.M53, this.M54);
			}
			set
			{
				this.M51 = value.X;
				this.M52 = value.Y;
				this.M53 = value.Z;
				this.M54 = value.W;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x00015B51 File Offset: 0x00013D51
		// (set) Token: 0x06000472 RID: 1138 RVA: 0x00015B70 File Offset: 0x00013D70
		public Vector4 TranslationVector
		{
			get
			{
				return new Vector4(this.M51, this.M52, this.M53, this.M54);
			}
			set
			{
				this.M51 = value.X;
				this.M52 = value.Y;
				this.M53 = value.Z;
				this.M54 = value.W;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00015BA2 File Offset: 0x00013DA2
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x00015BC1 File Offset: 0x00013DC1
		public Vector4 ScaleVector
		{
			get
			{
				return new Vector4(this.M11, this.M22, this.M33, this.M44);
			}
			set
			{
				this.M11 = value.X;
				this.M22 = value.Y;
				this.M33 = value.Z;
				this.M44 = value.W;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x00015BF3 File Offset: 0x00013DF3
		public bool IsIdentity
		{
			get
			{
				return this.Equals(Matrix5x4.Identity);
			}
		}

		// Token: 0x1700005D RID: 93
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
					return this.M14;
				case 4:
					return this.M21;
				case 5:
					return this.M22;
				case 6:
					return this.M23;
				case 7:
					return this.M24;
				case 8:
					return this.M31;
				case 9:
					return this.M32;
				case 10:
					return this.M33;
				case 11:
					return this.M34;
				case 12:
					return this.M41;
				case 13:
					return this.M42;
				case 14:
					return this.M43;
				case 15:
					return this.M44;
				case 16:
					return this.M51;
				case 17:
					return this.M52;
				case 18:
					return this.M53;
				case 19:
					return this.M54;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Matrix5x4 run from 0 to 19, inclusive.");
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
					this.M14 = value;
					return;
				case 4:
					this.M21 = value;
					return;
				case 5:
					this.M22 = value;
					return;
				case 6:
					this.M23 = value;
					return;
				case 7:
					this.M24 = value;
					return;
				case 8:
					this.M31 = value;
					return;
				case 9:
					this.M32 = value;
					return;
				case 10:
					this.M33 = value;
					return;
				case 11:
					this.M34 = value;
					return;
				case 12:
					this.M41 = value;
					return;
				case 13:
					this.M42 = value;
					return;
				case 14:
					this.M43 = value;
					return;
				case 15:
					this.M44 = value;
					return;
				case 16:
					this.M51 = value;
					return;
				case 17:
					this.M52 = value;
					return;
				case 18:
					this.M53 = value;
					return;
				case 19:
					this.M54 = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Matrix5x4 run from 0 to 19, inclusive.");
				}
			}
		}

		// Token: 0x1700005E RID: 94
		public float this[int row, int column]
		{
			get
			{
				if (row < 0 || row > 4)
				{
					throw new ArgumentOutOfRangeException("row", "Rows for matrices run from 0 to 4, inclusive.");
				}
				if (column < 0 || column > 3)
				{
					throw new ArgumentOutOfRangeException("column", "Columns for matrices run from 0 to 3, inclusive.");
				}
				return this[row * 4 + column];
			}
			set
			{
				if (row < 0 || row > 4)
				{
					throw new ArgumentOutOfRangeException("row", "Rows for matrices run from 0 to 4, inclusive.");
				}
				if (column < 0 || column > 3)
				{
					throw new ArgumentOutOfRangeException("column", "Columns for matrices run from 0 to 3, inclusive.");
				}
				this[row * 4 + column] = value;
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00015E98 File Offset: 0x00014098
		public static void Add(ref Matrix5x4 left, ref Matrix5x4 right, out Matrix5x4 result)
		{
			result.M11 = left.M11 + right.M11;
			result.M12 = left.M12 + right.M12;
			result.M13 = left.M13 + right.M13;
			result.M14 = left.M14 + right.M14;
			result.M21 = left.M21 + right.M21;
			result.M22 = left.M22 + right.M22;
			result.M23 = left.M23 + right.M23;
			result.M24 = left.M24 + right.M24;
			result.M31 = left.M31 + right.M31;
			result.M32 = left.M32 + right.M32;
			result.M33 = left.M33 + right.M33;
			result.M34 = left.M34 + right.M34;
			result.M41 = left.M41 + right.M41;
			result.M42 = left.M42 + right.M42;
			result.M43 = left.M43 + right.M43;
			result.M44 = left.M44 + right.M44;
			result.M51 = left.M51 + right.M51;
			result.M52 = left.M52 + right.M52;
			result.M53 = left.M53 + right.M53;
			result.M54 = left.M54 + right.M54;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00016024 File Offset: 0x00014224
		public static Matrix5x4 Add(Matrix5x4 left, Matrix5x4 right)
		{
			Matrix5x4 result;
			Matrix5x4.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00016040 File Offset: 0x00014240
		public static void Subtract(ref Matrix5x4 left, ref Matrix5x4 right, out Matrix5x4 result)
		{
			result.M11 = left.M11 - right.M11;
			result.M12 = left.M12 - right.M12;
			result.M13 = left.M13 - right.M13;
			result.M14 = left.M14 - right.M14;
			result.M21 = left.M21 - right.M21;
			result.M22 = left.M22 - right.M22;
			result.M23 = left.M23 - right.M23;
			result.M24 = left.M24 - right.M24;
			result.M31 = left.M31 - right.M31;
			result.M32 = left.M32 - right.M32;
			result.M33 = left.M33 - right.M33;
			result.M34 = left.M34 - right.M34;
			result.M41 = left.M41 - right.M41;
			result.M42 = left.M42 - right.M42;
			result.M43 = left.M43 - right.M43;
			result.M44 = left.M44 - right.M44;
			result.M51 = left.M51 - right.M51;
			result.M52 = left.M52 - right.M52;
			result.M53 = left.M53 - right.M53;
			result.M54 = left.M54 - right.M54;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x000161CC File Offset: 0x000143CC
		public static Matrix5x4 Subtract(Matrix5x4 left, Matrix5x4 right)
		{
			Matrix5x4 result;
			Matrix5x4.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x000161E8 File Offset: 0x000143E8
		public static void Multiply(ref Matrix5x4 left, float right, out Matrix5x4 result)
		{
			result.M11 = left.M11 * right;
			result.M12 = left.M12 * right;
			result.M13 = left.M13 * right;
			result.M14 = left.M14 * right;
			result.M21 = left.M21 * right;
			result.M22 = left.M22 * right;
			result.M23 = left.M23 * right;
			result.M24 = left.M24 * right;
			result.M31 = left.M31 * right;
			result.M32 = left.M32 * right;
			result.M33 = left.M33 * right;
			result.M34 = left.M34 * right;
			result.M41 = left.M41 * right;
			result.M42 = left.M42 * right;
			result.M43 = left.M43 * right;
			result.M44 = left.M44 * right;
			result.M51 = left.M51 * right;
			result.M52 = left.M52 * right;
			result.M53 = left.M53 * right;
			result.M54 = left.M54 * right;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00016310 File Offset: 0x00014510
		public static void Divide(ref Matrix5x4 left, float right, out Matrix5x4 result)
		{
			float num = 1f / right;
			result.M11 = left.M11 * num;
			result.M12 = left.M12 * num;
			result.M13 = left.M13 * num;
			result.M14 = left.M14 * num;
			result.M21 = left.M21 * num;
			result.M22 = left.M22 * num;
			result.M23 = left.M23 * num;
			result.M24 = left.M24 * num;
			result.M31 = left.M31 * num;
			result.M32 = left.M32 * num;
			result.M33 = left.M33 * num;
			result.M34 = left.M34 * num;
			result.M41 = left.M41 * num;
			result.M42 = left.M42 * num;
			result.M43 = left.M43 * num;
			result.M44 = left.M44 * num;
			result.M51 = left.M51 * num;
			result.M52 = left.M52 * num;
			result.M53 = left.M53 * num;
			result.M54 = left.M54 * num;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00016440 File Offset: 0x00014640
		public static void Negate(ref Matrix5x4 value, out Matrix5x4 result)
		{
			result.M11 = -value.M11;
			result.M12 = -value.M12;
			result.M13 = -value.M13;
			result.M14 = -value.M14;
			result.M21 = -value.M21;
			result.M22 = -value.M22;
			result.M23 = -value.M23;
			result.M24 = -value.M24;
			result.M31 = -value.M31;
			result.M32 = -value.M32;
			result.M33 = -value.M33;
			result.M34 = -value.M34;
			result.M41 = -value.M41;
			result.M42 = -value.M42;
			result.M43 = -value.M43;
			result.M44 = -value.M44;
			result.M51 = -value.M51;
			result.M52 = -value.M52;
			result.M53 = -value.M53;
			result.M54 = -value.M54;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00016554 File Offset: 0x00014754
		public static Matrix5x4 Negate(Matrix5x4 value)
		{
			Matrix5x4 result;
			Matrix5x4.Negate(ref value, out result);
			return result;
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0001656C File Offset: 0x0001476C
		public static void Lerp(ref Matrix5x4 start, ref Matrix5x4 end, float amount, out Matrix5x4 result)
		{
			result.M11 = MathUtil.Lerp(start.M11, end.M11, amount);
			result.M12 = MathUtil.Lerp(start.M12, end.M12, amount);
			result.M13 = MathUtil.Lerp(start.M13, end.M13, amount);
			result.M14 = MathUtil.Lerp(start.M14, end.M14, amount);
			result.M21 = MathUtil.Lerp(start.M21, end.M21, amount);
			result.M22 = MathUtil.Lerp(start.M22, end.M22, amount);
			result.M23 = MathUtil.Lerp(start.M23, end.M23, amount);
			result.M24 = MathUtil.Lerp(start.M24, end.M24, amount);
			result.M31 = MathUtil.Lerp(start.M31, end.M31, amount);
			result.M32 = MathUtil.Lerp(start.M32, end.M32, amount);
			result.M33 = MathUtil.Lerp(start.M33, end.M33, amount);
			result.M34 = MathUtil.Lerp(start.M34, end.M34, amount);
			result.M41 = MathUtil.Lerp(start.M41, end.M41, amount);
			result.M42 = MathUtil.Lerp(start.M42, end.M42, amount);
			result.M43 = MathUtil.Lerp(start.M43, end.M43, amount);
			result.M44 = MathUtil.Lerp(start.M44, end.M44, amount);
			result.M51 = MathUtil.Lerp(start.M51, end.M51, amount);
			result.M52 = MathUtil.Lerp(start.M52, end.M52, amount);
			result.M53 = MathUtil.Lerp(start.M53, end.M53, amount);
			result.M54 = MathUtil.Lerp(start.M54, end.M54, amount);
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0001675C File Offset: 0x0001495C
		public static Matrix5x4 Lerp(Matrix5x4 start, Matrix5x4 end, float amount)
		{
			Matrix5x4 result;
			Matrix5x4.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00016776 File Offset: 0x00014976
		public static void SmoothStep(ref Matrix5x4 start, ref Matrix5x4 end, float amount, out Matrix5x4 result)
		{
			amount = MathUtil.SmoothStep(amount);
			Matrix5x4.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0001678C File Offset: 0x0001498C
		public static Matrix5x4 SmoothStep(Matrix5x4 start, Matrix5x4 end, float amount)
		{
			Matrix5x4 result;
			Matrix5x4.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x000167A6 File Offset: 0x000149A6
		public static void Scaling(ref Vector4 scale, out Matrix5x4 result)
		{
			Matrix5x4.Scaling(scale.X, scale.Y, scale.Z, scale.W, out result);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x000167C8 File Offset: 0x000149C8
		public static Matrix5x4 Scaling(Vector4 scale)
		{
			Matrix5x4 result;
			Matrix5x4.Scaling(ref scale, out result);
			return result;
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x000167DF File Offset: 0x000149DF
		public static void Scaling(float x, float y, float z, float w, out Matrix5x4 result)
		{
			result = Matrix5x4.Identity;
			result.M11 = x;
			result.M22 = y;
			result.M33 = z;
			result.M44 = w;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00016810 File Offset: 0x00014A10
		public static Matrix5x4 Scaling(float x, float y, float z, float w)
		{
			Matrix5x4 result;
			Matrix5x4.Scaling(x, y, z, w, out result);
			return result;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0001682C File Offset: 0x00014A2C
		public static void Scaling(float scale, out Matrix5x4 result)
		{
			result = Matrix5x4.Identity;
			result.M44 = scale;
			result.M33 = scale;
			result.M22 = scale;
			result.M11 = scale;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00016868 File Offset: 0x00014A68
		public static Matrix5x4 Scaling(float scale)
		{
			Matrix5x4 result;
			Matrix5x4.Scaling(scale, out result);
			return result;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0001687E File Offset: 0x00014A7E
		public static void Translation(ref Vector4 value, out Matrix5x4 result)
		{
			Matrix5x4.Translation(value.X, value.Y, value.Z, value.W, out result);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x000168A0 File Offset: 0x00014AA0
		public static Matrix5x4 Translation(Vector4 value)
		{
			Matrix5x4 result;
			Matrix5x4.Translation(ref value, out result);
			return result;
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x000168B7 File Offset: 0x00014AB7
		public static void Translation(float x, float y, float z, float w, out Matrix5x4 result)
		{
			result = Matrix5x4.Identity;
			result.M51 = x;
			result.M52 = y;
			result.M53 = z;
			result.M54 = w;
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x000168E8 File Offset: 0x00014AE8
		public static Matrix5x4 Translation(float x, float y, float z, float w)
		{
			Matrix5x4 result;
			Matrix5x4.Translation(x, y, z, w, out result);
			return result;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00016904 File Offset: 0x00014B04
		public static Matrix5x4 operator +(Matrix5x4 left, Matrix5x4 right)
		{
			Matrix5x4 result;
			Matrix5x4.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00002505 File Offset: 0x00000705
		public static Matrix5x4 operator +(Matrix5x4 value)
		{
			return value;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00016920 File Offset: 0x00014B20
		public static Matrix5x4 operator -(Matrix5x4 left, Matrix5x4 right)
		{
			Matrix5x4 result;
			Matrix5x4.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0001693C File Offset: 0x00014B3C
		public static Matrix5x4 operator -(Matrix5x4 value)
		{
			Matrix5x4 result;
			Matrix5x4.Negate(ref value, out result);
			return result;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00016954 File Offset: 0x00014B54
		public static Matrix5x4 operator *(float left, Matrix5x4 right)
		{
			Matrix5x4 result;
			Matrix5x4.Multiply(ref right, left, out result);
			return result;
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0001696C File Offset: 0x00014B6C
		public static Matrix5x4 operator *(Matrix5x4 left, float right)
		{
			Matrix5x4 result;
			Matrix5x4.Multiply(ref left, right, out result);
			return result;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00016984 File Offset: 0x00014B84
		public static Matrix5x4 operator /(Matrix5x4 left, float right)
		{
			Matrix5x4 result;
			Matrix5x4.Divide(ref left, right, out result);
			return result;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0001699C File Offset: 0x00014B9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Matrix5x4 left, Matrix5x4 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x000169A7 File Offset: 0x00014BA7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Matrix5x4 left, Matrix5x4 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x000169B8 File Offset: 0x00014BB8
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M3:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}] [M51:{16} M52:{17} M53:{18} M54:{19}]", new object[]
			{
				this.M11,
				this.M12,
				this.M13,
				this.M14,
				this.M21,
				this.M22,
				this.M23,
				this.M24,
				this.M31,
				this.M32,
				this.M33,
				this.M34,
				this.M41,
				this.M42,
				this.M43,
				this.M44,
				this.M51,
				this.M52,
				this.M53,
				this.M54
			});
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00016B00 File Offset: 0x00014D00
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(format, new object[]
			{
				CultureInfo.CurrentCulture,
				"[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M3:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}] [M51:{16} M52:{17} M53:{18} M54:{19}]",
				this.M11.ToString(format, CultureInfo.CurrentCulture),
				this.M12.ToString(format, CultureInfo.CurrentCulture),
				this.M13.ToString(format, CultureInfo.CurrentCulture),
				this.M14.ToString(format, CultureInfo.CurrentCulture),
				this.M21.ToString(format, CultureInfo.CurrentCulture),
				this.M22.ToString(format, CultureInfo.CurrentCulture),
				this.M23.ToString(format, CultureInfo.CurrentCulture),
				this.M24.ToString(format, CultureInfo.CurrentCulture),
				this.M31.ToString(format, CultureInfo.CurrentCulture),
				this.M32.ToString(format, CultureInfo.CurrentCulture),
				this.M33.ToString(format, CultureInfo.CurrentCulture),
				this.M34.ToString(format, CultureInfo.CurrentCulture),
				this.M41.ToString(format, CultureInfo.CurrentCulture),
				this.M42.ToString(format, CultureInfo.CurrentCulture),
				this.M43.ToString(format, CultureInfo.CurrentCulture),
				this.M44.ToString(format, CultureInfo.CurrentCulture),
				this.M51.ToString(format, CultureInfo.CurrentCulture),
				this.M52.ToString(format, CultureInfo.CurrentCulture),
				this.M53.ToString(format, CultureInfo.CurrentCulture),
				this.M54.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00016CD8 File Offset: 0x00014ED8
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M3:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}] [M51:{16} M52:{17} M53:{18} M54:{19}]", new object[]
			{
				this.M11.ToString(formatProvider),
				this.M12.ToString(formatProvider),
				this.M13.ToString(formatProvider),
				this.M14.ToString(formatProvider),
				this.M21.ToString(formatProvider),
				this.M22.ToString(formatProvider),
				this.M23.ToString(formatProvider),
				this.M24.ToString(formatProvider),
				this.M31.ToString(formatProvider),
				this.M32.ToString(formatProvider),
				this.M33.ToString(formatProvider),
				this.M34.ToString(formatProvider),
				this.M41.ToString(formatProvider),
				this.M42.ToString(formatProvider),
				this.M43.ToString(formatProvider),
				this.M44.ToString(formatProvider),
				this.M51.ToString(formatProvider),
				this.M52.ToString(formatProvider),
				this.M53.ToString(formatProvider),
				this.M54.ToString(formatProvider)
			});
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00016E30 File Offset: 0x00015030
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(format, new object[]
			{
				formatProvider,
				"[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M3:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}] [M51:{16} M52:{17} M53:{18} M54:{19}]",
				this.M11.ToString(format, formatProvider),
				this.M12.ToString(format, formatProvider),
				this.M13.ToString(format, formatProvider),
				this.M14.ToString(format, formatProvider),
				this.M21.ToString(format, formatProvider),
				this.M22.ToString(format, formatProvider),
				this.M23.ToString(format, formatProvider),
				this.M24.ToString(format, formatProvider),
				this.M31.ToString(format, formatProvider),
				this.M32.ToString(format, formatProvider),
				this.M33.ToString(format, formatProvider),
				this.M34.ToString(format, formatProvider),
				this.M41.ToString(format, formatProvider),
				this.M42.ToString(format, formatProvider),
				this.M43.ToString(format, formatProvider),
				this.M44.ToString(format, formatProvider),
				this.M51.ToString(format, formatProvider),
				this.M52.ToString(format, formatProvider),
				this.M53.ToString(format, formatProvider),
				this.M54.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00016FB0 File Offset: 0x000151B0
		public override int GetHashCode()
		{
			return ((((((((((((((((((this.M11.GetHashCode() * 397 ^ this.M12.GetHashCode()) * 397 ^ this.M13.GetHashCode()) * 397 ^ this.M14.GetHashCode()) * 397 ^ this.M21.GetHashCode()) * 397 ^ this.M22.GetHashCode()) * 397 ^ this.M23.GetHashCode()) * 397 ^ this.M24.GetHashCode()) * 397 ^ this.M31.GetHashCode()) * 397 ^ this.M32.GetHashCode()) * 397 ^ this.M33.GetHashCode()) * 397 ^ this.M34.GetHashCode()) * 397 ^ this.M41.GetHashCode()) * 397 ^ this.M42.GetHashCode()) * 397 ^ this.M43.GetHashCode()) * 397 ^ this.M44.GetHashCode()) * 397 ^ this.M51.GetHashCode()) * 397 ^ this.M52.GetHashCode()) * 397 ^ this.M53.GetHashCode()) * 397 ^ this.M54.GetHashCode();
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00017120 File Offset: 0x00015320
		public bool Equals(ref Matrix5x4 other)
		{
			return MathUtil.NearEqual(other.M11, this.M11) && MathUtil.NearEqual(other.M12, this.M12) && MathUtil.NearEqual(other.M13, this.M13) && MathUtil.NearEqual(other.M14, this.M14) && MathUtil.NearEqual(other.M21, this.M21) && MathUtil.NearEqual(other.M22, this.M22) && MathUtil.NearEqual(other.M23, this.M23) && MathUtil.NearEqual(other.M24, this.M24) && MathUtil.NearEqual(other.M31, this.M31) && MathUtil.NearEqual(other.M32, this.M32) && MathUtil.NearEqual(other.M33, this.M33) && MathUtil.NearEqual(other.M34, this.M34) && MathUtil.NearEqual(other.M41, this.M41) && MathUtil.NearEqual(other.M42, this.M42) && MathUtil.NearEqual(other.M43, this.M43) && MathUtil.NearEqual(other.M44, this.M44) && MathUtil.NearEqual(other.M51, this.M51) && MathUtil.NearEqual(other.M52, this.M52) && MathUtil.NearEqual(other.M53, this.M53) && MathUtil.NearEqual(other.M54, this.M54);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x000172D0 File Offset: 0x000154D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Matrix5x4 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x000172DC File Offset: 0x000154DC
		public override bool Equals(object value)
		{
			if (!(value is Matrix5x4))
			{
				return false;
			}
			Matrix5x4 matrix5x = (Matrix5x4)value;
			return this.Equals(ref matrix5x);
		}

		// Token: 0x04000133 RID: 307
		public static readonly int SizeInBytes = Utilities.SizeOf<Matrix5x4>();

		// Token: 0x04000134 RID: 308
		public static readonly Matrix5x4 Zero = default(Matrix5x4);

		// Token: 0x04000135 RID: 309
		public static readonly Matrix5x4 Identity = new Matrix5x4
		{
			M11 = 1f,
			M22 = 1f,
			M33 = 1f,
			M44 = 1f,
			M54 = 0f
		};

		// Token: 0x04000136 RID: 310
		public float M11;

		// Token: 0x04000137 RID: 311
		public float M12;

		// Token: 0x04000138 RID: 312
		public float M13;

		// Token: 0x04000139 RID: 313
		public float M14;

		// Token: 0x0400013A RID: 314
		public float M21;

		// Token: 0x0400013B RID: 315
		public float M22;

		// Token: 0x0400013C RID: 316
		public float M23;

		// Token: 0x0400013D RID: 317
		public float M24;

		// Token: 0x0400013E RID: 318
		public float M31;

		// Token: 0x0400013F RID: 319
		public float M32;

		// Token: 0x04000140 RID: 320
		public float M33;

		// Token: 0x04000141 RID: 321
		public float M34;

		// Token: 0x04000142 RID: 322
		public float M41;

		// Token: 0x04000143 RID: 323
		public float M42;

		// Token: 0x04000144 RID: 324
		public float M43;

		// Token: 0x04000145 RID: 325
		public float M44;

		// Token: 0x04000146 RID: 326
		public float M51;

		// Token: 0x04000147 RID: 327
		public float M52;

		// Token: 0x04000148 RID: 328
		public float M53;

		// Token: 0x04000149 RID: 329
		public float M54;
	}
}

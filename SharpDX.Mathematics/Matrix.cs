using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000019 RID: 25
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Matrix : IEquatable<Matrix>, IFormattable
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x0000CBB4 File Offset: 0x0000ADB4
		// (set) Token: 0x060002EA RID: 746 RVA: 0x0000CBE9 File Offset: 0x0000ADE9
		public Vector3 Up
		{
			get
			{
				Vector3 result;
				result.X = this.M21;
				result.Y = this.M22;
				result.Z = this.M23;
				return result;
			}
			set
			{
				this.M21 = value.X;
				this.M22 = value.Y;
				this.M23 = value.Z;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060002EB RID: 747 RVA: 0x0000CC10 File Offset: 0x0000AE10
		// (set) Token: 0x060002EC RID: 748 RVA: 0x0000CC48 File Offset: 0x0000AE48
		public Vector3 Down
		{
			get
			{
				Vector3 result;
				result.X = -this.M21;
				result.Y = -this.M22;
				result.Z = -this.M23;
				return result;
			}
			set
			{
				this.M21 = -value.X;
				this.M22 = -value.Y;
				this.M23 = -value.Z;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060002ED RID: 749 RVA: 0x0000CC74 File Offset: 0x0000AE74
		// (set) Token: 0x060002EE RID: 750 RVA: 0x0000CCA9 File Offset: 0x0000AEA9
		public Vector3 Right
		{
			get
			{
				Vector3 result;
				result.X = this.M11;
				result.Y = this.M12;
				result.Z = this.M13;
				return result;
			}
			set
			{
				this.M11 = value.X;
				this.M12 = value.Y;
				this.M13 = value.Z;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060002EF RID: 751 RVA: 0x0000CCD0 File Offset: 0x0000AED0
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x0000CD08 File Offset: 0x0000AF08
		public Vector3 Left
		{
			get
			{
				Vector3 result;
				result.X = -this.M11;
				result.Y = -this.M12;
				result.Z = -this.M13;
				return result;
			}
			set
			{
				this.M11 = -value.X;
				this.M12 = -value.Y;
				this.M13 = -value.Z;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000CD34 File Offset: 0x0000AF34
		// (set) Token: 0x060002F2 RID: 754 RVA: 0x0000CD6C File Offset: 0x0000AF6C
		public Vector3 Forward
		{
			get
			{
				Vector3 result;
				result.X = -this.M31;
				result.Y = -this.M32;
				result.Z = -this.M33;
				return result;
			}
			set
			{
				this.M31 = -value.X;
				this.M32 = -value.Y;
				this.M33 = -value.Z;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000CD98 File Offset: 0x0000AF98
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x0000CDCD File Offset: 0x0000AFCD
		public Vector3 Backward
		{
			get
			{
				Vector3 result;
				result.X = this.M31;
				result.Y = this.M32;
				result.Z = this.M33;
				return result;
			}
			set
			{
				this.M31 = value.X;
				this.M32 = value.Y;
				this.M33 = value.Z;
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000CDF4 File Offset: 0x0000AFF4
		public Matrix(float value)
		{
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

		// Token: 0x060002F6 RID: 758 RVA: 0x0000CE90 File Offset: 0x0000B090
		public Matrix(float M11, float M12, float M13, float M14, float M21, float M22, float M23, float M24, float M31, float M32, float M33, float M34, float M41, float M42, float M43, float M44)
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
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000CF1C File Offset: 0x0000B11C
		public Matrix(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 16)
			{
				throw new ArgumentOutOfRangeException("values", "There must be sixteen and only sixteen input values for Matrix.");
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
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x0000CFE5 File Offset: 0x0000B1E5
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x0000D004 File Offset: 0x0000B204
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

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060002FA RID: 762 RVA: 0x0000D036 File Offset: 0x0000B236
		// (set) Token: 0x060002FB RID: 763 RVA: 0x0000D055 File Offset: 0x0000B255
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

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060002FC RID: 764 RVA: 0x0000D087 File Offset: 0x0000B287
		// (set) Token: 0x060002FD RID: 765 RVA: 0x0000D0A6 File Offset: 0x0000B2A6
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

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060002FE RID: 766 RVA: 0x0000D0D8 File Offset: 0x0000B2D8
		// (set) Token: 0x060002FF RID: 767 RVA: 0x0000D0F7 File Offset: 0x0000B2F7
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

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000D129 File Offset: 0x0000B329
		// (set) Token: 0x06000301 RID: 769 RVA: 0x0000D148 File Offset: 0x0000B348
		public Vector4 Column1
		{
			get
			{
				return new Vector4(this.M11, this.M21, this.M31, this.M41);
			}
			set
			{
				this.M11 = value.X;
				this.M21 = value.Y;
				this.M31 = value.Z;
				this.M41 = value.W;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000302 RID: 770 RVA: 0x0000D17A File Offset: 0x0000B37A
		// (set) Token: 0x06000303 RID: 771 RVA: 0x0000D199 File Offset: 0x0000B399
		public Vector4 Column2
		{
			get
			{
				return new Vector4(this.M12, this.M22, this.M32, this.M42);
			}
			set
			{
				this.M12 = value.X;
				this.M22 = value.Y;
				this.M32 = value.Z;
				this.M42 = value.W;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000304 RID: 772 RVA: 0x0000D1CB File Offset: 0x0000B3CB
		// (set) Token: 0x06000305 RID: 773 RVA: 0x0000D1EA File Offset: 0x0000B3EA
		public Vector4 Column3
		{
			get
			{
				return new Vector4(this.M13, this.M23, this.M33, this.M43);
			}
			set
			{
				this.M13 = value.X;
				this.M23 = value.Y;
				this.M33 = value.Z;
				this.M43 = value.W;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000306 RID: 774 RVA: 0x0000D21C File Offset: 0x0000B41C
		// (set) Token: 0x06000307 RID: 775 RVA: 0x0000D23B File Offset: 0x0000B43B
		public Vector4 Column4
		{
			get
			{
				return new Vector4(this.M14, this.M24, this.M34, this.M44);
			}
			set
			{
				this.M14 = value.X;
				this.M24 = value.Y;
				this.M34 = value.Z;
				this.M44 = value.W;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000308 RID: 776 RVA: 0x0000D26D File Offset: 0x0000B46D
		// (set) Token: 0x06000309 RID: 777 RVA: 0x0000D286 File Offset: 0x0000B486
		public Vector3 TranslationVector
		{
			get
			{
				return new Vector3(this.M41, this.M42, this.M43);
			}
			set
			{
				this.M41 = value.X;
				this.M42 = value.Y;
				this.M43 = value.Z;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600030A RID: 778 RVA: 0x0000D2AC File Offset: 0x0000B4AC
		// (set) Token: 0x0600030B RID: 779 RVA: 0x0000D2C5 File Offset: 0x0000B4C5
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

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600030C RID: 780 RVA: 0x0000D2EB File Offset: 0x0000B4EB
		public bool IsIdentity
		{
			get
			{
				return this.Equals(Matrix.Identity);
			}
		}

		// Token: 0x1700003F RID: 63
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
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Matrix run from 0 to 15, inclusive.");
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
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Matrix run from 0 to 15, inclusive.");
				}
			}
		}

		// Token: 0x17000040 RID: 64
		public float this[int row, int column]
		{
			get
			{
				if (row < 0 || row > 3)
				{
					throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 3, inclusive.");
				}
				if (column < 0 || column > 3)
				{
					throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 3, inclusive.");
				}
				return this[row * 4 + column];
			}
			set
			{
				if (row < 0 || row > 3)
				{
					throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 3, inclusive.");
				}
				if (column < 0 || column > 3)
				{
					throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 3, inclusive.");
				}
				this[row * 4 + column] = value;
			}
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000D530 File Offset: 0x0000B730
		public float Determinant()
		{
			float num = this.M33 * this.M44 - this.M34 * this.M43;
			float num2 = this.M32 * this.M44 - this.M34 * this.M42;
			float num3 = this.M32 * this.M43 - this.M33 * this.M42;
			float num4 = this.M31 * this.M44 - this.M34 * this.M41;
			float num5 = this.M31 * this.M43 - this.M33 * this.M41;
			float num6 = this.M31 * this.M42 - this.M32 * this.M41;
			return this.M11 * (this.M22 * num - this.M23 * num2 + this.M24 * num3) - this.M12 * (this.M21 * num - this.M23 * num4 + this.M24 * num5) + this.M13 * (this.M21 * num2 - this.M22 * num4 + this.M24 * num6) - this.M14 * (this.M21 * num3 - this.M22 * num5 + this.M23 * num6);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0000D672 File Offset: 0x0000B872
		public void Invert()
		{
			Matrix.Invert(ref this, out this);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0000D67B File Offset: 0x0000B87B
		public void Transpose()
		{
			Matrix.Transpose(ref this, out this);
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000D684 File Offset: 0x0000B884
		public void Orthogonalize()
		{
			Matrix.Orthogonalize(ref this, out this);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000D68D File Offset: 0x0000B88D
		public void Orthonormalize()
		{
			Matrix.Orthonormalize(ref this, out this);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000D698 File Offset: 0x0000B898
		public void DecomposeQR(out Matrix Q, out Matrix R)
		{
			Matrix matrix = this;
			matrix.Transpose();
			Matrix.Orthonormalize(ref matrix, out Q);
			Q.Transpose();
			R = default(Matrix);
			R.M11 = Vector4.Dot(Q.Column1, this.Column1);
			R.M12 = Vector4.Dot(Q.Column1, this.Column2);
			R.M13 = Vector4.Dot(Q.Column1, this.Column3);
			R.M14 = Vector4.Dot(Q.Column1, this.Column4);
			R.M22 = Vector4.Dot(Q.Column2, this.Column2);
			R.M23 = Vector4.Dot(Q.Column2, this.Column3);
			R.M24 = Vector4.Dot(Q.Column2, this.Column4);
			R.M33 = Vector4.Dot(Q.Column3, this.Column3);
			R.M34 = Vector4.Dot(Q.Column3, this.Column4);
			R.M44 = Vector4.Dot(Q.Column4, this.Column4);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000D7B0 File Offset: 0x0000B9B0
		public void DecomposeLQ(out Matrix L, out Matrix Q)
		{
			Matrix.Orthonormalize(ref this, out Q);
			L = default(Matrix);
			L.M11 = Vector4.Dot(Q.Row1, this.Row1);
			L.M21 = Vector4.Dot(Q.Row1, this.Row2);
			L.M22 = Vector4.Dot(Q.Row2, this.Row2);
			L.M31 = Vector4.Dot(Q.Row1, this.Row3);
			L.M32 = Vector4.Dot(Q.Row2, this.Row3);
			L.M33 = Vector4.Dot(Q.Row3, this.Row3);
			L.M41 = Vector4.Dot(Q.Row1, this.Row4);
			L.M42 = Vector4.Dot(Q.Row2, this.Row4);
			L.M43 = Vector4.Dot(Q.Row3, this.Row4);
			L.M44 = Vector4.Dot(Q.Row4, this.Row4);
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000D8B4 File Offset: 0x0000BAB4
		public bool Decompose(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
		{
			translation.X = this.M41;
			translation.Y = this.M42;
			translation.Z = this.M43;
			scale.X = (float)Math.Sqrt((double)(this.M11 * this.M11 + this.M12 * this.M12 + this.M13 * this.M13));
			scale.Y = (float)Math.Sqrt((double)(this.M21 * this.M21 + this.M22 * this.M22 + this.M23 * this.M23));
			scale.Z = (float)Math.Sqrt((double)(this.M31 * this.M31 + this.M32 * this.M32 + this.M33 * this.M33));
			if (MathUtil.IsZero(scale.X) || MathUtil.IsZero(scale.Y) || MathUtil.IsZero(scale.Z))
			{
				rotation = Quaternion.Identity;
				return false;
			}
			Matrix matrix = default(Matrix);
			matrix.M11 = this.M11 / scale.X;
			matrix.M12 = this.M12 / scale.X;
			matrix.M13 = this.M13 / scale.X;
			matrix.M21 = this.M21 / scale.Y;
			matrix.M22 = this.M22 / scale.Y;
			matrix.M23 = this.M23 / scale.Y;
			matrix.M31 = this.M31 / scale.Z;
			matrix.M32 = this.M32 / scale.Z;
			matrix.M33 = this.M33 / scale.Z;
			matrix.M44 = 1f;
			Quaternion.RotationMatrix(ref matrix, out rotation);
			return true;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000DA8C File Offset: 0x0000BC8C
		public bool DecomposeUniformScale(out float scale, out Quaternion rotation, out Vector3 translation)
		{
			translation.X = this.M41;
			translation.Y = this.M42;
			translation.Z = this.M43;
			scale = (float)Math.Sqrt((double)(this.M11 * this.M11 + this.M12 * this.M12 + this.M13 * this.M13));
			float num = 1f / scale;
			if (Math.Abs(scale) < 1E-06f)
			{
				rotation = Quaternion.Identity;
				return false;
			}
			Matrix matrix = default(Matrix);
			matrix.M11 = this.M11 * num;
			matrix.M12 = this.M12 * num;
			matrix.M13 = this.M13 * num;
			matrix.M21 = this.M21 * num;
			matrix.M22 = this.M22 * num;
			matrix.M23 = this.M23 * num;
			matrix.M31 = this.M31 * num;
			matrix.M32 = this.M32 * num;
			matrix.M33 = this.M33 * num;
			matrix.M44 = 1f;
			Quaternion.RotationMatrix(ref matrix, out rotation);
			return true;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000DBB8 File Offset: 0x0000BDB8
		public void ExchangeRows(int firstRow, int secondRow)
		{
			if (firstRow < 0)
			{
				throw new ArgumentOutOfRangeException("firstRow", "The parameter firstRow must be greater than or equal to zero.");
			}
			if (firstRow > 3)
			{
				throw new ArgumentOutOfRangeException("firstRow", "The parameter firstRow must be less than or equal to three.");
			}
			if (secondRow < 0)
			{
				throw new ArgumentOutOfRangeException("secondRow", "The parameter secondRow must be greater than or equal to zero.");
			}
			if (secondRow > 3)
			{
				throw new ArgumentOutOfRangeException("secondRow", "The parameter secondRow must be less than or equal to three.");
			}
			if (firstRow == secondRow)
			{
				return;
			}
			float value = this[secondRow, 0];
			float value2 = this[secondRow, 1];
			float value3 = this[secondRow, 2];
			float value4 = this[secondRow, 3];
			this[secondRow, 0] = this[firstRow, 0];
			this[secondRow, 1] = this[firstRow, 1];
			this[secondRow, 2] = this[firstRow, 2];
			this[secondRow, 3] = this[firstRow, 3];
			this[firstRow, 0] = value;
			this[firstRow, 1] = value2;
			this[firstRow, 2] = value3;
			this[firstRow, 3] = value4;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000DCA4 File Offset: 0x0000BEA4
		public void ExchangeColumns(int firstColumn, int secondColumn)
		{
			if (firstColumn < 0)
			{
				throw new ArgumentOutOfRangeException("firstColumn", "The parameter firstColumn must be greater than or equal to zero.");
			}
			if (firstColumn > 3)
			{
				throw new ArgumentOutOfRangeException("firstColumn", "The parameter firstColumn must be less than or equal to three.");
			}
			if (secondColumn < 0)
			{
				throw new ArgumentOutOfRangeException("secondColumn", "The parameter secondColumn must be greater than or equal to zero.");
			}
			if (secondColumn > 3)
			{
				throw new ArgumentOutOfRangeException("secondColumn", "The parameter secondColumn must be less than or equal to three.");
			}
			if (firstColumn == secondColumn)
			{
				return;
			}
			float value = this[0, secondColumn];
			float value2 = this[1, secondColumn];
			float value3 = this[2, secondColumn];
			float value4 = this[3, secondColumn];
			this[0, secondColumn] = this[0, firstColumn];
			this[1, secondColumn] = this[1, firstColumn];
			this[2, secondColumn] = this[2, firstColumn];
			this[3, secondColumn] = this[3, firstColumn];
			this[0, firstColumn] = value;
			this[1, firstColumn] = value2;
			this[2, firstColumn] = value3;
			this[3, firstColumn] = value4;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000DD90 File Offset: 0x0000BF90
		public float[] ToArray()
		{
			return new float[]
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
				this.M44
			};
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000DE3C File Offset: 0x0000C03C
		public static void Add(ref Matrix left, ref Matrix right, out Matrix result)
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
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000DF7C File Offset: 0x0000C17C
		public static Matrix Add(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000DF98 File Offset: 0x0000C198
		public static void Subtract(ref Matrix left, ref Matrix right, out Matrix result)
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
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000E0D8 File Offset: 0x0000C2D8
		public static Matrix Subtract(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000E0F4 File Offset: 0x0000C2F4
		public static void Multiply(ref Matrix left, float right, out Matrix result)
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
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000E1E4 File Offset: 0x0000C3E4
		public static Matrix Multiply(Matrix left, float right)
		{
			Matrix result;
			Matrix.Multiply(ref left, right, out result);
			return result;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000E1FC File Offset: 0x0000C3FC
		public static void Multiply(ref Matrix left, ref Matrix right, out Matrix result)
		{
			result = new Matrix
			{
				M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41,
				M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42,
				M13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43,
				M14 = left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44,
				M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41,
				M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42,
				M23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43,
				M24 = left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44,
				M31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31 + left.M34 * right.M41,
				M32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32 + left.M34 * right.M42,
				M33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33 + left.M34 * right.M43,
				M34 = left.M31 * right.M14 + left.M32 * right.M24 + left.M33 * right.M34 + left.M34 * right.M44,
				M41 = left.M41 * right.M11 + left.M42 * right.M21 + left.M43 * right.M31 + left.M44 * right.M41,
				M42 = left.M41 * right.M12 + left.M42 * right.M22 + left.M43 * right.M32 + left.M44 * right.M42,
				M43 = left.M41 * right.M13 + left.M42 * right.M23 + left.M43 * right.M33 + left.M44 * right.M43,
				M44 = left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M34 + left.M44 * right.M44
			};
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000E5F8 File Offset: 0x0000C7F8
		public static Matrix Multiply(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000E614 File Offset: 0x0000C814
		public static void Divide(ref Matrix left, float right, out Matrix result)
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
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000E70C File Offset: 0x0000C90C
		public static Matrix Divide(Matrix left, float right)
		{
			Matrix result;
			Matrix.Divide(ref left, right, out result);
			return result;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000E724 File Offset: 0x0000C924
		public static void Divide(ref Matrix left, ref Matrix right, out Matrix result)
		{
			result.M11 = left.M11 / right.M11;
			result.M12 = left.M12 / right.M12;
			result.M13 = left.M13 / right.M13;
			result.M14 = left.M14 / right.M14;
			result.M21 = left.M21 / right.M21;
			result.M22 = left.M22 / right.M22;
			result.M23 = left.M23 / right.M23;
			result.M24 = left.M24 / right.M24;
			result.M31 = left.M31 / right.M31;
			result.M32 = left.M32 / right.M32;
			result.M33 = left.M33 / right.M33;
			result.M34 = left.M34 / right.M34;
			result.M41 = left.M41 / right.M41;
			result.M42 = left.M42 / right.M42;
			result.M43 = left.M43 / right.M43;
			result.M44 = left.M44 / right.M44;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000E864 File Offset: 0x0000CA64
		public static Matrix Divide(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Divide(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000E880 File Offset: 0x0000CA80
		public static void Exponent(ref Matrix value, int exponent, out Matrix result)
		{
			if (exponent < 0)
			{
				throw new ArgumentOutOfRangeException("exponent", "The exponent can not be negative.");
			}
			if (exponent == 0)
			{
				result = Matrix.Identity;
				return;
			}
			if (exponent == 1)
			{
				result = value;
				return;
			}
			Matrix matrix = Matrix.Identity;
			Matrix matrix2 = value;
			for (;;)
			{
				if ((exponent & 1) != 0)
				{
					matrix *= matrix2;
				}
				exponent /= 2;
				if (exponent <= 0)
				{
					break;
				}
				matrix2 *= matrix2;
			}
			result = matrix;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000E8F8 File Offset: 0x0000CAF8
		public static Matrix Exponent(Matrix value, int exponent)
		{
			Matrix result;
			Matrix.Exponent(ref value, exponent, out result);
			return result;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000E910 File Offset: 0x0000CB10
		public static void Negate(ref Matrix value, out Matrix result)
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
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000E9F0 File Offset: 0x0000CBF0
		public static Matrix Negate(Matrix value)
		{
			Matrix result;
			Matrix.Negate(ref value, out result);
			return result;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000EA08 File Offset: 0x0000CC08
		public static void Lerp(ref Matrix start, ref Matrix end, float amount, out Matrix result)
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
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000EB98 File Offset: 0x0000CD98
		public static Matrix Lerp(Matrix start, Matrix end, float amount)
		{
			Matrix result;
			Matrix.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000EBB2 File Offset: 0x0000CDB2
		public static void SmoothStep(ref Matrix start, ref Matrix end, float amount, out Matrix result)
		{
			amount = MathUtil.SmoothStep(amount);
			Matrix.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000EBC8 File Offset: 0x0000CDC8
		public static Matrix SmoothStep(Matrix start, Matrix end, float amount)
		{
			Matrix result;
			Matrix.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000EBE4 File Offset: 0x0000CDE4
		public static void Transpose(ref Matrix value, out Matrix result)
		{
			result = new Matrix
			{
				M11 = value.M11,
				M12 = value.M21,
				M13 = value.M31,
				M14 = value.M41,
				M21 = value.M12,
				M22 = value.M22,
				M23 = value.M32,
				M24 = value.M42,
				M31 = value.M13,
				M32 = value.M23,
				M33 = value.M33,
				M34 = value.M43,
				M41 = value.M14,
				M42 = value.M24,
				M43 = value.M34,
				M44 = value.M44
			};
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000ECD0 File Offset: 0x0000CED0
		public static void TransposeByRef(ref Matrix value, ref Matrix result)
		{
			result.M11 = value.M11;
			result.M12 = value.M21;
			result.M13 = value.M31;
			result.M14 = value.M41;
			result.M21 = value.M12;
			result.M22 = value.M22;
			result.M23 = value.M32;
			result.M24 = value.M42;
			result.M31 = value.M13;
			result.M32 = value.M23;
			result.M33 = value.M33;
			result.M34 = value.M43;
			result.M41 = value.M14;
			result.M42 = value.M24;
			result.M43 = value.M34;
			result.M44 = value.M44;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000EDA0 File Offset: 0x0000CFA0
		public static Matrix Transpose(Matrix value)
		{
			Matrix result;
			Matrix.Transpose(ref value, out result);
			return result;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000EDB8 File Offset: 0x0000CFB8
		public static void Invert(ref Matrix value, out Matrix result)
		{
			float num = value.M31 * value.M42 - value.M32 * value.M41;
			float num2 = value.M31 * value.M43 - value.M33 * value.M41;
			float num3 = value.M34 * value.M41 - value.M31 * value.M44;
			float num4 = value.M32 * value.M43 - value.M33 * value.M42;
			float num5 = value.M34 * value.M42 - value.M32 * value.M44;
			float num6 = value.M33 * value.M44 - value.M34 * value.M43;
			float num7 = value.M22 * num6 + value.M23 * num5 + value.M24 * num4;
			float num8 = value.M21 * num6 + value.M23 * num3 + value.M24 * num2;
			float num9 = value.M21 * -num5 + value.M22 * num3 + value.M24 * num;
			float num10 = value.M21 * num4 + value.M22 * -num2 + value.M23 * num;
			float num11 = value.M11 * num7 - value.M12 * num8 + value.M13 * num9 - value.M14 * num10;
			if (Math.Abs(num11) == 0f)
			{
				result = Matrix.Zero;
				return;
			}
			num11 = 1f / num11;
			float num12 = value.M11 * value.M22 - value.M12 * value.M21;
			float num13 = value.M11 * value.M23 - value.M13 * value.M21;
			float num14 = value.M14 * value.M21 - value.M11 * value.M24;
			float num15 = value.M12 * value.M23 - value.M13 * value.M22;
			float num16 = value.M14 * value.M22 - value.M12 * value.M24;
			float num17 = value.M13 * value.M24 - value.M14 * value.M23;
			float num18 = value.M12 * num6 + value.M13 * num5 + value.M14 * num4;
			float num19 = value.M11 * num6 + value.M13 * num3 + value.M14 * num2;
			float num20 = value.M11 * -num5 + value.M12 * num3 + value.M14 * num;
			float num21 = value.M11 * num4 + value.M12 * -num2 + value.M13 * num;
			float num22 = value.M42 * num17 + value.M43 * num16 + value.M44 * num15;
			float num23 = value.M41 * num17 + value.M43 * num14 + value.M44 * num13;
			float num24 = value.M41 * -num16 + value.M42 * num14 + value.M44 * num12;
			float num25 = value.M41 * num15 + value.M42 * -num13 + value.M43 * num12;
			float num26 = value.M32 * num17 + value.M33 * num16 + value.M34 * num15;
			float num27 = value.M31 * num17 + value.M33 * num14 + value.M34 * num13;
			float num28 = value.M31 * -num16 + value.M32 * num14 + value.M34 * num12;
			float num29 = value.M31 * num15 + value.M32 * -num13 + value.M33 * num12;
			result.M11 = num7 * num11;
			result.M12 = -num18 * num11;
			result.M13 = num22 * num11;
			result.M14 = -num26 * num11;
			result.M21 = -num8 * num11;
			result.M22 = num19 * num11;
			result.M23 = -num23 * num11;
			result.M24 = num27 * num11;
			result.M31 = num9 * num11;
			result.M32 = -num20 * num11;
			result.M33 = num24 * num11;
			result.M34 = -num28 * num11;
			result.M41 = -num10 * num11;
			result.M42 = num21 * num11;
			result.M43 = -num25 * num11;
			result.M44 = num29 * num11;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000F20A File Offset: 0x0000D40A
		public static Matrix Invert(Matrix value)
		{
			value.Invert();
			return value;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000F214 File Offset: 0x0000D414
		public static void Orthogonalize(ref Matrix value, out Matrix result)
		{
			result = value;
			result.Row2 -= Vector4.Dot(result.Row1, result.Row2) / Vector4.Dot(result.Row1, result.Row1) * result.Row1;
			result.Row3 -= Vector4.Dot(result.Row1, result.Row3) / Vector4.Dot(result.Row1, result.Row1) * result.Row1;
			result.Row3 -= Vector4.Dot(result.Row2, result.Row3) / Vector4.Dot(result.Row2, result.Row2) * result.Row2;
			result.Row4 -= Vector4.Dot(result.Row1, result.Row4) / Vector4.Dot(result.Row1, result.Row1) * result.Row1;
			result.Row4 -= Vector4.Dot(result.Row2, result.Row4) / Vector4.Dot(result.Row2, result.Row2) * result.Row2;
			result.Row4 -= Vector4.Dot(result.Row3, result.Row4) / Vector4.Dot(result.Row3, result.Row3) * result.Row3;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000F3A8 File Offset: 0x0000D5A8
		public static Matrix Orthogonalize(Matrix value)
		{
			Matrix result;
			Matrix.Orthogonalize(ref value, out result);
			return result;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000F3C0 File Offset: 0x0000D5C0
		public static void Orthonormalize(ref Matrix value, out Matrix result)
		{
			result = value;
			result.Row1 = Vector4.Normalize(result.Row1);
			result.Row2 -= Vector4.Dot(result.Row1, result.Row2) * result.Row1;
			result.Row2 = Vector4.Normalize(result.Row2);
			result.Row3 -= Vector4.Dot(result.Row1, result.Row3) * result.Row1;
			result.Row3 -= Vector4.Dot(result.Row2, result.Row3) * result.Row2;
			result.Row3 = Vector4.Normalize(result.Row3);
			result.Row4 -= Vector4.Dot(result.Row1, result.Row4) * result.Row1;
			result.Row4 -= Vector4.Dot(result.Row2, result.Row4) * result.Row2;
			result.Row4 -= Vector4.Dot(result.Row3, result.Row4) * result.Row3;
			result.Row4 = Vector4.Normalize(result.Row4);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000F52C File Offset: 0x0000D72C
		public static Matrix Orthonormalize(Matrix value)
		{
			Matrix result;
			Matrix.Orthonormalize(ref value, out result);
			return result;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000F544 File Offset: 0x0000D744
		public static void UpperTriangularForm(ref Matrix value, out Matrix result)
		{
			result = value;
			int num = 0;
			int num2 = 4;
			int num3 = 4;
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
						ref Matrix ptr = ref result;
						int row = j;
						ptr[row, 0] = ptr[row, 0] - result[i, 0] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 1] = ptr[row, 1] - result[i, 1] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 2] = ptr[row, 2] - result[i, 2] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 3] = ptr[row, 3] - result[i, 3] * num4 * result[j, num];
					}
					j++;
				}
				num++;
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000F6A8 File Offset: 0x0000D8A8
		public static Matrix UpperTriangularForm(Matrix value)
		{
			Matrix result;
			Matrix.UpperTriangularForm(ref value, out result);
			return result;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000F6C0 File Offset: 0x0000D8C0
		public static void LowerTriangularForm(ref Matrix value, out Matrix result)
		{
			Matrix matrix = value;
			Matrix.Transpose(ref matrix, out result);
			int num = 0;
			int num2 = 4;
			int num3 = 4;
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
						ref Matrix ptr = ref result;
						int row = j;
						ptr[row, 0] = ptr[row, 0] - result[i, 0] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 1] = ptr[row, 1] - result[i, 1] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 2] = ptr[row, 2] - result[i, 2] * num4 * result[j, num];
						ptr = ref result;
						row = j;
						ptr[row, 3] = ptr[row, 3] - result[i, 3] * num4 * result[j, num];
					}
					j++;
				}
				num++;
			}
			Matrix.Transpose(ref result, out result);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000F83C File Offset: 0x0000DA3C
		public static Matrix LowerTriangularForm(Matrix value)
		{
			Matrix result;
			Matrix.LowerTriangularForm(ref value, out result);
			return result;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000F854 File Offset: 0x0000DA54
		public static void RowEchelonForm(ref Matrix value, out Matrix result)
		{
			result = value;
			int num = 0;
			int num2 = 4;
			int num3 = 4;
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
				ref Matrix ptr = ref result;
				int row = i;
				ptr[row, 0] = ptr[row, 0] * num4;
				ptr = ref result;
				row = i;
				ptr[row, 1] = ptr[row, 1] * num4;
				ptr = ref result;
				row = i;
				ptr[row, 2] = ptr[row, 2] * num4;
				ptr = ref result;
				row = i;
				ptr[row, 3] = ptr[row, 3] * num4;
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
						ptr = ref result;
						row = j;
						ptr[row, 3] = ptr[row, 3] - result[i, 3] * result[j, num];
					}
					j++;
				}
				num++;
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000FA20 File Offset: 0x0000DC20
		public static Matrix RowEchelonForm(Matrix value)
		{
			Matrix result;
			Matrix.RowEchelonForm(ref value, out result);
			return result;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000FA38 File Offset: 0x0000DC38
		public static void ReducedRowEchelonForm(ref Matrix value, ref Vector4 augment, out Matrix result, out Vector4 augmentResult)
		{
			float[,] array = new float[4, 5];
			array[0, 0] = value[0, 0];
			array[0, 1] = value[0, 1];
			array[0, 2] = value[0, 2];
			array[0, 3] = value[0, 3];
			array[0, 4] = augment[0];
			array[1, 0] = value[1, 0];
			array[1, 1] = value[1, 1];
			array[1, 2] = value[1, 2];
			array[1, 3] = value[1, 3];
			array[1, 4] = augment[1];
			array[2, 0] = value[2, 0];
			array[2, 1] = value[2, 1];
			array[2, 2] = value[2, 2];
			array[2, 3] = value[2, 3];
			array[2, 4] = augment[2];
			array[3, 0] = value[3, 0];
			array[3, 1] = value[3, 1];
			array[3, 2] = value[3, 2];
			array[3, 3] = value[3, 3];
			array[3, 4] = augment[3];
			int num = 0;
			int num2 = 4;
			int num3 = 5;
			int num4 = 0;
			while (num4 < num2 && num3 > num)
			{
				int num5 = num4;
				while (array[num5, num] == 0f)
				{
					num5++;
					if (num5 == num2)
					{
						num5 = num4;
						num++;
						if (num3 == num)
						{
							break;
						}
					}
				}
				for (int i = 0; i < num3; i++)
				{
					float num6 = array[num4, i];
					array[num4, i] = array[num5, i];
					array[num5, i] = num6;
				}
				float num7 = array[num4, num];
				for (int j = 0; j < num3; j++)
				{
					array[num4, j] /= num7;
				}
				for (int k = 0; k < num2; k++)
				{
					if (k != num4)
					{
						float num8 = array[k, num];
						for (int l = 0; l < num3; l++)
						{
							array[k, l] -= num8 * array[num4, l];
						}
					}
				}
				num++;
				num4++;
			}
			result.M11 = array[0, 0];
			result.M12 = array[0, 1];
			result.M13 = array[0, 2];
			result.M14 = array[0, 3];
			result.M21 = array[1, 0];
			result.M22 = array[1, 1];
			result.M23 = array[1, 2];
			result.M24 = array[1, 3];
			result.M31 = array[2, 0];
			result.M32 = array[2, 1];
			result.M33 = array[2, 2];
			result.M34 = array[2, 3];
			result.M41 = array[3, 0];
			result.M42 = array[3, 1];
			result.M43 = array[3, 2];
			result.M44 = array[3, 3];
			augmentResult.X = array[0, 4];
			augmentResult.Y = array[1, 4];
			augmentResult.Z = array[2, 4];
			augmentResult.W = array[3, 4];
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000FDA8 File Offset: 0x0000DFA8
		public static void BillboardLH(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, ref Vector3 cameraForwardVector, out Matrix result)
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
			result.M14 = 0f;
			result.M21 = vector3.X;
			result.M22 = vector3.Y;
			result.M23 = vector3.Z;
			result.M24 = 0f;
			result.M31 = vector.X;
			result.M32 = vector.Y;
			result.M33 = vector.Z;
			result.M34 = 0f;
			result.M41 = objectPosition.X;
			result.M42 = objectPosition.Y;
			result.M43 = objectPosition.Z;
			result.M44 = 1f;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000FEE8 File Offset: 0x0000E0E8
		public static Matrix BillboardLH(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector)
		{
			Matrix result;
			Matrix.BillboardLH(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
			return result;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000FF08 File Offset: 0x0000E108
		public static void BillboardRH(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, ref Vector3 cameraForwardVector, out Matrix result)
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
			result.M14 = 0f;
			result.M21 = vector3.X;
			result.M22 = vector3.Y;
			result.M23 = vector3.Z;
			result.M24 = 0f;
			result.M31 = vector.X;
			result.M32 = vector.Y;
			result.M33 = vector.Z;
			result.M34 = 0f;
			result.M41 = objectPosition.X;
			result.M42 = objectPosition.Y;
			result.M43 = objectPosition.Z;
			result.M44 = 1f;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00010048 File Offset: 0x0000E248
		public static Matrix BillboardRH(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector)
		{
			Matrix result;
			Matrix.BillboardRH(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
			return result;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00010068 File Offset: 0x0000E268
		public static void LookAtLH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Matrix result)
		{
			Vector3 vector;
			Vector3.Subtract(ref target, ref eye, out vector);
			vector.Normalize();
			Vector3 vector2;
			Vector3.Cross(ref up, ref vector, out vector2);
			vector2.Normalize();
			Vector3 vector3;
			Vector3.Cross(ref vector, ref vector2, out vector3);
			result = Matrix.Identity;
			result.M11 = vector2.X;
			result.M21 = vector2.Y;
			result.M31 = vector2.Z;
			result.M12 = vector3.X;
			result.M22 = vector3.Y;
			result.M32 = vector3.Z;
			result.M13 = vector.X;
			result.M23 = vector.Y;
			result.M33 = vector.Z;
			Vector3.Dot(ref vector2, ref eye, out result.M41);
			Vector3.Dot(ref vector3, ref eye, out result.M42);
			Vector3.Dot(ref vector, ref eye, out result.M43);
			result.M41 = -result.M41;
			result.M42 = -result.M42;
			result.M43 = -result.M43;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0001016C File Offset: 0x0000E36C
		public static Matrix LookAtLH(Vector3 eye, Vector3 target, Vector3 up)
		{
			Matrix result;
			Matrix.LookAtLH(ref eye, ref target, ref up, out result);
			return result;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00010188 File Offset: 0x0000E388
		public static void LookAtRH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Matrix result)
		{
			Vector3 vector;
			Vector3.Subtract(ref eye, ref target, out vector);
			vector.Normalize();
			Vector3 vector2;
			Vector3.Cross(ref up, ref vector, out vector2);
			vector2.Normalize();
			Vector3 vector3;
			Vector3.Cross(ref vector, ref vector2, out vector3);
			result = Matrix.Identity;
			result.M11 = vector2.X;
			result.M21 = vector2.Y;
			result.M31 = vector2.Z;
			result.M12 = vector3.X;
			result.M22 = vector3.Y;
			result.M32 = vector3.Z;
			result.M13 = vector.X;
			result.M23 = vector.Y;
			result.M33 = vector.Z;
			Vector3.Dot(ref vector2, ref eye, out result.M41);
			Vector3.Dot(ref vector3, ref eye, out result.M42);
			Vector3.Dot(ref vector, ref eye, out result.M43);
			result.M41 = -result.M41;
			result.M42 = -result.M42;
			result.M43 = -result.M43;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0001028C File Offset: 0x0000E48C
		public static Matrix LookAtRH(Vector3 eye, Vector3 target, Vector3 up)
		{
			Matrix result;
			Matrix.LookAtRH(ref eye, ref target, ref up, out result);
			return result;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000102A8 File Offset: 0x0000E4A8
		public static void OrthoLH(float width, float height, float znear, float zfar, out Matrix result)
		{
			float num = width * 0.5f;
			float num2 = height * 0.5f;
			Matrix.OrthoOffCenterLH(-num, num, -num2, num2, znear, zfar, out result);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x000102D4 File Offset: 0x0000E4D4
		public static Matrix OrthoLH(float width, float height, float znear, float zfar)
		{
			Matrix result;
			Matrix.OrthoLH(width, height, znear, zfar, out result);
			return result;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x000102F0 File Offset: 0x0000E4F0
		public static void OrthoRH(float width, float height, float znear, float zfar, out Matrix result)
		{
			float num = width * 0.5f;
			float num2 = height * 0.5f;
			Matrix.OrthoOffCenterRH(-num, num, -num2, num2, znear, zfar, out result);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0001031C File Offset: 0x0000E51C
		public static Matrix OrthoRH(float width, float height, float znear, float zfar)
		{
			Matrix result;
			Matrix.OrthoRH(width, height, znear, zfar, out result);
			return result;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00010338 File Offset: 0x0000E538
		public static void OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
		{
			float num = 1f / (zfar - znear);
			result = Matrix.Identity;
			result.M11 = 2f / (right - left);
			result.M22 = 2f / (top - bottom);
			result.M33 = num;
			result.M41 = (left + right) / (left - right);
			result.M42 = (top + bottom) / (bottom - top);
			result.M43 = -znear * num;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x000103B0 File Offset: 0x0000E5B0
		public static Matrix OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar)
		{
			Matrix result;
			Matrix.OrthoOffCenterLH(left, right, bottom, top, znear, zfar, out result);
			return result;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x000103CD File Offset: 0x0000E5CD
		public static void OrthoOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
		{
			Matrix.OrthoOffCenterLH(left, right, bottom, top, znear, zfar, out result);
			result.M33 *= -1f;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x000103F0 File Offset: 0x0000E5F0
		public static Matrix OrthoOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar)
		{
			Matrix result;
			Matrix.OrthoOffCenterRH(left, right, bottom, top, znear, zfar, out result);
			return result;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00010410 File Offset: 0x0000E610
		public static void PerspectiveLH(float width, float height, float znear, float zfar, out Matrix result)
		{
			float num = width * 0.5f;
			float num2 = height * 0.5f;
			Matrix.PerspectiveOffCenterLH(-num, num, -num2, num2, znear, zfar, out result);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0001043C File Offset: 0x0000E63C
		public static Matrix PerspectiveLH(float width, float height, float znear, float zfar)
		{
			Matrix result;
			Matrix.PerspectiveLH(width, height, znear, zfar, out result);
			return result;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00010458 File Offset: 0x0000E658
		public static void PerspectiveRH(float width, float height, float znear, float zfar, out Matrix result)
		{
			float num = width * 0.5f;
			float num2 = height * 0.5f;
			Matrix.PerspectiveOffCenterRH(-num, num, -num2, num2, znear, zfar, out result);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00010484 File Offset: 0x0000E684
		public static Matrix PerspectiveRH(float width, float height, float znear, float zfar)
		{
			Matrix result;
			Matrix.PerspectiveRH(width, height, znear, zfar, out result);
			return result;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000104A0 File Offset: 0x0000E6A0
		public static void PerspectiveFovLH(float fov, float aspect, float znear, float zfar, out Matrix result)
		{
			float num = (float)(1.0 / Math.Tan((double)(fov * 0.5f)));
			float num2 = zfar / (zfar - znear);
			result = default(Matrix);
			result.M11 = num / aspect;
			result.M22 = num;
			result.M33 = num2;
			result.M34 = 1f;
			result.M43 = -num2 * znear;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00010508 File Offset: 0x0000E708
		public static Matrix PerspectiveFovLH(float fov, float aspect, float znear, float zfar)
		{
			Matrix result;
			Matrix.PerspectiveFovLH(fov, aspect, znear, zfar, out result);
			return result;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00010524 File Offset: 0x0000E724
		public static void PerspectiveFovRH(float fov, float aspect, float znear, float zfar, out Matrix result)
		{
			float num = (float)(1.0 / Math.Tan((double)(fov * 0.5f)));
			float num2 = zfar / (znear - zfar);
			result = default(Matrix);
			result.M11 = num / aspect;
			result.M22 = num;
			result.M33 = num2;
			result.M34 = -1f;
			result.M43 = num2 * znear;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00010588 File Offset: 0x0000E788
		public static Matrix PerspectiveFovRH(float fov, float aspect, float znear, float zfar)
		{
			Matrix result;
			Matrix.PerspectiveFovRH(fov, aspect, znear, zfar, out result);
			return result;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x000105A4 File Offset: 0x0000E7A4
		public static void PerspectiveOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
		{
			float num = zfar / (zfar - znear);
			result = default(Matrix);
			result.M11 = 2f * znear / (right - left);
			result.M22 = 2f * znear / (top - bottom);
			result.M31 = (left + right) / (left - right);
			result.M32 = (top + bottom) / (bottom - top);
			result.M33 = num;
			result.M34 = 1f;
			result.M43 = -znear * num;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00010624 File Offset: 0x0000E824
		public static Matrix PerspectiveOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar)
		{
			Matrix result;
			Matrix.PerspectiveOffCenterLH(left, right, bottom, top, znear, zfar, out result);
			return result;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00010644 File Offset: 0x0000E844
		public static void PerspectiveOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
		{
			Matrix.PerspectiveOffCenterLH(left, right, bottom, top, znear, zfar, out result);
			result.M31 *= -1f;
			result.M32 *= -1f;
			result.M33 *= -1f;
			result.M34 *= -1f;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000106A0 File Offset: 0x0000E8A0
		public static Matrix PerspectiveOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar)
		{
			Matrix result;
			Matrix.PerspectiveOffCenterRH(left, right, bottom, top, znear, zfar, out result);
			return result;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x000106BD File Offset: 0x0000E8BD
		public static void Scaling(ref Vector3 scale, out Matrix result)
		{
			Matrix.Scaling(scale.X, scale.Y, scale.Z, out result);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x000106D8 File Offset: 0x0000E8D8
		public static Matrix Scaling(Vector3 scale)
		{
			Matrix result;
			Matrix.Scaling(ref scale, out result);
			return result;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000106EF File Offset: 0x0000E8EF
		public static void Scaling(float x, float y, float z, out Matrix result)
		{
			result = Matrix.Identity;
			result.M11 = x;
			result.M22 = y;
			result.M33 = z;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00010714 File Offset: 0x0000E914
		public static Matrix Scaling(float x, float y, float z)
		{
			Matrix result;
			Matrix.Scaling(x, y, z, out result);
			return result;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0001072C File Offset: 0x0000E92C
		public static void Scaling(float scale, out Matrix result)
		{
			result = Matrix.Identity;
			result.M33 = scale;
			result.M22 = scale;
			result.M11 = scale;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00010760 File Offset: 0x0000E960
		public static Matrix Scaling(float scale)
		{
			Matrix result;
			Matrix.Scaling(scale, out result);
			return result;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00010778 File Offset: 0x0000E978
		public static void RotationX(float angle, out Matrix result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix.Identity;
			result.M22 = num;
			result.M23 = num2;
			result.M32 = -num2;
			result.M33 = num;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x000107C0 File Offset: 0x0000E9C0
		public static Matrix RotationX(float angle)
		{
			Matrix result;
			Matrix.RotationX(angle, out result);
			return result;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x000107D8 File Offset: 0x0000E9D8
		public static void RotationY(float angle, out Matrix result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix.Identity;
			result.M11 = num;
			result.M13 = -num2;
			result.M31 = num2;
			result.M33 = num;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00010820 File Offset: 0x0000EA20
		public static Matrix RotationY(float angle)
		{
			Matrix result;
			Matrix.RotationY(angle, out result);
			return result;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00010838 File Offset: 0x0000EA38
		public static void RotationZ(float angle, out Matrix result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix.Identity;
			result.M11 = num;
			result.M12 = num2;
			result.M21 = -num2;
			result.M22 = num;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00010880 File Offset: 0x0000EA80
		public static Matrix RotationZ(float angle)
		{
			Matrix result;
			Matrix.RotationZ(angle, out result);
			return result;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00010898 File Offset: 0x0000EA98
		public static void RotationAxis(ref Vector3 axis, float angle, out Matrix result)
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
			result = Matrix.Identity;
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

		// Token: 0x0600036A RID: 874 RVA: 0x0001099C File Offset: 0x0000EB9C
		public static Matrix RotationAxis(Vector3 axis, float angle)
		{
			Matrix result;
			Matrix.RotationAxis(ref axis, angle, out result);
			return result;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000109B4 File Offset: 0x0000EBB4
		public static void RotationQuaternion(ref Quaternion rotation, out Matrix result)
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
			result = Matrix.Identity;
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

		// Token: 0x0600036C RID: 876 RVA: 0x00010AF4 File Offset: 0x0000ECF4
		public static Matrix RotationQuaternion(Quaternion rotation)
		{
			Matrix result;
			Matrix.RotationQuaternion(ref rotation, out result);
			return result;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00010B0C File Offset: 0x0000ED0C
		public static void RotationYawPitchRoll(float yaw, float pitch, float roll, out Matrix result)
		{
			Quaternion quaternion = default(Quaternion);
			Quaternion.RotationYawPitchRoll(yaw, pitch, roll, out quaternion);
			Matrix.RotationQuaternion(ref quaternion, out result);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00010B34 File Offset: 0x0000ED34
		public static Matrix RotationYawPitchRoll(float yaw, float pitch, float roll)
		{
			Matrix result;
			Matrix.RotationYawPitchRoll(yaw, pitch, roll, out result);
			return result;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00010B4C File Offset: 0x0000ED4C
		public static void Translation(ref Vector3 value, out Matrix result)
		{
			Matrix.Translation(value.X, value.Y, value.Z, out result);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00010B68 File Offset: 0x0000ED68
		public static Matrix Translation(Vector3 value)
		{
			Matrix result;
			Matrix.Translation(ref value, out result);
			return result;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00010B7F File Offset: 0x0000ED7F
		public static void Translation(float x, float y, float z, out Matrix result)
		{
			result = Matrix.Identity;
			result.M41 = x;
			result.M42 = y;
			result.M43 = z;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00010BA4 File Offset: 0x0000EDA4
		public static Matrix Translation(float x, float y, float z)
		{
			Matrix result;
			Matrix.Translation(x, y, z, out result);
			return result;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00010BBC File Offset: 0x0000EDBC
		public static void Skew(float angle, ref Vector3 rotationVec, ref Vector3 transVec, out Matrix matrix)
		{
			float num = 1E-06f;
			Vector3 left = rotationVec;
			Vector3 value = Vector3.Normalize(transVec);
			float num2;
			Vector3.Dot(ref rotationVec, ref value, out num2);
			left += num2 * value;
			float num3;
			Vector3.Dot(ref rotationVec, ref left, out num3);
			float num4 = (float)Math.Cos((double)angle);
			float num5 = (float)Math.Sin((double)angle);
			float num6 = num3 * num4 - num2 * num5;
			float num7 = num3 * num5 + num2 * num4;
			if (num6 < num)
			{
				throw new ArgumentException("illegal skew angle");
			}
			float num8 = num7 / num6 - num2 / num3;
			matrix = Matrix.Identity;
			matrix.M11 = num8 * value[0] * left[0] + 1f;
			matrix.M12 = num8 * value[0] * left[1];
			matrix.M13 = num8 * value[0] * left[2];
			matrix.M21 = num8 * value[1] * left[0];
			matrix.M22 = num8 * value[1] * left[1] + 1f;
			matrix.M23 = num8 * value[1] * left[2];
			matrix.M31 = num8 * value[2] * left[0];
			matrix.M32 = num8 * value[2] * left[1];
			matrix.M33 = num8 * value[2] * left[2] + 1f;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00010D4F File Offset: 0x0000EF4F
		public static void AffineTransformation(float scaling, ref Quaternion rotation, ref Vector3 translation, out Matrix result)
		{
			result = Matrix.Scaling(scaling) * Matrix.RotationQuaternion(rotation) * Matrix.Translation(translation);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00010D80 File Offset: 0x0000EF80
		public static Matrix AffineTransformation(float scaling, Quaternion rotation, Vector3 translation)
		{
			Matrix result;
			Matrix.AffineTransformation(scaling, ref rotation, ref translation, out result);
			return result;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00010D9C File Offset: 0x0000EF9C
		public static void AffineTransformation(float scaling, ref Vector3 rotationCenter, ref Quaternion rotation, ref Vector3 translation, out Matrix result)
		{
			result = Matrix.Scaling(scaling) * Matrix.Translation(-rotationCenter) * Matrix.RotationQuaternion(rotation) * Matrix.Translation(rotationCenter) * Matrix.Translation(translation);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00010DFC File Offset: 0x0000EFFC
		public static Matrix AffineTransformation(float scaling, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
		{
			Matrix result;
			Matrix.AffineTransformation(scaling, ref rotationCenter, ref rotation, ref translation, out result);
			return result;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00010E18 File Offset: 0x0000F018
		public static void AffineTransformation2D(float scaling, float rotation, ref Vector2 translation, out Matrix result)
		{
			result = Matrix.Scaling(scaling, scaling, 1f) * Matrix.RotationZ(rotation) * Matrix.Translation((Vector3)translation);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00010E4C File Offset: 0x0000F04C
		public static Matrix AffineTransformation2D(float scaling, float rotation, Vector2 translation)
		{
			Matrix result;
			Matrix.AffineTransformation2D(scaling, rotation, ref translation, out result);
			return result;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00010E68 File Offset: 0x0000F068
		public static void AffineTransformation2D(float scaling, ref Vector2 rotationCenter, float rotation, ref Vector2 translation, out Matrix result)
		{
			result = Matrix.Scaling(scaling, scaling, 1f) * Matrix.Translation((Vector3)(-rotationCenter)) * Matrix.RotationZ(rotation) * Matrix.Translation((Vector3)rotationCenter) * Matrix.Translation((Vector3)translation);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00010ED8 File Offset: 0x0000F0D8
		public static Matrix AffineTransformation2D(float scaling, Vector2 rotationCenter, float rotation, Vector2 translation)
		{
			Matrix result;
			Matrix.AffineTransformation2D(scaling, ref rotationCenter, rotation, ref translation, out result);
			return result;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00010EF4 File Offset: 0x0000F0F4
		public static void Transformation(ref Vector3 scalingCenter, ref Quaternion scalingRotation, ref Vector3 scaling, ref Vector3 rotationCenter, ref Quaternion rotation, ref Vector3 translation, out Matrix result)
		{
			Matrix matrix = Matrix.RotationQuaternion(scalingRotation);
			result = Matrix.Translation(-scalingCenter) * Matrix.Transpose(matrix) * Matrix.Scaling(scaling) * matrix * Matrix.Translation(scalingCenter) * Matrix.Translation(-rotationCenter) * Matrix.RotationQuaternion(rotation) * Matrix.Translation(rotationCenter) * Matrix.Translation(translation);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00010F9C File Offset: 0x0000F19C
		public static Matrix Transformation(Vector3 scalingCenter, Quaternion scalingRotation, Vector3 scaling, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
		{
			Matrix result;
			Matrix.Transformation(ref scalingCenter, ref scalingRotation, ref scaling, ref rotationCenter, ref rotation, ref translation, out result);
			return result;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00010FC0 File Offset: 0x0000F1C0
		public static void Transformation2D(ref Vector2 scalingCenter, float scalingRotation, ref Vector2 scaling, ref Vector2 rotationCenter, float rotation, ref Vector2 translation, out Matrix result)
		{
			result = Matrix.Translation((Vector3)(-scalingCenter)) * Matrix.RotationZ(-scalingRotation) * Matrix.Scaling((Vector3)scaling) * Matrix.RotationZ(scalingRotation) * Matrix.Translation((Vector3)scalingCenter) * Matrix.Translation((Vector3)(-rotationCenter)) * Matrix.RotationZ(rotation) * Matrix.Translation((Vector3)rotationCenter) * Matrix.Translation((Vector3)translation);
			result.M33 = 1f;
			result.M44 = 1f;
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00011094 File Offset: 0x0000F294
		public static Matrix Transformation2D(Vector2 scalingCenter, float scalingRotation, Vector2 scaling, Vector2 rotationCenter, float rotation, Vector2 translation)
		{
			Matrix result;
			Matrix.Transformation2D(ref scalingCenter, scalingRotation, ref scaling, ref rotationCenter, rotation, ref translation, out result);
			return result;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000110B4 File Offset: 0x0000F2B4
		public static Matrix operator +(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00002505 File Offset: 0x00000705
		public static Matrix operator +(Matrix value)
		{
			return value;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x000110D0 File Offset: 0x0000F2D0
		public static Matrix operator -(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x000110EC File Offset: 0x0000F2EC
		public static Matrix operator -(Matrix value)
		{
			Matrix result;
			Matrix.Negate(ref value, out result);
			return result;
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00011104 File Offset: 0x0000F304
		public static Matrix operator *(float left, Matrix right)
		{
			Matrix result;
			Matrix.Multiply(ref right, left, out result);
			return result;
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0001111C File Offset: 0x0000F31C
		public static Matrix operator *(Matrix left, float right)
		{
			Matrix result;
			Matrix.Multiply(ref left, right, out result);
			return result;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00011134 File Offset: 0x0000F334
		public static Matrix operator *(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00011150 File Offset: 0x0000F350
		public static Matrix operator /(Matrix left, float right)
		{
			Matrix result;
			Matrix.Divide(ref left, right, out result);
			return result;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00011168 File Offset: 0x0000F368
		public static Matrix operator /(Matrix left, Matrix right)
		{
			Matrix result;
			Matrix.Divide(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00011181 File Offset: 0x0000F381
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Matrix left, Matrix right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0001118C File Offset: 0x0000F38C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Matrix left, Matrix right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0001119C File Offset: 0x0000F39C
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]", new object[]
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
				this.M44
			});
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000112A8 File Offset: 0x0000F4A8
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(format, new object[]
			{
				CultureInfo.CurrentCulture,
				"[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]",
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
				this.M44.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0001142C File Offset: 0x0000F62C
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]", new object[]
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
				this.M44.ToString(formatProvider)
			});
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00011544 File Offset: 0x0000F744
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]", new object[]
			{
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
				this.M44.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00011678 File Offset: 0x0000F878
		public override int GetHashCode()
		{
			return ((((((((((((((this.M11.GetHashCode() * 397 ^ this.M12.GetHashCode()) * 397 ^ this.M13.GetHashCode()) * 397 ^ this.M14.GetHashCode()) * 397 ^ this.M21.GetHashCode()) * 397 ^ this.M22.GetHashCode()) * 397 ^ this.M23.GetHashCode()) * 397 ^ this.M24.GetHashCode()) * 397 ^ this.M31.GetHashCode()) * 397 ^ this.M32.GetHashCode()) * 397 ^ this.M33.GetHashCode()) * 397 ^ this.M34.GetHashCode()) * 397 ^ this.M41.GetHashCode()) * 397 ^ this.M42.GetHashCode()) * 397 ^ this.M43.GetHashCode()) * 397 ^ this.M44.GetHashCode();
		}

		// Token: 0x06000390 RID: 912 RVA: 0x000117A0 File Offset: 0x0000F9A0
		public bool Equals(ref Matrix other)
		{
			return MathUtil.NearEqual(other.M11, this.M11) && MathUtil.NearEqual(other.M12, this.M12) && MathUtil.NearEqual(other.M13, this.M13) && MathUtil.NearEqual(other.M14, this.M14) && MathUtil.NearEqual(other.M21, this.M21) && MathUtil.NearEqual(other.M22, this.M22) && MathUtil.NearEqual(other.M23, this.M23) && MathUtil.NearEqual(other.M24, this.M24) && MathUtil.NearEqual(other.M31, this.M31) && MathUtil.NearEqual(other.M32, this.M32) && MathUtil.NearEqual(other.M33, this.M33) && MathUtil.NearEqual(other.M34, this.M34) && MathUtil.NearEqual(other.M41, this.M41) && MathUtil.NearEqual(other.M42, this.M42) && MathUtil.NearEqual(other.M43, this.M43) && MathUtil.NearEqual(other.M44, this.M44);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x000118F8 File Offset: 0x0000FAF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Matrix other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00011904 File Offset: 0x0000FB04
		public override bool Equals(object value)
		{
			if (!(value is Matrix))
			{
				return false;
			}
			Matrix matrix = (Matrix)value;
			return this.Equals(ref matrix);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0001192A File Offset: 0x0000FB2A
		public unsafe static implicit operator RawMatrix(Matrix value)
		{
			return *(RawMatrix*)(&value);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00011934 File Offset: 0x0000FB34
		public unsafe static implicit operator Matrix(RawMatrix value)
		{
			return *(Matrix*)(&value);
		}

		// Token: 0x0400010D RID: 269
		public static readonly int SizeInBytes = 64;

		// Token: 0x0400010E RID: 270
		public static readonly Matrix Zero = default(Matrix);

		// Token: 0x0400010F RID: 271
		public static readonly Matrix Identity = new Matrix
		{
			M11 = 1f,
			M22 = 1f,
			M33 = 1f,
			M44 = 1f
		};

		// Token: 0x04000110 RID: 272
		public float M11;

		// Token: 0x04000111 RID: 273
		public float M12;

		// Token: 0x04000112 RID: 274
		public float M13;

		// Token: 0x04000113 RID: 275
		public float M14;

		// Token: 0x04000114 RID: 276
		public float M21;

		// Token: 0x04000115 RID: 277
		public float M22;

		// Token: 0x04000116 RID: 278
		public float M23;

		// Token: 0x04000117 RID: 279
		public float M24;

		// Token: 0x04000118 RID: 280
		public float M31;

		// Token: 0x04000119 RID: 281
		public float M32;

		// Token: 0x0400011A RID: 282
		public float M33;

		// Token: 0x0400011B RID: 283
		public float M34;

		// Token: 0x0400011C RID: 284
		public float M41;

		// Token: 0x0400011D RID: 285
		public float M42;

		// Token: 0x0400011E RID: 286
		public float M43;

		// Token: 0x0400011F RID: 287
		public float M44;
	}
}

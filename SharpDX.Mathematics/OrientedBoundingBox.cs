using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200001D RID: 29
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct OrientedBoundingBox : IEquatable<OrientedBoundingBox>, IFormattable
	{
		// Token: 0x060004A2 RID: 1186 RVA: 0x00017370 File Offset: 0x00015570
		public OrientedBoundingBox(BoundingBox bb)
		{
			Vector3 vector = bb.Minimum + (bb.Maximum - bb.Minimum) / 2f;
			this.Extents = bb.Maximum - vector;
			this.Transformation = Matrix.Translation(vector);
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x000173C4 File Offset: 0x000155C4
		public OrientedBoundingBox(Vector3 minimum, Vector3 maximum)
		{
			Vector3 vector = minimum + (maximum - minimum) / 2f;
			this.Extents = maximum - vector;
			this.Transformation = Matrix.Translation(vector);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00017404 File Offset: 0x00015604
		public OrientedBoundingBox(Vector3[] points)
		{
			if (points == null || points.Length == 0)
			{
				throw new ArgumentNullException("points");
			}
			Vector3 vector = new Vector3(float.MaxValue);
			Vector3 left = new Vector3(float.MinValue);
			for (int i = 0; i < points.Length; i++)
			{
				Vector3.Min(ref vector, ref points[i], out vector);
				Vector3.Max(ref left, ref points[i], out left);
			}
			Vector3 vector2 = vector + (left - vector) / 2f;
			this.Extents = left - vector2;
			this.Transformation = Matrix.Translation(vector2);
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0001749C File Offset: 0x0001569C
		public Vector3[] GetCorners()
		{
			Vector3 right = new Vector3(this.Extents.X, 0f, 0f);
			Vector3 right2 = new Vector3(0f, this.Extents.Y, 0f);
			Vector3 right3 = new Vector3(0f, 0f, this.Extents.Z);
			Vector3.TransformNormal(ref right, ref this.Transformation, out right);
			Vector3.TransformNormal(ref right2, ref this.Transformation, out right2);
			Vector3.TransformNormal(ref right3, ref this.Transformation, out right3);
			Vector3 translationVector = this.Transformation.TranslationVector;
			return new Vector3[]
			{
				translationVector + right + right2 + right3,
				translationVector + right + right2 - right3,
				translationVector - right + right2 - right3,
				translationVector - right + right2 + right3,
				translationVector + right - right2 + right3,
				translationVector + right - right2 - right3,
				translationVector - right - right2 - right3,
				translationVector - right - right2 + right3
			};
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0001760C File Offset: 0x0001580C
		public void Transform(ref Matrix mat)
		{
			this.Transformation *= mat;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00017625 File Offset: 0x00015825
		public void Transform(Matrix mat)
		{
			this.Transformation *= mat;
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00017639 File Offset: 0x00015839
		public void Scale(ref Vector3 scaling)
		{
			this.Extents *= scaling;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00017652 File Offset: 0x00015852
		public void Scale(Vector3 scaling)
		{
			this.Extents *= scaling;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00017666 File Offset: 0x00015866
		public void Scale(float scaling)
		{
			this.Extents *= scaling;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0001767A File Offset: 0x0001587A
		public void Translate(ref Vector3 translation)
		{
			this.Transformation.TranslationVector = this.Transformation.TranslationVector + translation;
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00017698 File Offset: 0x00015898
		public void Translate(Vector3 translation)
		{
			this.Transformation.TranslationVector = this.Transformation.TranslationVector + translation;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x000176B1 File Offset: 0x000158B1
		public Vector3 Size
		{
			get
			{
				return this.Extents * 2f;
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x000176C4 File Offset: 0x000158C4
		public Vector3 GetSize()
		{
			Vector3 vector = new Vector3(this.Extents.X * 2f, 0f, 0f);
			Vector3 vector2 = new Vector3(0f, this.Extents.Y * 2f, 0f);
			Vector3 vector3 = new Vector3(0f, 0f, this.Extents.Z * 2f);
			Vector3.TransformNormal(ref vector, ref this.Transformation, out vector);
			Vector3.TransformNormal(ref vector2, ref this.Transformation, out vector2);
			Vector3.TransformNormal(ref vector3, ref this.Transformation, out vector3);
			return new Vector3(vector.Length(), vector2.Length(), vector3.Length());
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00017780 File Offset: 0x00015980
		public Vector3 GetSizeSquared()
		{
			Vector3 vector = new Vector3(this.Extents.X * 2f, 0f, 0f);
			Vector3 vector2 = new Vector3(0f, this.Extents.Y * 2f, 0f);
			Vector3 vector3 = new Vector3(0f, 0f, this.Extents.Z * 2f);
			Vector3.TransformNormal(ref vector, ref this.Transformation, out vector);
			Vector3.TransformNormal(ref vector2, ref this.Transformation, out vector2);
			Vector3.TransformNormal(ref vector3, ref this.Transformation, out vector3);
			return new Vector3(vector.LengthSquared(), vector2.LengthSquared(), vector3.LengthSquared());
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x0001783A File Offset: 0x00015A3A
		public Vector3 Center
		{
			get
			{
				return this.Transformation.TranslationVector;
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00017848 File Offset: 0x00015A48
		public ContainmentType Contains(ref Vector3 point)
		{
			Matrix matrix;
			Matrix.Invert(ref this.Transformation, out matrix);
			Vector3 vector;
			Vector3.TransformCoordinate(ref point, ref matrix, out vector);
			vector.X = Math.Abs(vector.X);
			vector.Y = Math.Abs(vector.Y);
			vector.Z = Math.Abs(vector.Z);
			if (MathUtil.NearEqual(vector.X, this.Extents.X) && MathUtil.NearEqual(vector.Y, this.Extents.Y) && MathUtil.NearEqual(vector.Z, this.Extents.Z))
			{
				return ContainmentType.Intersects;
			}
			if (vector.X < this.Extents.X && vector.Y < this.Extents.Y && vector.Z < this.Extents.Z)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Disjoint;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00017928 File Offset: 0x00015B28
		public ContainmentType Contains(Vector3 point)
		{
			return this.Contains(ref point);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00017934 File Offset: 0x00015B34
		public ContainmentType Contains(Vector3[] points)
		{
			Matrix matrix;
			Matrix.Invert(ref this.Transformation, out matrix);
			bool flag = true;
			bool flag2 = false;
			for (int i = 0; i < points.Length; i++)
			{
				Vector3 vector;
				Vector3.TransformCoordinate(ref points[i], ref matrix, out vector);
				vector.X = Math.Abs(vector.X);
				vector.Y = Math.Abs(vector.Y);
				vector.Z = Math.Abs(vector.Z);
				if (MathUtil.NearEqual(vector.X, this.Extents.X) && MathUtil.NearEqual(vector.Y, this.Extents.Y) && MathUtil.NearEqual(vector.Z, this.Extents.Z))
				{
					flag2 = true;
				}
				if (vector.X < this.Extents.X && vector.Y < this.Extents.Y && vector.Z < this.Extents.Z)
				{
					flag2 = true;
				}
				else
				{
					flag = false;
				}
			}
			if (flag)
			{
				return ContainmentType.Contains;
			}
			if (flag2)
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Disjoint;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00017A4C File Offset: 0x00015C4C
		public ContainmentType Contains(BoundingSphere sphere, bool IgnoreScale = false)
		{
			Matrix matrix;
			Matrix.Invert(ref this.Transformation, out matrix);
			Vector3 vector;
			Vector3.TransformCoordinate(ref sphere.Center, ref matrix, out vector);
			float num;
			if (IgnoreScale)
			{
				num = sphere.Radius;
			}
			else
			{
				Vector3 vector2 = Vector3.UnitX * sphere.Radius;
				Vector3.TransformNormal(ref vector2, ref matrix, out vector2);
				num = vector2.Length();
			}
			Vector3 vector3 = -this.Extents;
			Vector3 value;
			Vector3.Clamp(ref vector, ref vector3, ref this.Extents, out value);
			if (Vector3.DistanceSquared(vector, value) > num * num)
			{
				return ContainmentType.Disjoint;
			}
			if (vector3.X + num <= vector.X && vector.X <= this.Extents.X - num && this.Extents.X - vector3.X > num && vector3.Y + num <= vector.Y && vector.Y <= this.Extents.Y - num && this.Extents.Y - vector3.Y > num && vector3.Z + num <= vector.Z && vector.Z <= this.Extents.Z - num && this.Extents.Z - vector3.Z > num)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Intersects;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00017B8C File Offset: 0x00015D8C
		private static Vector3[] GetRows(ref Matrix mat)
		{
			return new Vector3[]
			{
				new Vector3(mat.M11, mat.M12, mat.M13),
				new Vector3(mat.M21, mat.M22, mat.M23),
				new Vector3(mat.M31, mat.M32, mat.M33)
			};
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00017BFC File Offset: 0x00015DFC
		public ContainmentType Contains(ref OrientedBoundingBox obb)
		{
			ContainmentType containmentType = this.Contains(obb.GetCorners());
			if (containmentType != ContainmentType.Disjoint)
			{
				return containmentType;
			}
			Vector3 extents = this.Extents;
			Vector3 extents2 = obb.Extents;
			Vector3[] rows = OrientedBoundingBox.GetRows(ref this.Transformation);
			Vector3[] rows2 = OrientedBoundingBox.GetRows(ref obb.Transformation);
			Matrix matrix = default(Matrix);
			Matrix matrix2 = default(Matrix);
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix[i, j] = Vector3.Dot(rows[i], rows2[j]);
					matrix2[i, j] = Math.Abs(matrix[i, j]);
				}
			}
			Vector3 left = obb.Center - this.Center;
			Vector3 left2 = new Vector3(Vector3.Dot(left, rows[0]), Vector3.Dot(left, rows[1]), Vector3.Dot(left, rows[2]));
			for (int i = 0; i < 3; i++)
			{
				float num = extents[i];
				float num2 = Vector3.Dot(extents2, new Vector3(matrix2[i, 0], matrix2[i, 1], matrix2[i, 2]));
				if (Math.Abs(left2[i]) > num + num2)
				{
					return ContainmentType.Disjoint;
				}
			}
			for (int j = 0; j < 3; j++)
			{
				float num = Vector3.Dot(extents, new Vector3(matrix2[0, j], matrix2[1, j], matrix2[2, j]));
				float num2 = extents2[j];
				if (Math.Abs(Vector3.Dot(left2, new Vector3(matrix[0, j], matrix[1, j], matrix[2, j]))) > num + num2)
				{
					return ContainmentType.Disjoint;
				}
			}
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					int num3 = (i + 1) % 3;
					int num4 = (i + 2) % 3;
					int num5 = (j + 1) % 3;
					int num6 = (j + 2) % 3;
					float num = extents[num3] * matrix2[num4, j] + extents[num4] * matrix2[num3, j];
					float num2 = extents2[num5] * matrix2[i, num6] + extents2[num6] * matrix2[i, num5];
					if (Math.Abs(left2[num4] * matrix[num3, j] - left2[num3] * matrix[num4, j]) > num + num2)
					{
						return ContainmentType.Disjoint;
					}
				}
			}
			return ContainmentType.Intersects;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00017EB0 File Offset: 0x000160B0
		public ContainmentType ContainsLine(ref Vector3 L1, ref Vector3 L2)
		{
			ContainmentType containmentType = this.Contains(new Vector3[]
			{
				L1,
				L2
			});
			if (containmentType != ContainmentType.Disjoint)
			{
				return containmentType;
			}
			Matrix matrix;
			Matrix.Invert(ref this.Transformation, out matrix);
			Vector3 left;
			Vector3.TransformCoordinate(ref L1, ref matrix, out left);
			Vector3 right;
			Vector3.TransformCoordinate(ref L1, ref matrix, out right);
			Vector3 vector = (left + right) * 0.5f;
			Vector3 vector2 = left - vector;
			Vector3 vector3 = new Vector3(Math.Abs(vector2.X), Math.Abs(vector2.Y), Math.Abs(vector2.Z));
			if (Math.Abs(vector.X) > this.Extents.X + vector3.X)
			{
				return ContainmentType.Disjoint;
			}
			if (Math.Abs(vector.Y) > this.Extents.Y + vector3.Y)
			{
				return ContainmentType.Disjoint;
			}
			if (Math.Abs(vector.Z) > this.Extents.Z + vector3.Z)
			{
				return ContainmentType.Disjoint;
			}
			if (Math.Abs(vector.Y * vector2.Z - vector.Z * vector2.Y) > this.Extents.Y * vector3.Z + this.Extents.Z * vector3.Y)
			{
				return ContainmentType.Disjoint;
			}
			if (Math.Abs(vector.X * vector2.Z - vector.Z * vector2.X) > this.Extents.X * vector3.Z + this.Extents.Z * vector3.X)
			{
				return ContainmentType.Disjoint;
			}
			if (Math.Abs(vector.X * vector2.Y - vector.Y * vector2.X) > this.Extents.X * vector3.Y + this.Extents.Y * vector3.X)
			{
				return ContainmentType.Disjoint;
			}
			return ContainmentType.Intersects;
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x000180AC File Offset: 0x000162AC
		public ContainmentType Contains(ref BoundingBox box)
		{
			ContainmentType containmentType = this.Contains(box.GetCorners());
			if (containmentType != ContainmentType.Disjoint)
			{
				return containmentType;
			}
			Vector3 vector = box.Minimum + (box.Maximum - box.Minimum) / 2f;
			Vector3 vector2 = box.Maximum - vector;
			Vector3 extents = this.Extents;
			Vector3 left = vector2;
			Vector3[] rows = OrientedBoundingBox.GetRows(ref this.Transformation);
			Matrix matrix;
			Matrix.Invert(ref this.Transformation, out matrix);
			Matrix matrix2 = default(Matrix);
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix2[i, j] = Math.Abs(matrix[i, j]);
				}
			}
			Vector3 left2 = vector - this.Center;
			Vector3 left3 = new Vector3(Vector3.Dot(left2, rows[0]), Vector3.Dot(left2, rows[1]), Vector3.Dot(left2, rows[2]));
			for (int i = 0; i < 3; i++)
			{
				float num = extents[i];
				float num2 = Vector3.Dot(left, new Vector3(matrix2[i, 0], matrix2[i, 1], matrix2[i, 2]));
				if (Math.Abs(left3[i]) > num + num2)
				{
					return ContainmentType.Disjoint;
				}
			}
			for (int j = 0; j < 3; j++)
			{
				float num = Vector3.Dot(extents, new Vector3(matrix2[0, j], matrix2[1, j], matrix2[2, j]));
				float num2 = left[j];
				if (Math.Abs(Vector3.Dot(left3, new Vector3(matrix[0, j], matrix[1, j], matrix[2, j]))) > num + num2)
				{
					return ContainmentType.Disjoint;
				}
			}
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					int num3 = (i + 1) % 3;
					int num4 = (i + 2) % 3;
					int num5 = (j + 1) % 3;
					int num6 = (j + 2) % 3;
					float num = extents[num3] * matrix2[num4, j] + extents[num4] * matrix2[num3, j];
					float num2 = left[num5] * matrix2[i, num6] + left[num6] * matrix2[i, num5];
					if (Math.Abs(left3[num4] * matrix[num3, j] - left3[num3] * matrix[num4, j]) > num + num2)
					{
						return ContainmentType.Disjoint;
					}
				}
			}
			return ContainmentType.Intersects;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00018360 File Offset: 0x00016560
		public bool Intersects(ref Ray ray, out Vector3 point)
		{
			Matrix matrix;
			Matrix.Invert(ref this.Transformation, out matrix);
			Ray ray2;
			Vector3.TransformNormal(ref ray.Direction, ref matrix, out ray2.Direction);
			Vector3.TransformCoordinate(ref ray.Position, ref matrix, out ray2.Position);
			BoundingBox boundingBox = new BoundingBox(-this.Extents, this.Extents);
			bool flag = Collision.RayIntersectsBox(ref ray2, ref boundingBox, out point);
			if (flag)
			{
				Vector3.TransformCoordinate(ref point, ref this.Transformation, out point);
			}
			return flag;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x000183D4 File Offset: 0x000165D4
		public bool Intersects(ref Ray ray)
		{
			Vector3 vector;
			return this.Intersects(ref ray, out vector);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x000183EC File Offset: 0x000165EC
		private Vector3[] GetLocalCorners()
		{
			Vector3 value = new Vector3(this.Extents.X, 0f, 0f);
			Vector3 right = new Vector3(0f, this.Extents.Y, 0f);
			Vector3 right2 = new Vector3(0f, 0f, this.Extents.Z);
			return new Vector3[]
			{
				+value + right + right2,
				+value + right - right2,
				-value + right - right2,
				-value + right + right2,
				+value - right + right2,
				+value - right - right2,
				-value - right - right2,
				-value - right + right2
			};
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0001851B File Offset: 0x0001671B
		public BoundingBox GetBoundingBox()
		{
			return BoundingBox.FromPoints(this.GetCorners());
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00018528 File Offset: 0x00016728
		public static Matrix GetBoxToBoxMatrix(ref OrientedBoundingBox A, ref OrientedBoundingBox B, bool NoMatrixScaleApplied = false)
		{
			Matrix result;
			if (NoMatrixScaleApplied)
			{
				Vector3[] rows = OrientedBoundingBox.GetRows(ref A.Transformation);
				Vector3[] rows2 = OrientedBoundingBox.GetRows(ref B.Transformation);
				result = default(Matrix);
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						result[i, j] = Vector3.Dot(rows2[i], rows[j]);
					}
				}
				Vector3 left = B.Center - A.Center;
				result.M41 = Vector3.Dot(left, rows[0]);
				result.M42 = Vector3.Dot(left, rows[1]);
				result.M43 = Vector3.Dot(left, rows[2]);
				result.M44 = 1f;
			}
			else
			{
				Matrix right;
				Matrix.Invert(ref A.Transformation, out right);
				result = B.Transformation * right;
			}
			return result;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00018614 File Offset: 0x00016814
		public static void Merge(ref OrientedBoundingBox A, ref OrientedBoundingBox B, bool NoMatrixScaleApplied = false)
		{
			Matrix boxToBoxMatrix = OrientedBoundingBox.GetBoxToBoxMatrix(ref A, ref B, NoMatrixScaleApplied);
			Vector3[] localCorners = B.GetLocalCorners();
			Vector3.TransformCoordinate(localCorners, ref boxToBoxMatrix, localCorners);
			BoundingBox boundingBox = new BoundingBox(-A.Extents, A.Extents);
			BoundingBox boundingBox2 = BoundingBox.FromPoints(localCorners);
			BoundingBox boundingBox3;
			BoundingBox.Merge(ref boundingBox2, ref boundingBox, out boundingBox3);
			Vector3 vector = boundingBox3.Minimum + (boundingBox3.Maximum - boundingBox3.Minimum) / 2f;
			A.Extents = boundingBox3.Maximum - vector;
			Vector3.TransformCoordinate(ref vector, ref A.Transformation, out vector);
			A.Transformation.TranslationVector = vector;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x000186BF File Offset: 0x000168BF
		public void MergeInto(ref OrientedBoundingBox OBB, bool NoMatrixScaleApplied = false)
		{
			OrientedBoundingBox.Merge(ref OBB, ref this, NoMatrixScaleApplied);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x000186C9 File Offset: 0x000168C9
		public void Add(ref OrientedBoundingBox OBB, bool NoMatrixScaleApplied = false)
		{
			OrientedBoundingBox.Merge(ref this, ref OBB, NoMatrixScaleApplied);
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x000186D3 File Offset: 0x000168D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref OrientedBoundingBox value)
		{
			return this.Extents == value.Extents && this.Transformation == value.Transformation;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x000186FB File Offset: 0x000168FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(OrientedBoundingBox value)
		{
			return this.Equals(ref value);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00018708 File Offset: 0x00016908
		public override bool Equals(object value)
		{
			if (!(value is OrientedBoundingBox))
			{
				return false;
			}
			OrientedBoundingBox orientedBoundingBox = (OrientedBoundingBox)value;
			return this.Equals(ref orientedBoundingBox);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0001872E File Offset: 0x0001692E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(OrientedBoundingBox left, OrientedBoundingBox right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00018739 File Offset: 0x00016939
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(OrientedBoundingBox left, OrientedBoundingBox right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00018747 File Offset: 0x00016947
		public override int GetHashCode()
		{
			return this.Extents.GetHashCode() + this.Transformation.GetHashCode();
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0001876C File Offset: 0x0001696C
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "Center: {0}, Extents: {1}", new object[]
			{
				this.Center,
				this.Extents
			});
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x000187A0 File Offset: 0x000169A0
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "Center: {0}, Extents: {1}", new object[]
			{
				this.Center.ToString(format, CultureInfo.CurrentCulture),
				this.Extents.ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00018800 File Offset: 0x00016A00
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "Center: {0}, Extents: {1}", new object[]
			{
				this.Center.ToString(),
				this.Extents.ToString()
			});
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0001884C File Offset: 0x00016A4C
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "Center: {0}, Extents: {1}", new object[]
			{
				this.Center.ToString(format, formatProvider),
				this.Extents.ToString(format, formatProvider)
			});
		}

		// Token: 0x0400014A RID: 330
		public Vector3 Extents;

		// Token: 0x0400014B RID: 331
		public Matrix Transformation;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000005 RID: 5
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct BoundingFrustum : IEquatable<BoundingFrustum>
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600007E RID: 126 RVA: 0x0000319A File Offset: 0x0000139A
		// (set) Token: 0x0600007F RID: 127 RVA: 0x000031A2 File Offset: 0x000013A2
		public Matrix Matrix
		{
			get
			{
				return this.pMatrix;
			}
			set
			{
				this.pMatrix = value;
				BoundingFrustum.GetPlanesFromMatrix(ref this.pMatrix, out this.pNear, out this.pFar, out this.pLeft, out this.pRight, out this.pTop, out this.pBottom);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000080 RID: 128 RVA: 0x000031DA File Offset: 0x000013DA
		public Plane Near
		{
			get
			{
				return this.pNear;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000031E2 File Offset: 0x000013E2
		public Plane Far
		{
			get
			{
				return this.pFar;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000031EA File Offset: 0x000013EA
		public Plane Left
		{
			get
			{
				return this.pLeft;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000031F2 File Offset: 0x000013F2
		public Plane Right
		{
			get
			{
				return this.pRight;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000084 RID: 132 RVA: 0x000031FA File Offset: 0x000013FA
		public Plane Top
		{
			get
			{
				return this.pTop;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00003202 File Offset: 0x00001402
		public Plane Bottom
		{
			get
			{
				return this.pBottom;
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000031A2 File Offset: 0x000013A2
		public BoundingFrustum(Matrix matrix)
		{
			this.pMatrix = matrix;
			BoundingFrustum.GetPlanesFromMatrix(ref this.pMatrix, out this.pNear, out this.pFar, out this.pLeft, out this.pRight, out this.pTop, out this.pBottom);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000320A File Offset: 0x0000140A
		public override int GetHashCode()
		{
			return this.pMatrix.GetHashCode();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000321D File Offset: 0x0000141D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref BoundingFrustum other)
		{
			return this.pMatrix == other.pMatrix;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003230 File Offset: 0x00001430
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BoundingFrustum other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000323C File Offset: 0x0000143C
		public override bool Equals(object obj)
		{
			if (!(obj is BoundingFrustum))
			{
				return false;
			}
			BoundingFrustum boundingFrustum = (BoundingFrustum)obj;
			return this.Equals(ref boundingFrustum);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003262 File Offset: 0x00001462
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(BoundingFrustum left, BoundingFrustum right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000326D File Offset: 0x0000146D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(BoundingFrustum left, BoundingFrustum right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000327C File Offset: 0x0000147C
		public Plane GetPlane(int index)
		{
			switch (index)
			{
			case 0:
				return this.pLeft;
			case 1:
				return this.pRight;
			case 2:
				return this.pTop;
			case 3:
				return this.pBottom;
			case 4:
				return this.pNear;
			case 5:
				return this.pFar;
			default:
				return default(Plane);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000032DC File Offset: 0x000014DC
		private static void GetPlanesFromMatrix(ref Matrix matrix, out Plane near, out Plane far, out Plane left, out Plane right, out Plane top, out Plane bottom)
		{
			left.Normal.X = matrix.M14 + matrix.M11;
			left.Normal.Y = matrix.M24 + matrix.M21;
			left.Normal.Z = matrix.M34 + matrix.M31;
			left.D = matrix.M44 + matrix.M41;
			left.Normalize();
			right.Normal.X = matrix.M14 - matrix.M11;
			right.Normal.Y = matrix.M24 - matrix.M21;
			right.Normal.Z = matrix.M34 - matrix.M31;
			right.D = matrix.M44 - matrix.M41;
			right.Normalize();
			top.Normal.X = matrix.M14 - matrix.M12;
			top.Normal.Y = matrix.M24 - matrix.M22;
			top.Normal.Z = matrix.M34 - matrix.M32;
			top.D = matrix.M44 - matrix.M42;
			top.Normalize();
			bottom.Normal.X = matrix.M14 + matrix.M12;
			bottom.Normal.Y = matrix.M24 + matrix.M22;
			bottom.Normal.Z = matrix.M34 + matrix.M32;
			bottom.D = matrix.M44 + matrix.M42;
			bottom.Normalize();
			near.Normal.X = matrix.M13;
			near.Normal.Y = matrix.M23;
			near.Normal.Z = matrix.M33;
			near.D = matrix.M43;
			near.Normalize();
			far.Normal.X = matrix.M14 - matrix.M13;
			far.Normal.Y = matrix.M24 - matrix.M23;
			far.Normal.Z = matrix.M34 - matrix.M33;
			far.D = matrix.M44 - matrix.M43;
			far.Normalize();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003524 File Offset: 0x00001724
		private static Vector3 Get3PlanesInterPoint(ref Plane p1, ref Plane p2, ref Plane p3)
		{
			return -p1.D * Vector3.Cross(p2.Normal, p3.Normal) / Vector3.Dot(p1.Normal, Vector3.Cross(p2.Normal, p3.Normal)) - p2.D * Vector3.Cross(p3.Normal, p1.Normal) / Vector3.Dot(p2.Normal, Vector3.Cross(p3.Normal, p1.Normal)) - p3.D * Vector3.Cross(p1.Normal, p2.Normal) / Vector3.Dot(p3.Normal, Vector3.Cross(p1.Normal, p2.Normal));
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000035F4 File Offset: 0x000017F4
		public static BoundingFrustum FromCamera(Vector3 cameraPos, Vector3 lookDir, Vector3 upDir, float fov, float znear, float zfar, float aspect)
		{
			lookDir = Vector3.Normalize(lookDir);
			upDir = Vector3.Normalize(upDir);
			Vector3 left = cameraPos + lookDir * znear;
			Vector3 left2 = cameraPos + lookDir * zfar;
			float num = (float)((double)znear * Math.Tan((double)(fov / 2f)));
			float num2 = (float)((double)zfar * Math.Tan((double)(fov / 2f)));
			float scale = num * aspect;
			float scale2 = num2 * aspect;
			Vector3 value = Vector3.Normalize(Vector3.Cross(upDir, lookDir));
			Vector3 vector = left - num * upDir + scale * value;
			Vector3 vector2 = left + num * upDir + scale * value;
			Vector3 vector3 = left + num * upDir - scale * value;
			Vector3 point = left - num * upDir - scale * value;
			Vector3 vector4 = left2 - num2 * upDir + scale2 * value;
			Vector3 point2 = left2 + num2 * upDir + scale2 * value;
			Vector3 vector5 = left2 + num2 * upDir - scale2 * value;
			Vector3 point3 = left2 - num2 * upDir - scale2 * value;
			BoundingFrustum result = default(BoundingFrustum);
			result.pNear = new Plane(vector, vector2, vector3);
			result.pFar = new Plane(vector5, point2, vector4);
			result.pLeft = new Plane(point, vector3, vector5);
			result.pRight = new Plane(vector4, point2, vector2);
			result.pTop = new Plane(vector2, point2, vector5);
			result.pBottom = new Plane(point3, vector4, vector);
			result.pNear.Normalize();
			result.pFar.Normalize();
			result.pLeft.Normalize();
			result.pRight.Normalize();
			result.pTop.Normalize();
			result.pBottom.Normalize();
			result.pMatrix = Matrix.LookAtLH(cameraPos, cameraPos + lookDir * 10f, upDir) * Matrix.PerspectiveFovLH(fov, aspect, znear, zfar);
			return result;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000383E File Offset: 0x00001A3E
		public static BoundingFrustum FromCamera(FrustumCameraParams cameraParams)
		{
			return BoundingFrustum.FromCamera(cameraParams.Position, cameraParams.LookAtDir, cameraParams.UpDir, cameraParams.FOV, cameraParams.ZNear, cameraParams.ZFar, cameraParams.AspectRatio);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003870 File Offset: 0x00001A70
		public Vector3[] GetCorners()
		{
			Vector3[] array = new Vector3[8];
			this.GetCorners(array);
			return array;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000388C File Offset: 0x00001A8C
		public void GetCorners(Vector3[] corners)
		{
			corners[0] = BoundingFrustum.Get3PlanesInterPoint(ref this.pNear, ref this.pBottom, ref this.pRight);
			corners[1] = BoundingFrustum.Get3PlanesInterPoint(ref this.pNear, ref this.pTop, ref this.pRight);
			corners[2] = BoundingFrustum.Get3PlanesInterPoint(ref this.pNear, ref this.pTop, ref this.pLeft);
			corners[3] = BoundingFrustum.Get3PlanesInterPoint(ref this.pNear, ref this.pBottom, ref this.pLeft);
			corners[4] = BoundingFrustum.Get3PlanesInterPoint(ref this.pFar, ref this.pBottom, ref this.pRight);
			corners[5] = BoundingFrustum.Get3PlanesInterPoint(ref this.pFar, ref this.pTop, ref this.pRight);
			corners[6] = BoundingFrustum.Get3PlanesInterPoint(ref this.pFar, ref this.pTop, ref this.pLeft);
			corners[7] = BoundingFrustum.Get3PlanesInterPoint(ref this.pFar, ref this.pBottom, ref this.pLeft);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000398C File Offset: 0x00001B8C
		public FrustumCameraParams GetCameraParams()
		{
			Vector3[] corners = this.GetCorners();
			FrustumCameraParams frustumCameraParams = default(FrustumCameraParams);
			frustumCameraParams.Position = BoundingFrustum.Get3PlanesInterPoint(ref this.pRight, ref this.pTop, ref this.pLeft);
			frustumCameraParams.LookAtDir = this.pNear.Normal;
			frustumCameraParams.UpDir = Vector3.Normalize(Vector3.Cross(this.pRight.Normal, this.pNear.Normal));
			frustumCameraParams.FOV = (float)((1.5707963267948966 - Math.Acos((double)Vector3.Dot(this.pNear.Normal, this.pTop.Normal))) * 2.0);
			frustumCameraParams.AspectRatio = (corners[6] - corners[5]).Length() / (corners[4] - corners[5]).Length();
			frustumCameraParams.ZNear = (frustumCameraParams.Position + this.pNear.Normal * this.pNear.D).Length();
			frustumCameraParams.ZFar = (frustumCameraParams.Position + this.pFar.Normal * this.pFar.D).Length();
			return frustumCameraParams;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003AE8 File Offset: 0x00001CE8
		public ContainmentType Contains(ref Vector3 point)
		{
			PlaneIntersectionType planeIntersectionType = PlaneIntersectionType.Front;
			PlaneIntersectionType planeIntersectionType2 = PlaneIntersectionType.Front;
			for (int i = 0; i < 6; i++)
			{
				switch (i)
				{
				case 0:
					planeIntersectionType2 = this.pNear.Intersects(ref point);
					break;
				case 1:
					planeIntersectionType2 = this.pFar.Intersects(ref point);
					break;
				case 2:
					planeIntersectionType2 = this.pLeft.Intersects(ref point);
					break;
				case 3:
					planeIntersectionType2 = this.pRight.Intersects(ref point);
					break;
				case 4:
					planeIntersectionType2 = this.pTop.Intersects(ref point);
					break;
				case 5:
					planeIntersectionType2 = this.pBottom.Intersects(ref point);
					break;
				}
				if (planeIntersectionType2 == PlaneIntersectionType.Back)
				{
					return ContainmentType.Disjoint;
				}
				if (planeIntersectionType2 == PlaneIntersectionType.Intersecting)
				{
					planeIntersectionType = PlaneIntersectionType.Intersecting;
				}
			}
			if (planeIntersectionType == PlaneIntersectionType.Intersecting)
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Contains;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003B97 File Offset: 0x00001D97
		public ContainmentType Contains(Vector3 point)
		{
			return this.Contains(ref point);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003BA1 File Offset: 0x00001DA1
		public ContainmentType Contains(Vector3[] points)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003BA8 File Offset: 0x00001DA8
		public void Contains(Vector3[] points, out ContainmentType result)
		{
			result = this.Contains(points);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003BB4 File Offset: 0x00001DB4
		private void GetBoxToPlanePVertexNVertex(ref BoundingBox box, ref Vector3 planeNormal, out Vector3 p, out Vector3 n)
		{
			p = box.Minimum;
			if (planeNormal.X >= 0f)
			{
				p.X = box.Maximum.X;
			}
			if (planeNormal.Y >= 0f)
			{
				p.Y = box.Maximum.Y;
			}
			if (planeNormal.Z >= 0f)
			{
				p.Z = box.Maximum.Z;
			}
			n = box.Maximum;
			if (planeNormal.X >= 0f)
			{
				n.X = box.Minimum.X;
			}
			if (planeNormal.Y >= 0f)
			{
				n.Y = box.Minimum.Y;
			}
			if (planeNormal.Z >= 0f)
			{
				n.Z = box.Minimum.Z;
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003C94 File Offset: 0x00001E94
		public ContainmentType Contains(ref BoundingBox box)
		{
			ContainmentType result = ContainmentType.Contains;
			for (int i = 0; i < 6; i++)
			{
				Plane plane = this.GetPlane(i);
				Vector3 vector;
				Vector3 vector2;
				this.GetBoxToPlanePVertexNVertex(ref box, ref plane.Normal, out vector, out vector2);
				if (Collision.PlaneIntersectsPoint(ref plane, ref vector) == PlaneIntersectionType.Back)
				{
					return ContainmentType.Disjoint;
				}
				if (Collision.PlaneIntersectsPoint(ref plane, ref vector2) == PlaneIntersectionType.Back)
				{
					result = ContainmentType.Intersects;
				}
			}
			return result;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003CE9 File Offset: 0x00001EE9
		public ContainmentType Contains(BoundingBox box)
		{
			return this.Contains(ref box);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003CF3 File Offset: 0x00001EF3
		public void Contains(ref BoundingBox box, out ContainmentType result)
		{
			result = this.Contains(ref box);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003D00 File Offset: 0x00001F00
		public ContainmentType Contains(ref BoundingSphere sphere)
		{
			PlaneIntersectionType planeIntersectionType = PlaneIntersectionType.Front;
			PlaneIntersectionType planeIntersectionType2 = PlaneIntersectionType.Front;
			for (int i = 0; i < 6; i++)
			{
				switch (i)
				{
				case 0:
					planeIntersectionType2 = this.pNear.Intersects(ref sphere);
					break;
				case 1:
					planeIntersectionType2 = this.pFar.Intersects(ref sphere);
					break;
				case 2:
					planeIntersectionType2 = this.pLeft.Intersects(ref sphere);
					break;
				case 3:
					planeIntersectionType2 = this.pRight.Intersects(ref sphere);
					break;
				case 4:
					planeIntersectionType2 = this.pTop.Intersects(ref sphere);
					break;
				case 5:
					planeIntersectionType2 = this.pBottom.Intersects(ref sphere);
					break;
				}
				if (planeIntersectionType2 == PlaneIntersectionType.Back)
				{
					return ContainmentType.Disjoint;
				}
				if (planeIntersectionType2 == PlaneIntersectionType.Intersecting)
				{
					planeIntersectionType = PlaneIntersectionType.Intersecting;
				}
			}
			if (planeIntersectionType == PlaneIntersectionType.Intersecting)
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Contains;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003DAF File Offset: 0x00001FAF
		public ContainmentType Contains(BoundingSphere sphere)
		{
			return this.Contains(ref sphere);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003DB9 File Offset: 0x00001FB9
		public void Contains(ref BoundingSphere sphere, out ContainmentType result)
		{
			result = this.Contains(ref sphere);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003DC4 File Offset: 0x00001FC4
		public bool Contains(ref BoundingFrustum frustum)
		{
			return this.Contains(frustum.GetCorners()) > ContainmentType.Disjoint;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003DD5 File Offset: 0x00001FD5
		public bool Contains(BoundingFrustum frustum)
		{
			return this.Contains(ref frustum);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003DDF File Offset: 0x00001FDF
		public void Contains(ref BoundingFrustum frustum, out bool result)
		{
			result = (this.Contains(frustum.GetCorners()) > ContainmentType.Disjoint);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003DF2 File Offset: 0x00001FF2
		public bool Intersects(ref BoundingSphere sphere)
		{
			return this.Contains(ref sphere) > ContainmentType.Disjoint;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003DFE File Offset: 0x00001FFE
		public void Intersects(ref BoundingSphere sphere, out bool result)
		{
			result = (this.Contains(ref sphere) > ContainmentType.Disjoint);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003E0C File Offset: 0x0000200C
		public bool Intersects(ref BoundingBox box)
		{
			return this.Contains(ref box) > ContainmentType.Disjoint;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003E18 File Offset: 0x00002018
		public void Intersects(ref BoundingBox box, out bool result)
		{
			result = (this.Contains(ref box) > ContainmentType.Disjoint);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003E28 File Offset: 0x00002028
		private PlaneIntersectionType PlaneIntersectsPoints(ref Plane plane, Vector3[] points)
		{
			PlaneIntersectionType planeIntersectionType = Collision.PlaneIntersectsPoint(ref plane, ref points[0]);
			for (int i = 1; i < points.Length; i++)
			{
				if (Collision.PlaneIntersectsPoint(ref plane, ref points[i]) != planeIntersectionType)
				{
					return PlaneIntersectionType.Intersecting;
				}
			}
			return planeIntersectionType;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003E64 File Offset: 0x00002064
		public PlaneIntersectionType Intersects(ref Plane plane)
		{
			return this.PlaneIntersectsPoints(ref plane, this.GetCorners());
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003E73 File Offset: 0x00002073
		public void Intersects(ref Plane plane, out PlaneIntersectionType result)
		{
			result = this.PlaneIntersectsPoints(ref plane, this.GetCorners());
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003E84 File Offset: 0x00002084
		public float GetWidthAtDepth(float depth)
		{
			return (float)(Math.Tan((double)((float)(1.5707963267948966 - Math.Acos((double)Vector3.Dot(this.pNear.Normal, this.pLeft.Normal))))) * (double)depth * 2.0);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003ED4 File Offset: 0x000020D4
		public float GetHeightAtDepth(float depth)
		{
			return (float)(Math.Tan((double)((float)(1.5707963267948966 - Math.Acos((double)Vector3.Dot(this.pNear.Normal, this.pTop.Normal))))) * (double)depth * 2.0);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003F24 File Offset: 0x00002124
		private BoundingFrustum GetInsideOutClone()
		{
			BoundingFrustum boundingFrustum = this;
			boundingFrustum.pNear.Normal = -boundingFrustum.pNear.Normal;
			boundingFrustum.pFar.Normal = -boundingFrustum.pFar.Normal;
			boundingFrustum.pLeft.Normal = -boundingFrustum.pLeft.Normal;
			boundingFrustum.pRight.Normal = -boundingFrustum.pRight.Normal;
			boundingFrustum.pTop.Normal = -boundingFrustum.pTop.Normal;
			boundingFrustum.pBottom.Normal = -boundingFrustum.pBottom.Normal;
			return boundingFrustum;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003FE4 File Offset: 0x000021E4
		public bool Intersects(ref Ray ray)
		{
			float? num;
			float? num2;
			return this.Intersects(ref ray, out num, out num2);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003FFC File Offset: 0x000021FC
		public bool Intersects(ref Ray ray, out float? inDistance, out float? outDistance)
		{
			if (this.Contains(ray.Position) != ContainmentType.Disjoint)
			{
				float num = float.MaxValue;
				for (int i = 0; i < 6; i++)
				{
					Plane plane = this.GetPlane(i);
					float num2;
					if (Collision.RayIntersectsPlane(ref ray, ref plane, out num2) && num2 < num)
					{
						num = num2;
					}
				}
				inDistance = new float?(num);
				outDistance = null;
				return true;
			}
			float num3 = float.MaxValue;
			float num4 = float.MinValue;
			for (int j = 0; j < 6; j++)
			{
				Plane plane2 = this.GetPlane(j);
				float val;
				if (Collision.RayIntersectsPlane(ref ray, ref plane2, out val))
				{
					num3 = Math.Min(num3, val);
					num4 = Math.Max(num4, val);
				}
			}
			Vector3 left = ray.Position + ray.Direction * num3;
			Vector3 right = ray.Position + ray.Direction * num4;
			Vector3 vector = (left + right) / 2f;
			if (this.Contains(ref vector) != ContainmentType.Disjoint)
			{
				inDistance = new float?(num3);
				outDistance = new float?(num4);
				return true;
			}
			inDistance = null;
			outDistance = null;
			return false;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000411C File Offset: 0x0000231C
		public float GetZoomToExtentsShiftDistance(Vector3[] points)
		{
			float num = (float)Math.Sin((double)((float)(1.5707963267948966 - Math.Acos((double)Vector3.Dot(this.pNear.Normal, this.pTop.Normal)))));
			float num2 = (float)Math.Sin((double)((float)(1.5707963267948966 - Math.Acos((double)Vector3.Dot(this.pNear.Normal, this.pLeft.Normal)))));
			float num3 = num / num2;
			BoundingFrustum insideOutClone = this.GetInsideOutClone();
			float num4 = float.MinValue;
			for (int i = 0; i < points.Length; i++)
			{
				float num5 = Collision.DistancePlanePoint(ref insideOutClone.pTop, ref points[i]);
				num5 = Math.Max(num5, Collision.DistancePlanePoint(ref insideOutClone.pBottom, ref points[i]));
				num5 = Math.Max(num5, Collision.DistancePlanePoint(ref insideOutClone.pLeft, ref points[i]) * num3);
				num5 = Math.Max(num5, Collision.DistancePlanePoint(ref insideOutClone.pRight, ref points[i]) * num3);
				num4 = Math.Max(num4, num5);
			}
			return -num4 / num;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000423C File Offset: 0x0000243C
		public float GetZoomToExtentsShiftDistance(ref BoundingBox boundingBox)
		{
			return this.GetZoomToExtentsShiftDistance(boundingBox.GetCorners());
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000424A File Offset: 0x0000244A
		public Vector3 GetZoomToExtentsShiftVector(Vector3[] points)
		{
			return this.GetZoomToExtentsShiftDistance(points) * this.pNear.Normal;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004263 File Offset: 0x00002463
		public Vector3 GetZoomToExtentsShiftVector(ref BoundingBox boundingBox)
		{
			return this.GetZoomToExtentsShiftDistance(boundingBox.GetCorners()) * this.pNear.Normal;
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00004284 File Offset: 0x00002484
		public bool IsOrthographic
		{
			get
			{
				return this.pLeft.Normal == -this.pRight.Normal && this.pTop.Normal == -this.pBottom.Normal;
			}
		}

		// Token: 0x04000016 RID: 22
		private Matrix pMatrix;

		// Token: 0x04000017 RID: 23
		private Plane pNear;

		// Token: 0x04000018 RID: 24
		private Plane pFar;

		// Token: 0x04000019 RID: 25
		private Plane pLeft;

		// Token: 0x0400001A RID: 26
		private Plane pRight;

		// Token: 0x0400001B RID: 27
		private Plane pTop;

		// Token: 0x0400001C RID: 28
		private Plane pBottom;
	}
}

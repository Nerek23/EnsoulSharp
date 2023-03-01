using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000AD RID: 173
	[Guid("7ed943dd-52e8-40b5-a8d8-76685c406330")]
	public class BaseMesh : ComObject
	{
		// Token: 0x0600047E RID: 1150 RVA: 0x00002623 File Offset: 0x00000823
		public BaseMesh(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00011052 File Offset: 0x0000F252
		public new static explicit operator BaseMesh(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new BaseMesh(nativePointer);
			}
			return null;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x00011069 File Offset: 0x0000F269
		public int FVF
		{
			get
			{
				return this.GetFVF();
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x00011071 File Offset: 0x0000F271
		public int NumBytesPerVertex
		{
			get
			{
				return this.GetNumBytesPerVertex();
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00011079 File Offset: 0x0000F279
		public int Options
		{
			get
			{
				return this.GetOptions();
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00011084 File Offset: 0x0000F284
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0001109C File Offset: 0x0000F29C
		public VertexBuffer VertexBuffer
		{
			get
			{
				VertexBuffer result;
				this.GetVertexBuffer(out result);
				return result;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x000110B4 File Offset: 0x0000F2B4
		public IndexBuffer IndexBuffer
		{
			get
			{
				IndexBuffer result;
				this.GetIndexBuffer(out result);
				return result;
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x000110CC File Offset: 0x0000F2CC
		public unsafe void DrawSubset(int attribId)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, attribId, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00004001 File Offset: 0x00002201
		internal unsafe int GetNumFaces()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x000105EF File Offset: 0x0000E7EF
		internal unsafe int GetNumVertices()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0001060E File Offset: 0x0000E80E
		internal unsafe int GetFVF()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00011104 File Offset: 0x0000F304
		public unsafe void GetDeclaration(VertexElement declaration)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &declaration, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0001113E File Offset: 0x0000F33E
		internal unsafe int GetNumBytesPerVertex()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0001115D File Offset: 0x0000F35D
		internal unsafe int GetOptions()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00011180 File Offset: 0x0000F380
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x000111DC File Offset: 0x0000F3DC
		public unsafe void CloneMeshFVF(int options, int fvf, Device d3DDeviceRef, out Mesh cloneMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, options, fvf, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			cloneMeshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			result.CheckError();
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00011250 File Offset: 0x0000F450
		public unsafe void CloneMesh(int options, VertexElement declarationRef, Device d3DDeviceRef, out Mesh cloneMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, options, &declarationRef, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			cloneMeshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			result.CheckError();
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x000112C4 File Offset: 0x0000F4C4
		internal unsafe void GetVertexBuffer(out VertexBuffer vBOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			vBOut = ((zero == IntPtr.Zero) ? null : new VertexBuffer(zero));
			result.CheckError();
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00011320 File Offset: 0x0000F520
		internal unsafe void GetIndexBuffer(out IndexBuffer iBOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			iBOut = ((zero == IntPtr.Zero) ? null : new IndexBuffer(zero));
			result.CheckError();
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0001137C File Offset: 0x0000F57C
		public unsafe void LockVertexBuffer(int flags, IntPtr dataOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, flags, (void*)dataOut, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x000113BC File Offset: 0x0000F5BC
		public unsafe void UnlockVertexBuffer()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000113F4 File Offset: 0x0000F5F4
		public unsafe void LockIndexBuffer(int flags, IntPtr dataOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, flags, (void*)dataOut, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00011434 File Offset: 0x0000F634
		public unsafe void UnlockIndexBuffer()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0001146C File Offset: 0x0000F66C
		public unsafe void GetAttributeTable(out AttributeRange attribTableRef, out int attribTableSizeRef)
		{
			attribTableRef = default(AttributeRange);
			Result result;
			fixed (AttributeRange* ptr = &attribTableRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &attribTableSizeRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, ptr4, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x000114C0 File Offset: 0x0000F6C0
		public unsafe void ConvertPointRepsToAdjacency(int pRepRef, int adjacencyRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &pRepRef, &adjacencyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00011500 File Offset: 0x0000F700
		public unsafe void ConvertAdjacencyToPointReps(int adjacencyRef, int pRepRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &adjacencyRef, &pRepRef, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00011540 File Offset: 0x0000F740
		public unsafe void GenerateAdjacency(float epsilon, int adjacencyRef)
		{
			calli(System.Int32(System.Void*,System.Single,System.Void*), this._nativePointer, epsilon, &adjacencyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0001157C File Offset: 0x0000F77C
		public unsafe void UpdateSemantics(VertexElement declaration)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &declaration, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

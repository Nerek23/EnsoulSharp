using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000BA RID: 186
	[Guid("8875769a-d579-4088-aaeb-534d1ad84e96")]
	public class ProgressiveMesh : BaseMesh
	{
		// Token: 0x0600054C RID: 1356 RVA: 0x00012D37 File Offset: 0x00010F37
		public ProgressiveMesh(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0001368B File Offset: 0x0001188B
		public new static explicit operator ProgressiveMesh(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new ProgressiveMesh(nativePointer);
			}
			return null;
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x000136A2 File Offset: 0x000118A2
		public int MaxFaces
		{
			get
			{
				return this.GetMaxFaces();
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x000136AA File Offset: 0x000118AA
		public int MinFaces
		{
			get
			{
				return this.GetMinFaces();
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x000136B2 File Offset: 0x000118B2
		public int MaxVertices
		{
			get
			{
				return this.GetMaxVertices();
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x000136BA File Offset: 0x000118BA
		public int MinVertices
		{
			get
			{
				return this.GetMinVertices();
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x000136C4 File Offset: 0x000118C4
		public int Adjacency
		{
			get
			{
				int result;
				this.GetAdjacency(out result);
				return result;
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x000136DC File Offset: 0x000118DC
		public unsafe void ClonePMeshFVF(int options, int fvf, Device d3DDeviceRef, out ProgressiveMesh cloneMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, options, fvf, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			cloneMeshOut = ((zero == IntPtr.Zero) ? null : new ProgressiveMesh(zero));
			result.CheckError();
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00013750 File Offset: 0x00011950
		public unsafe void ClonePMesh(int options, VertexElement declarationRef, Device d3DDeviceRef, out ProgressiveMesh cloneMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, options, &declarationRef, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			cloneMeshOut = ((zero == IntPtr.Zero) ? null : new ProgressiveMesh(zero));
			result.CheckError();
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x000137C4 File Offset: 0x000119C4
		internal unsafe void SetNumFaces(int faces)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, faces, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00013800 File Offset: 0x00011A00
		internal unsafe void SetNumVertices(int vertices)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, vertices, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00013839 File Offset: 0x00011A39
		internal unsafe int GetMaxFaces()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00013859 File Offset: 0x00011A59
		internal unsafe int GetMinFaces()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00013879 File Offset: 0x00011A79
		internal unsafe int GetMaxVertices()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00013899 File Offset: 0x00011A99
		internal unsafe int GetMinVertices()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x000138BC File Offset: 0x00011ABC
		internal unsafe void Save_(IntPtr streamRef, ref ExtendedMaterial materialsRef, EffectInstance effectInstancesRef, int numMaterials)
		{
			ExtendedMaterial.__Native _Native = default(ExtendedMaterial.__Native);
			materialsRef.__MarshalTo(ref _Native);
			EffectInstance.__Native _Native2 = default(EffectInstance.__Native);
			effectInstancesRef.__MarshalTo(ref _Native2);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)streamRef, &_Native, &_Native2, numMaterials, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
			materialsRef.__MarshalFree(ref _Native);
			effectInstancesRef.__MarshalFree(ref _Native2);
			result.CheckError();
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00013934 File Offset: 0x00011B34
		public unsafe void Optimize(int flags, int adjacencyOutRef, int faceRemapRef, out Blob vertexRemapOut, out Mesh optMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, flags, &adjacencyOutRef, &faceRemapRef, &zero, &zero2, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
			vertexRemapOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			optMeshOut = ((zero2 == IntPtr.Zero) ? null : new Mesh(zero2));
			result.CheckError();
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x000139B8 File Offset: 0x00011BB8
		public unsafe void OptimizeBaseLOD(int flags, int faceRemapRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, flags, &faceRemapRef, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x000139F4 File Offset: 0x00011BF4
		public unsafe void TrimByFaces(int newFacesMin, int newFacesMax, int rgiFaceRemap, int rgiVertRemap)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, newFacesMin, newFacesMax, &rgiFaceRemap, &rgiVertRemap, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00013A34 File Offset: 0x00011C34
		public unsafe void TrimByVertices(int newVerticesMin, int newVerticesMax, int rgiFaceRemap, int rgiVertRemap)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, newVerticesMin, newVerticesMax, &rgiFaceRemap, &rgiVertRemap, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00013A74 File Offset: 0x00011C74
		internal unsafe void GetAdjacency(out int adjacencyRef)
		{
			Result result;
			fixed (int* ptr = &adjacencyRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00013AB8 File Offset: 0x00011CB8
		public unsafe void GenerateVertexHistory(int vertexHistoryRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &vertexHistoryRef, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

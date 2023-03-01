using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000BF RID: 191
	[Guid("667ea4c7-f1cd-4386-b523-7c0290b83cc5")]
	public class SimplificationMesh : ComObject
	{
		// Token: 0x06000599 RID: 1433 RVA: 0x00002623 File Offset: 0x00000823
		public SimplificationMesh(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x000146E4 File Offset: 0x000128E4
		public new static explicit operator SimplificationMesh(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new SimplificationMesh(nativePointer);
			}
			return null;
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x000146FB File Offset: 0x000128FB
		public int NumFaces
		{
			get
			{
				return this.GetNumFaces();
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x00014703 File Offset: 0x00012903
		public int NumVertices
		{
			get
			{
				return this.GetNumVertices();
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x0001470B File Offset: 0x0001290B
		public int FVF
		{
			get
			{
				return this.GetFVF();
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x00014713 File Offset: 0x00012913
		public int Options
		{
			get
			{
				return this.GetOptions();
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0001471C File Offset: 0x0001291C
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x00014732 File Offset: 0x00012932
		public int MaxFaces
		{
			get
			{
				return this.GetMaxFaces();
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0001473A File Offset: 0x0001293A
		public int MaxVertices
		{
			get
			{
				return this.GetMaxVertices();
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x00014744 File Offset: 0x00012944
		public float VertexWeights
		{
			get
			{
				float result;
				this.GetVertexWeights(out result);
				return result;
			}
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x000105D0 File Offset: 0x0000E7D0
		internal unsafe int GetNumFaces()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00004001 File Offset: 0x00002201
		internal unsafe int GetNumVertices()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x000105EF File Offset: 0x0000E7EF
		internal unsafe int GetFVF()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0001475C File Offset: 0x0001295C
		public unsafe void GetDeclaration(VertexElement declaration)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &declaration, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00012FB6 File Offset: 0x000111B6
		internal unsafe int GetOptions()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x00014798 File Offset: 0x00012998
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x000147F0 File Offset: 0x000129F0
		public unsafe void CloneMeshFVF(int options, int fvf, Device d3DDeviceRef, int adjacencyOutRef, int vertexRemapOutRef, out Mesh cloneMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, options, fvf, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), &adjacencyOutRef, &vertexRemapOutRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			cloneMeshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			result.CheckError();
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x00014868 File Offset: 0x00012A68
		public unsafe void CloneMesh(int options, VertexElement declarationRef, Device d3DDeviceRef, int adjacencyOutRef, int vertexRemapOutRef, out Mesh cloneMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, options, &declarationRef, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), &adjacencyOutRef, &vertexRemapOutRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			cloneMeshOut = ((zero == IntPtr.Zero) ? null : new Mesh(zero));
			result.CheckError();
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x000148E4 File Offset: 0x00012AE4
		public unsafe void ClonePMeshFVF(int options, int fvf, Device d3DDeviceRef, int vertexRemapOutRef, float errorsByFaceRef, out ProgressiveMesh cloneMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, options, fvf, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), &vertexRemapOutRef, &errorsByFaceRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			cloneMeshOut = ((zero == IntPtr.Zero) ? null : new ProgressiveMesh(zero));
			result.CheckError();
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0001495C File Offset: 0x00012B5C
		public unsafe void ClonePMesh(int options, VertexElement declarationRef, Device d3DDeviceRef, int vertexRemapOutRef, float errorsbyFaceRef, out ProgressiveMesh cloneMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, options, &declarationRef, (void*)((d3DDeviceRef == null) ? IntPtr.Zero : d3DDeviceRef.NativePointer), &vertexRemapOutRef, &errorsbyFaceRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			cloneMeshOut = ((zero == IntPtr.Zero) ? null : new ProgressiveMesh(zero));
			result.CheckError();
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x000149D8 File Offset: 0x00012BD8
		public unsafe void ReduceFaces(int faces)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, faces, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00014A14 File Offset: 0x00012C14
		public unsafe void ReduceVertices(int vertices)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, vertices, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00006504 File Offset: 0x00004704
		internal unsafe int GetMaxFaces()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00014A4D File Offset: 0x00012C4D
		internal unsafe int GetMaxVertices()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00014A70 File Offset: 0x00012C70
		public unsafe void GetVertexAttributeWeights(ref AttributeWeights vertexAttributeWeightsRef)
		{
			AttributeWeights.__Native _Native = default(AttributeWeights.__Native);
			vertexAttributeWeightsRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			vertexAttributeWeightsRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00014AC4 File Offset: 0x00012CC4
		internal unsafe void GetVertexWeights(out float vertexWeightsRef)
		{
			Result result;
			fixed (float* ptr = &vertexWeightsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}

using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C0 RID: 192
	[Guid("11eaa540-f9a6-4d49-ae6a-e19221f70cc4")]
	public class SkinInfo : ComObject
	{
		// Token: 0x060005B3 RID: 1459 RVA: 0x00002623 File Offset: 0x00000823
		public SkinInfo(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00014B05 File Offset: 0x00012D05
		public new static explicit operator SkinInfo(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new SkinInfo(nativePointer);
			}
			return null;
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x00014B1C File Offset: 0x00012D1C
		public int MaxVertexInfluences
		{
			get
			{
				int result;
				this.GetMaxVertexInfluences(out result);
				return result;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x00014B32 File Offset: 0x00012D32
		public int NumBones
		{
			get
			{
				return this.GetNumBones();
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x00014B3A File Offset: 0x00012D3A
		// (set) Token: 0x060005B8 RID: 1464 RVA: 0x00014B42 File Offset: 0x00012D42
		public float MinBoneInfluence
		{
			get
			{
				return this.GetMinBoneInfluence();
			}
			set
			{
				this.SetMinBoneInfluence(value);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x00014B4B File Offset: 0x00012D4B
		// (set) Token: 0x060005BA RID: 1466 RVA: 0x00014B53 File Offset: 0x00012D53
		public int FVF
		{
			get
			{
				return this.GetFVF();
			}
			set
			{
				this.SetFVF(value);
			}
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00014B5C File Offset: 0x00012D5C
		public unsafe void SetBoneInfluence(int bone, int numInfluences, int vertices, float weights)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, bone, numInfluences, &vertices, &weights, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00014B9C File Offset: 0x00012D9C
		public unsafe void SetBoneVertexInfluence(int boneNum, int influenceNum, float weight)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Single), this._nativePointer, boneNum, influenceNum, weight, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x00014BD6 File Offset: 0x00012DD6
		public unsafe int GetNumBoneInfluences(int bone)
		{
			return calli(System.Int32(System.Void*,System.Int32), this._nativePointer, bone, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x00014BF8 File Offset: 0x00012DF8
		public unsafe void GetBoneInfluence(int bone, out int vertices, out float weights)
		{
			Result result;
			fixed (int* ptr = &vertices)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &weights)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, bone, ptr2, ptr4, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00014C48 File Offset: 0x00012E48
		public unsafe void GetBoneVertexInfluence(int boneNum, int influenceNum, out float weightRef, out int vertexNumRef)
		{
			Result result;
			fixed (float* ptr = &weightRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &vertexNumRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, boneNum, influenceNum, ptr2, ptr4, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x00014C98 File Offset: 0x00012E98
		internal unsafe void GetMaxVertexInfluences(out int maxVertexInfluences)
		{
			Result result;
			fixed (int* ptr = &maxVertexInfluences)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0001115D File Offset: 0x0000F35D
		internal unsafe int GetNumBones()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00014CD8 File Offset: 0x00012ED8
		public unsafe void FindBoneVertexInfluenceIndex(int boneNum, int vertexNum, int influenceIndexRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, boneNum, vertexNum, &influenceIndexRef, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00014D18 File Offset: 0x00012F18
		public unsafe void GetMaxFaceInfluences(IndexBuffer iBRef, int numFaces, out int maxFaceInfluences)
		{
			Result result;
			fixed (int* ptr = &maxFaceInfluences)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)((iBRef == null) ? IntPtr.Zero : iBRef.NativePointer), numFaces, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x00014D70 File Offset: 0x00012F70
		internal unsafe void SetMinBoneInfluence(float minInfl)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, minInfl, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00014DA9 File Offset: 0x00012FA9
		internal unsafe float GetMinBoneInfluence()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00014DCC File Offset: 0x00012FCC
		public unsafe void SetBoneName(int bone, string nameRef)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(nameRef);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, bone, (void*)intPtr, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00014E18 File Offset: 0x00013018
		public unsafe string GetBoneName(int bone)
		{
			return Marshal.PtrToStringAnsi(calli(System.IntPtr(System.Void*,System.Int32), this._nativePointer, bone, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))));
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00014E40 File Offset: 0x00013040
		public unsafe void SetBoneOffsetMatrix(int bone, ref RawMatrix boneTransformRef)
		{
			Result result;
			fixed (RawMatrix* ptr = &boneTransformRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, bone, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00014E82 File Offset: 0x00013082
		public unsafe RawMatrix GetBoneOffsetMatrix(int bone)
		{
			return calli(SharpDX.Mathematics.Interop.RawMatrix(System.Void*,System.Int32), this._nativePointer, bone, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00014EA4 File Offset: 0x000130A4
		public unsafe void Clone(out SkinInfo skinInfoOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			skinInfoOut = ((zero == IntPtr.Zero) ? null : new SkinInfo(zero));
			result.CheckError();
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00014F00 File Offset: 0x00013100
		public unsafe void Remap(int numVertices, int vertexRemapRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, numVertices, &vertexRemapRef, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00014F3C File Offset: 0x0001313C
		internal unsafe void SetFVF(int fvf)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, fvf, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00014F78 File Offset: 0x00013178
		public unsafe void SetDeclaration(VertexElement declarationRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &declarationRef, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00014FB3 File Offset: 0x000131B3
		internal unsafe int GetFVF()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00014FD4 File Offset: 0x000131D4
		public unsafe void GetDeclaration(VertexElement declaration)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &declaration, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00015010 File Offset: 0x00013210
		public unsafe void UpdateSkinnedMesh(ref RawMatrix boneTransformsRef, ref RawMatrix boneInvTransposeTransformsRef, IntPtr verticesSrcRef, IntPtr verticesDstRef)
		{
			Result result;
			fixed (RawMatrix* ptr = &boneTransformsRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawMatrix* ptr3 = &boneInvTransposeTransformsRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, ptr4, (void*)verticesSrcRef, (void*)verticesDstRef, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0001506C File Offset: 0x0001326C
		public unsafe void ConvertToBlendedMesh(Mesh meshRef, int options, int adjacencyInRef, int adjacencyOutRef, int faceRemapRef, out Blob vertexRemapOut, int maxFaceInflRef, int numBoneCombinationsRef, out Blob boneCombinationTableOut, out Mesh meshOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), options, &adjacencyInRef, &adjacencyOutRef, &faceRemapRef, &zero, &maxFaceInflRef, &numBoneCombinationsRef, &zero2, &zero3, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			vertexRemapOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			boneCombinationTableOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			meshOut = ((zero3 == IntPtr.Zero) ? null : new Mesh(zero3));
			result.CheckError();
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00015130 File Offset: 0x00013330
		public unsafe void ConvertToIndexedBlendedMesh(Mesh meshRef, int options, int paletteSize, int adjacencyInRef, int adjacencyOutRef, int faceRemapRef, out Blob vertexRemapOut, int maxVertexInflRef, int numBoneCombinationsRef, out Blob boneCombinationTableOut, out Mesh meshOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			IntPtr zero3 = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), options, paletteSize, &adjacencyInRef, &adjacencyOutRef, &faceRemapRef, &zero, &maxVertexInflRef, &numBoneCombinationsRef, &zero2, &zero3, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			vertexRemapOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			boneCombinationTableOut = ((zero2 == IntPtr.Zero) ? null : new Blob(zero2));
			meshOut = ((zero3 == IntPtr.Zero) ? null : new Mesh(zero3));
			result.CheckError();
		}
	}
}

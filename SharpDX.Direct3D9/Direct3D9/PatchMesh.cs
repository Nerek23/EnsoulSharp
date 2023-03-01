using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B8 RID: 184
	[Guid("3ce6cc22-dbf2-44f4-894d-f9c34a337139")]
	public class PatchMesh : ComObject
	{
		// Token: 0x06000525 RID: 1317 RVA: 0x00002623 File Offset: 0x00000823
		public PatchMesh(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x00012EFA File Offset: 0x000110FA
		public new static explicit operator PatchMesh(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new PatchMesh(nativePointer);
			}
			return null;
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x00012F11 File Offset: 0x00011111
		public int NumPatches
		{
			get
			{
				return this.GetNumPatches();
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x00012F19 File Offset: 0x00011119
		public int NumVertices
		{
			get
			{
				return this.GetNumVertices();
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x00012F21 File Offset: 0x00011121
		public int ControlVerticesPerPatch
		{
			get
			{
				return this.GetControlVerticesPerPatch();
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x00012F29 File Offset: 0x00011129
		public int Options
		{
			get
			{
				return this.GetOptions();
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x00012F34 File Offset: 0x00011134
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x00012F4C File Offset: 0x0001114C
		public VertexBuffer VertexBuffer
		{
			get
			{
				VertexBuffer result;
				this.GetVertexBuffer(out result);
				return result;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x00012F64 File Offset: 0x00011164
		public IndexBuffer IndexBuffer
		{
			get
			{
				IndexBuffer result;
				this.GetIndexBuffer(out result);
				return result;
			}
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x000105D0 File Offset: 0x0000E7D0
		internal unsafe int GetNumPatches()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00004001 File Offset: 0x00002201
		internal unsafe int GetNumVertices()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00012F7C File Offset: 0x0001117C
		public unsafe void GetDeclaration(VertexElement declaration)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &declaration, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0001060E File Offset: 0x0000E80E
		internal unsafe int GetControlVerticesPerPatch()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00012FB6 File Offset: 0x000111B6
		internal unsafe int GetOptions()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00012FD8 File Offset: 0x000111D8
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00013030 File Offset: 0x00011230
		public unsafe void GetPatchInfo(PatchInfo patchInfo)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &patchInfo, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0001306C File Offset: 0x0001126C
		internal unsafe void GetVertexBuffer(out VertexBuffer vBOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			vBOut = ((zero == IntPtr.Zero) ? null : new VertexBuffer(zero));
			result.CheckError();
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x000130C8 File Offset: 0x000112C8
		internal unsafe void GetIndexBuffer(out IndexBuffer iBOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			iBOut = ((zero == IntPtr.Zero) ? null : new IndexBuffer(zero));
			result.CheckError();
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00013124 File Offset: 0x00011324
		public unsafe void LockVertexBuffer(int flags, IntPtr dataOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, flags, (void*)dataOut, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00013164 File Offset: 0x00011364
		public unsafe void UnlockVertexBuffer()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001319C File Offset: 0x0001139C
		public unsafe void LockIndexBuffer(int flags, IntPtr dataOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, flags, (void*)dataOut, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x000131DC File Offset: 0x000113DC
		public unsafe void UnlockIndexBuffer()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00013214 File Offset: 0x00011414
		public unsafe void LockAttributeBuffer(int flags, int dataOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, flags, &dataOut, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00013250 File Offset: 0x00011450
		public unsafe void UnlockAttributeBuffer()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00013288 File Offset: 0x00011488
		public unsafe void GetTessSize(float fTessLevel, int adaptive, out int numTriangles, out int numVertices)
		{
			Result result;
			fixed (int* ptr = &numTriangles)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &numVertices)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Single,System.Int32,System.Void*,System.Void*), this._nativePointer, fTessLevel, adaptive, ptr2, ptr4, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x000132D8 File Offset: 0x000114D8
		public unsafe void GenerateAdjacency(float tolerance)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, tolerance, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00013314 File Offset: 0x00011514
		public unsafe void CloneMesh(int options, VertexElement declRef, out PatchMesh meshRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, options, &declRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			meshRef = ((zero == IntPtr.Zero) ? null : new PatchMesh(zero));
			result.CheckError();
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00013374 File Offset: 0x00011574
		public unsafe void Optimize(int flags)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x000133B0 File Offset: 0x000115B0
		public unsafe void SetDisplaceParam(BaseTexture texture, TextureFilter minFilter, TextureFilter magFilter, TextureFilter mipFilter, TextureAddress wrap, int dwLODBias)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, (void*)((texture == null) ? IntPtr.Zero : texture.NativePointer), minFilter, magFilter, mipFilter, wrap, dwLODBias, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00013408 File Offset: 0x00011608
		public unsafe void GetDisplaceParam(out BaseTexture texture, out TextureFilter minFilter, out TextureFilter magFilter, out TextureFilter mipFilter, out TextureAddress wrap, out int dwLODBias)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (TextureFilter* ptr = &minFilter)
			{
				void* ptr2 = (void*)ptr;
				fixed (TextureFilter* ptr3 = &magFilter)
				{
					void* ptr4 = (void*)ptr3;
					fixed (TextureFilter* ptr5 = &mipFilter)
					{
						void* ptr6 = (void*)ptr5;
						fixed (TextureAddress* ptr7 = &wrap)
						{
							void* ptr8 = (void*)ptr7;
							fixed (int* ptr9 = &dwLODBias)
							{
								void* ptr10 = (void*)ptr9;
								result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr2, ptr4, ptr6, ptr8, ptr10, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
							}
						}
					}
				}
			}
			texture = ((zero == IntPtr.Zero) ? null : new BaseTexture(zero));
			result.CheckError();
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x000134A8 File Offset: 0x000116A8
		public unsafe void Tessellate(float fTessLevel, Mesh meshRef)
		{
			calli(System.Int32(System.Void*,System.Single,System.Void*), this._nativePointer, fTessLevel, (void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x000134F8 File Offset: 0x000116F8
		public unsafe void TessellateAdaptive(RawVector4 transRef, int dwMaxTessLevel, int dwMinTessLevel, Mesh meshRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, &transRef, dwMaxTessLevel, dwMinTessLevel, (void*)((meshRef == null) ? IntPtr.Zero : meshRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

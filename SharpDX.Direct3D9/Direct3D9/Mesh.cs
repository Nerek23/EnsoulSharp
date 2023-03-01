using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B7 RID: 183
	[Guid("4020e5c2-1403-4929-883f-e2e849fac195")]
	public class Mesh : BaseMesh
	{
		// Token: 0x0600051E RID: 1310 RVA: 0x00012D37 File Offset: 0x00010F37
		public Mesh(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00012D40 File Offset: 0x00010F40
		public new static explicit operator Mesh(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Mesh(nativePointer);
			}
			return null;
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00012D58 File Offset: 0x00010F58
		public unsafe void LockAttributeBuffer(int flags, int dataOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, flags, &dataOut, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00012D94 File Offset: 0x00010F94
		public unsafe void UnlockAttributeBuffer()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00012DCC File Offset: 0x00010FCC
		public unsafe void Optimize(int flags, int adjacencyInRef, int adjacencyOutRef, int faceRemapRef, out Blob vertexRemapOut, out Mesh optMeshOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, flags, &adjacencyInRef, &adjacencyOutRef, &faceRemapRef, &zero, &zero2, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			vertexRemapOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			optMeshOut = ((zero2 == IntPtr.Zero) ? null : new Mesh(zero2));
			result.CheckError();
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00012E54 File Offset: 0x00011054
		public unsafe void OptimizeInplace(int flags, int adjacencyInRef, int adjacencyOutRef, int faceRemapRef, out Blob vertexRemapOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, flags, &adjacencyInRef, &adjacencyOutRef, &faceRemapRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			vertexRemapOut = ((zero == IntPtr.Zero) ? null : new Blob(zero));
			result.CheckError();
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x00012EB8 File Offset: 0x000110B8
		public unsafe void SetAttributeTable(ref AttributeRange attribTableRef, int cAttribTableSize)
		{
			Result result;
			fixed (AttributeRange* ptr = &attribTableRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr2, cAttribTableSize, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}

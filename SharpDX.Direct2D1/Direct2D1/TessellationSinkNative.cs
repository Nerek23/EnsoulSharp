using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000235 RID: 565
	[Guid("2cd906c1-12e2-11dc-9fed-001143a055f9")]
	internal class TessellationSinkNative : ComObject, TessellationSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000D18 RID: 3352 RVA: 0x00024640 File Offset: 0x00022840
		public void AddTriangles(Triangle[] triangles)
		{
			this.AddTriangles_(triangles, triangles.Length);
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x0002464C File Offset: 0x0002284C
		public void Close()
		{
			this.Close_();
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x00002A7F File Offset: 0x00000C7F
		public TessellationSinkNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x00024654 File Offset: 0x00022854
		public new static explicit operator TessellationSinkNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TessellationSinkNative(nativePtr);
			}
			return null;
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x0002466C File Offset: 0x0002286C
		internal unsafe void AddTriangles_(Triangle[] triangles, int trianglesCount)
		{
			fixed (Triangle[] array = triangles)
			{
				void* ptr;
				if (triangles == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, trianglesCount, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x000246B4 File Offset: 0x000228B4
		internal unsafe void Close_()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

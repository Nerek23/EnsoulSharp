using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200012D RID: 301
	[Guid("B71E6052-5AEA-4FA3-832E-F60D431F7E91")]
	public class FontDownloadQueue : ComObject
	{
		// Token: 0x06000549 RID: 1353 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontDownloadQueue(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00011125 File Offset: 0x0000F325
		public new static explicit operator FontDownloadQueue(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontDownloadQueue(nativePtr);
			}
			return null;
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x0001113C File Offset: 0x0000F33C
		public RawBool IsEmpty
		{
			get
			{
				return this.IsEmpty_();
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x00011144 File Offset: 0x0000F344
		public long GenerationCount
		{
			get
			{
				return this.GetGenerationCount();
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0001114C File Offset: 0x0000F34C
		public unsafe void AddListener(FontDownloadListener listener, out int token)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontDownloadListener>(listener);
			Result result;
			fixed (int* ptr = &token)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x000111A0 File Offset: 0x0000F3A0
		public unsafe void RemoveListener(int token)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, token, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x000111D8 File Offset: 0x0000F3D8
		internal unsafe RawBool IsEmpty_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x000111F8 File Offset: 0x0000F3F8
		public unsafe void BeginDownload(IUnknown context)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(context);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00011244 File Offset: 0x0000F444
		public unsafe void CancelDownload()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001127B File Offset: 0x0000F47B
		internal unsafe long GetGenerationCount()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}
	}
}

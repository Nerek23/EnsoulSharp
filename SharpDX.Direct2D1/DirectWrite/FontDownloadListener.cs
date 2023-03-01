using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200012C RID: 300
	[Guid("B06FE5B9-43EC-4393-881B-DBE4DC72FDA7")]
	public class FontDownloadListener : ComObject
	{
		// Token: 0x06000546 RID: 1350 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontDownloadListener(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x000110BB File Offset: 0x0000F2BB
		public new static explicit operator FontDownloadListener(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontDownloadListener(nativePtr);
			}
			return null;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x000110D4 File Offset: 0x0000F2D4
		public unsafe void DownloadCompleted(FontDownloadQueue downloadQueue, IUnknown context, Result downloadResult)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontDownloadQueue>(downloadQueue);
			value2 = CppObject.ToCallbackPtr<IUnknown>(context);
			calli(System.Void(System.Void*,System.Void*,System.Void*,SharpDX.Result), this._nativePointer, (void*)value, (void*)value2, downloadResult, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}
	}
}

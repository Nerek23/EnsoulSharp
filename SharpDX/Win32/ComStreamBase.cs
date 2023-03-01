using System;
using System.Runtime.InteropServices;

namespace SharpDX.Win32
{
	// Token: 0x02000066 RID: 102
	[Guid("0c733a30-2a1c-11ce-ade5-00aa0044773d")]
	public class ComStreamBase : ComObject, IStreamBase, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000279 RID: 633 RVA: 0x00006A87 File Offset: 0x00004C87
		public ComStreamBase(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00007972 File Offset: 0x00005B72
		public new static explicit operator ComStreamBase(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ComStreamBase(nativePtr);
			}
			return null;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000798C File Offset: 0x00005B8C
		public unsafe int Read(IntPtr vRef, int cb)
		{
			int result;
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)vRef, cb, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000079D0 File Offset: 0x00005BD0
		public unsafe int Write(IntPtr vRef, int cb)
		{
			int result;
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)vRef, cb, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}
	}
}

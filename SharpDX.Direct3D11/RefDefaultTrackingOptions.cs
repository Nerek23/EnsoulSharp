using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000BE RID: 190
	[Guid("03916615-c644-418c-9bf4-75db5be63ca0")]
	public class RefDefaultTrackingOptions : ComObject
	{
		// Token: 0x060003C0 RID: 960 RVA: 0x0000383E File Offset: 0x00001A3E
		public RefDefaultTrackingOptions(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0000EE09 File Offset: 0x0000D009
		public new static explicit operator RefDefaultTrackingOptions(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RefDefaultTrackingOptions(nativePtr);
			}
			return null;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000EE20 File Offset: 0x0000D020
		public unsafe void SetTrackingOptions(int resourceTypeFlags, int options)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, resourceTypeFlags, options, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

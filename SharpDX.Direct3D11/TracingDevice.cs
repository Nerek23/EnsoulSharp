using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C1 RID: 193
	[Guid("1911c771-1587-413e-a7e0-fb26c3de0268")]
	public class TracingDevice : ComObject
	{
		// Token: 0x060003CB RID: 971 RVA: 0x0000383E File Offset: 0x00001A3E
		public TracingDevice(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000EF0A File Offset: 0x0000D10A
		public new static explicit operator TracingDevice(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TracingDevice(nativePtr);
			}
			return null;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000EF24 File Offset: 0x0000D124
		public unsafe void SetShaderTrackingOptionsByType(int resourceTypeFlags, int options)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, resourceTypeFlags, options, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0000EF60 File Offset: 0x0000D160
		public unsafe void SetShaderTrackingOptions(IUnknown shaderRef, int options)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(shaderRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, options, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B7 RID: 183
	[Guid("917600da-f58c-4c33-98d8-3e15b390fa24")]
	public class DeviceContext4 : DeviceContext3
	{
		// Token: 0x06000384 RID: 900 RVA: 0x0000DD1F File Offset: 0x0000BF1F
		public DeviceContext4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000DD28 File Offset: 0x0000BF28
		public new static explicit operator DeviceContext4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext4(nativePtr);
			}
			return null;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0000DD40 File Offset: 0x0000BF40
		public unsafe void Signal(Fence fenceRef, long value)
		{
			IntPtr value2 = IntPtr.Zero;
			value2 = CppObject.ToCallbackPtr<Fence>(fenceRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int64), this._nativePointer, (void*)value2, value, *(*(IntPtr*)this._nativePointer + (IntPtr)147 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000DD90 File Offset: 0x0000BF90
		public unsafe void Wait(Fence fenceRef, long value)
		{
			IntPtr value2 = IntPtr.Zero;
			value2 = CppObject.ToCallbackPtr<Fence>(fenceRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int64), this._nativePointer, (void*)value2, value, *(*(IntPtr*)this._nativePointer + (IntPtr)148 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

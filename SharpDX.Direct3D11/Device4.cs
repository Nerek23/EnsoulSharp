using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B6 RID: 182
	[Guid("8992ab71-02e6-4b8d-ba48-b056dcda42c4")]
	public class Device4 : Device3
	{
		// Token: 0x06000380 RID: 896 RVA: 0x0000DC9B File Offset: 0x0000BE9B
		public Device4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000DCA4 File Offset: 0x0000BEA4
		public new static explicit operator Device4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device4(nativePtr);
			}
			return null;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0000DCBC File Offset: 0x0000BEBC
		public unsafe int RegisterDeviceRemovedEvent(IntPtr hEvent)
		{
			int result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hEvent, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)65 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000DCFE File Offset: 0x0000BEFE
		public unsafe void UnregisterDeviceRemoved(int dwCookie)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, dwCookie, *(*(IntPtr*)this._nativePointer + (IntPtr)66 * (IntPtr)sizeof(void*)));
		}
	}
}

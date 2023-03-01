using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D
{
	// Token: 0x020000A8 RID: 168
	[Guid("9B7E4E00-342C-4106-A19F-4F2704F689F0")]
	public class DeviceMultithread : ComObject
	{
		// Token: 0x06000346 RID: 838 RVA: 0x00006A87 File Offset: 0x00004C87
		public DeviceMultithread(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00009839 File Offset: 0x00007A39
		public new static explicit operator DeviceMultithread(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceMultithread(nativePtr);
			}
			return null;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00009850 File Offset: 0x00007A50
		public unsafe void Enter()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000986F File Offset: 0x00007A6F
		public unsafe void Leave()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000988E File Offset: 0x00007A8E
		public unsafe RawBool SetMultithreadProtected(RawBool bMTProtect)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, bMTProtect, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600034B RID: 843 RVA: 0x000098AE File Offset: 0x00007AAE
		public unsafe RawBool GetMultithreadProtected()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}
	}
}

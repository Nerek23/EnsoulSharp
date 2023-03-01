using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000BC RID: 188
	[Guid("9B7E4E00-342C-4106-A19F-4F2704F689F0")]
	public class Multithread : ComObject
	{
		// Token: 0x060003AE RID: 942 RVA: 0x0000383E File Offset: 0x00001A3E
		public Multithread(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000E9AD File Offset: 0x0000CBAD
		public new static explicit operator Multithread(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Multithread(nativePtr);
			}
			return null;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000E9C4 File Offset: 0x0000CBC4
		public unsafe void Enter()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00009FBC File Offset: 0x000081BC
		public unsafe void Leave()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000E9E3 File Offset: 0x0000CBE3
		public unsafe RawBool SetMultithreadProtected(RawBool bMTProtect)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, bMTProtect, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000EA03 File Offset: 0x0000CC03
		public unsafe RawBool GetMultithreadProtected()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}
	}
}

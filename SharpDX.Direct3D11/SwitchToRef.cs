using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C0 RID: 192
	[Guid("1ef337e3-58e7-4f83-a692-db221f5ed47e")]
	public class SwitchToRef : ComObject
	{
		// Token: 0x060003C7 RID: 967 RVA: 0x0000383E File Offset: 0x00001A3E
		public SwitchToRef(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000EEB4 File Offset: 0x0000D0B4
		public new static explicit operator SwitchToRef(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SwitchToRef(nativePtr);
			}
			return null;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000EECB File Offset: 0x0000D0CB
		public unsafe RawBool SetUseRef(RawBool useRef)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, useRef, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000EEEB File Offset: 0x0000D0EB
		public unsafe RawBool GetUseRef()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}
	}
}

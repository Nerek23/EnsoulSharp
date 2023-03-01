using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001E4 RID: 484
	[Guid("e0db51c3-6f77-4bae-b3d5-e47509b35838")]
	public class GdiInteropRenderTarget : ComObject
	{
		// Token: 0x06000A01 RID: 2561 RVA: 0x0001D650 File Offset: 0x0001B850
		public void ReleaseDC()
		{
			this.ReleaseDC(null);
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00002A7F File Offset: 0x00000C7F
		public GdiInteropRenderTarget(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x0001D66C File Offset: 0x0001B86C
		public new static explicit operator GdiInteropRenderTarget(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GdiInteropRenderTarget(nativePtr);
			}
			return null;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0001D684 File Offset: 0x0001B884
		public unsafe IntPtr GetDC(DeviceContextInitializeMode mode)
		{
			IntPtr result;
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, mode, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x0001D6C0 File Offset: 0x0001B8C0
		public unsafe void ReleaseDC(RawRectangle? update)
		{
			RawRectangle value;
			if (update != null)
			{
				value = update.Value;
			}
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (update == null) ? null : (&value), *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

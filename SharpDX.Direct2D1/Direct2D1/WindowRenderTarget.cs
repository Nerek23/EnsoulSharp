using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200024D RID: 589
	[Guid("2cd90698-12e2-11dc-9fed-001143a055f9")]
	public class WindowRenderTarget : RenderTarget
	{
		// Token: 0x06000D78 RID: 3448 RVA: 0x0002501B File Offset: 0x0002321B
		public WindowRenderTarget(Factory factory, RenderTargetProperties renderTargetProperties, HwndRenderTargetProperties hwndProperties) : base(IntPtr.Zero)
		{
			factory.CreateHwndRenderTarget(ref renderTargetProperties, ref hwndProperties, this);
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x00015EFA File Offset: 0x000140FA
		public WindowRenderTarget(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x00025033 File Offset: 0x00023233
		public new static explicit operator WindowRenderTarget(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new WindowRenderTarget(nativePtr);
			}
			return null;
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000D7B RID: 3451 RVA: 0x0002504A File Offset: 0x0002324A
		public IntPtr Hwnd
		{
			get
			{
				return this.GetHwnd();
			}
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x00025052 File Offset: 0x00023252
		public unsafe WindowState CheckWindowState()
		{
			return calli(SharpDX.Direct2D1.WindowState(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x00025074 File Offset: 0x00023274
		public unsafe void Resize(Size2 ixelSizeRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &ixelSizeRef, *(*(IntPtr*)this._nativePointer + (IntPtr)58 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x000250AF File Offset: 0x000232AF
		internal unsafe IntPtr GetHwnd()
		{
			return calli(System.IntPtr(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)59 * (IntPtr)sizeof(void*)));
		}
	}
}

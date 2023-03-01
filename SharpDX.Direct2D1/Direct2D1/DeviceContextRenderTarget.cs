using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001D1 RID: 465
	[Guid("1c51bc64-de61-46fd-9899-63a5d8f03950")]
	public class DeviceContextRenderTarget : RenderTarget
	{
		// Token: 0x0600095E RID: 2398 RVA: 0x0001B275 File Offset: 0x00019475
		public DeviceContextRenderTarget(Factory factory, RenderTargetProperties properties) : base(IntPtr.Zero)
		{
			factory.CreateDCRenderTarget(ref properties, this);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00015EFA File Offset: 0x000140FA
		public DeviceContextRenderTarget(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0001B28B File Offset: 0x0001948B
		public new static explicit operator DeviceContextRenderTarget(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContextRenderTarget(nativePtr);
			}
			return null;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0001B2A4 File Offset: 0x000194A4
		public unsafe void BindDeviceContext(IntPtr hDC, RawRectangle subRectRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hDC, &subRectRef, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

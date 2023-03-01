using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000BD RID: 189
	[Guid("6985f346-2c3d-43b3-be8b-daae8a03d894")]
	public class RenderToSurface : ComObject
	{
		// Token: 0x0600057C RID: 1404 RVA: 0x00002623 File Offset: 0x00000823
		public RenderToSurface(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00014254 File Offset: 0x00012454
		public new static explicit operator RenderToSurface(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new RenderToSurface(nativePointer);
			}
			return null;
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x0001426C File Offset: 0x0001246C
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x00014284 File Offset: 0x00012484
		public RenderToSurfaceDescription Description
		{
			get
			{
				RenderToSurfaceDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0001429C File Offset: 0x0001249C
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x000142F4 File Offset: 0x000124F4
		internal unsafe void GetDescription(out RenderToSurfaceDescription descRef)
		{
			descRef = default(RenderToSurfaceDescription);
			Result result;
			fixed (RenderToSurfaceDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001433C File Offset: 0x0001253C
		public unsafe void BeginScene(Surface surfaceRef, RawViewport viewportRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((surfaceRef == null) ? IntPtr.Zero : surfaceRef.NativePointer), &viewportRef, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0001438C File Offset: 0x0001258C
		public unsafe void EndScene(Filter mipFilter)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, mipFilter, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x000143C4 File Offset: 0x000125C4
		public unsafe void OnLostDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x000143FC File Offset: 0x000125FC
		public unsafe void OnResetDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00014433 File Offset: 0x00012633
		public RenderToSurface(Device device, int width, int height, Format format, bool depthStencil = false, Format depthStencilFormat = Format.Unknown) : base(IntPtr.Zero)
		{
			D3DX9.CreateRenderToSurface(device, width, height, format, depthStencil, depthStencilFormat, this);
		}
	}
}

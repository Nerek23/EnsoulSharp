using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C4 RID: 196
	[Guid("794950F2-ADFC-458a-905E-10A10B0B503B")]
	public class SwapChain : ComObject
	{
		// Token: 0x06000625 RID: 1573 RVA: 0x00002623 File Offset: 0x00000823
		public SwapChain(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0001618D File Offset: 0x0001438D
		public new static explicit operator SwapChain(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new SwapChain(nativePointer);
			}
			return null;
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x000161A4 File Offset: 0x000143A4
		public RasterStatus RasterStatus
		{
			get
			{
				RasterStatus result;
				this.GetRasterStatus(out result);
				return result;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x000161BC File Offset: 0x000143BC
		public DisplayMode DisplayMode
		{
			get
			{
				DisplayMode result;
				this.GetDisplayMode(out result);
				return result;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x000161D4 File Offset: 0x000143D4
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x000161EC File Offset: 0x000143EC
		public PresentParameters PresentParameters
		{
			get
			{
				PresentParameters result;
				this.GetPresentParameters(out result);
				return result;
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00016204 File Offset: 0x00014404
		internal unsafe void Present(IntPtr sourceRectRef, IntPtr destRectRef, IntPtr hDestWindowOverride, IntPtr dirtyRegionRef, int dwFlags)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)sourceRectRef, (void*)destRectRef, (void*)hDestWindowOverride, (void*)dirtyRegionRef, dwFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00016258 File Offset: 0x00014458
		public unsafe void GetFrontBufferData(Surface destSurfaceRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((destSurfaceRef == null) ? IntPtr.Zero : destSurfaceRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x000162A4 File Offset: 0x000144A4
		internal unsafe Surface GetBackBuffer(int iBackBuffer, BackBufferType type)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, iBackBuffer, type, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x000162FC File Offset: 0x000144FC
		internal unsafe void GetRasterStatus(out RasterStatus rasterStatusRef)
		{
			rasterStatusRef = default(RasterStatus);
			Result result;
			fixed (RasterStatus* ptr = &rasterStatusRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00016344 File Offset: 0x00014544
		internal unsafe void GetDisplayMode(out DisplayMode modeRef)
		{
			modeRef = default(DisplayMode);
			Result result;
			fixed (DisplayMode* ptr = &modeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0001638C File Offset: 0x0001458C
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x000163E4 File Offset: 0x000145E4
		internal unsafe void GetPresentParameters(out PresentParameters presentationParametersRef)
		{
			presentationParametersRef = default(PresentParameters);
			Result result;
			fixed (PresentParameters* ptr = &presentationParametersRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001642C File Offset: 0x0001462C
		public SwapChain(Device device, PresentParameters presentParameters)
		{
			device.CreateAdditionalSwapChain(ref presentParameters, this);
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0001643D File Offset: 0x0001463D
		public Surface GetBackBuffer(int iBackBuffer)
		{
			return this.GetBackBuffer(iBackBuffer, BackBufferType.Mono);
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00016447 File Offset: 0x00014647
		public void Present(Present presentFlags)
		{
			this.Present(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (int)presentFlags);
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00016464 File Offset: 0x00014664
		public void Present(Present presentFlags, RawRectangle sourceRectangle, RawRectangle destinationRectangle)
		{
			this.Present(presentFlags, sourceRectangle, destinationRectangle, IntPtr.Zero);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00016474 File Offset: 0x00014674
		public unsafe void Present(Present presentFlags, RawRectangle sourceRectangle, RawRectangle destinationRectangle, IntPtr windowOverride)
		{
			IntPtr zero = IntPtr.Zero;
			if (!sourceRectangle.IsEmpty)
			{
				zero = new IntPtr((void*)(&sourceRectangle));
			}
			IntPtr zero2 = IntPtr.Zero;
			if (!destinationRectangle.IsEmpty)
			{
				zero2 = new IntPtr((void*)(&destinationRectangle));
			}
			this.Present(zero, zero2, windowOverride, IntPtr.Zero, (int)presentFlags);
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x000164C4 File Offset: 0x000146C4
		public unsafe void Present(Present flags, RawRectangle sourceRectangle, RawRectangle destinationRectangle, IntPtr windowOverride, IntPtr dirtyRegionRGNData)
		{
			IntPtr zero = IntPtr.Zero;
			if (!sourceRectangle.IsEmpty)
			{
				zero = new IntPtr((void*)(&sourceRectangle));
			}
			IntPtr zero2 = IntPtr.Zero;
			if (!destinationRectangle.IsEmpty)
			{
				zero2 = new IntPtr((void*)(&destinationRectangle));
			}
			this.Present(zero, zero2, windowOverride, dirtyRegionRGNData, (int)flags);
		}
	}
}

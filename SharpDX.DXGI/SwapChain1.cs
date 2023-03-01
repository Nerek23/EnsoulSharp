using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000028 RID: 40
	[Guid("790a45f7-0d42-4876-983a-0a55cfe6f4aa")]
	public class SwapChain1 : SwapChain
	{
		// Token: 0x06000117 RID: 279 RVA: 0x00005279 File Offset: 0x00003479
		public SwapChain1(Factory2 factory, ComObject device, IntPtr hwnd, ref SwapChainDescription1 description, SwapChainFullScreenDescription? fullScreenDescription = null, Output restrictToOutput = null) : base(IntPtr.Zero)
		{
			factory.CreateSwapChainForHwnd(device, hwnd, ref description, fullScreenDescription, restrictToOutput, this);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00005295 File Offset: 0x00003495
		public SwapChain1(Factory2 factory, ComObject device, ComObject coreWindow, ref SwapChainDescription1 description, Output restrictToOutput = null) : base(IntPtr.Zero)
		{
			factory.CreateSwapChainForCoreWindow(device, coreWindow, ref description, restrictToOutput, this);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000052AF File Offset: 0x000034AF
		public SwapChain1(Factory2 factory, ComObject device, ref SwapChainDescription1 description, Output restrictToOutput = null) : base(IntPtr.Zero)
		{
			factory.CreateSwapChainForComposition(device, ref description, restrictToOutput, this);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000052C8 File Offset: 0x000034C8
		public unsafe Result Present(int syncInterval, PresentFlags presentFlags, PresentParameters presentParameters)
		{
			bool flag = presentParameters.ScrollRectangle != null;
			bool flag2 = presentParameters.ScrollOffset != null;
			RawRectangle rawRectangle = flag ? presentParameters.ScrollRectangle.Value : default(RawRectangle);
			RawPoint rawPoint = flag2 ? presentParameters.ScrollOffset.Value : default(RawPoint);
			RawRectangle[] dirtyRectangles;
			void* value;
			if ((dirtyRectangles = presentParameters.DirtyRectangles) == null || dirtyRectangles.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&dirtyRectangles[0]);
			}
			PresentParameters.__Native _Native = default(PresentParameters.__Native);
			_Native.DirtyRectsCount = ((presentParameters.DirtyRectangles != null) ? presentParameters.DirtyRectangles.Length : 0);
			_Native.PDirtyRects = (IntPtr)value;
			_Native.PScrollRect = (flag ? new IntPtr((void*)(&rawRectangle)) : IntPtr.Zero);
			_Native.PScrollOffset = (flag2 ? new IntPtr((void*)(&rawPoint)) : IntPtr.Zero);
			return this.Present1(syncInterval, presentFlags, new IntPtr((void*)(&_Native)));
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000053BB File Offset: 0x000035BB
		public SwapChain1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000053C4 File Offset: 0x000035C4
		public new static explicit operator SwapChain1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SwapChain1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600011D RID: 285 RVA: 0x000053DC File Offset: 0x000035DC
		public SwapChainDescription1 Description1
		{
			get
			{
				SwapChainDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600011E RID: 286 RVA: 0x000053F4 File Offset: 0x000035F4
		public SwapChainFullScreenDescription FullscreenDescription
		{
			get
			{
				SwapChainFullScreenDescription result;
				this.GetFullscreenDescription(out result);
				return result;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600011F RID: 287 RVA: 0x0000540C File Offset: 0x0000360C
		public IntPtr Hwnd
		{
			get
			{
				IntPtr result;
				this.GetHwnd(out result);
				return result;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00005422 File Offset: 0x00003622
		public RawBool IsTemporaryMonoSupported
		{
			get
			{
				return this.IsTemporaryMonoSupported_();
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000121 RID: 289 RVA: 0x0000542C File Offset: 0x0000362C
		public Output RestrictToOutput
		{
			get
			{
				Output result;
				this.GetRestrictToOutput(out result);
				return result;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00005444 File Offset: 0x00003644
		// (set) Token: 0x06000123 RID: 291 RVA: 0x0000545A File Offset: 0x0000365A
		public RawColor4 BackgroundColor
		{
			get
			{
				RawColor4 result;
				this.GetBackgroundColor(out result);
				return result;
			}
			set
			{
				this.SetBackgroundColor(value);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00005464 File Offset: 0x00003664
		// (set) Token: 0x06000125 RID: 293 RVA: 0x0000547A File Offset: 0x0000367A
		public DisplayModeRotation Rotation
		{
			get
			{
				DisplayModeRotation result;
				this.GetRotation(out result);
				return result;
			}
			set
			{
				this.SetRotation(value);
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00005484 File Offset: 0x00003684
		internal unsafe void GetDescription1(out SwapChainDescription1 descRef)
		{
			descRef = default(SwapChainDescription1);
			Result result;
			fixed (SwapChainDescription1* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000054CC File Offset: 0x000036CC
		internal unsafe void GetFullscreenDescription(out SwapChainFullScreenDescription descRef)
		{
			descRef = default(SwapChainFullScreenDescription);
			Result result;
			fixed (SwapChainFullScreenDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00005514 File Offset: 0x00003714
		internal unsafe void GetHwnd(out IntPtr hwndRef)
		{
			Result result;
			fixed (IntPtr* ptr = &hwndRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00005558 File Offset: 0x00003758
		public unsafe void GetCoreWindow(Guid refiid, out IntPtr unkOut)
		{
			Result result;
			fixed (IntPtr* ptr = &unkOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &refiid, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000559C File Offset: 0x0000379C
		internal unsafe Result Present1(int syncInterval, PresentFlags presentFlags, IntPtr presentParametersRef)
		{
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, syncInterval, presentFlags, (void*)presentParametersRef, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			result.CheckError();
			return result;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000046BE File Offset: 0x000028BE
		internal unsafe RawBool IsTemporaryMonoSupported_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000055E0 File Offset: 0x000037E0
		internal unsafe void GetRestrictToOutput(out Output restrictToOutputOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				restrictToOutputOut = new Output(zero);
			}
			else
			{
				restrictToOutputOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000563C File Offset: 0x0000383C
		internal unsafe void SetBackgroundColor(RawColor4 colorRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &colorRef, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00005678 File Offset: 0x00003878
		internal unsafe void GetBackgroundColor(out RawColor4 colorRef)
		{
			colorRef = default(RawColor4);
			Result result;
			fixed (RawColor4* ptr = &colorRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000056C0 File Offset: 0x000038C0
		internal unsafe void SetRotation(DisplayModeRotation rotation)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, rotation, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000056FC File Offset: 0x000038FC
		internal unsafe void GetRotation(out DisplayModeRotation rotationRef)
		{
			Result result;
			fixed (DisplayModeRotation* ptr = &rotationRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}

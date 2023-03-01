using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001F6 RID: 502
	[Guid("77395441-1c8f-4555-8683-f50dab0fe792")]
	public class ImageSourceFromWic : ImageSource
	{
		// Token: 0x06000AB3 RID: 2739 RVA: 0x0001EBA3 File Offset: 0x0001CDA3
		public ImageSourceFromWic(DeviceContext2 context2, BitmapSource wicBitmapSource, ImageSourceLoadingOptions loadingOptions, AlphaMode alphaMode) : this(IntPtr.Zero)
		{
			context2.CreateImageSourceFromWic(wicBitmapSource, loadingOptions, alphaMode, this);
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0001EBBB File Offset: 0x0001CDBB
		public ImageSourceFromWic(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0001EBC4 File Offset: 0x0001CDC4
		public new static explicit operator ImageSourceFromWic(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ImageSourceFromWic(nativePtr);
			}
			return null;
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x0001EBDC File Offset: 0x0001CDDC
		public BitmapSource Source
		{
			get
			{
				BitmapSource result;
				this.GetSource(out result);
				return result;
			}
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0001EBF4 File Offset: 0x0001CDF4
		public unsafe void EnsureCached(RawRectangle? rectangleToFill)
		{
			RawRectangle value;
			if (rectangleToFill != null)
			{
				value = rectangleToFill.Value;
			}
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (rectangleToFill == null) ? null : (&value), *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x0001EC4C File Offset: 0x0001CE4C
		public unsafe void TrimCache(RawRectangle? rectangleToPreserve)
		{
			RawRectangle value;
			if (rectangleToPreserve != null)
			{
				value = rectangleToPreserve.Value;
			}
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (rectangleToPreserve == null) ? null : (&value), *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0001ECA4 File Offset: 0x0001CEA4
		internal unsafe void GetSource(out BitmapSource wicBitmapSource)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				wicBitmapSource = new BitmapSource(zero);
				return;
			}
			wicBitmapSource = null;
		}
	}
}

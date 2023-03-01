using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000019 RID: 25
	[Guid("00000301-a8f2-4877-ba0a-fd2b6645fb94")]
	public class FormatConverter : BitmapSource
	{
		// Token: 0x06000128 RID: 296 RVA: 0x0000525A File Offset: 0x0000345A
		public FormatConverter(FormatConverterInfo converterInfo) : base(IntPtr.Zero)
		{
			converterInfo.CreateInstance(this);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000526E File Offset: 0x0000346E
		public void Initialize(BitmapSource sourceRef, Guid dstFormat)
		{
			this.Initialize(sourceRef, dstFormat, BitmapDitherType.None, null, 0.0, BitmapPaletteType.Custom);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00005284 File Offset: 0x00003484
		public FormatConverter(ImagingFactory factory) : base(IntPtr.Zero)
		{
			factory.CreateFormatConverter(this);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00002145 File Offset: 0x00000345
		public FormatConverter(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00005298 File Offset: 0x00003498
		public new static explicit operator FormatConverter(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FormatConverter(nativePtr);
			}
			return null;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000052B0 File Offset: 0x000034B0
		public unsafe void Initialize(BitmapSource sourceRef, Guid dstFormat, BitmapDitherType dither, Palette paletteRef, double alphaThresholdPercent, BitmapPaletteType paletteTranslate)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(sourceRef);
			value2 = CppObject.ToCallbackPtr<Palette>(paletteRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Double,System.Int32), this._nativePointer, (void*)value, &dstFormat, dither, (void*)value2, alphaThresholdPercent, paletteTranslate, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00005318 File Offset: 0x00003518
		public unsafe RawBool CanConvert(Guid srcPixelFormat, Guid dstPixelFormat)
		{
			RawBool result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &srcPixelFormat, &dstPixelFormat, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}
	}
}

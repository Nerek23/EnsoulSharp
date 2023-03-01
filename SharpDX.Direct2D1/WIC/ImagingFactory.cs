using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x0200001F RID: 31
	[Guid("ec5ec8a9-c395-4314-9c77-54d7a935ff70")]
	public class ImagingFactory : ComObject
	{
		// Token: 0x06000144 RID: 324 RVA: 0x0000563B File Offset: 0x0000383B
		public ImagingFactory()
		{
			Utilities.CreateComInstance(ImagingFactory.WICImagingFactoryClsid, Utilities.CLSCTX.ClsctxInprocServer, Utilities.GetGuidFromType(typeof(ImagingFactory)), this);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00002A7F File Offset: 0x00000C7F
		public ImagingFactory(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000565E File Offset: 0x0000385E
		public new static explicit operator ImagingFactory(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ImagingFactory(nativePtr);
			}
			return null;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00005678 File Offset: 0x00003878
		internal unsafe void CreateDecoderFromFilename(string filename, Guid? guidVendorRef, int desiredAccess, DecodeOptions metadataOptions, BitmapDecoder decoderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Guid value;
			if (guidVendorRef != null)
			{
				value = guidVendorRef.Value;
			}
			Result result;
			fixed (string text = filename)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, ptr, (guidVendorRef == null) ? null : (&value), desiredAccess, metadataOptions, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			decoderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000056FC File Offset: 0x000038FC
		internal unsafe void CreateDecoderFromStream(IStream streamRef, Guid? guidVendorRef, DecodeOptions metadataOptions, BitmapDecoder decoderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(streamRef);
			Guid value2;
			if (guidVendorRef != null)
			{
				value2 = guidVendorRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, (guidVendorRef == null) ? null : (&value2), metadataOptions, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			decoderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000577C File Offset: 0x0000397C
		internal unsafe void CreateDecoderFromFileHandle(IntPtr hFile, Guid? guidVendorRef, DecodeOptions metadataOptions, BitmapDecoder decoderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Guid value;
			if (guidVendorRef != null)
			{
				value = guidVendorRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)hFile, (guidVendorRef == null) ? null : (&value), metadataOptions, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			decoderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000057EC File Offset: 0x000039EC
		internal unsafe void CreateComponentInfo(Guid clsidComponent, ComponentInfo infoOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &clsidComponent, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			infoOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00005838 File Offset: 0x00003A38
		internal unsafe void CreateDecoder(Guid guidContainerFormat, Guid? guidVendorRef, BitmapDecoder decoderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Guid value;
			if (guidVendorRef != null)
			{
				value = guidVendorRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &guidContainerFormat, (guidVendorRef == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			decoderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000058A4 File Offset: 0x00003AA4
		internal unsafe void CreateEncoder(Guid guidContainerFormat, Guid? guidVendorRef, BitmapEncoder encoderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Guid value;
			if (guidVendorRef != null)
			{
				value = guidVendorRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &guidContainerFormat, (guidVendorRef == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			encoderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00005910 File Offset: 0x00003B10
		internal unsafe void CreatePalette(Palette paletteOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			paletteOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00005958 File Offset: 0x00003B58
		internal unsafe void CreateFormatConverter(FormatConverter formatConverterOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			formatConverterOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000059A0 File Offset: 0x00003BA0
		internal unsafe void CreateBitmapScaler(BitmapScaler bitmapScalerOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			bitmapScalerOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000059E8 File Offset: 0x00003BE8
		internal unsafe void CreateBitmapClipper(BitmapClipper bitmapClipperOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			bitmapClipperOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00005A30 File Offset: 0x00003C30
		internal unsafe void CreateBitmapFlipRotator(BitmapFlipRotator bitmapFlipRotatorOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			bitmapFlipRotatorOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00005A78 File Offset: 0x00003C78
		internal unsafe void CreateStream(WICStream wICStreamOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			wICStreamOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00005AC0 File Offset: 0x00003CC0
		internal unsafe void CreateColorContext(ColorContext wICColorContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			wICColorContextOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00005B08 File Offset: 0x00003D08
		internal unsafe void CreateColorTransformer(ColorTransform wICColorTransformOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			wICColorTransformOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00005B50 File Offset: 0x00003D50
		internal unsafe void CreateBitmap(int width, int height, Guid ixelFormatRef, BitmapCreateCacheOption option, Bitmap bitmapOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, width, height, &ixelFormatRef, option, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			bitmapOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00005BA0 File Offset: 0x00003DA0
		internal unsafe void CreateBitmapFromSource(BitmapSource bitmapSourceRef, BitmapCreateCacheOption option, Bitmap bitmapOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(bitmapSourceRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, option, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			bitmapOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00005BFC File Offset: 0x00003DFC
		internal unsafe void CreateBitmapFromSourceRect(BitmapSource bitmapSourceRef, int x, int y, int width, int height, Bitmap bitmapOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(bitmapSourceRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, x, y, width, height, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			bitmapOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00005C60 File Offset: 0x00003E60
		internal unsafe void CreateBitmapFromMemory(int width, int height, Guid ixelFormatRef, int stride, int bufferSize, IntPtr bufferRef, Bitmap bitmapOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, width, height, &ixelFormatRef, stride, bufferSize, (void*)bufferRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			bitmapOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00005CBC File Offset: 0x00003EBC
		internal unsafe void CreateBitmapFromHBITMAP(IntPtr hBitmap, IntPtr hPalette, BitmapAlphaChannelOption options, Bitmap bitmapOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)hBitmap, (void*)hPalette, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			bitmapOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00005D14 File Offset: 0x00003F14
		internal unsafe void CreateBitmapFromHICON(IntPtr hIcon, Bitmap bitmapOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hIcon, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			bitmapOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00005D64 File Offset: 0x00003F64
		internal unsafe void CreateComponentEnumerator(int componentTypes, int options, ComObject enumUnknownOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, componentTypes, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			enumUnknownOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005DB0 File Offset: 0x00003FB0
		internal unsafe void CreateFastMetadataEncoderFromDecoder(BitmapDecoder decoderRef, FastMetadataEncoder fastEncoderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapDecoder>(decoderRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			fastEncoderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00005E0C File Offset: 0x0000400C
		internal unsafe void CreateFastMetadataEncoderFromFrameDecode(BitmapFrameDecode frameDecoderRef, FastMetadataEncoder fastEncoderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapFrameDecode>(frameDecoderRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			fastEncoderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00005E68 File Offset: 0x00004068
		internal unsafe void CreateQueryWriter(Guid guidMetadataFormat, Guid? guidVendorRef, MetadataQueryWriter queryWriterOut)
		{
			IntPtr zero = IntPtr.Zero;
			Guid value;
			if (guidVendorRef != null)
			{
				value = guidVendorRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &guidMetadataFormat, (guidVendorRef == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			queryWriterOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00005ED4 File Offset: 0x000040D4
		internal unsafe void CreateQueryWriterFromReader(MetadataQueryReader queryReaderRef, Guid? guidVendorRef, MetadataQueryWriter queryWriterOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<MetadataQueryReader>(queryReaderRef);
			Guid value2;
			if (guidVendorRef != null)
			{
				value2 = guidVendorRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (guidVendorRef == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			queryWriterOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x04000017 RID: 23
		public static readonly Guid WICImagingFactoryClsid = new Guid("cacaf262-9370-4615-a13b-9f5539da4c0a");
	}
}

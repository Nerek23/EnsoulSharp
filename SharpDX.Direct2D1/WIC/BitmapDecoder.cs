using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.IO;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x02000005 RID: 5
	[Guid("9EDDE9E7-8DEE-47ea-99DF-E6FAF2ED44BF")]
	public class BitmapDecoder : ComObject
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00002877 File Offset: 0x00000A77
		public BitmapDecoder(BitmapDecoderInfo bitmapDecoderInfo)
		{
			bitmapDecoderInfo.CreateInstance(this);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002888 File Offset: 0x00000A88
		public BitmapDecoder(ImagingFactory factory, Guid containerFormatGuid)
		{
			factory.CreateDecoder(containerFormatGuid, null, this);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000028AC File Offset: 0x00000AAC
		public BitmapDecoder(ImagingFactory factory, Guid containerFormatGuid, Guid guidVendorRef)
		{
			factory.CreateDecoder(containerFormatGuid, new Guid?(guidVendorRef), this);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000028C4 File Offset: 0x00000AC4
		public BitmapDecoder(ImagingFactory factory, IStream streamRef, DecodeOptions metadataOptions)
		{
			factory.CreateDecoderFromStream(streamRef, null, metadataOptions, this);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000028EC File Offset: 0x00000AEC
		public BitmapDecoder(ImagingFactory factory, Stream streamRef, DecodeOptions metadataOptions)
		{
			this.internalWICStream = new WICStream(factory, streamRef);
			factory.CreateDecoderFromStream(this.internalWICStream, null, metadataOptions, this);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002923 File Offset: 0x00000B23
		public BitmapDecoder(ImagingFactory factory, IStream streamRef, Guid guidVendorRef, DecodeOptions metadataOptions)
		{
			factory.CreateDecoderFromStream(streamRef, new Guid?(guidVendorRef), metadataOptions, this);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000293B File Offset: 0x00000B3B
		public BitmapDecoder(ImagingFactory factory, Stream streamRef, Guid guidVendorRef, DecodeOptions metadataOptions)
		{
			this.internalWICStream = new WICStream(factory, streamRef);
			factory.CreateDecoderFromStream(this.internalWICStream, new Guid?(guidVendorRef), metadataOptions, this);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002968 File Offset: 0x00000B68
		public BitmapDecoder(ImagingFactory factory, string filename, DecodeOptions metadataOptions) : this(factory, filename, null, (NativeFileAccess)2147483648U, metadataOptions)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000298C File Offset: 0x00000B8C
		public BitmapDecoder(ImagingFactory factory, string filename, NativeFileAccess desiredAccess, DecodeOptions metadataOptions) : this(factory, filename, null, desiredAccess, metadataOptions)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000029AD File Offset: 0x00000BAD
		public BitmapDecoder(ImagingFactory factory, string filename, Guid? guidVendorRef, NativeFileAccess desiredAccess, DecodeOptions metadataOptions)
		{
			factory.CreateDecoderFromFilename(filename, guidVendorRef, (int)desiredAccess, metadataOptions, this);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000029C4 File Offset: 0x00000BC4
		public BitmapDecoder(ImagingFactory factory, NativeFileStream fileStream, DecodeOptions metadataOptions)
		{
			factory.CreateDecoderFromFileHandle(fileStream.Handle, null, metadataOptions, this);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000029EE File Offset: 0x00000BEE
		public BitmapDecoder(ImagingFactory factory, NativeFileStream fileStream, Guid guidVendorRef, DecodeOptions metadataOptions)
		{
			factory.CreateDecoderFromFileHandle(fileStream.Handle, new Guid?(guidVendorRef), metadataOptions, this);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002A0B File Offset: 0x00000C0B
		public void Initialize(IStream stream, DecodeOptions cacheOptions)
		{
			if (this.internalWICStream != null)
			{
				throw new InvalidOperationException("This instance is already initialized with an existing stream");
			}
			this.Initialize_(stream, cacheOptions);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002A28 File Offset: 0x00000C28
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				if (this.internalWICStream != null)
				{
					this.internalWICStream.Dispose();
				}
				this.internalWICStream = null;
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002A4E File Offset: 0x00000C4E
		public Result TryGetColorContexts(ImagingFactory imagingFactory, out ColorContext[] colorContexts)
		{
			return ColorContextsHelper.TryGetColorContexts(new ColorContextsProvider(this.GetColorContexts), imagingFactory, out colorContexts);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002A63 File Offset: 0x00000C63
		public ColorContext[] TryGetColorContexts(ImagingFactory imagingFactory)
		{
			return ColorContextsHelper.TryGetColorContexts(new ColorContextsProvider(this.GetColorContexts), imagingFactory);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002A77 File Offset: 0x00000C77
		[Obsolete("Use TryGetColorContexts instead")]
		public ColorContext[] ColorContexts
		{
			get
			{
				return new ColorContext[0];
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002A7F File Offset: 0x00000C7F
		public BitmapDecoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002A88 File Offset: 0x00000C88
		public new static explicit operator BitmapDecoder(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapDecoder(nativePtr);
			}
			return null;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002AA0 File Offset: 0x00000CA0
		public Guid ContainerFormat
		{
			get
			{
				Guid result;
				this.GetContainerFormat(out result);
				return result;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public BitmapDecoderInfo DecoderInfo
		{
			get
			{
				BitmapDecoderInfo result;
				this.GetDecoderInfo(out result);
				return result;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002AD0 File Offset: 0x00000CD0
		public MetadataQueryReader MetadataQueryReader
		{
			get
			{
				MetadataQueryReader result;
				this.GetMetadataQueryReader(out result);
				return result;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002AE8 File Offset: 0x00000CE8
		public BitmapSource Preview
		{
			get
			{
				BitmapSource result;
				this.GetPreview(out result);
				return result;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002B00 File Offset: 0x00000D00
		public BitmapSource Thumbnail
		{
			get
			{
				BitmapSource result;
				this.GetThumbnail(out result);
				return result;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002B18 File Offset: 0x00000D18
		public int FrameCount
		{
			get
			{
				int result;
				this.GetFrameCount(out result);
				return result;
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002B30 File Offset: 0x00000D30
		public unsafe BitmapDecoderCapabilities QueryCapability(IStream streamRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(streamRef);
			BitmapDecoderCapabilities result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002B80 File Offset: 0x00000D80
		internal unsafe void Initialize_(IStream streamRef, DecodeOptions cacheOptions)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(streamRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, cacheOptions, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002BCC File Offset: 0x00000DCC
		internal unsafe void GetContainerFormat(out Guid guidContainerFormatRef)
		{
			guidContainerFormatRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &guidContainerFormatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002C14 File Offset: 0x00000E14
		internal unsafe void GetDecoderInfo(out BitmapDecoderInfo decoderInfoOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				decoderInfoOut = new BitmapDecoderInfo(zero);
			}
			else
			{
				decoderInfoOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002C70 File Offset: 0x00000E70
		public unsafe void CopyPalette(Palette paletteRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Palette>(paletteRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002CBC File Offset: 0x00000EBC
		internal unsafe void GetMetadataQueryReader(out MetadataQueryReader metadataQueryReaderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				metadataQueryReaderOut = new MetadataQueryReader(zero);
			}
			else
			{
				metadataQueryReaderOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002D18 File Offset: 0x00000F18
		internal unsafe void GetPreview(out BitmapSource bitmapSourceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				bitmapSourceOut = new BitmapSource(zero);
			}
			else
			{
				bitmapSourceOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002D74 File Offset: 0x00000F74
		internal unsafe Result GetColorContexts(int count, ColorContext[] colorContextsOut, out int actualCountRef)
		{
			IntPtr* ptr = null;
			if (colorContextsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)colorContextsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (colorContextsOut != null)
			{
				for (int i = 0; i < colorContextsOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<ColorContext>(colorContextsOut[i]);
				}
			}
			Result result;
			fixed (int* ptr2 = &actualCountRef)
			{
				void* ptr3 = (void*)ptr2;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, count, ptr, ptr3, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002DE8 File Offset: 0x00000FE8
		internal unsafe void GetThumbnail(out BitmapSource thumbnailOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				thumbnailOut = new BitmapSource(zero);
			}
			else
			{
				thumbnailOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002E44 File Offset: 0x00001044
		internal unsafe void GetFrameCount(out int countRef)
		{
			Result result;
			fixed (int* ptr = &countRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002E88 File Offset: 0x00001088
		public unsafe BitmapFrameDecode GetFrame(int index)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			BitmapFrameDecode result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new BitmapFrameDecode(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002EE4 File Offset: 0x000010E4
		internal unsafe Result GetColorContexts(int count, ComArray<ColorContext> colorContextsOut, out int actualCountRef)
		{
			Result result;
			fixed (int* ptr = &actualCountRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, count, (void*)((colorContextsOut != null) ? colorContextsOut.NativePointer : IntPtr.Zero), ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002F33 File Offset: 0x00001133
		private unsafe Result GetColorContexts(int count, IntPtr colorContextsOut, IntPtr actualCountRef)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, count, (void*)colorContextsOut, (void*)actualCountRef, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x04000001 RID: 1
		private WICStream internalWICStream;
	}
}

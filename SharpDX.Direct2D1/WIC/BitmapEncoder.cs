using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x02000007 RID: 7
	[Guid("00000103-a8f2-4877-ba0a-fd2b6645fb94")]
	public class BitmapEncoder : ComObject
	{
		// Token: 0x06000059 RID: 89 RVA: 0x000030D4 File Offset: 0x000012D4
		public BitmapEncoder(ImagingFactory factory, Guid containerFormatGuid)
		{
			this.factory = factory;
			factory.CreateEncoder(containerFormatGuid, null, this);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000030FF File Offset: 0x000012FF
		public BitmapEncoder(ImagingFactory factory, Guid containerFormatGuid, Guid guidVendorRef)
		{
			this.factory = factory;
			factory.CreateEncoder(containerFormatGuid, new Guid?(guidVendorRef), this);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000311C File Offset: 0x0000131C
		public BitmapEncoder(ImagingFactory factory, Guid containerFormatGuid, WICStream stream = null)
		{
			this.factory = factory;
			factory.CreateEncoder(containerFormatGuid, null, this);
			if (stream != null)
			{
				this.Initialize(stream);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003154 File Offset: 0x00001354
		public BitmapEncoder(ImagingFactory factory, Guid containerFormatGuid, Stream stream = null)
		{
			this.factory = factory;
			factory.CreateEncoder(containerFormatGuid, null, this);
			if (stream != null)
			{
				this.Initialize(stream);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003189 File Offset: 0x00001389
		public BitmapEncoder(ImagingFactory factory, Guid containerFormatGuid, Guid guidVendorRef, WICStream stream = null)
		{
			this.factory = factory;
			factory.CreateEncoder(containerFormatGuid, new Guid?(guidVendorRef), this);
			if (stream != null)
			{
				this.Initialize(stream);
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000031B2 File Offset: 0x000013B2
		public BitmapEncoder(ImagingFactory factory, Guid containerFormatGuid, Guid guidVendorRef, Stream stream = null)
		{
			this.factory = factory;
			factory.CreateEncoder(containerFormatGuid, new Guid?(guidVendorRef), this);
			if (stream != null)
			{
				this.Initialize(stream);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000031DB File Offset: 0x000013DB
		public void Initialize(IStream stream)
		{
			if (this.internalWICStream != null)
			{
				throw new InvalidOperationException("This instance is already initialized with an existing stream");
			}
			this.Initialize(stream, BitmapEncoderCacheOption.NoCache);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000031F8 File Offset: 0x000013F8
		public void Initialize(Stream stream)
		{
			if (this.internalWICStream != null)
			{
				throw new InvalidOperationException("This instance is already initialized with an existing stream");
			}
			this.internalWICStream = new WICStream(this.factory, stream);
			this.Initialize(this.internalWICStream, BitmapEncoderCacheOption.NoCache);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000322C File Offset: 0x0000142C
		public void SetColorContexts(ColorContext[] colorContextOut)
		{
			this.SetColorContexts((colorContextOut != null) ? colorContextOut.Length : 0, colorContextOut);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000323E File Offset: 0x0000143E
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

		// Token: 0x06000063 RID: 99 RVA: 0x00002A7F File Offset: 0x00000C7F
		public BitmapEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003264 File Offset: 0x00001464
		public new static explicit operator BitmapEncoder(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapEncoder(nativePtr);
			}
			return null;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000065 RID: 101 RVA: 0x0000327C File Offset: 0x0000147C
		public Guid ContainerFormat
		{
			get
			{
				Guid result;
				this.GetContainerFormat(out result);
				return result;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003294 File Offset: 0x00001494
		public BitmapEncoderInfo EncoderInfo
		{
			get
			{
				BitmapEncoderInfo result;
				this.GetEncoderInfo(out result);
				return result;
			}
		}

		// Token: 0x17000017 RID: 23
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000032AA File Offset: 0x000014AA
		public Palette Palette
		{
			set
			{
				this.SetPalette(value);
			}
		}

		// Token: 0x17000018 RID: 24
		// (set) Token: 0x06000068 RID: 104 RVA: 0x000032B3 File Offset: 0x000014B3
		public BitmapSource Thumbnail
		{
			set
			{
				this.SetThumbnail(value);
			}
		}

		// Token: 0x17000019 RID: 25
		// (set) Token: 0x06000069 RID: 105 RVA: 0x000032BC File Offset: 0x000014BC
		public BitmapSource Preview
		{
			set
			{
				this.SetPreview(value);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600006A RID: 106 RVA: 0x000032C8 File Offset: 0x000014C8
		public MetadataQueryWriter MetadataQueryWriter
		{
			get
			{
				MetadataQueryWriter result;
				this.GetMetadataQueryWriter(out result);
				return result;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000032E0 File Offset: 0x000014E0
		internal unsafe void Initialize(IStream streamRef, BitmapEncoderCacheOption cacheOption)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(streamRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, cacheOption, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000332C File Offset: 0x0000152C
		internal unsafe void GetContainerFormat(out Guid guidContainerFormatRef)
		{
			guidContainerFormatRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &guidContainerFormatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003374 File Offset: 0x00001574
		internal unsafe void GetEncoderInfo(out BitmapEncoderInfo encoderInfoOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				encoderInfoOut = new BitmapEncoderInfo(zero);
			}
			else
			{
				encoderInfoOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000033D0 File Offset: 0x000015D0
		internal unsafe void SetColorContexts(int count, ColorContext[] colorContextOut)
		{
			IntPtr* ptr = null;
			if (colorContextOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)colorContextOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (colorContextOut != null)
			{
				for (int i = 0; i < colorContextOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<ColorContext>(colorContextOut[i]);
				}
			}
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, count, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003444 File Offset: 0x00001644
		internal unsafe void SetPalette(Palette paletteRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Palette>(paletteRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003490 File Offset: 0x00001690
		internal unsafe void SetThumbnail(BitmapSource thumbnailRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(thumbnailRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000034DC File Offset: 0x000016DC
		internal unsafe void SetPreview(BitmapSource previewRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(previewRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003528 File Offset: 0x00001728
		internal unsafe void CreateNewFrame(BitmapFrameEncode frameEncodeOut, PropertyBag encoderOptionsOut)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, &zero2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			frameEncodeOut.NativePointer = zero;
			encoderOptionsOut.NativePointer = zero2;
			result.CheckError();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003580 File Offset: 0x00001780
		public unsafe void Commit()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000035B8 File Offset: 0x000017B8
		internal unsafe void GetMetadataQueryWriter(out MetadataQueryWriter metadataQueryWriterOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				metadataQueryWriterOut = new MetadataQueryWriter(zero);
			}
			else
			{
				metadataQueryWriterOut = null;
			}
			result.CheckError();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003614 File Offset: 0x00001814
		internal unsafe void SetColorContexts(int count, ComArray<ColorContext> colorContextOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, count, (void*)((colorContextOut != null) ? colorContextOut.NativePointer : IntPtr.Zero), *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003664 File Offset: 0x00001864
		private unsafe void SetColorContexts(int count, IntPtr colorContextOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, count, (void*)colorContextOut, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x04000002 RID: 2
		private ImagingFactory factory;

		// Token: 0x04000003 RID: 3
		private WICStream internalWICStream;
	}
}

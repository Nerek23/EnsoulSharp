using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x0200000B RID: 11
	[Guid("00000105-a8f2-4877-ba0a-fd2b6645fb94")]
	public class BitmapFrameEncode : ComObject
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00003B1D File Offset: 0x00001D1D
		public BitmapFrameEncode(BitmapEncoder encoder)
		{
			this.Options = new BitmapEncoderOptions(IntPtr.Zero);
			encoder.CreateNewFrame(this, this.Options);
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00003B42 File Offset: 0x00001D42
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00003B4A File Offset: 0x00001D4A
		public BitmapEncoderOptions Options { get; private set; }

		// Token: 0x060000A2 RID: 162 RVA: 0x00003B53 File Offset: 0x00001D53
		public void Initialize()
		{
			this.Initialize(this.Options);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003B61 File Offset: 0x00001D61
		public void SetColorContexts(ColorContext[] colorContextOut)
		{
			this.SetColorContexts((colorContextOut != null) ? colorContextOut.Length : 0, colorContextOut);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003B73 File Offset: 0x00001D73
		public void WritePixels(int lineCount, DataRectangle buffer, int totalSizeInBytes = 0)
		{
			this.WritePixels(lineCount, buffer.DataPointer, buffer.Pitch, totalSizeInBytes);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003B89 File Offset: 0x00001D89
		public void WritePixels(int lineCount, IntPtr buffer, int rowStride, int totalSizeInBytes = 0)
		{
			if (totalSizeInBytes == 0)
			{
				totalSizeInBytes = lineCount * rowStride;
			}
			this.WritePixels(lineCount, rowStride, totalSizeInBytes, buffer);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003BA0 File Offset: 0x00001DA0
		public unsafe void WritePixels<T>(int lineCount, int stride, T[] pixelBuffer) where T : struct
		{
			if (lineCount * stride > Utilities.SizeOf<T>() * pixelBuffer.Length)
			{
				throw new ArgumentException("lineCount * stride must be <= to sizeof(pixelBuffer)");
			}
			int bufferSize = lineCount * stride;
			fixed (T* value = &pixelBuffer[0])
			{
				this.WritePixels(lineCount, stride, bufferSize, (IntPtr)((void*)value));
				return;
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003BDF File Offset: 0x00001DDF
		public void WriteSource(BitmapSource bitmapSource)
		{
			this.WriteSource(bitmapSource, IntPtr.Zero);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003BED File Offset: 0x00001DED
		public unsafe void WriteSource(BitmapSource bitmapSourceRef, RawBox rectangleRef)
		{
			this.WriteSource(bitmapSourceRef, new IntPtr((void*)(&rectangleRef)));
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003BFE File Offset: 0x00001DFE
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Options.Dispose();
				this.Options = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00002A7F File Offset: 0x00000C7F
		public BitmapFrameEncode(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003C1C File Offset: 0x00001E1C
		public new static explicit operator BitmapFrameEncode(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapFrameEncode(nativePtr);
			}
			return null;
		}

		// Token: 0x1700002A RID: 42
		// (set) Token: 0x060000AC RID: 172 RVA: 0x00003C33 File Offset: 0x00001E33
		public Palette Palette
		{
			set
			{
				this.SetPalette(value);
			}
		}

		// Token: 0x1700002B RID: 43
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00003C3C File Offset: 0x00001E3C
		public BitmapSource Thumbnail
		{
			set
			{
				this.SetThumbnail(value);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003C48 File Offset: 0x00001E48
		public MetadataQueryWriter MetadataQueryWriter
		{
			get
			{
				MetadataQueryWriter result;
				this.GetMetadataQueryWriter(out result);
				return result;
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003C60 File Offset: 0x00001E60
		internal unsafe void Initialize(PropertyBag encoderOptionsRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<PropertyBag>(encoderOptionsRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003CAC File Offset: 0x00001EAC
		public unsafe void SetSize(int width, int height)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, width, height, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003CE8 File Offset: 0x00001EE8
		public unsafe void SetResolution(double dpiX, double dpiY)
		{
			calli(System.Int32(System.Void*,System.Double,System.Double), this._nativePointer, dpiX, dpiY, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003D24 File Offset: 0x00001F24
		public unsafe void SetPixelFormat(ref Guid pixelFormatRef)
		{
			Result result;
			fixed (Guid* ptr = &pixelFormatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003D64 File Offset: 0x00001F64
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
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, count, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003DD8 File Offset: 0x00001FD8
		internal unsafe void SetPalette(Palette paletteRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Palette>(paletteRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003E24 File Offset: 0x00002024
		internal unsafe void SetThumbnail(BitmapSource thumbnailRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(thumbnailRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003E70 File Offset: 0x00002070
		internal unsafe void WritePixels(int lineCount, int stride, int bufferSize, IntPtr pixelsRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, lineCount, stride, bufferSize, (void*)pixelsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003EB4 File Offset: 0x000020B4
		internal unsafe void WriteSource(BitmapSource bitmapSourceRef, IntPtr rectangleRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(bitmapSourceRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)rectangleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003F08 File Offset: 0x00002108
		public unsafe void Commit()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003F40 File Offset: 0x00002140
		internal unsafe void GetMetadataQueryWriter(out MetadataQueryWriter metadataQueryWriterOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060000BA RID: 186 RVA: 0x00003F9C File Offset: 0x0000219C
		internal unsafe void SetColorContexts(int count, ComArray<ColorContext> colorContextOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, count, (void*)((colorContextOut != null) ? colorContextOut.NativePointer : IntPtr.Zero), *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003FEC File Offset: 0x000021EC
		private unsafe void SetColorContexts(int count, IntPtr colorContextOut)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, count, (void*)colorContextOut, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

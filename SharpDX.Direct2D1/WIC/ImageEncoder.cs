using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;

namespace SharpDX.WIC
{
	// Token: 0x0200001D RID: 29
	[Guid("04C75BF8-3CE1-473B-ACC5-3CC4F5E94999")]
	public class ImageEncoder : ComObject
	{
		// Token: 0x0600013D RID: 317 RVA: 0x000054BD File Offset: 0x000036BD
		public ImageEncoder(ImagingFactory2 factory, Device d2dDevice)
		{
			factory.CreateImageEncoder(d2dDevice, this);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00002A7F File Offset: 0x00000C7F
		public ImageEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000054CD File Offset: 0x000036CD
		public new static explicit operator ImageEncoder(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ImageEncoder(nativePtr);
			}
			return null;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000054E4 File Offset: 0x000036E4
		public unsafe void WriteFrame(Image imageRef, BitmapFrameEncode frameEncodeRef, ImageParameters imageParametersRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(imageRef);
			value2 = CppObject.ToCallbackPtr<BitmapFrameEncode>(frameEncodeRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, &imageParametersRef, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00005544 File Offset: 0x00003744
		public unsafe void WriteFrameThumbnail(Image imageRef, BitmapFrameEncode frameEncodeRef, ImageParameters imageParametersRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(imageRef);
			value2 = CppObject.ToCallbackPtr<BitmapFrameEncode>(frameEncodeRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, &imageParametersRef, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000055A4 File Offset: 0x000037A4
		public unsafe void WriteThumbnail(Image imageRef, BitmapEncoder encoderRef, ImageParameters imageParametersRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(imageRef);
			value2 = CppObject.ToCallbackPtr<BitmapEncoder>(encoderRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, &imageParametersRef, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

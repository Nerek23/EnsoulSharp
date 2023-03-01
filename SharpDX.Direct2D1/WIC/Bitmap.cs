using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000002 RID: 2
	[Guid("00000121-a8f2-4877-ba0a-fd2b6645fb94")]
	public class Bitmap : BitmapSource
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002057 File Offset: 0x00000257
		public Bitmap(ImagingFactory factory, int width, int height, Guid pixelFormat, BitmapCreateCacheOption option) : base(IntPtr.Zero)
		{
			factory.CreateBitmap(width, height, pixelFormat, option, this);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002071 File Offset: 0x00000271
		public Bitmap(ImagingFactory factory, int width, int height, Guid pixelFormat, DataRectangle dataRectangle, int totalSizeInBytes = 0) : base(IntPtr.Zero)
		{
			if (totalSizeInBytes == 0)
			{
				totalSizeInBytes = height * dataRectangle.Pitch;
			}
			factory.CreateBitmapFromMemory(width, height, pixelFormat, dataRectangle.Pitch, totalSizeInBytes, dataRectangle.DataPointer, this);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020A8 File Offset: 0x000002A8
		public Bitmap(ImagingFactory factory, BitmapSource bitmapSource, BitmapCreateCacheOption option) : base(IntPtr.Zero)
		{
			factory.CreateBitmapFromSource(bitmapSource, option, this);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020BE File Offset: 0x000002BE
		public Bitmap(ImagingFactory factory, BitmapSource bitmapSource, RawBox rectangle) : base(IntPtr.Zero)
		{
			factory.CreateBitmapFromSourceRect(bitmapSource, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, this);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020EC File Offset: 0x000002EC
		public unsafe static Bitmap New<T>(ImagingFactory factory, int width, int height, Guid pixelFormat, T[] pixelDatas, int stride = 0) where T : struct
		{
			if (stride == 0)
			{
				stride = width * Utilities.SizeOf<T>();
			}
			fixed (T* value = &pixelDatas[0])
			{
				return new Bitmap(factory, width, height, pixelFormat, new DataRectangle((IntPtr)((void*)value), stride), 0);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002126 File Offset: 0x00000326
		public BitmapLock Lock(BitmapLockFlags flags)
		{
			return this.Lock(IntPtr.Zero, flags);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002134 File Offset: 0x00000334
		public unsafe BitmapLock Lock(RawBox rcLockRef, BitmapLockFlags flags)
		{
			return this.Lock(new IntPtr((void*)(&rcLockRef)), flags);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002145 File Offset: 0x00000345
		public Bitmap(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000214E File Offset: 0x0000034E
		public new static explicit operator Bitmap(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Bitmap(nativePtr);
			}
			return null;
		}

		// Token: 0x17000001 RID: 1
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002165 File Offset: 0x00000365
		public Palette Palette
		{
			set
			{
				this.SetPalette(value);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002170 File Offset: 0x00000370
		internal unsafe BitmapLock Lock(IntPtr rcLockRef, BitmapLockFlags flags)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)rcLockRef, flags, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			BitmapLock result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new BitmapLock(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021D0 File Offset: 0x000003D0
		internal unsafe void SetPalette(Palette paletteRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Palette>(paletteRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000221C File Offset: 0x0000041C
		public unsafe void SetResolution(double dpiX, double dpiY)
		{
			calli(System.Int32(System.Void*,System.Double,System.Double), this._nativePointer, dpiX, dpiY, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

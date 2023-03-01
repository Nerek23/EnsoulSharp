using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x0200000E RID: 14
	[Guid("00000120-a8f2-4877-ba0a-fd2b6645fb94")]
	public class BitmapSource : ComObject
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00004248 File Offset: 0x00002448
		public Size2 Size
		{
			get
			{
				int width;
				int height;
				this.GetSize(out width, out height);
				return new Size2(width, height);
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004266 File Offset: 0x00002466
		public unsafe void CopyPixels(RawBox rectangle, int stride, DataPointer dataPointer)
		{
			this.CopyPixels(new IntPtr((void*)(&rectangle)), stride, dataPointer.Size, dataPointer.Pointer);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004283 File Offset: 0x00002483
		public void CopyPixels(int stride, DataPointer dataPointer)
		{
			this.CopyPixels(IntPtr.Zero, stride, dataPointer.Size, dataPointer.Pointer);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000429D File Offset: 0x0000249D
		public void CopyPixels(int stride, IntPtr dataPointer, int size)
		{
			this.CopyPixels(IntPtr.Zero, stride, size, dataPointer);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000042B0 File Offset: 0x000024B0
		public unsafe void CopyPixels<T>(RawBox rectangle, T[] output) where T : struct
		{
			if (rectangle.Width * rectangle.Height != output.Length)
			{
				throw new ArgumentException("output.Length must be equal to Width * Height");
			}
			IntPtr rectangleRef = new IntPtr((void*)(&rectangle));
			int stride = rectangle.Width * Utilities.SizeOf<T>();
			int bufferSize = output.Length * Utilities.SizeOf<T>();
			fixed (T* value = &output[0])
			{
				this.CopyPixels(rectangleRef, stride, bufferSize, (IntPtr)((void*)value));
				return;
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000430C File Offset: 0x0000250C
		public unsafe void CopyPixels<T>(T[] output) where T : struct
		{
			Size2 size = this.Size;
			if (size.Width * size.Height != output.Length)
			{
				throw new ArgumentException("output.Length must be equal to Width * Height");
			}
			IntPtr zero = IntPtr.Zero;
			int stride = this.Size.Width * Utilities.SizeOf<T>();
			int bufferSize = output.Length * Utilities.SizeOf<T>();
			fixed (T* value = &output[0])
			{
				this.CopyPixels(zero, stride, bufferSize, (IntPtr)((void*)value));
				return;
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004370 File Offset: 0x00002570
		public unsafe void CopyPixels(RawRectangle rectangle, byte[] output, int stride)
		{
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (stride <= 0)
			{
				throw new ArgumentOutOfRangeException("stride", "Must be > 0");
			}
			if (output.Length % stride != 0)
			{
				throw new ArgumentException("output.Length must be a modulo of stride");
			}
			IntPtr rectangleRef = new IntPtr((void*)(&rectangle));
			int bufferSize = output.Length;
			fixed (byte* value = &output[0])
			{
				this.CopyPixels(rectangleRef, stride, bufferSize, (IntPtr)((void*)value));
				return;
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000043D4 File Offset: 0x000025D4
		public unsafe void CopyPixels(byte[] output, int stride)
		{
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (stride <= 0)
			{
				throw new ArgumentOutOfRangeException("stride", "Must be > 0");
			}
			if (output.Length % stride != 0)
			{
				throw new ArgumentException("output.Length must be a modulo of stride");
			}
			IntPtr zero = IntPtr.Zero;
			int bufferSize = output.Length;
			fixed (byte* value = &output[0])
			{
				this.CopyPixels(zero, stride, bufferSize, (IntPtr)((void*)value));
				return;
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00002A7F File Offset: 0x00000C7F
		public BitmapSource(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004432 File Offset: 0x00002632
		public new static explicit operator BitmapSource(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapSource(nativePtr);
			}
			return null;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x0000444C File Offset: 0x0000264C
		public Guid PixelFormat
		{
			get
			{
				Guid result;
				this.GetPixelFormat(out result);
				return result;
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004464 File Offset: 0x00002664
		internal unsafe void GetSize(out int widthRef, out int heightRef)
		{
			Result result;
			fixed (int* ptr = &heightRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &widthRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000044B0 File Offset: 0x000026B0
		internal unsafe void GetPixelFormat(out Guid pixelFormatRef)
		{
			pixelFormatRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &pixelFormatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000044F8 File Offset: 0x000026F8
		public unsafe void GetResolution(out double dpiXRef, out double dpiYRef)
		{
			Result result;
			fixed (double* ptr = &dpiYRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (double* ptr3 = &dpiXRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004544 File Offset: 0x00002744
		public unsafe void CopyPalette(Palette paletteRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Palette>(paletteRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004590 File Offset: 0x00002790
		internal unsafe void CopyPixels(IntPtr rectangleRef, int stride, int bufferSize, IntPtr bufferRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)rectangleRef, stride, bufferSize, (void*)bufferRef, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

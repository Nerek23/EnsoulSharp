using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000027 RID: 39
	[Guid("00000040-a8f2-4877-ba0a-fd2b6645fb94")]
	public class Palette : ComObject
	{
		// Token: 0x06000190 RID: 400 RVA: 0x000067B2 File Offset: 0x000049B2
		public Palette(ImagingFactory factory) : base(IntPtr.Zero)
		{
			factory.CreatePalette(this);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x000067C8 File Offset: 0x000049C8
		public unsafe void Initialize<T>(T[] colors) where T : struct
		{
			if (Utilities.SizeOf<T>() != 4)
			{
				throw new ArgumentException("Color type must be 4 bytes RGBA");
			}
			fixed (T* ptr = &colors[0])
			{
				void* value = (void*)ptr;
				this.Initialize((IntPtr)value, colors.Length);
				return;
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00006804 File Offset: 0x00004A04
		public unsafe T[] GetColors<T>() where T : struct
		{
			if (Utilities.SizeOf<T>() != 4)
			{
				throw new ArgumentException("Color type must be 4 bytes RGBA");
			}
			int colorCount = this.ColorCount;
			T[] array = new T[colorCount];
			fixed (T* ptr = &array[0])
			{
				void* value = (void*)ptr;
				int num;
				this.GetColors(colorCount, (IntPtr)value, out num);
				if (num == 0)
				{
					return new T[0];
				}
				if (colorCount != num)
				{
					array = new T[num];
					fixed (T* ptr2 = &array[0])
					{
						void* value2 = (void*)ptr2;
						this.GetColors(num, (IntPtr)value2, out num);
					}
				}
				return array;
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00002A7F File Offset: 0x00000C7F
		public Palette(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00006888 File Offset: 0x00004A88
		public new static explicit operator Palette(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Palette(nativePtr);
			}
			return null;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000195 RID: 405 RVA: 0x000068A0 File Offset: 0x00004AA0
		public BitmapPaletteType TypeInfo
		{
			get
			{
				BitmapPaletteType result;
				this.GetTypeInfo(out result);
				return result;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000196 RID: 406 RVA: 0x000068B8 File Offset: 0x00004AB8
		public int ColorCount
		{
			get
			{
				int result;
				this.GetColorCount(out result);
				return result;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000197 RID: 407 RVA: 0x000068D0 File Offset: 0x00004AD0
		public RawBool IsBlackWhite
		{
			get
			{
				RawBool result;
				this.IsBlackWhite_(out result);
				return result;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000198 RID: 408 RVA: 0x000068E8 File Offset: 0x00004AE8
		public RawBool IsGrayscale
		{
			get
			{
				RawBool result;
				this.IsGrayscale_(out result);
				return result;
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00006900 File Offset: 0x00004B00
		public unsafe void Initialize(BitmapPaletteType ePaletteType, RawBool fAddTransparentColor)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, ePaletteType, fAddTransparentColor, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000693C File Offset: 0x00004B3C
		internal unsafe void Initialize(IntPtr colorsRef, int count)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)colorsRef, count, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000697C File Offset: 0x00004B7C
		public unsafe void Initialize(BitmapSource surfaceRef, int count, RawBool fAddTransparentColor)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(surfaceRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, (void*)value, count, fAddTransparentColor, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x000069C8 File Offset: 0x00004BC8
		public unsafe void Initialize(Palette paletteRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Palette>(paletteRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00006A14 File Offset: 0x00004C14
		internal unsafe void GetTypeInfo(out BitmapPaletteType ePaletteTypeRef)
		{
			Result result;
			fixed (BitmapPaletteType* ptr = &ePaletteTypeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00006A54 File Offset: 0x00004C54
		internal unsafe void GetColorCount(out int countRef)
		{
			Result result;
			fixed (int* ptr = &countRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00006A94 File Offset: 0x00004C94
		internal unsafe void GetColors(int count, IntPtr colorsRef, out int actualColorsRef)
		{
			Result result;
			fixed (int* ptr = &actualColorsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, count, (void*)colorsRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00006ADC File Offset: 0x00004CDC
		internal unsafe void IsBlackWhite_(out RawBool fIsBlackWhiteRef)
		{
			fIsBlackWhiteRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fIsBlackWhiteRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00006B24 File Offset: 0x00004D24
		internal unsafe void IsGrayscale_(out RawBool fIsGrayscaleRef)
		{
			fIsGrayscaleRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fIsGrayscaleRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00006B6C File Offset: 0x00004D6C
		public unsafe void HasAlpha(out RawBool fHasAlphaRef)
		{
			fHasAlphaRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fHasAlphaRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}

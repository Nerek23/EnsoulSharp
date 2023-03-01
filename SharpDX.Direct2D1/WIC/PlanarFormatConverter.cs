using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000074 RID: 116
	[Guid("BEBEE9CB-83B0-4DCC-8132-B0AAA55EAC96")]
	public class PlanarFormatConverter : BitmapSource
	{
		// Token: 0x06000258 RID: 600 RVA: 0x00002145 File Offset: 0x00000345
		public PlanarFormatConverter(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00009AB0 File Offset: 0x00007CB0
		public new static explicit operator PlanarFormatConverter(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PlanarFormatConverter(nativePtr);
			}
			return null;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00009AC8 File Offset: 0x00007CC8
		public unsafe void Initialize(BitmapSource[] planesOut, int planes, Guid dstFormat, BitmapDitherType dither, Palette paletteRef, double alphaThresholdPercent, BitmapPaletteType paletteTranslate)
		{
			IntPtr* ptr = null;
			if (planesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)planesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			IntPtr value = IntPtr.Zero;
			if (planesOut != null)
			{
				for (int i = 0; i < planesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<BitmapSource>(planesOut[i]);
				}
			}
			value = CppObject.ToCallbackPtr<Palette>(paletteRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*,System.Double,System.Int32), this._nativePointer, ptr, planes, &dstFormat, dither, (void*)value, alphaThresholdPercent, paletteTranslate, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00009B58 File Offset: 0x00007D58
		public unsafe void CanConvert(Guid[] srcPixelFormatsRef, int srcPlanes, Guid dstPixelFormat, out RawBool fCanConvertRef)
		{
			fCanConvertRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fCanConvertRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (Guid[] array = srcPixelFormatsRef)
				{
					void* ptr3;
					if (srcPixelFormatsRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, ptr3, srcPlanes, &dstPixelFormat, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00009BC8 File Offset: 0x00007DC8
		public unsafe void Initialize(ComArray<BitmapSource> planesOut, int planes, Guid dstFormat, BitmapDitherType dither, Palette paletteRef, double alphaThresholdPercent, BitmapPaletteType paletteTranslate)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Palette>(paletteRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*,System.Double,System.Int32), this._nativePointer, (void*)((planesOut != null) ? planesOut.NativePointer : IntPtr.Zero), planes, &dstFormat, dither, (void*)value, alphaThresholdPercent, paletteTranslate, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00009C34 File Offset: 0x00007E34
		private unsafe void Initialize(IntPtr planesOut, int planes, IntPtr dstFormat, BitmapDitherType dither, IntPtr paletteRef, double alphaThresholdPercent, BitmapPaletteType paletteTranslate)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*,System.Double,System.Int32), this._nativePointer, (void*)planesOut, planes, (void*)dstFormat, dither, (void*)paletteRef, alphaThresholdPercent, paletteTranslate, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

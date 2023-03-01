using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x02000006 RID: 6
	[Guid("D8CD007F-D08F-4191-9BFC-236EA7F0E4B5")]
	public class BitmapDecoderInfo : BitmapCodecInfo
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002F68 File Offset: 0x00001168
		public BitmapPattern[] Patterns
		{
			get
			{
				int num = 0;
				int sizePatterns = 0;
				this.GetPatterns(0, null, out sizePatterns, out num);
				if (num == 0)
				{
					return new BitmapPattern[0];
				}
				sizePatterns = num;
				BitmapPattern[] array = new BitmapPattern[num];
				this.GetPatterns(sizePatterns, array, out sizePatterns, out num);
				return array;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002FA5 File Offset: 0x000011A5
		public BitmapDecoderInfo(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002FAE File Offset: 0x000011AE
		public new static explicit operator BitmapDecoderInfo(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapDecoderInfo(nativePtr);
			}
			return null;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002FC8 File Offset: 0x000011C8
		internal unsafe void GetPatterns(int sizePatterns, BitmapPattern[] patternsRef, out int atternCountRef, out int patternsActualRef)
		{
			Result result;
			fixed (int* ptr = &patternsActualRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &atternCountRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (BitmapPattern[] array = patternsRef)
					{
						void* ptr5;
						if (patternsRef == null || array.Length == 0)
						{
							ptr5 = null;
						}
						else
						{
							ptr5 = (void*)(&array[0]);
						}
						result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, sizePatterns, ptr5, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000303C File Offset: 0x0000123C
		public unsafe RawBool MatchesPattern(IStream streamRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(streamRef);
			RawBool result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000308C File Offset: 0x0000128C
		internal unsafe void CreateInstance(BitmapDecoder bitmapDecoderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			bitmapDecoderOut.NativePointer = zero;
			result.CheckError();
		}
	}
}

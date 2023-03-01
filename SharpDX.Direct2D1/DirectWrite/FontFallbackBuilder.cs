using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000134 RID: 308
	[Guid("FD882D06-8ABA-4FB8-B849-8BE8B73E14DE")]
	public class FontFallbackBuilder : ComObject
	{
		// Token: 0x060005A5 RID: 1445 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontFallbackBuilder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x000122B5 File Offset: 0x000104B5
		public new static explicit operator FontFallbackBuilder(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFallbackBuilder(nativePtr);
			}
			return null;
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x000122CC File Offset: 0x000104CC
		public unsafe void AddMapping(UnicodeRange[] ranges, int rangesCount, string targetFamilyNames, int targetFamilyNamesCount, FontCollection fontCollection, string localeName, string baseFamilyName, float scale)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontCollection>(fontCollection);
			Result result;
			fixed (string text = baseFamilyName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				fixed (string text2 = localeName)
				{
					char* ptr2 = text2;
					if (ptr2 != null)
					{
						ptr2 += RuntimeHelpers.OffsetToStringData / 2;
					}
					fixed (string text3 = targetFamilyNames)
					{
						char* ptr3 = text3;
						if (ptr3 != null)
						{
							ptr3 += RuntimeHelpers.OffsetToStringData / 2;
						}
						fixed (UnicodeRange[] array = ranges)
						{
							void* ptr4;
							if (ranges == null || array.Length == 0)
							{
								ptr4 = null;
							}
							else
							{
								ptr4 = (void*)(&array[0]);
							}
							result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Single), this._nativePointer, ptr4, rangesCount, ptr3, targetFamilyNamesCount, (void*)value, ptr2, ptr, scale, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0001238C File Offset: 0x0001058C
		public unsafe void AddMappings(FontFallback fontFallback)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFallback>(fontFallback);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x000123D8 File Offset: 0x000105D8
		public unsafe void CreateFontFallback(out FontFallback fontFallback)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFallback = new FontFallback(zero);
			}
			else
			{
				fontFallback = null;
			}
			result.CheckError();
		}
	}
}

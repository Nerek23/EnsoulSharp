using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000133 RID: 307
	[Guid("EFA008F9-F7A1-48BF-B05C-F224713CC0FF")]
	public class FontFallback : ComObject
	{
		// Token: 0x060005A2 RID: 1442 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontFallback(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x000121D6 File Offset: 0x000103D6
		public new static explicit operator FontFallback(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFallback(nativePtr);
			}
			return null;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x000121F0 File Offset: 0x000103F0
		public unsafe void MapCharacters(TextAnalysisSource analysisSource, int textPosition, int textLength, FontCollection baseFontCollection, string baseFamilyName, FontWeight baseWeight, FontStyle baseStyle, FontStretch baseStretch, out int mappedLength, out Font mappedFont, out float scale)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextAnalysisSource>(analysisSource);
			value2 = CppObject.ToCallbackPtr<FontCollection>(baseFontCollection);
			Result result;
			fixed (float* ptr = &scale)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &mappedLength)
				{
					void* ptr4 = (void*)ptr3;
					fixed (string text = baseFamilyName)
					{
						char* ptr5 = text;
						if (ptr5 != null)
						{
							ptr5 += RuntimeHelpers.OffsetToStringData / 2;
						}
						result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, textPosition, textLength, (void*)value2, ptr5, baseWeight, baseStyle, baseStretch, ptr4, &zero, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
					}
				}
			}
			if (zero != IntPtr.Zero)
			{
				mappedFont = new Font(zero);
			}
			else
			{
				mappedFont = null;
			}
			result.CheckError();
		}
	}
}

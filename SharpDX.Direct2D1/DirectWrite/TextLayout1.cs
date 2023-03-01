using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000148 RID: 328
	[Guid("9064D822-80A7-465C-A986-DF65F78B8FEB")]
	public class TextLayout1 : TextLayout
	{
		// Token: 0x0600062B RID: 1579 RVA: 0x00014130 File Offset: 0x00012330
		public TextLayout1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00014139 File Offset: 0x00012339
		public new static explicit operator TextLayout1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextLayout1(nativePtr);
			}
			return null;
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00014150 File Offset: 0x00012350
		public unsafe void SetPairKerning(RawBool isPairKerningEnabled, TextRange textRange)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool,SharpDX.DirectWrite.TextRange), this._nativePointer, isPairKerningEnabled, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)67 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001418C File Offset: 0x0001238C
		public unsafe void GetPairKerning(int currentPosition, out RawBool isPairKerningEnabled, out TextRange textRange)
		{
			isPairKerningEnabled = default(RawBool);
			textRange = default(TextRange);
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &isPairKerningEnabled)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, currentPosition, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)68 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x000141E8 File Offset: 0x000123E8
		public unsafe void SetCharacterSpacing(float leadingSpacing, float trailingSpacing, float minimumAdvanceWidth, TextRange textRange)
		{
			calli(System.Int32(System.Void*,System.Single,System.Single,System.Single,SharpDX.DirectWrite.TextRange), this._nativePointer, leadingSpacing, trailingSpacing, minimumAdvanceWidth, textRange, *(*(IntPtr*)this._nativePointer + (IntPtr)69 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00014228 File Offset: 0x00012428
		public unsafe void GetCharacterSpacing(int currentPosition, out float leadingSpacing, out float trailingSpacing, out float minimumAdvanceWidth, out TextRange textRange)
		{
			textRange = default(TextRange);
			Result result;
			fixed (TextRange* ptr = &textRange)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &minimumAdvanceWidth)
				{
					void* ptr4 = (void*)ptr3;
					fixed (float* ptr5 = &trailingSpacing)
					{
						void* ptr6 = (void*)ptr5;
						fixed (float* ptr7 = &leadingSpacing)
						{
							void* ptr8 = (void*)ptr7;
							result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, currentPosition, ptr8, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)70 * (IntPtr)sizeof(void*)));
						}
					}
				}
			}
			result.CheckError();
		}
	}
}

using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000131 RID: 305
	[Guid("27F2A904-4EB8-441D-9678-0563F53E3E2F")]
	public class FontFace4 : FontFace3
	{
		// Token: 0x06000585 RID: 1413 RVA: 0x00011D17 File Offset: 0x0000FF17
		public FontFace4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00011D20 File Offset: 0x0000FF20
		public new static explicit operator FontFace4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFace4(nativePtr);
			}
			return null;
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00011D38 File Offset: 0x0000FF38
		public unsafe void GetGlyphImageFormats(short glyphId, int pixelsPerEmFirst, int pixelsPerEmLast, out GlyphImageFormatS glyphImageFormats)
		{
			Result result;
			fixed (GlyphImageFormatS* ptr = &glyphImageFormats)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int16,System.Int32,System.Int32,System.Void*), this._nativePointer, glyphId, pixelsPerEmFirst, pixelsPerEmLast, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)49 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00011D7D File Offset: 0x0000FF7D
		public unsafe GlyphImageFormatS GetGlyphImageFormats()
		{
			return calli(SharpDX.Direct2D1.GlyphImageFormatS(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)50 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00011DA0 File Offset: 0x0000FFA0
		public unsafe void GetGlyphImageData(short glyphId, int pixelsPerEm, GlyphImageFormatS glyphImageFormat, out GlyphImageData glyphData, out IntPtr glyphDataContext)
		{
			glyphData = default(GlyphImageData);
			Result result;
			fixed (IntPtr* ptr = &glyphDataContext)
			{
				void* ptr2 = (void*)ptr;
				fixed (GlyphImageData* ptr3 = &glyphData)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int16,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, glyphId, pixelsPerEm, glyphImageFormat, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)51 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00011DFA File Offset: 0x0000FFFA
		public unsafe void ReleaseGlyphImageData(IntPtr glyphDataContext)
		{
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)glyphDataContext, *(*(IntPtr*)this._nativePointer + (IntPtr)52 * (IntPtr)sizeof(void*)));
		}
	}
}

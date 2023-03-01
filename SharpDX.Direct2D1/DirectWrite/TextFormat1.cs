using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000146 RID: 326
	[Guid("5F174B49-0D8B-4CFB-8BCA-F1CCE9D06C67")]
	public class TextFormat1 : TextFormat
	{
		// Token: 0x06000613 RID: 1555 RVA: 0x0000F102 File Offset: 0x0000D302
		public TextFormat1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00013E3E File Offset: 0x0001203E
		public new static explicit operator TextFormat1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextFormat1(nativePtr);
			}
			return null;
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x00013E55 File Offset: 0x00012055
		// (set) Token: 0x06000616 RID: 1558 RVA: 0x00013E5D File Offset: 0x0001205D
		public VerticalGlyphOrientation VerticalGlyphOrientation
		{
			get
			{
				return this.GetVerticalGlyphOrientation();
			}
			set
			{
				this.SetVerticalGlyphOrientation(value);
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000617 RID: 1559 RVA: 0x00013E66 File Offset: 0x00012066
		// (set) Token: 0x06000618 RID: 1560 RVA: 0x00013E6E File Offset: 0x0001206E
		public RawBool LastLineWrapping
		{
			get
			{
				return this.GetLastLineWrapping();
			}
			set
			{
				this.SetLastLineWrapping(value);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x00013E77 File Offset: 0x00012077
		// (set) Token: 0x0600061A RID: 1562 RVA: 0x00013E7F File Offset: 0x0001207F
		public OptimizationIcalAlignment OpticalAlignment
		{
			get
			{
				return this.GetOpticalAlignment();
			}
			set
			{
				this.SetOpticalAlignment(value);
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x00013E88 File Offset: 0x00012088
		// (set) Token: 0x0600061C RID: 1564 RVA: 0x00013E9E File Offset: 0x0001209E
		public FontFallback FontFallback
		{
			get
			{
				FontFallback result;
				this.GetFontFallback(out result);
				return result;
			}
			set
			{
				this.SetFontFallback(value);
			}
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00013EA8 File Offset: 0x000120A8
		internal unsafe void SetVerticalGlyphOrientation(VerticalGlyphOrientation glyphOrientation)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, glyphOrientation, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00013EE1 File Offset: 0x000120E1
		internal unsafe VerticalGlyphOrientation GetVerticalGlyphOrientation()
		{
			return calli(SharpDX.DirectWrite.VerticalGlyphOrientation(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00013F04 File Offset: 0x00012104
		internal unsafe void SetLastLineWrapping(RawBool isLastLineWrappingEnabled)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, isLastLineWrappingEnabled, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00013F3D File Offset: 0x0001213D
		internal unsafe RawBool GetLastLineWrapping()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00013F60 File Offset: 0x00012160
		internal unsafe void SetOpticalAlignment(OptimizationIcalAlignment opticalAlignment)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, opticalAlignment, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00013F99 File Offset: 0x00012199
		internal unsafe OptimizationIcalAlignment GetOpticalAlignment()
		{
			return calli(SharpDX.DirectWrite.OptimizationIcalAlignment(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00013FBC File Offset: 0x000121BC
		internal unsafe void SetFontFallback(FontFallback fontFallback)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFallback>(fontFallback);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00014008 File Offset: 0x00012208
		internal unsafe void GetFontFallback(out FontFallback fontFallback)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
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

using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000149 RID: 329
	[Guid("1093C18F-8D5E-43F0-B064-0917311B525E")]
	public class TextLayout2 : TextLayout1
	{
		// Token: 0x06000631 RID: 1585 RVA: 0x0001429C File Offset: 0x0001249C
		public TextLayout2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x000142A5 File Offset: 0x000124A5
		public new static explicit operator TextLayout2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextLayout2(nativePtr);
			}
			return null;
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x000142BC File Offset: 0x000124BC
		public new TextMetrics1 Metrics
		{
			get
			{
				TextMetrics1 result;
				this.GetMetrics(out result);
				return result;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x000142D2 File Offset: 0x000124D2
		// (set) Token: 0x06000635 RID: 1589 RVA: 0x000142DA File Offset: 0x000124DA
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

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000636 RID: 1590 RVA: 0x000142E3 File Offset: 0x000124E3
		// (set) Token: 0x06000637 RID: 1591 RVA: 0x000142EB File Offset: 0x000124EB
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

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x000142F4 File Offset: 0x000124F4
		// (set) Token: 0x06000639 RID: 1593 RVA: 0x000142FC File Offset: 0x000124FC
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

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x00014308 File Offset: 0x00012508
		// (set) Token: 0x0600063B RID: 1595 RVA: 0x0001431E File Offset: 0x0001251E
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

		// Token: 0x0600063C RID: 1596 RVA: 0x00014328 File Offset: 0x00012528
		internal unsafe void GetMetrics(out TextMetrics1 textMetrics)
		{
			textMetrics = default(TextMetrics1);
			Result result;
			fixed (TextMetrics1* ptr = &textMetrics)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)71 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00014370 File Offset: 0x00012570
		internal unsafe void SetVerticalGlyphOrientation(VerticalGlyphOrientation glyphOrientation)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, glyphOrientation, *(*(IntPtr*)this._nativePointer + (IntPtr)72 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x000143A9 File Offset: 0x000125A9
		internal unsafe VerticalGlyphOrientation GetVerticalGlyphOrientation()
		{
			return calli(SharpDX.DirectWrite.VerticalGlyphOrientation(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)73 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x000143CC File Offset: 0x000125CC
		internal unsafe void SetLastLineWrapping(RawBool isLastLineWrappingEnabled)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, isLastLineWrappingEnabled, *(*(IntPtr*)this._nativePointer + (IntPtr)74 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x00014405 File Offset: 0x00012605
		internal unsafe RawBool GetLastLineWrapping()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)75 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x00014428 File Offset: 0x00012628
		internal unsafe void SetOpticalAlignment(OptimizationIcalAlignment opticalAlignment)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, opticalAlignment, *(*(IntPtr*)this._nativePointer + (IntPtr)76 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00014461 File Offset: 0x00012661
		internal unsafe OptimizationIcalAlignment GetOpticalAlignment()
		{
			return calli(SharpDX.DirectWrite.OptimizationIcalAlignment(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)77 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x00014484 File Offset: 0x00012684
		internal unsafe void SetFontFallback(FontFallback fontFallback)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFallback>(fontFallback);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)78 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x000144D0 File Offset: 0x000126D0
		internal unsafe void GetFontFallback(out FontFallback fontFallback)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)79 * (IntPtr)sizeof(void*)));
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

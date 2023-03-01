using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000088 RID: 136
	[Guid("0439fc60-ca44-4994-8dee-3a9af7b732ec")]
	public class Factory2 : Factory1
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x0000AEE0 File Offset: 0x000090E0
		public void TranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, MeasuringMode measuringMode, RawMatrix3x2? worldToDeviceTransform, int colorPaletteIndex, out ColorGlyphRunEnumerator colorLayers)
		{
			this.TryTranslateColorGlyphRun(baselineOriginX, baselineOriginY, glyphRun, glyphRunDescription, measuringMode, worldToDeviceTransform, colorPaletteIndex, out colorLayers).CheckError();
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000AF08 File Offset: 0x00009108
		public ColorGlyphRunEnumerator TranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, MeasuringMode measuringMode, RawMatrix3x2? worldToDeviceTransform, int colorPaletteIndex)
		{
			ColorGlyphRunEnumerator result;
			this.TranslateColorGlyphRun(baselineOriginX, baselineOriginY, glyphRun, glyphRunDescription, measuringMode, worldToDeviceTransform, colorPaletteIndex, out result);
			return result;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000AF29 File Offset: 0x00009129
		public Factory2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000AF32 File Offset: 0x00009132
		public new static explicit operator Factory2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory2(nativePtr);
			}
			return null;
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x0000AF4C File Offset: 0x0000914C
		public FontFallback SystemFontFallback
		{
			get
			{
				FontFallback result;
				this.GetSystemFontFallback(out result);
				return result;
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000AF64 File Offset: 0x00009164
		internal unsafe void GetSystemFontFallback(out FontFallback fontFallback)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060002B9 RID: 697 RVA: 0x0000AFC0 File Offset: 0x000091C0
		public unsafe void CreateFontFallbackBuilder(out FontFallbackBuilder fontFallbackBuilder)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFallbackBuilder = new FontFallbackBuilder(zero);
			}
			else
			{
				fontFallbackBuilder = null;
			}
			result.CheckError();
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000B01C File Offset: 0x0000921C
		public unsafe Result TryTranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, MeasuringMode measuringMode, RawMatrix3x2? worldToDeviceTransform, int colorPaletteIndex, out ColorGlyphRunEnumerator colorLayers)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			GlyphRunDescription.__Native _Native2 = default(GlyphRunDescription.__Native);
			IntPtr zero = IntPtr.Zero;
			glyphRun.__MarshalTo(ref _Native);
			if (glyphRunDescription != null)
			{
				glyphRunDescription.__MarshalTo(ref _Native2);
			}
			RawMatrix3x2 value;
			if (worldToDeviceTransform != null)
			{
				value = worldToDeviceTransform.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, baselineOriginX, baselineOriginY, &_Native, (glyphRunDescription == null) ? null : (&_Native2), measuringMode, (worldToDeviceTransform == null) ? null : (&value), colorPaletteIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				colorLayers = new ColorGlyphRunEnumerator(zero);
			}
			else
			{
				colorLayers = null;
			}
			glyphRun.__MarshalFree(ref _Native);
			if (glyphRunDescription != null)
			{
				glyphRunDescription.__MarshalFree(ref _Native2);
			}
			return result;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000B0E0 File Offset: 0x000092E0
		public unsafe void CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel, PixelGeometry pixelGeometry, RenderingMode renderingMode, GridFitMode gridFitMode, out RenderingParams2 renderingParams)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Single,System.Single,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, gamma, enhancedContrast, grayscaleEnhancedContrast, clearTypeLevel, pixelGeometry, renderingMode, gridFitMode, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				renderingParams = new RenderingParams2(zero);
			}
			else
			{
				renderingParams = null;
			}
			result.CheckError();
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000B148 File Offset: 0x00009348
		public unsafe void CreateGlyphRunAnalysis(GlyphRun glyphRun, RawMatrix3x2? transform, RenderingMode renderingMode, MeasuringMode measuringMode, GridFitMode gridFitMode, TextAntialiasMode antialiasMode, float baselineOriginX, float baselineOriginY, out GlyphRunAnalysis glyphRunAnalysis)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			IntPtr zero = IntPtr.Zero;
			glyphRun.__MarshalTo(ref _Native);
			RawMatrix3x2 value;
			if (transform != null)
			{
				value = transform.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Single,System.Single,System.Void*), this._nativePointer, &_Native, (transform == null) ? null : (&value), renderingMode, measuringMode, gridFitMode, antialiasMode, baselineOriginX, baselineOriginY, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				glyphRunAnalysis = new GlyphRunAnalysis(zero);
			}
			else
			{
				glyphRunAnalysis = null;
			}
			glyphRun.__MarshalFree(ref _Native);
			result.CheckError();
		}
	}
}

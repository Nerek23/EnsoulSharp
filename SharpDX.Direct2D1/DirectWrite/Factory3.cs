using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000124 RID: 292
	[Guid("9A1B41C3-D3BB-466A-87FC-FE67556A3B65")]
	public class Factory3 : Factory2
	{
		// Token: 0x060004FD RID: 1277 RVA: 0x0001019D File Offset: 0x0000E39D
		public Factory3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x000101A6 File Offset: 0x0000E3A6
		public new static explicit operator Factory3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory3(nativePtr);
			}
			return null;
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x000101C0 File Offset: 0x0000E3C0
		public FontSet SystemFontSet
		{
			get
			{
				FontSet result;
				this.GetSystemFontSet(out result);
				return result;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x000101D8 File Offset: 0x0000E3D8
		public FontDownloadQueue FontDownloadQueue
		{
			get
			{
				FontDownloadQueue result;
				this.GetFontDownloadQueue(out result);
				return result;
			}
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x000101F0 File Offset: 0x0000E3F0
		public unsafe void CreateGlyphRunAnalysis(GlyphRun glyphRun, RawMatrix3x2? transform, RenderingMode1 renderingMode, MeasuringMode measuringMode, GridFitMode gridFitMode, TextAntialiasMode antialiasMode, float baselineOriginX, float baselineOriginY, out GlyphRunAnalysis glyphRunAnalysis)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			IntPtr zero = IntPtr.Zero;
			glyphRun.__MarshalTo(ref _Native);
			RawMatrix3x2 value;
			if (transform != null)
			{
				value = transform.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Single,System.Single,System.Void*), this._nativePointer, &_Native, (transform == null) ? null : (&value), renderingMode, measuringMode, gridFitMode, antialiasMode, baselineOriginX, baselineOriginY, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000502 RID: 1282 RVA: 0x00010294 File Offset: 0x0000E494
		public unsafe void CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel, PixelGeometry pixelGeometry, RenderingMode1 renderingMode, GridFitMode gridFitMode, out RenderingParams3 renderingParams)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Single,System.Single,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, gamma, enhancedContrast, grayscaleEnhancedContrast, clearTypeLevel, pixelGeometry, renderingMode, gridFitMode, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				renderingParams = new RenderingParams3(zero);
			}
			else
			{
				renderingParams = null;
			}
			result.CheckError();
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x000102FC File Offset: 0x0000E4FC
		public unsafe void CreateFontFaceReference(FontFile fontFile, int faceIndex, FontSimulations fontSimulations, out FontFaceReference fontFaceReference)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFile>(fontFile);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, faceIndex, fontSimulations, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFaceReference = new FontFaceReference(zero);
			}
			else
			{
				fontFaceReference = null;
			}
			result.CheckError();
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00010370 File Offset: 0x0000E570
		public unsafe void CreateFontFaceReference(string filePath, long? lastWriteTime, int faceIndex, FontSimulations fontSimulations, out FontFaceReference fontFaceReference)
		{
			IntPtr zero = IntPtr.Zero;
			long value;
			if (lastWriteTime != null)
			{
				value = lastWriteTime.Value;
			}
			Result result;
			fixed (string text = filePath)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, ptr, (lastWriteTime == null) ? null : (&value), faceIndex, fontSimulations, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				fontFaceReference = new FontFaceReference(zero);
			}
			else
			{
				fontFaceReference = null;
			}
			result.CheckError();
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00010408 File Offset: 0x0000E608
		internal unsafe void GetSystemFontSet(out FontSet fontSet)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontSet = new FontSet(zero);
			}
			else
			{
				fontSet = null;
			}
			result.CheckError();
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00010464 File Offset: 0x0000E664
		public unsafe void CreateFontSetBuilder(out FontSetBuilder fontSetBuilder)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontSetBuilder = new FontSetBuilder(zero);
			}
			else
			{
				fontSetBuilder = null;
			}
			result.CheckError();
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x000104C0 File Offset: 0x0000E6C0
		public unsafe void CreateFontCollectionFromFontSet(FontSet fontSet, out FontCollection1 fontCollection)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontSet>(fontSet);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontCollection = new FontCollection1(zero);
			}
			else
			{
				fontCollection = null;
			}
			result.CheckError();
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00010530 File Offset: 0x0000E730
		public unsafe void GetSystemFontCollection(RawBool includeDownloadableFonts, out FontCollection1 fontCollection, RawBool checkForUpdates)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, includeDownloadableFonts, &zero, checkForUpdates, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontCollection = new FontCollection1(zero);
			}
			else
			{
				fontCollection = null;
			}
			result.CheckError();
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00010590 File Offset: 0x0000E790
		internal unsafe void GetFontDownloadQueue(out FontDownloadQueue fontDownloadQueue)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontDownloadQueue = new FontDownloadQueue(zero);
			}
			else
			{
				fontDownloadQueue = null;
			}
			result.CheckError();
		}
	}
}

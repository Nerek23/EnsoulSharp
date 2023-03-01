using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000086 RID: 134
	[Guid("b859ee5a-d838-4b5b-a2e8-1adc7d93db48")]
	public class Factory : ComObject
	{
		// Token: 0x0600028B RID: 651 RVA: 0x0000A310 File Offset: 0x00008510
		internal FontCollectionLoader FindRegisteredFontCollectionLoaderCallback(FontCollectionLoader loader)
		{
			foreach (FontCollectionLoader fontCollectionLoader in this._fontCollectionLoaderCallbacks)
			{
				if (fontCollectionLoader == loader)
				{
					return fontCollectionLoader;
				}
			}
			return null;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000A368 File Offset: 0x00008568
		internal FontFileLoader FindRegisteredFontFileLoaderCallback(FontFileLoader loader)
		{
			foreach (FontFileLoader fontFileLoader in this._fontFileLoaderCallbacks)
			{
				if (fontFileLoader == loader)
				{
					return fontFileLoader;
				}
			}
			return null;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000A3C0 File Offset: 0x000085C0
		public Factory() : this(FactoryType.Shared)
		{
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000A3C9 File Offset: 0x000085C9
		public Factory(FactoryType factoryType)
		{
			this._fontCollectionLoaderCallbacks = new List<FontCollectionLoader>();
			this._fontFileLoaderCallbacks = new List<FontFileLoader>();
			base..ctor(IntPtr.Zero);
			DWrite.CreateFactory(factoryType, Utilities.GetGuidFromType(typeof(Factory)), this);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000A402 File Offset: 0x00008602
		public void RegisterFontCollectionLoader(FontCollectionLoader fontCollectionLoader)
		{
			FontCollectionLoaderShadow.SetFactory(fontCollectionLoader, this);
			this.RegisterFontCollectionLoader_(fontCollectionLoader);
			this._fontCollectionLoaderCallbacks.Add(fontCollectionLoader);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000A41E File Offset: 0x0000861E
		public void UnregisterFontCollectionLoader(FontCollectionLoader fontCollectionLoader)
		{
			if (!this._fontCollectionLoaderCallbacks.Contains(fontCollectionLoader))
			{
				throw new ArgumentException("This font collection loader is not registered", "fontCollectionLoader");
			}
			this.UnregisterFontCollectionLoader_(fontCollectionLoader);
			this._fontCollectionLoaderCallbacks.Remove(fontCollectionLoader);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000A452 File Offset: 0x00008652
		public void RegisterFontFileLoader(FontFileLoader fontFileLoader)
		{
			this.RegisterFontFileLoader_(fontFileLoader);
			this._fontFileLoaderCallbacks.Add(fontFileLoader);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000A467 File Offset: 0x00008667
		public void UnregisterFontFileLoader(FontFileLoader fontFileLoader)
		{
			if (!this._fontFileLoaderCallbacks.Contains(fontFileLoader))
			{
				throw new ArgumentException("This font file loader is not registered", "fontFileLoader");
			}
			this.UnregisterFontFileLoader_(fontFileLoader);
			this._fontFileLoaderCallbacks.Remove(fontFileLoader);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000A49B File Offset: 0x0000869B
		public Factory(IntPtr nativePtr)
		{
			this._fontCollectionLoaderCallbacks = new List<FontCollectionLoader>();
			this._fontFileLoaderCallbacks = new List<FontFileLoader>();
			base..ctor(nativePtr);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000A4BA File Offset: 0x000086BA
		public new static explicit operator Factory(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory(nativePtr);
			}
			return null;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000A4D4 File Offset: 0x000086D4
		public GdiInterop GdiInterop
		{
			get
			{
				GdiInterop result;
				this.GetGdiInterop(out result);
				return result;
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000A4EC File Offset: 0x000086EC
		public unsafe FontCollection GetSystemFontCollection(RawBool checkForUpdates)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, &zero, checkForUpdates, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			FontCollection result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new FontCollection(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000A548 File Offset: 0x00008748
		internal unsafe void CreateCustomFontCollection(FontCollectionLoader collectionLoader, IntPtr collectionKey, int collectionKeySize, FontCollection fontCollection)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontCollectionLoader>(collectionLoader);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, (void*)collectionKey, collectionKeySize, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			fontCollection.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000A5AC File Offset: 0x000087AC
		internal unsafe void RegisterFontCollectionLoader_(FontCollectionLoader fontCollectionLoader)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontCollectionLoader>(fontCollectionLoader);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000A5F8 File Offset: 0x000087F8
		internal unsafe void UnregisterFontCollectionLoader_(FontCollectionLoader fontCollectionLoader)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontCollectionLoader>(fontCollectionLoader);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000A644 File Offset: 0x00008844
		internal unsafe void CreateFontFileReference(string filePath, long? lastWriteTime, FontFile fontFile)
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, (lastWriteTime == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			fontFile.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000A6C4 File Offset: 0x000088C4
		internal unsafe void CreateCustomFontFileReference(IntPtr fontFileReferenceKey, int fontFileReferenceKeySize, FontFileLoader fontFileLoader, FontFile fontFile)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFileLoader>(fontFileLoader);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)fontFileReferenceKey, fontFileReferenceKeySize, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			fontFile.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000A728 File Offset: 0x00008928
		internal unsafe void CreateFontFace(FontFaceType fontFaceType, int numberOfFiles, FontFile[] fontFiles, int faceIndex, FontSimulations fontFaceSimulationFlags, FontFace fontFace)
		{
			IntPtr* ptr = null;
			if (fontFiles != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)fontFiles.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			IntPtr zero = IntPtr.Zero;
			if (fontFiles != null)
			{
				for (int i = 0; i < fontFiles.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<FontFile>(fontFiles[i]);
				}
			}
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, fontFaceType, numberOfFiles, ptr, faceIndex, fontFaceSimulationFlags, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			fontFace.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000A7B4 File Offset: 0x000089B4
		internal unsafe void CreateRenderingParams(RenderingParams renderingParams)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			renderingParams.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000A7FC File Offset: 0x000089FC
		internal unsafe void CreateMonitorRenderingParams(IntPtr monitor, RenderingParams renderingParams)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)monitor, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			renderingParams.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000A84C File Offset: 0x00008A4C
		internal unsafe void CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, PixelGeometry pixelGeometry, RenderingMode renderingMode, RenderingParams renderingParams)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Single,System.Int32,System.Int32,System.Void*), this._nativePointer, gamma, enhancedContrast, clearTypeLevel, pixelGeometry, renderingMode, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			renderingParams.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000A89C File Offset: 0x00008A9C
		internal unsafe void RegisterFontFileLoader_(FontFileLoader fontFileLoader)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFileLoader>(fontFileLoader);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000A8E8 File Offset: 0x00008AE8
		internal unsafe void UnregisterFontFileLoader_(FontFileLoader fontFileLoader)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFileLoader>(fontFileLoader);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000A934 File Offset: 0x00008B34
		internal unsafe void CreateTextFormat(string fontFamilyName, FontCollection fontCollection, FontWeight fontWeight, FontStyle fontStyle, FontStretch fontStretch, float fontSize, string localeName, TextFormat textFormat)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontCollection>(fontCollection);
			Result result;
			fixed (string text = localeName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				fixed (string text2 = fontFamilyName)
				{
					char* ptr2 = text2;
					if (ptr2 != null)
					{
						ptr2 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Single,System.Void*,System.Void*), this._nativePointer, ptr2, (void*)value, fontWeight, fontStyle, fontStretch, fontSize, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
				}
			}
			textFormat.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000A9CC File Offset: 0x00008BCC
		internal unsafe void CreateTypography(Typography typography)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			typography.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000AA14 File Offset: 0x00008C14
		internal unsafe void GetGdiInterop(out GdiInterop gdiInterop)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				gdiInterop = new GdiInterop(zero);
			}
			else
			{
				gdiInterop = null;
			}
			result.CheckError();
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000AA70 File Offset: 0x00008C70
		internal unsafe void CreateTextLayout(string text, int stringLength, TextFormat textFormat, float maxWidth, float maxHeight, TextLayout textLayout)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextFormat>(textFormat);
			Result result;
			fixed (string text2 = text)
			{
				char* ptr = text2;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Single,System.Single,System.Void*), this._nativePointer, ptr, stringLength, (void*)value, maxWidth, maxHeight, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			textLayout.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000AAE8 File Offset: 0x00008CE8
		internal unsafe void CreateGdiCompatibleTextLayout(string text, int stringLength, TextFormat textFormat, float layoutWidth, float layoutHeight, float pixelsPerDip, RawMatrix3x2? transform, RawBool useGdiNatural, TextLayout textLayout)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextFormat>(textFormat);
			RawMatrix3x2 value2;
			if (transform != null)
			{
				value2 = transform.Value;
			}
			Result result;
			fixed (string text2 = text)
			{
				char* ptr = text2;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Single,System.Single,System.Single,System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, ptr, stringLength, (void*)value, layoutWidth, layoutHeight, pixelsPerDip, (transform == null) ? null : (&value2), useGdiNatural, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			textLayout.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000AB8C File Offset: 0x00008D8C
		internal unsafe void CreateEllipsisTrimmingSign(TextFormat textFormat, InlineObjectNative trimmingSign)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextFormat>(textFormat);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			trimmingSign.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000ABE8 File Offset: 0x00008DE8
		internal unsafe void CreateTextAnalyzer(TextAnalyzer textAnalyzer)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			textAnalyzer.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000AC30 File Offset: 0x00008E30
		internal unsafe void CreateNumberSubstitution(NumberSubstitutionMethod substitutionMethod, string localeName, RawBool ignoreUserOverride, NumberSubstitution numberSubstitution)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (string text = localeName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, substitutionMethod, ptr, ignoreUserOverride, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			}
			numberSubstitution.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000AC90 File Offset: 0x00008E90
		internal unsafe void CreateGlyphRunAnalysis(GlyphRun glyphRun, float pixelsPerDip, RawMatrix3x2? transform, RenderingMode renderingMode, MeasuringMode measuringMode, float baselineOriginX, float baselineOriginY, GlyphRunAnalysis glyphRunAnalysis)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			IntPtr zero = IntPtr.Zero;
			glyphRun.__MarshalTo(ref _Native);
			RawMatrix3x2 value;
			if (transform != null)
			{
				value = transform.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Single,System.Void*,System.Int32,System.Int32,System.Single,System.Single,System.Void*), this._nativePointer, &_Native, pixelsPerDip, (transform == null) ? null : (&value), renderingMode, measuringMode, baselineOriginX, baselineOriginY, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			glyphRunAnalysis.NativePointer = zero;
			glyphRun.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000AD20 File Offset: 0x00008F20
		internal unsafe void CreateFontFace(FontFaceType fontFaceType, int numberOfFiles, ComArray<FontFile> fontFiles, int faceIndex, FontSimulations fontFaceSimulationFlags, FontFace fontFace)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, fontFaceType, numberOfFiles, (void*)((fontFiles != null) ? fontFiles.NativePointer : IntPtr.Zero), faceIndex, fontFaceSimulationFlags, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			fontFace.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000AD84 File Offset: 0x00008F84
		private unsafe void CreateFontFace(FontFaceType fontFaceType, int numberOfFiles, IntPtr fontFiles, int faceIndex, FontSimulations fontFaceSimulationFlags, IntPtr fontFace)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, fontFaceType, numberOfFiles, (void*)fontFiles, faceIndex, fontFaceSimulationFlags, (void*)fontFace, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0400020D RID: 525
		private readonly List<FontCollectionLoader> _fontCollectionLoaderCallbacks;

		// Token: 0x0400020E RID: 526
		private readonly List<FontFileLoader> _fontFileLoaderCallbacks;
	}
}

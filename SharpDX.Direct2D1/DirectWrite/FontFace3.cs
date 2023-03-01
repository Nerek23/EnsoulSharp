using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000130 RID: 304
	[Guid("D37D7598-09BE-4222-A236-2081341CC1F2")]
	public class FontFace3 : FontFace2
	{
		// Token: 0x0600056E RID: 1390 RVA: 0x0001188E File Offset: 0x0000FA8E
		public FontFace3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00011897 File Offset: 0x0000FA97
		public new static explicit operator FontFace3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFace3(nativePtr);
			}
			return null;
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x000118B0 File Offset: 0x0000FAB0
		public FontFaceReference FontFaceReference
		{
			get
			{
				FontFaceReference result;
				this.GetFontFaceReference(out result);
				return result;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x000118C8 File Offset: 0x0000FAC8
		public Panose Panose
		{
			get
			{
				Panose result;
				this.GetPanose(out result);
				return result;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x000118DE File Offset: 0x0000FADE
		public FontWeight Weight
		{
			get
			{
				return this.GetWeight();
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x000118E6 File Offset: 0x0000FAE6
		public FontStretch Stretch
		{
			get
			{
				return this.GetStretch();
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x000118EE File Offset: 0x0000FAEE
		public FontStyle Style
		{
			get
			{
				return this.GetStyle();
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x000118F8 File Offset: 0x0000FAF8
		public LocalizedStrings FamilyNames
		{
			get
			{
				LocalizedStrings result;
				this.GetFamilyNames(out result);
				return result;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x00011910 File Offset: 0x0000FB10
		public LocalizedStrings FaceNames
		{
			get
			{
				LocalizedStrings result;
				this.GetFaceNames(out result);
				return result;
			}
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00011928 File Offset: 0x0000FB28
		internal unsafe void GetFontFaceReference(out FontFaceReference fontFaceReference)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000578 RID: 1400 RVA: 0x00011984 File Offset: 0x0000FB84
		internal unsafe void GetPanose(out Panose anoseRef)
		{
			Panose.__Native _Native = default(Panose.__Native);
			anoseRef = default(Panose);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
			anoseRef.__MarshalFrom(ref _Native);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x000119C9 File Offset: 0x0000FBC9
		internal unsafe FontWeight GetWeight()
		{
			return calli(SharpDX.DirectWrite.FontWeight(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x000119E9 File Offset: 0x0000FBE9
		internal unsafe FontStretch GetStretch()
		{
			return calli(SharpDX.DirectWrite.FontStretch(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x00011A09 File Offset: 0x0000FC09
		internal unsafe FontStyle GetStyle()
		{
			return calli(SharpDX.DirectWrite.FontStyle(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00011A2C File Offset: 0x0000FC2C
		internal unsafe void GetFamilyNames(out LocalizedStrings names)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				names = new LocalizedStrings(zero);
			}
			else
			{
				names = null;
			}
			result.CheckError();
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00011A88 File Offset: 0x0000FC88
		internal unsafe void GetFaceNames(out LocalizedStrings names)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				names = new LocalizedStrings(zero);
			}
			else
			{
				names = null;
			}
			result.CheckError();
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00011AE4 File Offset: 0x0000FCE4
		public unsafe void GetInformationalStrings(InformationalStringId informationalStringID, out LocalizedStrings informationalStrings, out RawBool exists)
		{
			IntPtr zero = IntPtr.Zero;
			exists = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &exists)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, informationalStringID, &zero, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				informationalStrings = new LocalizedStrings(zero);
			}
			else
			{
				informationalStrings = null;
			}
			result.CheckError();
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00011B50 File Offset: 0x0000FD50
		public unsafe RawBool HasCharacter(int unicodeValue)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int32), this._nativePointer, unicodeValue, *(*(IntPtr*)this._nativePointer + (IntPtr)43 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00011B74 File Offset: 0x0000FD74
		public unsafe void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, RawMatrix3x2? transform, RawBool isSideways, OutlineThreshold outlineThreshold, MeasuringMode measuringMode, RenderingParams renderingParams, out RenderingMode1 renderingMode, out GridFitMode gridFitMode)
		{
			IntPtr value = IntPtr.Zero;
			RawMatrix3x2 value2;
			if (transform != null)
			{
				value2 = transform.Value;
			}
			value = CppObject.ToCallbackPtr<RenderingParams>(renderingParams);
			Result result;
			fixed (GridFitMode* ptr = &gridFitMode)
			{
				void* ptr2 = (void*)ptr;
				fixed (RenderingMode1* ptr3 = &renderingMode)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Single,System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, fontEmSize, dpiX, dpiY, (transform == null) ? null : (&value2), isSideways, outlineThreshold, measuringMode, (void*)value, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)44 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00011C06 File Offset: 0x0000FE06
		public unsafe RawBool IsCharacterLocal(int unicodeValue)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int32), this._nativePointer, unicodeValue, *(*(IntPtr*)this._nativePointer + (IntPtr)45 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00011C27 File Offset: 0x0000FE27
		public unsafe RawBool IsGlyphLocal(short glyphId)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int16), this._nativePointer, glyphId, *(*(IntPtr*)this._nativePointer + (IntPtr)46 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00011C48 File Offset: 0x0000FE48
		public unsafe void AreCharactersLocal(string characters, int characterCount, RawBool enqueueIfNotLocal, out RawBool isLocal)
		{
			isLocal = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &isLocal)
			{
				void* ptr2 = (void*)ptr;
				fixed (string text = characters)
				{
					char* ptr3 = text;
					if (ptr3 != null)
					{
						ptr3 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, ptr3, characterCount, enqueueIfNotLocal, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)47 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00011CAC File Offset: 0x0000FEAC
		public unsafe void AreGlyphsLocal(short[] glyphIndices, int glyphCount, RawBool enqueueIfNotLocal, out RawBool isLocal)
		{
			isLocal = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &isLocal)
			{
				void* ptr2 = (void*)ptr;
				fixed (short[] array = glyphIndices)
				{
					void* ptr3;
					if (glyphIndices == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, ptr3, glyphCount, enqueueIfNotLocal, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)48 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}

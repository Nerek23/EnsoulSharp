using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200012E RID: 302
	[Guid("a71efdb4-9fdb-4838-ad90-cfc3be8c3daf")]
	public class FontFace1 : FontFace
	{
		// Token: 0x06000553 RID: 1363 RVA: 0x0001129A File Offset: 0x0000F49A
		public FontFace1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x000112A3 File Offset: 0x0000F4A3
		public new static explicit operator FontFace1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFace1(nativePtr);
			}
			return null;
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x000112BC File Offset: 0x0000F4BC
		public new FontMetrics1 Metrics
		{
			get
			{
				FontMetrics1 result;
				this.GetMetrics(out result);
				return result;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x000112D4 File Offset: 0x0000F4D4
		public CaretMetrics CaretMetrics
		{
			get
			{
				CaretMetrics result;
				this.GetCaretMetrics(out result);
				return result;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x000112EA File Offset: 0x0000F4EA
		public RawBool IsMonospacedFont
		{
			get
			{
				return this.IsMonospacedFont_();
			}
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x000112F4 File Offset: 0x0000F4F4
		internal unsafe void GetMetrics(out FontMetrics1 fontMetrics)
		{
			fontMetrics = default(FontMetrics1);
			fixed (FontMetrics1* ptr = &fontMetrics)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00011330 File Offset: 0x0000F530
		public unsafe void GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, RawMatrix3x2? transform, out FontMetrics1 fontMetrics)
		{
			fontMetrics = default(FontMetrics1);
			RawMatrix3x2 value;
			if (transform != null)
			{
				value = transform.Value;
			}
			Result result;
			fixed (FontMetrics1* ptr = &fontMetrics)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Void*,System.Void*), this._nativePointer, emSize, pixelsPerDip, (transform == null) ? null : (&value), ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x000113A0 File Offset: 0x0000F5A0
		internal unsafe void GetCaretMetrics(out CaretMetrics caretMetrics)
		{
			caretMetrics = default(CaretMetrics);
			fixed (CaretMetrics* ptr = &caretMetrics)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x000113DC File Offset: 0x0000F5DC
		public unsafe void GetUnicodeRanges(int maxRangeCount, UnicodeRange[] unicodeRanges, out int actualRangeCount)
		{
			Result result;
			fixed (int* ptr = &actualRangeCount)
			{
				void* ptr2 = (void*)ptr;
				fixed (UnicodeRange[] array = unicodeRanges)
				{
					void* ptr3;
					if (unicodeRanges == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, maxRangeCount, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0001143D File Offset: 0x0000F63D
		internal unsafe RawBool IsMonospacedFont_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00011460 File Offset: 0x0000F660
		public unsafe void GetDesignGlyphAdvances(int glyphCount, short[] glyphIndices, int[] glyphAdvances, RawBool isSideways)
		{
			Result result;
			fixed (int[] array = glyphAdvances)
			{
				void* ptr;
				if (glyphAdvances == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (short[] array2 = glyphIndices)
				{
					void* ptr2;
					if (glyphIndices == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, glyphCount, ptr2, ptr, isSideways, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x000114D8 File Offset: 0x0000F6D8
		public unsafe void GetGdiCompatibleGlyphAdvances(float emSize, float pixelsPerDip, RawMatrix3x2? transform, RawBool useGdiNatural, RawBool isSideways, int glyphCount, short[] glyphIndices, int[] glyphAdvances)
		{
			RawMatrix3x2 value;
			if (transform != null)
			{
				value = transform.Value;
			}
			Result result;
			fixed (int[] array = glyphAdvances)
			{
				void* ptr;
				if (glyphAdvances == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (short[] array2 = glyphIndices)
				{
					void* ptr2;
					if (glyphIndices == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Void*,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,System.Int32,System.Void*,System.Void*), this._nativePointer, emSize, pixelsPerDip, (transform == null) ? null : (&value), useGdiNatural, isSideways, glyphCount, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00011578 File Offset: 0x0000F778
		public unsafe void GetKerningPairAdjustments(int glyphCount, short[] glyphIndices, int[] glyphAdvanceAdjustments)
		{
			Result result;
			fixed (int[] array = glyphAdvanceAdjustments)
			{
				void* ptr;
				if (glyphAdvanceAdjustments == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (short[] array2 = glyphIndices)
				{
					void* ptr2;
					if (glyphIndices == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, glyphCount, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x000115EB File Offset: 0x0000F7EB
		public unsafe RawBool HasKerningPairs()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0001160C File Offset: 0x0000F80C
		public unsafe void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, RawMatrix3x2? transform, RawBool isSideways, OutlineThreshold outlineThreshold, MeasuringMode measuringMode, out RenderingMode renderingMode)
		{
			RawMatrix3x2 value;
			if (transform != null)
			{
				value = transform.Value;
			}
			Result result;
			fixed (RenderingMode* ptr = &renderingMode)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Single,System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Int32,System.Int32,System.Void*), this._nativePointer, fontEmSize, dpiX, dpiY, (transform == null) ? null : (&value), isSideways, outlineThreshold, measuringMode, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x00011678 File Offset: 0x0000F878
		public unsafe void GetVerticalGlyphVariants(int glyphCount, short[] nominalGlyphIndices, short[] verticalGlyphIndices)
		{
			Result result;
			fixed (short[] array = verticalGlyphIndices)
			{
				void* ptr;
				if (verticalGlyphIndices == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (short[] array2 = nominalGlyphIndices)
				{
					void* ptr2;
					if (nominalGlyphIndices == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, glyphCount, ptr2, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x000116EB File Offset: 0x0000F8EB
		public unsafe RawBool HasVerticalGlyphVariants()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
		}
	}
}

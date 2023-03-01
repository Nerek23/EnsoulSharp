using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000125 RID: 293
	[Guid("4B0B5BD3-0797-4549-8AC5-FE915CC53856")]
	public class Factory4 : Factory3
	{
		// Token: 0x0600050A RID: 1290 RVA: 0x000105EB File Offset: 0x0000E7EB
		public Factory4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x000105F4 File Offset: 0x0000E7F4
		public new static explicit operator Factory4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory4(nativePtr);
			}
			return null;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0001060C File Offset: 0x0000E80C
		public unsafe void TranslateColorGlyphRun(RawVector2 baselineOrigin, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, GlyphImageFormatS desiredGlyphImageFormats, MeasuringMode measuringMode, RawMatrix3x2? worldAndDpiTransform, int colorPaletteIndex, out ColorGlyphRunEnumerator1 colorLayers)
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
			if (worldAndDpiTransform != null)
			{
				value = worldAndDpiTransform.Value;
			}
			Result result = calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, baselineOrigin, &_Native, (glyphRunDescription == null) ? null : (&_Native2), desiredGlyphImageFormats, measuringMode, (worldAndDpiTransform == null) ? null : (&value), colorPaletteIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				colorLayers = new ColorGlyphRunEnumerator1(zero);
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
			result.CheckError();
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x000106D8 File Offset: 0x0000E8D8
		public unsafe void ComputeGlyphOrigins(GlyphRun glyphRun, RawVector2 baselineOrigin, RawVector2[] glyphOrigins)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			glyphRun.__MarshalTo(ref _Native);
			Result result;
			fixed (RawVector2[] array = glyphOrigins)
			{
				void* ptr;
				if (glyphOrigins == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*), this._nativePointer, &_Native, baselineOrigin, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*)));
			}
			glyphRun.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00010748 File Offset: 0x0000E948
		public unsafe void ComputeGlyphOrigins(GlyphRun glyphRun, MeasuringMode measuringMode, RawVector2 baselineOrigin, RawMatrix3x2? worldAndDpiTransform, RawVector2[] glyphOrigins)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			glyphRun.__MarshalTo(ref _Native);
			RawMatrix3x2 value;
			if (worldAndDpiTransform != null)
			{
				value = worldAndDpiTransform.Value;
			}
			Result result;
			fixed (RawVector2[] array = glyphOrigins)
			{
				void* ptr;
				if (glyphOrigins == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Void*), this._nativePointer, &_Native, measuringMode, baselineOrigin, (worldAndDpiTransform == null) ? null : (&value), ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*)));
			}
			glyphRun.__MarshalFree(ref _Native);
			result.CheckError();
		}
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001CF RID: 463
	[Guid("8c427831-3d90-4476-b647-c4fae349e4db")]
	public class DeviceContext4 : DeviceContext3
	{
		// Token: 0x0600094C RID: 2380 RVA: 0x0001AD00 File Offset: 0x00018F00
		public DeviceContext4(Device4 device, DeviceContextOptions options) : base(IntPtr.Zero)
		{
			device.CreateDeviceContext(options, this);
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0001AD15 File Offset: 0x00018F15
		public DeviceContext4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0001AD1E File Offset: 0x00018F1E
		public new static explicit operator DeviceContext4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext4(nativePtr);
			}
			return null;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0001AD38 File Offset: 0x00018F38
		public unsafe void CreateSvgGlyphStyle(out SvgGlyphStyle svgGlyphStyle)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)108 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				svgGlyphStyle = new SvgGlyphStyle(zero);
			}
			else
			{
				svgGlyphStyle = null;
			}
			result.CheckError();
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0001AD94 File Offset: 0x00018F94
		public unsafe void DrawText(string text, int stringLength, TextFormat textFormat, RawRectangleF layoutRect, Brush defaultFillBrush, SvgGlyphStyle svgGlyphStyle, int colorPaletteIndex, DrawTextOptions options, MeasuringMode measuringMode)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextFormat>(textFormat);
			value2 = CppObject.ToCallbackPtr<Brush>(defaultFillBrush);
			value3 = CppObject.ToCallbackPtr<SvgGlyphStyle>(svgGlyphStyle);
			fixed (string text2 = text)
			{
				char* ptr = text2;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, ptr, stringLength, (void*)value, &layoutRect, (void*)value2, (void*)value3, colorPaletteIndex, options, measuringMode, *(*(IntPtr*)this._nativePointer + (IntPtr)109 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0001AE1C File Offset: 0x0001901C
		public unsafe void DrawTextLayout(RawVector2 origin, TextLayout textLayout, Brush defaultFillBrush, SvgGlyphStyle svgGlyphStyle, int colorPaletteIndex, DrawTextOptions options)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextLayout>(textLayout);
			value2 = CppObject.ToCallbackPtr<Brush>(defaultFillBrush);
			value3 = CppObject.ToCallbackPtr<SvgGlyphStyle>(svgGlyphStyle);
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, origin, (void*)value, (void*)value2, (void*)value3, colorPaletteIndex, options, *(*(IntPtr*)this._nativePointer + (IntPtr)110 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0001AE88 File Offset: 0x00019088
		public unsafe void DrawColorBitmapGlyphRun(GlyphImageFormatS glyphImageFormat, RawVector2 baselineOrigin, GlyphRun glyphRun, MeasuringMode measuringMode, ColorBitmapGlyphSnapOption bitmapSnapOption)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			glyphRun.__MarshalTo(ref _Native);
			calli(System.Void(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Int32,System.Int32), this._nativePointer, glyphImageFormat, baselineOrigin, &_Native, measuringMode, bitmapSnapOption, *(*(IntPtr*)this._nativePointer + (IntPtr)111 * (IntPtr)sizeof(void*)));
			glyphRun.__MarshalFree(ref _Native);
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0001AED4 File Offset: 0x000190D4
		public unsafe void DrawSvgGlyphRun(RawVector2 baselineOrigin, GlyphRun glyphRun, Brush defaultFillBrush, SvgGlyphStyle svgGlyphStyle, int colorPaletteIndex, MeasuringMode measuringMode)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			glyphRun.__MarshalTo(ref _Native);
			value = CppObject.ToCallbackPtr<Brush>(defaultFillBrush);
			value2 = CppObject.ToCallbackPtr<SvgGlyphStyle>(svgGlyphStyle);
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, baselineOrigin, &_Native, (void*)value, (void*)value2, colorPaletteIndex, measuringMode, *(*(IntPtr*)this._nativePointer + (IntPtr)112 * (IntPtr)sizeof(void*)));
			glyphRun.__MarshalFree(ref _Native);
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0001AF48 File Offset: 0x00019148
		public unsafe void GetColorBitmapGlyphImage(GlyphImageFormatS glyphImageFormat, RawVector2 glyphOrigin, FontFace fontFace, float fontEmSize, short glyphIndex, RawBool isSideways, RawMatrix3x2? worldTransform, float dpiX, float dpiY, out RawMatrix3x2 glyphTransform, out Image glyphImage)
		{
			IntPtr value = IntPtr.Zero;
			glyphTransform = default(RawMatrix3x2);
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			RawMatrix3x2 value2;
			if (worldTransform != null)
			{
				value2 = worldTransform.Value;
			}
			Result result;
			fixed (RawMatrix3x2* ptr = &glyphTransform)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Single,System.Int16,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Single,System.Single,System.Void*,System.Void*), this._nativePointer, glyphImageFormat, glyphOrigin, (void*)value, fontEmSize, glyphIndex, isSideways, (worldTransform == null) ? null : (&value2), dpiX, dpiY, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)113 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				glyphImage = new Image(zero);
			}
			else
			{
				glyphImage = null;
			}
			result.CheckError();
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0001AFFC File Offset: 0x000191FC
		public unsafe void GetSvgGlyphImage(RawVector2 glyphOrigin, FontFace fontFace, float fontEmSize, short glyphIndex, RawBool isSideways, RawMatrix3x2? worldTransform, Brush defaultFillBrush, SvgGlyphStyle svgGlyphStyle, int colorPaletteIndex, out RawMatrix3x2 glyphTransform, out CommandList glyphImage)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			glyphTransform = default(RawMatrix3x2);
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			RawMatrix3x2 value4;
			if (worldTransform != null)
			{
				value4 = worldTransform.Value;
			}
			value2 = CppObject.ToCallbackPtr<Brush>(defaultFillBrush);
			value3 = CppObject.ToCallbackPtr<SvgGlyphStyle>(svgGlyphStyle);
			Result result;
			fixed (RawMatrix3x2* ptr = &glyphTransform)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Single,System.Int16,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, glyphOrigin, (void*)value, fontEmSize, glyphIndex, isSideways, (worldTransform == null) ? null : (&value4), (void*)value2, (void*)value3, colorPaletteIndex, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)114 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				glyphImage = new CommandList(zero);
			}
			else
			{
				glyphImage = null;
			}
			result.CheckError();
		}
	}
}

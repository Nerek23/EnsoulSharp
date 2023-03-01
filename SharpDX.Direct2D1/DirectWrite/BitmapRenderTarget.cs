using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000082 RID: 130
	[Guid("5e5a32a3-8dff-4773-9ff6-0696eab77267")]
	public class BitmapRenderTarget : ComObject
	{
		// Token: 0x0600026E RID: 622 RVA: 0x00009EB4 File Offset: 0x000080B4
		public void DrawGlyphRun(float baselineOriginX, float baselineOriginY, MeasuringMode measuringMode, GlyphRun glyphRun, RenderingParams renderingParams, RawColorBGRA textColor, out RawRectangle blackBoxRect)
		{
			int textColor2 = (int)textColor.R | (int)textColor.G << 8 | (int)textColor.B << 16;
			this.DrawGlyphRun(baselineOriginX, baselineOriginY, measuringMode, glyphRun, renderingParams, textColor2, out blackBoxRect);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00009EF0 File Offset: 0x000080F0
		public void DrawGlyphRun(float baselineOriginX, float baselineOriginY, MeasuringMode measuringMode, GlyphRun glyphRun, RenderingParams renderingParams, RawColorBGRA textColor)
		{
			RawRectangle rawRectangle;
			this.DrawGlyphRun(baselineOriginX, baselineOriginY, measuringMode, glyphRun, renderingParams, textColor, out rawRectangle);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00002A7F File Offset: 0x00000C7F
		public BitmapRenderTarget(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00009F0E File Offset: 0x0000810E
		public new static explicit operator BitmapRenderTarget(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapRenderTarget(nativePtr);
			}
			return null;
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000272 RID: 626 RVA: 0x00009F25 File Offset: 0x00008125
		public IntPtr MemoryDC
		{
			get
			{
				return this.GetMemoryDC();
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00009F2D File Offset: 0x0000812D
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00009F35 File Offset: 0x00008135
		public float PixelsPerDip
		{
			get
			{
				return this.GetPixelsPerDip();
			}
			set
			{
				this.SetPixelsPerDip(value);
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00009F40 File Offset: 0x00008140
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00009F56 File Offset: 0x00008156
		public RawMatrix3x2 CurrentTransform
		{
			get
			{
				RawMatrix3x2 result;
				this.GetCurrentTransform(out result);
				return result;
			}
			set
			{
				this.SetCurrentTransform(new RawMatrix3x2?(value));
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00009F64 File Offset: 0x00008164
		public Size2 Size
		{
			get
			{
				Size2 result;
				this.GetSize(out result);
				return result;
			}
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00009F7C File Offset: 0x0000817C
		private unsafe void DrawGlyphRun(float baselineOriginX, float baselineOriginY, MeasuringMode measuringMode, GlyphRun glyphRun, RenderingParams renderingParams, int textColor, out RawRectangle blackBoxRect)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			IntPtr value = IntPtr.Zero;
			blackBoxRect = default(RawRectangle);
			glyphRun.__MarshalTo(ref _Native);
			value = CppObject.ToCallbackPtr<RenderingParams>(renderingParams);
			Result result;
			fixed (RawRectangle* ptr = &blackBoxRect)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Single,System.Single,System.Int32,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, baselineOriginX, baselineOriginY, measuringMode, &_Native, (void*)value, textColor, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			glyphRun.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00009FFE File Offset: 0x000081FE
		internal unsafe IntPtr GetMemoryDC()
		{
			return calli(System.IntPtr(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000A01D File Offset: 0x0000821D
		internal unsafe float GetPixelsPerDip()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000A03C File Offset: 0x0000823C
		internal unsafe void SetPixelsPerDip(float pixelsPerDip)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, pixelsPerDip, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000A074 File Offset: 0x00008274
		internal unsafe void GetCurrentTransform(out RawMatrix3x2 transform)
		{
			transform = default(RawMatrix3x2);
			Result result;
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000A0BC File Offset: 0x000082BC
		internal unsafe void SetCurrentTransform(RawMatrix3x2? transform)
		{
			RawMatrix3x2 value;
			if (transform != null)
			{
				value = transform.Value;
			}
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (transform == null) ? null : (&value), *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000A114 File Offset: 0x00008314
		internal unsafe void GetSize(out Size2 size)
		{
			size = default(Size2);
			Result result;
			fixed (Size2* ptr = &size)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000A15C File Offset: 0x0000835C
		public unsafe void Resize(int width, int height)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, width, height, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}

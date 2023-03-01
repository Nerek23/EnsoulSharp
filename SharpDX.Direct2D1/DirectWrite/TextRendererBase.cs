using System;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000DE RID: 222
	public abstract class TextRendererBase : CallbackBase, TextRenderer, PixelSnapping, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060004C7 RID: 1223 RVA: 0x0000FD25 File Offset: 0x0000DF25
		public virtual bool IsPixelSnappingDisabled(object clientDrawingContext)
		{
			return false;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0000FD28 File Offset: 0x0000DF28
		public virtual RawMatrix3x2 GetCurrentTransform(object clientDrawingContext)
		{
			return new RawMatrix3x2
			{
				M11 = 1f,
				M22 = 1f
			};
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000FD56 File Offset: 0x0000DF56
		public virtual float GetPixelsPerDip(object clientDrawingContext)
		{
			return 1f;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000FD5D File Offset: 0x0000DF5D
		public virtual Result DrawGlyphRun(object clientDrawingContext, float baselineOriginX, float baselineOriginY, MeasuringMode measuringMode, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, ComObject clientDrawingEffect)
		{
			return Result.NotImplemented;
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0000FD5D File Offset: 0x0000DF5D
		public virtual Result DrawUnderline(object clientDrawingContext, float baselineOriginX, float baselineOriginY, ref Underline underline, ComObject clientDrawingEffect)
		{
			return Result.NotImplemented;
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0000FD5D File Offset: 0x0000DF5D
		public virtual Result DrawStrikethrough(object clientDrawingContext, float baselineOriginX, float baselineOriginY, ref Strikethrough strikethrough, ComObject clientDrawingEffect)
		{
			return Result.NotImplemented;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0000FD5D File Offset: 0x0000DF5D
		public virtual Result DrawInlineObject(object clientDrawingContext, float originX, float originY, InlineObject inlineObject, bool isSideways, bool isRightToLeft, ComObject clientDrawingEffect)
		{
			return Result.NotImplemented;
		}
	}
}

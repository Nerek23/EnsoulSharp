using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000DD RID: 221
	[Shadow(typeof(TextRendererShadow))]
	[Guid("ef8a8135-5cc6-45fe-8825-c5a0724eb819")]
	public interface TextRenderer : PixelSnapping, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060004C3 RID: 1219
		Result DrawGlyphRun(object clientDrawingContext, float baselineOriginX, float baselineOriginY, MeasuringMode measuringMode, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, ComObject clientDrawingEffect);

		// Token: 0x060004C4 RID: 1220
		Result DrawUnderline(object clientDrawingContext, float baselineOriginX, float baselineOriginY, ref Underline underline, ComObject clientDrawingEffect);

		// Token: 0x060004C5 RID: 1221
		Result DrawStrikethrough(object clientDrawingContext, float baselineOriginX, float baselineOriginY, ref Strikethrough strikethrough, ComObject clientDrawingEffect);

		// Token: 0x060004C6 RID: 1222
		Result DrawInlineObject(object clientDrawingContext, float originX, float originY, InlineObject inlineObject, bool isSideways, bool isRightToLeft, ComObject clientDrawingEffect);
	}
}

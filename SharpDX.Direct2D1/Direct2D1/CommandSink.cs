using System;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000183 RID: 387
	[Guid("54d7898a-a061-40a7-bec7-e465bcba2c4f")]
	public interface CommandSink : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000739 RID: 1849
		void BeginDraw();

		// Token: 0x0600073A RID: 1850
		void EndDraw();

		// Token: 0x17000122 RID: 290
		// (set) Token: 0x0600073B RID: 1851
		AntialiasMode AntialiasMode { set; }

		// Token: 0x0600073C RID: 1852
		void SetTags(long tag1, long tag2);

		// Token: 0x17000123 RID: 291
		// (set) Token: 0x0600073D RID: 1853
		TextAntialiasMode TextAntialiasMode { set; }

		// Token: 0x17000124 RID: 292
		// (set) Token: 0x0600073E RID: 1854
		RenderingParams TextRenderingParams { set; }

		// Token: 0x17000125 RID: 293
		// (set) Token: 0x0600073F RID: 1855
		RawMatrix3x2 Transform { set; }

		// Token: 0x17000126 RID: 294
		// (set) Token: 0x06000740 RID: 1856
		PrimitiveBlend PrimitiveBlend { set; }

		// Token: 0x17000127 RID: 295
		// (set) Token: 0x06000741 RID: 1857
		UnitMode UnitMode { set; }

		// Token: 0x06000742 RID: 1858
		void Clear(RawColor4? color = null);

		// Token: 0x06000743 RID: 1859
		void DrawGlyphRun(RawVector2 baselineOrigin, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, Brush foregroundBrush, MeasuringMode measuringMode);

		// Token: 0x06000744 RID: 1860
		void DrawLine(RawVector2 point0, RawVector2 point1, Brush brush, float strokeWidth, StrokeStyle strokeStyle);

		// Token: 0x06000745 RID: 1861
		void DrawGeometry(Geometry geometry, Brush brush, float strokeWidth, StrokeStyle strokeStyle);

		// Token: 0x06000746 RID: 1862
		void DrawRectangle(RawRectangleF rect, Brush brush, float strokeWidth, StrokeStyle strokeStyle);

		// Token: 0x06000747 RID: 1863
		void DrawBitmap(Bitmap bitmap, RawRectangleF? destinationRectangle, float opacity, InterpolationMode interpolationMode, RawRectangleF? sourceRectangle, RawMatrix? erspectiveTransformRef);

		// Token: 0x06000748 RID: 1864
		void DrawImage(Image image, RawVector2? targetOffset, RawRectangleF? imageRectangle, InterpolationMode interpolationMode, CompositeMode compositeMode);

		// Token: 0x06000749 RID: 1865
		void DrawGdiMetafile(GdiMetafile gdiMetafile, RawVector2? targetOffset);

		// Token: 0x0600074A RID: 1866
		void FillMesh(Mesh mesh, Brush brush);

		// Token: 0x0600074B RID: 1867
		void FillOpacityMask(Bitmap opacityMask, Brush brush, RawRectangleF? destinationRectangle, RawRectangleF? sourceRectangle);

		// Token: 0x0600074C RID: 1868
		void FillGeometry(Geometry geometry, Brush brush, Brush opacityBrush);

		// Token: 0x0600074D RID: 1869
		void FillRectangle(RawRectangleF rect, Brush brush);

		// Token: 0x0600074E RID: 1870
		void PushAxisAlignedClip(RawRectangleF clipRect, AntialiasMode antialiasMode);

		// Token: 0x0600074F RID: 1871
		void PushLayer(ref LayerParameters1 layerParameters1, Layer layer);

		// Token: 0x06000750 RID: 1872
		void PopAxisAlignedClip();

		// Token: 0x06000751 RID: 1873
		void PopLayer();
	}
}

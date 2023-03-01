using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001E8 RID: 488
	[Shadow(typeof(GeometrySinkShadow))]
	[Guid("2cd9069f-12e2-11dc-9fed-001143a055f9")]
	public interface GeometrySink : SimplifiedGeometrySink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000A48 RID: 2632
		void AddLine(RawVector2 point);

		// Token: 0x06000A49 RID: 2633
		void AddBezier(BezierSegment bezier);

		// Token: 0x06000A4A RID: 2634
		void AddQuadraticBezier(QuadraticBezierSegment bezier);

		// Token: 0x06000A4B RID: 2635
		void AddQuadraticBeziers(QuadraticBezierSegment[] beziers);

		// Token: 0x06000A4C RID: 2636
		void AddArc(ArcSegment arc);
	}
}

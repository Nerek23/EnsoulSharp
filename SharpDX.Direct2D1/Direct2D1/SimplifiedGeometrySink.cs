using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200021C RID: 540
	[Shadow(typeof(SimplifiedGeometrySinkShadow))]
	[Guid("2cd9069e-12e2-11dc-9fed-001143a055f9")]
	public interface SimplifiedGeometrySink : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000C34 RID: 3124
		void SetFillMode(FillMode fillMode);

		// Token: 0x06000C35 RID: 3125
		void SetSegmentFlags(PathSegment vertexFlags);

		// Token: 0x06000C36 RID: 3126
		void BeginFigure(RawVector2 startPoint, FigureBegin figureBegin);

		// Token: 0x06000C37 RID: 3127
		void AddLines(RawVector2[] ointsRef);

		// Token: 0x06000C38 RID: 3128
		void AddBeziers(BezierSegment[] beziers);

		// Token: 0x06000C39 RID: 3129
		void EndFigure(FigureEnd figureEnd);

		// Token: 0x06000C3A RID: 3130
		void Close();
	}
}

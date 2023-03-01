using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200023A RID: 570
	[Shadow(typeof(TransformShadow))]
	[Guid("ef1a287d-342a-4f76-8fdb-da0d6ea9f92b")]
	public interface Transform : TransformNode, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000D2D RID: 3373
		void MapOutputRectangleToInputRectangles(RawRectangle outputRect, RawRectangle[] inputRects);

		// Token: 0x06000D2E RID: 3374
		RawRectangle MapInputRectanglesToOutputRectangle(RawRectangle[] inputRects, RawRectangle[] inputOpaqueSubRects, out RawRectangle outputOpaqueSubRect);

		// Token: 0x06000D2F RID: 3375
		RawRectangle MapInvalidRect(int inputIndex, RawRectangle invalidInputRect);
	}
}

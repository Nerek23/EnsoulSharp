using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000189 RID: 393
	[Guid("3bab440e-417e-47df-a2e2-bc0be6a00916")]
	public interface CommandSink2 : CommandSink1, CommandSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000762 RID: 1890
		void DrawInk(Ink ink, Brush brush, InkStyle inkStyle);

		// Token: 0x06000763 RID: 1891
		void DrawGradientMesh(GradientMesh gradientMesh);

		// Token: 0x06000764 RID: 1892
		void DrawGdiMetafile(GdiMetafile gdiMetafile, RawRectangleF? destinationRectangle, RawRectangleF? sourceRectangle);
	}
}

using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000B9 RID: 185
	[Guid("eaf3a2da-ecf4-4d24-b644-b34f6842024b")]
	[Shadow(typeof(PixelSnappingShadow))]
	public interface PixelSnapping : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060003B4 RID: 948
		bool IsPixelSnappingDisabled(object clientDrawingContext);

		// Token: 0x060003B5 RID: 949
		RawMatrix3x2 GetCurrentTransform(object clientDrawingContext);

		// Token: 0x060003B6 RID: 950
		float GetPixelsPerDip(object clientDrawingContext);
	}
}

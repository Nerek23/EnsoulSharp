using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001D5 RID: 469
	[Shadow(typeof(DrawTransformShadow))]
	[Guid("36bfdcb6-9739-435d-a30d-a653beff6a6f")]
	public interface DrawTransform : Transform, TransformNode, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000987 RID: 2439
		void SetDrawInformation(DrawInformation drawInfo);
	}
}

using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000228 RID: 552
	[Shadow(typeof(SourceTransformShadow))]
	[Guid("db1800dd-0c34-4cf9-be90-31cc0a5653e1")]
	public interface SourceTransform : Transform, TransformNode, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000C7D RID: 3197
		void SetRenderInformation(RenderInformation renderInfo);

		// Token: 0x06000C7E RID: 3198
		void Draw(Bitmap1 target, RawRectangle drawRect, RawPoint targetOrigin);
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001AF RID: 431
	[Shadow(typeof(CustomEffectShadow))]
	[Guid("a248fd3f-3e6c-4e63-9f03-7f68ecc91db9")]
	public interface CustomEffect : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600084A RID: 2122
		void Initialize(EffectContext effectContext, TransformGraph transformGraph);

		// Token: 0x0600084B RID: 2123
		void PrepareForRender(ChangeType changeType);

		// Token: 0x0600084C RID: 2124
		void SetGraph(TransformGraph transformGraph);
	}
}

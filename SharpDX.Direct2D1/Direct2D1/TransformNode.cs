using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200023E RID: 574
	[Shadow(typeof(TransformNodeShadow))]
	[Guid("b2efe1e7-729f-4102-949f-505fa21bf666")]
	public interface TransformNode : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000D46 RID: 3398
		int InputCount { get; }
	}
}

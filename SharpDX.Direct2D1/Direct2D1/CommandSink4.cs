using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200018D RID: 397
	[Guid("c78a6519-40d6-4218-b2de-beeeb744bb3e")]
	public interface CommandSink4 : CommandSink3, CommandSink2, CommandSink1, CommandSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000772 RID: 1906
		void SetPrimitiveBlend2(PrimitiveBlend primitiveBlend);
	}
}

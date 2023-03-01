using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000184 RID: 388
	[Guid("9eb767fd-4269-4467-b8c2-eb30cb305743")]
	public interface CommandSink1 : CommandSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x17000128 RID: 296
		// (set) Token: 0x06000752 RID: 1874
		PrimitiveBlend PrimitiveBlend1 { set; }
	}
}

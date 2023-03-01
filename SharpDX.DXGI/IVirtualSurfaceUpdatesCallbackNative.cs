using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000014 RID: 20
	[Shadow(typeof(VirtualSurfaceUpdatesCallbackNativeShadow))]
	[Guid("dbf2e947-8e6c-4254-9eee-7738f71386c9")]
	internal interface IVirtualSurfaceUpdatesCallbackNative : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060000A6 RID: 166
		void UpdatesNeeded();
	}
}

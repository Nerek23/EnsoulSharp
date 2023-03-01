using System;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000026 RID: 38
	[Guid("00000000-0000-0000-C000-000000000046")]
	public interface IUnknown : ICallbackable, IDisposable
	{
		// Token: 0x0600010C RID: 268
		Result QueryInterface(ref Guid guid, out IntPtr comObject);

		// Token: 0x0600010D RID: 269
		int AddReference();

		// Token: 0x0600010E RID: 270
		int Release();
	}
}

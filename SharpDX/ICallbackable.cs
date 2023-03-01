using System;

namespace SharpDX
{
	// Token: 0x0200001D RID: 29
	public interface ICallbackable : IDisposable
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000E0 RID: 224
		// (set) Token: 0x060000E1 RID: 225
		IDisposable Shadow { get; set; }
	}
}

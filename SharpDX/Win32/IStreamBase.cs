using System;
using System.Runtime.InteropServices;

namespace SharpDX.Win32
{
	// Token: 0x02000050 RID: 80
	[Guid("0c733a30-2a1c-11ce-ade5-00aa0044773d")]
	[Shadow(typeof(ComStreamBaseShadow))]
	public interface IStreamBase : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600024C RID: 588
		int Read(IntPtr buffer, int numberOfBytesToRead);

		// Token: 0x0600024D RID: 589
		int Write(IntPtr buffer, int numberOfBytesToRead);
	}
}

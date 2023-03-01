using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200009B RID: 155
	[Guid("6d4865fe-0ab8-4d91-8f62-5dd6be34a3e0")]
	[Shadow(typeof(FontFileStreamShadow))]
	public interface FontFileStream : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600031A RID: 794
		void ReadFileFragment(out IntPtr fragmentStart, long fileOffset, long fragmentSize, out IntPtr fragmentContext);

		// Token: 0x0600031B RID: 795
		void ReleaseFileFragment(IntPtr fragmentContext);

		// Token: 0x0600031C RID: 796
		long GetFileSize();

		// Token: 0x0600031D RID: 797
		long GetLastWriteTime();
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000096 RID: 150
	[Shadow(typeof(FontFileLoaderShadow))]
	[Guid("727cad4e-d6af-4c9e-8a08-d695b11caa49")]
	public interface FontFileLoader : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600030B RID: 779
		FontFileStream CreateStreamFromKey(DataPointer fontFileReferenceKey);
	}
}

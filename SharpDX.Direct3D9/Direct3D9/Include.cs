using System;
using System.IO;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B2 RID: 178
	[Shadow(typeof(IncludeShadow))]
	public interface Include : ICallbackable, IDisposable
	{
		// Token: 0x060004CA RID: 1226
		Stream Open(IncludeType type, string fileName, Stream parentStream);

		// Token: 0x060004CB RID: 1227
		void Close(Stream stream);
	}
}

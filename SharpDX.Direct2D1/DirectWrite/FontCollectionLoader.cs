using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200008A RID: 138
	[Shadow(typeof(FontCollectionLoaderShadow))]
	[Guid("cca920e4-52f0-492b-bfa8-29c72ee0a468")]
	public interface FontCollectionLoader : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060002C5 RID: 709
		FontFileEnumerator CreateEnumeratorFromKey(Factory factory, DataPointer collectionKey);
	}
}

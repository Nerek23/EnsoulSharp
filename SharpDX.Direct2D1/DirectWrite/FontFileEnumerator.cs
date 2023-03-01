using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000091 RID: 145
	[Shadow(typeof(FontFileEnumeratorShadow))]
	[Guid("72755049-5ff7-435d-8348-4be97cfa6c7c")]
	public interface FontFileEnumerator : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060002FA RID: 762
		bool MoveNext();

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060002FB RID: 763
		FontFile CurrentFontFile { get; }
	}
}

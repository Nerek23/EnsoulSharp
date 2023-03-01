using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000234 RID: 564
	[Guid("2cd906c1-12e2-11dc-9fed-001143a055f9")]
	[Shadow(typeof(TessellationSinkShadow))]
	public interface TessellationSink : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000D16 RID: 3350
		void AddTriangles(Triangle[] triangles);

		// Token: 0x06000D17 RID: 3351
		void Close();
	}
}

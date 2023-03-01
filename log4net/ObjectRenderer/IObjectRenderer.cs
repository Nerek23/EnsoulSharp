using System;
using System.IO;

namespace log4net.ObjectRenderer
{
	// Token: 0x02000066 RID: 102
	public interface IObjectRenderer
	{
		// Token: 0x06000378 RID: 888
		void RenderObject(RendererMap rendererMap, object obj, TextWriter writer);
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000132 RID: 306
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct QueryDescription1
	{
		// Token: 0x040009F8 RID: 2552
		public QueryType Query;

		// Token: 0x040009F9 RID: 2553
		public int MiscFlags;

		// Token: 0x040009FA RID: 2554
		public ContextType ContextType;
	}
}

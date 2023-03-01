using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000131 RID: 305
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct QueryDescription
	{
		// Token: 0x040009F6 RID: 2550
		public QueryType Type;

		// Token: 0x040009F7 RID: 2551
		public QueryFlags Flags;
	}
}

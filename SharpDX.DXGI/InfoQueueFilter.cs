using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000083 RID: 131
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct InfoQueueFilter
	{
		// Token: 0x04000C31 RID: 3121
		public InfoQueueFilterDescription AllowList;

		// Token: 0x04000C32 RID: 3122
		public InfoQueueFilterDescription DenyList;
	}
}

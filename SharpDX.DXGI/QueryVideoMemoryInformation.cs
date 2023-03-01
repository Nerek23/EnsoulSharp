using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000098 RID: 152
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct QueryVideoMemoryInformation
	{
		// Token: 0x04000DD9 RID: 3545
		public long Budget;

		// Token: 0x04000DDA RID: 3546
		public long CurrentUsage;

		// Token: 0x04000DDB RID: 3547
		public long AvailableForReservation;

		// Token: 0x04000DDC RID: 3548
		public long CurrentReservation;
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000127 RID: 295
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct KeyExchangeHwProtectionData
	{
		// Token: 0x040009B8 RID: 2488
		public int HWProtectionFunctionID;

		// Token: 0x040009B9 RID: 2489
		public IntPtr PInputData;

		// Token: 0x040009BA RID: 2490
		public IntPtr POutputData;

		// Token: 0x040009BB RID: 2491
		public Result Status;
	}
}

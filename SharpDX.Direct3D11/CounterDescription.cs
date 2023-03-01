using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000105 RID: 261
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CounterDescription
	{
		// Token: 0x04000958 RID: 2392
		public CounterKind Counter;

		// Token: 0x04000959 RID: 2393
		public int MiscFlags;
	}
}

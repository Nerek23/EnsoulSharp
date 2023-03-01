using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000130 RID: 304
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct QueryDataTimestampDisjoint
	{
		// Token: 0x040009F4 RID: 2548
		public long Frequency;

		// Token: 0x040009F5 RID: 2549
		public RawBool Disjoint;
	}
}

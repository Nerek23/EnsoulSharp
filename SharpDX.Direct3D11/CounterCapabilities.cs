using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000104 RID: 260
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CounterCapabilities
	{
		// Token: 0x04000955 RID: 2389
		public CounterKind LastDeviceDependentCounter;

		// Token: 0x04000956 RID: 2390
		public int SimultaneousCounterCount;

		// Token: 0x04000957 RID: 2391
		public byte DetectableParallelUnitCount;
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000120 RID: 288
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct FeatureDataGpuVirtualAddressSupport
	{
		// Token: 0x040009AC RID: 2476
		public int MaxGPUVirtualAddressBitsPerResource;

		// Token: 0x040009AD RID: 2477
		public int MaxGPUVirtualAddressBitsPerProcess;
	}
}

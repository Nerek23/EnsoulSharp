using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000124 RID: 292
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct FeatureDataThreading
	{
		// Token: 0x040009B2 RID: 2482
		public RawBool DriverConcurrentCreates;

		// Token: 0x040009B3 RID: 2483
		public RawBool DriverCommandLists;
	}
}

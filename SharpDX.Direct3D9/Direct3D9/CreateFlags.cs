using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200004A RID: 74
	[Flags]
	public enum CreateFlags
	{
		// Token: 0x040005BC RID: 1468
		FpuPreserve = 2,
		// Token: 0x040005BD RID: 1469
		Multithreaded = 4,
		// Token: 0x040005BE RID: 1470
		PureDevice = 16,
		// Token: 0x040005BF RID: 1471
		SoftwareVertexProcessing = 32,
		// Token: 0x040005C0 RID: 1472
		HardwareVertexProcessing = 64,
		// Token: 0x040005C1 RID: 1473
		MixedVertexProcessing = 128,
		// Token: 0x040005C2 RID: 1474
		DisableDriverManagement = 256,
		// Token: 0x040005C3 RID: 1475
		AdapterGroupDevice = 512,
		// Token: 0x040005C4 RID: 1476
		DisableExtendedDriverManagement = 1024,
		// Token: 0x040005C5 RID: 1477
		NoWindowChanges = 2048,
		// Token: 0x040005C6 RID: 1478
		DisablePsgpThreading = 8192,
		// Token: 0x040005C7 RID: 1479
		EnablePresentStatistics = 16384,
		// Token: 0x040005C8 RID: 1480
		DisablePrintScreen = 32768,
		// Token: 0x040005C9 RID: 1481
		AllowScreensavers = 268435456,
		// Token: 0x040005CA RID: 1482
		None = 0
	}
}

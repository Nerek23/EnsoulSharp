using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200006F RID: 111
	[Flags]
	public enum DeviceCreationFlags
	{
		// Token: 0x040001A8 RID: 424
		SingleThreaded = 1,
		// Token: 0x040001A9 RID: 425
		Debug = 2,
		// Token: 0x040001AA RID: 426
		SwitchToRef = 4,
		// Token: 0x040001AB RID: 427
		PreventThreadingOptimizations = 8,
		// Token: 0x040001AC RID: 428
		BgraSupport = 32,
		// Token: 0x040001AD RID: 429
		Debuggable = 64,
		// Token: 0x040001AE RID: 430
		PreventAlteringLayerSettingsFromRegistry = 128,
		// Token: 0x040001AF RID: 431
		DisableGpuTimeout = 256,
		// Token: 0x040001B0 RID: 432
		VideoSupport = 2048,
		// Token: 0x040001B1 RID: 433
		None = 0
	}
}

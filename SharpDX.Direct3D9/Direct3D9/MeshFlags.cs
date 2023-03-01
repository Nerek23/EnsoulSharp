using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000067 RID: 103
	[Flags]
	public enum MeshFlags
	{
		// Token: 0x040006E1 RID: 1761
		Use32Bit = 1,
		// Token: 0x040006E2 RID: 1762
		DoNotClip = 2,
		// Token: 0x040006E3 RID: 1763
		Points = 4,
		// Token: 0x040006E4 RID: 1764
		RTPatches = 8,
		// Token: 0x040006E5 RID: 1765
		NPatches = 16384,
		// Token: 0x040006E6 RID: 1766
		VertexBufferSystemMemory = 16,
		// Token: 0x040006E7 RID: 1767
		VertexBufferManaged = 32,
		// Token: 0x040006E8 RID: 1768
		VertexBufferWriteOnly = 64,
		// Token: 0x040006E9 RID: 1769
		VertexBufferDynamic = 128,
		// Token: 0x040006EA RID: 1770
		VertexBufferSoftware = 32768,
		// Token: 0x040006EB RID: 1771
		IndexBufferSystemMemory = 256,
		// Token: 0x040006EC RID: 1772
		IndexBufferManaged = 512,
		// Token: 0x040006ED RID: 1773
		IndexBufferWriteOnly = 1024,
		// Token: 0x040006EE RID: 1774
		IndexBufferDynamic = 2048,
		// Token: 0x040006EF RID: 1775
		IndexBufferSoftware = 65536,
		// Token: 0x040006F0 RID: 1776
		VertexBufferShare = 4096,
		// Token: 0x040006F1 RID: 1777
		UseHardwareOnly = 8192,
		// Token: 0x040006F2 RID: 1778
		SystemMemory = 272,
		// Token: 0x040006F3 RID: 1779
		Managed = 544,
		// Token: 0x040006F4 RID: 1780
		WriteOnly = 1088,
		// Token: 0x040006F5 RID: 1781
		Dynamic = 2176,
		// Token: 0x040006F6 RID: 1782
		Software = 98304
	}
}

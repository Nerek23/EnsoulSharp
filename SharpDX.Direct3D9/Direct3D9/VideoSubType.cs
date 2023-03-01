using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000A3 RID: 163
	public enum VideoSubType
	{
		// Token: 0x04000991 RID: 2449
		Other,
		// Token: 0x04000992 RID: 2450
		Pci,
		// Token: 0x04000993 RID: 2451
		PciX,
		// Token: 0x04000994 RID: 2452
		PciExpress,
		// Token: 0x04000995 RID: 2453
		Agp,
		// Token: 0x04000996 RID: 2454
		InsideOfChipset = 65536,
		// Token: 0x04000997 RID: 2455
		TracksOnMotherBoardToChip = 131072,
		// Token: 0x04000998 RID: 2456
		TracksOnMotherBoardToSocket = 196608,
		// Token: 0x04000999 RID: 2457
		DaughterBoardConnector = 262144,
		// Token: 0x0400099A RID: 2458
		DaughterBoardConnectorInsideOfNuae = 327680,
		// Token: 0x0400099B RID: 2459
		NonStandard = -2147483648
	}
}

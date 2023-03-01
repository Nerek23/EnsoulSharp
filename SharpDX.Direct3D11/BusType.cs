using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000059 RID: 89
	public enum BusType
	{
		// Token: 0x04000127 RID: 295
		TypeOther,
		// Token: 0x04000128 RID: 296
		TypePci,
		// Token: 0x04000129 RID: 297
		TypePcix,
		// Token: 0x0400012A RID: 298
		TypePciexpress,
		// Token: 0x0400012B RID: 299
		TypeAgp,
		// Token: 0x0400012C RID: 300
		ImplModifierInsideOfChipset = 65536,
		// Token: 0x0400012D RID: 301
		ImplModifierTracksOnMotherBoardToChip = 131072,
		// Token: 0x0400012E RID: 302
		ImplModifierTracksOnMotherBoardToSocket = 196608,
		// Token: 0x0400012F RID: 303
		ImplModifierDaughterBoardConnector = 262144,
		// Token: 0x04000130 RID: 304
		ImplModifierDaughterBoardConnectorInsideOfNuae = 327680,
		// Token: 0x04000131 RID: 305
		ImplModifierNonStandard = -2147483648
	}
}

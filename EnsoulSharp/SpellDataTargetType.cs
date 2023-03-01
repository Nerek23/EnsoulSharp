using System;

namespace EnsoulSharp
{
	// Token: 0x02000032 RID: 50
	public enum SpellDataTargetType
	{
		// Token: 0x0400030C RID: 780
		Unknown = -1,
		// Token: 0x0400030D RID: 781
		Self,
		// Token: 0x0400030E RID: 782
		Target,
		// Token: 0x0400030F RID: 783
		Area,
		// Token: 0x04000310 RID: 784
		Cone,
		// Token: 0x04000311 RID: 785
		SelfAoe,
		// Token: 0x04000312 RID: 786
		TargetOrLocation,
		// Token: 0x04000313 RID: 787
		Location,
		// Token: 0x04000314 RID: 788
		Direction,
		// Token: 0x04000315 RID: 789
		DragDirection,
		// Token: 0x04000316 RID: 790
		LineTargetToCaster,
		// Token: 0x04000317 RID: 791
		AreaClamped,
		// Token: 0x04000318 RID: 792
		LocationClamped,
		// Token: 0x04000319 RID: 793
		TerrainLocation,
		// Token: 0x0400031A RID: 794
		TerrainType
	}
}

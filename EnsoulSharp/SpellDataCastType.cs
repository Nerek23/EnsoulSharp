using System;

namespace EnsoulSharp
{
	// Token: 0x02000031 RID: 49
	public enum SpellDataCastType
	{
		// Token: 0x04000303 RID: 771
		Unknown = -1,
		// Token: 0x04000304 RID: 772
		Instant,
		// Token: 0x04000305 RID: 773
		Missile,
		// Token: 0x04000306 RID: 774
		ArcMissile = 3,
		// Token: 0x04000307 RID: 775
		CircleMissile,
		// Token: 0x04000308 RID: 776
		CircleMissileSynchronized = 7,
		// Token: 0x04000309 RID: 777
		Spline,
		// Token: 0x0400030A RID: 778
		TrackAndContinuePastTarget
	}
}

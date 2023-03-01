using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000088 RID: 136
	public enum ShaderTrackingOption
	{
		// Token: 0x040007B0 RID: 1968
		Ignore,
		// Token: 0x040007B1 RID: 1969
		TrackUninitialized,
		// Token: 0x040007B2 RID: 1970
		TrackRaw,
		// Token: 0x040007B3 RID: 1971
		TrackWar = 4,
		// Token: 0x040007B4 RID: 1972
		TrackWaw = 8,
		// Token: 0x040007B5 RID: 1973
		AllowSame = 16,
		// Token: 0x040007B6 RID: 1974
		TrackAtomicConsistency = 32,
		// Token: 0x040007B7 RID: 1975
		TrackRawAcrossThreadgroups = 64,
		// Token: 0x040007B8 RID: 1976
		TrackWarAcrossThreadgroups = 128,
		// Token: 0x040007B9 RID: 1977
		TrackWawAcrossThreadgroups = 256,
		// Token: 0x040007BA RID: 1978
		TrackAtomicConsistencyAcrossThreadgroups = 512,
		// Token: 0x040007BB RID: 1979
		UnorderedAccessViewSpecificFlags = 960,
		// Token: 0x040007BC RID: 1980
		AllHazards = 1006,
		// Token: 0x040007BD RID: 1981
		AllHazardsAllowingSame = 1022,
		// Token: 0x040007BE RID: 1982
		AllOptions
	}
}

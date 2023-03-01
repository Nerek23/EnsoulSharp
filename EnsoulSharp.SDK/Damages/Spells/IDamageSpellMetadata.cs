using System;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A9 RID: 425
	public interface IDamageSpellMetadata
	{
		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000B1A RID: 2842
		string ChampionName { get; }

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000B1B RID: 2843
		SpellSlot SpellSlot { get; }

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000B1C RID: 2844
		int Stage { get; }
	}
}

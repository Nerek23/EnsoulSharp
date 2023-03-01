using System;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A8 RID: 424
	public interface IDamageSpell
	{
		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000B10 RID: 2832
		// (set) Token: 0x06000B11 RID: 2833
		double CalculatedDamage { get; set; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000B12 RID: 2834
		// (set) Token: 0x06000B13 RID: 2835
		SpellDamageDelegate Damage { get; set; }

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000B14 RID: 2836
		// (set) Token: 0x06000B15 RID: 2837
		DamageType DamageType { get; set; }

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000B16 RID: 2838
		// (set) Token: 0x06000B17 RID: 2839
		SpellSlot Slot { get; set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000B18 RID: 2840
		// (set) Token: 0x06000B19 RID: 2841
		int Stage { get; set; }
	}
}

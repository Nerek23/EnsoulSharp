using System;

namespace EnsoulSharp.SDK.Evade
{
	// Token: 0x020000E6 RID: 230
	public struct ExistSkillshot
	{
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060008C0 RID: 2240 RVA: 0x00037999 File Offset: 0x00035B99
		// (set) Token: 0x060008C1 RID: 2241 RVA: 0x000379A1 File Offset: 0x00035BA1
		public string ChampionName { get; set; }

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x000379AA File Offset: 0x00035BAA
		// (set) Token: 0x060008C3 RID: 2243 RVA: 0x000379B2 File Offset: 0x00035BB2
		public string SpellName { get; set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x000379BB File Offset: 0x00035BBB
		// (set) Token: 0x060008C5 RID: 2245 RVA: 0x000379C3 File Offset: 0x00035BC3
		public string DisplayName { get; set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060008C6 RID: 2246 RVA: 0x000379CC File Offset: 0x00035BCC
		// (set) Token: 0x060008C7 RID: 2247 RVA: 0x000379D4 File Offset: 0x00035BD4
		public EvadeSkillshotType Type { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060008C8 RID: 2248 RVA: 0x000379DD File Offset: 0x00035BDD
		// (set) Token: 0x060008C9 RID: 2249 RVA: 0x000379E5 File Offset: 0x00035BE5
		public SpellSlot Slot { get; set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060008CA RID: 2250 RVA: 0x000379EE File Offset: 0x00035BEE
		// (set) Token: 0x060008CB RID: 2251 RVA: 0x000379F6 File Offset: 0x00035BF6
		public SkillshotCollisionObjectType[] CollisionObjects { get; set; }
	}
}

using System;

namespace EnsoulSharp.SDK.Damages.SummonerSpells
{
	// Token: 0x020000E7 RID: 231
	public interface ISummonerSpell
	{
		// Token: 0x060008CC RID: 2252
		double GetDamage(AIHeroClient source, AIBaseClient target);
	}
}

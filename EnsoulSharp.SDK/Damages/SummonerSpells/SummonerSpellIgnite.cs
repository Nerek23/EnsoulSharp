using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.SummonerSpells
{
	// Token: 0x020000EA RID: 234
	[Export(typeof(ISummonerSpell))]
	[ExportMetadata("SummonerSpell", SummonerSpell.Ignite)]
	public class SummonerSpellIgnite : ISummonerSpell
	{
		// Token: 0x060008D0 RID: 2256 RVA: 0x00037A24 File Offset: 0x00035C24
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)((float)(50 + 20 * source.Level) - target.HPRegenRate / 5f * 3f);
		}
	}
}

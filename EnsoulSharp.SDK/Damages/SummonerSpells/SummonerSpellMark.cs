using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.SummonerSpells
{
	// Token: 0x020000E9 RID: 233
	[Export(typeof(ISummonerSpell))]
	[ExportMetadata("SummonerSpell", SummonerSpell.Mark)]
	public class SummonerSpellMark : ISummonerSpell
	{
		// Token: 0x060008CE RID: 2254 RVA: 0x000379FF File Offset: 0x00035BFF
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(15 + 5 * Math.Max(0, Math.Min(17, source.Level - 1)));
		}
	}
}

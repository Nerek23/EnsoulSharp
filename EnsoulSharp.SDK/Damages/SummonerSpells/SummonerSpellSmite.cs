using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.SummonerSpells
{
	// Token: 0x020000EB RID: 235
	[Export(typeof(ISummonerSpell))]
	[ExportMetadata("SummonerSpell", SummonerSpell.Smite)]
	public class SummonerSpellSmite : ISummonerSpell
	{
		// Token: 0x060008D2 RID: 2258 RVA: 0x00037A50 File Offset: 0x00035C50
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			GameCache.HeroCache heroCache = Library.GameCache.AllHeroCache.Find((GameCache.HeroCache x) => x.Hero.Compare(source));
			if (heroCache != null && heroCache.SmiteState != SmiteState.None)
			{
				if (target.Type == GameObjectType.AIHeroClient)
				{
					if (heroCache.SmiteState == SmiteState.Second || heroCache.SmiteState == SmiteState.Last)
					{
						return (double)(20f + ((float)source.Level - 1f) * 8f);
					}
				}
				else
				{
					if (heroCache.SmiteState == SmiteState.Basic)
					{
						return 600.0;
					}
					if (heroCache.SmiteState == SmiteState.Second)
					{
						return 900.0;
					}
					if (heroCache.SmiteState == SmiteState.Last)
					{
						return 1200.0;
					}
				}
			}
			return 0.0;
		}
	}
}

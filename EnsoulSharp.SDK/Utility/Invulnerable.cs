using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x0200007C RID: 124
	public class Invulnerable
	{
		// Token: 0x060004BC RID: 1212 RVA: 0x000237A0 File Offset: 0x000219A0
		static Invulnerable()
		{
			Invulnerable.PEntries.AddRange(new List<InvulnerableEntry>
			{
				new InvulnerableEntry("FerociousHowl")
				{
					ChampionName = "Alistar",
					CheckFunction = ((AIBaseClient target, DamageType type) => GameObjects.Player.CountEnemyHeroesInRange(GameObjects.Player.GetRealAutoAttackRange(), null) > 1)
				},
				new InvulnerableEntry("FioraW")
				{
					ChampionName = "Fiora"
				},
				new InvulnerableEntry("JaxCounterStrike")
				{
					ChampionName = "Jax",
					DamageType = new DamageType?(DamageType.Physical)
				},
				new InvulnerableEntry("KayleR")
				{
					IsShield = true
				},
				new InvulnerableEntry("KindredRNoDeathBuff")
				{
					MinHealthPercent = 10,
					CheckFunction = ((AIBaseClient target, DamageType type) => target.HealthPercent <= 10f)
				},
				new InvulnerableEntry("malzaharpassiveshield")
				{
					ChampionName = "Malzahar",
					IsShield = true,
					DamageType = new DamageType?(DamageType.Magical)
				},
				new InvulnerableEntry("Meditate")
				{
					ChampionName = "MasterYi",
					CheckFunction = ((AIBaseClient target, DamageType type) => GameObjects.Player.CountEnemyHeroesInRange(GameObjects.Player.GetRealAutoAttackRange(), null) > 1)
				},
				new InvulnerableEntry("MorganaE")
				{
					IsShield = true,
					DamageType = new DamageType?(DamageType.Magical)
				},
				new InvulnerableEntry("NocturneShroudofDarkness")
				{
					ChampionName = "Nocturne"
				},
				new InvulnerableEntry("ShenWBuff")
				{
					DamageType = new DamageType?(DamageType.Physical)
				},
				new InvulnerableEntry("SivirE")
				{
					ChampionName = "Sivir",
					IsShield = true
				},
				new InvulnerableEntry("TaricR"),
				new InvulnerableEntry("UndyingRage")
				{
					ChampionName = "Tryndamere",
					CheckFunction = ((AIBaseClient target, DamageType type) => target.Health <= (new int[]
					{
						30,
						50,
						70
					})[Math.Max(0, target.Spellbook.GetSpell(SpellSlot.R).Level - 1)])
				},
				new InvulnerableEntry("bansheesveil")
				{
					IsShield = true,
					DamageType = new DamageType?(DamageType.Magical)
				},
				new InvulnerableEntry("itemmagekillerveil")
				{
					IsShield = true,
					DamageType = new DamageType?(DamageType.Magical)
				},
				new InvulnerableEntry("YuumiWAlly")
				{
					ChampionName = "Yuumi"
				},
				new InvulnerableEntry("GwenW")
				{
					ChampionName = "Gwen",
					CheckFunction = ((AIBaseClient target, DamageType type) => target.IsInvulnerableVisual)
				}
			});
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x00023A2C File Offset: 0x00021C2C
		public static ReadOnlyCollection<InvulnerableEntry> Entries
		{
			get
			{
				return Invulnerable.PEntries.AsReadOnly();
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00023A38 File Offset: 0x00021C38
		public static bool Check(AIHeroClient hero, DamageType damageType = DamageType.True, bool ignoreShields = true, float damage = -1f)
		{
			if (hero == null || !hero.IsValid)
			{
				return true;
			}
			if (hero.HasBuffOfType(BuffType.Invulnerability) || hero.IsInvulnerable)
			{
				return true;
			}
			foreach (InvulnerableEntry invulnerableEntry in Invulnerable.Entries)
			{
				if (invulnerableEntry.ChampionName == null || invulnerableEntry.ChampionName == hero.CharacterName)
				{
					if (invulnerableEntry.DamageType != null)
					{
						DamageType? damageType2 = invulnerableEntry.DamageType;
						if (!(damageType2.GetValueOrDefault() == damageType & damageType2 != null))
						{
							continue;
						}
					}
					if (hero.HasBuff(invulnerableEntry.BuffName) && (!ignoreShields || !invulnerableEntry.IsShield) && (invulnerableEntry.CheckFunction == null || Invulnerable.ExecuteCheckFunction(invulnerableEntry, hero, damageType)))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00023B20 File Offset: 0x00021D20
		public static void Deregister(InvulnerableEntry entry)
		{
			if (Invulnerable.PEntries.Any((InvulnerableEntry i) => i.BuffName.Equals(entry.BuffName)))
			{
				Invulnerable.PEntries.Remove(entry);
			}
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00023B64 File Offset: 0x00021D64
		public static InvulnerableEntry GetItem(string buffName, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
		{
			return Invulnerable.PEntries.FirstOrDefault((InvulnerableEntry w) => w.BuffName.Equals(buffName, stringComparison));
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00023B9C File Offset: 0x00021D9C
		public static void Register(InvulnerableEntry entry)
		{
			if (!string.IsNullOrEmpty(entry.BuffName) && !Invulnerable.PEntries.Any((InvulnerableEntry i) => i.BuffName.Equals(entry.BuffName)))
			{
				Invulnerable.PEntries.Add(entry);
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00023BF0 File Offset: 0x00021DF0
		private static bool ExecuteCheckFunction(InvulnerableEntry entry, AIHeroClient hero, DamageType damageType)
		{
			return entry != null && entry.CheckFunction(hero, damageType);
		}

		// Token: 0x04000292 RID: 658
		private static readonly List<InvulnerableEntry> PEntries = new List<InvulnerableEntry>();
	}
}

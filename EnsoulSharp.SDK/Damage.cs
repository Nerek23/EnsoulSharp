using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Damages.Items;
using EnsoulSharp.SDK.Damages.Passives;
using EnsoulSharp.SDK.Damages.Spells;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000008 RID: 8
	public static class Damage
	{
		// Token: 0x06000030 RID: 48 RVA: 0x000029FC File Offset: 0x00000BFC
		public static double CalculateDamage(this AIBaseClient source, AIBaseClient target, DamageType damageType, double amount)
		{
			double num = 0.0;
			switch (damageType)
			{
			case DamageType.Physical:
				num = source.CalculatePhysicalDamage(target, amount);
				break;
			case DamageType.Magical:
				num = source.CalculateMagicDamage(target, amount);
				break;
			case DamageType.Mixed:
				num = source.CalculateMixedDamage(target, num / 2.0, num / 2.0);
				break;
			case DamageType.True:
				num = source.CalculateTrueDamage(target, amount);
				break;
			}
			return num;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002A6C File Offset: 0x00000C6C
		public static double GetAutoAttackDamage(this AIBaseClient source, AIBaseClient target, bool includePassive = true, bool includeItem = false)
		{
			Damage.<>c__DisplayClass9_0 CS$<>8__locals1 = new Damage.<>c__DisplayClass9_0();
			CS$<>8__locals1.target = target;
			if (source == null || !source.IsValid)
			{
				return 0.0;
			}
			if (CS$<>8__locals1.target == null || !CS$<>8__locals1.target.IsValid)
			{
				return 0.0;
			}
			double num = (double)source.TotalAttackDamage;
			double num2 = 1.0;
			if (source.Type == GameObjectType.AITurretClient && CS$<>8__locals1.target.Type == GameObjectType.AIMinionClient)
			{
				AITurretClient source2 = source as AITurretClient;
				AIMinionClient minion = CS$<>8__locals1.target as AIMinionClient;
				return source2.AutoAttackDamageOverrideMod(minion, num);
			}
			num = source.CalculatePhysicalDamage(CS$<>8__locals1.target, num);
			if (source.Type == GameObjectType.AIMinionClient && CS$<>8__locals1.target.Type == GameObjectType.AIMinionClient)
			{
				return num;
			}
			CS$<>8__locals1.hero = (source as AIHeroClient);
			if (CS$<>8__locals1.hero == null || !CS$<>8__locals1.hero.IsValid)
			{
				return num;
			}
			if (includePassive)
			{
				string heroCharacterName = CS$<>8__locals1.hero.CharacterName;
				if (Library.DamageData != null && Library.DamageData.PassiveLazies.Any((Lazy<IPassiveDamage, IPassiveDamageMetadata> x) => x.Metadata.ChampionName == heroCharacterName && x.Value.IsActive(CS$<>8__locals1.hero, CS$<>8__locals1.target) && x.Value.OverwriteAttackDamage()))
				{
					num = (from passiveDamage in Library.DamageData.PassiveLazies
					where passiveDamage.Metadata.ChampionName == heroCharacterName
					where passiveDamage.Value.OverwriteAttackDamage()
					where passiveDamage.Value.IsActive(CS$<>8__locals1.hero, CS$<>8__locals1.target)
					select CS$<>8__locals1.hero.CalculateDamage(CS$<>8__locals1.target, passiveDamage.Value.GetDamageType(), passiveDamage.Value.GetDamage(CS$<>8__locals1.hero, CS$<>8__locals1.target))).Sum();
				}
				bool flag = Math.Abs(CS$<>8__locals1.hero.Crit - 1f) < float.Epsilon;
				string heroCharacterName2 = heroCharacterName;
				if (!(heroCharacterName2 == "Fiora"))
				{
					if (!(heroCharacterName2 == "Galio"))
					{
						if (!(heroCharacterName2 == "Jayce"))
						{
							if (!(heroCharacterName2 == "Kayle"))
							{
								if (heroCharacterName2 == "Jhin")
								{
									if (flag || source.HasBuff("JhinPassiveAttackBuff"))
									{
										num *= 0.86 * (double)CS$<>8__locals1.hero.GetCritMultiplier(true);
									}
								}
							}
							else if (flag && !CS$<>8__locals1.hero.HasBuff("KayleE"))
							{
								num += (double)(CS$<>8__locals1.hero.TotalAttackDamage * (CS$<>8__locals1.hero.GetCritMultiplier(true) - 1f));
							}
						}
						else if (flag && !CS$<>8__locals1.hero.HasBuff("JayceHyperCharge"))
						{
							num += (double)(CS$<>8__locals1.hero.TotalAttackDamage * (CS$<>8__locals1.hero.GetCritMultiplier(true) - 1f));
						}
					}
					else if (flag && !CS$<>8__locals1.hero.HasBuff("galiopassivebuff"))
					{
						num += (double)(CS$<>8__locals1.hero.TotalAttackDamage * (CS$<>8__locals1.hero.GetCritMultiplier(true) - 1f));
					}
				}
				else if (flag && !CS$<>8__locals1.hero.HasBuff("FioraE") && !CS$<>8__locals1.hero.HasBuff("FioraE2"))
				{
					num += (double)(CS$<>8__locals1.hero.TotalAttackDamage * (CS$<>8__locals1.hero.GetCritMultiplier(true) - 1f));
				}
				if (!Damage.NoCritFixChampions.Contains(heroCharacterName) && flag)
				{
					num *= (double)CS$<>8__locals1.hero.GetCritMultiplier(true);
				}
				AIMinionClient minionTarget = CS$<>8__locals1.target as AIMinionClient;
				if (minionTarget != null && minionTarget.IsEnemy && minionTarget.Team != GameObjectTeam.Neutral && (CS$<>8__locals1.hero.HasBuff("talentreaperstacksone") || CS$<>8__locals1.hero.HasBuff("talentreaperstackstwo") || CS$<>8__locals1.hero.HasBuff("talentreaperstacksthree")) && GameObjects.Heroes.Any((AIHeroClient h) => !h.Compare(CS$<>8__locals1.hero) && h.Team == CS$<>8__locals1.hero.Team && h.Distance(minionTarget.Position) < 1100f) && minionTarget.HealthPercent < (float)(CS$<>8__locals1.hero.IsMelee ? 50 : 30))
				{
					return 10000000.0;
				}
				double num3 = num;
				DamageData damageData = Library.DamageData;
				num = num3 + (from passiveDamage in (damageData != null) ? damageData.PassiveLazies : null
				where passiveDamage.Metadata.ChampionName == "AllChampions" || passiveDamage.Metadata.ChampionName == heroCharacterName
				where !passiveDamage.Value.OverwriteAttackDamage()
				where passiveDamage.Value.IsActive(CS$<>8__locals1.hero, CS$<>8__locals1.target)
				select CS$<>8__locals1.hero.CalculateDamage(CS$<>8__locals1.target, passiveDamage.Value.GetDamageType(), passiveDamage.Value.GetDamage(CS$<>8__locals1.hero, CS$<>8__locals1.target))).Sum();
				AIHeroClient aiheroClient = CS$<>8__locals1.target as AIHeroClient;
				if (aiheroClient != null)
				{
					if (aiheroClient.CharacterName == "Fizz")
					{
						float num4 = 4f + 0.01f * aiheroClient.TotalMagicalDamage;
						num -= Math.Min((double)num4, num * 0.5);
					}
					GameCache gameCache = Library.GameCache;
					GameCache.HeroCache heroCache = (gameCache != null) ? gameCache.AllHeroCache.Find((GameCache.HeroCache x) => x.Hero.Compare(CS$<>8__locals1.hero)) : null;
					if (heroCache != null)
					{
						if (heroCache.HasItems.Any((ItemId x) => x == ItemId.Wardens_Mail || x == ItemId.Frozen_Heart || x == ItemId.Randuins_Omen))
						{
							num2 *= (double)(1f - (float)Math.Min(40, (int)(0.005f * CS$<>8__locals1.target.MaxHealth)) / 100f);
						}
					}
				}
			}
			if (includeItem)
			{
				Damage.<>c__DisplayClass9_2 CS$<>8__locals3 = new Damage.<>c__DisplayClass9_2();
				CS$<>8__locals3.CS$<>8__locals2 = CS$<>8__locals1;
				Damage.<>c__DisplayClass9_2 CS$<>8__locals4 = CS$<>8__locals3;
				GameCache gameCache2 = Library.GameCache;
				CS$<>8__locals4.heroCache = ((gameCache2 != null) ? gameCache2.AllHeroCache.Find((GameCache.HeroCache x) => x.Hero.Compare(CS$<>8__locals3.CS$<>8__locals2.hero)) : null);
				if (CS$<>8__locals3.heroCache != null)
				{
					double num5 = num;
					DamageData damageData2 = Library.DamageData;
					num = num5 + (from itemDamage in (damageData2 != null) ? damageData2.ItemLazies : null
					where CS$<>8__locals3.heroCache.HasItems.Any((ItemId id) => itemDamage.Value.ItemId == id)
					where itemDamage.Value.IsActive(CS$<>8__locals3.CS$<>8__locals2.hero, CS$<>8__locals3.CS$<>8__locals2.target)
					select CS$<>8__locals3.CS$<>8__locals2.hero.CalculateDamage(CS$<>8__locals3.CS$<>8__locals2.target, CS$<>8__locals3.heroCache.IsZeri ? DamageType.Magical : itemDamage.Value.DamageType, itemDamage.Value.GetPassiveDamage(CS$<>8__locals3.CS$<>8__locals2.hero, CS$<>8__locals3.CS$<>8__locals2.target))).Sum();
				}
			}
			return Math.Max(Math.Floor(num * num2), 0.0);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000316C File Offset: 0x0000136C
		public static double GetSpellDamage(this AIHeroClient source, AIBaseClient target, SpellSlot spellSlot, int stage = 0)
		{
			if (source == null || !source.IsValid || target == null || !target.IsValid)
			{
				return 0.0;
			}
			DamageData damageData = Library.DamageData;
			DamageSpell damageSpell = (damageData != null) ? damageData.GetDamageSpell(source, target, spellSlot, stage) : null;
			if (damageSpell == null)
			{
				return 0.0;
			}
			return damageSpell.CalculatedDamage;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000031D0 File Offset: 0x000013D0
		public static double GetSpellDamageFromName(this AIHeroClient source, AIBaseClient target, string spellName, int stage = 0)
		{
			if (source == null || !source.IsValid || target == null || !target.IsValid)
			{
				return 0.0;
			}
			if (Orbwalker.IsAutoAttack(spellName))
			{
				return source.GetAutoAttackDamage(target, true, false);
			}
			foreach (SpellDataInst spellDataInst in source.Spellbook.Spells)
			{
				if (spellDataInst.Name.ToLower() == spellName.ToLower())
				{
					return source.GetSpellDamage(target, spellDataInst.Slot, stage);
				}
			}
			return 0.0;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000326C File Offset: 0x0000146C
		public static double GetSylasStealDamage(this AIHeroClient source, AIHeroClient originHero, AIBaseClient target, int stage = 0)
		{
			if (source == null || !source.IsValid || target == null || !target.IsValid)
			{
				return 0.0;
			}
			DamageData damageData = Library.DamageData;
			DamageSpell damageSpell = (damageData != null) ? damageData.GetStealSpellDamage(source, originHero, target, stage) : null;
			if (damageSpell == null)
			{
				return 0.0;
			}
			return damageSpell.CalculatedDamage;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000032D0 File Offset: 0x000014D0
		public static double GetItemDamage(this AIHeroClient source, AIBaseClient target, DamageItems item)
		{
			if (source == null || !source.IsValid || target == null || !target.IsValid)
			{
				return 0.0;
			}
			DamageData damageData = Library.DamageData;
			double? num = (damageData != null) ? new double?(damageData.GetItemDamage(source, target, item, ItemDamageType.Default, false)) : null;
			if (num == null)
			{
				return 0.0;
			}
			return num.GetValueOrDefault();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003348 File Offset: 0x00001548
		public static double GetSummonerSpellDamage(this AIHeroClient source, AIBaseClient target, SummonerSpell summonerSpell)
		{
			if (source == null || !source.IsValid || target == null || !target.IsValid)
			{
				return 0.0;
			}
			DamageData damageData = Library.DamageData;
			double? num = (damageData != null) ? new double?(damageData.GetSummonerSpellDamage(source, target, summonerSpell)) : null;
			if (num == null)
			{
				return 0.0;
			}
			return num.GetValueOrDefault();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000033BD File Offset: 0x000015BD
		public static double CalculateTrueDamage(this AIBaseClient source, AIBaseClient target, double amount)
		{
			return Math.Floor(Math.Max(amount, 0.0));
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000033D3 File Offset: 0x000015D3
		public static double CalculateMixedDamage(this AIBaseClient source, AIBaseClient target, double physicalAmount, double magicalAmount)
		{
			return source.CalculatePhysicalDamage(target, physicalAmount) + source.CalculateMagicDamage(target, magicalAmount);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000033E8 File Offset: 0x000015E8
		public static double CalculateMagicDamage(this AIBaseClient source, AIBaseClient target, double amount)
		{
			if (amount <= 0.0)
			{
				return 0.0;
			}
			if (source == null || !source.IsValid)
			{
				return 0.0;
			}
			if (target == null || !target.IsValid)
			{
				return 0.0;
			}
			float spellBlock = target.SpellBlock;
			float bonusSpellBlock = target.BonusSpellBlock;
			double num = 0.0;
			double num2;
			if (spellBlock < 0f)
			{
				num2 = (double)(2f - 100f / (100f - spellBlock));
			}
			else if (spellBlock * source.PercentMagicPenetrationMod - bonusSpellBlock * (1f - source.PercentBonusMagicPenetrationMod) - source.FlatMagicPenetrationMod - source.MagicLethality < 0f)
			{
				num2 = 1.0;
			}
			else
			{
				num2 = (double)(100f / (100f + spellBlock * source.PercentMagicPenetrationMod - bonusSpellBlock * (1f - source.PercentBonusMagicPenetrationMod) - source.FlatMagicPenetrationMod - source.MagicLethality));
			}
			if (target.HasBuff("cursedtouch"))
			{
				num = 0.10000000149011612 * amount;
			}
			return Math.Max(Math.Floor(source.DamageReductionMod(target, num2 * amount, DamageType.Magical)) + num, 0.0);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000351C File Offset: 0x0000171C
		public static double CalculatePhysicalDamage(this AIBaseClient source, AIBaseClient target, double amount)
		{
			if (amount <= 0.0)
			{
				return 0.0;
			}
			if (source == null || !source.IsValid)
			{
				return 0.0;
			}
			if (target == null || !target.IsValid)
			{
				return 0.0;
			}
			double num = (double)source.PercentArmorPenetrationMod;
			double num2 = (double)(source.FlatArmorPenetrationMod + source.PhysicalLethality);
			double num3 = (double)source.PercentBonusArmorPenetrationMod;
			if (source.Type == GameObjectType.AIMinionClient)
			{
				num2 = 0.0;
				num = 1.0;
				num3 = 1.0;
			}
			else if (source.Type == GameObjectType.AIHeroClient)
			{
				AIHeroClient aiheroClient = source as AIHeroClient;
				num2 = (double)(source.PhysicalLethality * (0.6f + 0.4f * (float)aiheroClient.Level / 18f));
				if (double.IsNaN(num2))
				{
					num2 = 0.0;
				}
			}
			else if (source.Type == GameObjectType.AITurretClient)
			{
				num2 = 0.0;
				num = 1.0;
				num3 = 1.0;
			}
			float armor = target.Armor;
			float bonusArmor = target.BonusArmor;
			double num4;
			if (armor < 0f)
			{
				num4 = (double)(2f - 100f / (100f - armor));
			}
			else if ((double)armor * num - (double)bonusArmor * (1.0 - num3) - num2 < 0.0)
			{
				num4 = 1.0;
			}
			else
			{
				num4 = 100.0 / (100.0 + (double)armor * num - (double)bonusArmor * (1.0 - num3) - num2);
			}
			return Math.Max(Math.Floor(source.DamageReductionMod(target, num4 * amount, DamageType.Physical)), 0.0);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000036D4 File Offset: 0x000018D4
		public static double DamageReductionMod(this AIBaseClient source, AIBaseClient target, double amount, DamageType damageType)
		{
			if (source == null || !source.IsValid)
			{
				return 0.0;
			}
			if (target == null || !target.IsValid)
			{
				return 0.0;
			}
			string characterName = target.CharacterName;
			AIHeroClient aiheroClient = target as AIHeroClient;
			AIMinionClient aiminionClient = source as AIMinionClient;
			if (aiheroClient != null && aiminionClient != null && source.Team == GameObjectTeam.Neutral && source.IsDragon())
			{
				if (aiheroClient.IsAlly)
				{
					amount *= 1.0 + 0.2 * (double)Library.GameCache.AllyDragonKills;
				}
				else
				{
					amount *= 1.0 + 0.2 * (double)Library.GameCache.EnemyDragonKills;
				}
			}
			AIHeroClient aiheroClient2 = source as AIHeroClient;
			AIMinionClient aiminionClient2 = target as AIMinionClient;
			if (aiheroClient2 != null)
			{
				if (aiminionClient2 != null && target.Team == GameObjectTeam.Neutral)
				{
					if (source.HasBuff("barontarget") && characterName == "SRU_Baron")
					{
						amount *= 0.5;
					}
					if (source.IsDragon())
					{
						if (source.IsAlly)
						{
							amount *= 1.0 - 0.07 * (double)Library.GameCache.AllyDragonKills;
						}
						else
						{
							amount *= 1.0 - 0.07 * (double)Library.GameCache.EnemyDragonKills;
						}
					}
					if (aiheroClient2.CharacterName == "Shyvana" && target.GetJungleType().HasFlag(JungleType.Legendary))
					{
						amount *= 1.2;
					}
				}
				if (source.HasBuff("SummonerExhaust"))
				{
					amount *= 0.6499999761581421;
				}
			}
			if (target.HasBuff("vladimirhemoplaguedamageamp"))
			{
				amount *= 1.1;
			}
			BuffInstance buff = source.GetBuff("sonapassivedebuff");
			if (buff != null && buff.Caster != null && buff.Caster.IsValid)
			{
				AIHeroClient aiheroClient3 = (AIHeroClient)buff.Caster;
				amount *= 0.75 - 0.04 * (double)aiheroClient3.TotalMagicalDamage / 100.0;
			}
			if (aiminionClient2 != null && aiminionClient2.HasBuff("exaltedwithbaronnashorminion"))
			{
				MinionTypes minionType = aiminionClient2.GetMinionType();
				if (minionType.HasFlag(MinionTypes.Ranged))
				{
					if (source.Type == GameObjectType.AIHeroClient)
					{
						amount *= 0.3;
					}
				}
				else if (minionType.HasFlag(MinionTypes.Melee))
				{
					if (source.Type == GameObjectType.AIHeroClient)
					{
						amount *= 0.3;
					}
					else if (source.Type == GameObjectType.AIMinionClient && source.Team != GameObjectTeam.Neutral)
					{
						amount *= 0.25;
					}
				}
			}
			if (aiminionClient != null && target.Type == GameObjectType.AITurretClient && aiminionClient.GetMinionType().HasFlag(MinionTypes.Siege) && aiminionClient.HasBuff("exaltedwithbaronnashorminion"))
			{
				amount *= 2.0;
			}
			if (aiheroClient != null)
			{
				if (characterName == "Alistar" && aiheroClient.HasBuff("FerociousHowl"))
				{
					int spellLevel = Damage.GetSpellLevel(aiheroClient, SpellSlot.R);
					amount *= 1.0 - Damage.AlistarR[Math.Min(spellLevel, 2)];
				}
				if (characterName == "Amumu" && aiheroClient.HasBuff("Tantrum") && damageType == DamageType.Physical)
				{
					int spellLevel2 = Damage.GetSpellLevel(aiheroClient, SpellSlot.E);
					amount -= Damage.AmumuE[Math.Min(spellLevel2, 4)] + 0.03 * (double)aiheroClient.BonusArmor + 0.03 * (double)aiheroClient.BonusSpellBlock;
				}
				if (characterName == "Braum" && aiheroClient.HasBuff("braumeshieldbuff"))
				{
					int spellLevel3 = Damage.GetSpellLevel(aiheroClient, SpellSlot.E);
					amount *= 1.0 - Damage.BraumE[Math.Min(spellLevel3, 4)];
				}
				if (characterName == "Galio" && aiheroClient.HasBuff("galiowbuff"))
				{
					int spellLevel4 = Damage.GetSpellLevel(aiheroClient, SpellSlot.W);
					double num = Damage.GalioW[Math.Min(spellLevel4, 4)] + 0.05 * (double)aiheroClient.TotalMagicalDamage / 100.0 + 0.08 * (double)aiheroClient.BonusSpellBlock / 100.0;
					amount *= 1.0 - ((damageType == DamageType.Magical) ? num : ((damageType == DamageType.Physical) ? (num / 2.0) : 0.0));
				}
				if (characterName == "Garen" && aiheroClient.HasBuff("GarenW"))
				{
					BuffInstance buff2 = aiheroClient.GetBuff("GarenW");
					if (buff2 != null)
					{
						amount *= 1.0 - (((double)(Game.Time - buff2.StartTime) < 0.75) ? 0.6 : 0.3);
					}
				}
				if (characterName == "Gragas" && aiheroClient.HasBuff("gragaswself"))
				{
					int spellLevel5 = Damage.GetSpellLevel(aiheroClient, SpellSlot.W);
					amount *= 1.0 - Damage.GragasW[Math.Min(spellLevel5, 4)] - 0.04 * (double)aiheroClient.TotalMagicalDamage / 100.0;
				}
				if (characterName == "Irelia" && aiheroClient.HasBuff("ireliawdefense"))
				{
					if (damageType == DamageType.Physical)
					{
						amount *= 0.6 - 0.01764705882352941 * (double)(aiheroClient.Level - 1);
					}
					else if (damageType == DamageType.Magical)
					{
						amount *= 0.8 - 0.008823529411764706 * (double)(aiheroClient.Level - 1);
					}
				}
				if (characterName == "Kassadin" && aiheroClient.HasBuff("voidstone") && damageType == DamageType.Magical)
				{
					amount *= 0.85;
				}
				if (characterName == "MasterYi" && aiheroClient.HasBuff("Meditate"))
				{
					int spellLevel6 = Damage.GetSpellLevel(aiheroClient, SpellSlot.W);
					amount *= 1.0 - Damage.MasterYiW[Math.Min(spellLevel6, 4)] * ((source.Type == GameObjectType.AITurretClient) ? 0.5 : 1.0);
				}
				if (characterName == "Warwick" && aiheroClient.HasBuff("WarwickE"))
				{
					int spellLevel7 = Damage.GetSpellLevel(aiheroClient, SpellSlot.E);
					amount *= 1.0 - Damage.WarwickE[Math.Min(spellLevel7, 4)];
				}
			}
			return amount;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003D88 File Offset: 0x00001F88
		public static float GetCritMultiplier(this AIHeroClient hero, bool checkCrit = false)
		{
			float num = 1f;
			GameCache gameCache = Library.GameCache;
			GameCache.HeroCache heroCache = (gameCache != null) ? gameCache.AllHeroCache.Find((GameCache.HeroCache x) => x.Hero.Compare(hero)) : null;
			if (heroCache != null)
			{
				if (heroCache.HasItems.Any((ItemId x) => x == ItemId.Rageknife || x == ItemId.Guinsoos_Rageblade))
				{
					num = 0f;
				}
				if (heroCache.HasItems.Any((ItemId x) => x == ItemId.Infinity_Edge))
				{
					num = 0.35f;
				}
			}
			if (Math.Abs(hero.Crit - 1f) >= 1E-45f)
			{
				return 1f;
			}
			return 1f + num;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003E5C File Offset: 0x0000205C
		internal static float GetTotalAaDamage(this AIBaseClient hero)
		{
			float num = hero.TotalAttackDamage;
			if (hero.CharacterName == "Sylas")
			{
				num += hero.TotalMagicalDamage * 0.6f;
			}
			return num;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003E94 File Offset: 0x00002094
		internal static float GetBonusAaDamage(this AIBaseClient hero)
		{
			float num = hero.TotalAttackDamage - hero.BaseAttackDamage;
			if (hero.CharacterName == "Sylas")
			{
				num += hero.TotalMagicalDamage * 0.4f;
			}
			return num;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003ED4 File Offset: 0x000020D4
		private static double AutoAttackDamageOverrideMod(this AITurretClient source, AIMinionClient minion, double amount)
		{
			double result = amount;
			MinionTypes minionType = minion.GetMinionType();
			if (minionType.HasFlag(MinionTypes.Melee) && !minionType.HasFlag(MinionTypes.Super))
			{
				result = 0.45 * (double)minion.MaxHealth;
			}
			else if (minionType.HasFlag(MinionTypes.Ranged) && !minionType.HasFlag(MinionTypes.Siege))
			{
				result = 0.7 * (double)minion.MaxHealth;
			}
			else if (minionType.HasFlag(MinionTypes.Siege))
			{
				switch (source.GetTurretType())
				{
				case TurretType.TierOne:
					result = 0.14 * (double)minion.MaxHealth;
					break;
				case TurretType.TierTwo:
					result = 0.11 * (double)minion.MaxHealth;
					break;
				case TurretType.TierThree:
				case TurretType.TierFour:
					result = 0.08 * (double)minion.MaxHealth;
					break;
				}
			}
			else if (minionType.HasFlag(MinionTypes.Super))
			{
				result = 0.05 * (double)minion.MaxHealth;
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004000 File Offset: 0x00002200
		private static int GetSpellLevel(AIBaseClient source, SpellSlot slot)
		{
			int num = source.Spellbook.GetSpell(slot).Level;
			if (num == 0)
			{
				num = 1;
			}
			return num;
		}

		// Token: 0x0400001C RID: 28
		private static readonly double[] AlistarR = new double[]
		{
			0.55,
			0.65,
			0.75
		};

		// Token: 0x0400001D RID: 29
		private static readonly double[] AmumuE = new double[]
		{
			5.0,
			7.0,
			9.0,
			11.0,
			13.0
		};

		// Token: 0x0400001E RID: 30
		private static readonly double[] BraumE = new double[]
		{
			0.3,
			0.325,
			0.35,
			0.375,
			0.4
		};

		// Token: 0x0400001F RID: 31
		private static readonly double[] GalioW = new double[]
		{
			0.2,
			0.25,
			0.3,
			0.35,
			0.4
		};

		// Token: 0x04000020 RID: 32
		private static readonly double[] GragasW = new double[]
		{
			0.1,
			0.12,
			0.14,
			0.16,
			0.18
		};

		// Token: 0x04000021 RID: 33
		private static readonly double[] MasterYiW = new double[]
		{
			0.6,
			0.625,
			0.65,
			0.675,
			0.7
		};

		// Token: 0x04000022 RID: 34
		private static readonly double[] WarwickE = new double[]
		{
			0.35,
			0.4,
			0.45,
			0.5,
			0.55
		};

		// Token: 0x04000023 RID: 35
		private static readonly HashSet<string> NoCritFixChampions = new HashSet<string>
		{
			"Ashe",
			"Corki",
			"Fiora",
			"Galio",
			"Graves",
			"Jayce",
			"Kayle",
			"Kled",
			"Pantheon",
			"Shaco",
			"Urgot",
			"Yasuo",
			"Zac",
			"Zeri"
		};
	}
}

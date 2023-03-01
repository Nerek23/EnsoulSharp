using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200000F RID: 15
	public static class AIMinionClientExtensions
	{
		// Token: 0x06000076 RID: 118 RVA: 0x00005390 File Offset: 0x00003590
		public static JungleType GetJungleType(this AIBaseClient minion)
		{
			if (minion != null && minion.IsValid && minion.Type == GameObjectType.AIMinionClient && minion.Team == GameObjectTeam.Neutral)
			{
				if (AIMinionClientExtensions.SmallJungleNameList.Contains(minion.CharacterName))
				{
					return JungleType.All | JungleType.Small;
				}
				if (AIMinionClientExtensions.LargeJungleNameList.Contains(minion.CharacterName))
				{
					return JungleType.All | JungleType.Large;
				}
				if (AIMinionClientExtensions.LegendaryJungleNameList.Contains(minion.CharacterName))
				{
					return JungleType.All | JungleType.Legendary;
				}
			}
			return JungleType.Unknown;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00005404 File Offset: 0x00003604
		public static JungleType GetJungleType(this AIMinionClient minion)
		{
			if (minion != null && minion.IsValid)
			{
				if (AIMinionClientExtensions.SmallJungleNameList.Contains(minion.CharacterName))
				{
					return JungleType.All | JungleType.Small;
				}
				if (AIMinionClientExtensions.LargeJungleNameList.Contains(minion.CharacterName))
				{
					return JungleType.All | JungleType.Large;
				}
				if (AIMinionClientExtensions.LegendaryJungleNameList.Contains(minion.CharacterName))
				{
					return JungleType.All | JungleType.Legendary;
				}
			}
			return JungleType.Unknown;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00005460 File Offset: 0x00003660
		public static MinionTypes GetMinionType(this AIMinionClient minion)
		{
			if (minion == null || !minion.IsValid)
			{
				return MinionTypes.Unknown;
			}
			string characterName = minion.CharacterName;
			if (AIMinionClientExtensions.NormalMinionList.Contains(characterName))
			{
				return MinionTypes.Normal | (minion.CharacterName.Contains("Melee") ? MinionTypes.Melee : MinionTypes.Ranged) | MinionTypes.All;
			}
			if (AIMinionClientExtensions.SiegeMinionList.Contains(characterName))
			{
				return MinionTypes.All | MinionTypes.Ranged | MinionTypes.Siege;
			}
			if (AIMinionClientExtensions.SuperMinionList.Contains(characterName))
			{
				return MinionTypes.All | MinionTypes.Melee | MinionTypes.Super;
			}
			if (AIMinionClientExtensions.WardList.Contains(characterName))
			{
				return MinionTypes.Ward;
			}
			if (!AIMinionClientExtensions.JunglePlantList.Contains(characterName.ToLower()))
			{
				return MinionTypes.Unknown;
			}
			return MinionTypes.JunglePlant;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000054F8 File Offset: 0x000036F8
		public static bool IsJungle(this AttackableUnit minion)
		{
			if (minion != null && minion.IsValid && minion.Type == GameObjectType.AIMinionClient)
			{
				AIMinionClient aiminionClient = (AIMinionClient)minion;
				if (aiminionClient.IsValid)
				{
					return aiminionClient.GetJungleType().HasFlag(JungleType.All);
				}
			}
			return false;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00005548 File Offset: 0x00003748
		public static bool IsJungle(this AIBaseClient minion)
		{
			if (minion != null && minion.IsValid && minion.Type == GameObjectType.AIMinionClient)
			{
				AIMinionClient aiminionClient = (AIMinionClient)minion;
				if (aiminionClient.IsValid)
				{
					return aiminionClient.GetJungleType().HasFlag(JungleType.All);
				}
			}
			return false;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005596 File Offset: 0x00003796
		public static bool IsJungle(this AIMinionClient mob)
		{
			return mob != null && mob.IsValid && mob.GetJungleType().HasFlag(JungleType.All);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000055C1 File Offset: 0x000037C1
		public static bool IsDragon(this AIBaseClient mob)
		{
			return mob != null && mob.IsValid && mob.Type == GameObjectType.AIMinionClient && mob.Team == GameObjectTeam.Neutral && AIMinionClientExtensions.DragonNameList.Contains(mob.CharacterName);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000055FC File Offset: 0x000037FC
		public static bool IsBaron(this AIBaseClient mob)
		{
			return mob != null && mob.IsValid && mob.Type == GameObjectType.AIMinionClient && mob.Team == GameObjectTeam.Neutral && AIMinionClientExtensions.BaronNameList.Contains(mob.CharacterName);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00005638 File Offset: 0x00003838
		public static bool IsMinion(this AttackableUnit minion)
		{
			if (minion != null && minion.IsValid && minion.Type == GameObjectType.AIMinionClient)
			{
				AIMinionClient minion2 = minion as AIMinionClient;
				return minion2.GetMinionType().HasFlag(MinionTypes.Melee) || minion2.GetMinionType().HasFlag(MinionTypes.Ranged);
			}
			return false;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00005698 File Offset: 0x00003898
		public static bool IsMinion(this AIBaseClient minion)
		{
			if (minion != null && minion.IsValid && minion.Type == GameObjectType.AIMinionClient)
			{
				AIMinionClient minion2 = minion as AIMinionClient;
				return minion2.GetMinionType().HasFlag(MinionTypes.Melee) || minion2.GetMinionType().HasFlag(MinionTypes.Ranged);
			}
			return false;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000056F8 File Offset: 0x000038F8
		public static bool IsMinion(this AIMinionClient minion)
		{
			return minion.GetMinionType().HasFlag(MinionTypes.Melee) || minion.GetMinionType().HasFlag(MinionTypes.Ranged);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000572C File Offset: 0x0000392C
		public static bool IsPet(this AIBaseClient minion, bool includeClones = true)
		{
			return !(minion == null) && minion.IsValid && minion.Type == GameObjectType.AIMinionClient && minion.Team != GameObjectTeam.Neutral && (AIMinionClientExtensions.PetList.Contains(minion.CharacterName.ToLower()) || (includeClones && AIMinionClientExtensions.CloneList.Contains(minion.CharacterName.ToLower())));
		}

		// Token: 0x04000038 RID: 56
		private static readonly HashSet<string> CloneList = new HashSet<string>
		{
			"leblanc",
			"monkeyking",
			"neeko",
			"shaco"
		};

		// Token: 0x04000039 RID: 57
		private static readonly HashSet<string> NormalMinionList = new HashSet<string>
		{
			"SRU_ChaosMinionMelee",
			"SRU_ChaosMinionRanged",
			"SRU_OrderMinionMelee",
			"SRU_OrderMinionRanged",
			"HA_ChaosMinionMelee",
			"HA_ChaosMinionRanged",
			"HA_OrderMinionMelee",
			"HA_OrderMinionRanged"
		};

		// Token: 0x0400003A RID: 58
		private static readonly HashSet<string> PetList = new HashSet<string>
		{
			"tibbers",
			"annietibbers",
			"elisespiderling",
			"heimertyellow",
			"heimertblue",
			"ivernminion",
			"malzaharvoidling",
			"zacrebirthbloblet",
			"shacobox",
			"yorickghoulmelee",
			"yorickbigghoul",
			"zyrathornplant",
			"zyragraspingplant",
			"teemomushroom",
			"apheliosturret",
			"kalistaspawn",
			"jhintrap",
			"nidaleespear",
			"illaoiminion",
			"sru_riftherald_mercenary",
			"belvethvoidling"
		};

		// Token: 0x0400003B RID: 59
		private static readonly HashSet<string> SiegeMinionList = new HashSet<string>
		{
			"SRU_ChaosMinionSiege",
			"SRU_OrderMinionSiege",
			"HA_ChaosMinionSiege",
			"HA_OrderMinionSiege"
		};

		// Token: 0x0400003C RID: 60
		private static readonly HashSet<string> SuperMinionList = new HashSet<string>
		{
			"SRU_ChaosMinionSuper",
			"SRU_OrderMinionSuper",
			"HA_ChaosMinionSuper",
			"HA_OrderMinionSuper"
		};

		// Token: 0x0400003D RID: 61
		private static readonly HashSet<string> WardList = new HashSet<string>
		{
			"SightWard",
			"YellowTrinket",
			"BlueTrinket",
			"JammerDevice",
			"PerksZombieWard"
		};

		// Token: 0x0400003E RID: 62
		private static readonly HashSet<string> JunglePlantList = new HashSet<string>
		{
			"sru_plant_health",
			"sru_plant_satchel",
			"sru_plant_vision"
		};

		// Token: 0x0400003F RID: 63
		private static readonly HashSet<string> LargeJungleNameList = new HashSet<string>
		{
			"SRU_Razorbeak",
			"SRU_Red",
			"SRU_Krug",
			"SRU_Murkwolf",
			"SRU_Blue",
			"SRU_Gromp",
			"Sru_Crab",
			"TT_NGolem",
			"TT_NWraith",
			"TT_NWolf",
			"SLIME_Razorbeak",
			"SLIME_Murkwolf",
			"SLIME_Gromp",
			"SLIME_Red",
			"SLIME_Blue",
			"SLIME_Crab",
			"SLIME_NexusMinionBlue",
			"SLIME_NexusMinionRed"
		};

		// Token: 0x04000040 RID: 64
		private static readonly HashSet<string> LegendaryJungleNameList = new HashSet<string>
		{
			"SRU_Dragon_Air",
			"SRU_Dragon_Earth",
			"SRU_Dragon_Fire",
			"SRU_Dragon_Water",
			"SRU_Dragon_Elder",
			"SRU_Dragon_Chemtech",
			"SRU_Dragon_Hextech",
			"SRU_RiftHerald",
			"SRU_Baron",
			"TT_Spiderboss",
			"SLIME_RiftHerald",
			"SLIME_NexusMinionBlue",
			"SLIME_NexusMinionRed"
		};

		// Token: 0x04000041 RID: 65
		private static readonly HashSet<string> SmallJungleNameList = new HashSet<string>
		{
			"SRU_RazorbeakMini",
			"SRU_MurkwolfMini",
			"SRU_KrugMini",
			"TestCubeRender",
			"SRU_KrugMiniMini",
			"TT_NGolem2",
			"TT_NWraith2",
			"TT_NWolf2",
			"SLIME_RazorbeakMini",
			"SLIME_MurkwolfMini"
		};

		// Token: 0x04000042 RID: 66
		private static readonly HashSet<string> BaronNameList = new HashSet<string>
		{
			"SRU_RiftHerald",
			"SRU_Baron",
			"TT_Spiderboss",
			"SLIME_RiftHerald"
		};

		// Token: 0x04000043 RID: 67
		private static readonly HashSet<string> DragonNameList = new HashSet<string>
		{
			"SRU_Dragon_Air",
			"SRU_Dragon_Earth",
			"SRU_Dragon_Fire",
			"SRU_Dragon_Water",
			"SRU_Dragon_Elder",
			"SRU_Dragon_Chemtech",
			"SRU_Dragon_Hextech"
		};
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000036 RID: 54
	[Export(typeof(GameObjects))]
	public class GameObjects
	{
		// Token: 0x06000285 RID: 645 RVA: 0x0001070F File Offset: 0x0000E90F
		public GameObjects()
		{
			GameObjects.Initialized();
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000286 RID: 646 RVA: 0x0001071C File Offset: 0x0000E91C
		public static IEnumerable<GameObject> AllGameObjects
		{
			get
			{
				return GameObjects.GameObjectsHashSet;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00010723 File Offset: 0x0000E923
		public static IEnumerable<AIBaseClient> AiBaseObjects
		{
			get
			{
				return GameObjects.AIBaseClientsHashSet;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000288 RID: 648 RVA: 0x0001072A File Offset: 0x0000E92A
		public static IEnumerable<MissileClient> Missiles
		{
			get
			{
				return GameObjects.MissilesHashSet;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00010731 File Offset: 0x0000E931
		public static IEnumerable<AttackableUnit> AttackableUnits
		{
			get
			{
				return GameObjects.AttackableUnitsHashSet;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00010738 File Offset: 0x0000E938
		public static IEnumerable<AIMinionClient> Minions
		{
			get
			{
				return GameObjects.MinionsHashSet;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600028B RID: 651 RVA: 0x0001073F File Offset: 0x0000E93F
		public static IEnumerable<AIMinionClient> AllyMinions
		{
			get
			{
				return GameObjects.AllyMinionsHashSet;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00010746 File Offset: 0x0000E946
		public static IEnumerable<AIMinionClient> EnemyMinions
		{
			get
			{
				return GameObjects.EnemyMinionsHashSet;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0001074D File Offset: 0x0000E94D
		public static IEnumerable<AIMinionClient> Jungle
		{
			get
			{
				return GameObjects.JungleHashSet;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600028E RID: 654 RVA: 0x00010754 File Offset: 0x0000E954
		public static IEnumerable<AIMinionClient> JungleSmall
		{
			get
			{
				return GameObjects.JungleSmallHashSet;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0001075B File Offset: 0x0000E95B
		public static IEnumerable<AIMinionClient> JungleLarge
		{
			get
			{
				return GameObjects.JungleLargeHashSet;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000290 RID: 656 RVA: 0x00010762 File Offset: 0x0000E962
		public static IEnumerable<AIMinionClient> JungleLegendary
		{
			get
			{
				return GameObjects.JungleLegendaryHashSet;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00010769 File Offset: 0x0000E969
		public static IEnumerable<AIMinionClient> JunglePlant
		{
			get
			{
				return GameObjects.JunglePlantHashSet;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00010770 File Offset: 0x0000E970
		public static IEnumerable<AIMinionClient> Wards
		{
			get
			{
				return GameObjects.WardsHashSet;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00010777 File Offset: 0x0000E977
		public static IEnumerable<AIMinionClient> AllyWards
		{
			get
			{
				return GameObjects.AllyWardsHashSet;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000294 RID: 660 RVA: 0x0001077E File Offset: 0x0000E97E
		public static IEnumerable<AIMinionClient> EnemyWards
		{
			get
			{
				return GameObjects.EnemyWardsHashSet;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000295 RID: 661 RVA: 0x00010785 File Offset: 0x0000E985
		public static IEnumerable<AIHeroClient> Heroes
		{
			get
			{
				return GameObjects.HeroesHashSet;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000296 RID: 662 RVA: 0x0001078C File Offset: 0x0000E98C
		public static IEnumerable<AIHeroClient> AllyHeroes
		{
			get
			{
				return GameObjects.AllyHeroesHashSet;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00010793 File Offset: 0x0000E993
		public static IEnumerable<AIHeroClient> EnemyHeroes
		{
			get
			{
				return GameObjects.EnemyHeroesHashSet;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000298 RID: 664 RVA: 0x0001079A File Offset: 0x0000E99A
		public static IEnumerable<AITurretClient> Turrets
		{
			get
			{
				return GameObjects.TurretsHashSet;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000299 RID: 665 RVA: 0x000107A1 File Offset: 0x0000E9A1
		public static IEnumerable<AITurretClient> AllyTurrets
		{
			get
			{
				return GameObjects.AllyTurretsHashSet;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600029A RID: 666 RVA: 0x000107A8 File Offset: 0x0000E9A8
		public static IEnumerable<AITurretClient> EnemyTurrets
		{
			get
			{
				return GameObjects.EnemyTurretsHashSet;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600029B RID: 667 RVA: 0x000107AF File Offset: 0x0000E9AF
		public static IEnumerable<BarracksDampenerClient> Inhibitors
		{
			get
			{
				return GameObjects.InhibitorsHashSet;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600029C RID: 668 RVA: 0x000107B6 File Offset: 0x0000E9B6
		public static IEnumerable<BarracksDampenerClient> AllyInhibitors
		{
			get
			{
				return GameObjects.AllyInhibitorsHashSet;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600029D RID: 669 RVA: 0x000107BD File Offset: 0x0000E9BD
		public static IEnumerable<BarracksDampenerClient> EnemyInhibitors
		{
			get
			{
				return GameObjects.EnemyInhibitorsHashSet;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600029E RID: 670 RVA: 0x000107C4 File Offset: 0x0000E9C4
		public static IEnumerable<EffectEmitter> AzirSoldiers
		{
			get
			{
				return GameObjects.AzirSoldiersHashSet;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600029F RID: 671 RVA: 0x000107CB File Offset: 0x0000E9CB
		public static IEnumerable<EffectEmitter> EffectEmitters
		{
			get
			{
				return GameObjects.EffeectEmittersHashSet;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x000107D2 File Offset: 0x0000E9D2
		public static IEnumerable<HQClient> Nexuses
		{
			get
			{
				return GameObjects.NexusHashSet;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x000107D9 File Offset: 0x0000E9D9
		public static IEnumerable<ShopClient> Shops
		{
			get
			{
				return GameObjects.ShopsHashSet;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x000107E0 File Offset: 0x0000E9E0
		public static IEnumerable<ShopClient> AllyShops
		{
			get
			{
				return GameObjects.AllyShopsHashSet;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x000107E7 File Offset: 0x0000E9E7
		public static IEnumerable<ShopClient> EnemyShops
		{
			get
			{
				return GameObjects.EnemyShopsHashSet;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x000107EE File Offset: 0x0000E9EE
		public static IEnumerable<Obj_SpawnPoint> SpawnPoints
		{
			get
			{
				return GameObjects.SpawnPointsHashSet;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x000107F5 File Offset: 0x0000E9F5
		public static IEnumerable<Obj_SpawnPoint> AllySpawnPoints
		{
			get
			{
				return GameObjects.AllySpawnPointsHashSet;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x000107FC File Offset: 0x0000E9FC
		public static IEnumerable<Obj_SpawnPoint> EnemySpawnPoints
		{
			get
			{
				return GameObjects.EnemySpawnPointsHashSet;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00010803 File Offset: 0x0000EA03
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x0001080A File Offset: 0x0000EA0A
		public static AIHeroClient Player { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x00010812 File Offset: 0x0000EA12
		// (set) Token: 0x060002AA RID: 682 RVA: 0x00010819 File Offset: 0x0000EA19
		public static HQClient AllyNexus { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002AB RID: 683 RVA: 0x00010821 File Offset: 0x0000EA21
		// (set) Token: 0x060002AC RID: 684 RVA: 0x00010828 File Offset: 0x0000EA28
		public static HQClient EnemyNexus { get; set; }

		// Token: 0x060002AD RID: 685 RVA: 0x00010830 File Offset: 0x0000EA30
		public static IEnumerable<ObjectType> Get<ObjectType>() where ObjectType : GameObject
		{
			return GameObjects.AllGameObjects.OfType<ObjectType>();
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0001083C File Offset: 0x0000EA3C
		public static IEnumerable<ObjectType> GetNative<ObjectType>() where ObjectType : GameObject
		{
			return ObjectManager.Get<ObjectType>();
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00010844 File Offset: 0x0000EA44
		internal static void Initialized()
		{
			if (GameObjects._initialized)
			{
				return;
			}
			GameObjects._initialized = true;
			GameObjects.Player = ObjectManager.Player;
			IEnumerable<GameObject> enumerable = from x in ObjectManager.Get<GameObject>()
			where x != null && x.IsValid
			select x;
			GameObjects.GameObjectsHashSet = new HashSet<GameObject>(enumerable);
			GameObjects.AttackableUnitsHashSet = new HashSet<AttackableUnit>(enumerable.OfType<AttackableUnit>());
			GameObjects.EffeectEmittersHashSet = new HashSet<EffectEmitter>(enumerable.OfType<EffectEmitter>());
			GameObjects.MissilesHashSet = new HashSet<MissileClient>(enumerable.OfType<MissileClient>());
			GameObjects.AIBaseClientsHashSet = new HashSet<AIBaseClient>(enumerable.OfType<AIBaseClient>());
			GameObjects.AzirSoldiersHashSet = new HashSet<EffectEmitter>(from x in enumerable.OfType<EffectEmitter>()
			where GameObjects.SoldierRegex.IsMatch(x.Name)
			select x);
			GameObjects.MinionsHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.Team != GameObjectTeam.Neutral && !x.GetMinionType().HasFlag(MinionTypes.Ward) && !x.GetMinionType().HasFlag(MinionTypes.JunglePlant)
			select x);
			GameObjects.AllyMinionsHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.Team != GameObjectTeam.Neutral && x.IsAlly && !x.GetMinionType().HasFlag(MinionTypes.Ward) && !x.GetMinionType().HasFlag(MinionTypes.JunglePlant)
			select x);
			GameObjects.EnemyMinionsHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.Team != GameObjectTeam.Neutral && x.IsEnemy && !x.GetMinionType().HasFlag(MinionTypes.Ward) && !x.GetMinionType().HasFlag(MinionTypes.JunglePlant)
			select x);
			GameObjects.JungleHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.Team == GameObjectTeam.Neutral && x.Name != "WardCorpse" && ((x.Name == "Barrel" && x.CharacterName != "SennaSoul") || x.Name != "Barrel") && !x.GetMinionType().HasFlag(MinionTypes.JunglePlant)
			select x);
			GameObjects.JungleSmallHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.Team == GameObjectTeam.Neutral && x.Name != "WardCorpse" && ((x.Name == "Barrel" && x.CharacterName != "SennaSoul") || x.Name != "Barrel") && !x.GetMinionType().HasFlag(MinionTypes.JunglePlant) && x.GetJungleType().HasFlag(JungleType.Small)
			select x);
			GameObjects.JungleLargeHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.Team == GameObjectTeam.Neutral && x.Name != "WardCorpse" && ((x.Name == "Barrel" && x.CharacterName != "SennaSoul") || x.Name != "Barrel") && !x.GetMinionType().HasFlag(MinionTypes.JunglePlant) && x.GetJungleType().HasFlag(JungleType.Large)
			select x);
			GameObjects.JungleLegendaryHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.Team == GameObjectTeam.Neutral && x.Name != "WardCorpse" && ((x.Name == "Barrel" && x.CharacterName != "SennaSoul") || x.Name != "Barrel") && !x.GetMinionType().HasFlag(MinionTypes.JunglePlant) && x.GetJungleType().HasFlag(JungleType.Legendary)
			select x);
			GameObjects.JunglePlantHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.GetMinionType().HasFlag(MinionTypes.JunglePlant)
			select x);
			GameObjects.WardsHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.GetMinionType().HasFlag(MinionTypes.Ward)
			select x);
			GameObjects.AllyWardsHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.GetMinionType().HasFlag(MinionTypes.Ward) && x.IsAlly
			select x);
			GameObjects.EnemyWardsHashSet = new HashSet<AIMinionClient>(from x in enumerable.OfType<AIMinionClient>()
			where x.GetMinionType().HasFlag(MinionTypes.Ward) && x.IsEnemy
			select x);
			GameObjects.HeroesHashSet = new HashSet<AIHeroClient>(enumerable.OfType<AIHeroClient>());
			GameObjects.AllyHeroesHashSet = new HashSet<AIHeroClient>(from x in enumerable.OfType<AIHeroClient>()
			where x.IsAlly
			select x);
			GameObjects.EnemyHeroesHashSet = new HashSet<AIHeroClient>(from x in enumerable.OfType<AIHeroClient>()
			where x.IsEnemy
			select x);
			GameObjects.TurretsHashSet = new HashSet<AITurretClient>(from x in enumerable.OfType<AITurretClient>()
			where !x.IsFountainTurret()
			select x);
			GameObjects.AllyTurretsHashSet = new HashSet<AITurretClient>(from x in enumerable.OfType<AITurretClient>()
			where !x.IsFountainTurret() && x.IsAlly
			select x);
			GameObjects.EnemyTurretsHashSet = new HashSet<AITurretClient>(from x in enumerable.OfType<AITurretClient>()
			where !x.IsFountainTurret() && x.IsEnemy
			select x);
			GameObjects.InhibitorsHashSet = new HashSet<BarracksDampenerClient>(enumerable.OfType<BarracksDampenerClient>());
			GameObjects.AllyInhibitorsHashSet = new HashSet<BarracksDampenerClient>(from x in enumerable.OfType<BarracksDampenerClient>()
			where x.IsAlly
			select x);
			GameObjects.EnemyInhibitorsHashSet = new HashSet<BarracksDampenerClient>(from x in enumerable.OfType<BarracksDampenerClient>()
			where x.IsEnemy
			select x);
			GameObjects.NexusHashSet = new HashSet<HQClient>(enumerable.OfType<HQClient>());
			GameObjects.AllyNexus = GameObjects.NexusHashSet.FirstOrDefault((HQClient n) => n.IsAlly);
			GameObjects.EnemyNexus = GameObjects.NexusHashSet.FirstOrDefault((HQClient n) => n.IsEnemy);
			GameObjects.ShopsHashSet = new HashSet<ShopClient>(enumerable.OfType<ShopClient>());
			GameObjects.AllyShopsHashSet = new HashSet<ShopClient>(from x in enumerable.OfType<ShopClient>()
			where x.IsAlly
			select x);
			GameObjects.EnemyShopsHashSet = new HashSet<ShopClient>(from x in enumerable.OfType<ShopClient>()
			where x.IsEnemy
			select x);
			GameObjects.SpawnPointsHashSet = new HashSet<Obj_SpawnPoint>(enumerable.OfType<Obj_SpawnPoint>());
			GameObjects.AllySpawnPointsHashSet = new HashSet<Obj_SpawnPoint>(from x in enumerable.OfType<Obj_SpawnPoint>()
			where x.IsAlly
			select x);
			GameObjects.EnemySpawnPointsHashSet = new HashSet<Obj_SpawnPoint>(from x in enumerable.OfType<Obj_SpawnPoint>()
			where x.IsEnemy
			select x);
			GameObjects.AzirInGame = GameObjects.HeroesHashSet.Any((AIHeroClient x) => x.CharacterName == "Azir");
			GameObjects.CaitlynInGame = GameObjects.HeroesHashSet.Any((AIHeroClient x) => x.CharacterName == "Caitlyn");
			GameObject.OnCreate += GameObjects.OnCreate;
			GameObject.OnDelete += GameObjects.OnDelete;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00010EB4 File Offset: 0x0000F0B4
		public static HashSet<AIBaseClient> GetMinions(Vector3 from, float range, MinionTypes type = MinionTypes.All, MinionTeam team = MinionTeam.Enemy, MinionOrderTypes order = MinionOrderTypes.Health)
		{
			if (!GameObjects._initialized)
			{
				return new HashSet<AIBaseClient>();
			}
			HashSet<AIBaseClient> source = new HashSet<AIBaseClient>();
			if (type <= MinionTypes.Siege)
			{
				switch (type)
				{
				case MinionTypes.All:
					source = new HashSet<AIBaseClient>(from x in GameObjects.Minions
					where x.IsValidTarget(range, team == MinionTeam.Enemy, @from) && x.IsMinion()
					select x);
					break;
				case MinionTypes.Normal:
					source = new HashSet<AIBaseClient>(from x in GameObjects.Minions
					where x.IsValidTarget(range, team == MinionTeam.Enemy, @from) && x.GetMinionType().HasFlag(MinionTypes.Normal)
					select x);
					break;
				case MinionTypes.All | MinionTypes.Normal:
					break;
				case MinionTypes.Ranged:
					source = new HashSet<AIBaseClient>(from x in GameObjects.Minions
					where x.IsValidTarget(range, team == MinionTeam.Enemy, @from) && x.GetMinionType().HasFlag(MinionTypes.Ranged)
					select x);
					break;
				default:
					if (type != MinionTypes.Melee)
					{
						if (type == MinionTypes.Siege)
						{
							source = new HashSet<AIBaseClient>(from x in GameObjects.Minions
							where x.IsValidTarget(range, team == MinionTeam.Enemy, @from) && x.GetMinionType().HasFlag(MinionTypes.Siege)
							select x);
						}
					}
					else
					{
						source = new HashSet<AIBaseClient>(from x in GameObjects.Minions
						where x.IsValidTarget(range, team == MinionTeam.Enemy, @from) && x.GetMinionType().HasFlag(MinionTypes.Melee)
						select x);
					}
					break;
				}
			}
			else if (type != MinionTypes.Super)
			{
				if (type != MinionTypes.Ward)
				{
					if (type == MinionTypes.JunglePlant)
					{
						source = new HashSet<AIBaseClient>(from x in GameObjects.Minions
						where x.IsValidTarget(range, team == MinionTeam.Enemy, @from) && x.GetMinionType().HasFlag(MinionTypes.JunglePlant)
						select x);
					}
				}
				else
				{
					source = new HashSet<AIBaseClient>(from x in GameObjects.Minions
					where x.IsValidTarget(range, team == MinionTeam.Enemy, @from) && x.GetMinionType().HasFlag(MinionTypes.Ward)
					select x);
				}
			}
			else
			{
				source = new HashSet<AIBaseClient>(from x in GameObjects.Minions
				where x.IsValidTarget(range, team == MinionTeam.Enemy, @from) && x.GetMinionType().HasFlag(MinionTypes.Super)
				select x);
			}
			switch (order)
			{
			case MinionOrderTypes.None:
				return source.ToHashSet<AIBaseClient>();
			case MinionOrderTypes.Health:
				return (from o in source
				orderby o.Health
				select o).ToHashSet<AIBaseClient>();
			case MinionOrderTypes.MaxHealth:
				return (from o in source
				orderby o.MaxHealth descending
				select o).ToHashSet<AIBaseClient>();
			default:
				return source.ToHashSet<AIBaseClient>();
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x000110AF File Offset: 0x0000F2AF
		public static HashSet<AIBaseClient> GetMinions(float range, MinionTypes type = MinionTypes.All, MinionTeam team = MinionTeam.Enemy, MinionOrderTypes order = MinionOrderTypes.Health)
		{
			return GameObjects.GetMinions(GameObjects.Player.ServerPosition, range, type, team, order);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x000110C4 File Offset: 0x0000F2C4
		public static HashSet<AIBaseClient> GetJungles(Vector3 from, float range, JungleType type = JungleType.All, JungleOrderTypes order = JungleOrderTypes.MaxHealth)
		{
			if (!GameObjects._initialized)
			{
				return new HashSet<AIBaseClient>();
			}
			HashSet<AIBaseClient> source = new HashSet<AIBaseClient>();
			switch (type)
			{
			case JungleType.All:
				source = new HashSet<AIBaseClient>(from x in GameObjects.Jungle
				where x.IsValidTarget(range, true, @from) && x.IsJungle()
				select x);
				break;
			case JungleType.Small:
				source = new HashSet<AIBaseClient>(from x in GameObjects.JungleSmall
				where x.IsValidTarget(range, true, @from) && x.GetJungleType().HasFlag(JungleType.Small)
				select x);
				break;
			case JungleType.All | JungleType.Small:
				break;
			case JungleType.Large:
				source = new HashSet<AIBaseClient>(from x in GameObjects.JungleLarge
				where x.IsValidTarget(range, true, @from) && x.GetJungleType().HasFlag(JungleType.Large)
				select x);
				break;
			default:
				if (type == JungleType.Legendary)
				{
					source = new HashSet<AIBaseClient>(from x in GameObjects.JungleLegendary
					where x.IsValidTarget(range, true, @from) && x.GetJungleType().HasFlag(JungleType.Legendary)
					select x);
				}
				break;
			}
			switch (order)
			{
			case JungleOrderTypes.None:
				return source.ToHashSet<AIBaseClient>();
			case JungleOrderTypes.Health:
				return (from o in source
				orderby o.Health
				select o).ToHashSet<AIBaseClient>();
			case JungleOrderTypes.MaxHealth:
				return (from o in source
				orderby o.MaxHealth descending
				select o).ToHashSet<AIBaseClient>();
			default:
				return source.ToHashSet<AIBaseClient>();
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00011203 File Offset: 0x0000F403
		public static HashSet<AIBaseClient> GetJungles(float range, JungleType type = JungleType.All, JungleOrderTypes order = JungleOrderTypes.MaxHealth)
		{
			return GameObjects.GetJungles(GameObjects.Player.ServerPosition, range, type, order);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00011218 File Offset: 0x0000F418
		private static void OnCreate(GameObject sender, EventArgs args)
		{
			if (sender == null || !sender.IsValid)
			{
				return;
			}
			GameObjects.GameObjectsHashSet.Add(sender);
			AttackableUnit attackableUnit = sender as AttackableUnit;
			if (attackableUnit != null && attackableUnit.IsValid)
			{
				GameObjects.AttackableUnitsHashSet.Add(attackableUnit);
			}
			EffectEmitter effectEmitter = sender as EffectEmitter;
			if (effectEmitter != null && effectEmitter.IsValid)
			{
				GameObjects.EffeectEmittersHashSet.Add(effectEmitter);
				if (GameObjects.AzirInGame && GameObjects.SoldierRegex.IsMatch(effectEmitter.Name))
				{
					GameObjects.AzirSoldiersHashSet.Add(effectEmitter);
					return;
				}
				if (GameObjects.CaitlynInGame && (GameObjects.CaitlynRegex.IsMatch(effectEmitter.Name) || GameObjects.CaitlynRegex2.IsMatch(effectEmitter.Name) || GameObjects.CaitlynRegex3.IsMatch(effectEmitter.Name)))
				{
					Vector3 beamPos = effectEmitter.Position.SetZ(new float?(0f));
					AIBaseClient aibaseClient = (from h in GameObjects.AiBaseObjects
					where h.IsValid && !h.IsDead && h.Position.SetZ(new float?(0f)).Distance(beamPos) < h.BoundingRadius
					orderby h.Position.SetZ(new float?(0f)).Distance(beamPos)
					select h).FirstOrDefault<AIBaseClient>();
					if (aibaseClient != null)
					{
						BuffInstance buffInstance = aibaseClient.Buffs.FirstOrDefault((BuffInstance b) => b.IsValid && b.IsActive && (b.Name.Equals("CaitlynWSnare") || b.Name.Equals("CaitlynEMissile")));
						if (buffInstance == null || buffInstance.Caster.IsMe)
						{
							if (GameObjects.CaitlynHeadshotBeams.ContainsKey(aibaseClient.NetworkId))
							{
								GameObjects.CaitlynHeadshotBeams[aibaseClient.NetworkId].Add(effectEmitter);
								return;
							}
							GameObjects.CaitlynHeadshotBeams.Add(aibaseClient.NetworkId, new HashSet<EffectEmitter>
							{
								effectEmitter
							});
						}
					}
				}
				return;
			}
			else
			{
				MissileClient missileClient = sender as MissileClient;
				if (missileClient != null && missileClient.IsValid)
				{
					GameObjects.MissilesHashSet.Add(missileClient);
					return;
				}
				AIBaseClient aibaseClient2 = sender as AIBaseClient;
				if (aibaseClient2 != null && aibaseClient2.IsValid)
				{
					GameObjects.AIBaseClientsHashSet.Add(aibaseClient2);
				}
				AIHeroClient aiheroClient = sender as AIHeroClient;
				if (aiheroClient != null && aiheroClient.IsValid)
				{
					GameObjects.HeroesHashSet.Add(aiheroClient);
					if (aiheroClient.IsEnemy)
					{
						GameObjects.EnemyHeroesHashSet.Add(aiheroClient);
					}
					else
					{
						GameObjects.AllyHeroesHashSet.Add(aiheroClient);
					}
					Library.GameCache.AddCacheData(aiheroClient);
					return;
				}
				AIMinionClient aiminionClient = sender as AIMinionClient;
				if (aiminionClient != null && aiminionClient.IsValid)
				{
					if (aiminionClient.Team == GameObjectTeam.Neutral)
					{
						if (aiminionClient.Name != "WardCorpse")
						{
							if (aiminionClient.GetMinionType().HasFlag(MinionTypes.JunglePlant))
							{
								GameObjects.JunglePlantHashSet.Add(aiminionClient);
								return;
							}
							if (aiminionClient.Name == "Barrel" && aiminionClient.CharacterName == "SennaSoul")
							{
								return;
							}
							JungleType jungleType = aiminionClient.GetJungleType();
							if (jungleType != JungleType.Small)
							{
								if (jungleType != JungleType.Large)
								{
									if (jungleType == JungleType.Legendary)
									{
										GameObjects.JungleLegendaryHashSet.Add(aiminionClient);
									}
								}
								else
								{
									GameObjects.JungleLargeHashSet.Add(aiminionClient);
								}
							}
							else
							{
								GameObjects.JungleSmallHashSet.Add(aiminionClient);
							}
							GameObjects.JungleHashSet.Add(aiminionClient);
						}
						return;
					}
					if (aiminionClient.GetMinionType().HasFlag(MinionTypes.Ward))
					{
						GameObjects.WardsHashSet.Add(aiminionClient);
						if (aiminionClient.IsEnemy)
						{
							GameObjects.EnemyWardsHashSet.Add(aiminionClient);
							return;
						}
						GameObjects.AllyWardsHashSet.Add(aiminionClient);
						return;
					}
					else
					{
						GameObjects.MinionsHashSet.Add(aiminionClient);
						if (aiminionClient.IsEnemy)
						{
							GameObjects.EnemyMinionsHashSet.Add(aiminionClient);
							return;
						}
						GameObjects.AllyMinionsHashSet.Add(aiminionClient);
						return;
					}
				}
				else
				{
					AITurretClient aiturretClient = sender as AITurretClient;
					if (aiturretClient != null && aiturretClient.IsValid && !aiturretClient.IsFountainTurret())
					{
						GameObjects.TurretsHashSet.Add(aiturretClient);
						if (aiturretClient.IsEnemy)
						{
							GameObjects.EnemyTurretsHashSet.Add(aiturretClient);
							return;
						}
						GameObjects.AllyTurretsHashSet.Add(aiturretClient);
						return;
					}
					else
					{
						ShopClient shopClient = sender as ShopClient;
						if (shopClient != null && shopClient.IsValid)
						{
							GameObjects.ShopsHashSet.Add(shopClient);
							if (shopClient.IsAlly)
							{
								GameObjects.AllyShopsHashSet.Add(shopClient);
								return;
							}
							GameObjects.EnemyShopsHashSet.Add(shopClient);
							return;
						}
						else
						{
							Obj_SpawnPoint obj_SpawnPoint = sender as Obj_SpawnPoint;
							if (obj_SpawnPoint != null && obj_SpawnPoint.IsValid)
							{
								GameObjects.SpawnPointsHashSet.Add(obj_SpawnPoint);
								if (obj_SpawnPoint.IsAlly)
								{
									GameObjects.AllySpawnPointsHashSet.Add(obj_SpawnPoint);
									return;
								}
								GameObjects.EnemySpawnPointsHashSet.Add(obj_SpawnPoint);
								return;
							}
							else
							{
								BarracksDampenerClient barracksDampenerClient = sender as BarracksDampenerClient;
								if (!(barracksDampenerClient != null) || !barracksDampenerClient.IsValid)
								{
									HQClient hqclient = sender as HQClient;
									if (hqclient != null && hqclient.IsValid)
									{
										GameObjects.NexusHashSet.Add(hqclient);
										if (hqclient.IsAlly)
										{
											GameObjects.AllyNexus = hqclient;
											return;
										}
										GameObjects.EnemyNexus = hqclient;
									}
									return;
								}
								GameObjects.InhibitorsHashSet.Add(barracksDampenerClient);
								if (barracksDampenerClient.IsAlly)
								{
									GameObjects.AllyInhibitorsHashSet.Add(barracksDampenerClient);
									return;
								}
								GameObjects.EnemyInhibitorsHashSet.Add(barracksDampenerClient);
								return;
							}
						}
					}
				}
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0001176C File Offset: 0x0000F96C
		private static void OnDelete(GameObject sender, EventArgs args)
		{
			if (sender == null || !sender.IsValid)
			{
				return;
			}
			GameObjects.GameObjectsHashSet.Remove(sender);
			AttackableUnit attackableUnit = sender as AttackableUnit;
			if (attackableUnit != null && attackableUnit.IsValid)
			{
				GameObjects.AttackableUnitsHashSet.Remove(attackableUnit);
			}
			EffectEmitter effectEmitter = sender as EffectEmitter;
			if (effectEmitter != null && effectEmitter.IsValid)
			{
				GameObjects.EffeectEmittersHashSet.Remove(effectEmitter);
				if (GameObjects.AzirInGame && GameObjects.SoldierRegex.IsMatch(effectEmitter.Name))
				{
					GameObjects.AzirSoldiersHashSet.Remove(effectEmitter);
					return;
				}
				if (GameObjects.CaitlynInGame && (GameObjects.CaitlynRegex.IsMatch(effectEmitter.Name) || GameObjects.CaitlynRegex2.IsMatch(effectEmitter.Name) || GameObjects.CaitlynRegex3.IsMatch(effectEmitter.Name)))
				{
					Predicate<EffectEmitter> <>9__0;
					foreach (KeyValuePair<int, HashSet<EffectEmitter>> keyValuePair in GameObjects.CaitlynHeadshotBeams)
					{
						HashSet<EffectEmitter> value = keyValuePair.Value;
						Predicate<EffectEmitter> match;
						if ((match = <>9__0) == null)
						{
							match = (<>9__0 = ((EffectEmitter b) => !b.IsValid || b.IsDead || b.Compare(effectEmitter)));
						}
						value.RemoveWhere(match);
					}
				}
				return;
			}
			else
			{
				MissileClient missileClient = sender as MissileClient;
				if (missileClient != null && missileClient.IsValid)
				{
					GameObjects.MissilesHashSet.Remove(missileClient);
					return;
				}
				AIBaseClient aibaseClient = sender as AIBaseClient;
				if (aibaseClient != null && aibaseClient.IsValid)
				{
					GameObjects.AIBaseClientsHashSet.Remove(aibaseClient);
					if (GameObjects.CaitlynInGame)
					{
						GameObjects.CaitlynHeadshotBeams.Remove(attackableUnit.NetworkId);
					}
				}
				AIHeroClient aiheroClient = sender as AIHeroClient;
				if (aiheroClient != null && aiheroClient.IsValid)
				{
					GameObjects.HeroesHashSet.Remove(aiheroClient);
					if (aiheroClient.IsEnemy)
					{
						GameObjects.EnemyHeroesHashSet.Remove(aiheroClient);
						return;
					}
					GameObjects.AllyHeroesHashSet.Remove(aiheroClient);
					return;
				}
				else
				{
					AIMinionClient aiminionClient = sender as AIMinionClient;
					if (aiminionClient != null && aiminionClient.IsValid)
					{
						if (aiminionClient.Team != GameObjectTeam.Neutral)
						{
							if (aiminionClient.GetMinionType().HasFlag(MinionTypes.Ward))
							{
								GameObjects.WardsHashSet.Remove(aiminionClient);
								if (aiminionClient.IsEnemy)
								{
									GameObjects.EnemyWardsHashSet.Remove(aiminionClient);
									return;
								}
								GameObjects.AllyWardsHashSet.Remove(aiminionClient);
								return;
							}
							else
							{
								GameObjects.MinionsHashSet.Remove(aiminionClient);
								if (aiminionClient.IsEnemy)
								{
									GameObjects.EnemyMinionsHashSet.Remove(aiminionClient);
									return;
								}
								GameObjects.AllyMinionsHashSet.Remove(aiminionClient);
								return;
							}
						}
						else
						{
							if (aiminionClient.GetMinionType().HasFlag(MinionTypes.JunglePlant))
							{
								GameObjects.JunglePlantHashSet.Remove(aiminionClient);
								return;
							}
							GameObjects.JungleHashSet.Remove(aiminionClient);
							JungleType jungleType = aiminionClient.GetJungleType();
							if (jungleType == JungleType.Small)
							{
								GameObjects.JungleSmallHashSet.Remove(aiminionClient);
								return;
							}
							if (jungleType == JungleType.Large)
							{
								GameObjects.JungleLargeHashSet.Remove(aiminionClient);
								return;
							}
							if (jungleType != JungleType.Legendary)
							{
								return;
							}
							GameObjects.JungleLegendaryHashSet.Remove(aiminionClient);
							return;
						}
					}
					else
					{
						AITurretClient aiturretClient = sender as AITurretClient;
						if (aiturretClient != null && aiturretClient.IsValid)
						{
							GameObjects.TurretsHashSet.Remove(aiturretClient);
							if (aiturretClient.IsEnemy)
							{
								GameObjects.EnemyTurretsHashSet.Remove(aiturretClient);
								return;
							}
							GameObjects.AllyTurretsHashSet.Remove(aiturretClient);
							return;
						}
						else
						{
							ShopClient shopClient = sender as ShopClient;
							if (shopClient != null && shopClient.IsValid)
							{
								GameObjects.ShopsHashSet.Remove(shopClient);
								if (shopClient.IsAlly)
								{
									GameObjects.AllyShopsHashSet.Remove(shopClient);
									return;
								}
								GameObjects.EnemyShopsHashSet.Remove(shopClient);
								return;
							}
							else
							{
								Obj_SpawnPoint obj_SpawnPoint = sender as Obj_SpawnPoint;
								if (obj_SpawnPoint != null && obj_SpawnPoint.IsValid)
								{
									GameObjects.SpawnPointsHashSet.Remove(obj_SpawnPoint);
									if (obj_SpawnPoint.IsAlly)
									{
										GameObjects.AllySpawnPointsHashSet.Remove(obj_SpawnPoint);
										return;
									}
									GameObjects.EnemySpawnPointsHashSet.Remove(obj_SpawnPoint);
									return;
								}
								else
								{
									BarracksDampenerClient barracksDampenerClient = sender as BarracksDampenerClient;
									if (!(barracksDampenerClient != null) || !barracksDampenerClient.IsValid)
									{
										HQClient hqclient = sender as HQClient;
										if (hqclient != null && hqclient.IsValid)
										{
											GameObjects.NexusHashSet.Remove(hqclient);
											if (hqclient.IsAlly)
											{
												GameObjects.AllyNexus = null;
												return;
											}
											GameObjects.EnemyNexus = null;
										}
										return;
									}
									GameObjects.InhibitorsHashSet.Remove(barracksDampenerClient);
									if (barracksDampenerClient.IsAlly)
									{
										GameObjects.AllyInhibitorsHashSet.Remove(barracksDampenerClient);
										return;
									}
									GameObjects.EnemyInhibitorsHashSet.Remove(barracksDampenerClient);
									return;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04000126 RID: 294
		private static HashSet<GameObject> GameObjectsHashSet;

		// Token: 0x04000127 RID: 295
		private static HashSet<AttackableUnit> AttackableUnitsHashSet;

		// Token: 0x04000128 RID: 296
		private static HashSet<AIBaseClient> AIBaseClientsHashSet;

		// Token: 0x04000129 RID: 297
		private static HashSet<AIMinionClient> MinionsHashSet;

		// Token: 0x0400012A RID: 298
		private static HashSet<AIMinionClient> AllyMinionsHashSet;

		// Token: 0x0400012B RID: 299
		private static HashSet<AIMinionClient> EnemyMinionsHashSet;

		// Token: 0x0400012C RID: 300
		private static HashSet<AIMinionClient> JungleHashSet;

		// Token: 0x0400012D RID: 301
		private static HashSet<AIMinionClient> JungleSmallHashSet;

		// Token: 0x0400012E RID: 302
		private static HashSet<AIMinionClient> JungleLargeHashSet;

		// Token: 0x0400012F RID: 303
		private static HashSet<AIMinionClient> JungleLegendaryHashSet;

		// Token: 0x04000130 RID: 304
		private static HashSet<AIMinionClient> JunglePlantHashSet;

		// Token: 0x04000131 RID: 305
		private static HashSet<AIMinionClient> WardsHashSet;

		// Token: 0x04000132 RID: 306
		private static HashSet<AIMinionClient> AllyWardsHashSet;

		// Token: 0x04000133 RID: 307
		private static HashSet<AIMinionClient> EnemyWardsHashSet;

		// Token: 0x04000134 RID: 308
		private static HashSet<AIHeroClient> HeroesHashSet;

		// Token: 0x04000135 RID: 309
		private static HashSet<AIHeroClient> AllyHeroesHashSet;

		// Token: 0x04000136 RID: 310
		private static HashSet<AIHeroClient> EnemyHeroesHashSet;

		// Token: 0x04000137 RID: 311
		private static HashSet<AITurretClient> TurretsHashSet;

		// Token: 0x04000138 RID: 312
		private static HashSet<AITurretClient> AllyTurretsHashSet;

		// Token: 0x04000139 RID: 313
		private static HashSet<AITurretClient> EnemyTurretsHashSet;

		// Token: 0x0400013A RID: 314
		private static HashSet<BarracksDampenerClient> InhibitorsHashSet;

		// Token: 0x0400013B RID: 315
		private static HashSet<BarracksDampenerClient> AllyInhibitorsHashSet;

		// Token: 0x0400013C RID: 316
		private static HashSet<BarracksDampenerClient> EnemyInhibitorsHashSet;

		// Token: 0x0400013D RID: 317
		private static HashSet<EffectEmitter> AzirSoldiersHashSet;

		// Token: 0x0400013E RID: 318
		private static HashSet<EffectEmitter> EffeectEmittersHashSet;

		// Token: 0x0400013F RID: 319
		private static HashSet<HQClient> NexusHashSet;

		// Token: 0x04000140 RID: 320
		private static HashSet<MissileClient> MissilesHashSet;

		// Token: 0x04000141 RID: 321
		private static HashSet<Obj_SpawnPoint> SpawnPointsHashSet;

		// Token: 0x04000142 RID: 322
		private static HashSet<Obj_SpawnPoint> AllySpawnPointsHashSet;

		// Token: 0x04000143 RID: 323
		private static HashSet<Obj_SpawnPoint> EnemySpawnPointsHashSet;

		// Token: 0x04000144 RID: 324
		private static HashSet<ShopClient> ShopsHashSet;

		// Token: 0x04000145 RID: 325
		private static HashSet<ShopClient> AllyShopsHashSet;

		// Token: 0x04000146 RID: 326
		private static HashSet<ShopClient> EnemyShopsHashSet;

		// Token: 0x04000147 RID: 327
		internal static Dictionary<int, HashSet<EffectEmitter>> CaitlynHeadshotBeams = new Dictionary<int, HashSet<EffectEmitter>>();

		// Token: 0x04000148 RID: 328
		private static bool _initialized;

		// Token: 0x04000149 RID: 329
		private static bool AzirInGame;

		// Token: 0x0400014A RID: 330
		private static bool CaitlynInGame;

		// Token: 0x0400014B RID: 331
		private static readonly Regex SoldierRegex = new Regex("Azir_.+_P_Soldier_Ring");

		// Token: 0x0400014C RID: 332
		private static readonly Regex CaitlynRegex = new Regex("Caitlyn_.+_ace_beam");

		// Token: 0x0400014D RID: 333
		private static readonly Regex CaitlynRegex2 = new Regex("Caitlyn_.+_W_E_Tar_Headshot_Beam");

		// Token: 0x0400014E RID: 334
		private static readonly Regex CaitlynRegex3 = new Regex("Caitlyn_.+_LRHeadshotTarget_Beam");
	}
}

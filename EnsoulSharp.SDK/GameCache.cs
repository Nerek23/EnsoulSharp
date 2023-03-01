using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000006 RID: 6
	[Export(typeof(GameCache))]
	public class GameCache
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002500 File Offset: 0x00000700
		public Vector2 ScreenCursor
		{
			get
			{
				return Cursor.Position;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002508 File Offset: 0x00000708
		public GameCache()
		{
			this.WindowsValue = new GameCache.GameWindowsValue
			{
				WindowsHeight = Drawing.Height,
				WindowsWidth = Drawing.Width,
				MiniMapHeight = TacticalMap.Offset.Y,
				MiniMapWidth = TacticalMap.Offset.X
			};
			try
			{
				X509Certificate x509Certificate = X509Certificate.CreateFromSignedFile("League of Legends.exe");
				if (x509Certificate.Subject.Contains("CN") && x509Certificate.Subject.Contains("Shenzhen") && x509Certificate.Subject.Contains("Tencent Technology"))
				{
					this.IsRiot = false;
				}
			}
			catch
			{
			}
			if (!this.IsRiot)
			{
				new MouseTracker();
			}
			using (IEnumerator<AIHeroClient> enumerator = (from x in ObjectManager.Get<AIHeroClient>()
			where x != null && x.IsValid
			select x).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					AIHeroClient hero = enumerator.Current;
					if (!this.AllHeroCache.Any((GameCache.HeroCache i) => i.Hero.Compare(hero)))
					{
						this.AddCacheData(hero);
					}
				}
			}
			GameEvent.OnGameTick += this.OnGameTick;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000026B8 File Offset: 0x000008B8
		private void OnGameTick(EventArgs args)
		{
			int gameTimeTickCount = Variables.GameTimeTickCount;
			foreach (GameCache.HeroCache heroCache in this.AllHeroCache)
			{
				if (heroCache.Check(gameTimeTickCount) && !(heroCache.Hero == null) && heroCache.Hero.IsValid)
				{
					HashSet<ItemId> hashSet = (from x in heroCache.Hero.InventoryItems
					where x != null && x.IData != null
					select x.Id).ToHashSet<ItemId>();
					heroCache.HasItems = ((hashSet.Count > 0) ? hashSet : new HashSet<ItemId>());
					heroCache.LastCheckTimer = gameTimeTickCount;
					if (heroCache.SmiteState != SmiteState.Last)
					{
						if (heroCache.HasItems.Any((ItemId x) => x == ItemId.Scorchclaw_Pup || x == ItemId.Gustwalker_Hatchling || x == ItemId.Mosstomper_Seedling))
						{
							if (heroCache.Hero.Spellbook.Spells.Any((SpellDataInst x) => this.lastestStateName.Contains(x.Name)))
							{
								heroCache.SmiteState = SmiteState.Last;
							}
							else if (heroCache.Hero.Spellbook.Spells.Any((SpellDataInst x) => this.secondStateName == x.Name))
							{
								heroCache.SmiteState = SmiteState.Second;
							}
							else
							{
								heroCache.SmiteState = SmiteState.Basic;
							}
						}
					}
				}
			}
			if (gameTimeTickCount - this.lastCheckTime > 2500)
			{
				this.lastCheckTime = gameTimeTickCount;
				int allyDragonKills = 0;
				int enemyDragonKills = 0;
				if (Game.MapId == GameMapId.SummonersRift)
				{
					NeutralMinionCampClient neutralMinionCampClient = ObjectManager.Get<NeutralMinionCampClient>().FirstOrDefault((NeutralMinionCampClient x) => x != null && x.IsValid && x.Name == "monsterCamp_6");
					if (neutralMinionCampClient != null)
					{
						if (GameObjects.Player.Team == GameObjectTeam.Chaos)
						{
							allyDragonKills = neutralMinionCampClient.ChaosRewards.Length;
							enemyDragonKills = neutralMinionCampClient.OrderRewards.Length;
						}
						else
						{
							allyDragonKills = neutralMinionCampClient.OrderRewards.Length;
							enemyDragonKills = neutralMinionCampClient.ChaosRewards.Length;
						}
					}
					this.AllyDragonKills = allyDragonKills;
					this.EnemyDragonKills = enemyDragonKills;
				}
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002908 File Offset: 0x00000B08
		internal void AddCacheData(AIHeroClient hero)
		{
			this.lastIndex++;
			this.AllHeroCache.Add(new GameCache.HeroCache
			{
				Index = this.lastIndex,
				LastCheckTimer = 0,
				IsZeri = (hero.CharacterName == "Zeri"),
				Hero = hero,
				HasItems = new HashSet<ItemId>(),
				Perks = hero.Perks,
				SmiteState = SmiteState.None
			});
		}

		// Token: 0x0400000C RID: 12
		private int lastIndex;

		// Token: 0x0400000D RID: 13
		private int lastCheckTime;

		// Token: 0x0400000E RID: 14
		private readonly string basicName = "SummonerSmite";

		// Token: 0x0400000F RID: 15
		private readonly string secondStateName = "S5_SummonerSmitePlayerGanker";

		// Token: 0x04000010 RID: 16
		private readonly HashSet<string> lastestStateName = new HashSet<string>
		{
			"SummonerSmiteAvatarOffensive",
			"SummonerSmiteAvatarDefensive",
			"SummonerSmiteAvatarUtility"
		};

		// Token: 0x04000011 RID: 17
		public int AllyDragonKills;

		// Token: 0x04000012 RID: 18
		public int EnemyDragonKills;

		// Token: 0x04000013 RID: 19
		internal bool IsRiot = true;

		// Token: 0x04000014 RID: 20
		public bool HumainzerSpellCast;

		// Token: 0x04000015 RID: 21
		public GameCache.GameWindowsValue WindowsValue;

		// Token: 0x04000016 RID: 22
		public HashSet<GameCache.HeroCache> AllHeroCache = new HashSet<GameCache.HeroCache>();

		// Token: 0x0200040C RID: 1036
		public class HeroCache
		{
			// Token: 0x060013A2 RID: 5026 RVA: 0x0004A224 File Offset: 0x00048424
			internal bool Check(int time)
			{
				return time - (this.LastCheckTimer + this.Index * 500) > 0;
			}

			// Token: 0x04000AAD RID: 2733
			public AIHeroClient Hero;

			// Token: 0x04000AAE RID: 2734
			public HashSet<ItemId> HasItems = new HashSet<ItemId>();

			// Token: 0x04000AAF RID: 2735
			public Perk[] Perks = Array.Empty<Perk>();

			// Token: 0x04000AB0 RID: 2736
			public SmiteState SmiteState;

			// Token: 0x04000AB1 RID: 2737
			internal int Index;

			// Token: 0x04000AB2 RID: 2738
			internal int LastCheckTimer;

			// Token: 0x04000AB3 RID: 2739
			internal bool IsZeri;
		}

		// Token: 0x0200040D RID: 1037
		public class GameWindowsValue
		{
			// Token: 0x04000AB4 RID: 2740
			public int WindowsWidth;

			// Token: 0x04000AB5 RID: 2741
			public int WindowsHeight;

			// Token: 0x04000AB6 RID: 2742
			public float MiniMapWidth;

			// Token: 0x04000AB7 RID: 2743
			public float MiniMapHeight;
		}
	}
}

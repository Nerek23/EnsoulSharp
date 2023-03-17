using System;
using System.Collections.Generic;
using System.Linq;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000030 RID: 48
	public static class Interrupter
	{
		// Token: 0x06000260 RID: 608 RVA: 0x0000FA04 File Offset: 0x0000DC04
		static Interrupter()
		{
			Interrupter.AddInterruptSpellInDB("MasterYi", SpellSlot.W, Interrupter.DangerLevel.Low);
			Interrupter.AddInterruptSpellInDB("Sion", SpellSlot.Q, Interrupter.DangerLevel.Low);
			Interrupter.AddInterruptSpellInDB("Pantheon", SpellSlot.Q, Interrupter.DangerLevel.Low);
			Interrupter.AddInterruptSpellInDB("Yuumi", SpellSlot.W, Interrupter.DangerLevel.Low);
			Interrupter.AddInterruptSpellInDB("FiddleSticks", SpellSlot.W, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Janna", SpellSlot.R, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Lucian", SpellSlot.R, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Pantheon", SpellSlot.R, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Pyke", SpellSlot.Q, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Quinn", SpellSlot.R, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Shen", SpellSlot.R, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("TahmKench", SpellSlot.W, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("TwistedFate", SpellSlot.R, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Varus", SpellSlot.Q, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Vi", SpellSlot.Q, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Viego", SpellSlot.W, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Xerath", SpellSlot.Q, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Zac", SpellSlot.E, Interrupter.DangerLevel.Medium);
			Interrupter.AddInterruptSpellInDB("Yuumi", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Akshan", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Caitlyn", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("FiddleSticks", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Galio", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Jhin", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Karthus", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Katarina", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Malzahar", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("MissFortune", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Nunu", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Velkoz", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Warwick", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Xerath", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Samira", SpellSlot.R, Interrupter.DangerLevel.High);
			Interrupter.AddInterruptSpellInDB("Poppy", SpellSlot.R, Interrupter.DangerLevel.High);
			foreach (AIHeroClient aiheroClient in GameObjects.EnemyHeroes)
			{
				Interrupter.AddInterruptSpellInDB(aiheroClient.CharacterName, SpellSlot.Unknown, Interrupter.DangerLevel.High);
			}
			Game.OnUpdate += Interrupter.OnUpdate;
			AIBaseClient.OnDoCast += Interrupter.OnDoCast;
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000261 RID: 609 RVA: 0x0000FC24 File Offset: 0x0000DE24
		// (remove) Token: 0x06000262 RID: 610 RVA: 0x0000FC58 File Offset: 0x0000DE58
		public static event Interrupter.InterrupterSpellHandler OnInterrupterSpell;

		// Token: 0x06000263 RID: 611 RVA: 0x0000FC8C File Offset: 0x0000DE8C
		private static void OnUpdate(EventArgs args)
		{
			foreach (AIHeroClient aiheroClient in from h in GameObjects.EnemyHeroes
			where h != null && h.IsValid && Interrupter.CastingSpell.ContainsKey(h.NetworkId) && !h.Spellbook.IsChanneling && !h.Spellbook.IsCharging && !h.Spellbook.IsCastingSpell
			select h)
			{
				Interrupter.CastingSpell.Remove(aiheroClient.NetworkId);
			}
			if (Interrupter.OnInterrupterSpell == null)
			{
				return;
			}
			foreach (Interrupter.InterruptSpellArgs interruptSpellArgs in from h in GameObjects.EnemyHeroes.Select(new Func<AIHeroClient, Interrupter.InterruptSpellArgs>(Interrupter.GetSpell))
			where h != null
			select h)
			{
				Interrupter.OnInterrupterSpell(interruptSpellArgs.Sender, interruptSpellArgs);
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000FD88 File Offset: 0x0000DF88
		public static bool IsCastingImporantSpell(this AIHeroClient unit)
		{
			return !(unit == null) && unit.IsValid && Interrupter.SpellDatabase.ContainsKey(unit.CharacterName) && Interrupter.SpellDatabase[unit.CharacterName].Any((Interrupter.InterruptSpellDB x) => unit.GetLastCastedSpell() != null && ((unit.GetSpellSlot(unit.GetLastCastedSpell().Name) == x.SpellSlot && x.SpellSlot != SpellSlot.Unknown) || (unit.GetLastCastedSpell().Name == "SummonerTeleport" && x.SpellSlot == SpellSlot.Unknown)) && (float)Variables.GameTimeTickCount - unit.GetLastCastedSpell().EndTime < 350f);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000FDFC File Offset: 0x0000DFFC
		private static void AddInterruptSpellInDB(string champName, SpellSlot slot, Interrupter.DangerLevel dangerLevel)
		{
			if (!Interrupter.SpellDatabase.ContainsKey(champName))
			{
				Interrupter.SpellDatabase.Add(champName, new List<Interrupter.InterruptSpellDB>());
			}
			Interrupter.SpellDatabase[champName].Add(new Interrupter.InterruptSpellDB
			{
				SpellSlot = slot,
				DangerLevel = dangerLevel
			});
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000FE4C File Offset: 0x0000E04C
		private static void OnDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (sender == null || !sender.IsValid || sender.Type != GameObjectType.AIHeroClient || !sender.IsEnemy)
			{
				return;
			}
			if (Interrupter.CastingSpell.ContainsKey(sender.NetworkId) || !Interrupter.SpellDatabase.ContainsKey(sender.CharacterName))
			{
				return;
			}
			Interrupter.InterruptSpellDB interruptSpellDB = Interrupter.SpellDatabase[sender.CharacterName].Find((Interrupter.InterruptSpellDB o) => o.SpellSlot == args.Slot || (o.SpellSlot == SpellSlot.Unknown && args.SData.Name.StartsWith("SummonerTeleport")));
			if (interruptSpellDB != null)
			{
				Interrupter.CastingSpell.Add(sender.NetworkId, interruptSpellDB);
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000FEE4 File Offset: 0x0000E0E4
		private static Interrupter.InterruptSpellArgs GetSpell(AIHeroClient hero)
		{
			if (hero == null || !hero.IsValid || hero.IsDead || !Interrupter.CastingSpell.ContainsKey(hero.NetworkId))
			{
				return null;
			}
			Interrupter.InterruptSpellDB interruptSpellDB = Interrupter.CastingSpell[hero.NetworkId];
			return new Interrupter.InterruptSpellArgs
			{
				Sender = hero,
				Slot = interruptSpellDB.SpellSlot,
				DangerLevel = interruptSpellDB.DangerLevel,
				EndTime = hero.Spellbook.CastEndTime
			};
		}

		// Token: 0x04000119 RID: 281
		public static Dictionary<int, Interrupter.InterruptSpellDB> CastingSpell = new Dictionary<int, Interrupter.InterruptSpellDB>();

		// Token: 0x0400011A RID: 282
		public static readonly Dictionary<string, List<Interrupter.InterruptSpellDB>> SpellDatabase = new Dictionary<string, List<Interrupter.InterruptSpellDB>>();

		// Token: 0x02000470 RID: 1136
		// (Invoke) Token: 0x060014EC RID: 5356
		public delegate void InterrupterSpellHandler(AIHeroClient sender, Interrupter.InterruptSpellArgs args);

		// Token: 0x02000471 RID: 1137
		public enum DangerLevel
		{
			// Token: 0x04000B74 RID: 2932
			High,
			// Token: 0x04000B75 RID: 2933
			Medium,
			// Token: 0x04000B76 RID: 2934
			Low
		}

		// Token: 0x02000472 RID: 1138
		public class InterruptSpellDB
		{
			// Token: 0x170001BA RID: 442
			// (get) Token: 0x060014EF RID: 5359 RVA: 0x0004BB85 File Offset: 0x00049D85
			// (set) Token: 0x060014F0 RID: 5360 RVA: 0x0004BB8D File Offset: 0x00049D8D
			public Interrupter.DangerLevel DangerLevel { get; internal set; }

			// Token: 0x170001BB RID: 443
			// (get) Token: 0x060014F1 RID: 5361 RVA: 0x0004BB96 File Offset: 0x00049D96
			// (set) Token: 0x060014F2 RID: 5362 RVA: 0x0004BB9E File Offset: 0x00049D9E
			public SpellSlot SpellSlot { get; internal set; }
		}

		// Token: 0x02000473 RID: 1139
		public class InterruptSpellArgs
		{
			// Token: 0x170001BC RID: 444
			// (get) Token: 0x060014F4 RID: 5364 RVA: 0x0004BBAF File Offset: 0x00049DAF
			// (set) Token: 0x060014F5 RID: 5365 RVA: 0x0004BBB7 File Offset: 0x00049DB7
			public AIHeroClient Sender { get; set; }

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x060014F6 RID: 5366 RVA: 0x0004BBC0 File Offset: 0x00049DC0
			// (set) Token: 0x060014F7 RID: 5367 RVA: 0x0004BBC8 File Offset: 0x00049DC8
			public SpellSlot Slot { get; internal set; }

			// Token: 0x170001BE RID: 446
			// (get) Token: 0x060014F8 RID: 5368 RVA: 0x0004BBD1 File Offset: 0x00049DD1
			// (set) Token: 0x060014F9 RID: 5369 RVA: 0x0004BBD9 File Offset: 0x00049DD9
			public Interrupter.DangerLevel DangerLevel { get; internal set; }

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x060014FA RID: 5370 RVA: 0x0004BBE2 File Offset: 0x00049DE2
			// (set) Token: 0x060014FB RID: 5371 RVA: 0x0004BBEA File Offset: 0x00049DEA
			public float EndTime { get; internal set; }
		}
	}
}

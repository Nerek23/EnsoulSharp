using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using EnsoulSharp.SDK.Damages.Items;
using EnsoulSharp.SDK.Damages.Passives;
using EnsoulSharp.SDK.Damages.Spells;
using EnsoulSharp.SDK.Damages.SummonerSpells;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000009 RID: 9
	[Export(typeof(DamageData))]
	public class DamageData
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00004181 File Offset: 0x00002381
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00004189 File Offset: 0x00002389
		[ImportMany]
		public IEnumerable<Lazy<IDamageItem, IDamageItemMetadata>> ItemLazies { get; protected set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00004192 File Offset: 0x00002392
		// (set) Token: 0x06000045 RID: 69 RVA: 0x0000419A File Offset: 0x0000239A
		[ImportMany]
		public IEnumerable<Lazy<IPassiveDamage, IPassiveDamageMetadata>> PassiveLazies { get; protected set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000041A3 File Offset: 0x000023A3
		// (set) Token: 0x06000047 RID: 71 RVA: 0x000041AB File Offset: 0x000023AB
		[ImportMany]
		public IEnumerable<Lazy<IDamageSpell, IDamageSpellMetadata>> SpellLazies { get; protected set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000041B4 File Offset: 0x000023B4
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000041BC File Offset: 0x000023BC
		[ImportMany]
		public IEnumerable<Lazy<ISummonerSpell, ISummonerSpellMetadata>> SummonerSpellLazies { get; protected set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000041C5 File Offset: 0x000023C5
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000041CD File Offset: 0x000023CD
		public IDictionary<string, IList<Lazy<IDamageSpell, IDamageSpellMetadata>>> SpellsDictionary { get; set; }

		// Token: 0x0600004C RID: 76 RVA: 0x000041D8 File Offset: 0x000023D8
		public double GetItemDamage(AIHeroClient source, AIBaseClient target, DamageItems item, ItemDamageType type = ItemDamageType.Default, bool fromSDKCache = false)
		{
			double num = 0.0;
			IDamageItem itemDamage = this.GetItemDamage(item);
			if (itemDamage != null)
			{
				if (type.HasFlag(ItemDamageType.Default))
				{
					num += itemDamage.GetDamage(source, target);
				}
				if (type.HasFlag(ItemDamageType.Passive))
				{
					num += itemDamage.GetPassiveDamage(source, target);
				}
			}
			return num;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000423C File Offset: 0x0000243C
		public DamageSpell GetDamageSpell(AIHeroClient source, AIBaseClient target, SpellSlot slot, int stage = 0)
		{
			IList<Lazy<IDamageSpell, IDamageSpellMetadata>> source2;
			if (this.SpellsDictionary.TryGetValue(source.CharacterName, out source2))
			{
				Lazy<IDamageSpell, IDamageSpellMetadata> lazy = source2.FirstOrDefault((Lazy<IDamageSpell, IDamageSpellMetadata> v) => v.Metadata.SpellSlot == slot && v.Metadata.Stage == stage);
				if (lazy != null)
				{
					int level = Math.Max(0, Math.Min(source.Spellbook.GetSpell(slot).Level - 1, 5));
					double amount = lazy.Value.Damage(source, target, level);
					lazy.Value.CalculatedDamage = source.CalculateDamage(target, lazy.Value.DamageType, amount);
					return lazy.Value as DamageSpell;
				}
			}
			return null;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000042F0 File Offset: 0x000024F0
		public DamageSpell GetStealSpellDamage(AIHeroClient source, AIHeroClient originHero, AIBaseClient target, int stage = 0)
		{
			IList<Lazy<IDamageSpell, IDamageSpellMetadata>> source2;
			if (this.SpellsDictionary.TryGetValue(originHero.CharacterName, out source2))
			{
				Lazy<IDamageSpell, IDamageSpellMetadata> lazy = source2.FirstOrDefault((Lazy<IDamageSpell, IDamageSpellMetadata> v) => v.Metadata.SpellSlot == SpellSlot.R && v.Metadata.Stage == stage);
				if (lazy != null)
				{
					int level = Math.Max(0, Math.Min(source.Spellbook.GetSpell(SpellSlot.R).Level - 1, 5));
					double amount = lazy.Value.Damage(source, target, level);
					lazy.Value.CalculatedDamage = source.CalculateDamage(target, lazy.Value.DamageType, amount);
					return lazy.Value as DamageSpell;
				}
			}
			return null;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004398 File Offset: 0x00002598
		public IDamageItem GetItemDamage(DamageItems item)
		{
			Lazy<IDamageItem, IDamageItemMetadata> lazy = this.ItemLazies.FirstOrDefault((Lazy<IDamageItem, IDamageItemMetadata> i) => i.Metadata.Item == item);
			if (lazy == null)
			{
				return null;
			}
			return lazy.Value;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000043D4 File Offset: 0x000025D4
		public double GetSummonerSpellDamage(AIHeroClient source, AIBaseClient target, SummonerSpell summonerSpell)
		{
			return (from lazy in this.SummonerSpellLazies
			where lazy.Metadata.SummonerSpell == summonerSpell
			select lazy.Value.GetDamage(source, target)).FirstOrDefault<double>();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000442C File Offset: 0x0000262C
		internal void SortSpells()
		{
			Dictionary<string, IList<Lazy<IDamageSpell, IDamageSpellMetadata>>> dictionary = new Dictionary<string, IList<Lazy<IDamageSpell, IDamageSpellMetadata>>>();
			string[] source = (from s in ObjectManager.Get<AIHeroClient>()
			select s.CharacterName).ToArray<string>();
			using (IEnumerator<Lazy<IDamageSpell, IDamageSpellMetadata>> enumerator = this.SpellLazies.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Lazy<IDamageSpell, IDamageSpellMetadata> lazy = enumerator.Current;
					if (source.Any((string c) => c.Equals(lazy.Metadata.ChampionName, StringComparison.CurrentCultureIgnoreCase) && lazy.Metadata.ChampionName != "AllChampions"))
					{
						IList<Lazy<IDamageSpell, IDamageSpellMetadata>> list;
						IList<Lazy<IDamageSpell, IDamageSpellMetadata>> list2;
						if (dictionary.TryGetValue(lazy.Metadata.ChampionName, out list))
						{
							list.Add(lazy);
						}
						else if (dictionary.TryGetValue("AllChampions", out list2))
						{
							list2.Add(lazy);
						}
						else
						{
							dictionary[lazy.Metadata.ChampionName] = new List<Lazy<IDamageSpell, IDamageSpellMetadata>>
							{
								lazy
							};
						}
					}
				}
			}
			this.SpellsDictionary = dictionary;
		}
	}
}

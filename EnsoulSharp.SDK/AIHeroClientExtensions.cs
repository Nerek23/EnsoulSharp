using System;
using System.Linq;
using System.Runtime.CompilerServices;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200000D RID: 13
	public static class AIHeroClientExtensions
	{
		// Token: 0x06000053 RID: 83 RVA: 0x0000454C File Offset: 0x0000274C
		public static bool HavePerk(this AIHeroClient source, PerksId perkId)
		{
			if (source == null || !source.IsValid)
			{
				return false;
			}
			GameCache.HeroCache heroCache = Library.GameCache.AllHeroCache.Find((GameCache.HeroCache x) => x.Hero.Compare(source));
			return heroCache != null && heroCache.Perks.Any((Perk x) => x.Id == (int)perkId);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000045C4 File Offset: 0x000027C4
		public static bool CanUseItem(this AIHeroClient source, string name)
		{
			if (source != null && source.IsValid)
			{
				return (from slot in source.InventoryItems
				where slot != null && slot.IData != null && slot.IData.DisplayName == name
				select source.Spellbook.Spells.FirstOrDefault((SpellDataInst spell) => spell.Slot == slot.SpellSlot) into inst
				select inst != null && inst.IsReady(0)).FirstOrDefault<bool>();
			}
			return false;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004658 File Offset: 0x00002858
		public static bool CanUseItem(this AIHeroClient source, ItemId id)
		{
			if (source != null && source.IsValid)
			{
				return (from slot in source.InventoryItems
				where slot != null && slot.Id == id
				select source.Spellbook.Spells.FirstOrDefault((SpellDataInst spell) => spell.Slot == slot.SpellSlot) into inst
				select inst != null && inst.IsReady(0)).FirstOrDefault<bool>();
			}
			return false;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000046EC File Offset: 0x000028EC
		public static SpellSlot GetSpellSlotFromName(this AIHeroClient source, string name)
		{
			if (source != null && source.IsValid && source.Spellbook != null)
			{
				SpellDataInst spellDataInst = source.Spellbook.Spells.FirstOrDefault((SpellDataInst x) => x != null && x.Name.ToLower() == name.ToLower());
				if (spellDataInst != null && spellDataInst.Slot != SpellSlot.Unknown)
				{
					return spellDataInst.Slot;
				}
			}
			return SpellSlot.Unknown;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004750 File Offset: 0x00002950
		public static bool IsZombie(this AIHeroClient source)
		{
			if (source != null && source.IsValid)
			{
				if (source.CharacterName == "Sion" && source.HasBuff("sionpassivezombie"))
				{
					return true;
				}
				if (source.CharacterName == "KogMaw" && source.HasBuff("kogmawicathiansurprise"))
				{
					return true;
				}
				if (source.CharacterName == "Karthus" && source.HasBuff("KarthusDeathDefiedBuff"))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000047D4 File Offset: 0x000029D4
		public static bool CanUseItem(this AIHeroClient source, int id)
		{
			if (source != null && source.IsValid)
			{
				return (from slot in source.InventoryItems
				where slot != null && slot.Id == (ItemId)id
				select source.Spellbook.Spells.FirstOrDefault((SpellDataInst spell) => spell.Slot == slot.SpellSlot) into inst
				select inst != null && inst.IsReady(0)).FirstOrDefault<bool>();
			}
			return false;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004868 File Offset: 0x00002A68
		public static int GetRecallTime(this AIHeroClient hero)
		{
			return hero.Spellbook.GetSpell(SpellSlot.Recall).Name.GetRecallTime();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004884 File Offset: 0x00002A84
		public static InventorySlot GetWardSlot(this AIHeroClient source)
		{
			return (from wardId in AIHeroClientExtensions.WardIds
			where source.CanUseItem((int)wardId)
			select source.InventoryItems.FirstOrDefault((InventorySlot slot) => slot != null && slot.Id == wardId)).FirstOrDefault<InventorySlot>();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000048CC File Offset: 0x00002ACC
		public static bool HasItem(this AIHeroClient source, string name)
		{
			return source != null && source.IsValid && source.InventoryItems.Any((InventorySlot slot) => slot != null && slot.IData != null && slot.IData.DisplayName == name);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004910 File Offset: 0x00002B10
		public static bool HasItem(this AIHeroClient source, int id)
		{
			return source != null && source.IsValid && source.InventoryItems.Any((InventorySlot slot) => slot != null && slot.Id == (ItemId)id);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004954 File Offset: 0x00002B54
		public static bool HasItem(this AIHeroClient source, ItemId id)
		{
			return source != null && source.IsValid && source.InventoryItems.Any((InventorySlot slot) => slot != null && slot.Id == id);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004998 File Offset: 0x00002B98
		public static bool InFountain(this AIHeroClient hero)
		{
			double fountainRange = Math.Pow(750.0, 2.0);
			if (Game.MapId == GameMapId.SummonersRift)
			{
				fountainRange = Math.Pow(1050.0, 2.0);
			}
			return hero != null && hero.IsValid() && hero.IsVisible && GameObjects.AllySpawnPoints.Any((Obj_SpawnPoint sp) => sp != null && sp.IsValid && (double)hero.DistanceSquared(sp.Position) < fountainRange);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004A38 File Offset: 0x00002C38
		public static bool InShop(this AIHeroClient hero)
		{
			return hero != null && hero.IsValid() && hero.IsVisible && GameObjects.AllyShops.Any((ShopClient s) => s != null && s.IsValid && hero.DistanceSquared(s.Position) < 1562500f);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004A92 File Offset: 0x00002C92
		public static bool IsRecalling(this AIHeroClient unit)
		{
			return unit != null && unit.IsValid && (unit.HasBuff("recall") || unit.HasBuff("superrecall"));
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004AC4 File Offset: 0x00002CC4
		public static bool UseItem(this AIHeroClient source, string name, AIHeroClient target = null)
		{
			return !(source == null) && source.IsValid && source.Compare(GameObjects.Player) && (from slot in source.InventoryItems
			where slot.IData.DisplayName == name
			select slot).Select(delegate(InventorySlot slot)
			{
				if (!(target != null) || !target.IsValid)
				{
					return source.Spellbook.CastSpell(slot.SpellSlot);
				}
				return source.Spellbook.CastSpell(slot.SpellSlot, target);
			}).FirstOrDefault<bool>();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004B50 File Offset: 0x00002D50
		public static bool UseItem(this AIHeroClient source, int id, AIBaseClient target = null)
		{
			return !(source == null) && source.IsValid && source.Compare(GameObjects.Player) && (from slot in source.InventoryItems
			where slot.Id == (ItemId)id
			select slot).Select(delegate(InventorySlot slot)
			{
				if (!(target != null) || !target.IsValid)
				{
					return source.Spellbook.CastSpell(slot.SpellSlot);
				}
				return source.Spellbook.CastSpell(slot.SpellSlot, target);
			}).FirstOrDefault<bool>();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004BD9 File Offset: 0x00002DD9
		public static bool UseItem(this AIHeroClient source, int id, Vector2 position)
		{
			return source.UseItem(id, position.ToVector3(0f));
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004BF0 File Offset: 0x00002DF0
		public static bool UseItem(this AIHeroClient source, int id, Vector3 position)
		{
			return !(source == null) && source.IsValid && source.Compare(GameObjects.Player) && position != Vector3.Zero && (from slot in source.InventoryItems
			where slot.Id == (ItemId)id
			select source.Spellbook.CastSpell(slot.SpellSlot, position)).FirstOrDefault<bool>();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004C8D File Offset: 0x00002E8D
		// Note: this type is marked as 'beforefieldinit'.
		static AIHeroClientExtensions()
		{
			ItemId[] array = new ItemId[13];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.9E0019BE8E7BEF7602565A809C467709028C96F3).FieldHandle);
			AIHeroClientExtensions.WardIds = array;
		}

		// Token: 0x04000037 RID: 55
		private static readonly ItemId[] WardIds;
	}
}

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000023 RID: 35
	public static class Items
	{
		// Token: 0x0600018C RID: 396 RVA: 0x00009F90 File Offset: 0x00008190
		public static bool CanUseItem(AIHeroClient source, string name)
		{
			if (source != null && source.IsValid)
			{
				return (from slot in source.InventoryItems
				where slot != null && slot.IData.DisplayName == name
				select source.Spellbook.Spells.FirstOrDefault((SpellDataInst spell) => spell.Slot == slot.SpellSlot) into inst
				select inst != null && inst.State == SpellState.Ready).FirstOrDefault<bool>();
			}
			return false;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000A024 File Offset: 0x00008224
		public static bool CanUseItem(AIHeroClient source, int id)
		{
			if (source != null && source.IsValid)
			{
				return (from slot in source.InventoryItems
				where slot != null && slot.Id == (ItemId)id
				select source.Spellbook.Spells.FirstOrDefault((SpellDataInst spell) => spell.Slot == slot.SpellSlot) into inst
				select inst != null && inst.State == SpellState.Ready).FirstOrDefault<bool>();
			}
			return false;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000A0B8 File Offset: 0x000082B8
		public static InventorySlot GetWardSlot(AIHeroClient source)
		{
			ItemId[] array = new ItemId[9];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.7A12470977651BA09B3FC44F7791F5FC05726116).FieldHandle);
			ItemId[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				ItemId wardId = array2[i];
				if (Items.CanUseItem(source, (int)wardId))
				{
					return source.InventoryItems.FirstOrDefault((InventorySlot slot) => slot != null && slot.Id == wardId);
				}
			}
			return null;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000A11C File Offset: 0x0000831C
		public static bool HasItem(AIHeroClient source, string name)
		{
			return source != null && source.IsValid && source.InventoryItems.Any((InventorySlot slot) => slot != null && slot.IData.DisplayName == name);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000A160 File Offset: 0x00008360
		public static bool HasItem(AIHeroClient source, int id)
		{
			return source != null && source.IsValid && source.InventoryItems.Any((InventorySlot slot) => slot != null && slot.Id == (ItemId)id);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000A1A4 File Offset: 0x000083A4
		public static bool HasItem(AIHeroClient source, ItemId id)
		{
			return source != null && source.IsValid && source.InventoryItems.Any((InventorySlot slot) => slot != null && slot.Id == id);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000A1E8 File Offset: 0x000083E8
		public static bool UseItem(AIHeroClient source, string name, AIHeroClient target = null)
		{
			return !(source == null) && source.IsValid && source.Compare(GameObjects.Player) && (from slot in GameObjects.Player.InventoryItems
			where slot != null && slot.IData.DisplayName == name
			select slot).Select(delegate(InventorySlot slot)
			{
				if (!(target != null) || !target.IsValid)
				{
					return GameObjects.Player.Spellbook.CastSpell(slot.SpellSlot);
				}
				return GameObjects.Player.Spellbook.CastSpell(slot.SpellSlot, target);
			}).FirstOrDefault<bool>();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000A25C File Offset: 0x0000845C
		public static bool UseItem(AIHeroClient source, int id, AIBaseClient target = null)
		{
			return !(source == null) && source.IsValid && source.Compare(GameObjects.Player) && (from slot in GameObjects.Player.InventoryItems
			where slot != null && slot.Id == (ItemId)id
			select slot).Select(delegate(InventorySlot slot)
			{
				if (!(target != null) || !target.IsValid)
				{
					return GameObjects.Player.Spellbook.CastSpell(slot.SpellSlot);
				}
				return GameObjects.Player.Spellbook.CastSpell(slot.SpellSlot, target);
			}).FirstOrDefault<bool>();
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000A2CE File Offset: 0x000084CE
		public static bool UseItem(AIHeroClient source, int id, Vector2 position)
		{
			return Items.UseItem(source, id, position.ToVector3(0f));
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000A2E4 File Offset: 0x000084E4
		public static bool UseItem(AIHeroClient source, int id, Vector3 position)
		{
			return !(source == null) && source.IsValid && source.Compare(GameObjects.Player) && position != Vector3.Zero && (from slot in GameObjects.Player.InventoryItems
			where slot != null && slot.Id == (ItemId)id
			select GameObjects.Player.Spellbook.CastSpell(slot.SpellSlot, position)).FirstOrDefault<bool>();
		}

		// Token: 0x02000448 RID: 1096
		public class Item
		{
			// Token: 0x0600144F RID: 5199 RVA: 0x0004B007 File Offset: 0x00049207
			public Item(int id, float range)
			{
				this.Id = id;
				this.Range = range;
			}

			// Token: 0x06001450 RID: 5200 RVA: 0x0004B01D File Offset: 0x0004921D
			public Item(ItemId id, float range)
			{
				this.Id = id;
				this.Range = range;
			}

			// Token: 0x170001A1 RID: 417
			// (get) Token: 0x06001451 RID: 5201 RVA: 0x0004B033 File Offset: 0x00049233
			public int Id { get; }

			// Token: 0x170001A2 RID: 418
			// (get) Token: 0x06001452 RID: 5202 RVA: 0x0004B03B File Offset: 0x0004923B
			// (set) Token: 0x06001453 RID: 5203 RVA: 0x0004B043 File Offset: 0x00049243
			public float Range { get; set; }

			// Token: 0x170001A3 RID: 419
			// (get) Token: 0x06001454 RID: 5204 RVA: 0x0004B04C File Offset: 0x0004924C
			public float RangeSqr
			{
				get
				{
					return this.Range * this.Range;
				}
			}

			// Token: 0x170001A4 RID: 420
			// (get) Token: 0x06001455 RID: 5205 RVA: 0x0004B05B File Offset: 0x0004925B
			public InventorySlot InventorySlot
			{
				get
				{
					if (this.Id != 0)
					{
						return GameObjects.Player.InventoryItems.FirstOrDefault((InventorySlot slot) => slot != null && slot.Id == (ItemId)this.Id);
					}
					return null;
				}
			}

			// Token: 0x170001A5 RID: 421
			// (get) Token: 0x06001456 RID: 5206 RVA: 0x0004B082 File Offset: 0x00049282
			public int BasePrice
			{
				get
				{
					InventorySlot inventorySlot = this.InventorySlot;
					if (inventorySlot == null)
					{
						return -1;
					}
					return inventorySlot.IData.Price;
				}
			}

			// Token: 0x170001A6 RID: 422
			// (get) Token: 0x06001457 RID: 5207 RVA: 0x0004B09A File Offset: 0x0004929A
			public bool HideFromAll
			{
				get
				{
					return this.InventorySlot != null && this.InventorySlot.IData.UsableInStore;
				}
			}

			// Token: 0x170001A7 RID: 423
			// (get) Token: 0x06001458 RID: 5208 RVA: 0x0004B0B6 File Offset: 0x000492B6
			public bool IsReady
			{
				get
				{
					return this.InventorySlot != null && Items.CanUseItem(GameObjects.Player, this.Id);
				}
			}

			// Token: 0x170001A8 RID: 424
			// (get) Token: 0x06001459 RID: 5209 RVA: 0x0004B0D2 File Offset: 0x000492D2
			public string Name
			{
				get
				{
					if (this.InventorySlot == null)
					{
						return "Unknow";
					}
					return this.InventorySlot.IData.DisplayName;
				}
			}

			// Token: 0x170001A9 RID: 425
			// (get) Token: 0x0600145A RID: 5210 RVA: 0x0004B0F2 File Offset: 0x000492F2
			public bool CanBeSold
			{
				get
				{
					return this.InventorySlot != null && this.InventorySlot.IData.CanBeSold;
				}
			}

			// Token: 0x170001AA RID: 426
			// (get) Token: 0x0600145B RID: 5211 RVA: 0x0004B10E File Offset: 0x0004930E
			public int SellPrice
			{
				get
				{
					if (this.InventorySlot != null)
					{
						return (int)((float)this.InventorySlot.IData.Price * this.InventorySlot.IData.SellBackModifier);
					}
					return -1;
				}
			}

			// Token: 0x170001AB RID: 427
			// (get) Token: 0x0600145C RID: 5212 RVA: 0x0004B13D File Offset: 0x0004933D
			public int Stacks
			{
				get
				{
					InventorySlot inventorySlot = this.InventorySlot;
					if (inventorySlot == null)
					{
						return 0;
					}
					return inventorySlot.IData.MaxStack;
				}
			}

			// Token: 0x170001AC RID: 428
			// (get) Token: 0x0600145D RID: 5213 RVA: 0x0004B158 File Offset: 0x00049358
			public SpellSlot Slot
			{
				get
				{
					return (from slot in GameObjects.Player.InventoryItems
					where slot != null && slot.Id == (ItemId)this.Id && slot.SpellSlot != SpellSlot.Unknown
					select slot.SpellSlot).FirstOrDefault<SpellSlot>();
				}
			}

			// Token: 0x0600145E RID: 5214 RVA: 0x0004B1A9 File Offset: 0x000493A9
			public void Buy()
			{
				GameObjects.Player.BuyItem((ItemId)this.Id);
			}

			// Token: 0x0600145F RID: 5215 RVA: 0x0004B1BC File Offset: 0x000493BC
			public bool Cast()
			{
				return Items.UseItem(GameObjects.Player, this.Id, null);
			}

			// Token: 0x06001460 RID: 5216 RVA: 0x0004B1CF File Offset: 0x000493CF
			public bool Cast(AIBaseClient target)
			{
				return Items.UseItem(GameObjects.Player, this.Id, target);
			}

			// Token: 0x06001461 RID: 5217 RVA: 0x0004B1E2 File Offset: 0x000493E2
			public bool Cast(Vector2 position)
			{
				return Items.UseItem(GameObjects.Player, this.Id, position);
			}

			// Token: 0x06001462 RID: 5218 RVA: 0x0004B1F5 File Offset: 0x000493F5
			public bool Cast(Vector3 position)
			{
				return Items.UseItem(GameObjects.Player, this.Id, position);
			}

			// Token: 0x06001463 RID: 5219 RVA: 0x0004B208 File Offset: 0x00049408
			public bool IsInRange(AIBaseClient target)
			{
				return this.IsInRange(target.ServerPosition);
			}

			// Token: 0x06001464 RID: 5220 RVA: 0x0004B216 File Offset: 0x00049416
			public bool IsInRange(Vector2 position)
			{
				return this.IsInRange(position.ToVector3(0f));
			}

			// Token: 0x06001465 RID: 5221 RVA: 0x0004B229 File Offset: 0x00049429
			public bool IsInRange(Vector3 position)
			{
				return GameObjects.Player.ServerPosition.DistanceSquared(position) < this.RangeSqr;
			}

			// Token: 0x06001466 RID: 5222 RVA: 0x0004B243 File Offset: 0x00049443
			public bool IsOwned()
			{
				return Items.HasItem(GameObjects.Player, this.Id);
			}
		}
	}
}

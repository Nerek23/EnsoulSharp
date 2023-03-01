using System;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each inventory in slot.
	/// </summary>
	// Token: 0x02000069 RID: 105
	public class InventorySlot
	{
		// Token: 0x06000423 RID: 1059 RVA: 0x0000C924 File Offset: 0x0000BD24
		internal InventorySlot(uint networkId, uint slot)
		{
			this.m_networkId = networkId;
			this.m_slot = slot;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000C948 File Offset: 0x0000BD48
		internal unsafe InventorySlot* GetPtr()
		{
			AIBaseClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetUnitByNetworkId(this.m_networkId);
			if (ptr != null)
			{
				BaseInventory* ptr2 = *<Module>.EnsoulSharp.Native.AIBaseCommon.GetInventory(ptr);
				if (ptr2 != null)
				{
					return *(this.m_slot * 4U + <Module>.EnsoulSharp.Native.HeroInventoryCommon.GetInventory(ptr2));
				}
			}
			throw new InventorySlotNotFoundException();
		}

		/// <summary>
		/// 	Gets the spell slot of the inventory.
		/// </summary>
		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0000C988 File Offset: 0x0000BD88
		public SpellSlot SpellSlot
		{
			get
			{
				return (int)this.m_slot + SpellSlot.Item1;
			}
		}

		/// <summary>
		/// 	Gets the slot of the inventory.
		/// </summary>
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000C9A0 File Offset: 0x0000BDA0
		public int Slot
		{
			get
			{
				return (int)this.m_slot;
			}
		}

		/// <summary>
		/// 	Gets the item id of the inventory.
		/// </summary>
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0000C9B4 File Offset: 0x0000BDB4
		public unsafe ItemId Id
		{
			get
			{
				InventorySlot* ptr = this.GetPtr();
				if (ptr != null)
				{
					ItemInInventory* ptr2 = *<Module>.EnsoulSharp.Native.InventorySlot.GetItemInInventory(ptr);
					if (ptr2 != null)
					{
						ItemData* ptr3 = *<Module>.EnsoulSharp.Native.ItemInInventory.GetItemData(ptr2);
						if (ptr3 != null)
						{
							return (ItemId)(*<Module>.EnsoulSharp.Native.ItemData.GetItemID(ptr3));
						}
					}
				}
				return ItemId.Unknown;
			}
		}

		/// <summary>
		/// 	Gets the inventory count in slot.
		/// </summary>
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x0000C9EC File Offset: 0x0000BDEC
		public unsafe int CountInSlot
		{
			get
			{
				InventorySlot* ptr = this.GetPtr();
				if (ptr != null)
				{
					return (int)(*<Module>.EnsoulSharp.Native.InventorySlot.GetCountInSlot(ptr));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the purchase time of the inventory.
		/// </summary>
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0000CA0C File Offset: 0x0000BE0C
		public unsafe float PurchaseTime
		{
			get
			{
				InventorySlot* ptr = this.GetPtr();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.InventorySlot.GetPurchaseTime(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the spell charges of the inventory.
		/// </summary>
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000CA30 File Offset: 0x0000BE30
		public unsafe int SpellCharges
		{
			get
			{
				InventorySlot* ptr = this.GetPtr();
				if (ptr != null)
				{
					ItemInInventory* ptr2 = *<Module>.EnsoulSharp.Native.InventorySlot.GetItemInInventory(ptr);
					if (ptr2 != null)
					{
						return (int)(*<Module>.EnsoulSharp.Native.ItemInInventory.GetSpellCharges(ptr2));
					}
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the invested gold amount of the inventory.
		/// </summary>
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0000CA5C File Offset: 0x0000BE5C
		public unsafe float InvestedGoldAmount
		{
			get
			{
				InventorySlot* ptr = this.GetPtr();
				if (ptr != null)
				{
					ItemInInventory* ptr2 = *<Module>.EnsoulSharp.Native.InventorySlot.GetItemInInventory(ptr);
					if (ptr2 != null)
					{
						return *<Module>.EnsoulSharp.Native.ItemInInventory.GetInvestedGoldAmount(ptr2);
					}
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the item data of the inventory.
		/// </summary>
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x0000CA8C File Offset: 0x0000BE8C
		public unsafe ItemData IData
		{
			get
			{
				InventorySlot* ptr = this.GetPtr();
				if (ptr != null)
				{
					ItemInInventory* ptr2 = *<Module>.EnsoulSharp.Native.InventorySlot.GetItemInInventory(ptr);
					if (ptr2 != null)
					{
						ItemData* ptr3 = *<Module>.EnsoulSharp.Native.ItemInInventory.GetItemData(ptr2);
						if (ptr3 != null)
						{
							return new ItemData(ptr3);
						}
					}
				}
				return null;
			}
		}

		// Token: 0x04000398 RID: 920
		private uint m_networkId;

		// Token: 0x04000399 RID: 921
		private uint m_slot;
	}
}

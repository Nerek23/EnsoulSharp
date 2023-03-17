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
		// Token: 0x0600042E RID: 1070 RVA: 0x0000CA14 File Offset: 0x0000BE14
		internal InventorySlot(uint networkId, uint slot)
		{
			this.m_networkId = networkId;
			this.m_slot = slot;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000CA38 File Offset: 0x0000BE38
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
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x0000CA78 File Offset: 0x0000BE78
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
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000CA90 File Offset: 0x0000BE90
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
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x0000CAA4 File Offset: 0x0000BEA4
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
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000CADC File Offset: 0x0000BEDC
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
		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x0000CAFC File Offset: 0x0000BEFC
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
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000CB20 File Offset: 0x0000BF20
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
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x0000CB4C File Offset: 0x0000BF4C
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
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x0000CB7C File Offset: 0x0000BF7C
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

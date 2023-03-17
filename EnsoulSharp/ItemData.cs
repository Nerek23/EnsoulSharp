using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each item data.
	/// </summary>
	// Token: 0x02000147 RID: 327
	public class ItemData
	{
		// Token: 0x06000643 RID: 1603 RVA: 0x0000CBB4 File Offset: 0x0000BFB4
		internal unsafe ItemData(ItemData* itemData)
		{
			this.m_itemData = itemData;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0000CBD0 File Offset: 0x0000BFD0
		internal unsafe ItemData* GetPtr()
		{
			return this.m_itemData;
		}

		/// <summary>
		/// 	Gets the required level of the item.
		/// </summary>
		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x0000CBE4 File Offset: 0x0000BFE4
		public unsafe int RequiredLevel
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.ItemData.GetRequiredLevel(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the id of the item.
		/// </summary>
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000646 RID: 1606 RVA: 0x0000CC00 File Offset: 0x0000C000
		public unsafe ItemId Id
		{
			get
			{
				return (ItemId)(*<Module>.EnsoulSharp.Native.ItemData.GetItemID(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the max stack of the item.
		/// </summary>
		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x0000CC1C File Offset: 0x0000C01C
		public unsafe int MaxStack
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.ItemData.GetMaxStack(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the price of the item.
		/// </summary>
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000648 RID: 1608 RVA: 0x0000CC38 File Offset: 0x0000C038
		public unsafe int Price
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.ItemData.GetPrice(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the item is usable in store.
		/// </summary>
		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x0000CC54 File Offset: 0x0000C054
		public unsafe bool UsableInStore
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return *<Module>.EnsoulSharp.Native.ItemData.GetUsableInStore(this.GetPtr()) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the item can be sold.
		/// </summary>
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x0000CC70 File Offset: 0x0000C070
		public unsafe bool CanBeSold
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return *<Module>.EnsoulSharp.Native.ItemData.GetCanBeSold(this.GetPtr()) != 0;
			}
		}

		/// <summary>
		/// 	Gets the sell back modifier of the item.
		/// </summary>
		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x0000CC8C File Offset: 0x0000C08C
		public unsafe float SellBackModifier
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.ItemData.GetSellBackModifier(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the display name of the item.
		/// </summary>
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x0000CCA8 File Offset: 0x0000C0A8
		public unsafe string DisplayName
		{
			get
			{
				sbyte* ptr = *<Module>.EnsoulSharp.Native.ItemData.GetDisplayName(this.GetPtr());
				if (ptr != null)
				{
					return new string((sbyte*)ptr);
				}
				return "unknown";
			}
		}

		/// <summary>
		/// 	Gets the translated display name of the item.
		/// </summary>
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x0000CCD4 File Offset: 0x0000C0D4
		public unsafe string TranslatedDisplayName
		{
			get
			{
				sbyte* ptr = *<Module>.EnsoulSharp.Native.ItemData.GetDisplayName(this.GetPtr());
				if (ptr != null)
				{
					sbyte* ptr2 = <Module>.EnsoulSharp.Native.StringTable.Translate((sbyte*)ptr);
					if (ptr2 != null)
					{
						sbyte* ptr3 = ptr2;
						if (*(sbyte*)ptr2 != 0)
						{
							do
							{
								ptr3 += 1 / sizeof(sbyte);
							}
							while (*(sbyte*)ptr3 != 0);
						}
						int length = (int)(ptr3 - ptr2);
						return new string((sbyte*)ptr2, 0, length, Encoding.UTF8);
					}
				}
				return "unknown";
			}
		}

		/// <summary>
		/// 	Gets the spell name of the item.
		/// </summary>
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x0000CD20 File Offset: 0x0000C120
		public unsafe string SpellName
		{
			get
			{
				sbyte* ptr = *<Module>.EnsoulSharp.Native.ItemData.GetSpellName(this.GetPtr());
				if (ptr != null)
				{
					return new string((sbyte*)ptr);
				}
				return "unknown";
			}
		}

		/// <summary>
		/// 	Gets the entries of all items.
		/// </summary>
		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x0000CD78 File Offset: 0x0000C178
		public unsafe static IEnumerable<ItemData> Entries
		{
			get
			{
				if (ItemData.m_itemDataList == null)
				{
					ItemData.m_itemDataList = new List<ItemData>();
					ItemManager* ptr = <Module>.EnsoulSharp.Native.ItemManager.GetInstance();
					if (ptr != null)
					{
						StlVector<EnsoulSharp::Native::ItemData\u0020*>* ptr2 = <Module>.EnsoulSharp.Native.ItemManager.GetAllItemData(ptr);
						ItemData** ptr3 = *(int*)ptr2;
						if (ptr3 != *(int*)(ptr2 + 4 / sizeof(StlVector<EnsoulSharp::Native::ItemData\u0020*>)))
						{
							do
							{
								ItemData* ptr4 = *(int*)ptr3;
								if (ptr4 != null)
								{
									ItemData.m_itemDataList.Add(new ItemData(ptr4));
								}
								ptr3 += 4 / sizeof(ItemData*);
							}
							while (ptr3 != *(int*)(ptr2 + 4 / sizeof(StlVector<EnsoulSharp::Native::ItemData\u0020*>)));
						}
					}
				}
				return ItemData.m_itemDataList;
			}
		}

		/// <summary>
		/// 	Gets the specific item data.
		/// </summary>
		/// <param name="itemId">The item id.</param>
		/// <returns>The <see cref="T:EnsoulSharp.ItemData" /> instance.</returns>
		/// <remarks>Returns null if the specified item id is invalid.</remarks>
		// Token: 0x06000650 RID: 1616 RVA: 0x0000CD4C File Offset: 0x0000C14C
		public unsafe static ItemData GetIData(ItemId itemId)
		{
			ItemManager* ptr = <Module>.EnsoulSharp.Native.ItemManager.GetInstance();
			if (ptr != null)
			{
				ItemData* ptr2 = <Module>.EnsoulSharp.Native.ItemManager.Get(ptr, (uint)itemId);
				if (ptr2 != null)
				{
					return new ItemData(ptr2);
				}
			}
			return null;
		}

		// Token: 0x04000407 RID: 1031
		private static List<ItemData> m_itemDataList = null;

		// Token: 0x04000408 RID: 1032
		private unsafe ItemData* m_itemData;
	}
}

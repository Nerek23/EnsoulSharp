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
	// Token: 0x02000145 RID: 325
	public class ItemData
	{
		// Token: 0x06000636 RID: 1590 RVA: 0x0000CAC4 File Offset: 0x0000BEC4
		internal unsafe ItemData(ItemData* itemData)
		{
			this.m_itemData = itemData;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0000CAE0 File Offset: 0x0000BEE0
		internal unsafe ItemData* GetPtr()
		{
			return this.m_itemData;
		}

		/// <summary>
		/// 	Gets the required level of the item.
		/// </summary>
		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x0000CAF4 File Offset: 0x0000BEF4
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
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x0000CB10 File Offset: 0x0000BF10
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
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x0000CB2C File Offset: 0x0000BF2C
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
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x0000CB48 File Offset: 0x0000BF48
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
		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x0000CB64 File Offset: 0x0000BF64
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
		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x0000CB80 File Offset: 0x0000BF80
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
		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x0000CB9C File Offset: 0x0000BF9C
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
		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x0000CBB8 File Offset: 0x0000BFB8
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
		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0000CBE4 File Offset: 0x0000BFE4
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
		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x0000CC30 File Offset: 0x0000C030
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
		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x0000CC88 File Offset: 0x0000C088
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
		// Token: 0x06000643 RID: 1603 RVA: 0x0000CC5C File Offset: 0x0000C05C
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

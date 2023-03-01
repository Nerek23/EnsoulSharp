using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each spell data instance.
	/// </summary>
	// Token: 0x02000076 RID: 118
	public class SpellDataInst
	{
		// Token: 0x060004A3 RID: 1187 RVA: 0x0000F7D0 File Offset: 0x0000EBD0
		internal SpellDataInst(uint networkId, uint slot)
		{
			this.m_networkId = networkId;
			this.m_slot = slot;
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000F7F4 File Offset: 0x0000EBF4
		internal unsafe SpellDataInstClient* GetPtr()
		{
			AIBaseClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetUnitByNetworkId(this.m_networkId);
			if (ptr != null)
			{
				return *(this.m_slot * 4U + <Module>.EnsoulSharp.Native.SpellbookClient.GetSpellsDataClient(<Module>.EnsoulSharp.Native.AIBaseCommon.GetSpellbook(ptr)));
			}
			throw new SpellDataInstNotFoundException();
		}

		/// <summary>
		/// 	Gets the level of the spell.
		/// </summary>
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x0000F830 File Offset: 0x0000EC30
		public unsafe int Level
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataInst.GetLevel(ptr);
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the spell is learned.
		/// </summary>
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0000F850 File Offset: 0x0000EC50
		public unsafe bool Learned
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				return ptr != null && *<Module>.EnsoulSharp.Native.SpellDataInst.GetLearned(ptr) != 0;
			}
		}

		/// <summary>
		/// 	Gets the cooldown expires time of the spell.
		/// </summary>
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0000F870 File Offset: 0x0000EC70
		public unsafe float CooldownExpires
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataInst.GetCooldownExpires(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the display numerical of the spell.
		/// </summary>
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0000F894 File Offset: 0x0000EC94
		public unsafe int NumericalDisplay
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null && *<Module>.EnsoulSharp.Native.SpellVisualData.GetNumericalDisplayActive(<Module>.EnsoulSharp.Native.SpellDataInst.GetVisualData(ptr)) != 0)
				{
					return *<Module>.EnsoulSharp.Native.SpellVisualData.GetCurrentNumericalDisplay(<Module>.EnsoulSharp.Native.SpellDataInst.GetVisualData(ptr));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the current ammo of the spell.
		/// </summary>
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x0000F8C8 File Offset: 0x0000ECC8
		public unsafe int Ammo
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataInst.GetCurrentAmmo(ptr);
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the time for next ammo recharge.
		/// </summary>
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0000F8E8 File Offset: 0x0000ECE8
		public unsafe float NextAmmoRechargeTime
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataInst.GetTimeForNextAmmoRecharge(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the total ammo recharge time.
		/// </summary>
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0000F90C File Offset: 0x0000ED0C
		public unsafe float AmmoRechargeTime
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataInst.GetTotalAmmoRechargeTime(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the toggle state of the spell.
		/// </summary>
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0000F930 File Offset: 0x0000ED30
		public unsafe SpellToggleState ToggleState
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					return (SpellToggleState)(*<Module>.EnsoulSharp.Native.SpellDataInst.GetToggleState(ptr));
				}
				return SpellToggleState.None;
			}
		}

		/// <summary>
		/// 	Gets the total cooldown time of the spell.
		/// </summary>
		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000F950 File Offset: 0x0000ED50
		public unsafe float Cooldown
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataInst.GetTotalCooldown(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the tooltip vars of the spell.
		/// </summary>
		/// <remarks>The max count is 16.</remarks>
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0000F974 File Offset: 0x0000ED74
		public unsafe float[] TooltipVars
		{
			get
			{
				float[] array = new float[16];
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					int num = 0;
					do
					{
						float num2 = *(num * 4 + <Module>.EnsoulSharp.Native.SpellDataInst.GetToolTipVars(ptr));
						array[num] = num2;
						num++;
					}
					while (num < 16);
				}
				return array;
			}
		}

		/// <summary>
		/// 	Gets the icon used index of the spell.
		/// </summary>
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x0000F9B0 File Offset: 0x0000EDB0
		public unsafe int IconUsed
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					return (int)(*<Module>.EnsoulSharp.Native.SpellDataInst.GetIconUsed(ptr));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the name of the spell.
		/// </summary>
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x0000F9D0 File Offset: 0x0000EDD0
		public unsafe string Name
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr == null)
				{
					return "nospell";
				}
				SpellDataClient* ptr2 = *<Module>.EnsoulSharp.Native.SpellDataInstClient.GetSpellDataClient(ptr);
				if (ptr2 != null)
				{
					StlString* ptr3 = <Module>.EnsoulSharp.Native.SpellData.GetName(ptr2);
					return new string((*(ptr3 + 16) + 1 <= 16) ? ptr3 : (*ptr3));
				}
				return "nospelldata";
			}
		}

		/// <summary>
		/// 	Gets the mana cost of the spell.
		/// </summary>
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0000FA1C File Offset: 0x0000EE1C
		public unsafe float ManaCost
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr != null)
				{
					SpellDataClient* ptr2 = *<Module>.EnsoulSharp.Native.SpellDataInstClient.GetSpellDataClient(ptr);
					if (ptr2 != null)
					{
						SpellDataResource* ptr3 = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(ptr2);
						if (ptr3 != null)
						{
							int* ptr4 = <Module>.EnsoulSharp.Native.SpellDataInst.GetLevel(ptr);
							int num = Math.Max(0, Math.Min(5, *ptr4 - 1)) * 4;
							return *(<Module>.EnsoulSharp.Native.SpellDataResource.GetMana(ptr3) + num);
						}
					}
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the data of the spell.
		/// </summary>
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060004B2 RID: 1202 RVA: 0x0000FA74 File Offset: 0x0000EE74
		public unsafe SpellData SData
		{
			get
			{
				SpellDataInstClient* ptr = this.GetPtr();
				if (ptr == null)
				{
					throw new SpellDataInstNotFoundException();
				}
				SpellDataClient* ptr2 = *<Module>.EnsoulSharp.Native.SpellDataInstClient.GetSpellDataClient(ptr);
				if (ptr2 != null)
				{
					return new SpellData((SpellData*)ptr2);
				}
				throw new SpellDataNotFoundException();
			}
		}

		/// <summary>
		/// 	Gets the slot of the spell.
		/// </summary>
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x0000FAAC File Offset: 0x0000EEAC
		public SpellSlot Slot
		{
			get
			{
				return (SpellSlot)this.m_slot;
			}
		}

		/// <summary>
		/// 	Gets the state of the spell.
		/// </summary>
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x0000FAC0 File Offset: 0x0000EEC0
		public unsafe SpellState State
		{
			get
			{
				AIBaseClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetUnitByNetworkId(this.m_networkId);
				if (ptr != null)
				{
					return (SpellState)<Module>.EnsoulSharp.Native.SpellbookClient.CanUseSpell(<Module>.EnsoulSharp.Native.AIBaseCommon.GetSpellbook(ptr), (SpellSlot)this.m_slot);
				}
				return SpellState.Unknown;
			}
		}

		// Token: 0x040003B5 RID: 949
		private uint m_networkId;

		// Token: 0x040003B6 RID: 950
		private uint m_slot;
	}
}

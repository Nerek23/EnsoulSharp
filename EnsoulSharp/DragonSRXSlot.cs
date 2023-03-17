using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each dragon srx slot.
	/// </summary>
	// Token: 0x020000F0 RID: 240
	public class DragonSRXSlot
	{
		// Token: 0x06000581 RID: 1409 RVA: 0x000067F8 File Offset: 0x00005BF8
		internal unsafe DragonSRXSlot(IconSlotInfo* icon)
		{
			this.m_icon = icon;
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00006814 File Offset: 0x00005C14
		internal unsafe IconSlotInfo* GetPtr()
		{
			return this.m_icon;
		}

		/// <summary>
		/// 	Gets the id of the dragon.
		/// </summary>
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x00006828 File Offset: 0x00005C28
		public unsafe int Id
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.IconSlotInfo.GetIconId(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the team of the dragon.
		/// </summary>
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x00006844 File Offset: 0x00005C44
		public unsafe GameObjectTeam Team
		{
			get
			{
				return (GameObjectTeam)(*<Module>.EnsoulSharp.Native.IconSlotInfo.GetIconTeam(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the dragon is soul.
		/// </summary>
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x00006860 File Offset: 0x00005C60
		public unsafe bool Soul
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return *<Module>.EnsoulSharp.Native.IconSlotInfo.GetIsIconSoul(this.GetPtr()) != 0;
			}
		}

		// Token: 0x040003E2 RID: 994
		private unsafe IconSlotInfo* m_icon;
	}
}

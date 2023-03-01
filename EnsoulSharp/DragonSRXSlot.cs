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
		// Token: 0x06000576 RID: 1398 RVA: 0x00006760 File Offset: 0x00005B60
		internal unsafe DragonSRXSlot(IconSlotInfo* icon)
		{
			this.m_icon = icon;
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0000677C File Offset: 0x00005B7C
		internal unsafe IconSlotInfo* GetPtr()
		{
			return this.m_icon;
		}

		/// <summary>
		/// 	Gets the id of the dragon.
		/// </summary>
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x00006790 File Offset: 0x00005B90
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
		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x000067AC File Offset: 0x00005BAC
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
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x000067C8 File Offset: 0x00005BC8
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

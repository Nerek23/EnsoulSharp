using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to menu gui.
	/// </summary>
	// Token: 0x0200014F RID: 335
	public class MenuGUI
	{
		/// <summary>
		/// 	Gets a value indicating whether the chat is open.
		/// </summary>
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x0000CDD8 File Offset: 0x0000C1D8
		public unsafe static bool IsChatOpen
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				ChatViewController* ptr = <Module>.EnsoulSharp.Native.ChatViewController.GetInstance();
				return ptr != null && *<Module>.EnsoulSharp.Native.HudTextEdit.GetTextRegionEnabled(<Module>.EnsoulSharp.Native.ChatViewController.GetTextEdit(ptr)) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the chat is show.
		/// </summary>
		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x0000CDFC File Offset: 0x0000C1FC
		public unsafe static bool IsChatShow
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				ChatViewController* ptr = <Module>.EnsoulSharp.Native.ChatViewController.GetInstance();
				return ptr != null && *<Module>.EnsoulSharp.Native.ChatViewController.GetIsActivated(ptr) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the scoreboard is open.
		/// </summary>
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x0000CE1C File Offset: 0x0000C21C
		public unsafe static bool IsScoreboardOpen
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				ScoreboardViewController* ptr = <Module>.EnsoulSharp.Native.ScoreboardViewController.GetInstance();
				return ptr != null && *<Module>.EnsoulSharp.Native.ScoreboardViewController.GetIsShown(ptr) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the shop is open.
		/// </summary>
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x0000CE3C File Offset: 0x0000C23C
		public unsafe static bool IsShopOpen
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				AIHeroClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetPlayer();
				return ptr != null && *<Module>.EnsoulSharp.Native.HeroInventoryCommon.GetShopIsOpen(<Module>.EnsoulSharp.Native.AIHero.GetHeroInventory(ptr)) != 0;
			}
		}
	}
}

using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to menu gui.
	/// </summary>
	// Token: 0x0200014D RID: 333
	public class MenuGUI
	{
		/// <summary>
		/// 	Gets a value indicating whether the chat is open.
		/// </summary>
		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x0000CCE8 File Offset: 0x0000C0E8
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
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x0000CD0C File Offset: 0x0000C10C
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
		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x0000CD2C File Offset: 0x0000C12C
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
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x0000CD4C File Offset: 0x0000C14C
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

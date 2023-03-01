using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to hud.
	/// </summary>
	// Token: 0x0200013B RID: 315
	public class Hud
	{
		/// <summary>
		/// 	Gets the dragon srx.
		/// </summary>
		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x0000C7B0 File Offset: 0x0000BBB0
		[Obsolete("This property is unable to get data in time, it depends on hud refresh by player. Please use NeutralMinionCampClient's members instead.")]
		public unsafe static DragonSRX DragonSRX
		{
			get
			{
				ScoreboardViewController* ptr = <Module>.EnsoulSharp.Native.ScoreboardViewController.GetInstance();
				if (ptr != null)
				{
					ScoreboardTeamScoresDefinitions* ptr2 = *<Module>.EnsoulSharp.Native.ScoreboardViewController.GetTeamScoresDefinitions(ptr);
					if (ptr2 != null)
					{
						return new DragonSRX(<Module>.EnsoulSharp.Native.ScoreboardTeamScoresDefinitions.GetDragonTracker(ptr2));
					}
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the selected spell.
		/// </summary>
		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x0000C7E0 File Offset: 0x0000BBE0
		public unsafe static SpellData SelectedSpell
		{
			get
			{
				HudSpellLogic* ptr = <Module>.EnsoulSharp.Native.HudSpellLogic.GetInstance();
				if (ptr != null)
				{
					SpellDataClient* ptr2 = *<Module>.EnsoulSharp.Native.HudSpellLogic.GetSpell(ptr);
					if (ptr2 != null)
					{
						return new SpellData((SpellData*)ptr2);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether target champions only.
		/// </summary>
		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x0000C80C File Offset: 0x0000BC0C
		// (set) Token: 0x0600062E RID: 1582 RVA: 0x0000C82C File Offset: 0x0000BC2C
		public unsafe static bool TargetChampionsOnly
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				HudSelectLogic* ptr = <Module>.EnsoulSharp.Native.HudSelectLogic.GetInstance();
				return ptr != null && *<Module>.EnsoulSharp.Native.HudSelectLogic.GetTargetChampionsOnly(ptr) != 0;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				HudSelectLogic* ptr = <Module>.EnsoulSharp.Native.HudSelectLogic.GetInstance();
				if (ptr != null)
				{
					*<Module>.EnsoulSharp.Native.HudSelectLogic.GetTargetChampionsOnly(ptr) = (value ? 1 : 0);
				}
			}
		}

		/// <summary>
		/// 	Pings specific local player's bar.
		/// </summary>
		/// <param name="type">The resource type.</param>
		// Token: 0x0600062F RID: 1583 RVA: 0x0000C84C File Offset: 0x0000BC4C
		public unsafe static void PingBar(PingResourceType type)
		{
			HudPlayerResourceBars* ptr = <Module>.EnsoulSharp.Native.HudPlayerResourceBars.GetInstance();
			if (ptr != null)
			{
				<Module>.EnsoulSharp.Native.HudPlayerResourceBars.OnPing(ptr, (PingResourceType)type);
			}
		}

		/// <summary>
		/// 	Pings specific target's spell.
		/// </summary>
		/// <param name="target">The target.</param>
		/// <param name="slot">The slot.</param>
		// Token: 0x06000630 RID: 1584 RVA: 0x0000C86C File Offset: 0x0000BC6C
		public unsafe static void PingSpell(AIHeroClient target, SpellSlot slot)
		{
			HudSpellLogic* ptr = <Module>.EnsoulSharp.Native.HudSpellLogic.GetInstance();
			if (ptr != null)
			{
				<Module>.EnsoulSharp.Native.HudSpellLogic.HandleSpellPingClick(ptr, (AIHero*)target.GetPtr(), (SpellSlot)slot);
			}
		}

		/// <summary>
		/// 	Pings specific target's stat.
		/// </summary>
		/// <param name="target">The target.</param>
		/// <param name="type">The stat type.</param>
		// Token: 0x06000631 RID: 1585 RVA: 0x0000C890 File Offset: 0x0000BC90
		public unsafe static void PingStat(AIHeroClient target, PingStatType type)
		{
			HudUnitStats* ptr = <Module>.EnsoulSharp.Native.HudUnitStats.GetInstance();
			if (ptr != null)
			{
				<Module>.EnsoulSharp.Native.HudUnitStats.OnPing(ptr, (uint)target.NetworkId, (uint)type);
			}
		}

		/// <summary>
		/// 	Sets specific camera lock state.
		/// </summary>
		/// <param name="locked">A value indicating whether locked.</param>
		// Token: 0x06000632 RID: 1586 RVA: 0x0000C8B4 File Offset: 0x0000BCB4
		public unsafe static void SetCameraLockState([MarshalAs(UnmanagedType.U1)] bool locked)
		{
			ClientCameraPositionClient* ptr = <Module>.EnsoulSharp.Native.ClientCameraPositionClient.GetInstance();
			if (ptr != null)
			{
				<Module>.EnsoulSharp.Native.ClientCameraPositionClient.SetLockedInternal(ptr, locked);
			}
		}

		/// <summary>
		/// 	Shows specific click effect on specified 3D world position.
		/// </summary>
		/// <param name="type">The click type.</param>
		/// <param name="position">The 3D world click position.</param>
		// Token: 0x06000633 RID: 1587 RVA: 0x0000C8D4 File Offset: 0x0000BCD4
		public unsafe static void ShowClick(ClickType type, Vector3 position)
		{
			HudCursorTargetLogic* ptr = <Module>.EnsoulSharp.Native.HudCursorTargetLogic.GetInstance();
			if (ptr != null)
			{
				Vector3f vector3f;
				<Module>.EnsoulSharp.Native.HudCursorTargetLogic.UpdateGroundAttackMode(ptr, (ClickType)type, <Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, position.X, position.Z, position.Y));
			}
		}
	}
}

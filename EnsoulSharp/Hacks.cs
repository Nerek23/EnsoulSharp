using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to controlling basic hack features.
	/// </summary>
	// Token: 0x02000002 RID: 2
	public class Hacks
	{
		/// <summary>
		/// 	Gets or sets a value indicating whether open anti-afk.
		/// </summary>
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000259 RID: 601 RVA: 0x000010A4 File Offset: 0x000004A4
		// (set) Token: 0x0600025A RID: 602 RVA: 0x000010B8 File Offset: 0x000004B8
		public static bool AntiAFK
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.Hacks.GetAntiAFK() != null;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				<Module>.EnsoulSharp.Native.Hacks.SetAntiAFK(value);
			}
		}

		/// <summary>
		/// 	Gets or sets the anti-disconnect system's flags.
		/// </summary>
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600025B RID: 603 RVA: 0x000010CC File Offset: 0x000004CC
		// (set) Token: 0x0600025C RID: 604 RVA: 0x000010E0 File Offset: 0x000004E0
		public static AntiDisconnectFlags AntiDisconnectFlags
		{
			get
			{
				return (AntiDisconnectFlags)<Module>.EnsoulSharp.Native.Hacks.GetAntiDisconnectFlags();
			}
			set
			{
				<Module>.EnsoulSharp.Native.Hacks.SetAntiDisconnectFlags((AntiDisconnectFlags)value);
			}
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether open console.
		/// </summary>
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600025D RID: 605 RVA: 0x000010F4 File Offset: 0x000004F4
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00001108 File Offset: 0x00000508
		public static bool Console
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.Hacks.GetConsole() != null;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				<Module>.EnsoulSharp.Native.Hacks.SetConsole(value);
			}
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether disable all drawings come from scripts.
		/// </summary>
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600025F RID: 607 RVA: 0x0000111C File Offset: 0x0000051C
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00001130 File Offset: 0x00000530
		public static bool DisableDrawings
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.Hacks.GetDisableDrawings() != null;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				<Module>.EnsoulSharp.Native.Hacks.SetDisableDrawings(value);
			}
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether disable all prints come from Game.Print.
		/// </summary>
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00001144 File Offset: 0x00000544
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00001158 File Offset: 0x00000558
		public static bool DisablePrints
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.Hacks.GetDisablePrints() != null;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				<Module>.EnsoulSharp.Native.Hacks.SetDisablePrints(value);
			}
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether hide all drawings from capture.
		/// </summary>
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000116C File Offset: 0x0000056C
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00001180 File Offset: 0x00000580
		public static bool HideDrawingsFromCapture
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.Hacks.GetHideDrawingsFromCapture() != null;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				<Module>.EnsoulSharp.Native.Hacks.SetHideDrawingsFromCapture(value);
			}
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether open zoom hack.
		/// </summary>
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00001194 File Offset: 0x00000594
		// (set) Token: 0x06000266 RID: 614 RVA: 0x000011A8 File Offset: 0x000005A8
		public static bool ZoomHack
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.Hacks.GetZoomHack() != null;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				<Module>.EnsoulSharp.Native.Hacks.SetZoomHack(value);
			}
		}
	}
}

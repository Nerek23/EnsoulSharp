using System;
using EnsoulSharp.SDK.MenuUI;

namespace EnsoulSharp.SDK.Core
{
	// Token: 0x0200005F RID: 95
	internal static class Hacks
	{
		// Token: 0x060003BB RID: 955 RVA: 0x0001A468 File Offset: 0x00018668
		internal static void Initialize(Menu menu)
		{
			Hacks.Menu = menu.Add<Menu>(new Menu("Hacks", "Hacks", false));
			Hacks.Menu.Add<MenuBool>(new MenuBool("ZoomHack", "Zoom Hack", false));
			Hacks.Menu.Add<MenuBool>(new MenuBool("AntiObs", "Bypass Obs", false));
			Hacks.Menu.Add<MenuKeyBind>(new MenuKeyBind("DisableDraw", "Disable Drawing", Keys.L, KeyBindType.Toggle, false));
			Hacks.ZoomHack = Hacks.Menu["ZoomHack"].GetValue<MenuBool>().Enabled;
			Hacks.HideDrawingsFromCapture = Hacks.Menu["AntiObs"].GetValue<MenuBool>().Enabled;
			Hacks.DisableDrawings = Hacks.Menu["DisableDraw"].GetValue<MenuKeyBind>().Active;
			Hacks.Menu["ZoomHack"].GetValue<MenuBool>().ValueChanged += delegate(MenuBool menuItem, EventArgs args)
			{
				Hacks.ZoomHack = menuItem.Enabled;
			};
			Hacks.Menu["AntiObs"].GetValue<MenuBool>().ValueChanged += delegate(MenuBool menuItem, EventArgs args)
			{
				Hacks.HideDrawingsFromCapture = menuItem.Enabled;
			};
			Hacks.Menu["DisableDraw"].GetValue<MenuKeyBind>().ValueChanged += delegate(MenuKeyBind menuItem, EventArgs args)
			{
				Hacks.DisableDrawings = menuItem.Active;
			};
		}

		// Token: 0x04000202 RID: 514
		private static Menu Menu;
	}
}

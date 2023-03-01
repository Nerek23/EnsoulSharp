using System;
using System.ComponentModel.Composition;
using EnsoulSharp.SDK.Core;
using EnsoulSharp.SDK.Utils;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000AE RID: 174
	[Export(typeof(MenuWrapper))]
	public class MenuWrapper
	{
		// Token: 0x060005EF RID: 1519 RVA: 0x00028A0C File Offset: 0x00026C0C
		public MenuWrapper()
		{
			if (MenuWrapper._initialize)
			{
				return;
			}
			MenuWrapper._initialize = true;
			LanguageTranslate.Initialize();
			Menu menu = new Menu("Core", "Core", true).Attach();
			MenuCustomizer.Initialize(menu);
			PermaShow.Initialize(menu);
			Notifications.Initialize(menu);
			Hacks.Initialize(menu);
			menu.Add<MenuButton>(new MenuButton("SaveConfig", "Save Config", "Yes"));
			menu["SaveConfig"].GetValue<MenuButton>().Action = delegate()
			{
				MenuManager.Instance.SaveSettings();
			};
			TargetSelector.Initialize();
			Orbwalker.Initialize();
			Prediction.Initialize();
			HealthPrediction.Initialize();
		}

		// Token: 0x040003FD RID: 1021
		private static bool _initialize;
	}
}

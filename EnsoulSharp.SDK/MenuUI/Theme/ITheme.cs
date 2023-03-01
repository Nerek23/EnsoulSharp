using System;

namespace EnsoulSharp.SDK.MenuUI.Theme
{
	// Token: 0x020000C9 RID: 201
	internal interface ITheme
	{
		// Token: 0x060007A5 RID: 1957
		ADrawable<MenuBool> BuildBoolHandler(MenuBool component);

		// Token: 0x060007A6 RID: 1958
		ADrawable<MenuButton> BuildButtonHandler(MenuButton component);

		// Token: 0x060007A7 RID: 1959
		ADrawable<MenuColor> BuildColorHandler(MenuColor component);

		// Token: 0x060007A8 RID: 1960
		ADrawable<MenuKeyBind> BuildKeyBindHandler(MenuKeyBind component);

		// Token: 0x060007A9 RID: 1961
		ADrawable<MenuList> BuildListHandler(MenuList component);

		// Token: 0x060007AA RID: 1962
		ADrawable<Menu> BuildMenuHandler(Menu menu);

		// Token: 0x060007AB RID: 1963
		ADrawable<MenuSeparator> BuildSeparatorHandler(MenuSeparator component);

		// Token: 0x060007AC RID: 1964
		ADrawable<MenuSlider> BuildSliderHandler(MenuSlider component);

		// Token: 0x060007AD RID: 1965
		ADrawable<MenuSliderButton> BuildSliderButtonHandler(MenuSliderButton component);

		// Token: 0x060007AE RID: 1966
		void Draw();
	}
}

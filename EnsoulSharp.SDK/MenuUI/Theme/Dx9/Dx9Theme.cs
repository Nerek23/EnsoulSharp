using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Rendering;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000D5 RID: 213
	internal class Dx9Theme : ITheme
	{
		// Token: 0x0600082C RID: 2092 RVA: 0x000320DB File Offset: 0x000302DB
		public ADrawable<MenuBool> BuildBoolHandler(MenuBool component)
		{
			return new BoolTheme(component);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x000320E3 File Offset: 0x000302E3
		public ADrawable<MenuButton> BuildButtonHandler(MenuButton component)
		{
			return new ButtonTheme(component);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x000320EB File Offset: 0x000302EB
		public ADrawable<MenuColor> BuildColorHandler(MenuColor component)
		{
			return new ColorPickerTheme(component);
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x000320F3 File Offset: 0x000302F3
		public ADrawable<MenuKeyBind> BuildKeyBindHandler(MenuKeyBind component)
		{
			return new KeyBindTheme(component);
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x000320FB File Offset: 0x000302FB
		public ADrawable<MenuList> BuildListHandler(MenuList component)
		{
			return new ListTheme(component);
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x00032103 File Offset: 0x00030303
		public ADrawable<Menu> BuildMenuHandler(Menu menu)
		{
			return new MenuTheme(menu);
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0003210B File Offset: 0x0003030B
		public ADrawable<MenuSeparator> BuildSeparatorHandler(MenuSeparator component)
		{
			return new SeparatorTheme(component);
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x00032113 File Offset: 0x00030313
		public ADrawable<MenuSlider> BuildSliderHandler(MenuSlider component)
		{
			return new SliderTheme(component);
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0003211B File Offset: 0x0003031B
		public ADrawable<MenuSliderButton> BuildSliderButtonHandler(MenuSliderButton component)
		{
			return new SliderButtonTheme(component);
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00032124 File Offset: 0x00030324
		public void Draw()
		{
			Vector2 position = MenuSettings.Position;
			List<Menu> list = MenuManager.Instance.Menus.FindAll((Menu menu) => menu.Visible);
			int num = MenuSettings.ContainerHeight * list.Count;
			float width = MenuSettings.ContainerWidth;
			if (list.Count > 0)
			{
				width = (float)list.First<Menu>().MenuWidth;
			}
			RectangleRender.Draw(new Vector2(position.X, position.Y), width, (float)num, 0f, MenuSettings.RootContainerColor, MenuSettings.RootContainerColor);
			for (int i = 0; i < list.Count; i++)
			{
				Vector2 vector = new Vector2(position.X, position.Y + (float)(i * MenuSettings.ContainerHeight));
				RectangleRender.Draw(new Vector2(vector.X, vector.Y), (float)list[i].MenuWidth, (float)MenuSettings.ContainerHeight, 1f, MenuUtils.AlphaColor, MenuSettings.ContainerSeparatorColor);
				list[i].OnDraw(vector);
			}
			RectangleRender.Draw(new Vector2(position.X, position.Y), width, (float)num, 1f, MenuUtils.AlphaColor, Color.Black);
		}
	}
}

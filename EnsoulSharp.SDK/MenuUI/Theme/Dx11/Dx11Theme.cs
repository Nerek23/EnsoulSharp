using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Rendering;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx11
{
	// Token: 0x020000D9 RID: 217
	internal class Dx11Theme : ITheme
	{
		// Token: 0x0600085A RID: 2138 RVA: 0x000342B9 File Offset: 0x000324B9
		public ADrawable<MenuBool> BuildBoolHandler(MenuBool component)
		{
			return new BoolTheme(component);
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x000342C1 File Offset: 0x000324C1
		public ADrawable<MenuButton> BuildButtonHandler(MenuButton component)
		{
			return new ButtonTheme(component);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x000342C9 File Offset: 0x000324C9
		public ADrawable<MenuColor> BuildColorHandler(MenuColor component)
		{
			return new ColorPickerTheme(component);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x000342D1 File Offset: 0x000324D1
		public ADrawable<MenuKeyBind> BuildKeyBindHandler(MenuKeyBind component)
		{
			return new KeyBindTheme(component);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x000342D9 File Offset: 0x000324D9
		public ADrawable<MenuList> BuildListHandler(MenuList component)
		{
			return new ListTheme(component);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x000342E1 File Offset: 0x000324E1
		public ADrawable<Menu> BuildMenuHandler(Menu menu)
		{
			return new MenuTheme(menu);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x000342E9 File Offset: 0x000324E9
		public ADrawable<MenuSeparator> BuildSeparatorHandler(MenuSeparator component)
		{
			return new SeparatorTheme(component);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x000342F1 File Offset: 0x000324F1
		public ADrawable<MenuSlider> BuildSliderHandler(MenuSlider component)
		{
			return new SliderTheme(component);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x000342F9 File Offset: 0x000324F9
		public ADrawable<MenuSliderButton> BuildSliderButtonHandler(MenuSliderButton component)
		{
			return new SliderButtonTheme(component);
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x00034304 File Offset: 0x00032504
		public void Draw()
		{
			Vector2 position = MenuSettings.Position;
			List<Menu> list = MenuManager.Instance.Menus.FindAll((Menu menu) => menu.Visible);
			int num = MenuSettings.ContainerHeight * list.Count;
			float num2 = MenuSettings.ContainerWidth;
			if (list.Count > 0)
			{
				num2 = (float)list.First<Menu>().MenuWidth;
			}
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(position.X + num2 / 2f, position.Y),
				new Vector2(position.X + num2 / 2f, position.Y + (float)num)
			}, MenuSettings.RootContainerColor, num2);
			for (int i = 0; i < list.Count; i++)
			{
				Vector2 vector = new Vector2(position.X, position.Y + (float)(i * MenuSettings.ContainerHeight));
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2(vector.X, vector.Y + (float)MenuSettings.ContainerHeight),
					new Vector2(vector.X + (float)list[i].MenuWidth, vector.Y + (float)MenuSettings.ContainerHeight)
				}, MenuSettings.ContainerSeparatorColor, 1f);
				list[i].OnDraw(vector);
			}
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(position.X, position.Y),
				new Vector2(position.X + num2, position.Y),
				new Vector2(position.X + num2, position.Y + (float)num),
				new Vector2(position.X, position.Y + (float)num),
				new Vector2(position.X, position.Y)
			}, Color.Black, 1f);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000D1 RID: 209
	internal class MenuTheme : ADrawable<Menu>
	{
		// Token: 0x06000807 RID: 2055 RVA: 0x000308B8 File Offset: 0x0002EAB8
		public MenuTheme(Menu component) : base(component)
		{
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x000308C1 File Offset: 0x0002EAC1
		public override void Dispose()
		{
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x000308C4 File Offset: 0x0002EAC4
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 position = base.Component.Position;
			List<AMenuComponent> list = (from x in base.Component.Components
			where x.Value.Visible
			select x.Value).ToList<AMenuComponent>();
			if (this.hovering && !base.Component.Toggled && list.Count > 0)
			{
				RectangleRender.Draw(new Vector2(position.X, position.Y), (float)base.Component.MenuWidth, (float)MenuSettings.ContainerHeight, 0f, MenuSettings.HoverColor, MenuSettings.HoverColor);
			}
			int num = base.Component.HaveLogo ? (MenuSettings.ContainerHeight + 5) : 0;
			int y = (int)ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter).Y;
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(position.X + (float)num + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
			MenuSettings.Font.Draw("»", (int)(position.X + (float)base.Component.MenuWidth - MenuSettings.ContainerTextMarkWidth - MenuSettings.ContainerTextMarkOffset), y, (list.Count > 0) ? MenuSettings.TextColor : MenuSettings.ContainerSeparatorColor, MenuManager.Instance.Sprite);
			if (base.Component.Toggled)
			{
				RectangleRender.Draw(new Vector2(position.X, position.Y), (float)base.Component.MenuWidth, (float)MenuSettings.ContainerHeight, 0f, MenuSettings.ContainerSelectedColor, MenuSettings.ContainerSelectedColor);
				float height = (float)(MenuSettings.ContainerHeight * list.Count);
				float width = MenuSettings.ContainerWidth;
				if (list.Count > 0)
				{
					width = (float)list.First<AMenuComponent>().MenuWidth;
				}
				RectangleRender.Draw(new Vector2(position.X + (float)base.Component.MenuWidth, position.Y), width, height, 0f, MenuSettings.RootContainerColor, MenuSettings.RootContainerColor);
				for (int i = 0; i < list.Count; i++)
				{
					AMenuComponent amenuComponent = list[i];
					if (amenuComponent != null)
					{
						Vector2 vector = new Vector2(position.X + (float)base.Component.MenuWidth, position.Y + (float)(i * MenuSettings.ContainerHeight));
						RectangleRender.Draw(new Vector2(vector.X, vector.Y), (float)amenuComponent.MenuWidth, (float)MenuSettings.ContainerHeight, 1f, MenuUtils.AlphaColor, MenuSettings.ContainerSeparatorColor);
						amenuComponent.OnDraw(vector);
					}
				}
				RectangleRender.Draw(new Vector2(position.X + (float)base.Component.MenuWidth, position.Y), width, height, 1f, MenuUtils.AlphaColor, Color.Black);
			}
			if (base.Component.HaveLogo)
			{
				SpriteCache menuLogo = base.Component.MenuLogo;
				if (menuLogo != null)
				{
					float num2 = (float)MenuSettings.ContainerHeight * 0.1f;
					menuLogo.Draw(position.X + MenuSettings.ContainerTextOffset, position.Y + num2);
				}
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00030C68 File Offset: 0x0002EE68
		public override void OnWndProc(SingleMouseEventArgs args)
		{
			if (!base.Component.ToggleVisible)
			{
				return;
			}
			if (args.Cursor.IsUnderRectangle(base.Component.Position.X, base.Component.Position.Y, (float)base.Component.MenuWidth, (float)MenuSettings.ContainerHeight))
			{
				this.hovering = true;
				if (args.Type == SingleMouseType.MouseUp && args.Key == SingleMouseKey.LeftClick)
				{
					base.Component.Toggle();
					return;
				}
			}
			else
			{
				this.hovering = false;
			}
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00030CF0 File Offset: 0x0002EEF0
		public override void OnWndProc(WindowsKeys args)
		{
			if (!base.Component.ToggleVisible)
			{
				return;
			}
			if (!Library.GameCache.IsRiot)
			{
				return;
			}
			if (args.Cursor.IsUnderRectangle(base.Component.Position.X, base.Component.Position.Y, (float)base.Component.MenuWidth, (float)MenuSettings.ContainerHeight))
			{
				this.hovering = true;
				if (args.Msg == WindowsKeyMessages.LBUTTONUP)
				{
					base.Component.Toggle();
					return;
				}
			}
			else
			{
				this.hovering = false;
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00030D80 File Offset: 0x0002EF80
		public override int Width()
		{
			return (int)((float)ThemeUtilities.MeasureString(base.Component.DisplayName + " »").Width + MenuSettings.ContainerTextOffset * 2f + MenuSettings.ContainerTextMarkWidth) + 5 + (base.Component.HaveLogo ? (MenuSettings.ContainerHeight + 5) : 0);
		}

		// Token: 0x0400059E RID: 1438
		private bool hovering;
	}
}

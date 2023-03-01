using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx11
{
	// Token: 0x020000DC RID: 220
	internal class MenuTheme : ADrawable<Menu>
	{
		// Token: 0x0600087B RID: 2171 RVA: 0x00035BAC File Offset: 0x00033DAC
		public MenuTheme(Menu component) : base(component)
		{
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00035BB5 File Offset: 0x00033DB5
		public override void Dispose()
		{
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00035BB8 File Offset: 0x00033DB8
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
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2(position.X, position.Y + (float)MenuSettings.ContainerHeight / 2f),
					new Vector2(position.X + (float)base.Component.MenuWidth, position.Y + (float)MenuSettings.ContainerHeight / 2f)
				}, MenuSettings.HoverColor, (float)MenuSettings.ContainerHeight);
			}
			int num = base.Component.HaveLogo ? (MenuSettings.ContainerHeight + 5) : 0;
			int y = (int)ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter).Y;
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(position.X + (float)num + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, null);
			MenuSettings.Font.Draw("»", (int)(position.X + (float)base.Component.MenuWidth - MenuSettings.ContainerTextMarkWidth - MenuSettings.ContainerTextMarkOffset), y, (list.Count > 0) ? MenuSettings.TextColor : MenuSettings.ContainerSeparatorColor, null);
			if (base.Component.Toggled)
			{
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2(position.X + (float)base.Component.MenuWidth / 2f, position.Y),
					new Vector2(position.X + (float)base.Component.MenuWidth / 2f, position.Y + (float)MenuSettings.ContainerHeight)
				}, MenuSettings.ContainerSelectedColor, (float)base.Component.MenuWidth);
				float num2 = (float)(MenuSettings.ContainerHeight * list.Count);
				float num3 = MenuSettings.ContainerWidth;
				if (list.Count > 0)
				{
					num3 = (float)list.First<AMenuComponent>().MenuWidth;
				}
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2(position.X + (float)base.Component.MenuWidth + num3 / 2f, position.Y),
					new Vector2(position.X + (float)base.Component.MenuWidth + num3 / 2f, position.Y + num2)
				}, MenuSettings.RootContainerColor, num3);
				for (int i = 0; i < list.Count; i++)
				{
					AMenuComponent amenuComponent = list[i];
					if (amenuComponent != null)
					{
						Vector2 vector = new Vector2(position.X + (float)base.Component.MenuWidth, position.Y + (float)(i * MenuSettings.ContainerHeight));
						ThemeUtilities.Line.Draw(new Vector2[]
						{
							new Vector2(vector.X, vector.Y + (float)MenuSettings.ContainerHeight),
							new Vector2(vector.X + (float)amenuComponent.MenuWidth, vector.Y + (float)MenuSettings.ContainerHeight)
						}, MenuSettings.ContainerSeparatorColor, 1f);
						amenuComponent.OnDraw(vector);
					}
				}
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2(position.X + (float)base.Component.MenuWidth, position.Y),
					new Vector2(position.X + (float)base.Component.MenuWidth + num3, position.Y)
				}, Color.Black, 1f);
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2(position.X + (float)base.Component.MenuWidth, position.Y + num2),
					new Vector2(position.X + (float)base.Component.MenuWidth + num3, position.Y + num2)
				}, Color.Black, 1f);
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2(position.X + (float)base.Component.MenuWidth, position.Y),
					new Vector2(position.X + (float)base.Component.MenuWidth, position.Y + num2)
				}, Color.Black, 1f);
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2(position.X + (float)base.Component.MenuWidth + num3, position.Y),
					new Vector2(position.X + (float)base.Component.MenuWidth + num3, position.Y + num2)
				}, Color.Black, 1f);
			}
			if (base.Component.HaveLogo)
			{
				SpriteCache menuLogo = base.Component.MenuLogo;
				if (menuLogo != null)
				{
					float num4 = (float)MenuSettings.ContainerHeight * 0.1f;
					menuLogo.Draw(position.X + MenuSettings.ContainerTextOffset, position.Y + num4);
				}
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x000361A0 File Offset: 0x000343A0
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

		// Token: 0x0600087F RID: 2175 RVA: 0x00036228 File Offset: 0x00034428
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

		// Token: 0x06000880 RID: 2176 RVA: 0x000362B8 File Offset: 0x000344B8
		public override int Width()
		{
			return (int)((float)ThemeUtilities.MeasureString(base.Component.DisplayName + " »").Width + MenuSettings.ContainerTextOffset * 2f + MenuSettings.ContainerTextMarkWidth) + 5 + (base.Component.HaveLogo ? (MenuSettings.ContainerHeight + 5) : 0);
		}

		// Token: 0x040005AF RID: 1455
		private bool hovering;
	}
}

using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000CD RID: 205
	internal class ButtonTheme : ADrawable<MenuButton>
	{
		// Token: 0x060007D7 RID: 2007 RVA: 0x0002DDD6 File Offset: 0x0002BFD6
		public ButtonTheme(MenuButton component) : base(component)
		{
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0002DE14 File Offset: 0x0002C014
		public Rectangle ButtonBoundaries(MenuButton component)
		{
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(MenuManager.Instance.Sprite, component.ButtonText, FontCache.DrawFontFlags.Left);
			int num = rawRectangle.Right - rawRectangle.Left;
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)num - 10f), (int)component.Position.Y, 10 + num, MenuSettings.ContainerHeight);
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0002DE82 File Offset: 0x0002C082
		public Rectangle GetFullRectangle(MenuButton component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0002DEB8 File Offset: 0x0002C0B8
		public int GetToolTipWidth(MenuButton component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0002DEC6 File Offset: 0x0002C0C6
		public Rectangle GetTooltipRectangle(MenuButton component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0002DEF9 File Offset: 0x0002C0F9
		public override void Dispose()
		{
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0002DEFC File Offset: 0x0002C0FC
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 centeredText = ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter);
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(base.Component.Position.X + MenuSettings.ContainerTextOffset), (int)centeredText.Y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(MenuManager.Instance.Sprite, base.Component.ButtonText, FontCache.DrawFontFlags.Left);
			int num = rawRectangle.Right - rawRectangle.Left;
			RectangleRender.Draw(new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)num - 10f + 2f, base.Component.Position.Y + 1f), (float)num + 5f, (float)MenuSettings.ContainerHeight, 0f, base.Component.Active ? this.buttonHoverColor : this.buttonColor, base.Component.Active ? this.buttonHoverColor : this.buttonColor);
			MenuSettings.Font.Draw(base.Component.ButtonText, (int)(base.Component.Position.X + (float)base.Component.MenuWidth - (float)num - 5f), (int)centeredText.Y, MenuSettings.TextColor, MenuManager.Instance.Sprite);
			if (base.Component.DrawTooltip)
			{
				Rectangle tooltipRectangle = this.GetTooltipRectangle(base.Component);
				int y = (int)tooltipRectangle.GetCenteredText(MenuSettings.Font, base.Component.Tooltip, CenteredFlags.VerticalCenter).Y;
				MenuSettings.Font.Draw(base.Component.Tooltip, (int)((float)tooltipRectangle.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuSettings.RootContainerColor, MenuSettings.RootContainerColor);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuUtils.AlphaColor, Color.Black);
			}
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0002E1D4 File Offset: 0x0002C3D4
		public override void OnWndProc(SingleMouseEventArgs args)
		{
			if (!base.Component.ToggleVisible)
			{
				return;
			}
			if (!Library.GameCache.IsRiot && args.Type == SingleMouseType.MouseMove && !string.IsNullOrEmpty(base.Component.Tooltip))
			{
				Rectangle fullRectangle = this.GetFullRectangle(base.Component);
				base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
			}
			Rectangle rectangle = this.ButtonBoundaries(base.Component);
			if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
			{
				base.Component.Active = true;
				if (args.Key == SingleMouseKey.LeftClick && args.Type == SingleMouseType.MouseDown)
				{
					MenuButton.ButtonAction action = base.Component.Action;
					if (action == null)
					{
						return;
					}
					action();
					return;
				}
			}
			else
			{
				base.Component.Active = false;
			}
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0002E2D4 File Offset: 0x0002C4D4
		public override void OnWndProc(WindowsKeys args)
		{
			if (!base.Component.ToggleVisible)
			{
				return;
			}
			if (args.Msg == WindowsKeyMessages.MOUSEFIRST && !string.IsNullOrEmpty(base.Component.Tooltip))
			{
				Rectangle fullRectangle = this.GetFullRectangle(base.Component);
				base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
			}
			if (Library.GameCache.IsRiot)
			{
				Rectangle rectangle = this.ButtonBoundaries(base.Component);
				if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
				{
					base.Component.Active = true;
					if (args.Msg == WindowsKeyMessages.LBUTTONDOWN)
					{
						MenuButton.ButtonAction action = base.Component.Action;
						if (action == null)
						{
							return;
						}
						action();
						return;
					}
				}
				else
				{
					base.Component.Active = false;
				}
			}
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0002E3D4 File Offset: 0x0002C5D4
		public override int Width()
		{
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(MenuManager.Instance.Sprite, base.Component.ButtonText, FontCache.DrawFontFlags.Left);
			return ThemeUtilities.CalcWidthItem(base.Component) + 10 + (rawRectangle.Right - rawRectangle.Left);
		}

		// Token: 0x0400058D RID: 1421
		private const int TextGap = 5;

		// Token: 0x0400058E RID: 1422
		private readonly ColorBGRA buttonColor = new ColorBGRA(100, 100, 100, byte.MaxValue);

		// Token: 0x0400058F RID: 1423
		private readonly ColorBGRA buttonHoverColor = new ColorBGRA(170, 170, 170, 200);
	}
}

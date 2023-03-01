using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx11
{
	// Token: 0x020000D7 RID: 215
	internal class ButtonTheme : ADrawable<MenuButton>
	{
		// Token: 0x06000841 RID: 2113 RVA: 0x00032932 File Offset: 0x00030B32
		public ButtonTheme(MenuButton component) : base(component)
		{
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00032970 File Offset: 0x00030B70
		public Rectangle ButtonBoundaries(MenuButton component)
		{
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(component.ButtonText, FontCache.DrawFontFlags.Left);
			int num = rawRectangle.Right - rawRectangle.Left;
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)num - 10f), (int)component.Position.Y, 10 + num, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x000329D4 File Offset: 0x00030BD4
		public Rectangle GetFullRectangle(MenuButton component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00032A0A File Offset: 0x00030C0A
		public int GetToolTipWidth(MenuButton component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x00032A18 File Offset: 0x00030C18
		public Rectangle GetTooltipRectangle(MenuButton component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00032A4B File Offset: 0x00030C4B
		public override void Dispose()
		{
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00032A50 File Offset: 0x00030C50
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 centeredText = ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter);
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(base.Component.Position.X + MenuSettings.ContainerTextOffset), (int)centeredText.Y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, null);
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(base.Component.ButtonText, FontCache.DrawFontFlags.Left);
			int num = rawRectangle.Right - rawRectangle.Left;
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)num - 10f, base.Component.Position.Y + (float)MenuSettings.ContainerHeight / 2f),
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth, base.Component.Position.Y + (float)MenuSettings.ContainerHeight / 2f)
			}, MenuSettings.HoverColor, (float)MenuSettings.ContainerHeight);
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)num - 10f + 2f, base.Component.Position.Y + (float)MenuSettings.ContainerHeight / 2f),
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - 2f, base.Component.Position.Y + (float)MenuSettings.ContainerHeight / 2f)
			}, base.Component.Active ? this.buttonHoverColor : this.buttonColor, (float)MenuSettings.ContainerHeight - 5f);
			MenuSettings.Font.Draw(base.Component.ButtonText, (int)(base.Component.Position.X + (float)base.Component.MenuWidth - (float)num - 5f), (int)centeredText.Y, MenuSettings.TextColor, null);
			if (base.Component.DrawTooltip)
			{
				Rectangle tooltipRectangle = this.GetTooltipRectangle(base.Component);
				int y = (int)tooltipRectangle.GetCenteredText(MenuSettings.Font, base.Component.Tooltip, CenteredFlags.VerticalCenter).Y;
				MenuSettings.Font.Draw(base.Component.Tooltip, (int)((float)tooltipRectangle.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, null);
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2((float)tooltipRectangle.X + (float)tooltipRectangle.Width / 2f, (float)tooltipRectangle.Y),
					new Vector2((float)(tooltipRectangle.X + tooltipRectangle.Width / 2), (float)(tooltipRectangle.Y + tooltipRectangle.Height))
				}, MenuSettings.RootContainerColor, (float)tooltipRectangle.Width);
				ThemeUtilities.Line.Draw(new Vector2[]
				{
					new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y),
					new Vector2((float)(tooltipRectangle.X + tooltipRectangle.Width), (float)tooltipRectangle.Y),
					new Vector2((float)(tooltipRectangle.X + tooltipRectangle.Width), (float)(tooltipRectangle.Y + tooltipRectangle.Height)),
					new Vector2((float)tooltipRectangle.X, (float)(tooltipRectangle.Y + tooltipRectangle.Height)),
					new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y)
				}, Color.Black, 1f);
			}
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00032EB4 File Offset: 0x000310B4
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

		// Token: 0x06000849 RID: 2121 RVA: 0x00032FB4 File Offset: 0x000311B4
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

		// Token: 0x0600084A RID: 2122 RVA: 0x000330B4 File Offset: 0x000312B4
		public override int Width()
		{
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(base.Component.ButtonText, FontCache.DrawFontFlags.Left);
			return ThemeUtilities.CalcWidthItem(base.Component) + 10 + (rawRectangle.Right - rawRectangle.Left);
		}

		// Token: 0x0400059F RID: 1439
		private readonly ColorBGRA buttonColor = new ColorBGRA(100, 100, 100, byte.MaxValue);

		// Token: 0x040005A0 RID: 1440
		private readonly ColorBGRA buttonHoverColor = new ColorBGRA(170, 170, 170, 200);
	}
}

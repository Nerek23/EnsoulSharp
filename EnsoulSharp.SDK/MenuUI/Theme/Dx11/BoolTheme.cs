using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx11
{
	// Token: 0x020000D6 RID: 214
	internal class BoolTheme : ADrawable<MenuBool>
	{
		// Token: 0x06000837 RID: 2103 RVA: 0x0003227F File Offset: 0x0003047F
		public BoolTheme(MenuBool component) : base(component)
		{
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00032288 File Offset: 0x00030488
		public Rectangle ButtonBoundaries(MenuBool component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x000322C0 File Offset: 0x000304C0
		public Rectangle GetFullRectangle(MenuBool component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x000322F6 File Offset: 0x000304F6
		public int GetToolTipWidth(MenuBool component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x00032304 File Offset: 0x00030504
		public Rectangle GetTooltipRectangle(MenuBool component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00032337 File Offset: 0x00030537
		public override void Dispose()
		{
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0003233C File Offset: 0x0003053C
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			int y = (int)ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter).Y;
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(base.Component.Position.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, null);
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight + (float)MenuSettings.ContainerHeight / 2f, base.Component.Position.Y + 1f),
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight + (float)MenuSettings.ContainerHeight / 2f, base.Component.Position.Y + (float)MenuSettings.ContainerHeight)
			}, base.Component.Enabled ? new ColorBGRA(0, 100, 0, byte.MaxValue) : new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue), (float)MenuSettings.ContainerHeight);
			int x = (int)new Rectangle((int)(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)base.Component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight).GetCenteredText(MenuSettings.Font, base.Component.Enabled ? LanguageTranslate.GetOnTranslation() : LanguageTranslate.GetOffTranslation(), CenteredFlags.HorizontalCenter).X;
			MenuSettings.Font.Draw(base.Component.Enabled ? LanguageTranslate.GetOnTranslation() : LanguageTranslate.GetOffTranslation(), x, y, MenuSettings.TextColor, null);
			if (base.Component.DrawTooltip)
			{
				Rectangle tooltipRectangle = this.GetTooltipRectangle(base.Component);
				int y2 = (int)tooltipRectangle.GetCenteredText(MenuSettings.Font, base.Component.Tooltip, CenteredFlags.VerticalCenter).Y;
				MenuSettings.Font.Draw(base.Component.Tooltip, (int)((float)tooltipRectangle.X + MenuSettings.ContainerTextOffset), y2, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, null);
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

		// Token: 0x0600083E RID: 2110 RVA: 0x0003272C File Offset: 0x0003092C
		public override void OnWndProc(SingleMouseEventArgs args)
		{
			if (!base.Component.ToggleVisible)
			{
				return;
			}
			if (args.Type == SingleMouseType.MouseMove && !string.IsNullOrEmpty(base.Component.Tooltip))
			{
				Rectangle fullRectangle = this.GetFullRectangle(base.Component);
				base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
			}
			if (args.Key == SingleMouseKey.LeftClick && args.Type == SingleMouseType.MouseDown)
			{
				Rectangle rectangle = this.ButtonBoundaries(base.Component);
				if (Cursor.Position.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
				{
					base.Component.Enabled = !base.Component.Enabled;
					base.Component.FireEvent();
					base.Component.Save();
				}
			}
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x00032820 File Offset: 0x00030A20
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
			if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.LBUTTONDOWN)
			{
				Rectangle rectangle = this.ButtonBoundaries(base.Component);
				if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
				{
					base.Component.Enabled = !base.Component.Enabled;
					base.Component.FireEvent();
					base.Component.Save();
				}
			}
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x0003291F File Offset: 0x00030B1F
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + MenuSettings.ContainerHeight;
		}
	}
}

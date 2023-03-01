using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000CC RID: 204
	internal class BoolTheme : ADrawable<MenuBool>
	{
		// Token: 0x060007CD RID: 1997 RVA: 0x0002D7FF File Offset: 0x0002B9FF
		public BoolTheme(MenuBool component) : base(component)
		{
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0002D808 File Offset: 0x0002BA08
		public Rectangle ButtonBoundaries(MenuBool component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x0002D840 File Offset: 0x0002BA40
		public Rectangle GetFullRectangle(MenuBool component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0002D876 File Offset: 0x0002BA76
		public int GetToolTipWidth(MenuBool component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0002D884 File Offset: 0x0002BA84
		public Rectangle GetTooltipRectangle(MenuBool component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0002D8B7 File Offset: 0x0002BAB7
		public override void Dispose()
		{
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0002D8BC File Offset: 0x0002BABC
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			int y = (int)ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter).Y;
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(base.Component.Position.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
			RectangleRender.Draw(new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight, base.Component.Position.Y), (float)(MenuSettings.ContainerHeight - 2), (float)(MenuSettings.ContainerHeight - 1), 0f, base.Component.Enabled ? new ColorBGRA(0, 100, 0, byte.MaxValue) : new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue), base.Component.Enabled ? new ColorBGRA(0, 100, 0, byte.MaxValue) : new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue));
			int x = (int)new Rectangle((int)(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)base.Component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight).GetCenteredText(MenuSettings.Font, base.Component.Enabled ? LanguageTranslate.GetOnTranslation() : LanguageTranslate.GetOffTranslation(), CenteredFlags.HorizontalCenter).X;
			MenuSettings.Font.Draw(base.Component.Enabled ? LanguageTranslate.GetOnTranslation() : LanguageTranslate.GetOffTranslation(), x, y, MenuSettings.TextColor, MenuManager.Instance.Sprite);
			if (base.Component.DrawTooltip)
			{
				Rectangle tooltipRectangle = this.GetTooltipRectangle(base.Component);
				int y2 = (int)tooltipRectangle.GetCenteredText(MenuSettings.Font, base.Component.Tooltip, CenteredFlags.VerticalCenter).Y;
				MenuSettings.Font.Draw(base.Component.Tooltip, (int)((float)tooltipRectangle.X + MenuSettings.ContainerTextOffset), y2, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuSettings.RootContainerColor, MenuSettings.RootContainerColor);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuUtils.AlphaColor, Color.Black);
			}
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0002DBD0 File Offset: 0x0002BDD0
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

		// Token: 0x060007D5 RID: 2005 RVA: 0x0002DCC4 File Offset: 0x0002BEC4
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

		// Token: 0x060007D6 RID: 2006 RVA: 0x0002DDC3 File Offset: 0x0002BFC3
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + MenuSettings.ContainerHeight;
		}
	}
}

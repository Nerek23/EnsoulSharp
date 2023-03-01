using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000D2 RID: 210
	internal class SeparatorTheme : ADrawable<MenuSeparator>
	{
		// Token: 0x0600080D RID: 2061 RVA: 0x00030DDD File Offset: 0x0002EFDD
		public SeparatorTheme(MenuSeparator component) : base(component)
		{
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00030DE6 File Offset: 0x0002EFE6
		public Rectangle GetFullRectangle(MenuSeparator component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x00030E1C File Offset: 0x0002F01C
		public int GetToolTipWidth(MenuSeparator component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00030E2A File Offset: 0x0002F02A
		public Rectangle GetTooltipRectangle(MenuSeparator component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00030E5D File Offset: 0x0002F05D
		public override void Dispose()
		{
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00030E60 File Offset: 0x0002F060
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 centeredText = ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.HorizontalCenter | CenteredFlags.VerticalCenter);
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)centeredText.X, (int)centeredText.Y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
			if (base.Component.DrawTooltip)
			{
				Rectangle tooltipRectangle = this.GetTooltipRectangle(base.Component);
				int y = (int)tooltipRectangle.GetCenteredText(MenuSettings.Font, base.Component.Tooltip, CenteredFlags.VerticalCenter).Y;
				MenuSettings.Font.Draw(base.Component.Tooltip, (int)((float)tooltipRectangle.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuSettings.RootContainerColor, MenuSettings.RootContainerColor);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuUtils.AlphaColor, Color.Black);
			}
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00031000 File Offset: 0x0002F200
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
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0003107C File Offset: 0x0002F27C
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
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x000310F9 File Offset: 0x0002F2F9
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component);
		}
	}
}

using System;
using System.Globalization;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000D4 RID: 212
	internal class SliderButtonTheme : ADrawable<MenuSliderButton>
	{
		// Token: 0x06000821 RID: 2081 RVA: 0x000317E1 File Offset: 0x0002F9E1
		public SliderButtonTheme(MenuSliderButton component) : base(component)
		{
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x000317EA File Offset: 0x0002F9EA
		public Rectangle SliderBoundaries(MenuSliderButton component)
		{
			return new Rectangle((int)component.Position.X, (int)component.Position.Y, component.MenuWidth - MenuSettings.ContainerHeight, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0003181A File Offset: 0x0002FA1A
		public Rectangle ButtonBoundaries(MenuSliderButton component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00031852 File Offset: 0x0002FA52
		public Rectangle GetFullRectangle(MenuSliderButton component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00031888 File Offset: 0x0002FA88
		public int GetToolTipWidth(MenuSliderButton component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00031896 File Offset: 0x0002FA96
		public Rectangle GetTooltipRectangle(MenuSliderButton component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x000318C9 File Offset: 0x0002FAC9
		public override void Dispose()
		{
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x000318CC File Offset: 0x0002FACC
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 position = base.Component.Position;
			int y = (int)ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter).Y;
			float num = (float)(base.Component.Value - base.Component.MinValue) / (float)(base.Component.MaxValue - base.Component.MinValue);
			float num2 = position.X + num * (float)(base.Component.MenuWidth - MenuSettings.ContainerHeight);
			RectangleRender.Draw(new Vector2(num2, position.Y), 2f, (float)MenuSettings.ContainerHeight, 0f, base.Component.Interacting ? new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue) : new ColorBGRA(50, 154, 205, byte.MaxValue), base.Component.Interacting ? new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue) : new ColorBGRA(50, 154, 205, byte.MaxValue));
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(position.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(base.Component.Value.ToString(CultureInfo.InvariantCulture), FontCache.DrawFontFlags.Left);
			MenuSettings.Font.Draw(base.Component.Value.ToString(CultureInfo.InvariantCulture), (int)(position.X + (float)base.Component.MenuWidth - 5f - (float)(rawRectangle.Right - rawRectangle.Left) - (float)MenuSettings.ContainerHeight), y, MenuSettings.TextColor, MenuManager.Instance.Sprite);
			RectangleRender.Draw(new Vector2(position.X, position.Y), num2 - position.X, (float)MenuSettings.ContainerHeight, 0f, MenuSettings.HoverColor, MenuSettings.HoverColor);
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

		// Token: 0x06000829 RID: 2089 RVA: 0x00031D98 File Offset: 0x0002FF98
		public override void OnWndProc(SingleMouseEventArgs args)
		{
			if (!base.Component.ToggleVisible)
			{
				return;
			}
			if (args.Key != SingleMouseKey.LeftClick)
			{
				return;
			}
			if (args.Type == SingleMouseType.MouseDown)
			{
				Rectangle rectangle = this.ButtonBoundaries(base.Component);
				if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
				{
					base.Component.Enabled = !base.Component.Enabled;
					base.Component.FireEvent();
					base.Component.Save();
				}
				if (!base.Component.Interacting)
				{
					Rectangle rectangle2 = this.SliderBoundaries(base.Component);
					if (args.Cursor.IsUnderRectangle((float)rectangle2.X, (float)rectangle2.Y, (float)rectangle2.Width, (float)rectangle2.Height))
					{
						base.Component.Interacting = true;
						ThemeUtilities.CalculateNewValue(base.Component, args);
						return;
					}
				}
			}
			else
			{
				if (args.Type == SingleMouseType.MouseUp)
				{
					base.Component.Interacting = false;
					return;
				}
				if (args.Type == SingleMouseType.MouseMove)
				{
					if (base.Component.Interacting)
					{
						ThemeUtilities.CalculateNewValue(base.Component, args);
					}
					if (!string.IsNullOrEmpty(base.Component.Tooltip))
					{
						Rectangle fullRectangle = this.GetFullRectangle(base.Component);
						base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
					}
				}
			}
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00031F24 File Offset: 0x00030124
		public override void OnWndProc(WindowsKeys args)
		{
			if (!base.Component.ToggleVisible)
			{
				return;
			}
			if (args.Msg == WindowsKeyMessages.MOUSEFIRST)
			{
				if (base.Component.Interacting)
				{
					ThemeUtilities.CalculateNewValue(base.Component, args);
				}
				if (!string.IsNullOrEmpty(base.Component.Tooltip))
				{
					Rectangle fullRectangle = this.GetFullRectangle(base.Component);
					base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
					return;
				}
			}
			else if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.LBUTTONDOWN)
			{
				Rectangle rectangle = this.ButtonBoundaries(base.Component);
				if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
				{
					base.Component.Enabled = !base.Component.Enabled;
					base.Component.FireEvent();
					base.Component.Save();
				}
				if (!base.Component.Interacting)
				{
					Rectangle rectangle2 = this.SliderBoundaries(base.Component);
					if (args.Cursor.IsUnderRectangle((float)rectangle2.X, (float)rectangle2.Y, (float)rectangle2.Width, (float)rectangle2.Height))
					{
						base.Component.Interacting = true;
						ThemeUtilities.CalculateNewValue(base.Component, args);
						return;
					}
				}
			}
			else if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.LBUTTONUP)
			{
				base.Component.Interacting = false;
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x000320CB File Offset: 0x000302CB
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + 100;
		}
	}
}

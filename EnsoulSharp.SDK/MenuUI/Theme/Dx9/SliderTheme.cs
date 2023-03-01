using System;
using System.Globalization;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000D3 RID: 211
	internal class SliderTheme : ADrawable<MenuSlider>
	{
		// Token: 0x06000816 RID: 2070 RVA: 0x00031106 File Offset: 0x0002F306
		public SliderTheme(MenuSlider component) : base(component)
		{
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0003110F File Offset: 0x0002F30F
		public Rectangle Bounding(MenuSlider component)
		{
			return ThemeUtilities.GetContainerRectangle(component);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00031117 File Offset: 0x0002F317
		public Rectangle GetFullRectangle(MenuSlider component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0003114D File Offset: 0x0002F34D
		public int GetToolTipWidth(MenuSlider component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0003115B File Offset: 0x0002F35B
		public Rectangle GetTooltipRectangle(MenuSlider component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0003118E File Offset: 0x0002F38E
		public override void Dispose()
		{
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00031190 File Offset: 0x0002F390
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 position = base.Component.Position;
			int y = (int)ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter).Y;
			float num = (float)(base.Component.Value - base.Component.MinValue) / (float)(base.Component.MaxValue - base.Component.MinValue);
			float num2 = position.X + num * (float)base.Component.MenuWidth;
			RectangleRender.Draw(new Vector2(num2, position.Y), 2f, (float)MenuSettings.ContainerHeight, 0f, base.Component.Interacting ? new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue) : new ColorBGRA(50, 154, 205, byte.MaxValue), base.Component.Interacting ? new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue) : new ColorBGRA(50, 154, 205, byte.MaxValue));
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(position.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(base.Component.Value.ToString(CultureInfo.InvariantCulture), FontCache.DrawFontFlags.Left);
			MenuSettings.Font.Draw(base.Component.Value.ToString(CultureInfo.InvariantCulture), (int)(position.X + (float)base.Component.MenuWidth - 5f - (float)(rawRectangle.Right - rawRectangle.Left)), y, MenuSettings.TextColor, MenuManager.Instance.Sprite);
			RectangleRender.Draw(new Vector2(position.X, position.Y), num2 - position.X, (float)MenuSettings.ContainerHeight, 0f, MenuSettings.HoverColor, MenuSettings.HoverColor);
			if (base.Component.DrawTooltip)
			{
				Rectangle tooltipRectangle = this.GetTooltipRectangle(base.Component);
				int y2 = (int)tooltipRectangle.GetCenteredText(MenuSettings.Font, base.Component.Tooltip, CenteredFlags.VerticalCenter).Y;
				MenuSettings.Font.Draw(base.Component.Tooltip, (int)((float)tooltipRectangle.X + MenuSettings.ContainerTextOffset), y2, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuSettings.RootContainerColor, MenuSettings.RootContainerColor);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuUtils.AlphaColor, Color.Black);
			}
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x000314EC File Offset: 0x0002F6EC
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
			if (args.Type == SingleMouseType.MouseDown && !base.Component.Interacting)
			{
				Rectangle rectangle = this.Bounding(base.Component);
				if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
				{
					base.Component.Interacting = true;
					ThemeUtilities.CalculateNewValue(base.Component, args);
					return;
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

		// Token: 0x0600081E RID: 2078 RVA: 0x0003160C File Offset: 0x0002F80C
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
					this.CalculateNewValue(base.Component, args);
				}
				if (!string.IsNullOrEmpty(base.Component.Tooltip))
				{
					Rectangle fullRectangle = this.GetFullRectangle(base.Component);
					base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
					return;
				}
			}
			else if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.LBUTTONDOWN && !base.Component.Interacting)
			{
				Rectangle rectangle = this.Bounding(base.Component);
				if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
				{
					base.Component.Interacting = true;
					this.CalculateNewValue(base.Component, args);
					return;
				}
			}
			else if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.LBUTTONUP)
			{
				base.Component.Interacting = false;
			}
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00031746 File Offset: 0x0002F946
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + 100;
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00031758 File Offset: 0x0002F958
		private void CalculateNewValue(MenuSlider component, WindowsKeys args)
		{
			int num = (int)Math.Round((double)((float)component.MinValue + (args.Cursor.X - component.Position.X) * (float)(component.MaxValue - component.MinValue) / (float)component.MenuWidth));
			if (num < component.MinValue)
			{
				num = component.MinValue;
			}
			else if (num > component.MaxValue)
			{
				num = component.MaxValue;
			}
			if (num != component.Value)
			{
				component.Value = num;
				component.FireEvent();
				component.Save();
			}
		}
	}
}

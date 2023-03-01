using System;
using System.Globalization;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx11
{
	// Token: 0x020000DF RID: 223
	internal class SliderTheme : ADrawable<MenuSlider>
	{
		// Token: 0x06000895 RID: 2197 RVA: 0x000370CF File Offset: 0x000352CF
		public SliderTheme(MenuSlider component) : base(component)
		{
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x000370D8 File Offset: 0x000352D8
		public Rectangle Bounding(MenuSlider component)
		{
			return ThemeUtilities.GetContainerRectangle(component);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x000370E0 File Offset: 0x000352E0
		public Rectangle GetFullRectangle(MenuSlider component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00037116 File Offset: 0x00035316
		public int GetToolTipWidth(MenuSlider component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00037124 File Offset: 0x00035324
		public Rectangle GetTooltipRectangle(MenuSlider component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00037157 File Offset: 0x00035357
		public override void Dispose()
		{
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0003715C File Offset: 0x0003535C
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 position = base.Component.Position;
			int y = (int)ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter).Y;
			float num = (float)(base.Component.Value - base.Component.MinValue) / (float)(base.Component.MaxValue - base.Component.MinValue);
			float x = position.X + num * (float)base.Component.MenuWidth;
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(x, position.Y + 1f),
				new Vector2(x, position.Y + (float)MenuSettings.ContainerHeight)
			}, base.Component.Interacting ? new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue) : new ColorBGRA(50, 154, 205, byte.MaxValue), 2f);
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(position.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, null);
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(base.Component.Value.ToString(CultureInfo.InvariantCulture), FontCache.DrawFontFlags.Left);
			MenuSettings.Font.Draw(base.Component.Value.ToString(CultureInfo.InvariantCulture), (int)(position.X + (float)base.Component.MenuWidth - 5f - (float)(rawRectangle.Right - rawRectangle.Left)), y, MenuSettings.TextColor, null);
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(position.X, position.Y + (float)MenuSettings.ContainerHeight / 2f),
				new Vector2(x, position.Y + (float)MenuSettings.ContainerHeight / 2f)
			}, MenuSettings.HoverColor, (float)MenuSettings.ContainerHeight);
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

		// Token: 0x0600089C RID: 2204 RVA: 0x00037570 File Offset: 0x00035770
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

		// Token: 0x0600089D RID: 2205 RVA: 0x00037690 File Offset: 0x00035890
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

		// Token: 0x0600089E RID: 2206 RVA: 0x000377CA File Offset: 0x000359CA
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + 100;
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x000377DC File Offset: 0x000359DC
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

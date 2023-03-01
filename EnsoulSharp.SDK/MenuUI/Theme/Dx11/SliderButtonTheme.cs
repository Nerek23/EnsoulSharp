using System;
using System.Globalization;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx11
{
	// Token: 0x020000DE RID: 222
	internal class SliderButtonTheme : ADrawable<MenuSliderButton>
	{
		// Token: 0x0600088A RID: 2186 RVA: 0x000366EE File Offset: 0x000348EE
		public SliderButtonTheme(MenuSliderButton component) : base(component)
		{
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x000366F7 File Offset: 0x000348F7
		public Rectangle SliderBoundaries(MenuSliderButton component)
		{
			return new Rectangle((int)component.Position.X, (int)component.Position.Y, component.MenuWidth - MenuSettings.ContainerHeight, MenuSettings.ContainerHeight);
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00036727 File Offset: 0x00034927
		public Rectangle ButtonBoundaries(MenuSliderButton component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0003675F File Offset: 0x0003495F
		public Rectangle GetFullRectangle(MenuSliderButton component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00036795 File Offset: 0x00034995
		public int GetToolTipWidth(MenuSliderButton component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x000367A3 File Offset: 0x000349A3
		public Rectangle GetTooltipRectangle(MenuSliderButton component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x000367D6 File Offset: 0x000349D6
		public override void Dispose()
		{
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x000367D8 File Offset: 0x000349D8
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 position = base.Component.Position;
			int y = (int)ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter).Y;
			float num = (float)(base.Component.Value - base.Component.MinValue) / (float)(base.Component.MaxValue - base.Component.MinValue);
			float x = position.X + num * (float)(base.Component.MenuWidth - MenuSettings.ContainerHeight);
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(x, position.Y + 1f),
				new Vector2(x, position.Y + (float)MenuSettings.ContainerHeight)
			}, base.Component.Interacting ? new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue) : new ColorBGRA(50, 154, 205, byte.MaxValue), 2f);
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(position.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, null);
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(base.Component.Value.ToString(CultureInfo.InvariantCulture), FontCache.DrawFontFlags.Left);
			MenuSettings.Font.Draw(base.Component.Value.ToString(CultureInfo.InvariantCulture), (int)(position.X + (float)base.Component.MenuWidth - 5f - (float)(rawRectangle.Right - rawRectangle.Left) - (float)MenuSettings.ContainerHeight), y, MenuSettings.TextColor, null);
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(position.X, position.Y + (float)MenuSettings.ContainerHeight / 2f),
				new Vector2(x, position.Y + (float)MenuSettings.ContainerHeight / 2f)
			}, MenuSettings.HoverColor, (float)MenuSettings.ContainerHeight);
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight + (float)MenuSettings.ContainerHeight / 2f, base.Component.Position.Y + 1f),
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight + (float)MenuSettings.ContainerHeight / 2f, base.Component.Position.Y + (float)MenuSettings.ContainerHeight)
			}, base.Component.Enabled ? new ColorBGRA(0, 100, 0, byte.MaxValue) : new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue), (float)MenuSettings.ContainerHeight);
			int x2 = (int)new Rectangle((int)(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)base.Component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight).GetCenteredText(MenuSettings.Font, base.Component.Enabled ? LanguageTranslate.GetOnTranslation() : LanguageTranslate.GetOffTranslation(), CenteredFlags.HorizontalCenter).X;
			MenuSettings.Font.Draw(base.Component.Enabled ? LanguageTranslate.GetOnTranslation() : LanguageTranslate.GetOffTranslation(), x2, y, MenuSettings.TextColor, null);
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

		// Token: 0x06000892 RID: 2194 RVA: 0x00036D8C File Offset: 0x00034F8C
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

		// Token: 0x06000893 RID: 2195 RVA: 0x00036F18 File Offset: 0x00035118
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

		// Token: 0x06000894 RID: 2196 RVA: 0x000370BF File Offset: 0x000352BF
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + 100;
		}
	}
}

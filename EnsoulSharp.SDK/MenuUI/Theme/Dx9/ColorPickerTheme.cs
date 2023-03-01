using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000CE RID: 206
	internal class ColorPickerTheme : ADrawable<MenuColor>
	{
		// Token: 0x060007E1 RID: 2017 RVA: 0x0002E420 File Offset: 0x0002C620
		public ColorPickerTheme(MenuColor component) : base(component)
		{
			this.pickerHeight = 40 + MenuSettings.ContainerHeight + 120 + 40;
			this.pickerX = (Library.GameCache.WindowsValue.WindowsWidth - 300) / 2;
			this.pickerY = (Library.GameCache.WindowsValue.WindowsHeight - this.pickerHeight) / 2;
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(MenuManager.Instance.Sprite, "Opacity", FontCache.DrawFontFlags.Left);
			this.greenWidth = rawRectangle.Right - rawRectangle.Left;
			this.sliderWidth = 240 - this.greenWidth - 30;
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0002E4F2 File Offset: 0x0002C6F2
		public Rectangle GetFullRectangle(MenuColor component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0002E528 File Offset: 0x0002C728
		public int GetToolTipWidth(MenuColor component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0002E536 File Offset: 0x0002C736
		public Rectangle GetTooltipRectangle(MenuColor component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0002E569 File Offset: 0x0002C769
		public override void Dispose()
		{
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0002E56C File Offset: 0x0002C76C
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 centeredText = ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter);
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(base.Component.Position.X + MenuSettings.ContainerTextOffset), (int)centeredText.Y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
			RectangleRender.Draw(new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight, base.Component.Position.Y), (float)MenuSettings.ContainerHeight, (float)MenuSettings.ContainerHeight, 0f, base.Component.Color, base.Component.Color);
			if (base.Component.DrawTooltip)
			{
				Rectangle tooltipRectangle = this.GetTooltipRectangle(base.Component);
				int y = (int)tooltipRectangle.GetCenteredText(MenuSettings.Font, base.Component.Tooltip, CenteredFlags.VerticalCenter).Y;
				MenuSettings.Font.Draw(base.Component.Tooltip, (int)((float)tooltipRectangle.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuSettings.RootContainerColor, MenuSettings.RootContainerColor);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuUtils.AlphaColor, Color.Black);
			}
			if (base.Component.Active)
			{
				MenuManager.Instance.DrawDelayed(delegate
				{
					RectangleRender.Draw(new Vector2((float)this.pickerX, (float)this.pickerY), 300f, (float)this.pickerHeight, 0f, Color.Black, Color.Black);
					RectangleRender.Draw(new Vector2((float)(this.pickerX + 20), (float)(this.pickerY + 20)), 260f, 30f, 0f, base.Component.Color, base.Component.Color);
					ColorBGRA color = base.Component.Color;
					string text = string.Format("R:{0}  G:{1}  B:{2}  A:{3}", new object[]
					{
						color.R,
						color.G,
						color.B,
						color.A
					});
					Vector2 centeredText2 = new Rectangle(this.pickerX + 20, this.pickerY + 20, 260, MenuSettings.ContainerHeight).GetCenteredText(MenuSettings.Font, text, CenteredFlags.HorizontalCenter | CenteredFlags.VerticalCenter);
					MenuSettings.Font.Draw(text, (int)centeredText2.X, (int)centeredText2.Y, new ColorBGRA((color.R > 128) ? 0f : 255f, (color.G > 128) ? 0f : 255f, (color.B > 128) ? 0f : 255f, 255f), MenuManager.Instance.Sprite);
					int num = (int)new Rectangle(this.pickerX + 20, this.pickerY + 20 + MenuSettings.ContainerHeight + 10, 300, 30).GetCenteredText(MenuSettings.Font, "Green", CenteredFlags.VerticalCenter).Y;
					for (int i = 0; i < this.lineNames.Length; i++)
					{
						MenuSettings.Font.Draw(this.lineNames[i], this.pickerX + 20, num + i * 40, Color.White, MenuManager.Instance.Sprite);
					}
					for (int j = 1; j <= 4; j++)
					{
						RectangleRender.Draw(new Vector2((float)(this.pickerX + 20 + this.greenWidth + 10), (float)(this.pickerY + 20 + MenuSettings.ContainerHeight + j * 10 + (j - 1) * 30) + 15f), (float)this.sliderWidth, 1f, 0f, Color.White, Color.White);
					}
					ColorBGRA[] array = new ColorBGRA[]
					{
						new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue),
						new ColorBGRA(0, byte.MaxValue, 0, byte.MaxValue),
						new ColorBGRA(0, 0, byte.MaxValue, byte.MaxValue),
						new ColorBGRA(byte.MaxValue, byte.MaxValue, byte.MaxValue, color.A)
					};
					for (int k = 1; k <= 4; k++)
					{
						RectangleRender.Draw(new Vector2((float)(this.pickerX + 20 + this.greenWidth + 20 + this.sliderWidth), (float)(this.pickerY + 20 + MenuSettings.ContainerHeight + k * 10 + (k - 1) * 30)), 30f, 30f, 0f, array[k - 1], array[k - 1]);
					}
					byte[] array2 = new byte[]
					{
						color.R,
						color.G,
						color.B,
						color.A
					};
					for (int l = 0; l < array2.Length; l++)
					{
						float num2 = (float)array2[l] / 255f * (float)this.sliderWidth;
						RectangleRender.Draw(new Vector2((float)(this.pickerX + 20 + this.greenWidth + 10) + num2, (float)(this.pickerY + 20 + MenuSettings.ContainerHeight + (l + 1) * 10 + l * 30)), 2f, 30f, 0f, new ColorBGRA(50, 154, 205, byte.MaxValue), new ColorBGRA(50, 154, 205, byte.MaxValue));
					}
				});
			}
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x0002E7B0 File Offset: 0x0002C9B0
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
			Rectangle rectangle = ThemeUtilities.PreviewBoundaries(base.Component);
			Rectangle rectangle2 = this.PickerBoundaries();
			Rectangle rect = this.RedPickerBoundaries();
			Rectangle rect2 = this.GreenPickerBoundaries();
			Rectangle rect3 = this.BluePickerBoundaries();
			Rectangle rect4 = this.AlphaPickerBoundaries();
			if (args.Type == SingleMouseType.MouseMove)
			{
				base.Component.HoveringPreview = args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height);
				if (base.Component.Active)
				{
					if (base.Component.InteractingRed)
					{
						ThemeUtilities.UpdateRed(base.Component, args, rect);
					}
					else if (base.Component.InteractingGreen)
					{
						ThemeUtilities.UpdateGreen(base.Component, args, rect2);
					}
					else if (base.Component.InteractingBlue)
					{
						ThemeUtilities.UpdateBlue(base.Component, args, rect3);
					}
					else if (base.Component.InteractingAlpha)
					{
						ThemeUtilities.UpdateAlpha(base.Component, args, rect4);
					}
				}
				if (!string.IsNullOrEmpty(base.Component.Tooltip))
				{
					Rectangle fullRectangle = this.GetFullRectangle(base.Component);
					base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
				}
			}
			if (args.Type == SingleMouseType.MouseUp)
			{
				base.Component.InteractingRed = false;
				base.Component.InteractingGreen = false;
				base.Component.InteractingBlue = false;
				base.Component.InteractingAlpha = false;
			}
			if (args.Type == SingleMouseType.MouseDown)
			{
				if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
				{
					base.Component.Active = true;
					return;
				}
				if (args.Cursor.IsUnderRectangle((float)rectangle2.X, (float)rectangle2.Y, (float)rectangle2.Width, (float)rectangle2.Height) && base.Component.Active)
				{
					if (args.Cursor.IsUnderRectangle((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height))
					{
						base.Component.InteractingRed = true;
						ThemeUtilities.UpdateRed(base.Component, args, rect);
						return;
					}
					if (args.Cursor.IsUnderRectangle((float)rect2.X, (float)rect2.Y, (float)rect2.Width, (float)rect2.Height))
					{
						base.Component.InteractingGreen = true;
						ThemeUtilities.UpdateGreen(base.Component, args, rect2);
						return;
					}
					if (args.Cursor.IsUnderRectangle((float)rect3.X, (float)rect3.Y, (float)rect3.Width, (float)rect3.Height))
					{
						base.Component.InteractingBlue = true;
						ThemeUtilities.UpdateBlue(base.Component, args, rect3);
						return;
					}
					if (args.Cursor.IsUnderRectangle((float)rect4.X, (float)rect4.Y, (float)rect4.Width, (float)rect4.Height))
					{
						base.Component.InteractingAlpha = true;
						ThemeUtilities.UpdateAlpha(base.Component, args, rect4);
						return;
					}
				}
				else
				{
					base.Component.Active = false;
				}
			}
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0002EB04 File Offset: 0x0002CD04
		public override void OnWndProc(WindowsKeys args)
		{
			if (!base.Component.ToggleVisible)
			{
				return;
			}
			Rectangle rectangle = ThemeUtilities.PreviewBoundaries(base.Component);
			Rectangle rect = this.RedPickerBoundaries();
			Rectangle rect2 = this.GreenPickerBoundaries();
			Rectangle rect3 = this.BluePickerBoundaries();
			Rectangle rect4 = this.AlphaPickerBoundaries();
			if (args.Msg == WindowsKeyMessages.MOUSEFIRST)
			{
				base.Component.HoveringPreview = args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height);
				if (base.Component.Active)
				{
					if (base.Component.InteractingRed)
					{
						ThemeUtilities.UpdateRed(base.Component, args, rect);
					}
					else if (base.Component.InteractingGreen)
					{
						ThemeUtilities.UpdateGreen(base.Component, args, rect2);
					}
					else if (base.Component.InteractingBlue)
					{
						ThemeUtilities.UpdateBlue(base.Component, args, rect3);
					}
					else if (base.Component.InteractingAlpha)
					{
						ThemeUtilities.UpdateAlpha(base.Component, args, rect4);
					}
				}
				if (!string.IsNullOrEmpty(base.Component.Tooltip))
				{
					Rectangle fullRectangle = this.GetFullRectangle(base.Component);
					base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
				}
			}
			if (Library.GameCache.IsRiot)
			{
				if (args.Msg == WindowsKeyMessages.LBUTTONUP)
				{
					base.Component.InteractingRed = false;
					base.Component.InteractingGreen = false;
					base.Component.InteractingBlue = false;
					base.Component.InteractingAlpha = false;
				}
				if (args.Msg == WindowsKeyMessages.LBUTTONDOWN)
				{
					Rectangle rectangle2 = this.PickerBoundaries();
					if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
					{
						base.Component.Active = true;
						return;
					}
					if (args.Cursor.IsUnderRectangle((float)rectangle2.X, (float)rectangle2.Y, (float)rectangle2.Width, (float)rectangle2.Height) && base.Component.Active)
					{
						if (args.Cursor.IsUnderRectangle((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height))
						{
							base.Component.InteractingRed = true;
							ThemeUtilities.UpdateRed(base.Component, args, rect);
							return;
						}
						if (args.Cursor.IsUnderRectangle((float)rect2.X, (float)rect2.Y, (float)rect2.Width, (float)rect2.Height))
						{
							base.Component.InteractingGreen = true;
							ThemeUtilities.UpdateGreen(base.Component, args, rect2);
							return;
						}
						if (args.Cursor.IsUnderRectangle((float)rect3.X, (float)rect3.Y, (float)rect3.Width, (float)rect3.Height))
						{
							base.Component.InteractingBlue = true;
							ThemeUtilities.UpdateBlue(base.Component, args, rect3);
							return;
						}
						if (args.Cursor.IsUnderRectangle((float)rect4.X, (float)rect4.Y, (float)rect4.Width, (float)rect4.Height))
						{
							base.Component.InteractingAlpha = true;
							ThemeUtilities.UpdateAlpha(base.Component, args, rect4);
							return;
						}
					}
					else
					{
						base.Component.Active = false;
					}
				}
			}
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0002EE67 File Offset: 0x0002D067
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0002EE7A File Offset: 0x0002D07A
		private Rectangle AlphaPickerBoundaries()
		{
			return new Rectangle(this.pickerX + 20 + this.greenWidth + 10, this.pickerY + 20 + MenuSettings.ContainerHeight + 40 + 90, this.sliderWidth, 30);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0002EEB1 File Offset: 0x0002D0B1
		private Rectangle BluePickerBoundaries()
		{
			return new Rectangle(this.pickerX + 20 + this.greenWidth + 10, this.pickerY + 20 + MenuSettings.ContainerHeight + 30 + 60, this.sliderWidth, 30);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0002EEE8 File Offset: 0x0002D0E8
		private Rectangle GreenPickerBoundaries()
		{
			return new Rectangle(this.pickerX + 20 + this.greenWidth + 10, this.pickerY + 20 + MenuSettings.ContainerHeight + 20 + 30, this.sliderWidth, 30);
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0002EF1F File Offset: 0x0002D11F
		private Rectangle PickerBoundaries()
		{
			return new Rectangle(this.pickerX, this.pickerY, 300, this.pickerHeight);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0002EF3D File Offset: 0x0002D13D
		private Rectangle RedPickerBoundaries()
		{
			return new Rectangle(this.pickerX + 20 + this.greenWidth + 10, this.pickerY + 20 + MenuSettings.ContainerHeight + 10, this.sliderWidth, 30);
		}

		// Token: 0x04000590 RID: 1424
		private const int BorderOffset = 20;

		// Token: 0x04000591 RID: 1425
		private const int PickerWidth = 300;

		// Token: 0x04000592 RID: 1426
		private const int SliderHeight = 30;

		// Token: 0x04000593 RID: 1427
		private const int SliderOffset = 10;

		// Token: 0x04000594 RID: 1428
		private const int TextOffset = 10;

		// Token: 0x04000595 RID: 1429
		private readonly int greenWidth;

		// Token: 0x04000596 RID: 1430
		private readonly int pickerHeight;

		// Token: 0x04000597 RID: 1431
		private readonly int pickerX;

		// Token: 0x04000598 RID: 1432
		private readonly int pickerY;

		// Token: 0x04000599 RID: 1433
		private readonly int sliderWidth;

		// Token: 0x0400059A RID: 1434
		private readonly string[] lineNames = new string[]
		{
			"Red",
			"Green",
			"Blue",
			"Opacity"
		};
	}
}

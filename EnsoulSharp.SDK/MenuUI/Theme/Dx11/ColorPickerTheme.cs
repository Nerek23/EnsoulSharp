using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx11
{
	// Token: 0x020000D8 RID: 216
	internal class ColorPickerTheme : ADrawable<MenuColor>
	{
		// Token: 0x0600084B RID: 2123 RVA: 0x000330F4 File Offset: 0x000312F4
		public ColorPickerTheme(MenuColor component) : base(component)
		{
			this.pickerHeight = 40 + MenuSettings.ContainerHeight + 120 + 40;
			this.pickerX = (Library.GameCache.WindowsValue.WindowsWidth - 300) / 2;
			this.pickerY = (Library.GameCache.WindowsValue.WindowsHeight - this.pickerHeight) / 2;
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText("Opacity", FontCache.DrawFontFlags.Left);
			this.greenWidth = rawRectangle.Right - rawRectangle.Left;
			this.sliderWidth = 240 - this.greenWidth - 30;
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x000331BC File Offset: 0x000313BC
		public Rectangle GetFullRectangle(MenuColor component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x000331F2 File Offset: 0x000313F2
		public int GetToolTipWidth(MenuColor component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x00033200 File Offset: 0x00031400
		public Rectangle GetTooltipRectangle(MenuColor component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00033233 File Offset: 0x00031433
		public override void Dispose()
		{
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00033238 File Offset: 0x00031438
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			Vector2 centeredText = ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter);
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(base.Component.Position.X + MenuSettings.ContainerTextOffset), (int)centeredText.Y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, null);
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight / 2f, base.Component.Position.Y + 1f),
				new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight / 2f, base.Component.Position.Y + (float)MenuSettings.ContainerHeight)
			}, base.Component.Color, (float)MenuSettings.ContainerHeight);
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
			if (base.Component.Active)
			{
				MenuManager.Instance.DrawDelayed(delegate
				{
					ThemeUtilities.Line.Draw(new Vector2[]
					{
						new Vector2((float)this.pickerX + 150f, (float)this.pickerY),
						new Vector2((float)this.pickerX + 150f, (float)(this.pickerY + this.pickerHeight))
					}, Color.Black, 300f);
					ThemeUtilities.Line.Draw(new Vector2[]
					{
						new Vector2((float)(this.pickerX + 20), (float)(this.pickerY + 20) + (float)MenuSettings.ContainerHeight / 2f),
						new Vector2((float)(this.pickerX + 300 - 20), (float)(this.pickerY + 20) + (float)MenuSettings.ContainerHeight / 2f)
					}, base.Component.Color, 30f);
					ColorBGRA color = base.Component.Color;
					string text = string.Format("R:{0}  G:{1}  B:{2}  A:{3}", new object[]
					{
						color.R,
						color.G,
						color.B,
						color.A
					});
					Vector2 centeredText2 = new Rectangle(this.pickerX + 20, this.pickerY + 20, 260, MenuSettings.ContainerHeight).GetCenteredText(MenuSettings.Font, text, CenteredFlags.HorizontalCenter | CenteredFlags.VerticalCenter);
					MenuSettings.Font.Draw(text, (int)centeredText2.X, (int)centeredText2.Y, new ColorBGRA((color.R > 128) ? 0f : 255f, (color.G > 128) ? 0f : 255f, (color.B > 128) ? 0f : 255f, 255f), null);
					int num = (int)new Rectangle(this.pickerX + 20, this.pickerY + 20 + MenuSettings.ContainerHeight + 10, 300, 30).GetCenteredText(MenuSettings.Font, "Green", CenteredFlags.VerticalCenter).Y;
					for (int i = 0; i < this.lineNames.Length; i++)
					{
						MenuSettings.Font.Draw(this.lineNames[i], this.pickerX + 20, num + i * 40, Color.White, null);
					}
					for (int j = 1; j <= 4; j++)
					{
						ThemeUtilities.Line.Draw(new Vector2[]
						{
							new Vector2((float)(this.pickerX + 20 + this.greenWidth + 10), (float)(this.pickerY + 20 + MenuSettings.ContainerHeight + j * 10 + (j - 1) * 30) + 15f),
							new Vector2((float)(this.pickerX + 20 + this.greenWidth + 10 + this.sliderWidth), (float)(this.pickerY + 20 + MenuSettings.ContainerHeight + j * 10 + (j - 1) * 30) + 15f)
						}, Color.White, 1f);
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
						ThemeUtilities.Line.Draw(new Vector2[]
						{
							new Vector2((float)(this.pickerX + 20 + this.greenWidth + 20 + this.sliderWidth), (float)(this.pickerY + 20 + MenuSettings.ContainerHeight + k * 10 + (k - 1) * 30) + 15f),
							new Vector2((float)(this.pickerX + 20 + this.greenWidth + 20 + this.sliderWidth + 30), (float)(this.pickerY + 20 + MenuSettings.ContainerHeight + k * 10 + (k - 1) * 30) + 15f)
						}, array[k - 1], 30f);
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
						ThemeUtilities.Line.Draw(new Vector2[]
						{
							new Vector2((float)(this.pickerX + 20 + this.greenWidth + 10) + num2, (float)(this.pickerY + 20 + MenuSettings.ContainerHeight + (l + 1) * 10 + l * 30)),
							new Vector2((float)(this.pickerX + 20 + this.greenWidth + 10) + num2, (float)(this.pickerY + 20 + MenuSettings.ContainerHeight + (l + 1) * 10 + (l + 1) * 30))
						}, new ColorBGRA(50, 154, 205, byte.MaxValue), 2f);
					}
				});
			}
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00033578 File Offset: 0x00031778
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

		// Token: 0x06000852 RID: 2130 RVA: 0x000338CC File Offset: 0x00031ACC
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

		// Token: 0x06000853 RID: 2131 RVA: 0x00033C2F File Offset: 0x00031E2F
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00033C42 File Offset: 0x00031E42
		private Rectangle AlphaPickerBoundaries()
		{
			return new Rectangle(this.pickerX + 20 + this.greenWidth + 10, this.pickerY + 20 + MenuSettings.ContainerHeight + 40 + 90, this.sliderWidth, 30);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00033C79 File Offset: 0x00031E79
		private Rectangle BluePickerBoundaries()
		{
			return new Rectangle(this.pickerX + 20 + this.greenWidth + 10, this.pickerY + 20 + MenuSettings.ContainerHeight + 30 + 60, this.sliderWidth, 30);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00033CB0 File Offset: 0x00031EB0
		private Rectangle GreenPickerBoundaries()
		{
			return new Rectangle(this.pickerX + 20 + this.greenWidth + 10, this.pickerY + 20 + MenuSettings.ContainerHeight + 20 + 30, this.sliderWidth, 30);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00033CE7 File Offset: 0x00031EE7
		private Rectangle PickerBoundaries()
		{
			return new Rectangle(this.pickerX, this.pickerY, 300, this.pickerHeight);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00033D05 File Offset: 0x00031F05
		private Rectangle RedPickerBoundaries()
		{
			return new Rectangle(this.pickerX + 20 + this.greenWidth + 10, this.pickerY + 20 + MenuSettings.ContainerHeight + 10, this.sliderWidth, 30);
		}

		// Token: 0x040005A1 RID: 1441
		private const int BorderOffset = 20;

		// Token: 0x040005A2 RID: 1442
		private const int PickerWidth = 300;

		// Token: 0x040005A3 RID: 1443
		private const int SliderHeight = 30;

		// Token: 0x040005A4 RID: 1444
		private const int SliderOffset = 10;

		// Token: 0x040005A5 RID: 1445
		private const int TextOffset = 10;

		// Token: 0x040005A6 RID: 1446
		private readonly int greenWidth;

		// Token: 0x040005A7 RID: 1447
		private readonly int pickerHeight;

		// Token: 0x040005A8 RID: 1448
		private readonly int pickerX;

		// Token: 0x040005A9 RID: 1449
		private readonly int pickerY;

		// Token: 0x040005AA RID: 1450
		private readonly int sliderWidth;

		// Token: 0x040005AB RID: 1451
		private readonly string[] lineNames = new string[]
		{
			"Red",
			"Green",
			"Blue",
			"Opacity"
		};
	}
}

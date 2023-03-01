using System;
using System.Collections.Generic;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx11
{
	// Token: 0x020000DB RID: 219
	internal class ListTheme : ADrawable<MenuList>
	{
		// Token: 0x06000870 RID: 2160 RVA: 0x00035114 File Offset: 0x00033314
		public ListTheme(MenuList component) : base(component)
		{
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText("V", FontCache.DrawFontFlags.Left);
			this.dropDownButtonWidth = rawRectangle.Right - rawRectangle.Left + 12;
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0003514F File Offset: 0x0003334F
		public Rectangle GetFullRectangle(MenuList component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00035185 File Offset: 0x00033385
		public int GetToolTipWidth(MenuList component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00035193 File Offset: 0x00033393
		public Rectangle GetTooltipRectangle(MenuList component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x000351C6 File Offset: 0x000333C6
		public override void Dispose()
		{
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x000351C8 File Offset: 0x000333C8
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			int dropdownMenuWidth = this.dropDownButtonWidth + 16 + base.Component.MaxStringWidth;
			Vector2 position = base.Component.Position;
			Vector2 rectangleName = ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter);
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(position.X + MenuSettings.ContainerTextOffset), (int)rectangleName.Y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, null);
			MenuSettings.Font.Draw("»", (int)(position.X + (float)base.Component.MenuWidth - (float)this.dropDownButtonWidth + 6f), (int)rectangleName.Y, MenuSettings.TextColor, null);
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(position.X + (float)base.Component.MenuWidth - (float)this.dropDownButtonWidth - 1f, position.Y + 1f),
				new Vector2(position.X + (float)base.Component.MenuWidth - (float)this.dropDownButtonWidth - 1f, position.Y + (float)MenuSettings.ContainerHeight)
			}, MenuSettings.ContainerSeparatorColor, 1f);
			MenuSettings.Font.Draw(ThemeUtilities.GetTranslateName(base.Component, base.Component.SelectedValue), (int)position.X + base.Component.MenuWidth - this.dropDownButtonWidth - 8 - base.Component.MaxStringWidth, (int)rectangleName.Y, MenuSettings.TextColor, null);
			ThemeUtilities.Line.Draw(new Vector2[]
			{
				new Vector2(position.X + (float)base.Component.MenuWidth - (float)this.dropDownButtonWidth - 16f - (float)base.Component.MaxStringWidth, position.Y + 1f),
				new Vector2(position.X + (float)base.Component.MenuWidth - (float)this.dropDownButtonWidth - 16f - (float)base.Component.MaxStringWidth, position.Y + (float)MenuSettings.ContainerHeight)
			}, MenuSettings.ContainerSeparatorColor, 1f);
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
				string[] valueStrings = base.Component.Items;
				int dropdownMenuHeight = valueStrings.Length * MenuSettings.ContainerHeight;
				MenuManager.Instance.DrawDelayed(delegate
				{
					int num = (int)(position.X + (float)this.Component.MenuWidth + (float)this.dropDownButtonWidth + 16f + (float)this.Component.MaxStringWidth);
					int num2 = (int)rectangleName.Y;
					ThemeUtilities.Line.Draw(new Vector2[]
					{
						new Vector2(position.X + (float)this.Component.MenuWidth + (float)this.dropDownButtonWidth + (float)this.Component.MaxStringWidth / 2f, position.Y),
						new Vector2(position.X + (float)this.Component.MenuWidth + (float)this.dropDownButtonWidth + (float)this.Component.MaxStringWidth / 2f, position.Y + (float)dropdownMenuHeight)
					}, MenuSettings.RootContainerColor, (float)dropdownMenuWidth);
					for (int i = 0; i < valueStrings.Length; i++)
					{
						ThemeUtilities.Line.Draw(new Vector2[]
						{
							new Vector2(position.X + (float)this.Component.MenuWidth + (float)dropdownMenuWidth, position.Y + (float)(MenuSettings.ContainerHeight * i)),
							new Vector2(position.X + (float)this.Component.MenuWidth, position.Y + (float)(MenuSettings.ContainerHeight * i))
						}, MenuSettings.ContainerSeparatorColor, 1f);
						MenuSettings.Font.Draw(ThemeUtilities.GetTranslateName(this.Component, valueStrings[i]), num - this.Component.MaxStringWidth - 16, num2, MenuSettings.TextColor, null);
						if (this.Component.Index == i)
						{
							RawRectangle rawRectangle = MenuSettings.Font.MeasureText("√", FontCache.DrawFontFlags.Left);
							MenuSettings.Font.Draw("√", (int)(position.X + (float)this.Component.MenuWidth + (float)(rawRectangle.Right - rawRectangle.Left) + 16f + (float)this.Component.MaxStringWidth), num2, MenuSettings.TextColor, null);
						}
						num2 += MenuSettings.ContainerHeight;
					}
					ThemeUtilities.Line.Draw(new Vector2[]
					{
						new Vector2(position.X + (float)this.Component.MenuWidth, position.Y),
						new Vector2(position.X + (float)this.Component.MenuWidth, position.Y + (float)(MenuSettings.ContainerHeight * valueStrings.Length)),
						new Vector2(position.X + (float)this.Component.MenuWidth + (float)dropdownMenuWidth, position.Y + (float)(MenuSettings.ContainerHeight * valueStrings.Length)),
						new Vector2(position.X + (float)this.Component.MenuWidth + (float)dropdownMenuWidth, position.Y),
						new Vector2(position.X + (float)this.Component.MenuWidth, position.Y)
					}, MenuSettings.ContainerSeparatorColor, 1f);
				});
			}
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x000356D0 File Offset: 0x000338D0
		public Rectangle DropDownBoundaries(MenuList component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)this.dropDownButtonWidth - 16f - (float)component.MaxStringWidth), (int)component.Position.Y, this.dropDownButtonWidth + 16 + component.MaxStringWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00035730 File Offset: 0x00033930
		public List<Rectangle> DropDownListBoundaries(MenuList component)
		{
			List<Rectangle> list = new List<Rectangle>();
			for (int i = 0; i < component.Items.Length; i++)
			{
				list.Add(new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)this.dropDownButtonWidth - 16f + (float)component.MaxStringWidth), (int)(component.Position.Y + (float)(i * MenuSettings.ContainerHeight)), this.dropDownButtonWidth + 16 + component.MaxStringWidth, MenuSettings.ContainerHeight + 1));
			}
			return list;
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x000357B8 File Offset: 0x000339B8
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
			Rectangle rectangle = this.DropDownBoundaries(base.Component);
			if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
			{
				base.Component.Hovering = true;
				if (args.Type == SingleMouseType.MouseDown)
				{
					base.Component.Active = !base.Component.Active;
				}
			}
			else
			{
				base.Component.Hovering = false;
			}
			if (base.Component.Active)
			{
				bool flag = false;
				List<Rectangle> list = this.DropDownListBoundaries(base.Component);
				for (int i = 0; i < list.Count; i++)
				{
					if (args.Cursor.IsUnderRectangle((float)list[i].X, (float)list[i].Y, (float)list[i].Width, (float)list[i].Height) && args.Key == SingleMouseKey.LeftClick)
					{
						base.Component.HoveringIndex = i;
						flag = true;
					}
				}
				if (!flag)
				{
					base.Component.HoveringIndex = -1;
					return;
				}
				if (args.Type == SingleMouseType.MouseDown && args.Key == SingleMouseKey.LeftClick)
				{
					base.Component.Index = base.Component.HoveringIndex;
					base.Component.Save();
					base.Component.Active = false;
				}
			}
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00035998 File Offset: 0x00033B98
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
				Rectangle rectangle = this.DropDownBoundaries(base.Component);
				if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
				{
					base.Component.Hovering = true;
					if (args.Msg == WindowsKeyMessages.LBUTTONDOWN)
					{
						base.Component.Active = !base.Component.Active;
					}
				}
				else
				{
					base.Component.Hovering = false;
				}
				if (base.Component.Active)
				{
					bool flag = false;
					List<Rectangle> list = this.DropDownListBoundaries(base.Component);
					for (int i = 0; i < list.Count; i++)
					{
						if (args.Cursor.IsUnderRectangle((float)list[i].X, (float)list[i].Y, (float)list[i].Width, (float)list[i].Height))
						{
							base.Component.HoveringIndex = i;
							flag = true;
						}
					}
					if (!flag)
					{
						base.Component.HoveringIndex = -1;
						return;
					}
					if (args.Msg == WindowsKeyMessages.LBUTTONDOWN)
					{
						base.Component.Index = base.Component.HoveringIndex;
						base.Component.Save();
						base.Component.Active = false;
						args.Process = false;
					}
				}
			}
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00035B87 File Offset: 0x00033D87
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + base.Component.MaxStringWidth + 16 + this.dropDownButtonWidth + 5;
		}

		// Token: 0x040005AC RID: 1452
		private const int ArrowSpacing = 6;

		// Token: 0x040005AD RID: 1453
		private const int TextSpacing = 8;

		// Token: 0x040005AE RID: 1454
		private readonly int dropDownButtonWidth;
	}
}

using System;
using System.Collections.Generic;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000D0 RID: 208
	internal class ListTheme : ADrawable<MenuList>
	{
		// Token: 0x060007FB RID: 2043 RVA: 0x0002FEE8 File Offset: 0x0002E0E8
		public ListTheme(MenuList component) : base(component)
		{
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(null, "»", FontCache.DrawFontFlags.Left);
			this.dropDownButtonWidth = rawRectangle.Right - rawRectangle.Left + 12;
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0002FF24 File Offset: 0x0002E124
		public Rectangle GetFullRectangle(MenuList component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0002FF5A File Offset: 0x0002E15A
		public int GetToolTipWidth(MenuList component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0002FF68 File Offset: 0x0002E168
		public Rectangle GetTooltipRectangle(MenuList component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0002FF9B File Offset: 0x0002E19B
		public override void Dispose()
		{
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0002FFA0 File Offset: 0x0002E1A0
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			int dropdownMenuWidth = this.dropDownButtonWidth + 16 + base.Component.MaxStringWidth;
			Vector2 position = base.Component.Position;
			Vector2 rectangleName = ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter);
			MenuSettings.Font.Draw(base.Component.DisplayName, (int)(position.X + MenuSettings.ContainerTextOffset), (int)rectangleName.Y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
			MenuSettings.Font.Draw("»", (int)(position.X + (float)base.Component.MenuWidth - (float)this.dropDownButtonWidth + 6f), (int)rectangleName.Y, MenuSettings.TextColor, MenuManager.Instance.Sprite);
			RectangleRender.Draw(new Vector2(position.X + (float)base.Component.MenuWidth - (float)this.dropDownButtonWidth - 1f, position.Y), 1f, (float)MenuSettings.ContainerHeight, 0f, MenuSettings.ContainerSeparatorColor, MenuSettings.ContainerSeparatorColor);
			MenuSettings.Font.Draw(ThemeUtilities.GetTranslateName(base.Component, base.Component.SelectedValue), (int)position.X + base.Component.MenuWidth - this.dropDownButtonWidth - 8 - base.Component.MaxStringWidth, (int)rectangleName.Y, MenuSettings.TextColor, MenuManager.Instance.Sprite);
			RectangleRender.Draw(new Vector2(position.X + (float)base.Component.MenuWidth - (float)this.dropDownButtonWidth - 16f - (float)base.Component.MaxStringWidth, position.Y), 1f, (float)MenuSettings.ContainerHeight, 0f, MenuSettings.ContainerSeparatorColor, MenuSettings.ContainerSeparatorColor);
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
				string[] valueStrings = base.Component.Items;
				int dropdownMenuHeight = valueStrings.Length * MenuSettings.ContainerHeight;
				MenuManager.Instance.DrawDelayed(delegate
				{
					int num = (int)(position.X + (float)this.Component.MenuWidth + (float)this.dropDownButtonWidth + 16f + (float)this.Component.MaxStringWidth);
					int num2 = (int)rectangleName.Y;
					RectangleRender.Draw(new Vector2(position.X + (float)this.Component.MenuWidth, position.Y), (float)dropdownMenuWidth, (float)dropdownMenuHeight, 0f, MenuSettings.RootContainerColor, MenuSettings.RootContainerColor);
					for (int i = 0; i < valueStrings.Length; i++)
					{
						Vector2 vector = new Vector2(position.X + (float)this.Component.MenuWidth, position.Y + (float)(i * MenuSettings.ContainerHeight));
						RectangleRender.Draw(new Vector2(vector.X, vector.Y), (float)dropdownMenuWidth, (float)MenuSettings.ContainerHeight, 1f, MenuUtils.AlphaColor, MenuSettings.ContainerSeparatorColor);
						MenuSettings.Font.Draw(ThemeUtilities.GetTranslateName(this.Component, valueStrings[i]), num - this.Component.MaxStringWidth - 16, num2, MenuSettings.TextColor, MenuManager.Instance.Sprite);
						if (this.Component.Index == i)
						{
							RawRectangle rawRectangle = MenuSettings.Font.MeasureText(null, "√", FontCache.DrawFontFlags.Left);
							MenuSettings.Font.Draw("√", (int)(position.X + (float)this.Component.MenuWidth + (float)(rawRectangle.Right - rawRectangle.Left) + 16f + (float)this.Component.MaxStringWidth), num2, MenuSettings.TextColor, MenuManager.Instance.Sprite);
						}
						num2 += MenuSettings.ContainerHeight;
					}
					RectangleRender.Draw(new Vector2(position.X + (float)this.Component.MenuWidth, position.Y), (float)dropdownMenuWidth, (float)(MenuSettings.ContainerHeight * valueStrings.Length), 1f, MenuUtils.AlphaColor, Color.Black);
				});
			}
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00030370 File Offset: 0x0002E570
		public Rectangle DropDownBoundaries(MenuList component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)this.dropDownButtonWidth - 16f - (float)component.MaxStringWidth), (int)component.Position.Y, this.dropDownButtonWidth + 16 + component.MaxStringWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x000303D0 File Offset: 0x0002E5D0
		public Rectangle DropDownExpandedBoundaries(MenuList component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)this.dropDownButtonWidth - 16f + (float)component.MaxStringWidth / 2f), (int)component.Position.Y, this.dropDownButtonWidth + 16 + component.MaxStringWidth, component.Items.Length * MenuSettings.ContainerHeight);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0003043C File Offset: 0x0002E63C
		public List<Rectangle> DropDownListBoundaries(MenuList component)
		{
			List<Rectangle> list = new List<Rectangle>();
			for (int i = 0; i < component.Items.Length; i++)
			{
				list.Add(new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)this.dropDownButtonWidth - 16f + (float)component.MaxStringWidth), (int)(component.Position.Y + (float)(i * MenuSettings.ContainerHeight)), this.dropDownButtonWidth + 16 + component.MaxStringWidth, MenuSettings.ContainerHeight + 1));
			}
			return list;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x000304C4 File Offset: 0x0002E6C4
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

		// Token: 0x06000805 RID: 2053 RVA: 0x000306A4 File Offset: 0x0002E8A4
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

		// Token: 0x06000806 RID: 2054 RVA: 0x00030893 File Offset: 0x0002EA93
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + base.Component.MaxStringWidth + 16 + this.dropDownButtonWidth + 5;
		}

		// Token: 0x0400059B RID: 1435
		private const int ArrowSpacing = 6;

		// Token: 0x0400059C RID: 1436
		private const int TextSpacing = 8;

		// Token: 0x0400059D RID: 1437
		private readonly int dropDownButtonWidth;
	}
}

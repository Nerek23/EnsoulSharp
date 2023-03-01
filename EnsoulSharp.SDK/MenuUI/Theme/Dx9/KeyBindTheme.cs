using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI.Theme.Dx9
{
	// Token: 0x020000CF RID: 207
	internal class KeyBindTheme : ADrawable<MenuKeyBind>
	{
		// Token: 0x060007F0 RID: 2032 RVA: 0x0002F3C9 File Offset: 0x0002D5C9
		public KeyBindTheme(MenuKeyBind component) : base(component)
		{
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0002F3D2 File Offset: 0x0002D5D2
		public Rectangle ButtonBoundaries(MenuKeyBind component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0002F40A File Offset: 0x0002D60A
		public Rectangle GetFullRectangle(MenuKeyBind component)
		{
			return new Rectangle((int)component.Position.X - MenuSettings.ContainerHeight, (int)component.Position.Y, MenuSettings.ContainerHeight + component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0002F440 File Offset: 0x0002D640
		public int GetToolTipWidth(MenuKeyBind component)
		{
			return ThemeUtilities.CalcWidthToolTips(component) + MenuSettings.ContainerHeight;
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0002F44E File Offset: 0x0002D64E
		public Rectangle GetTooltipRectangle(MenuKeyBind component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth), (int)component.Position.Y, this.GetToolTipWidth(component), MenuSettings.ContainerHeight);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0002F481 File Offset: 0x0002D681
		public override void Dispose()
		{
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0002F484 File Offset: 0x0002D684
		public override void Draw()
		{
			if (!base.Component.Visible)
			{
				return;
			}
			int y = (int)ThemeUtilities.GetContainerRectangle(base.Component).GetCenteredText(MenuSettings.Font, base.Component.DisplayName, CenteredFlags.VerticalCenter).Y;
			MenuSettings.Font.Draw(base.Component.Interacting ? LanguageTranslate.GetPressKeyTranslation() : base.Component.DisplayName, (int)(base.Component.Position.X + MenuSettings.ContainerTextOffset), y, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
			if (!base.Component.Interacting)
			{
				string text = "[" + base.Component.Key + "]";
				MenuSettings.Font.Draw(text, (int)(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight - (float)ThemeUtilities.CalcWidthText(text) - MenuSettings.ContainerTextOffset), y, MenuSettings.TextColor, MenuManager.Instance.Sprite);
			}
			RectangleRender.Draw(new Vector2(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight, base.Component.Position.Y + 1f), (float)(MenuSettings.ContainerHeight - 2), (float)(MenuSettings.ContainerHeight - 1), 0f, base.Component.Active ? new ColorBGRA(0, 100, 0, byte.MaxValue) : new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue), base.Component.Active ? new ColorBGRA(0, 100, 0, byte.MaxValue) : new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue));
			int x = (int)new Rectangle((int)(base.Component.Position.X + (float)base.Component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)base.Component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight).GetCenteredText(MenuSettings.Font, base.Component.Active ? LanguageTranslate.GetOnTranslation() : LanguageTranslate.GetOffTranslation(), CenteredFlags.HorizontalCenter).X;
			MenuSettings.Font.Draw(base.Component.Active ? LanguageTranslate.GetOnTranslation() : LanguageTranslate.GetOffTranslation(), x, y, MenuSettings.TextColor, MenuManager.Instance.Sprite);
			if (base.Component.DrawTooltip)
			{
				Rectangle tooltipRectangle = this.GetTooltipRectangle(base.Component);
				int y2 = (int)tooltipRectangle.GetCenteredText(MenuSettings.Font, base.Component.Tooltip, CenteredFlags.VerticalCenter).Y;
				MenuSettings.Font.Draw(base.Component.Tooltip, (int)((float)tooltipRectangle.X + MenuSettings.ContainerTextOffset), y2, base.Component.HaveCustomColor ? base.Component.FontColor : MenuSettings.TextColor, MenuManager.Instance.Sprite);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuSettings.RootContainerColor, MenuSettings.RootContainerColor);
				RectangleRender.Draw(new Vector2((float)tooltipRectangle.X, (float)tooltipRectangle.Y), (float)tooltipRectangle.Width, (float)tooltipRectangle.Height, 1f, MenuUtils.AlphaColor, Color.Black);
			}
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0002F831 File Offset: 0x0002DA31
		public Rectangle KeyBindBoundaries(MenuKeyBind component)
		{
			return ThemeUtilities.GetContainerRectangle(component);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0002F83C File Offset: 0x0002DA3C
		public override void OnWndProc(SingleMouseEventArgs args)
		{
			if (MenuGUI.IsChatOpen)
			{
				return;
			}
			if (args.Type == SingleMouseType.MouseDown && args.Key == SingleMouseKey.XButton1Click)
			{
				ThemeUtilities.HandleDown(base.Component, Keys.XButton1);
				return;
			}
			if (args.Type == SingleMouseType.MouseUp && args.Key == SingleMouseKey.XButton1Click)
			{
				if (base.Component.Interacting)
				{
					ThemeUtilities.ChangeKey(base.Component, Keys.XButton1);
					return;
				}
				ThemeUtilities.HandleUp(base.Component, Keys.XButton1);
				return;
			}
			else
			{
				if (args.Type == SingleMouseType.MouseDown && args.Key == SingleMouseKey.XButton2Click)
				{
					ThemeUtilities.HandleDown(base.Component, Keys.XButton2);
					return;
				}
				if (args.Type == SingleMouseType.MouseUp && args.Key == SingleMouseKey.XButton2Click)
				{
					if (base.Component.Interacting)
					{
						ThemeUtilities.ChangeKey(base.Component, Keys.XButton2);
						return;
					}
					ThemeUtilities.HandleUp(base.Component, Keys.XButton2);
					return;
				}
				else
				{
					if (args.Type == SingleMouseType.MouseDown && args.Key == SingleMouseKey.MiddleClick)
					{
						ThemeUtilities.HandleDown(base.Component, Keys.MButton);
						return;
					}
					if (args.Type == SingleMouseType.MouseUp && args.Key == SingleMouseKey.MiddleClick)
					{
						if (base.Component.Interacting)
						{
							ThemeUtilities.ChangeKey(base.Component, Keys.MButton);
							return;
						}
						ThemeUtilities.HandleUp(base.Component, Keys.MButton);
						return;
					}
					else
					{
						if (args.Type == SingleMouseType.MouseDown && args.Key == SingleMouseKey.RightClick)
						{
							ThemeUtilities.HandleDown(base.Component, Keys.RButton);
							return;
						}
						if (args.Type == SingleMouseType.MouseUp && args.Key == SingleMouseKey.RightClick)
						{
							if (base.Component.Interacting)
							{
								ThemeUtilities.ChangeKey(base.Component, Keys.RButton);
								return;
							}
							ThemeUtilities.HandleUp(base.Component, Keys.RButton);
							return;
						}
						else if (args.Type == SingleMouseType.MouseDown && args.Key == SingleMouseKey.LeftClick)
						{
							if (base.Component.Interacting)
							{
								ThemeUtilities.ChangeKey(base.Component, Keys.LButton);
								return;
							}
							if (!base.Component.ToggleVisible)
							{
								ThemeUtilities.HandleDown(base.Component, Keys.LButton);
								return;
							}
							Rectangle rectangle = this.ButtonBoundaries(base.Component);
							Rectangle rectangle2 = this.KeyBindBoundaries(base.Component);
							if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
							{
								base.Component.Active = !base.Component.Active;
								return;
							}
							if (args.Cursor.IsUnderRectangle((float)rectangle2.X, (float)rectangle2.Y, (float)rectangle2.Width, (float)rectangle2.Height))
							{
								base.Component.Interacting = !base.Component.Interacting;
								return;
							}
							ThemeUtilities.HandleDown(base.Component, Keys.LButton);
							return;
						}
						else
						{
							if (args.Type == SingleMouseType.MouseUp && args.Key == SingleMouseKey.LeftClick)
							{
								ThemeUtilities.HandleUp(base.Component, Keys.LButton);
								return;
							}
							if (args.Type == SingleMouseType.MouseMove)
							{
								if (!base.Component.ToggleVisible)
								{
									return;
								}
								if (!string.IsNullOrEmpty(base.Component.Tooltip))
								{
									Rectangle fullRectangle = this.GetFullRectangle(base.Component);
									base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
								}
							}
							return;
						}
					}
				}
			}
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0002FB3C File Offset: 0x0002DD3C
		public override void OnWndProc(WindowsKeys args)
		{
			if (MenuGUI.IsChatOpen)
			{
				return;
			}
			if (args.Msg == WindowsKeyMessages.KEYFIRST)
			{
				ThemeUtilities.HandleDown(base.Component, args.Key);
				return;
			}
			if (args.Msg == WindowsKeyMessages.KEYUP)
			{
				if (base.Component.Interacting && args.SingleKey != Keys.ShiftKey)
				{
					ThemeUtilities.ChangeKey(base.Component, (args.SingleKey == Keys.Escape) ? Keys.None : args.Key);
					return;
				}
				ThemeUtilities.HandleUp(base.Component, args.Key);
				return;
			}
			else
			{
				if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.XBUTTONDOWN)
				{
					ThemeUtilities.HandleDown(base.Component, args.SideButton);
					return;
				}
				if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.XBUTTONUP)
				{
					if (base.Component.Interacting)
					{
						ThemeUtilities.ChangeKey(base.Component, args.SideButton);
						return;
					}
					ThemeUtilities.HandleUp(base.Component, args.SideButton);
					return;
				}
				else
				{
					if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.MBUTTONDOWN)
					{
						ThemeUtilities.HandleDown(base.Component, Keys.MButton);
						return;
					}
					if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.MBUTTONUP)
					{
						if (base.Component.Interacting)
						{
							ThemeUtilities.ChangeKey(base.Component, Keys.MButton);
							return;
						}
						ThemeUtilities.HandleUp(base.Component, Keys.MButton);
						return;
					}
					else
					{
						if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.RBUTTONDOWN)
						{
							ThemeUtilities.HandleDown(base.Component, Keys.RButton);
							return;
						}
						if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.RBUTTONUP)
						{
							if (base.Component.Interacting)
							{
								ThemeUtilities.ChangeKey(base.Component, Keys.RButton);
								return;
							}
							ThemeUtilities.HandleUp(base.Component, Keys.RButton);
							return;
						}
						else if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.LBUTTONDOWN)
						{
							if (base.Component.Interacting)
							{
								ThemeUtilities.ChangeKey(base.Component, Keys.LButton);
								return;
							}
							if (!base.Component.ToggleVisible)
							{
								ThemeUtilities.HandleDown(base.Component, Keys.LButton);
								return;
							}
							Rectangle rectangle = this.ButtonBoundaries(base.Component);
							Rectangle rectangle2 = this.KeyBindBoundaries(base.Component);
							if (args.Cursor.IsUnderRectangle((float)rectangle.X, (float)rectangle.Y, (float)rectangle.Width, (float)rectangle.Height))
							{
								base.Component.Active = !base.Component.Active;
								return;
							}
							if (args.Cursor.IsUnderRectangle((float)rectangle2.X, (float)rectangle2.Y, (float)rectangle2.Width, (float)rectangle2.Height))
							{
								base.Component.Interacting = !base.Component.Interacting;
								return;
							}
							ThemeUtilities.HandleDown(base.Component, Keys.LButton);
							return;
						}
						else
						{
							if (Library.GameCache.IsRiot && args.Msg == WindowsKeyMessages.LBUTTONUP)
							{
								ThemeUtilities.HandleUp(base.Component, Keys.LButton);
								return;
							}
							if (args.Msg == WindowsKeyMessages.MOUSEFIRST)
							{
								if (!base.Component.ToggleVisible)
								{
									return;
								}
								if (!string.IsNullOrEmpty(base.Component.Tooltip))
								{
									Rectangle fullRectangle = this.GetFullRectangle(base.Component);
									base.Component.DrawTooltip = args.Cursor.IsUnderRectangle((float)fullRectangle.X, (float)fullRectangle.Y, (float)fullRectangle.Width, (float)fullRectangle.Height);
								}
							}
							return;
						}
					}
				}
			}
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0002FEA7 File Offset: 0x0002E0A7
		public override int Width()
		{
			return ThemeUtilities.CalcWidthItem(base.Component) + (int)((float)(MenuSettings.ContainerHeight + ThemeUtilities.CalcWidthText("[" + base.Component.Key + "]")) + MenuSettings.ContainerTextOffset);
		}
	}
}

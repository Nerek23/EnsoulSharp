using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme
{
	// Token: 0x020000C8 RID: 200
	internal class ThemeUtilities
	{
		// Token: 0x0600078C RID: 1932 RVA: 0x0002CEF4 File Offset: 0x0002B0F4
		public static int CalcWidthItem(MenuItem menuItem)
		{
			return (int)((float)ThemeUtilities.MeasureString(menuItem.DisplayName).Width + MenuSettings.ContainerTextOffset * 2f);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0002CF24 File Offset: 0x0002B124
		public static int CalcWidthToolTips(MenuItem menuItem)
		{
			return (int)((float)ThemeUtilities.MeasureString(menuItem.Tooltip).Width + MenuSettings.ContainerTextOffset * 2f);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0002CF54 File Offset: 0x0002B154
		public static byte GetByte(WindowsKeys args, Rectangle rect)
		{
			if (args.Cursor.X < (float)rect.X)
			{
				return 0;
			}
			if (args.Cursor.X > (float)(rect.X + rect.Width))
			{
				return byte.MaxValue;
			}
			return (byte)((args.Cursor.X - (float)rect.X) / (float)rect.Width * 255f);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0002CFC0 File Offset: 0x0002B1C0
		public static byte GetByte(SingleMouseEventArgs args, Rectangle rect)
		{
			if (args.Cursor.X < (float)rect.X)
			{
				return 0;
			}
			if (args.Cursor.X > (float)(rect.X + rect.Width))
			{
				return byte.MaxValue;
			}
			return (byte)((args.Cursor.X - (float)rect.X) / (float)rect.Width * 255f);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0002D02B File Offset: 0x0002B22B
		public static Rectangle PreviewBoundaries(AMenuComponent component)
		{
			return new Rectangle((int)(component.Position.X + (float)component.MenuWidth - (float)MenuSettings.ContainerHeight), (int)component.Position.Y, MenuSettings.ContainerHeight, MenuSettings.ContainerHeight);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0002D063 File Offset: 0x0002B263
		public static void UpdateAlpha(MenuColor component, WindowsKeys args, Rectangle rect)
		{
			component.Color = new ColorBGRA(component.Color.R, component.Color.G, component.Color.B, ThemeUtilities.GetByte(args, rect));
			component.FireEvent();
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0002D09E File Offset: 0x0002B29E
		public static void UpdateBlue(MenuColor component, WindowsKeys args, Rectangle rect)
		{
			component.Color = new ColorBGRA(component.Color.R, component.Color.G, ThemeUtilities.GetByte(args, rect), component.Color.A);
			component.FireEvent();
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0002D0D9 File Offset: 0x0002B2D9
		public static void UpdateGreen(MenuColor component, WindowsKeys args, Rectangle rect)
		{
			component.Color = new ColorBGRA(component.Color.R, ThemeUtilities.GetByte(args, rect), component.Color.B, component.Color.A);
			component.FireEvent();
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0002D114 File Offset: 0x0002B314
		public static void UpdateRed(MenuColor component, WindowsKeys args, Rectangle rect)
		{
			component.Color = new ColorBGRA(ThemeUtilities.GetByte(args, rect), component.Color.G, component.Color.B, component.Color.A);
			component.FireEvent();
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0002D14F File Offset: 0x0002B34F
		public static void UpdateAlpha(MenuColor component, SingleMouseEventArgs args, Rectangle rect)
		{
			component.Color = new ColorBGRA(component.Color.R, component.Color.G, component.Color.B, ThemeUtilities.GetByte(args, rect));
			component.FireEvent();
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0002D18A File Offset: 0x0002B38A
		public static void UpdateBlue(MenuColor component, SingleMouseEventArgs args, Rectangle rect)
		{
			component.Color = new ColorBGRA(component.Color.R, component.Color.G, ThemeUtilities.GetByte(args, rect), component.Color.A);
			component.FireEvent();
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0002D1C5 File Offset: 0x0002B3C5
		public static void UpdateGreen(MenuColor component, SingleMouseEventArgs args, Rectangle rect)
		{
			component.Color = new ColorBGRA(component.Color.R, ThemeUtilities.GetByte(args, rect), component.Color.B, component.Color.A);
			component.FireEvent();
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0002D200 File Offset: 0x0002B400
		public static void UpdateRed(MenuColor component, SingleMouseEventArgs args, Rectangle rect)
		{
			component.Color = new ColorBGRA(ThemeUtilities.GetByte(args, rect), component.Color.G, component.Color.B, component.Color.A);
			component.FireEvent();
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0002D23B File Offset: 0x0002B43B
		public static void ChangeKey(MenuKeyBind component, Keys newKey)
		{
			component.Key = newKey;
			component.Interacting = false;
			MenuManager.Instance.ResetWidth();
			component.Save();
			component.FireEvent();
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0002D261 File Offset: 0x0002B461
		public static void HandleDown(MenuKeyBind component, Keys expectedKey)
		{
			if (component.Key == Keys.ControlKey && expectedKey == (Keys.LButton | Keys.ShiftKey | Keys.Control))
			{
				expectedKey = Keys.ControlKey;
			}
			if (!component.Interacting && expectedKey == component.Key && component.Type == KeyBindType.Press)
			{
				component.Active = true;
			}
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0002D29C File Offset: 0x0002B49C
		public static void HandleUp(MenuKeyBind component, Keys expectedKey)
		{
			if (component.Type == KeyBindType.Press)
			{
				if ((expectedKey.HasFlag(Keys.Shift) && expectedKey.HasFlag(component.Key)) || expectedKey == component.Key)
				{
					component.Active = false;
					return;
				}
			}
			else if (component.Type == KeyBindType.Toggle && expectedKey == component.Key)
			{
				component.Active = !component.Active;
			}
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0002D312 File Offset: 0x0002B512
		public static string GetTranslateName(MenuList component, string name)
		{
			if (!(component.Name == "PredictionSelected"))
			{
				return LanguageTranslate.Translation(name);
			}
			return name;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0002D330 File Offset: 0x0002B530
		public static int CalcWidthText(string text)
		{
			RawRectangle rawRectangle = MenuSettings.Font.MeasureText(MenuManager.Instance.Sprite, text, FontCache.DrawFontFlags.Left);
			return rawRectangle.Right - rawRectangle.Left;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0002D361 File Offset: 0x0002B561
		public static Rectangle GetContainerRectangle(AMenuComponent component)
		{
			return new Rectangle((int)component.Position.X, (int)component.Position.Y, component.MenuWidth, MenuSettings.ContainerHeight);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0002D38B File Offset: 0x0002B58B
		public static Rectangle MeasureString(string text)
		{
			return MenuSettings.Font.MeasureText(MenuManager.Instance.Sprite, text, FontCache.DrawFontFlags.Left);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0002D3A8 File Offset: 0x0002B5A8
		public static void CalculateNewValue(MenuSlider component, SingleMouseEventArgs args)
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

		// Token: 0x060007A1 RID: 1953 RVA: 0x0002D434 File Offset: 0x0002B634
		public static void CalculateNewValue(MenuSliderButton component, WindowsKeys args)
		{
			int num = (int)Math.Round((double)((float)component.MinValue + (args.Cursor.X - component.Position.X) * (float)(component.MaxValue - component.MinValue) / (float)(component.MenuWidth - MenuSettings.ContainerHeight)));
			if (num < component.MinValue)
			{
				num = component.MinValue;
			}
			else if (num > component.MaxValue)
			{
				num = component.MaxValue;
			}
			if (num != component.ActiveValue)
			{
				component.Value = num;
				component.FireEvent();
				component.Save();
			}
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0002D4C4 File Offset: 0x0002B6C4
		public static void CalculateNewValue(MenuSliderButton component, SingleMouseEventArgs args)
		{
			int num = (int)Math.Round((double)((float)component.MinValue + (args.Cursor.X - component.Position.X) * (float)(component.MaxValue - component.MinValue) / (float)(component.MenuWidth - MenuSettings.ContainerHeight)));
			if (num < component.MinValue)
			{
				num = component.MinValue;
			}
			else if (num > component.MaxValue)
			{
				num = component.MaxValue;
			}
			if (num != component.ActiveValue)
			{
				component.Value = num;
				component.FireEvent();
				component.Save();
			}
		}

		// Token: 0x0400057E RID: 1406
		public static readonly LineCache Line = LineRender.CreateLine(1f, false, false);
	}
}

using System;
using System.Linq;
using EnsoulSharp.SDK.Core;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Utility;
using EnsoulSharp.SDK.Utils;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000B1 RID: 177
	public static class PermaShow
	{
		// Token: 0x06000605 RID: 1541 RVA: 0x000290EC File Offset: 0x000272EC
		public static void Initialize(Menu menu)
		{
			PermaShow.Menu = menu.Add<Menu>(new Menu("PermaShow", "Permashow", false));
			PermaShow.Menu.Add<MenuBool>(new MenuBool("Enabled", "Enable", true));
			PermaShow.Menu.Add<MenuSlider>(new MenuSlider("X", "Position (X)", (int)((float)Library.GameCache.WindowsValue.WindowsWidth - 0.682f * (float)Library.GameCache.WindowsValue.WindowsWidth), 0, Library.GameCache.WindowsValue.WindowsWidth)).ValueChanged += delegate(MenuSlider m, EventArgs e)
			{
				PermaShow.UpdatePositionValue();
			};
			PermaShow.Menu.Add<MenuSlider>(new MenuSlider("Y", "Position (Y)", (int)((float)Library.GameCache.WindowsValue.WindowsHeight - 0.965f * (float)Library.GameCache.WindowsValue.WindowsHeight), 0, Library.GameCache.WindowsValue.WindowsHeight)).ValueChanged += delegate(MenuSlider m, EventArgs e)
			{
				PermaShow.UpdatePositionValue();
			};
			PermaShow.Menu.Add<MenuSlider>(new MenuSlider("BorderWidth", "Width", 300, 100, 400)).ValueChanged += delegate(MenuSlider m, EventArgs e)
			{
				PermaShow.UpdatePositionValue();
			};
			PermaShow.Menu.Add<MenuSlider>(new MenuSlider("IndicatorWidth", "Indicator Width", 45, 30, 90)).ValueChanged += delegate(MenuSlider m, EventArgs e)
			{
				PermaShow.UpdatePositionValue();
			};
			MenuButton menuButton = PermaShow.Menu.Add<MenuButton>(new MenuButton("Reset", "Reset to Default", "Reset"));
			menuButton.Action = (MenuButton.ButtonAction)Delegate.Combine(menuButton.Action, new MenuButton.ButtonAction(PermaShow.ResetPermashow));
			PermashowUtility.Text = Config.EnsoulSharpFont;
			PermashowUtility.XFactor = (float)Library.GameCache.WindowsValue.WindowsWidth / 1366f;
			PermashowUtility.BoxPosition = new Vector2((float)PermaShow.Menu["X"].GetValue<MenuSlider>().Value, (float)PermaShow.Menu["Y"].GetValue<MenuSlider>().Value);
			PermashowUtility.PermashowWidth = (float)PermaShow.Menu["BorderWidth"].GetValue<MenuSlider>().Value * PermashowUtility.XFactor;
			PermashowUtility.SmallBoxWidth = (float)PermaShow.Menu["IndicatorWidth"].GetValue<MenuSlider>().Value * PermashowUtility.XFactor;
			PermashowUtility.HalfPermashowWidth = 0.96f * (PermashowUtility.PermashowWidth / 2f);
			PermashowUtility.DrawBoxWidth = PermashowUtility.BoxPosition.X + PermashowUtility.PermashowWidth / 2f - PermashowUtility.SmallBoxWidth;
			PermashowUtility.DrawBasicPosition = new Vector2(PermashowUtility.BoxPosition.X - PermashowUtility.HalfPermashowWidth, PermashowUtility.BoxPosition.Y);
			Render.OnDraw += PermaShow.OnDraw;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00029400 File Offset: 0x00027600
		public static void AddPermashow(this MenuItem menuItem, string customDisplayName = "", Color? color = null)
		{
			if (PermashowUtility.AllPermashows.Count > 0 && PermashowUtility.AllPermashows.Any((PermashowItem x) => x.Item == menuItem))
			{
				Logging.Write(false, true, "AddPermashow")(LogLevel.Warn, "[Permashow]: Already Add the same MenuItem in Permashow. Name -> " + menuItem.Name, Array.Empty<object>());
				return;
			}
			menuItem.PermasShowText = customDisplayName;
			MenuValueType menuValueType = MenuValueType.None;
			if (menuItem is MenuBool)
			{
				menuValueType = MenuValueType.Boolean;
			}
			else if (menuItem is MenuColor)
			{
				menuValueType = MenuValueType.Color;
			}
			else if (menuItem is MenuKeyBind)
			{
				menuValueType = MenuValueType.KeyBind;
			}
			else if (menuItem is MenuList)
			{
				menuValueType = MenuValueType.List;
			}
			else if (menuItem is MenuSlider)
			{
				menuValueType = MenuValueType.Slider;
			}
			else if (menuItem is MenuSliderButton)
			{
				menuValueType = MenuValueType.SliderButton;
			}
			else if (menuItem is MenuSeparator)
			{
				menuValueType = MenuValueType.Separator;
			}
			if (menuValueType == MenuValueType.Color || menuValueType == MenuValueType.None)
			{
				Logging.Write(false, true, "AddPermashow")(LogLevel.Warn, "[Permashow]: Not Support this MenuItem. Name -> " + menuItem.Name, Array.Empty<object>());
				return;
			}
			PermashowUtility.AllPermashows.Add(new PermashowItem(PermaShow.Index, menuItem, menuValueType, customDisplayName, color));
			PermaShow.Index++;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00029550 File Offset: 0x00027750
		public static void RemovePermashow(this MenuItem menuItem)
		{
			if (PermashowUtility.AllPermashows.Count > 0)
			{
				PermashowItem permashowItem = PermashowUtility.AllPermashows.Find((PermashowItem x) => x.Item == menuItem);
				if (permashowItem != null)
				{
					PermashowUtility.AllPermashows.Remove(permashowItem);
					PermashowUtility.UpdateAllIndex();
				}
			}
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000295A4 File Offset: 0x000277A4
		public static void ChangePermashowDisplayName(this MenuItem menuItem, string displayName)
		{
			if (PermashowUtility.AllPermashows.Count > 0)
			{
				foreach (PermashowItem permashowItem in PermashowUtility.AllPermashows)
				{
					if (permashowItem.Item == menuItem)
					{
						permashowItem.DisplayName = LanguageTranslate.Translation(displayName);
						permashowItem.UpdatePosition();
					}
				}
			}
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00029618 File Offset: 0x00027818
		private static void OnDraw(EventArgs args)
		{
			if (!PermaShow.Menu["Enabled"].GetValue<MenuBool>().Enabled)
			{
				return;
			}
			RectangleRender.Draw(new Vector2(PermashowUtility.BoxPosition.X - PermashowUtility.PermashowWidth / 2f, PermashowUtility.BoxPosition.Y), PermashowUtility.PermashowWidth, (float)(PermashowUtility.AllPermashows.Count * PermashowUtility.Text.FontDescription.Height) * 1.4f, 0f, PermashowUtility.Black, PermashowUtility.Black);
			foreach (PermashowItem permashowItem in PermashowUtility.AllPermashows)
			{
				permashowItem.Draw();
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x000296EC File Offset: 0x000278EC
		private static void UpdatePositionValue()
		{
			PermashowUtility.BoxPosition = new Vector2((float)PermaShow.Menu["X"].GetValue<MenuSlider>().Value, (float)PermaShow.Menu["Y"].GetValue<MenuSlider>().Value);
			PermashowUtility.PermashowWidth = (float)PermaShow.Menu["BorderWidth"].GetValue<MenuSlider>().Value * PermashowUtility.XFactor;
			PermashowUtility.SmallBoxWidth = (float)PermaShow.Menu["IndicatorWidth"].GetValue<MenuSlider>().Value * PermashowUtility.XFactor;
			PermashowUtility.HalfPermashowWidth = 0.96f * (PermashowUtility.PermashowWidth / 2f);
			PermashowUtility.DrawBoxWidth = PermashowUtility.BoxPosition.X + PermashowUtility.PermashowWidth / 2f - PermashowUtility.SmallBoxWidth;
			PermashowUtility.DrawBasicPosition = new Vector2(PermashowUtility.BoxPosition.X - PermashowUtility.HalfPermashowWidth, PermashowUtility.BoxPosition.Y);
			foreach (PermashowItem permashowItem in PermashowUtility.AllPermashows)
			{
				permashowItem.UpdatePosition();
			}
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00029820 File Offset: 0x00027A20
		private static void ResetPermashow()
		{
			PermaShow.Menu["BorderWidth"].GetValue<MenuSlider>().Value = 300;
			PermaShow.Menu["IndicatorWidth"].GetValue<MenuSlider>().Value = 45;
			PermaShow.Menu["X"].GetValue<MenuSlider>().Value = (int)((float)Library.GameCache.WindowsValue.WindowsWidth - 0.682f * (float)Library.GameCache.WindowsValue.WindowsWidth);
			PermaShow.Menu["Y"].GetValue<MenuSlider>().Value = (int)((float)Library.GameCache.WindowsValue.WindowsHeight - 0.965f * (float)Library.GameCache.WindowsValue.WindowsHeight);
			PermashowUtility.BoxPosition = new Vector2((float)PermaShow.Menu["X"].GetValue<MenuSlider>().Value, (float)PermaShow.Menu["Y"].GetValue<MenuSlider>().Value);
			PermashowUtility.PermashowWidth = 300f * PermashowUtility.XFactor;
			PermashowUtility.HalfPermashowWidth = 0.96f * (PermashowUtility.PermashowWidth / 2f);
			PermashowUtility.SmallBoxWidth = 45f * PermashowUtility.XFactor;
			PermashowUtility.DrawBoxWidth = PermashowUtility.BoxPosition.X + PermashowUtility.PermashowWidth / 2f - PermashowUtility.SmallBoxWidth;
			PermashowUtility.DrawBasicPosition = new Vector2(PermashowUtility.BoxPosition.X - PermashowUtility.HalfPermashowWidth, PermashowUtility.BoxPosition.Y);
			foreach (PermashowItem permashowItem in PermashowUtility.AllPermashows)
			{
				permashowItem.UpdatePosition();
			}
		}

		// Token: 0x0400040E RID: 1038
		private static Menu Menu;

		// Token: 0x0400040F RID: 1039
		internal static int Index;
	}
}

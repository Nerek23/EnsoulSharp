using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Utility;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000B7 RID: 183
	public abstract class AMenuComponent : IDisposable
	{
		// Token: 0x0600063D RID: 1597 RVA: 0x0002A4D5 File Offset: 0x000286D5
		internal AMenuComponent()
		{
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0002A4F0 File Offset: 0x000286F0
		protected AMenuComponent(string name, string displayName)
		{
			if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(displayName))
			{
				throw new Exception("Please enter a valid name.\nName: " + name + "\nDisplayName: " + displayName);
			}
			this.Name = name;
			this.DisplayName = LanguageTranslate.Translation(displayName);
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x0002A54F File Offset: 0x0002874F
		// (set) Token: 0x06000640 RID: 1600 RVA: 0x0002A557 File Offset: 0x00028757
		public bool DontSave { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x0002A560 File Offset: 0x00028760
		// (set) Token: 0x06000642 RID: 1602 RVA: 0x0002A568 File Offset: 0x00028768
		public string Name { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x0002A571 File Offset: 0x00028771
		// (set) Token: 0x06000644 RID: 1604 RVA: 0x0002A579 File Offset: 0x00028779
		public string DisplayName { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x0002A582 File Offset: 0x00028782
		// (set) Token: 0x06000646 RID: 1606 RVA: 0x0002A58A File Offset: 0x0002878A
		public string PermasShowText { get; set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x0002A593 File Offset: 0x00028793
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x0002A59B File Offset: 0x0002879B
		public Menu Parent { get; set; }

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x0002A5A4 File Offset: 0x000287A4
		// (set) Token: 0x0600064A RID: 1610 RVA: 0x0002A5AC File Offset: 0x000287AC
		public bool Root { get; protected set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600064B RID: 1611
		// (set) Token: 0x0600064C RID: 1612
		public abstract bool Toggled { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x0002A5B5 File Offset: 0x000287B5
		// (set) Token: 0x0600064E RID: 1614 RVA: 0x0002A5BD File Offset: 0x000287BD
		public string UniqueString { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600064F RID: 1615
		// (set) Token: 0x06000650 RID: 1616
		public abstract bool Visible { get; set; }

		// Token: 0x17000114 RID: 276
		public abstract AMenuComponent this[string name]
		{
			get;
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0002A5C6 File Offset: 0x000287C6
		public virtual void Dispose()
		{
			Menu parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.Components.Remove(this.Name);
		}

		// Token: 0x06000653 RID: 1619
		public abstract T GetValue<T>(string name) where T : MenuItem;

		// Token: 0x06000654 RID: 1620
		public abstract T GetValue<T>() where T : MenuItem;

		// Token: 0x06000655 RID: 1621 RVA: 0x0002A5E4 File Offset: 0x000287E4
		public void SetFontColor(Color color)
		{
			this.HaveCustomColor = true;
			this.FontColor = color;
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000656 RID: 1622
		// (set) Token: 0x06000657 RID: 1623
		internal abstract bool ToggleVisible { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000658 RID: 1624 RVA: 0x0002A5FC File Offset: 0x000287FC
		// (set) Token: 0x06000659 RID: 1625 RVA: 0x0002A6D2 File Offset: 0x000288D2
		internal int MenuWidth
		{
			get
			{
				if (this.resetWidth)
				{
					Menu parent = this.Parent;
					int num;
					if (parent == null)
					{
						num = (from menu in MenuManager.Instance.Menus
						where menu.Visible
						select menu).Max((Menu menu) => menu.Width);
					}
					else
					{
						num = (from comp in parent.Components
						where comp.Value.Visible
						select comp).Max((KeyValuePair<string, AMenuComponent> comp) => comp.Value.Width);
					}
					this.menuWidthCached = num;
					this.resetWidth = false;
				}
				return this.menuWidthCached;
			}
			set
			{
				this.menuWidthCached = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x0002A6DB File Offset: 0x000288DB
		// (set) Token: 0x0600065B RID: 1627 RVA: 0x0002A6E3 File Offset: 0x000288E3
		internal bool HaveCustomColor { get; set; }

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x0002A6EC File Offset: 0x000288EC
		// (set) Token: 0x0600065D RID: 1629 RVA: 0x0002A710 File Offset: 0x00028910
		internal string AssemblyName
		{
			get
			{
				if (!this.Root && this.Parent != null)
				{
					return this.Parent.assemblyConfigName;
				}
				return this.assemblyConfigName;
			}
			set
			{
				this.assemblyConfigName = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x0002A719 File Offset: 0x00028919
		// (set) Token: 0x0600065F RID: 1631 RVA: 0x0002A721 File Offset: 0x00028921
		internal ColorBGRA FontColor { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x0002A72A File Offset: 0x0002892A
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x0002A732 File Offset: 0x00028932
		internal Vector2 Position { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x0002A73C File Offset: 0x0002893C
		internal ADrawable Handler
		{
			get
			{
				if (this.themeHandler != null && this.currentTheme != ThemeManager.Current)
				{
					this.themeHandler.Dispose();
					this.themeHandler = null;
				}
				if (this.themeHandler == null || this.currentTheme != ThemeManager.Current)
				{
					this.currentTheme = ThemeManager.Current;
					this.themeHandler = this.BuildHandler(ThemeManager.Current);
					if (this.themeHandler == null)
					{
						this.themeHandler = this.defaultThemeHandler;
						Logging.Write(false, true, "Handler")(LogLevel.Warn, "No ADrawable handler exists for the component of type {0}", new object[]
						{
							base.GetType()
						});
					}
				}
				return this.themeHandler;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000663 RID: 1635
		internal abstract int Width { get; }

		// Token: 0x06000664 RID: 1636
		internal abstract void Load();

		// Token: 0x06000665 RID: 1637
		internal abstract void Save();

		// Token: 0x06000666 RID: 1638
		internal abstract void OnDraw(Vector2 position);

		// Token: 0x06000667 RID: 1639
		internal abstract void OnWndProc(WindowsKeys args);

		// Token: 0x06000668 RID: 1640
		internal abstract void OnWndProc(SingleMouseEventArgs args);

		// Token: 0x06000669 RID: 1641 RVA: 0x0002A7E1 File Offset: 0x000289E1
		internal virtual void ResetWidth()
		{
			this.resetWidth = true;
		}

		// Token: 0x0600066A RID: 1642
		public abstract void RestoreDefault();

		// Token: 0x0600066B RID: 1643 RVA: 0x0002A7EA File Offset: 0x000289EA
		internal virtual ADrawable BuildHandler(ITheme theme)
		{
			return null;
		}

		// Token: 0x04000524 RID: 1316
		private readonly ADrawable defaultThemeHandler = new ADrawableAdapter();

		// Token: 0x04000525 RID: 1317
		private string assemblyConfigName;

		// Token: 0x04000526 RID: 1318
		private ITheme currentTheme;

		// Token: 0x04000527 RID: 1319
		private int menuWidthCached;

		// Token: 0x04000528 RID: 1320
		private bool resetWidth = true;

		// Token: 0x04000529 RID: 1321
		private ADrawable themeHandler;
	}
}

using System;
using EnsoulSharp.SDK.Utility;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000BA RID: 186
	public abstract class MenuItem : AMenuComponent
	{
		// Token: 0x0600069C RID: 1692 RVA: 0x0002B492 File Offset: 0x00029692
		protected MenuItem()
		{
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0002B4A1 File Offset: 0x000296A1
		protected MenuItem(string name, string displayName) : base(name, displayName)
		{
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x0002B4B2 File Offset: 0x000296B2
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x0002B4BA File Offset: 0x000296BA
		public string Tooltip
		{
			get
			{
				return this._tooltip;
			}
			set
			{
				this._tooltip = LanguageTranslate.Translation(value);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x0002B4C8 File Offset: 0x000296C8
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x0002B4D0 File Offset: 0x000296D0
		public Color TooltipColor { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x0002B4D9 File Offset: 0x000296D9
		// (set) Token: 0x060006A3 RID: 1699 RVA: 0x0002B4E1 File Offset: 0x000296E1
		internal bool DrawTooltip { get; set; }

		// Token: 0x060006A4 RID: 1700 RVA: 0x0002B4EA File Offset: 0x000296EA
		public MenuItem SetTooltip(string str)
		{
			this.Tooltip = str;
			return this;
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x0002B4F4 File Offset: 0x000296F4
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x0002B4FC File Offset: 0x000296FC
		public bool SettingsLoaded { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x0002B505 File Offset: 0x00029705
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x0002B50D File Offset: 0x0002970D
		public override bool Toggled { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x0002B516 File Offset: 0x00029716
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x0002B51E File Offset: 0x0002971E
		public sealed override bool Visible { get; set; } = true;

		// Token: 0x17000131 RID: 305
		public override AMenuComponent this[string name]
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0002B52A File Offset: 0x0002972A
		public override T GetValue<T>()
		{
			return (T)((object)this);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0002B532 File Offset: 0x00029732
		public override T GetValue<T>(string name)
		{
			throw new Exception("Cannot get child of a MenuItem - " + name);
		}

		// Token: 0x060006AE RID: 1710
		internal abstract void Draw();

		// Token: 0x060006AF RID: 1711
		internal abstract void Extract(MenuItem component);

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x0002B544 File Offset: 0x00029744
		// (set) Token: 0x060006B1 RID: 1713 RVA: 0x0002B54C File Offset: 0x0002974C
		internal sealed override bool ToggleVisible { get; set; }

		// Token: 0x060006B2 RID: 1714 RVA: 0x0002B558 File Offset: 0x00029758
		internal override void Load()
		{
			if (base.DontSave)
			{
				return;
			}
			if (!this.SettingsLoaded && base.GetType().IsSerializable)
			{
				this.SettingsLoaded = true;
				try
				{
					byte[] arrBytes;
					if (base.Parent.SaveDictionary.TryGetValue(base.Name + base.UniqueString, out arrBytes))
					{
						MenuItem component = MenuUtils.DeserializeMenuItem<MenuItem>(arrBytes);
						this.Extract(component);
					}
				}
				catch (Exception arg)
				{
					Logging.Write(false, true, "Load")(LogLevel.Error, "Something wrong about the MenuItemSave Load." + Environment.NewLine + arg, Array.Empty<object>());
				}
			}
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0002B5FC File Offset: 0x000297FC
		internal override void Save()
		{
			if (base.DontSave)
			{
				return;
			}
			if (base.GetType().IsSerializable)
			{
				base.Parent.SaveDictionary[base.Name + base.UniqueString] = MenuUtils.SerializeMenuItem(this);
			}
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0002B63B File Offset: 0x0002983B
		internal override void OnDraw(Vector2 position)
		{
			if (this.Visible)
			{
				base.Position = position;
				this.Draw();
			}
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0002B652 File Offset: 0x00029852
		internal override void OnWndProc(WindowsKeys args)
		{
			if (!args.Process)
			{
				return;
			}
			this.WndProc(args);
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0002B664 File Offset: 0x00029864
		internal override void OnWndProc(SingleMouseEventArgs args)
		{
			this.WndProc(args);
		}

		// Token: 0x060006B7 RID: 1719
		internal abstract void WndProc(WindowsKeys args);

		// Token: 0x060006B8 RID: 1720
		internal abstract void WndProc(SingleMouseEventArgs args);

		// Token: 0x04000543 RID: 1347
		private string _tooltip;
	}
}

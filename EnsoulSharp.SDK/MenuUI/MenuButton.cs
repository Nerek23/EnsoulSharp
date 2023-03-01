using System;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Utility.MouseActivity;
using EnsoulSharp.SDK.Utils;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000BD RID: 189
	public class MenuButton : MenuItem
	{
		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060006E4 RID: 1764 RVA: 0x0002BDFC File Offset: 0x00029FFC
		// (remove) Token: 0x060006E5 RID: 1765 RVA: 0x0002BE34 File Offset: 0x0002A034
		public event MenuButton.OnValueChanged ValueChanged;

		// Token: 0x060006E6 RID: 1766 RVA: 0x0002BE69 File Offset: 0x0002A069
		public MenuButton(string name, string displayName, string buttonText) : base(name, displayName)
		{
			this.ButtonText = buttonText;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0002BE7A File Offset: 0x0002A07A
		private MenuButton()
		{
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060006E8 RID: 1768 RVA: 0x0002BE82 File Offset: 0x0002A082
		// (set) Token: 0x060006E9 RID: 1769 RVA: 0x0002BE8A File Offset: 0x0002A08A
		public MenuButton.ButtonAction Action { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060006EA RID: 1770 RVA: 0x0002BE93 File Offset: 0x0002A093
		// (set) Token: 0x060006EB RID: 1771 RVA: 0x0002BE9B File Offset: 0x0002A09B
		public string ButtonText
		{
			get
			{
				return this._buttonText;
			}
			set
			{
				this._buttonText = LanguageTranslate.Translation(value);
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060006EC RID: 1772 RVA: 0x0002BEA9 File Offset: 0x0002A0A9
		// (set) Token: 0x060006ED RID: 1773 RVA: 0x0002BEB1 File Offset: 0x0002A0B1
		public bool Active { get; set; }

		// Token: 0x060006EE RID: 1774 RVA: 0x0002BEBA File Offset: 0x0002A0BA
		internal void FireEvent()
		{
			MenuButton.OnValueChanged valueChanged = this.ValueChanged;
			if (valueChanged == null)
			{
				return;
			}
			valueChanged(this, EventArgs.Empty);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0002BED2 File Offset: 0x0002A0D2
		internal override void Extract(MenuItem component)
		{
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060006F0 RID: 1776 RVA: 0x0002BED4 File Offset: 0x0002A0D4
		internal override int Width
		{
			get
			{
				return base.Handler.Width();
			}
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0002BEE1 File Offset: 0x0002A0E1
		internal override void Draw()
		{
			base.Handler.Draw();
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0002BEEE File Offset: 0x0002A0EE
		internal override void Load()
		{
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0002BEF0 File Offset: 0x0002A0F0
		public override void RestoreDefault()
		{
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x0002BEF2 File Offset: 0x0002A0F2
		internal override void WndProc(WindowsKeys args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0002BF00 File Offset: 0x0002A100
		internal override ADrawable BuildHandler(ITheme theme)
		{
			return theme.BuildButtonHandler(this);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0002BF09 File Offset: 0x0002A109
		internal override void WndProc(SingleMouseEventArgs args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x04000556 RID: 1366
		private string _buttonText;

		// Token: 0x020004ED RID: 1261
		// (Invoke) Token: 0x060016C6 RID: 5830
		public delegate void ButtonAction();

		// Token: 0x020004EE RID: 1262
		// (Invoke) Token: 0x060016CA RID: 5834
		public delegate void OnValueChanged(MenuButton menuItem, EventArgs args);
	}
}

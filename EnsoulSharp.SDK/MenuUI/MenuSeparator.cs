using System;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Utility.MouseActivity;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000C0 RID: 192
	public class MenuSeparator : MenuItem
	{
		// Token: 0x0600072D RID: 1837 RVA: 0x0002C541 File Offset: 0x0002A741
		public MenuSeparator(string name, string displayName) : base(name, displayName)
		{
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0002C54B File Offset: 0x0002A74B
		private MenuSeparator()
		{
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x0002C553 File Offset: 0x0002A753
		internal override int Width
		{
			get
			{
				return base.Handler.Width();
			}
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0002C560 File Offset: 0x0002A760
		internal override void Extract(MenuItem component)
		{
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0002C562 File Offset: 0x0002A762
		internal override void Draw()
		{
			base.Handler.Draw();
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0002C56F File Offset: 0x0002A76F
		internal override void Load()
		{
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0002C571 File Offset: 0x0002A771
		public override void RestoreDefault()
		{
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x0002C573 File Offset: 0x0002A773
		internal override void WndProc(WindowsKeys args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0002C581 File Offset: 0x0002A781
		internal override void WndProc(SingleMouseEventArgs args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x0002C58F File Offset: 0x0002A78F
		internal override ADrawable BuildHandler(ITheme theme)
		{
			return theme.BuildSeparatorHandler(this);
		}
	}
}

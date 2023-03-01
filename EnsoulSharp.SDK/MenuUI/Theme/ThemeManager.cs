using System;
using EnsoulSharp.SDK.MenuUI.Theme.Dx9;

namespace EnsoulSharp.SDK.MenuUI.Theme
{
	// Token: 0x020000CB RID: 203
	internal class ThemeManager
	{
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x0002D7C3 File Offset: 0x0002B9C3
		// (set) Token: 0x060007CA RID: 1994 RVA: 0x0002D7D9 File Offset: 0x0002B9D9
		public static ITheme Current
		{
			get
			{
				ITheme result;
				if ((result = ThemeManager.currentTheme) == null)
				{
					result = (ThemeManager.currentTheme = ThemeManager.Default);
				}
				return result;
			}
			set
			{
				ThemeManager.currentTheme = value;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060007CB RID: 1995 RVA: 0x0002D7E1 File Offset: 0x0002B9E1
		public static ITheme Default
		{
			get
			{
				ITheme result;
				if ((result = ThemeManager.defaultTheme) == null)
				{
					result = (ThemeManager.defaultTheme = new Dx9Theme());
				}
				return result;
			}
		}

		// Token: 0x0400058B RID: 1419
		private static ITheme currentTheme;

		// Token: 0x0400058C RID: 1420
		private static ITheme defaultTheme;
	}
}

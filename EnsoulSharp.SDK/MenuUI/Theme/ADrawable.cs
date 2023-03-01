using System;

namespace EnsoulSharp.SDK.MenuUI.Theme
{
	// Token: 0x020000C5 RID: 197
	internal abstract class ADrawable<T> : ADrawable where T : AMenuComponent
	{
		// Token: 0x0600077E RID: 1918 RVA: 0x0002CEBE File Offset: 0x0002B0BE
		protected ADrawable(T component)
		{
			this.Component = component;
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x0002CECD File Offset: 0x0002B0CD
		protected T Component { get; }
	}
}

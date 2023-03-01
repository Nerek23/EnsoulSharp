using System;
using EnsoulSharp.SDK.Utility.MouseActivity;

namespace EnsoulSharp.SDK.MenuUI.Theme
{
	// Token: 0x020000C6 RID: 198
	internal abstract class ADrawable
	{
		// Token: 0x06000780 RID: 1920
		public abstract void Dispose();

		// Token: 0x06000781 RID: 1921
		public abstract void Draw();

		// Token: 0x06000782 RID: 1922
		public abstract void OnWndProc(WindowsKeys args);

		// Token: 0x06000783 RID: 1923
		public abstract void OnWndProc(SingleMouseEventArgs args);

		// Token: 0x06000784 RID: 1924
		public abstract int Width();
	}
}

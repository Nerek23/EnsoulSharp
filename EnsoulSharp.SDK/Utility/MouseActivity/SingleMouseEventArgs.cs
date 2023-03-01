using System;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Utils;
using SharpDX;

namespace EnsoulSharp.SDK.Utility.MouseActivity
{
	// Token: 0x02000089 RID: 137
	internal class SingleMouseEventArgs
	{
		// Token: 0x0600051B RID: 1307 RVA: 0x000253DD File Offset: 0x000235DD
		public SingleMouseEventArgs()
		{
			this.Cursor = EnsoulSharp.SDK.Utils.Cursor.Position;
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x000253F0 File Offset: 0x000235F0
		public Vector2 Cursor { get; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x000253F8 File Offset: 0x000235F8
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x00025400 File Offset: 0x00023600
		public SingleMouseKey Key { get; set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x00025409 File Offset: 0x00023609
		// (set) Token: 0x06000520 RID: 1312 RVA: 0x00025411 File Offset: 0x00023611
		public SingleMouseType Type { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x0002541C File Offset: 0x0002361C
		public WindowsKeyMessages WindowsKey
		{
			get
			{
				if (this.Type == SingleMouseType.MouseUp)
				{
					if (this.Key == SingleMouseKey.LeftClick)
					{
						return WindowsKeyMessages.LBUTTONUP;
					}
					if (this.Key == SingleMouseKey.RightClick)
					{
						return WindowsKeyMessages.RBUTTONUP;
					}
					if (this.Key == SingleMouseKey.XButton1Click || this.Key == SingleMouseKey.XButton2Click)
					{
						return WindowsKeyMessages.XBUTTONUP;
					}
					if (this.Key == SingleMouseKey.MiddleClick)
					{
						return WindowsKeyMessages.MBUTTONUP;
					}
				}
				else if (this.Type == SingleMouseType.MouseDown)
				{
					if (this.Key == SingleMouseKey.LeftClick)
					{
						return WindowsKeyMessages.LBUTTONDOWN;
					}
					if (this.Key == SingleMouseKey.RightClick)
					{
						return WindowsKeyMessages.RBUTTONDOWN;
					}
					if (this.Key == SingleMouseKey.XButton1Click || this.Key == SingleMouseKey.XButton2Click)
					{
						return WindowsKeyMessages.XBUTTONDOWN;
					}
					if (this.Key == SingleMouseKey.MiddleClick)
					{
						return WindowsKeyMessages.MBUTTONDOWN;
					}
				}
				else
				{
					if (this.Type == SingleMouseType.MouseDoubleClick)
					{
						return WindowsKeyMessages.LBUTTONDBLCLK;
					}
					if (this.Type == SingleMouseType.MouseWheel)
					{
						return WindowsKeyMessages.MOUSEWHEEL;
					}
				}
				return WindowsKeyMessages.NULL;
			}
		}
	}
}

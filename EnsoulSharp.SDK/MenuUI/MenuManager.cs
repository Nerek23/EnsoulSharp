using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Core;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX.Direct3D9;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000BB RID: 187
	public class MenuManager
	{
		// Token: 0x060006B9 RID: 1721 RVA: 0x0002B670 File Offset: 0x00029870
		private MenuManager()
		{
			if (Render.Platform == X3DPlatform.Direct3D9)
			{
				this.Sprite = new Sprite(Drawing.Direct3DDevice9);
			}
			Render.OnEndScene += this.OnEndScene;
			Game.OnWndProc += this.OnWndProc;
			MouseTracker.OnMouseTracker += this.OnMouseTracker;
			GameEvent.OnGameEnd += this.SaveSettings;
			AppDomain.CurrentDomain.DomainUnload += delegate(object sender, EventArgs args)
			{
				this.SaveSettings();
			};
			AppDomain.CurrentDomain.ProcessExit += delegate(object sender, EventArgs args)
			{
				this.SaveSettings();
			};
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060006BA RID: 1722 RVA: 0x0002B720 File Offset: 0x00029920
		// (set) Token: 0x060006BB RID: 1723 RVA: 0x0002B728 File Offset: 0x00029928
		public bool ForcedOpen
		{
			get
			{
				return this.forcedOpen;
			}
			set
			{
				this.forcedOpen = value;
				if (this.forcedOpen)
				{
					this.MenuVisible = true;
				}
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x0002B740 File Offset: 0x00029940
		public List<Menu> Menus { get; } = new List<Menu>();

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x0002B748 File Offset: 0x00029948
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x0002B750 File Offset: 0x00029950
		public bool MenuVisible
		{
			get
			{
				return this.menuVisible;
			}
			set
			{
				this.menuVisible = value;
				foreach (Menu menu in this.Menus)
				{
					menu.Visible = value;
					menu.ToggleVisible = value;
				}
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0002B7B0 File Offset: 0x000299B0
		public Sprite Sprite { get; }

		// Token: 0x17000137 RID: 311
		public Menu this[string name]
		{
			get
			{
				return this.Menus.FirstOrDefault((Menu menu) => menu.Name.Equals(name));
			}
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060006C1 RID: 1729 RVA: 0x0002B7EC File Offset: 0x000299EC
		// (remove) Token: 0x060006C2 RID: 1730 RVA: 0x0002B824 File Offset: 0x00029A24
		public event EventHandler OnClose;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x060006C3 RID: 1731 RVA: 0x0002B85C File Offset: 0x00029A5C
		// (remove) Token: 0x060006C4 RID: 1732 RVA: 0x0002B894 File Offset: 0x00029A94
		public event EventHandler OnOpen;

		// Token: 0x060006C5 RID: 1733 RVA: 0x0002B8C9 File Offset: 0x00029AC9
		public void Add(Menu menu)
		{
			if (!this.Menus.Contains(menu))
			{
				this.Menus.Add(menu);
			}
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0002B8E5 File Offset: 0x00029AE5
		public void Remove(Menu menu)
		{
			if (this.Menus.Contains(menu))
			{
				this.Menus.Remove(menu);
			}
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0002B902 File Offset: 0x00029B02
		public void DrawDelayed(Action a)
		{
			this.delayedDrawActions.Enqueue(a);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x0002B910 File Offset: 0x00029B10
		public void ResetWidth()
		{
			foreach (Menu menu in this.Menus)
			{
				menu.ResetWidth();
			}
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0002B960 File Offset: 0x00029B60
		protected virtual void FireOnClose()
		{
			EventHandler onClose = this.OnClose;
			if (onClose == null)
			{
				return;
			}
			onClose(this, EventArgs.Empty);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0002B978 File Offset: 0x00029B78
		protected virtual void FireOnOpen()
		{
			EventHandler onOpen = this.OnOpen;
			if (onOpen == null)
			{
				return;
			}
			onOpen(this, EventArgs.Empty);
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0002B990 File Offset: 0x00029B90
		private void OnEndScene(EventArgs args)
		{
			if (Render.Platform == X3DPlatform.Direct3D9)
			{
				if (this.MenuVisible)
				{
					if (!this.ppSpriteDrawnProtection)
					{
						this.Sprite.Begin(SpriteFlags.AlphaBlend);
						this.ppSpriteDrawnProtection = true;
					}
					ThemeManager.Current.Draw();
					if (this.ppSpriteDrawnProtection)
					{
						this.Sprite.End();
						this.ppSpriteDrawnProtection = false;
					}
					if (!this.ppSpriteDrawnProtection)
					{
						this.Sprite.Begin(SpriteFlags.AlphaBlend);
						this.ppSpriteDrawnProtection = true;
					}
					while (this.delayedDrawActions.Count > 0)
					{
						this.delayedDrawActions.Dequeue()();
					}
					if (this.ppSpriteDrawnProtection)
					{
						this.Sprite.End();
						this.ppSpriteDrawnProtection = false;
						return;
					}
				}
			}
			else if (this.MenuVisible)
			{
				ThemeManager.Current.Draw();
				while (this.delayedDrawActions.Count > 0)
				{
					this.delayedDrawActions.Dequeue()();
				}
			}
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0002BA7C File Offset: 0x00029C7C
		private void OnWndProc(GameWndEventArgs args)
		{
			if (MenuGUI.IsChatOpen)
			{
				return;
			}
			WindowsKeys windowsKeys = new WindowsKeys(args);
			if (!this.ForcedOpen)
			{
				if (windowsKeys.SingleKey == (Keys)Config.MenuKey || windowsKeys.Key == (Keys)(13 | Config.MenuKey))
				{
					bool flag = windowsKeys.Msg == WindowsKeyMessages.KEYFIRST;
					bool flag2 = windowsKeys.Msg == WindowsKeyMessages.KEYUP || windowsKeys.Msg == WindowsKeyMessages.CHAR;
					if (flag)
					{
						if (!this.MenuVisible)
						{
							this.MenuVisible = true;
							this.FireOnOpen();
						}
					}
					else if (flag2 && this.MenuVisible)
					{
						this.MenuVisible = false;
						this.FireOnClose();
					}
				}
				else if (windowsKeys.SingleKey == (Keys)Config.MenuToggleKey && windowsKeys.Msg == WindowsKeyMessages.KEYFIRST)
				{
					this.MenuVisible = !this.MenuVisible;
					if (this.MenuVisible)
					{
						this.FireOnOpen();
					}
					else
					{
						this.FireOnClose();
					}
				}
			}
			foreach (Menu menu in this.Menus)
			{
				menu.OnWndProc(windowsKeys);
			}
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0002BBA4 File Offset: 0x00029DA4
		private void OnMouseTracker(SingleMouseEventArgs args)
		{
			if (MenuGUI.IsChatOpen || Library.GameCache.IsRiot)
			{
				return;
			}
			foreach (Menu menu in this.Menus)
			{
				menu.OnWndProc(args);
			}
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0002BC0C File Offset: 0x00029E0C
		public void SaveSettings()
		{
			foreach (Menu menu in this.Menus)
			{
				menu.Save();
			}
		}

		// Token: 0x0400054A RID: 1354
		private bool forcedOpen;

		// Token: 0x0400054B RID: 1355
		private bool menuVisible;

		// Token: 0x0400054C RID: 1356
		private bool ppSpriteDrawnProtection;

		// Token: 0x0400054D RID: 1357
		private readonly Queue<Action> delayedDrawActions = new Queue<Action>();

		// Token: 0x0400054E RID: 1358
		public static readonly MenuManager Instance = new MenuManager();
	}
}

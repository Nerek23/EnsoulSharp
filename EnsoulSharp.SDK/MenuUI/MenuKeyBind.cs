using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Utility.MouseActivity;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000BF RID: 191
	[Serializable]
	public class MenuKeyBind : MenuItem, ISerializable
	{
		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000715 RID: 1813 RVA: 0x0002C28C File Offset: 0x0002A48C
		// (remove) Token: 0x06000716 RID: 1814 RVA: 0x0002C2C4 File Offset: 0x0002A4C4
		public event MenuKeyBind.OnValueChanged ValueChanged;

		// Token: 0x06000717 RID: 1815 RVA: 0x0002C2F9 File Offset: 0x0002A4F9
		public MenuKeyBind(string name, string displayName, Keys key, KeyBindType type, bool keyactive = false) : base(name, displayName)
		{
			this.Key = key;
			this.Type = type;
			this.original = key;
			this.active = keyactive;
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0002C321 File Offset: 0x0002A521
		private MenuKeyBind()
		{
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0002C32C File Offset: 0x0002A52C
		protected MenuKeyBind(SerializationInfo info, StreamingContext context)
		{
			this.Key = (Keys)info.GetValue("key", typeof(Keys));
			if (this.Type == KeyBindType.Toggle)
			{
				this.Active = (bool)info.GetValue("active", typeof(bool));
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600071A RID: 1818 RVA: 0x0002C387 File Offset: 0x0002A587
		// (set) Token: 0x0600071B RID: 1819 RVA: 0x0002C38F File Offset: 0x0002A58F
		public bool Active
		{
			get
			{
				return this.active;
			}
			set
			{
				if (this.active != value)
				{
					this.active = value;
					this.FireEvent();
				}
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x0002C3A7 File Offset: 0x0002A5A7
		// (set) Token: 0x0600071D RID: 1821 RVA: 0x0002C3AF File Offset: 0x0002A5AF
		public bool Interacting
		{
			get
			{
				return this.interacting;
			}
			set
			{
				this.interacting = value;
				MenuManager.Instance.ForcedOpen = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x0002C3C3 File Offset: 0x0002A5C3
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x0002C3CB File Offset: 0x0002A5CB
		public Keys Key { get; set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x0002C3D4 File Offset: 0x0002A5D4
		// (set) Token: 0x06000721 RID: 1825 RVA: 0x0002C3DC File Offset: 0x0002A5DC
		public KeyBindType Type { get; set; }

		// Token: 0x06000722 RID: 1826 RVA: 0x0002C3E5 File Offset: 0x0002A5E5
		internal void FireEvent()
		{
			MenuKeyBind.OnValueChanged valueChanged = this.ValueChanged;
			if (valueChanged == null)
			{
				return;
			}
			valueChanged(this, EventArgs.Empty);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0002C400 File Offset: 0x0002A600
		internal override void Extract(MenuItem value)
		{
			MenuKeyBind menuKeyBind = (MenuKeyBind)value;
			this.Key = menuKeyBind.Key;
			if (this.Type == KeyBindType.Toggle)
			{
				this.Active = menuKeyBind.active;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x0002C434 File Offset: 0x0002A634
		internal override int Width
		{
			get
			{
				return base.Handler.Width();
			}
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0002C441 File Offset: 0x0002A641
		internal override void Draw()
		{
			base.Handler.Draw();
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0002C44E File Offset: 0x0002A64E
		public override void RestoreDefault()
		{
			this.Key = this.original;
			this.Active = false;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0002C463 File Offset: 0x0002A663
		internal override void WndProc(WindowsKeys args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x0002C471 File Offset: 0x0002A671
		internal override void WndProc(SingleMouseEventArgs args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0002C47F File Offset: 0x0002A67F
		internal override ADrawable BuildHandler(ITheme theme)
		{
			return theme.BuildKeyBindHandler(this);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0002C488 File Offset: 0x0002A688
		public MenuKeyBind SetValue(bool newValue)
		{
			this.Active = newValue;
			this.FireEvent();
			return this;
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0002C498 File Offset: 0x0002A698
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("key", this.Key, typeof(Keys));
			info.AddValue("active", this.active, typeof(bool));
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0002C4F4 File Offset: 0x0002A6F4
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("key", this.Key, typeof(Keys));
			info.AddValue("active", this.active, typeof(bool));
		}

		// Token: 0x04000563 RID: 1379
		private readonly Keys original;

		// Token: 0x04000564 RID: 1380
		private bool active;

		// Token: 0x04000565 RID: 1381
		private bool interacting;

		// Token: 0x020004F0 RID: 1264
		// (Invoke) Token: 0x060016D2 RID: 5842
		public delegate void OnValueChanged(MenuKeyBind menuItem, EventArgs args);
	}
}

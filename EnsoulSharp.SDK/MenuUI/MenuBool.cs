using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Utility.MouseActivity;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000BC RID: 188
	[Serializable]
	public class MenuBool : MenuItem, ISerializable
	{
		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060006D2 RID: 1746 RVA: 0x0002BC78 File Offset: 0x00029E78
		// (remove) Token: 0x060006D3 RID: 1747 RVA: 0x0002BCB0 File Offset: 0x00029EB0
		public event MenuBool.OnValueChanged ValueChanged;

		// Token: 0x060006D4 RID: 1748 RVA: 0x0002BCE5 File Offset: 0x00029EE5
		public MenuBool(string name, string displayName, bool value = true) : base(name, displayName)
		{
			this.Enabled = value;
			this.original = value;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0002BCFD File Offset: 0x00029EFD
		protected MenuBool(SerializationInfo info, StreamingContext context)
		{
			this.Enabled = (bool)info.GetValue("enabled", typeof(bool));
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0002BD25 File Offset: 0x00029F25
		private MenuBool()
		{
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0002BD2D File Offset: 0x00029F2D
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x0002BD35 File Offset: 0x00029F35
		public bool Enabled { get; set; }

		// Token: 0x060006D9 RID: 1753 RVA: 0x0002BD3E File Offset: 0x00029F3E
		internal void FireEvent()
		{
			MenuBool.OnValueChanged valueChanged = this.ValueChanged;
			if (valueChanged == null)
			{
				return;
			}
			valueChanged(this, EventArgs.Empty);
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x0002BD56 File Offset: 0x00029F56
		internal override int Width
		{
			get
			{
				return base.Handler.Width();
			}
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0002BD63 File Offset: 0x00029F63
		internal override void Draw()
		{
			base.Handler.Draw();
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0002BD70 File Offset: 0x00029F70
		public override void RestoreDefault()
		{
			this.Enabled = this.original;
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0002BD7E File Offset: 0x00029F7E
		internal override void WndProc(WindowsKeys args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x0002BD8C File Offset: 0x00029F8C
		internal override void WndProc(SingleMouseEventArgs args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x0002BD9A File Offset: 0x00029F9A
		internal override ADrawable BuildHandler(ITheme theme)
		{
			return theme.BuildBoolHandler(this);
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x0002BDA3 File Offset: 0x00029FA3
		public MenuBool SetValue(bool newValue)
		{
			this.Enabled = newValue;
			this.FireEvent();
			return this;
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0002BDB3 File Offset: 0x00029FB3
		internal override void Extract(MenuItem component)
		{
			this.Enabled = ((MenuBool)component).Enabled;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0002BDC6 File Offset: 0x00029FC6
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("enabled", this.Enabled);
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0002BDE7 File Offset: 0x00029FE7
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("enabled", this.Enabled);
		}

		// Token: 0x04000553 RID: 1363
		private readonly bool original;

		// Token: 0x020004EC RID: 1260
		// (Invoke) Token: 0x060016C2 RID: 5826
		public delegate void OnValueChanged(MenuBool menuItem, EventArgs args);
	}
}

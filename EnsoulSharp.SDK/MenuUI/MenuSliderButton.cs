using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Utility.MouseActivity;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000C2 RID: 194
	[Serializable]
	public class MenuSliderButton : MenuItem, ISerializable
	{
		// Token: 0x14000026 RID: 38
		// (add) Token: 0x0600074F RID: 1871 RVA: 0x0002C7A8 File Offset: 0x0002A9A8
		// (remove) Token: 0x06000750 RID: 1872 RVA: 0x0002C7E0 File Offset: 0x0002A9E0
		public event MenuSliderButton.OnValueChanged ValueChanged;

		// Token: 0x06000751 RID: 1873 RVA: 0x0002C815 File Offset: 0x0002AA15
		public MenuSliderButton(string name, string displayName, int value = 0, int minValue = 0, int maxValue = 100, bool enabled = true) : base(name, displayName)
		{
			this.MinValue = minValue;
			this.MaxValue = maxValue;
			this.Value = value;
			this.Enabled = enabled;
			this.original = value;
			this.bOriginal = enabled;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0002C84D File Offset: 0x0002AA4D
		private MenuSliderButton()
		{
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0002C858 File Offset: 0x0002AA58
		protected MenuSliderButton(SerializationInfo info, StreamingContext context)
		{
			this.value = (int)info.GetValue("value", typeof(int));
			this.enabled = (bool)info.GetValue("enabled", typeof(bool));
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x0002C8AB File Offset: 0x0002AAAB
		// (set) Token: 0x06000755 RID: 1877 RVA: 0x0002C8B3 File Offset: 0x0002AAB3
		public bool Interacting { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x0002C8BC File Offset: 0x0002AABC
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x0002C8C4 File Offset: 0x0002AAC4
		public int MaxValue { get; set; }

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x0002C8CD File Offset: 0x0002AACD
		// (set) Token: 0x06000759 RID: 1881 RVA: 0x0002C8D5 File Offset: 0x0002AAD5
		public int MinValue { get; set; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x0002C8DE File Offset: 0x0002AADE
		// (set) Token: 0x0600075B RID: 1883 RVA: 0x0002C8E6 File Offset: 0x0002AAE6
		public bool Enabled
		{
			get
			{
				return this.enabled;
			}
			set
			{
				this.enabled = value;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x0002C8EF File Offset: 0x0002AAEF
		// (set) Token: 0x0600075D RID: 1885 RVA: 0x0002C8F7 File Offset: 0x0002AAF7
		public int Value
		{
			get
			{
				return this.value;
			}
			set
			{
				if (value < this.MinValue)
				{
					this.value = this.MinValue;
					return;
				}
				if (value > this.MaxValue)
				{
					this.value = this.MaxValue;
					return;
				}
				this.value = value;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x0002C92C File Offset: 0x0002AB2C
		public int ActiveValue
		{
			get
			{
				if (this.Value == this.MinValue || !this.Enabled)
				{
					return -1;
				}
				return this.value;
			}
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0002C94C File Offset: 0x0002AB4C
		internal void FireEvent()
		{
			MenuSliderButton.OnValueChanged valueChanged = this.ValueChanged;
			if (valueChanged == null)
			{
				return;
			}
			valueChanged(this, EventArgs.Empty);
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x0002C964 File Offset: 0x0002AB64
		internal override int Width
		{
			get
			{
				return base.Handler.Width();
			}
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0002C971 File Offset: 0x0002AB71
		internal override void Extract(MenuItem menuValue)
		{
			this.Value = ((MenuSliderButton)menuValue).value;
			this.Enabled = ((MenuSliderButton)menuValue).enabled;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0002C995 File Offset: 0x0002AB95
		internal override void Draw()
		{
			base.Handler.Draw();
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0002C9A2 File Offset: 0x0002ABA2
		public override void RestoreDefault()
		{
			this.Value = this.original;
			this.Enabled = this.bOriginal;
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0002C9BC File Offset: 0x0002ABBC
		internal override void WndProc(WindowsKeys args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0002C9CA File Offset: 0x0002ABCA
		internal override void WndProc(SingleMouseEventArgs args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0002C9D8 File Offset: 0x0002ABD8
		internal override ADrawable BuildHandler(ITheme theme)
		{
			return theme.BuildSliderButtonHandler(this);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0002C9E1 File Offset: 0x0002ABE1
		public MenuSliderButton SetValue(int newValue)
		{
			this.Value = newValue;
			return this;
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0002C9EB File Offset: 0x0002ABEB
		public MenuSliderButton SetValue(bool newValue)
		{
			this.Enabled = newValue;
			this.FireEvent();
			return this;
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0002C9FC File Offset: 0x0002ABFC
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("value", this.Value, typeof(int));
			info.AddValue("enabled", this.Enabled, typeof(bool));
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0002CA58 File Offset: 0x0002AC58
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("value", this.Value, typeof(int));
			info.AddValue("enabled", this.Enabled, typeof(bool));
		}

		// Token: 0x0400056F RID: 1391
		private readonly bool bOriginal;

		// Token: 0x04000570 RID: 1392
		private readonly int original;

		// Token: 0x04000571 RID: 1393
		private bool enabled;

		// Token: 0x04000572 RID: 1394
		private int value;

		// Token: 0x020004F2 RID: 1266
		// (Invoke) Token: 0x060016DA RID: 5850
		public delegate void OnValueChanged(MenuSliderButton menuItem, EventArgs args);
	}
}

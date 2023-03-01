using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Utility.MouseActivity;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000C1 RID: 193
	[Serializable]
	public class MenuSlider : MenuItem, ISerializable
	{
		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000737 RID: 1847 RVA: 0x0002C598 File Offset: 0x0002A798
		// (remove) Token: 0x06000738 RID: 1848 RVA: 0x0002C5D0 File Offset: 0x0002A7D0
		public event MenuSlider.OnValueChanged ValueChanged;

		// Token: 0x06000739 RID: 1849 RVA: 0x0002C605 File Offset: 0x0002A805
		public MenuSlider(string name, string displayName, int value = 0, int minValue = 0, int maxValue = 100) : base(name, displayName)
		{
			this.MinValue = minValue;
			this.MaxValue = maxValue;
			this.Value = value;
			this.original = value;
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x0002C62D File Offset: 0x0002A82D
		private MenuSlider()
		{
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0002C635 File Offset: 0x0002A835
		protected MenuSlider(SerializationInfo info, StreamingContext context)
		{
			this.value = (int)info.GetValue("value", typeof(int));
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x0002C65D File Offset: 0x0002A85D
		// (set) Token: 0x0600073D RID: 1853 RVA: 0x0002C665 File Offset: 0x0002A865
		public bool Interacting { get; set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x0002C66E File Offset: 0x0002A86E
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x0002C676 File Offset: 0x0002A876
		public int MaxValue { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000740 RID: 1856 RVA: 0x0002C67F File Offset: 0x0002A87F
		// (set) Token: 0x06000741 RID: 1857 RVA: 0x0002C687 File Offset: 0x0002A887
		public int MinValue { get; set; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x0002C690 File Offset: 0x0002A890
		// (set) Token: 0x06000743 RID: 1859 RVA: 0x0002C698 File Offset: 0x0002A898
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

		// Token: 0x06000744 RID: 1860 RVA: 0x0002C6CD File Offset: 0x0002A8CD
		internal void FireEvent()
		{
			MenuSlider.OnValueChanged valueChanged = this.ValueChanged;
			if (valueChanged == null)
			{
				return;
			}
			valueChanged(this, EventArgs.Empty);
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x0002C6E5 File Offset: 0x0002A8E5
		internal override int Width
		{
			get
			{
				return base.Handler.Width();
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0002C6F2 File Offset: 0x0002A8F2
		internal override void Extract(MenuItem menuValue)
		{
			this.Value = ((MenuSlider)menuValue).value;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0002C705 File Offset: 0x0002A905
		internal override void Draw()
		{
			base.Handler.Draw();
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x0002C712 File Offset: 0x0002A912
		public override void RestoreDefault()
		{
			this.Value = this.original;
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0002C720 File Offset: 0x0002A920
		internal override void WndProc(WindowsKeys args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0002C72E File Offset: 0x0002A92E
		internal override void WndProc(SingleMouseEventArgs args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0002C73C File Offset: 0x0002A93C
		internal override ADrawable BuildHandler(ITheme theme)
		{
			return theme.BuildSliderHandler(this);
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0002C745 File Offset: 0x0002A945
		public MenuSlider SetValue(int newValue)
		{
			this.Value = newValue;
			this.FireEvent();
			return this;
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0002C755 File Offset: 0x0002A955
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("value", this.Value, typeof(int));
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0002C785 File Offset: 0x0002A985
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("value", this.Value, typeof(int));
		}

		// Token: 0x04000569 RID: 1385
		private readonly int original;

		// Token: 0x0400056A RID: 1386
		private int value;

		// Token: 0x020004F1 RID: 1265
		// (Invoke) Token: 0x060016D6 RID: 5846
		public delegate void OnValueChanged(MenuSlider menuItem, EventArgs args);
	}
}

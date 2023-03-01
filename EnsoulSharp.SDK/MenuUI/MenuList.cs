using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000B5 RID: 181
	[Serializable]
	public class MenuList : MenuItem, ISerializable
	{
		// Token: 0x1400001E RID: 30
		// (add) Token: 0x0600061F RID: 1567 RVA: 0x0002A180 File Offset: 0x00028380
		// (remove) Token: 0x06000620 RID: 1568 RVA: 0x0002A1B8 File Offset: 0x000283B8
		public event MenuList.OnValueChanged ValueChanged;

		// Token: 0x06000621 RID: 1569 RVA: 0x0002A1ED File Offset: 0x000283ED
		public MenuList(string name, string displayName, string[] items, int selectValue = 0) : base(name, displayName)
		{
			base.Name = name;
			base.DisplayName = displayName;
			this.Items = items;
			this.Index = selectValue;
			this.original = selectValue;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0002A21C File Offset: 0x0002841C
		private MenuList()
		{
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0002A224 File Offset: 0x00028424
		protected MenuList(SerializationInfo info, StreamingContext context)
		{
			this.ListIndex = (int)info.GetValue("index", typeof(int));
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000624 RID: 1572 RVA: 0x0002A24C File Offset: 0x0002844C
		// (set) Token: 0x06000625 RID: 1573 RVA: 0x0002A254 File Offset: 0x00028454
		public string[] Items
		{
			get
			{
				return this.items;
			}
			set
			{
				this.items = value;
				if (this.Index >= this.items.Length)
				{
					this.Index = this.items.Length - 1;
				}
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000626 RID: 1574 RVA: 0x0002A27D File Offset: 0x0002847D
		// (set) Token: 0x06000627 RID: 1575 RVA: 0x0002A288 File Offset: 0x00028488
		public int Index
		{
			get
			{
				return this.ListIndex;
			}
			set
			{
				int num;
				if (value < 0)
				{
					num = 0;
				}
				else if (value >= this.Items.Length)
				{
					num = this.Items.Length - 1;
				}
				else
				{
					num = value;
				}
				if (num != this.ListIndex)
				{
					this.ListIndex = num;
					this.FireEvent();
				}
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x0002A2CD File Offset: 0x000284CD
		// (set) Token: 0x06000629 RID: 1577 RVA: 0x0002A2D5 File Offset: 0x000284D5
		public bool Active { get; set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x0002A2DE File Offset: 0x000284DE
		// (set) Token: 0x0600062B RID: 1579 RVA: 0x0002A2E6 File Offset: 0x000284E6
		public bool Hovering { get; set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x0002A2EF File Offset: 0x000284EF
		// (set) Token: 0x0600062D RID: 1581 RVA: 0x0002A2F7 File Offset: 0x000284F7
		public int HoveringIndex { get; set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x0002A300 File Offset: 0x00028500
		public int MaxStringWidth
		{
			get
			{
				if (this.width == 0)
				{
					foreach (RawRectangle rawRectangle in from obj in this.items
					select MenuSettings.Font.MeasureText(obj.ToString(), FontCache.DrawFontFlags.Left) into newWidth
					where newWidth.Right - newWidth.Left > this.width
					select newWidth)
					{
						this.width = rawRectangle.Right - rawRectangle.Left;
					}
				}
				return this.width;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x0002A39C File Offset: 0x0002859C
		// (set) Token: 0x06000630 RID: 1584 RVA: 0x0002A3AC File Offset: 0x000285AC
		public string SelectedValue
		{
			get
			{
				return this.items[this.Index];
			}
			set
			{
				for (int i = 0; i < this.items.Length; i++)
				{
					if (this.items[i].Equals(value))
					{
						this.Index = i;
						return;
					}
				}
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0002A3E4 File Offset: 0x000285E4
		internal void FireEvent()
		{
			MenuList.OnValueChanged valueChanged = this.ValueChanged;
			if (valueChanged == null)
			{
				return;
			}
			valueChanged(this, EventArgs.Empty);
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x0002A3FC File Offset: 0x000285FC
		internal override int Width
		{
			get
			{
				return base.Handler.Width();
			}
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0002A409 File Offset: 0x00028609
		internal override void Extract(MenuItem component)
		{
			this.Index = ((MenuList)component).Index;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0002A41C File Offset: 0x0002861C
		public override void RestoreDefault()
		{
			this.Index = this.original;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0002A42A File Offset: 0x0002862A
		internal override ADrawable BuildHandler(ITheme theme)
		{
			return theme.BuildListHandler(this);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0002A433 File Offset: 0x00028633
		public MenuList SetValue(int newValue)
		{
			this.Index = newValue;
			this.FireEvent();
			return this;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0002A443 File Offset: 0x00028643
		internal override void Draw()
		{
			base.Handler.Draw();
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0002A450 File Offset: 0x00028650
		internal override void WndProc(WindowsKeys args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0002A45E File Offset: 0x0002865E
		internal override void WndProc(SingleMouseEventArgs args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0002A46C File Offset: 0x0002866C
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("index", this.Index, typeof(int));
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0002A49C File Offset: 0x0002869C
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("index", this.Index, typeof(int));
		}

		// Token: 0x04000429 RID: 1065
		private string[] items;

		// Token: 0x0400042A RID: 1066
		private int ListIndex;

		// Token: 0x0400042B RID: 1067
		private int width;

		// Token: 0x0400042C RID: 1068
		private int original;

		// Token: 0x020004E8 RID: 1256
		// (Invoke) Token: 0x060016B3 RID: 5811
		public delegate void OnValueChanged(MenuList menuItem, EventArgs args);
	}
}

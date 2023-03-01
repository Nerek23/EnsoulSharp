using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000BE RID: 190
	[Serializable]
	public class MenuColor : MenuItem, ISerializable
	{
		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060006F7 RID: 1783 RVA: 0x0002BF18 File Offset: 0x0002A118
		// (remove) Token: 0x060006F8 RID: 1784 RVA: 0x0002BF50 File Offset: 0x0002A150
		public event MenuColor.OnValueChanged ValueChanged;

		// Token: 0x060006F9 RID: 1785 RVA: 0x0002BF85 File Offset: 0x0002A185
		public MenuColor(string name, string displayName, ColorBGRA color) : base(name, displayName)
		{
			this.Color = color;
			this.original = color;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0002BFA0 File Offset: 0x0002A1A0
		protected MenuColor(SerializationInfo info, StreamingContext context)
		{
			byte red = (byte)info.GetValue("red", typeof(byte));
			byte green = (byte)info.GetValue("green", typeof(byte));
			byte blue = (byte)info.GetValue("blue", typeof(byte));
			byte alpha = (byte)info.GetValue("alpha", typeof(byte));
			this.Color = new ColorBGRA(red, green, blue, alpha);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0002C02E File Offset: 0x0002A22E
		private MenuColor()
		{
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x0002C036 File Offset: 0x0002A236
		// (set) Token: 0x060006FD RID: 1789 RVA: 0x0002C03E File Offset: 0x0002A23E
		public bool Active { get; set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x0002C047 File Offset: 0x0002A247
		// (set) Token: 0x060006FF RID: 1791 RVA: 0x0002C04F File Offset: 0x0002A24F
		public ColorBGRA Color { get; set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x0002C058 File Offset: 0x0002A258
		// (set) Token: 0x06000701 RID: 1793 RVA: 0x0002C060 File Offset: 0x0002A260
		public bool HoveringPreview { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000702 RID: 1794 RVA: 0x0002C069 File Offset: 0x0002A269
		// (set) Token: 0x06000703 RID: 1795 RVA: 0x0002C071 File Offset: 0x0002A271
		public bool InteractingAlpha { get; set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000704 RID: 1796 RVA: 0x0002C07A File Offset: 0x0002A27A
		// (set) Token: 0x06000705 RID: 1797 RVA: 0x0002C082 File Offset: 0x0002A282
		public bool InteractingBlue { get; set; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x0002C08B File Offset: 0x0002A28B
		// (set) Token: 0x06000707 RID: 1799 RVA: 0x0002C093 File Offset: 0x0002A293
		public bool InteractingGreen { get; set; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x0002C09C File Offset: 0x0002A29C
		// (set) Token: 0x06000709 RID: 1801 RVA: 0x0002C0A4 File Offset: 0x0002A2A4
		public bool InteractingRed { get; set; }

		// Token: 0x0600070A RID: 1802 RVA: 0x0002C0AD File Offset: 0x0002A2AD
		internal void FireEvent()
		{
			MenuColor.OnValueChanged valueChanged = this.ValueChanged;
			if (valueChanged == null)
			{
				return;
			}
			valueChanged(this, EventArgs.Empty);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x0002C0C5 File Offset: 0x0002A2C5
		internal override void Extract(MenuItem component)
		{
			this.Color = ((MenuColor)component).Color;
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600070C RID: 1804 RVA: 0x0002C0D8 File Offset: 0x0002A2D8
		internal override int Width
		{
			get
			{
				return base.Handler.Width();
			}
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0002C0E5 File Offset: 0x0002A2E5
		internal override void Draw()
		{
			base.Handler.Draw();
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0002C0F2 File Offset: 0x0002A2F2
		public override void RestoreDefault()
		{
			this.Color = this.original;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0002C100 File Offset: 0x0002A300
		internal override void WndProc(WindowsKeys args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0002C10E File Offset: 0x0002A30E
		internal override void WndProc(SingleMouseEventArgs args)
		{
			base.Handler.OnWndProc(args);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0002C11C File Offset: 0x0002A31C
		internal override ADrawable BuildHandler(ITheme theme)
		{
			return theme.BuildColorHandler(this);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0002C125 File Offset: 0x0002A325
		public MenuColor SetValue(ColorBGRA newValue)
		{
			this.Color = newValue;
			this.FireEvent();
			return this;
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x0002C138 File Offset: 0x0002A338
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("red", this.Color.R, typeof(byte));
			info.AddValue("green", this.Color.G, typeof(byte));
			info.AddValue("blue", this.Color.B, typeof(byte));
			info.AddValue("alpha", this.Color.A, typeof(byte));
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0002C1E8 File Offset: 0x0002A3E8
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("red", this.Color.R, typeof(byte));
			info.AddValue("green", this.Color.G, typeof(byte));
			info.AddValue("blue", this.Color.B, typeof(byte));
			info.AddValue("alpha", this.Color.A, typeof(byte));
		}

		// Token: 0x0400055A RID: 1370
		private readonly ColorBGRA original;

		// Token: 0x020004EF RID: 1263
		// (Invoke) Token: 0x060016CE RID: 5838
		public delegate void OnValueChanged(MenuColor menuItem, EventArgs args);
	}
}

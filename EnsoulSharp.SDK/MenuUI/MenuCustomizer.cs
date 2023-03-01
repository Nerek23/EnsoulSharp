using System;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;
using SharpDX.Direct3D9;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000B8 RID: 184
	internal class MenuCustomizer : Menu
	{
		// Token: 0x0600066C RID: 1644 RVA: 0x0002A7ED File Offset: 0x000289ED
		private MenuCustomizer(Menu parentMenu) : base("Customize", "Menu Customize", false)
		{
			parentMenu.Add<MenuCustomizer>(this);
			this.BuildCustomizer();
			this.ApplyChanges();
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x0002A814 File Offset: 0x00028A14
		// (set) Token: 0x0600066E RID: 1646 RVA: 0x0002A81C File Offset: 0x00028A1C
		public MenuColor BackgroundColor { get; private set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x0002A825 File Offset: 0x00028A25
		// (set) Token: 0x06000670 RID: 1648 RVA: 0x0002A82D File Offset: 0x00028A2D
		public MenuColor TextColor { get; private set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x0002A836 File Offset: 0x00028A36
		// (set) Token: 0x06000672 RID: 1650 RVA: 0x0002A83E File Offset: 0x00028A3E
		public MenuSlider ContainerHeight { get; private set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x0002A847 File Offset: 0x00028A47
		// (set) Token: 0x06000674 RID: 1652 RVA: 0x0002A84F File Offset: 0x00028A4F
		public MenuSlider FontHeight { get; private set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x0002A858 File Offset: 0x00028A58
		// (set) Token: 0x06000676 RID: 1654 RVA: 0x0002A860 File Offset: 0x00028A60
		public MenuList FontName { get; private set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x0002A869 File Offset: 0x00028A69
		// (set) Token: 0x06000678 RID: 1656 RVA: 0x0002A871 File Offset: 0x00028A71
		public MenuSlider PositionX { get; private set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x0002A87A File Offset: 0x00028A7A
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x0002A882 File Offset: 0x00028A82
		public MenuSlider PositionY { get; private set; }

		// Token: 0x0600067B RID: 1659 RVA: 0x0002A88B File Offset: 0x00028A8B
		internal static void Initialize(Menu menu)
		{
			if (MenuCustomizer.Instance == null)
			{
				MenuCustomizer.Instance = new MenuCustomizer(menu);
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600067C RID: 1660 RVA: 0x0002A8A0 File Offset: 0x00028AA0
		private string GetFontName
		{
			get
			{
				switch (this.FontName.Index)
				{
				case 0:
					return "Arial";
				case 2:
					return "Calibri";
				case 3:
					return "Segoe UI";
				case 4:
					return "Microsoft YaHei";
				}
				return "Tahoma";
			}
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0002A8F4 File Offset: 0x00028AF4
		private void ApplyChanges()
		{
			MenuSettings.Position = new Vector2((float)this.PositionX.Value, (float)this.PositionY.Value);
			MenuSettings.ContainerHeight = this.ContainerHeight.Value;
			MenuSettings.RootContainerColor = new ColorBGRA(this.BackgroundColor.Color.R, this.BackgroundColor.Color.G, this.BackgroundColor.Color.B, this.BackgroundColor.Color.A);
			MenuSettings.HoverColor = new ColorBGRA(this.BackgroundColor.Color.R, this.BackgroundColor.Color.G, this.BackgroundColor.Color.B, this.BackgroundColor.Color.A);
			MenuSettings.TextColor = new ColorBGRA(this.TextColor.Color.R, this.TextColor.Color.G, this.TextColor.Color.B, byte.MaxValue);
			FontCache font = MenuSettings.Font;
			MenuSettings.Font = TextRender.CreateFont(new FontCache.DrawFontDescription
			{
				Height = this.FontHeight.Value,
				Weight = FontCache.DrawFontWeight.DoNotCare,
				OutputPrecision = FontPrecision.Raster,
				Quality = FontQuality.Antialiased,
				PitchAndFamily = FontPitchAndFamily.Decorative,
				FaceName = this.GetFontName
			});
			font.Dispose();
			MenuManager.Instance.ResetWidth();
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0002AA68 File Offset: 0x00028C68
		private void BuildCustomizer()
		{
			this.PositionX = this.Add<MenuSlider>(new MenuSlider("x", "Position (X)", (int)MenuSettings.Position.X, 0, Library.GameCache.WindowsValue.WindowsWidth));
			this.PositionY = this.Add<MenuSlider>(new MenuSlider("y", "Position (Y)", (int)MenuSettings.Position.Y, 0, Library.GameCache.WindowsValue.WindowsHeight));
			this.ContainerHeight = this.Add<MenuSlider>(new MenuSlider("containerheight", "Item Height", MenuSettings.ContainerHeight, 15, 50));
			this.FontHeight = this.Add<MenuSlider>(new MenuSlider("fontheight", "Font Size", MenuSettings.Font.FontDescription.Height, 15, 30));
			this.FontName = this.Add<MenuList>(new MenuList("fontname", "Font Name (Need F5 reload)", new string[]
			{
				"Arial",
				"Tahoma",
				"Calibri",
				"Segoe UI",
				"Microsoft YaHei"
			}, 1));
			this.BackgroundColor = this.Add<MenuColor>(new MenuColor("backgroundcolor", "Background Color", MenuSettings.RootContainerColor));
			this.TextColor = this.Add<MenuColor>(new MenuColor("textcolor", "Text Color", Color.White));
			this.Add<MenuButton>(new MenuButton("apply", "Apply Changes", "Apply")
			{
				Action = new MenuButton.ButtonAction(this.ApplyChanges)
			});
			this.Add<MenuButton>(new MenuButton("reset", "Reset Customization", "Reset")
			{
				Action = delegate
				{
					this.RestoreDefault();
					this.ApplyChanges();
				}
			});
		}

		// Token: 0x04000534 RID: 1332
		public static MenuCustomizer Instance;
	}
}
